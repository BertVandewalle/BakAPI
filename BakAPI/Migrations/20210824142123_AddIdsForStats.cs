using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class AddIdsForStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "058fbc3e-525a-4b89-8e5a-277354472467");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2d99d29-c53d-4e5d-bbf0-b987b77af6ed");

            migrationBuilder.AddColumn<int>(
                name: "DefAmount",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OffAmount",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DuoGreId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DuoRedId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "Games",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8bf2c903-387e-4ccf-bb08-60532e52cf85", "4a27b400-9371-4926-a7f5-580aca1c5530", "User", "USER" },
                    { "885ec6f9-06cd-4e9d-a8ba-6c7f2212b483", "55210553-5a0e-4160-9faa-cae2c523915e", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DuoGreId",
                table: "Games",
                column: "DuoGreId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DuoRedId",
                table: "Games",
                column: "DuoRedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Duos_DuoGreId",
                table: "Games",
                column: "DuoGreId",
                principalTable: "Duos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Duos_DuoRedId",
                table: "Games",
                column: "DuoRedId",
                principalTable: "Duos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Duos_DuoGreId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Duos_DuoRedId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_DuoGreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_DuoRedId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "885ec6f9-06cd-4e9d-a8ba-6c7f2212b483");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bf2c903-387e-4ccf-bb08-60532e52cf85");

            migrationBuilder.DropColumn(
                name: "DefAmount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "OffAmount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DuoGreId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DuoRedId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "058fbc3e-525a-4b89-8e5a-277354472467", "5d205c52-3a89-4fb9-95ef-cd693aaa3b76", "User", "USER" },
                    { "a2d99d29-c53d-4e5d-bbf0-b987b77af6ed", "abd2fa1c-db2e-49f5-b0c2-f922fa38a6d9", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
