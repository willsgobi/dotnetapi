using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogo.Migrations
{
    public partial class Popular : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImageUrl) Values('Bebidas', 'http://www.macoratti.net/Imagens/1.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImageUrl) Values('Lanches', 'http://www.macoratti.net/Imagens/2.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImageUrl) Values('Sobremesas', 'http://www.macoratti.net/Imagens/3.jpg')");

            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) " +
                "Values('Coca-Cola', 'Refrigerante de Cola', 5.45, 'http://macoratti.net.Imagens/coca.jpg', 50, " +
                "now(), (SELECT CategoriaId from Categorias where Nome='Bebidas'))");
            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) " +
               "Values('Lanche de Atum', 'Lanche Delicioso', 5.00, 'http://macoratti.net.Imagens/atum.jpg', 40, " +
               "now(), (SELECT CategoriaId from Categorias where Nome='Lanches'))");
            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) " +
               "Values('Pudim 100g', 'Pudim delicioso', 3, 'http://macoratti.net.Imagens/pudim.jpg', 10, " +
               "now(), (SELECT CategoriaId from Categorias where Nome='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
