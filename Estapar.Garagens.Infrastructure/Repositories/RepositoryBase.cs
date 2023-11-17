using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Estapar.Garagens.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T objeto)
        {
            await _dbContext.Set<T>().AddAsync(objeto);
            await _dbContext.SaveChangesAsync();

            return objeto;
        }

        public async Task AddRange(List<T> objeto)
        {
            await _dbContext.Set<T>().AddRangeAsync(objeto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T objeto)
        {
            _dbContext.Set<T>().Remove(objeto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T objeto)
        {
            _dbContext.Set<T>().Update(objeto);
            await _dbContext.SaveChangesAsync();

            return objeto;
        }

        public async Task UpdateRange(List<T> objeto)
        {
            _dbContext.Set<T>().UpdateRange(objeto);
            await _dbContext.SaveChangesAsync();

        }
    }
}
