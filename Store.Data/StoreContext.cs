using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;

namespace Store.Data
{
    public class StoreContext: DbContext
    {
      
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }



        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
   
}