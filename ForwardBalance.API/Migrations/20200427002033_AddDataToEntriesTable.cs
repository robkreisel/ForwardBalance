using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForwardBalance.API.Migrations
{
    public partial class AddDataToEntriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "AccountId", "Amount", "Date", "Description" },
                values: new object[] { 1, 1, 0.0, new DateTime(2020, 4, 26, 10, 10, 0, 0, DateTimeKind.Unspecified), "Starting balance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
