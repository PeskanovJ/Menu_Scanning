using Microsoft.EntityFrameworkCore;
using MenuParser.Domain.Entities;

namespace MenuParser.Infrastructure.Persistence
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options) { 
        }

        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<MenuItem> MenuItem => Set<MenuItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(menu =>
            {
                menu.HasKey(x => x.Id);
                menu.Property(x => x.Name).IsRequired();
                menu.Property(x => x.CreatedAt);

                menu.HasMany(x=>x.Items).WithOne().OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<MenuItem>(item =>
            {
                item.HasKey(item => item.Id);
                item.Property(item => item.Name).IsRequired();
                item.Property(item => item.IsDeleted);
                item.OwnsOne(i => i.Price, price =>
                {
                    price.Property(p => p.Amount).HasColumnName("PriceAmount");
                    price.Property(p => p.Currency).HasColumnName("PriceCurrency");
                });
            });
        }
    }
}
