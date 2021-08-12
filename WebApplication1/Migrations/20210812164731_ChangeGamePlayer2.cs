using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class ChangeGamePlayer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Players_PlayerId",
                table: "GamePlayer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27469da9-f7c4-4dcc-9ed7-b3543173fb12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a26ca4d-5063-472c-9cc7-afc6500ab13f");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "GamePlayer");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "GamePlayer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fbf5494f-7ca1-452b-85b3-5dafa10b4728", "dd429cd2-1789-46db-a80e-9f210cbc5906", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfa3c4c0-74ab-4718-9c8f-6aa19a9d8934", "f785a408-4d5c-406f-bb83-2c87f1441e7c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Players_PlayerId",
                table: "GamePlayer",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Players_PlayerId",
                table: "GamePlayer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfa3c4c0-74ab-4718-9c8f-6aa19a9d8934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbf5494f-7ca1-452b-85b3-5dafa10b4728");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "GamePlayer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "GamePlayer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a26ca4d-5063-472c-9cc7-afc6500ab13f", "d48120e5-0085-4c8f-9b27-51534ffd75c8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27469da9-f7c4-4dcc-9ed7-b3543173fb12", "157e0d4d-6ac2-431d-9a30-daec781790b1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Players_PlayerId",
                table: "GamePlayer",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
