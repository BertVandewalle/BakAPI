using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class AddGamePlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05a2aea1-8ea9-4372-855b-65c373d6a78e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68176dc8-a85e-4a38-b5ba-df715644776e");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedDefScore = table.Column<int>(type: "int", nullable: false),
                    RedOffId = table.Column<int>(type: "int", nullable: false),
                    RedOffScore = table.Column<int>(type: "int", nullable: false),
                    GreDefId = table.Column<int>(type: "int", nullable: false),
                    GreDefScore = table.Column<int>(type: "int", nullable: false),
                    GreOffId = table.Column<int>(type: "int", nullable: false),
                    GreOffScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedDefAmount = table.Column<int>(type: "int", nullable: false),
                    RedOffAmount = table.Column<int>(type: "int", nullable: false),
                    GreDefAmount = table.Column<int>(type: "int", nullable: false),
                    GreOffAmount = table.Column<int>(type: "int", nullable: false),
                    GameAmount = table.Column<int>(type: "int", nullable: false),
                    WinAmount = table.Column<int>(type: "int", nullable: false),
                    LossAmount = table.Column<int>(type: "int", nullable: false),
                    WinDefAmount = table.Column<int>(type: "int", nullable: false),
                    WinOffAmount = table.Column<int>(type: "int", nullable: false),
                    DefWinRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OffWinRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WinRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Elo = table.Column<double>(type: "float", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    GoalAmount = table.Column<int>(type: "int", nullable: false),
                    GoalAmountDef = table.Column<int>(type: "int", nullable: false),
                    GoalAmountOff = table.Column<int>(type: "int", nullable: false),
                    GoalRateDef = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoalRateOff = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoalMatchRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoalMatchRateDef = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoalMatchRateOff = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1cf8327c-a8ee-41e3-999a-640c6796d753", "9368c249-552b-4534-8d5b-6bea7d4fdace", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4498ee4-0a80-409f-8a19-d00ec41ec82c", "f0dceb3e-7004-4cf0-8e84-9731d6c5e670", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_GameId",
                table: "GamePlayer",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_PlayerId",
                table: "GamePlayer",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf8327c-a8ee-41e3-999a-640c6796d753");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4498ee4-0a80-409f-8a19-d00ec41ec82c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68176dc8-a85e-4a38-b5ba-df715644776e", "126133de-ac8b-4463-8f33-dde83fcef9d0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05a2aea1-8ea9-4372-855b-65c373d6a78e", "0d0ee844-8b13-4b90-bb07-6a603815856c", "Administrator", "ADMINISTRATOR" });
        }
    }
}
