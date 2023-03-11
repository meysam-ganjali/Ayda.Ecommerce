using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayda.Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.CreateTable(
                name: "RequestPays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestPays_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RequestPayId = table.Column<long>(type: "bigint", nullable: false),
                    OrderState = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_RequestPays_RequestPayId",
                        column: x => x.RequestPayId,
                        principalTable: "RequestPays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
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
                values: new object[] { new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4844), "AQAAAAEAACcQAAAAENxaupoVqPA8Q7beXenlKs5EshpJyQ1X9TJoe0H4toU7EgTvxK7Fj6FQ2UNBAVuG+g==" });

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 18, 22, 47, 193, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RequestPayId",
                table: "Orders",
                column: "RequestPayId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestPays_UserId",
                table: "RequestPays",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RequestPays");

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsShow = table.Column<bool>(type: "bit", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8090), "AQAAAAEAACcQAAAAENr4ArouBMyVpGgU8iwAlBPU2yLhRVaDlACsLyLsJ14PYDiGnEYp3/KmoPxkr+r2lw==" });

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 11, 17, 57, 21, 440, DateTimeKind.Local).AddTicks(8029));

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");
        }
    }
}
