using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class AddGamePlayerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfa3c4c0-74ab-4718-9c8f-6aa19a9d8934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbf5494f-7ca1-452b-85b3-5dafa10b4728");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "GamePlayer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b542eabd-3261-41e8-8f33-ed1093de4778", "80964d41-4918-4a9f-bb28-673efda728e4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e52ed3a-8b5c-4598-a3c9-3d61c0598a09", "817aaf06-061f-4dc1-a910-4ccb7225e07a", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e52ed3a-8b5c-4598-a3c9-3d61c0598a09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b542eabd-3261-41e8-8f33-ed1093de4778");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "GamePlayer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fbf5494f-7ca1-452b-85b3-5dafa10b4728", "dd429cd2-1789-46db-a80e-9f210cbc5906", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfa3c4c0-74ab-4718-9c8f-6aa19a9d8934", "f785a408-4d5c-406f-bb83-2c87f1441e7c", "Administrator", "ADMINISTRATOR" });
        }
    }
}
