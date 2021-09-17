using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class AddElodetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a48f78f-b37a-495e-9213-186245c0d2dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5e5db0f-c785-4665-8fd0-4921228482a9");

            migrationBuilder.AddColumn<double>(
                name: "EloGreDefBase",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloGreDefBonus",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloGreOffBase",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloGreOffBonus",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloGreTeamBonus",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloRedDefBase",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloRedDefBonus",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloRedOffBase",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloRedOffBonus",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EloRedTeamBonus",
                table: "Games",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b6f32fe1-4128-4abc-9b02-bc794710cb5b", "22b42571-803f-43c7-8cc6-8b7e452d0742", "User", "USER" },
                    { "bf468aa3-2d87-4844-be94-ee8a0df1bcf0", "cedb6927-1785-47a2-9ae7-58c666a1eeb7", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6f32fe1-4128-4abc-9b02-bc794710cb5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf468aa3-2d87-4844-be94-ee8a0df1bcf0");

            migrationBuilder.DropColumn(
                name: "EloGreDefBase",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloGreDefBonus",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloGreOffBase",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloGreOffBonus",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloGreTeamBonus",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloRedDefBase",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloRedDefBonus",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloRedOffBase",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloRedOffBonus",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "EloRedTeamBonus",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a48f78f-b37a-495e-9213-186245c0d2dd", "bae32fd3-a810-4a56-a0f3-ac587ca139a0", "User", "USER" },
                    { "d5e5db0f-c785-4665-8fd0-4921228482a9", "2589d4dd-c0ba-4cc1-ad8f-88e828e6f87d", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
