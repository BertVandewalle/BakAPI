using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class addDeltaEloToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00a06302-d48a-486a-8ad5-73ebe2e3d851");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "817a5cb4-4be9-4c35-b5d6-f007de1199af");

            migrationBuilder.AddColumn<double>(
                name: "GreDefDeltaElo",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GreOffDeltaElo",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RedDefDeltaElo",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RedOffDeltaElo",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a48f78f-b37a-495e-9213-186245c0d2dd", "bae32fd3-a810-4a56-a0f3-ac587ca139a0", "User", "USER" },
                    { "d5e5db0f-c785-4665-8fd0-4921228482a9", "2589d4dd-c0ba-4cc1-ad8f-88e828e6f87d", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a48f78f-b37a-495e-9213-186245c0d2dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5e5db0f-c785-4665-8fd0-4921228482a9");

            migrationBuilder.DropColumn(
                name: "GreDefDeltaElo",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GreOffDeltaElo",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RedDefDeltaElo",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RedOffDeltaElo",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "817a5cb4-4be9-4c35-b5d6-f007de1199af", "fde8c2bf-efec-4acc-aba4-9b185d9c0a6c", "User", "USER" },
                    { "00a06302-d48a-486a-8ad5-73ebe2e3d851", "53266a66-f4a5-44b1-b4e2-4171ccecabaf", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
