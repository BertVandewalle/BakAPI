using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ChangeReferraltry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e1abf57-ce3f-4ba2-acd3-949ae7009063");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81aa1ece-7bae-47d6-99cf-d22f5deace42");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c76a468-0086-416a-972c-23de57df5b86", "689b3a10-8386-409e-87f9-1a02c124de35", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "961e8dc0-9071-465f-ad52-e118e3af46dc", "195a9517-4b03-4b82-8884-298b1c1920c4", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c76a468-0086-416a-972c-23de57df5b86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "961e8dc0-9071-465f-ad52-e118e3af46dc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81aa1ece-7bae-47d6-99cf-d22f5deace42", "75878102-c06e-496d-ae3e-22032d4c1c40", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e1abf57-ce3f-4ba2-acd3-949ae7009063", "41dee924-5394-4696-a1b1-aac6533ed1a5", "Administrator", "ADMINISTRATOR" });
        }
    }
}
