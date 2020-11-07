using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImageUrl) values('Bebidas', 'http://www.macoratti.net/Imagens/1.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImageUrl) values('Lanches', 'http://www.macoratti.net/Imagens/2.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImageUrl) values('Sobremesas', 'http://www.macoratti.net/Imagens/3.jpg')");

            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) " +
                "values('Coca-Cola', 'Refrigerante de 350ml', 4.50, 'http://www.macoratti.net/Imagens/coca.jpg', 50, now(), " +
                "(Select CategoriaId from Categorias where Nome='Bebidas'))");

            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) " +
                "values('Lanche de Atum', 'Um sabor irresistível', 5.50, 'http://www.macoratti.net/Imagens/atum.jpg', 50, now(), " +
                "(Select CategoriaId from Categorias where Nome='Lanches'))");

            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) " +
                "values('Pudim', 'Pudim delicioso', 3.00, 'http://www.macoratti.net/Imagens/pudim.jpg', 50, now(), " +
                "(Select CategoriaId from Categorias where Nome='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
