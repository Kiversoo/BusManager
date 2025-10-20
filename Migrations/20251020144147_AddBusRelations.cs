using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusManager.Migrations
{
    /// <inheritdoc />
    public partial class AddBusRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Buses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Buses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_BusId",
                table: "Repairs",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_DriverId",
                table: "Buses",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_RouteId",
                table: "Buses",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_BusRoutes_RouteId",
                table: "Buses",
                column: "RouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Drivers_DriverId",
                table: "Buses",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Buses_BusId",
                table: "Repairs",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_BusRoutes_RouteId",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Drivers_DriverId",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Buses_BusId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_BusId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Buses_DriverId",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_RouteId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Buses");
        }
    }
}
