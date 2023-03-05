using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ayda.Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSliders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Possitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PossitionNameFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProssitionNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PossitionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banners_Possitions_PossitionId",
                        column: x => x.PossitionId,
                        principalTable: "Possitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PossitionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sliders_Possitions_PossitionId",
                        column: x => x.PossitionId,
                        principalTable: "Possitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1885), "AQAAAAEAACcQAAAAEGwzG8znu+CQEeF1HZ41YGiV9+2IUFRAM5ue6f36k+L77/i4kUQv3J15ZAjrdfsSdw==" });

            migrationBuilder.InsertData(
                table: "Possitions",
                columns: new[] { "Id", "CreatedDate", "IsShow", "PossitionNameFA", "ProssitionNameEN", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1945), true, "بالا", "UP", null },
                    { 2, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1956), true, "پایین", "BUTTOM", null },
                    { 3, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1964), true, "چپ", "LEFT", null },
                    { 4, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1971), true, "راست", "RIGHT", null },
                    { 5, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1979), true, "بالا - چپ", "UP-LEFT", null },
                    { 6, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1993), true, "بالا - راست", "UP-RIGHT", null },
                    { 7, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(2001), true, "وسط", "CENTER", null },
                    { 8, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(2008), true, "وسط - راست", "CENTER-RIGHT", null },
                    { 9, new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(2015), true, "وسط - چپ", "CENTER-Left", null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1657));

            migrationBuilder.CreateIndex(
                name: "IX_Banners_PossitionId",
                table: "Banners",
                column: "PossitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_PossitionId",
                table: "Sliders",
                column: "PossitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Possitions");

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 2, 16, 40, 27, 685, DateTimeKind.Local).AddTicks(5503), "AQAAAAEAACcQAAAAEFBDtSfbfdvW2X7JF97wWmn97dxY2TYpFoupz/914sxfRqMXS9fKrQV4YJQI1SKczw==" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 2, 16, 40, 27, 685, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 2, 16, 40, 27, 685, DateTimeKind.Local).AddTicks(5448));
        }
    }
}
