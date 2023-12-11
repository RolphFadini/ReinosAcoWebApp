namespace ReinosAcoWebApp.Models;

public class Material
{
    public int MaterialId { get; set; }
    public string Descricao { get; set; }

    public ICollection<Armadura>? Armaduras { get; set; }
}
