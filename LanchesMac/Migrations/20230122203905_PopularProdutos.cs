using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId,DescricaoCurta, DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsProdutoPreferido,Nome,Preco)" +
                "VALUES(1,'Pão, hambúrger, ovo, presunto, queijo, e batata palha', 'Delicioso pão de hambúrger com presunto e queijo de primeira qualidade acompanhado com batata palha', 1, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 0, 'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId,DescricaoCurta, DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsProdutoPreferido,Nome,Preco)" +
                "VALUES(1,'Pão, presunto, mussarela e tomate', 'Delicioso pão francês com presunto mussarela e tomate de primeira qualidade', 1, 'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg', 'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg', 0, 'Pão com queijo', 12.50)");
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId,DescricaoCurta, DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsProdutoPreferido,Nome,Preco)" +
                "VALUES(1,'Pão, hambúrger, presunto, mussarela, e batata palha', 'Delicioso pão de hambúrger com presunto e queijo de primeira qualidade', 1, 'http://www.macoratti.net/Imagens/lanches/cheesesburger1.jpg', 'http://www.macoratti.net/Imagens/lanches/cheeseburguer1.jpg', 0, 'Cheeseburger', 12.50)");
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId,DescricaoCurta, DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsProdutoPreferido,Nome,Preco)" +
                "VALUES(2,'Pão Integral, queijo branco, peito de peru, cenoura, alface e iogurte', 'Delicioso pão de hambúrger com presunto e queijo de primeira qualidade', 1, 'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg', 'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg', 0, 'Cheese Natural', 12.50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete FROM Produtos");
        }
    }
}
