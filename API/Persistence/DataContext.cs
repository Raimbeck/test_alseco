using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        
    }
}