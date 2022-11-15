using System.Threading.Tasks;
using AssetsService.Core.Entities;

namespace AssetsService.Core.Repositories.Assets.Base
{

    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity, long id,string types);
        Task DeleteAsync(T entity);
        Task<T> DeleteActiveAsync(T entity, long id, string types);
        
        Task<T> UpdateAsync(T entity, long id);
        Task<T> DeleteDispenserAsync(T entity, long id,string types);
        Task<T> DeleteLocationAsync(T entity, long id,string types);

        Task<T> IsActiveStatusChangeAsync(T entity, long id, string types);
    }
}
