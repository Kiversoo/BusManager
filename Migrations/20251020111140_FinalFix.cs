using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusManager.Migrations
{
    /// <inheritdoc />
    public partial class FinalFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Buses_BusId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_BusId",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "BusRoutes");

            migrationBuilder.RenameColumn(
                name: "Driver",
                table: "Buses",
                newName: "Status");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Repairs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<string>(
                name: "BusNumber",
                table: "Repairs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RepairDate",
                table: "Repairs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Drivers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Buses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Buses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "BusRoutes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "BusRoutes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusRoutes",
                table: "BusRoutes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusRoutes",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "BusNumber",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "RepairDate",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "BusRoutes");

            migrationBuilder.RenameTable(
                name: "BusRoutes",
                newName: "Routes");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Buses",
                newName: "Driver");

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Repairs",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_BusId",
                table: "Repairs",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Buses_BusId",
                table: "Repairs",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
