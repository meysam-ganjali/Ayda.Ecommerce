using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayda.Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserFild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Address", "CreatedDate", "Password", "PostalCode" },
                values: new object[] { null, new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(652), "AQAAAAEAACcQAAAAEK4Gqml2goKAwSlkuXTf+HG0NwvE3edfjmxP3pS118DVIDhX8hL2YGJS9XCMHFS36g==", null });

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "Possitions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 16, 50, 5, 45, DateTimeKind.Local).AddTicks(599));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
