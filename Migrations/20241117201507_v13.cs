﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Produtoras_ProdId",
                table: "Filmes");

            migrationBuilder.RenameColumn(
                name: "ProdId",
                table: "Filmes",
                newName: "ProdutoraProdId");

            migrationBuilder.RenameIndex(
                name: "IX_Filmes_ProdId",
                table: "Filmes",
                newName: "IX_Filmes_ProdutoraProdId");

            migrationBuilder.AlterColumn<string>(
                name: "desc",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Produtoras_ProdutoraProdId",
                table: "Filmes",
                column: "ProdutoraProdId",
                principalTable: "Produtoras",
                principalColumn: "ProdId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Produtoras_ProdutoraProdId",
                table: "Filmes");

            migrationBuilder.RenameColumn(
                name: "ProdutoraProdId",
                table: "Filmes",
                newName: "ProdId");

            migrationBuilder.RenameIndex(
                name: "IX_Filmes_ProdutoraProdId",
                table: "Filmes",
                newName: "IX_Filmes_ProdId");

            migrationBuilder.AlterColumn<string>(
                name: "desc",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Produtoras_ProdId",
                table: "Filmes",
                column: "ProdId",
                principalTable: "Produtoras",
                principalColumn: "ProdId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
