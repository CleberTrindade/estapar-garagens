namespace Estapar.Garagens.Infrastructure.Models
{
    public class GaragemDto
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Preco_1aHora { get; set; }
        public string Preco_HorasExtra { get; set; }
        public string Preco_Mensalista { get; set; }
    }

    public class ConfiguiracaoGaragemDto
    {
        public List<GaragemDto> Garagens { get; set; }
    }
}
