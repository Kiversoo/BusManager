using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusManager.Data;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using BusManager.Models;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// 🔹 Подключаем базы данных (SQLite)
// ==========================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ==========================
// 🔹 Identity и роли
// ==========================
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultUI()
.AddDefaultTokenProviders();

// ==========================
// 🔹 Настройки Identity
// ==========================
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});

// ==========================
// 🔹 MVC и Razor Pages
// ==========================
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// ==========================
// 🔹 Создаём роли, админа и сидим тестовые данные
// ==========================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var context = services.GetRequiredService<AppDbContext>();

        string[] roles = { "Admin", "User" };
        foreach (var role in roles)
        {
            if (!roleManager.RoleExistsAsync(role).Result)
                roleManager.CreateAsync(new IdentityRole(role)).Wait();
        }

        string adminEmail = "admin@site.com";
        string adminPassword = "Admin123!";
        var adminUser = userManager.FindByEmailAsync(adminEmail).Result;

        if (adminUser == null)
        {
            var newAdmin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };
            var result = userManager.CreateAsync(newAdmin, adminPassword).Result;
            if (result.Succeeded)
                userManager.AddToRoleAsync(newAdmin, "Admin").Wait();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Ошибка при инициализации базы данных: " + ex.Message);
    }
}

// ==========================
// 🔹 Автоматическое добавление роли User при входе
// ==========================
app.Use(async (context, next) =>
{
    if (context.User.Identity?.IsAuthenticated == true)
    {
        var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
        var user = await userManager.GetUserAsync(context.User);

        if (user != null && !await userManager.IsInRoleAsync(user, "User"))
        {
            await userManager.AddToRoleAsync(user, "User");
        }
    }
    await next();
});

// ==========================
// 🔹 Конвейер обработки запросов
// ==========================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
