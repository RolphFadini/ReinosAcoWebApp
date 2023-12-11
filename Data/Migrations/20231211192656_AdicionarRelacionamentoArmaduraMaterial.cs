using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReinosAcoWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoArmaduraMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArmaduraMaterial",
                columns: table => new
                {
                    ArmadurasArmaduraId = table.Column<int>(type: "int", nullable: false),
                    MateriaisMaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmaduraMaterial", x => new { x.ArmadurasArmaduraId, x.MateriaisMaterialId });
                    table.ForeignKey(
                        name: "FK_ArmaduraMaterial_Armadura_ArmadurasArmaduraId",
                        column: x => x.ArmadurasArmaduraId,
                        principalTable: "Armadura",
                        principalColumn: "ArmaduraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmaduraMaterial_Material_MateriaisMaterialId",
                        column: x => x.MateriaisMaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmaduraMaterial_MateriaisMaterialId",
                table: "ArmaduraMaterial",
                column: "MateriaisMaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmaduraMaterial");
        }
    }
}
