using Microsoft.EntityFrameworkCore.Migrations;

namespace ITSearch.Data.Migrations
{
    public partial class StringYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StringYear",
                table: "Computers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StringYear",
                table: "Computers");
        }
    }
}
