namespace Estapar.Garagens.Infrastructure.Models
{
    public class PassagemDto
    {
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public string DataHoraEntrada { get; set; }
        public string DataHoraSaida { get; set; }
        public string FormaPagamento { get; set; }
        public string PrecoTotal { get; set; }
    }

    public class ConfiguiracaoPassagemDto
    {
        public List<PassagemDto> Passagens { get; set; }
    }
}
