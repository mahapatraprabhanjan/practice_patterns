using System;
using System.Threading.Tasks;
using Generic_Repo.Repository;

namespace Generic_Repo.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly GPContext dbContext;
        private readonly IRepository<T> repository;

        public UnitOfWork(GPContext dbContext, IRepository<T> repository)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public IRepository<T> GetRepository()
        {
            return this.repository;
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
