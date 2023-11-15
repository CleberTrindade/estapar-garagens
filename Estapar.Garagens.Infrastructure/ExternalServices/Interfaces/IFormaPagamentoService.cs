using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Infrastructure.ExternalServices.Interfaces
{
    public interface IFormaPagamentoService
    {
        Task<List<FormaPagamentoDto>> GetData();
    }
}
