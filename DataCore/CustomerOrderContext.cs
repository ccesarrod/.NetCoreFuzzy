using fuzzy.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace fuzzy.core.DataCore
{
    public class CustomerOrderContext : DbContext
    {
        public CustomerOrderContext(DbContextOptions<CustomerOrderContext> options) : base(options) { }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Customer>().ToTable("Customers");
          

            base.OnModelCreating(modelBuilder);

        }
       

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}
