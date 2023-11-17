namespace Estapar.Garagens.Domain.Entities
{
    public class Passagem
    {
        public Guid Codigo { get; set; }
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; } = null;
        public string? FormaPagamento { get; set; } = null;
        public decimal? PrecoTotal { get; set; } = null;

        public void AtualizarPrecoTotal(Garagem garagem)
        {
            TimeSpan diferenca = (TimeSpan)(DataHoraSaida - DataHoraEntrada);

            int totalHoras = (int)diferenca.TotalHours;
            int minutos = diferenca.Minutes;

            double HoraExtra = (double)garagem.Preco_HorasExtra;
            double valorPrimeiraHora = (double)garagem.Preco_1aHora;

            double valorTotal = 0;

            if (totalHoras < 1 && minutos >= 0)            
                valorTotal = valorPrimeiraHora;            
            else
            {
                valorTotal = valorPrimeiraHora;

                if (totalHoras == 1 && minutos > 0)                    
                    valorTotal += (minutos < 30) ? 0.5 * HoraExtra : HoraExtra;
                else {
                    valorTotal += (totalHoras - 1) * HoraExtra;
                    valorTotal += (minutos < 30) ? 0.5 * HoraExtra : HoraExtra;
                }
            }

            PrecoTotal = (decimal)valorTotal;
        }


        public TimeSpan ObterTotalHoras()
        {
            return (TimeSpan)(DataHoraSaida - DataHoraEntrada);
        }
    }
}
