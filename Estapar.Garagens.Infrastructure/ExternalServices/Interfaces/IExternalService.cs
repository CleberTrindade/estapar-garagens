namespace Estapar.Garagens.Infrastructure.ExternalServices.Interfaces
{
    public interface IExternalService<T> where T : class
    {
        Task<List<T>> GetData();
    }
}
