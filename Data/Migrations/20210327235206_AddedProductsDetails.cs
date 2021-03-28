using Microsoft.EntityFrameworkCore.Migrations;

namespace ITSearch.Data.Migrations
{
    public partial class AddedProductsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Description");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<bool>(
                name: "Inventoried",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Inventory",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inventoried",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.AlterColumn<double>(
                name: "ProductPrice",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
