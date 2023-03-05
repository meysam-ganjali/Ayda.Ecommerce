using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayda.Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubMenus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubMenus_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(6988), "AQAAAAEAACcQAAAAEOBQYZHecVVR83CVt97sMbMpaeJEu1skMtAMoYqKfbYXGid4FfI2ESHxwaGONMFraA==" });

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 18, 28, 6, 947, DateTimeKind.Local).AddTicks(6385));

            migrationBuilder.CreateIndex(
                name: "IX_SubMenus_CategoryId",
                table: "SubMenus",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubMenus_MenuItemId",
                table: "SubMenus",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubMenus");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1885), "AQAAAAEAACcQAAAAEGwzG8znu+CQEeF1HZ41YGiV9+2IUFRAM5ue6f36k+L77/i4kUQv3J15ZAjrdfsSdw==" });

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 16, 13, 48, 621, DateTimeKind.Local).AddTicks(2015));

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
        }
    }
}
