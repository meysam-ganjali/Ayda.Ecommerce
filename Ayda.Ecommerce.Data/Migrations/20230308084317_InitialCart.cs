using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayda.Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrowserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    TotalSum = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(1979), "AQAAAAEAACcQAAAAEECd7rZ+UT92zR5ilqKYMl4TvlakldVI6kCdXunOR2VabA746XUAIpikC4TGrOkL9g==" });

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 12, 13, 17, 16, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

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
        }
    }
}
