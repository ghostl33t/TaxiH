using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiHDbContext.DBContext.Migrations
{
    /// <inheritdoc />
    public partial class InitializingMultipleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeRideHistoryId",
                table: "Zones",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Validated = table.Column<bool>(type: "bit", nullable: false),
                    HQPhone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HQAdress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCityInterests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCityInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCityInterests_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCityInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAvailabilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAvailabilities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAvailabilities_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCars_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyEmployees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrivatePhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyCarId = table.Column<long>(type: "bigint", nullable: false),
                    ZoneId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyEmployees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyEmployees_CompanyCars_CompanyCarId",
                        column: x => x.CompanyCarId,
                        principalTable: "CompanyCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyEmployees_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyAvailabilityId = table.Column<long>(type: "bigint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CompanyEmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyNumbers_CompanyAvailabilities_CompanyAvailabilityId",
                        column: x => x.CompanyAvailabilityId,
                        principalTable: "CompanyAvailabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyNumbers_CompanyEmployees_CompanyEmployeeId",
                        column: x => x.CompanyEmployeeId,
                        principalTable: "CompanyEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRideHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneIdFrom = table.Column<long>(type: "bigint", nullable: false),
                    ZoneIdTo = table.Column<long>(type: "bigint", nullable: false),
                    CompanyEmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRideHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRideHistories_CompanyEmployees_CompanyEmployeeId",
                        column: x => x.CompanyEmployeeId,
                        principalTable: "CompanyEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zones_EmployeeRideHistoryId",
                table: "Zones",
                column: "EmployeeRideHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAvailabilities_CityId",
                table: "CompanyAvailabilities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAvailabilities_CompanyId",
                table: "CompanyAvailabilities",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CompanyId",
                table: "CompanyCars",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployees_CompanyCarId",
                table: "CompanyEmployees",
                column: "CompanyCarId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployees_CompanyId",
                table: "CompanyEmployees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployees_ZoneId",
                table: "CompanyEmployees",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNumbers_CompanyAvailabilityId",
                table: "CompanyNumbers",
                column: "CompanyAvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNumbers_CompanyEmployeeId",
                table: "CompanyNumbers",
                column: "CompanyEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRideHistories_CompanyEmployeeId",
                table: "EmployeeRideHistories",
                column: "CompanyEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCityInterests_CityId",
                table: "UserCityInterests",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCityInterests_UserId",
                table: "UserCityInterests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_EmployeeRideHistories_EmployeeRideHistoryId",
                table: "Zones",
                column: "EmployeeRideHistoryId",
                principalTable: "EmployeeRideHistories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zones_EmployeeRideHistories_EmployeeRideHistoryId",
                table: "Zones");

            migrationBuilder.DropTable(
                name: "CompanyNumbers");

            migrationBuilder.DropTable(
                name: "EmployeeRideHistories");

            migrationBuilder.DropTable(
                name: "UserCityInterests");

            migrationBuilder.DropTable(
                name: "CompanyAvailabilities");

            migrationBuilder.DropTable(
                name: "CompanyEmployees");

            migrationBuilder.DropTable(
                name: "CompanyCars");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Zones_EmployeeRideHistoryId",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "EmployeeRideHistoryId",
                table: "Zones");
        }
    }
}
