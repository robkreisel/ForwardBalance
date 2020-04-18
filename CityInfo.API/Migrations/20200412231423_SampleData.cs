using Microsoft.EntityFrameworkCore.Migrations;

namespace ForwardBalance.API.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name", "RoutingNumber" },
                values: new object[] { 1, "Bank of America", 11111 });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name", "RoutingNumber" },
                values: new object[] { 2, "Chase Bank", 22222 });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name", "RoutingNumber" },
                values: new object[] { 3, "PNC Bank", 33333 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "BankId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 0, 1, "Simple checking.", "Checking" },
                    { 2, 0, 1, "Simple savings.", "Savings" },
                    { 3, 0, 2, "Business checking.", "Checking" },
                    { 4, 0, 2, "High interest savings account.", "High Yield Savings" },
                    { 5, 0, 3, "Small interest on checking account balance.", "Interest Checking" },
                    { 6, 0, 3, "Typical rate savings account.", "Interest Savings" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
