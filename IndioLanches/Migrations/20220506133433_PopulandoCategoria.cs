using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndioLanches.Migrations
{
    public partial class PopulandoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao) " +
                "VALUES('Normal', 'Lanche feito com ingredientes normais.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
