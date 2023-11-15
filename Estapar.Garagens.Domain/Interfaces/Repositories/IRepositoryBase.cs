namespace Estapar.Garagens.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Add(T objeto);
        Task<T> Update(T objeto);
        Task Delete(T objeto);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(T objeto);
    }
}
