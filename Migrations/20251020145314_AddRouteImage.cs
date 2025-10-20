using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusManager.Migrations
{
    /// <inheritdoc />
    public partial class AddRouteImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MapImagePath",
                table: "BusRoutes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RouteImagePath",
                table: "BusRoutes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapImagePath",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "RouteImagePath",
                table: "BusRoutes");
        }
    }
}
