namespace Estapar.Garagens.Application.DTOs.TempoMedioEstadia
{
    public class TempoMedioDto
    {
        public string CodigoGaragem { get; set; }
        public TimeSpan TempoMedio { get; set; }
        public bool Mensalista { get; set; }
    }
}
