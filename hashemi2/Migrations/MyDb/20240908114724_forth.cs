using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hashemi2.Migrations.MyDb
{
    /// <inheritdoc />
    public partial class forth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockOwnerId",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "StockOwnerName",
                table: "Stocks",
                newName: "StockOwnerUserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockOwnerUserName",
                table: "Stocks",
                newName: "StockOwnerName");

            migrationBuilder.AddColumn<int>(
                name: "StockOwnerId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
