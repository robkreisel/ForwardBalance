using Microsoft.EntityFrameworkCore.Migrations;

namespace ForwardBalance.API.Migrations
{
    public partial class AddTransferAccountColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransferAccountId",
                table: "Entries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransferAccountId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_TransferAccountId",
                table: "Entries",
                column: "TransferAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Accounts_TransferAccountId",
                table: "Entries",
                column: "TransferAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Accounts_TransferAccountId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_TransferAccountId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TransferAccountId",
                table: "Entries");
        }
    }
}
