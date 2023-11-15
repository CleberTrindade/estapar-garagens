namespace Estapar.Garagens.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task Add(T objeto);
        Task Update(T objeto);
        Task Delete(T objeto);
        Task<T> GetById(T objeto);
        Task<List<T>> GetAll(T objeto);
    }
}
