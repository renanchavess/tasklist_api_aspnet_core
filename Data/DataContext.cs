using Microsoft.EntityFrameworkCore;
using tasklist_api_aspnet_core.models;

namespace tasklist_api_aspnet_core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Item> Itens { get; set; }
    }
}