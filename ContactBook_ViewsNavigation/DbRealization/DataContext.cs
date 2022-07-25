using ContactBook_ViewsNavigation.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBook_ViewsNavigation.DbRealization
{
    public class DataContext : DbContext
    {
        private readonly string ConnectionString = @"Server=(localdb)\MSSQLLocalDB; Database=NavViewsDb; Trusted_Connection=True;";
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Order>? Orders { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
