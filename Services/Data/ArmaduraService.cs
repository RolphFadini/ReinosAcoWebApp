using ReinosAcoWebApp.Data;
using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Services.Data;

public class ArmaduraService : IArmaduraService
{

    private ArmaduraDbContext _context;

    public ArmaduraService(ArmaduraDbContext context)
    {
        _context = context;
    }

    public void Alterar(Armadura armadura)
    {
        var armaduraEncontrada = Obter(armadura.ArmaduraId);
        armaduraEncontrada.Nome = armadura.Nome;
        armaduraEncontrada.Descricao = armadura.Descricao;
        armaduraEncontrada.Preco = armadura.Preco;
        armaduraEncontrada.ImgUri = armadura.ImgUri;
        armaduraEncontrada.EntregaExpressa = armadura.EntregaExpressa;
        armaduraEncontrada.DataCadastro = armadura.DataCadastro;
        armaduraEncontrada.AutenticidadeId = armadura.AutenticidadeId;

        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var armaduraEncontrada = Obter(id);
        _context.Armadura.Remove(armaduraEncontrada);
        _context.SaveChanges();
    }

    public void Incluir(Armadura armadura)
    {
        _context.Armadura.Add(armadura);
        _context.SaveChanges();
    }

    public Armadura Obter(int id)
    {
        return _context.Armadura.SingleOrDefault(item => item.ArmaduraId == id);
    }

    public IList<Armadura> ObterTodos()
    {
        return _context.Armadura.ToList();
    }

    public IList<Autenticidade> ObterTodasAutenticidades() => _context.Autenticidade.ToList();

    public Autenticidade ObterAutenticidade(int id) => _context.Autenticidade.SingleOrDefault(item => item.AutenticidadeId == id);
}
