namespace Estapar.Garagens.Application.Interfaces
{
    public interface ITratamentoBaseExterna
    {
        Task<List<string>> ProcessarDadosServicoExterno();
    }
}
