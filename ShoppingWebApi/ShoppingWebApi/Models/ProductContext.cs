using Microsoft.EntityFrameworkCore;

namespace ShoppingWebApi.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
             : base(options)
        {
        }

        public DbSet<Product> ProductsInDb { get; set; }
    }
}
