using Microsoft.EntityFrameworkCore.Migrations;

namespace BakAPI.Migrations
{
    public partial class AddRankWithSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55ccf4be-47e9-452d-9ce6-5aea6f43a0e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63bf0029-2875-4262-ae41-6d5a08fdb4eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8148587b-aadf-4096-b821-21cad6200135", "3b2d6b41-b233-42f3-b6c0-e96167b1b0f4", "Administrator", "ADMINISTRATOR" },
                    { "78378eee-dd2a-4ccf-baa8-dc2e72eff066", "bf20a852-c01c-42ed-ac9f-1b0c7ad7396a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "Division", "LowerBound", "SubDivision", "UpperBound" },
                values: new object[,]
                {
                    { 34, "GrandMaster", 5775, "II", 5950 },
                    { 33, "GrandMaster", 5600, "III", 5775 },
                    { 32, "GrandMaster", 5425, "IV", 5600 },
                    { 31, "GrandMaster", 5250, "V", 5425 },
                    { 30, "Master", 5075, "I", 5250 },
                    { 29, "Master", 4900, "II", 5075 },
                    { 20, "Platinum", 3325, "I", 3500 },
                    { 27, "Master", 4550, "IV", 4725 },
                    { 26, "Master", 4375, "V", 4550 },
                    { 25, "Diamond", 4200, "I", 4375 },
                    { 24, "Diamond", 4025, "II", 4200 },
                    { 23, "Diamond", 3850, "III", 4025 },
                    { 22, "Diamond", 3675, "IV", 3850 },
                    { 21, "Diamond", 3500, "V", 3675 },
                    { 35, "GrandMaster", 5950, "I", 2147483647 },
                    { 28, "Master", 4725, "III", 4900 },
                    { 19, "Platinum", 3150, "II", 3325 },
                    { 17, "Platinum", 2800, "IV", 2975 },
                    { 2, "Bronze", 175, "IV", 350 },
                    { 3, "Bronze", 350, "III", 525 },
                    { 4, "Bronze", 525, "II", 700 },
                    { 5, "Bronze", 700, "I", 875 },
                    { 6, "Silver", 875, "V", 1050 },
                    { 7, "Silver", 1050, "IV", 1225 },
                    { 8, "Silver", 1225, "III", 1400 },
                    { 9, "Silver", 1400, "II", 1575 },
                    { 10, "Silver", 1575, "I", 1750 },
                    { 11, "Gold", 1750, "V", 1925 },
                    { 12, "Gold", 1925, "IV", 2100 },
                    { 13, "Gold", 2100, "III", 2275 },
                    { 14, "Gold", 2275, "II", 2450 },
                    { 15, "Gold", 2450, "I", 2625 },
                    { 16, "Platinum", 2625, "V", 2800 },
                    { 18, "Platinum", 2975, "III", 3150 },
                    { 1, "Bronze", 0, "V", 175 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78378eee-dd2a-4ccf-baa8-dc2e72eff066");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8148587b-aadf-4096-b821-21cad6200135");

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63bf0029-2875-4262-ae41-6d5a08fdb4eb", "13e8b850-a4ac-4f0f-94d2-5632c41840e9", "User", "USER" },
                    { "55ccf4be-47e9-452d-9ce6-5aea6f43a0e6", "c9ac74fa-d100-4320-b3ec-8228ea407c60", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
