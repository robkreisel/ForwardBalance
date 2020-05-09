using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForwardBalance.API.Migrations
{
    public partial class AddTestEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "AccountId", "Amount", "Date", "Description", "TransferAccountId" },
                values: new object[] { 100, 2, 10.0, new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit", 1 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "AccountId", "Amount", "Date", "Description", "TransferAccountId" },
                values: new object[] { 101, 1, -10.0, new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 101);
        }
    }
}
