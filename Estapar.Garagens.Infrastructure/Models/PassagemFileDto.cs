namespace Estapar.Garagens.Infrastructure.Models
{
    public class PassagemFileDto
    {
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public string DataHoraEntrada { get; set; }
        public string? DataHoraSaida { get; set; }
        public string FormaPagamento { get; set; }
        public string? PrecoTotal { get; set; }

        public object ValidarPrecoTotal()
        { 
            return PrecoTotal.Equals("") ? null : Convert.ToDecimal(PrecoTotal);
        }
        public object ValidarDataHoraSaida()
        {
            return DataHoraSaida.Equals("") ? null : DateTime.Parse(DataHoraSaida);
        }

    }



    public class ConfiguiracaoPassagemDto
    {
        public List<PassagemFileDto> Passagens { get; set; }
    }
}
