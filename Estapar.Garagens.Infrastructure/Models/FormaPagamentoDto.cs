namespace Estapar.Garagens.Infrastructure.Models
{
    public class FormaPagamentoDto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public class ConfiguiracaoPagamentoDto
    {
        public List<FormaPagamentoDto>? FormasPagamento { get; set; }
    }
}
