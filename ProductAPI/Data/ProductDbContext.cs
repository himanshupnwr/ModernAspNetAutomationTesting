using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Data
{
    public class ProductDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ProductDbContext(DbContextOptions<ProductDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    builder=> builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null));
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Products { get; set; }
    }
}
