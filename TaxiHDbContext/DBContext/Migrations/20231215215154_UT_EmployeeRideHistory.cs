using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiHDbContext.DBContext.Migrations
{
    /// <inheritdoc />
    public partial class UT_EmployeeRideHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishTime",
                table: "EmployeeRideHistories",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "EmployeeRideHistories",
                type: "datetime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "EmployeeRideHistories");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "EmployeeRideHistories");
        }
    }
}
