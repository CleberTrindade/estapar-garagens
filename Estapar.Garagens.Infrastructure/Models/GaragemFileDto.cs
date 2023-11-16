namespace Estapar.Garagens.Infrastructure.Models
{
    public class GaragemFileDto
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Preco_1aHora { get; set; }
        public string Preco_HorasExtra { get; set; }
        public string Preco_Mensalista { get; set; }
    }

    public class ConfiguiracaoGaragemDto
    {
        public List<GaragemFileDto> Garagens { get; set; }
    }
}
