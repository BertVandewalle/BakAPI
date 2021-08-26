using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BakAPI.Migrations
{
    public partial class AddDuos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Games_GameId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Players_PlayerId",
                table: "Goal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goal",
                table: "Goal");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5300fe06-455c-46df-a7ac-7666938d1941");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8efa069-1510-41e5-883d-d527499759e4");

            migrationBuilder.RenameTable(
                name: "Goal",
                newName: "Goals");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_PlayerId",
                table: "Goals",
                newName: "IX_Goals_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_GameId",
                table: "Goals",
                newName: "IX_Goals_GameId");

            migrationBuilder.AlterColumn<double>(
                name: "WinRate",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "OffWinRate",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "GoalRateOff",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "GoalRateDef",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "GoalMatchRateOff",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "GoalMatchRateDef",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "GoalMatchRate",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "DefWinRate",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goals",
                table: "Goals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Duos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefPlayerId = table.Column<int>(type: "integer", nullable: false),
                    OffPlayerId = table.Column<int>(type: "integer", nullable: false),
                    WinRate = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfGames = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duos_Players_DefPlayerId",
                        column: x => x.DefPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duos_Players_OffPlayerId",
                        column: x => x.OffPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b68b7799-7012-4ea2-aebc-7e5c10578187", "2c0facc7-07d6-42db-a9a1-9f79ec1ccd2e", "User", "USER" },
                    { "9e20a985-dc81-4614-b7aa-e02a108f24f8", "2f28932e-9da2-4a6d-837c-69ff3dcba017", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duos_DefPlayerId",
                table: "Duos",
                column: "DefPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Duos_OffPlayerId",
                table: "Duos",
                column: "OffPlayerId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Players_PlayerId",
                table: "Goals");

            migrationBuilder.DropTable(
                name: "Duos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e20a985-dc81-4614-b7aa-e02a108f24f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b68b7799-7012-4ea2-aebc-7e5c10578187");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Goal");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_PlayerId",
                table: "Goal",
                newName: "IX_Goal_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_GameId",
                table: "Goal",
                newName: "IX_Goal_GameId");

            migrationBuilder.AlterColumn<decimal>(
                name: "WinRate",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "OffWinRate",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "GoalRateOff",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "GoalRateDef",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "GoalMatchRateOff",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "GoalMatchRateDef",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "GoalMatchRate",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "DefWinRate",
                table: "Players",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goal",
                table: "Goal",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b8efa069-1510-41e5-883d-d527499759e4", "12625c21-3558-4f9f-a0fb-eb340a21ba1e", "User", "USER" },
                    { "5300fe06-455c-46df-a7ac-7666938d1941", "51d0df04-7c9c-4ed7-90a7-9c946583611d", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Games_GameId",
                table: "Goal",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Players_PlayerId",
                table: "Goal",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
