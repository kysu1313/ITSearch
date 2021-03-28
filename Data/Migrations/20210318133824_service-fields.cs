using Microsoft.EntityFrameworkCore.Migrations;

namespace ITSearch.Data.Migrations
{
    public partial class servicefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Searches",
                columns: table => new
                {
                    SearchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Searches", x => x.SearchId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Searches");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Services");
        }
    }
}
