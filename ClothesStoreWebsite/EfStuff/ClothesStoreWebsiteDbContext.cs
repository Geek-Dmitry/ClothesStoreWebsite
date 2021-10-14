using Microsoft.EntityFrameworkCore;
using СlothesStoreWebsite.EfStuff.Model;

namespace СlothesStoreWebsite.EfStuff
{
    public class ClothesStoreWebsiteDbContext : DbContext
    {
        public ClothesStoreWebsiteDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.WishProducts)
                .WithOne(rocket => rocket.WishProductFor);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}