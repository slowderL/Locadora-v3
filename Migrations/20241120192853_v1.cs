using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GenId);
                });

            migrationBuilder.CreateTable(
                name: "Produtoras",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdCnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtoras", x => x.ProdId);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Emprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Produtoras_ProdId",
                        column: x => x.ProdId,
                        principalTable: "Produtoras",
                        principalColumn: "ProdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmeGenero",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    GenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeGenero", x => new { x.FilmeId, x.GenId });
                    table.ForeignKey(
                        name: "FK_FilmeGenero_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeGenero_Generos_GenId",
                        column: x => x.GenId,
                        principalTable: "Generos",
                        principalColumn: "GenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeGenero_GenId",
                table: "FilmeGenero",
                column: "GenId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_ProdId",
                table: "Filmes",
                column: "ProdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeGenero");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Produtoras");
        }
    }
}
