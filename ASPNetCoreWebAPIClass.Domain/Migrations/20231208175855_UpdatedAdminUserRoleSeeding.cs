using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCoreWebAPIClass.Domain.Migrations
{
    public partial class UpdatedAdminUserRoleSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3e860248-4fb8-4aea-9787-8dd99b77046a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "c5936ffb-388c-4795-af41-da675dad4135", "ecommerceadmin@gmail.com", "ECOMMERCEADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEP+nvHc2DF7r6qqzUpA+cBcWoGg5TQNEnT8tPTFD//zFhHTQZMqkGotY5IU9bW6/BA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4a8b661d-5c3d-466a-b3e5-e0b989b27a51");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "2ea24f17-cc0f-4677-99af-b4d0cfbfe65d", null, null, "AQAAAAEAACcQAAAAELF89loWAorwagLVxpqXn1x2g6nNnnXi/46SD/RB8mH8ccmPCFDMd1rmehMh4K40OA==" });
        }
    }
}
