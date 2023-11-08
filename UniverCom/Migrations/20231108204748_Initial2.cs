using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniverCom.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("19565003-8a8b-4c78-815a-e267f4ed95eb"), new Guid("42f95cc7-18d0-447e-9034-e4d0b0aa8e95") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("19565003-8a8b-4c78-815a-e267f4ed95eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42f95cc7-18d0-447e-9034-e4d0b0aa8e95"));

            migrationBuilder.RenameColumn(
                name: "Secondname",
                table: "AspNetUsers",
                newName: "Fathername");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0bba0156-e9c4-4264-b79f-f14e37af5460"), null, "Teacher", "TEACHER" },
                    { new Guid("343f55fe-6ebf-4afa-8da8-fe018db400db"), null, "Student", "STUDENT" },
                    { new Guid("7316f54c-adbe-4aaf-b20b-53338c858fe1"), null, "Curator", "CURATOR" },
                    { new Guid("e1c1c3f9-7d55-42a6-978b-9cbefde501f0"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccessToken", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fathername", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("679f7a6c-f857-40f3-a249-87710861be7c"), 0, null, "47b3875a-97d4-454f-b8e9-43440f754535", null, false, null, null, null, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEA3nt/PBz9Lu17nsp80myFP71tAhgaDdJh2d3GP/hqmxJVKQKbGkPi/7WmBhKOCjiQ==", null, false, null, "4979e5aa-ad2b-4c1a-aff3-0cc139cfc6ef", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("e1c1c3f9-7d55-42a6-978b-9cbefde501f0"), new Guid("679f7a6c-f857-40f3-a249-87710861be7c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0bba0156-e9c4-4264-b79f-f14e37af5460"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f55fe-6ebf-4afa-8da8-fe018db400db"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7316f54c-adbe-4aaf-b20b-53338c858fe1"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1c1c3f9-7d55-42a6-978b-9cbefde501f0"), new Guid("679f7a6c-f857-40f3-a249-87710861be7c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1c1c3f9-7d55-42a6-978b-9cbefde501f0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("679f7a6c-f857-40f3-a249-87710861be7c"));

            migrationBuilder.RenameColumn(
                name: "Fathername",
                table: "AspNetUsers",
                newName: "Secondname");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("19565003-8a8b-4c78-815a-e267f4ed95eb"), null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccessToken", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "Secondname", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("42f95cc7-18d0-447e-9034-e4d0b0aa8e95"), 0, null, "7fd43b13-c914-48cd-8ac4-e373056a0028", null, false, null, null, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEArKNpS16jomNEWEOMtTntlGSl26zaBnVWIVyTRwnm8YRIcs2IvoMkAZ9RvUfnyAeg==", null, false, null, null, "730d7d16-4640-4be1-a5e8-3aa5deed0628", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("19565003-8a8b-4c78-815a-e267f4ed95eb"), new Guid("42f95cc7-18d0-447e-9034-e4d0b0aa8e95") });
        }
    }
}
