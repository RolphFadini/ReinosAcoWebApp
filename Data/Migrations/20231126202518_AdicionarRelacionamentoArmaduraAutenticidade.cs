using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReinosAcoWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoArmaduraAutenticidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutenticidadeId",
                table: "Armadura",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Armadura_AutenticidadeId",
                table: "Armadura",
                column: "AutenticidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armadura_Autenticidade_AutenticidadeId",
                table: "Armadura",
                column: "AutenticidadeId",
                principalTable: "Autenticidade",
                principalColumn: "AutenticidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armadura_Autenticidade_AutenticidadeId",
                table: "Armadura");

            migrationBuilder.DropIndex(
                name: "IX_Armadura_AutenticidadeId",
                table: "Armadura");

            migrationBuilder.DropColumn(
                name: "AutenticidadeId",
                table: "Armadura");
        }
    }
}
