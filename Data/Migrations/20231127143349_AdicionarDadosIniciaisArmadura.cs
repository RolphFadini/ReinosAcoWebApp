using ReinosAcoWebApp.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReinosAcoWebApp.Data.Migrations;

/// <inheritdoc />
public partial class AdicionarDadosIniciaisArmadura : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        var context = new ArmaduraDbContext();
        context.Armadura.AddRange(ObterCargaInicialArmadura());
        context.SaveChanges();
    }

    private IList<Armadura> ObterCargaInicialArmadura()
    {
        return new List<Armadura>()
        {
            new Armadura
            {
                Nome = "Armet Helmet",
                Descricao = "Elmo Armet, um tesouro do século XV. Originado na Itália, resistiu ao teste do tempo. Uma peça que conta histórias de batalhas e bravura.",
                ImgUri = "/images/Armet-helmet.jpg",
                Preco = 50.00,
                EntregaExpressa = true,
                DataCadastro = DateTime.Now
            },
            new Armadura
            {
                Nome = "Breastplate Armor",
                Descricao = "Armadura de Peito Breastplate, forjada na Europa no século XVI. Vestida por guerreiros em campos de batalha reais, uma testemunha silenciosa da história.",
                ImgUri = "/images/Breastplate-armor.jpg",
                Preco = 239.00,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
            new Armadura
            {
                Nome = "Cabasset Helmet",
                Descricao = "Cabasset Helmet, século XVII, Espanha. Uma relíquia que presenciou as guerras de conquista. Sinta o peso da história em cada detalhe.",
                ImgUri = "/images/Cabasset-helmet.jpg",
                Preco = 49.00,
                EntregaExpressa = true,
                DataCadastro = DateTime.Now
            },
            new Armadura
            {
                Nome = "Half Armor",
                Descricao = "Half Armor, utilizado no século XIV na França. Uma peça que viu as batalhas da Guerra dos Cem Anos. A resistência perdura.",
                ImgUri = "/images/Half-armor.jpg",
                Preco = 120.99,
                EntregaExpressa = true,
                DataCadastro = DateTime.Now
            },
            new Armadura
            {
                Nome = "Morion Helmet",
                Descricao = "Morion Helmet, do século XVI, teve origem na Espanha. Usado por soldados que exploraram os confins do Novo Mundo. Uma herança de coragem.",
                ImgUri = "/images/Morion-helmet.jpg",
                Preco = 39.35,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
        };
    }
}
