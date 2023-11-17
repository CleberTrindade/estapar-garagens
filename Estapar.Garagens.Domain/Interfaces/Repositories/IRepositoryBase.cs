namespace Estapar.Garagens.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Add(T objeto);
        Task AddRange(List<T> objeto);
        Task<T> Update(T objeto);
        Task UpdateRange(List<T> objeto);
        Task Delete(T objeto);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
