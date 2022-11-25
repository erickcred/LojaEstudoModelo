using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class AlterandoNomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityInStok",
                table: "Produto",
                newName: "Estoque");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Produto",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Produto",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Produto",
                newName: "Imagem");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Produto",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produto",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Produto",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Produto",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Estoque",
                table: "Produto",
                newName: "QuantityInStok");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Produto",
                newName: "Description");
        }
    }
}
