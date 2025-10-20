using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusManager.Migrations
{
    /// <inheritdoc />
    public partial class AddBusAndDriverToRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusId",
                table: "BusRoutes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "BusRoutes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusId",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "BusRoutes");
        }
    }
}
