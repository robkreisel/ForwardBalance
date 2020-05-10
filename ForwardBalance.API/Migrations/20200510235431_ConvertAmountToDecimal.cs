using Microsoft.EntityFrameworkCore.Migrations;

namespace ForwardBalance.API.Migrations
{
    public partial class ConvertAmountToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Entries",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Entries",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
