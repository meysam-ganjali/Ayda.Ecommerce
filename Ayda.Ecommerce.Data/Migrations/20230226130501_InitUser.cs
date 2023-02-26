using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayda.Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneConfirm = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LastLoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "Avatar", "CreatedDate", "Email", "EmailConfirm", "FName", "Gender", "IsActive", "IsLocked", "LName", "LastLoginDateTime", "LockoutEndDate", "OrganizationEmail", "Password", "PhoneConfirm", "RoleId", "UpdatedDate", "UserPhone" },
                values: new object[] { 1L, null, new DateTime(2023, 2, 26, 16, 35, 1, 798, DateTimeKind.Local).AddTicks(6197), "ganjalimeysam@gmail.com", true, "Meysam", 1, true, false, "Ganjali", null, null, "GANJALIMEYSAM@GMAIL.COM", "AQAAAAEAACcQAAAAEI3mNu2jByB2UigB3H3L2XAekq4BxhcMBIh0EqAVscXC2LbGMVCc+5XSUEXyHyweMg==", true, 1, null, "09187504331" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 16, 35, 1, 798, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 16, 35, 1, 798, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_RoleId",
                table: "ApplicationUsers",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 25, 18, 14, 24, 558, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 25, 18, 14, 24, 558, DateTimeKind.Local).AddTicks(2877));
        }
    }
}
