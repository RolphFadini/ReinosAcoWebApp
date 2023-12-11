using Microsoft.EntityFrameworkCore.Migrations;
using ReinosAcoWebApp.Models;

#nullable disable

namespace ReinosAcoWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDadosMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new ArmaduraDbContext();
            context.Material.AddRange(ObterCargaInicialMaterial());
            context.SaveChanges();
        }

        private IList<Material> ObterCargaInicialMaterial() 
        {
            return new List<Material>()
            {
                new Material() { Descricao = "Couro"},
                new Material() { Descricao = "Tecido"},
                new Material() { Descricao = "Metal"},
                new Material() { Descricao = "Madeira"},
                new Material() { Descricao = "Peles"},
                new Material() { Descricao = "Algodão/Estofamento"},
            };
        }
    }
}
