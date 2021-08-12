using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1308b710-d2ab-48ee-ad52-846cab919d2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aff3b0d-9802-4005-8d8b-8284354a0ff9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68176dc8-a85e-4a38-b5ba-df715644776e", "126133de-ac8b-4463-8f33-dde83fcef9d0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05a2aea1-8ea9-4372-855b-65c373d6a78e", "0d0ee844-8b13-4b90-bb07-6a603815856c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05a2aea1-8ea9-4372-855b-65c373d6a78e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68176dc8-a85e-4a38-b5ba-df715644776e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1308b710-d2ab-48ee-ad52-846cab919d2a", "3d68c5cb-70e1-491f-8dce-b7a68ac2cc6f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1aff3b0d-9802-4005-8d8b-8284354a0ff9", "e743ef22-5ffc-446e-8127-b4bcbf2a997d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
