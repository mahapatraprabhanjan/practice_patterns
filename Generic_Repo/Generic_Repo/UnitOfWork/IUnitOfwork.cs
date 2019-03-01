using Generic_Repo.Repository;
using System;
using System.Threading.Tasks;

namespace Generic_Repo.UnitOfWork
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        Task SaveChangesAsync();

        IRepository<T> GetRepository();
    }
}
