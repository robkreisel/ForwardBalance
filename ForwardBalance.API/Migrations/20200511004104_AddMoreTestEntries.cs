using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForwardBalance.API.Migrations
{
    public partial class AddMoreTestEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 2,
                column: "RelatedEntryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 3,
                column: "RelatedEntryId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "AccountId", "Amount", "Date", "Description", "RelatedEntryId" },
                values: new object[,]
                {
                    { 4, 2, -4.55m, new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer to Test Bank A - Test Savings Account", 5 },
                    { 5, 3, 4.55m, new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer from Test Bank A - Test Checking Account", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 2,
                column: "RelatedEntryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 3,
                column: "RelatedEntryId",
                value: 0);
        }
    }
}
