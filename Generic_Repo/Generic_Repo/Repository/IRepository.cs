using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic_Repo.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task InsertAsync(T obj);

        void Update(T obj);

        Task DeleteAsync(object id);
    }
}
