using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class SituaçãoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Estoque",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 28, 11, 4, 28, 141, DateTimeKind.Local).AddTicks(8218),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2022, 11, 26, 19, 53, 25, 468, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.AddColumn<sbyte>(
                name: "Ativo",
                table: "Cliente",
                type: "TINYINT",
                maxLength: 1,
                nullable: false,
                defaultValue: (sbyte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Cliente");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Estoque",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 26, 19, 53, 25, 468, DateTimeKind.Local).AddTicks(8658),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2022, 11, 28, 11, 4, 28, 141, DateTimeKind.Local).AddTicks(8218));
        }
    }
}
