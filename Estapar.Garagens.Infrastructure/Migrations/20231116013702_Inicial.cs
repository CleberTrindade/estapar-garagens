using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estapar.Garagens.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaPagamentos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamentos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Garagens",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco_1aHora = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Preco_HorasExtra = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Preco_Mensalista = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garagens", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Passagens",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Garagem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CarroPlaca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CarroMarca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CarroModelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PrecoTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagens", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormaPagamentos");

            migrationBuilder.DropTable(
                name: "Garagens");

            migrationBuilder.DropTable(
                name: "Passagens");
        }
    }
}
