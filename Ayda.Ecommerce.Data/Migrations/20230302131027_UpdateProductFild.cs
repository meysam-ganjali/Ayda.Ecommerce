using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayda.Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductFild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountLableText",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountLableText",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 1, 16, 39, 45, 460, DateTimeKind.Local).AddTicks(9963), "AQAAAAEAACcQAAAAEL3EKlTsYEhkVZNF2P7FMBOWjMeY0wq6F33VmFgA4DGH9Z6fHy+d0VTmAyE2XSo7jQ==" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 16, 39, 45, 460, DateTimeKind.Local).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 16, 39, 45, 460, DateTimeKind.Local).AddTicks(9916));
        }
    }
}
