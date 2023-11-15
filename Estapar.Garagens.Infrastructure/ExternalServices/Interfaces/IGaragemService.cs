using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Infrastructure.ExternalServices.Interfaces
{
    public interface IGaragemService
    {
        Task<List<GaragemDto>> GetData();
    }
}
