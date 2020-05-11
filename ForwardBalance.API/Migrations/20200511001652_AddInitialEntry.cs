using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForwardBalance.API.Migrations
{
    public partial class AddInitialEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "AccountId", "Amount", "Date", "Description", "RelatedEntryId" },
                values: new object[] { 1, 1, 0.00m, new DateTime(2020, 4, 26, 0, 0, 1, 0, DateTimeKind.Unspecified), "Starting balance", 0 });
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
