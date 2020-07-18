using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackSales.Migrations
{
    public partial class PopulatingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name,Description) VALUES('Comum','Lanche feito com ingredientes comuns')");
            migrationBuilder.Sql("INSERT INTO Categories(Name,Description) VALUES('Natural','Lanche feito com ingredientes integrais e naturais')");

            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,LongDescription,InStock,ThumbnailUrl,ImageUrl,Favorite,Name,Price) VALUES((SELECT Id FROM Categories WHERE Name='Comum'),'Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',1, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 0 ,'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,LongDescription,InStock,ThumbnailUrl,ImageUrl,Favorite,Name,Price) VALUES((SELECT Id FROM Categories WHERE Name='Comum'),'Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.',1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0,'Misto Quente', 8.00)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,LongDescription,InStock,ThumbnailUrl,ImageUrl,Favorite,Name,Price) VALUES((SELECT Id FROM Categories WHERE Name='Comum'),'Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.',1,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',0,'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,LongDescription,InStock,ThumbnailUrl,ImageUrl,Favorite,Name,Price) VALUES((SELECT Id FROM Categories WHERE Name='Natural'),'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.',1,'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',0,'Lanche Natural Peito Peru', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
