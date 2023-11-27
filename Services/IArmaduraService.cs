using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Services;

public interface IArmaduraService
{
    IList<Armadura> ObterTodos();
    Armadura Obter(int id);
    void Incluir(Armadura armadura);
    void Alterar(Armadura armadura);
    void Excluir(int id);
    IList<Autenticidade> ObterTodasAutenticidades();
    Autenticidade ObterAutenticidade(int id);
}
