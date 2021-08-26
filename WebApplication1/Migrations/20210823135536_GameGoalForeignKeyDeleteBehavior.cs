using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class GameGoalForeignKeyDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Players_PlayerId",
                table: "Goals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e20a985-dc81-4614-b7aa-e02a108f24f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b68b7799-7012-4ea2-aebc-7e5c10578187");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "eb29d2a6-a327-4f78-951d-955f2187c1fd", "95aac9da-e8de-4bd4-b562-17b505fd8111", "User", "USER" },
                    { "e841fabe-9d39-4211-a1eb-23dc557826e0", "f56afd41-a9bf-4c5b-8df6-fdb37ac2b097", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Players_PlayerId",
                table: "Goals",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Players_PlayerId",
                table: "Goals");

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
                    { "b68b7799-7012-4ea2-aebc-7e5c10578187", "2c0facc7-07d6-42db-a9a1-9f79ec1ccd2e", "User", "USER" },
                    { "9e20a985-dc81-4614-b7aa-e02a108f24f8", "2f28932e-9da2-4a6d-837c-69ff3dcba017", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Players_PlayerId",
                table: "Goals",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
