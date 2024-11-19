using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Produtoras",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdCnpj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtoras", x => x.ProdId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_ProdId",
                table: "Filmes",
                column: "ProdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Produtoras_ProdId",
                table: "Filmes",
                column: "ProdId",
                principalTable: "Produtoras",
                principalColumn: "ProdId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Produtoras_ProdId",
                table: "Filmes");

            migrationBuilder.DropTable(
                name: "Produtoras");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_ProdId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "ProdId",
                table: "Filmes");
        }
    }
}
