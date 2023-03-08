using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayda.Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartFild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Carts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9017), "AQAAAAEAACcQAAAAEHLLvck7ngDW6KasDTyqLUf0TKrznd20Lx2iGPMLAbppjjlfkLO+n+KYjeIXA/VduA==" });

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9065));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(8925));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Carts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
        }
    }
}
