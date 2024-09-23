using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hashemi2.Migrations.MyDb
{
    /// <inheritdoc />
    public partial class fixmany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Stocks_StockId",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_UserShifts_Shifts_ShiftId",
                table: "UserShifts");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Stocks_StockId",
                table: "Goods",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserShifts_Shifts_ShiftId",
                table: "UserShifts",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Stocks_StockId",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_UserShifts_Shifts_ShiftId",
                table: "UserShifts");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Stocks_StockId",
                table: "Goods",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserShifts_Shifts_ShiftId",
                table: "UserShifts",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
