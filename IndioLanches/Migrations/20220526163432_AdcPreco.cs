using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndioLanches.Migrations
{
    public partial class AdcPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarrinhoDeCompraItemId",
                table: "CarrinhoCompraItens",
                newName: "CarrinhoDeCompraId");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "CarrinhoCompraItens",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "CarrinhoCompraItens");

            migrationBuilder.RenameColumn(
                name: "CarrinhoDeCompraId",
                table: "CarrinhoCompraItens",
                newName: "CarrinhoDeCompraItemId");
        }
    }
}
