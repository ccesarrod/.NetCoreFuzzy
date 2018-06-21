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

            base.OnModelCreating(modelBuilder);

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new ProductMap());
        //    modelBuilder.Configurations.Add(new CategoryMap());
        //    // modelBuilder.Configurations.InsertOrUpdate(new ShoppingCartMap());
        //    modelBuilder.Configurations.Add(new CartDetailsMap());
        //    modelBuilder.Configurations.Add(new CustomerMap());
        //    modelBuilder.Configurations.Add(new OrderMap());
        //    modelBuilder.Configurations.Add(new Order_DetailMap());

        //}

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}
