using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReinosAcoWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarMigrationsTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autenticidade",
                columns: table => new
                {
                    AutenticidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autenticidade", x => x.AutenticidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Armadura",
                columns: table => new
                {
                    ArmaduraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    EntregaExpressa = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutenticidadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armadura", x => x.ArmaduraId);
                    table.ForeignKey(
                        name: "FK_Armadura_Autenticidade_AutenticidadeId",
                        column: x => x.AutenticidadeId,
                        principalTable: "Autenticidade",
                        principalColumn: "AutenticidadeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armadura_AutenticidadeId",
                table: "Armadura",
                column: "AutenticidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armadura");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Autenticidade");
        }
    }
}
