using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class DeleteGamePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Games_GameId",
                table: "GamePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Players_PlayerId",
                table: "GamePlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer");

            migrationBuilder.DropIndex(
                name: "IX_GamePlayer_GameId",
                table: "GamePlayer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e52ed3a-8b5c-4598-a3c9-3d61c0598a09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b542eabd-3261-41e8-8f33-ed1093de4778");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GamePlayer");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "GamePlayer");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "GamePlayer",
                newName: "PlayersId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GamePlayer",
                newName: "GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayer_PlayerId",
                table: "GamePlayer",
                newName: "IX_GamePlayer_PlayersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer",
                columns: new[] { "GamesId", "PlayersId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d00058d-f492-4322-8127-9b543b95e11a", "8fe7ace8-e1b4-4eb8-aeae-63d1bbf2dc5f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d7c6e08-6b0e-4b01-a302-121d0c9593b2", "b5a16df1-c2b9-4cd4-8576-bc9b7955adb3", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Games_GamesId",
                table: "GamePlayer",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Players_PlayersId",
                table: "GamePlayer",
                column: "PlayersId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Games_GamesId",
                table: "GamePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Players_PlayersId",
                table: "GamePlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d7c6e08-6b0e-4b01-a302-121d0c9593b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d00058d-f492-4322-8127-9b543b95e11a");

            migrationBuilder.RenameColumn(
                name: "PlayersId",
                table: "GamePlayer",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GamePlayer",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayer_PlayersId",
                table: "GamePlayer",
                newName: "IX_GamePlayer_PlayerId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GamePlayer",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "GamePlayer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b542eabd-3261-41e8-8f33-ed1093de4778", "80964d41-4918-4a9f-bb28-673efda728e4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e52ed3a-8b5c-4598-a3c9-3d61c0598a09", "817aaf06-061f-4dc1-a910-4ccb7225e07a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_GameId",
                table: "GamePlayer",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Games_GameId",
                table: "GamePlayer",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Players_PlayerId",
                table: "GamePlayer",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
