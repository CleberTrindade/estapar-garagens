using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Estapar.Garagens.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        public RepositoryBase()
        {
            _dbContext = new DbContextOptions<ApplicationDbContext>();
        }

        public async Task<T> Add(T objeto)
        {
            using (var data = new ApplicationDbContext(_dbContext))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
            return objeto;
        }

        public async Task Delete(T objeto)
        {
            using (var data = new ApplicationDbContext(_dbContext))
            {
                data.Set<T>().Remove(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll(T objeto)
        {
            using (var data = new ApplicationDbContext(_dbContext))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var data = new ApplicationDbContext(_dbContext))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<T> Update(T objeto)
        {
            using (var data = new ApplicationDbContext(_dbContext))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }

            return objeto;
        }
    }
}
