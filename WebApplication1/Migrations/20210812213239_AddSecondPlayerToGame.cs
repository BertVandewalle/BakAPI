using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class AddSecondPlayerToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c93ef72e-838c-4d32-b0b0-bdf5d177ffd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d919025f-5e2f-40c0-870f-377378dd721e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7ebd6e4-ed5b-4217-8e07-3efa1d8ec95b", "816d5b7a-fc70-47a7-b4c1-e1483da2d191", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "852d6fc1-25f6-494a-9af0-fddd17211c5b", "d7e1a38f-a43b-484d-9029-7f289ac73650", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_RedOffId",
                table: "Games",
                column: "RedOffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_RedOffId",
                table: "Games",
                column: "RedOffId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_RedOffId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_RedOffId",
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
                values: new object[] { "c93ef72e-838c-4d32-b0b0-bdf5d177ffd2", "ef0960b0-b1c4-40d6-80c2-617ec00b43a8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d919025f-5e2f-40c0-870f-377378dd721e", "b8491a46-087a-4f87-a4df-0437c8b9c349", "Administrator", "ADMINISTRATOR" });
        }
    }
}
