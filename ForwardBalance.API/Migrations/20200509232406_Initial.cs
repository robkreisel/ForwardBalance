using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForwardBalance.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RoutingNumber = table.Column<int>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 20, nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    RelatedEntryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "IsHidden", "Name", "RoutingNumber" },
                values: new object[] { 1, true, "System", 0 });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "IsHidden", "Name", "RoutingNumber" },
                values: new object[] { 2, false, "Test Bank A", 11111 });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "IsHidden", "Name", "RoutingNumber" },
                values: new object[] { 3, false, "Test Bank B", 22222 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "BankId", "Description", "IsHidden", "Name" },
                values: new object[,]
                {
                    { 1, "0", 1, "System account for transfers in and out of listed accounts", true, "System Account" },
                    { 2, "A1", 2, "This is a test checking account for Test Bank A", false, "Test Checking Account" },
                    { 3, "A2", 2, "This is a test savings account for Test Bank A", false, "Test Savings Account" },
                    { 4, "B1", 3, "This is a test checking account for Test Bank B", false, "Test Checking Account" },
                    { 5, "B2", 3, "This is a test savings account for Test Bank B", false, "Test Savings Account" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankId",
                table: "Accounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_AccountId",
                table: "Entries",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
