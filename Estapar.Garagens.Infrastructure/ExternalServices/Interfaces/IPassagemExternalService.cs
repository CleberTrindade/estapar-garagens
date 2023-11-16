using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Infrastructure.ExternalServices.Interfaces
{
    public interface IPassagemExternalService
    {
        Task<List<PassagemFileDto>> GetData();
    }
}
