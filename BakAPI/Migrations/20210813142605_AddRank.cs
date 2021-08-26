using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BakAPI.Migrations
{
    public partial class AddRank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f3b4d88-c24c-46d9-91a7-b4add8e8d81d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82415927-6d96-45bd-9817-76dfa7fa3da0");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "Players",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Division = table.Column<string>(type: "text", nullable: true),
                    SubDivision = table.Column<string>(type: "text", nullable: true),
                    LowerBound = table.Column<int>(type: "integer", nullable: false),
                    UpperBound = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63bf0029-2875-4262-ae41-6d5a08fdb4eb", "13e8b850-a4ac-4f0f-94d2-5632c41840e9", "User", "USER" },
                    { "55ccf4be-47e9-452d-9ce6-5aea6f43a0e6", "c9ac74fa-d100-4320-b3ec-8228ea407c60", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_RankId",
                table: "Players",
                column: "RankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Ranks_RankId",
                table: "Players",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Ranks_RankId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_Players_RankId",
                table: "Players");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55ccf4be-47e9-452d-9ce6-5aea6f43a0e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63bf0029-2875-4262-ae41-6d5a08fdb4eb");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82415927-6d96-45bd-9817-76dfa7fa3da0", "f12e3f23-5e95-43c6-bb41-96fae3233ac7", "User", "USER" },
                    { "7f3b4d88-c24c-46d9-91a7-b4add8e8d81d", "74265822-8f68-4039-a771-5de3ea8594c2", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
