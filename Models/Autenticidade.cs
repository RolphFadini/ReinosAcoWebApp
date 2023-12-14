namespace ReinosAcoWebApp.Models;

public class Autenticidade
{
    public int AutenticidadeId { get; set; }
    public string Descricao { get; set; }   

    public ICollection<Armadura>? Armaduras { get; set; }
}
