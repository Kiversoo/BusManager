using BusManager.Models;


namespace BusManager.Data
{
    
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {

            Console.WriteLine("🔹 DbInitializer.Seed() запущен!"); 
            Console.WriteLine($"Buses count before seeding: {context.Buses.Count()}");
            Console.WriteLine($"Drivers count before seeding: {context.Drivers.Count()}");
            Console.WriteLine($"BusRoutes count before seeding: {context.BusRoutes.Count()}");
            Console.WriteLine($"Repairs count before seeding: {context.Repairs.Count()}");


            // Если уже есть данные — выходим
            if (context.Buses.Any() || context.Drivers.Any() || context.BusRoutes.Any() || context.Repairs.Any())
                return;

            // === Buses ===
            var buses = new List<Bus>
            {
                new Bus { Model = "Mercedes Sprinter", Number = "A001", Capacity = 20, Status = "Active" },
                new Bus { Model = "ЛиАЗ 4292", Number = "B002", Capacity = 40, Status = "Under Maintenance" }
            };
            context.Buses.AddRange(buses);

            // === Drivers ===
            var drivers = new List<Driver>
            {
                new Driver { Name = "Иванов Иван", LicenseNumber = "AB12345", Phone = "123-456-789", ExperienceYears = 5 },
                new Driver { Name = "Петров Пётр", LicenseNumber = "BC98765", Phone = "987-654-321", ExperienceYears = 8 }
            };
            context.Drivers.AddRange(drivers);

            // === Bus Routes ===
            var routes = new List<BusRoute>
            {
                new BusRoute { Name = "Маршрут №1", StartLocation = "Центр", EndLocation = "Аэропорт", DistanceKm = 15.4 },
                new BusRoute { Name = "Маршрут №2", StartLocation = "Вокзал", EndLocation = "Университет", DistanceKm = 8.7 }
            };
            context.BusRoutes.AddRange(routes);

            // === Repairs ===
            var repairs = new List<Repair>
            {
                new Repair { BusNumber = "A001", Description = "Замена масла", RepairDate = DateTime.Now.AddDays(-10), Cost = 1500 },
                new Repair { BusNumber = "B002", Description = "Ремонт тормозов", RepairDate = DateTime.Now.AddDays(-5), Cost = 3000 }
            };
            context.Repairs.AddRange(repairs);

            context.SaveChanges();
        }
    }
}
