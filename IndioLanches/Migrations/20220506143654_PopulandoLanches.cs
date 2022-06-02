using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndioLanches.Migrations
{
    public partial class PopulandoLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome, Preco, DescricaoCurta, DescricaoLonga,ImagemUrl, ImagemMiniaturaUrl, LanchePreferido, EmEstoque)" +
                "VALUES(1,'Sanduíche natural','15.00', 'Sanduiche saudável', 'Sanduiche com salada, queijo e peito de frango', 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 1, 0)");
        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
