using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Infrastructure.ExternalServices.Interfaces
{
    public interface IPassagemService
    {
        Task<List<PassagemDto>> GetData();
    }
}
