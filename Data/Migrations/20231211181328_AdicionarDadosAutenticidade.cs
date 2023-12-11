using Microsoft.EntityFrameworkCore.Migrations;
using ReinosAcoWebApp.Models;

#nullable disable

namespace ReinosAcoWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDadosAutenticidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new ArmaduraDbContext();
            context.Autenticidade.AddRange(ObterCargaInicialAutenticidade());
            context.SaveChanges();
        }

        private IList<Autenticidade> ObterCargaInicialAutenticidade()
        {
            return new List<Autenticidade>()
        {
            new Autenticidade() { Descricao = "Autêntico"},
            new Autenticidade() { Descricao = "Réplica"},
        };
        }
    }
}
