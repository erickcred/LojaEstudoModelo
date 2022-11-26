using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class TipoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Estoque",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 19, 53, 25, 468, DateTimeKind.Local).AddTicks(8658),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2022, 11, 26, 19, 7, 26, 294, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.AddColumn<string>(
                name: "TipoUsuario",
                table: "Cliente",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Cliente");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Estoque",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 19, 7, 26, 294, DateTimeKind.Local).AddTicks(7459),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2022, 11, 26, 19, 53, 25, 468, DateTimeKind.Local).AddTicks(8658));
        }
    }
}
