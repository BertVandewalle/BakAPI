using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class ChangeOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_RedDefId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_RedOffId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "852d6fc1-25f6-494a-9af0-fddd17211c5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7ebd6e4-ed5b-4217-8e07-3efa1d8ec95b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95bee434-7854-43d7-8adf-7924a896bee3", "5f0e2cb9-b1c9-4f8c-b4cf-8104863d52f9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4dbf8bb-cf2e-495f-94f4-7bd58a3850d4", "f2ba9d60-d0fe-4567-9d9b-0716d736fcf5", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_RedDefId",
                table: "Games",
                column: "RedDefId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_RedOffId",
                table: "Games",
                column: "RedOffId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_RedDefId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_RedOffId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95bee434-7854-43d7-8adf-7924a896bee3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4dbf8bb-cf2e-495f-94f4-7bd58a3850d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7ebd6e4-ed5b-4217-8e07-3efa1d8ec95b", "816d5b7a-fc70-47a7-b4c1-e1483da2d191", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "852d6fc1-25f6-494a-9af0-fddd17211c5b", "d7e1a38f-a43b-484d-9029-7f289ac73650", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_RedDefId",
                table: "Games",
                column: "RedDefId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_RedOffId",
                table: "Games",
                column: "RedOffId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
