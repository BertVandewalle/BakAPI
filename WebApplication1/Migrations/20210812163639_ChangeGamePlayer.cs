using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class ChangeGamePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf8327c-a8ee-41e3-999a-640c6796d753");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4498ee4-0a80-409f-8a19-d00ec41ec82c");

            migrationBuilder.AddColumn<int>(
                name: "GreScore",
                table: "Games",
                type: "int",
                nullable: false,
                computedColumnSql: "[GreDefScore] + [GreOffScore]");

            migrationBuilder.AddColumn<int>(
                name: "RedScore",
                table: "Games",
                type: "int",
                nullable: false,
                computedColumnSql: "[RedDefScore] + [RedOffScore]");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a26ca4d-5063-472c-9cc7-afc6500ab13f", "d48120e5-0085-4c8f-9b27-51534ffd75c8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27469da9-f7c4-4dcc-9ed7-b3543173fb12", "157e0d4d-6ac2-431d-9a30-daec781790b1", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27469da9-f7c4-4dcc-9ed7-b3543173fb12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a26ca4d-5063-472c-9cc7-afc6500ab13f");

            migrationBuilder.DropColumn(
                name: "GreScore",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RedScore",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1cf8327c-a8ee-41e3-999a-640c6796d753", "9368c249-552b-4534-8d5b-6bea7d4fdace", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4498ee4-0a80-409f-8a19-d00ec41ec82c", "f0dceb3e-7004-4cf0-8e84-9731d6c5e670", "Administrator", "ADMINISTRATOR" });
        }
    }
}
