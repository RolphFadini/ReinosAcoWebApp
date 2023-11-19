using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Services;

public class ArmaduraService : IArmaduraService
{
    public ArmaduraService() => CarregarListaInicial();

    private IList<Armadura> _armaduras;

    private void CarregarListaInicial()
    {
        _armaduras = new List<Armadura>()
        {
            new Armadura
            {
                ArmaduraId = 1,
                Nome = "Armet Helmet",
                Descricao = "Elmo Armet, um tesouro do século XV. Originado na Itália, resistiu ao teste do tempo. Uma peça que conta histórias de batalhas e bravura.",
                ImgUri = "/images/Armet-armor.jpg",
                Preco = 50.00,
                EntregaExpressa = true,
                DataCadastro = DateTime.Now
            },
            new Armadura
            {
                ArmaduraId = 2,
                Nome = "Breastplate Armor",
                Descricao = "Armadura de Peito Breastplate, forjada na Europa no século XVI. Vestida por guerreiros em campos de batalha reais, uma testemunha silenciosa da história.",
                ImgUri = "/images/Breastplate-armor.jpg",
                Preco = 239.00,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
            new Armadura
            {
                ArmaduraId = 3,
                Nome = "Cabasset Helmet",
                Descricao = "Cabasset Helmet, século XVII, Espanha. Uma relíquia que presenciou as guerras de conquista. Sinta o peso da história em cada detalhe.",
                ImgUri = "/images/Cabasset-armor.jpg",
                Preco = 49.00,
                EntregaExpressa = true,
                DataCadastro = DateTime.Now
            },
            new Armadura
            {
                ArmaduraId = 4,
                Nome = "Half Armor",
                Descricao = "Half Armor, utilizado no século XIV na França. Uma peça que viu as batalhas da Guerra dos Cem Anos. A resistência perdura.",
                ImgUri = "/images/Half-armor.jpg",
                Preco = 120.99,
                EntregaExpressa = true,
                DataCadastro = DateTime.Now
            },
            new Armadura
            {
                ArmaduraId = 5,
                Nome = "Morion Helmet",
                Descricao = "Morion Helmet, do século XVI, teve origem na Espanha. Usado por soldados que exploraram os confins do Novo Mundo. Uma herança de coragem.",
                ImgUri = "/images/Morion-armor.jpg",
                Preco = 39.35,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
        };
    }

    public IList<Armadura> ObterTodos() => _armaduras;


    public Armadura Obter(int id) => ObterTodos().SingleOrDefault(item => item.ArmaduraId == id);

    public void Incluir(Armadura armadura)
    {
        var proximoId = _armaduras.Max(item => item.ArmaduraId) + 1;
        armadura.ArmaduraId = proximoId;
        _armaduras.Add(armadura);
    }

    public void Alterar(Armadura armadura)
    {
        var armaduraEncontrada = _armaduras?.SingleOrDefault(item => item.ArmaduraId == armadura.ArmaduraId);

        armaduraEncontrada.Nome = armadura.Nome;
        armaduraEncontrada.Descricao = armadura.Descricao;
        armaduraEncontrada.Preco = armadura.Preco;
        armaduraEncontrada.EntregaExpressa = armadura.EntregaExpressa;
        armaduraEncontrada.DataCadastro = armadura.DataCadastro;
        armaduraEncontrada.ImgUri = armadura.ImgUri;
    }

    public void Excluir(int id)
    {
        var armaduraEncontrada = Obter(id);
        _armaduras.Remove(armaduraEncontrada);
    }
}
