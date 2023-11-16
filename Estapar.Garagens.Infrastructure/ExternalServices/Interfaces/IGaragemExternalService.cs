using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Infrastructure.ExternalServices.Interfaces
{
    public interface IGaragemExternalService
    {
        Task<List<GaragemFileDto>> GetData();
    }
}
