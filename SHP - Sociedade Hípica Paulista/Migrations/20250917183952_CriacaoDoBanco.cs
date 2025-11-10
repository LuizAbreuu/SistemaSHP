using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHP___Sociedade_Hípica_Paulista.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notebook_Desktops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsavelInstalacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Procedencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Memoria = table.Column<int>(type: "int", nullable: false),
                    Espaco_TipoDisco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SistemaOperacional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInstalacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInventario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogEquipamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebook_Desktops", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notebook_Desktops");
        }
    }
}
