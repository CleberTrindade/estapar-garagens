namespace Estapar.Garagens.Infrastructure.Models
{
    public class GaragemFileDto
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Preco_1aHora { get; set; }
        public string Preco_HorasExtra { get; set; }
        public string Preco_Mensalista { get; set; }

        public object Preco_Hora(string preco)
        {
            return preco.Equals("") ? null : Convert.ToDecimal(preco);
        }
    }

    

    public class ConfiguiracaoGaragemDto
    {
        public List<GaragemFileDto> Garagens { get; set; }
    }
}
