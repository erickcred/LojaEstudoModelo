using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class ImagemUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Estoque",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 28, 18, 7, 49, 742, DateTimeKind.Local).AddTicks(577),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2022, 11, 28, 18, 5, 28, 206, DateTimeKind.Local).AddTicks(4335));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Estoque",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 28, 18, 5, 28, 206, DateTimeKind.Local).AddTicks(4335),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2022, 11, 28, 18, 7, 49, 742, DateTimeKind.Local).AddTicks(577));
        }
    }
}
