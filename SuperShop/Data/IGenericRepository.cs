using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public interface IGenericRepository<T> where T : class   //vai injetar T em que T e uma class ou seja T pode ser clientes,owners,produtos etc
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> ExistAsync(int id);
    }
}
