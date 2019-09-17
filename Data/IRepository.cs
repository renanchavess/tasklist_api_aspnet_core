using System.Threading.Tasks;
using tasklist_api_aspnet_core.models;

namespace tasklist_api_aspnet_core.Data
{
    public interface IRepository
    {
         void Add<T>( T entity) where T: class;
         void Update<T>( T entity) where T: class;
         void Delete<T>( T entity) where T: class;
         Task<bool> SaveChangesAsync();

         Task<Item> GetItemAsyncById(int id);
         Task<Item[]> GetAllItensAsync();

    }
}