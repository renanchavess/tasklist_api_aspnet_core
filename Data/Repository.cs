using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tasklist_api_aspnet_core.models;

namespace tasklist_api_aspnet_core.Data
{
    public class Repository : IRepository
    {
        public DataContext Context { get; }
        public Repository(DataContext context)
        {
            this.Context = context;
        }

        public void Add<T>(T entity) where T : class
        {
           this.Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.Context.Remove(entity);
        }        

        public void Update<T>(T entity) where T : class
        {
            this.Context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
             return (await this.Context.SaveChangesAsync() > 0);
        }

        public async Task<Item> GetItemAsyncById(int id)
        {
            IQueryable<Item> query = Context.Itens;

            query = query.AsNoTracking().Where( item => item.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Item[]> GetAllItensAsync()
        {
            IQueryable<Item> query = Context.Itens;

            query = query.AsNoTracking().OrderBy( item => item.Created);            

            return await query.ToArrayAsync();
        }
    }
}