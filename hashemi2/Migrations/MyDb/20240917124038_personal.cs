using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hashemi2.Migrations.MyDb
{
    /// <inheritdoc />
    public partial class personal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Personal1",
                table: "UserShifts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Personal2",
                table: "UserShifts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Personal3",
                table: "UserShifts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Personal1",
                table: "UserShifts");

            migrationBuilder.DropColumn(
                name: "Personal2",
                table: "UserShifts");

            migrationBuilder.DropColumn(
                name: "Personal3",
                table: "UserShifts");
        }
    }
}
