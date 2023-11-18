using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace ReinosAcoWebApp.Models;

public class Armadura
{
    public int ArmaduraId { get; set; }

    [Required(ErrorMessage = "Campo 'Nome' obrigatório")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Campo 'Nome' deve ter entre 10 a 50 caracteres")]
    public string Nome { get; set; }
    public string NomeSlug => Nome?.ToLower().Replace(" ", "-");

    [Required(ErrorMessage = "Campo 'Descrição' obrigatório")]
    [StringLength(200, MinimumLength = 40, ErrorMessage = "Campo 'Descrição' deve ter entre 40 a 100 caracteres")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Campo 'Caminho URL da imagem' obrigatório")]
    [Display(Name = "Caminho URL da imagem")]
    public string ImgUri { get; set; }

    [Required(ErrorMessage = "Campo 'Preço' obrigatório")]
    [Display(Name = "Preço")]
    [DataType(DataType.Currency)]
    public double Preco { get; set; }

    [Display(Name = "Entrega Expressa")]
    public bool EntregaExpressa { get; set; }

    public string EntregaExpressaFormatada => EntregaExpressa ? "Sim" : "Não";


    [Required(ErrorMessage = "Campo 'Disponível em' obrigatório")]
    [Display(Name = "Disponível em")]
    [DisplayFormat(DataFormatString = "{0:MM\\/yyyy}")]
    [DataType("month")]
    public DateTime DataCadastro { get; set; }
}
