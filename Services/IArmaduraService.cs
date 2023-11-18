using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Services;

public interface IArmaduraService
{
    IList<Armadura> ObterTodos();
    Armadura Obter(int id);
    void Incluir(Armadura armadura);
    void Alterar(Armadura armadura);
}
