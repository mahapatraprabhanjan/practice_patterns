using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic_Repo.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> dbSet;
        private readonly GPContext dbContext;

        public Repository(GPContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.dbSet = this.dbContext.Set<T>();
        }

        public async Task DeleteAsync(object id)
        {
            var tempItem = await GetByIdAsync(id);
            if(tempItem != null)
            {
                dbContext.Entry(id).State = EntityState.Deleted;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public Task<T> GetByIdAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public async Task InsertAsync(T obj)
        {
            await dbSet.AddAsync(obj);
        }

        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
    }
}
