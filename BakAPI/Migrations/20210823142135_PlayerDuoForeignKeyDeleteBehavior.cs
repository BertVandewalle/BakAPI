using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class PlayerDuoForeignKeyDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duos_Players_DefPlayerId",
                table: "Duos");

            migrationBuilder.DropForeignKey(
                name: "FK_Duos_Players_OffPlayerId",
                table: "Duos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e841fabe-9d39-4211-a1eb-23dc557826e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb29d2a6-a327-4f78-951d-955f2187c1fd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "058fbc3e-525a-4b89-8e5a-277354472467", "5d205c52-3a89-4fb9-95ef-cd693aaa3b76", "User", "USER" },
                    { "a2d99d29-c53d-4e5d-bbf0-b987b77af6ed", "abd2fa1c-db2e-49f5-b0c2-f922fa38a6d9", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Duos_Players_DefPlayerId",
                table: "Duos",
                column: "DefPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Duos_Players_OffPlayerId",
                table: "Duos",
                column: "OffPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duos_Players_DefPlayerId",
                table: "Duos");

            migrationBuilder.DropForeignKey(
                name: "FK_Duos_Players_OffPlayerId",
                table: "Duos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "058fbc3e-525a-4b89-8e5a-277354472467");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2d99d29-c53d-4e5d-bbf0-b987b77af6ed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "eb29d2a6-a327-4f78-951d-955f2187c1fd", "95aac9da-e8de-4bd4-b562-17b505fd8111", "User", "USER" },
                    { "e841fabe-9d39-4211-a1eb-23dc557826e0", "f56afd41-a9bf-4c5b-8df6-fdb37ac2b097", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Duos_Players_DefPlayerId",
                table: "Duos",
                column: "DefPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Duos_Players_OffPlayerId",
                table: "Duos",
                column: "OffPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
