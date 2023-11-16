namespace Estapar.Garagens.Infrastructure.Models
{
    public class FormaPagamentoFileDto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public class ConfiguiracaoPagamentoDto
    {
        public List<FormaPagamentoFileDto>? FormasPagamento { get; set; }
    }
}
