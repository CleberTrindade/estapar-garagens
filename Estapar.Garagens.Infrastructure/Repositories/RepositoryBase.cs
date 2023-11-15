using Estapar.Garagens.Domain.Interfaces.Repositories;

namespace Estapar.Garagens.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public async Task Add(T objeto)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(T objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll(T objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(T objeto)
        {
            throw new NotImplementedException();
        }

        public async Task Update(T objeto)
        {
            throw new NotImplementedException();
        }
    }
}
