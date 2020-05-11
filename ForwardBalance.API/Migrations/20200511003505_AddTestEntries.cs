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
                columns: new[] { "Id", "AccountId", "Amount", "Date", "Description", "RelatedEntryId" },
                values: new object[] { 2, 2, 10.00m, new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit", 0 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "AccountId", "Amount", "Date", "Description", "RelatedEntryId" },
                values: new object[] { 3, 1, -10.00m, new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
