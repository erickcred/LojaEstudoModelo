using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class ClienteImamgem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Estoque",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 1, 8, 33, 46, 876, DateTimeKind.Local).AddTicks(2968),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2022, 11, 28, 11, 4, 28, 141, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Cliente",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Cliente");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Estoque",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 28, 11, 4, 28, 141, DateTimeKind.Local).AddTicks(8218),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2022, 12, 1, 8, 33, 46, 876, DateTimeKind.Local).AddTicks(2968));
        }
    }
}
