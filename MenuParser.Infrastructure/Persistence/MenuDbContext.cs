using Microsoft.EntityFrameworkCore;
using MenuParser.Domain.Entities;
using MenuParser.Application.Interfaces;

namespace MenuParser.Infrastructure.Persistence
{
    public class MenuDbContext : DbContext,IApplicationDbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options) { 
        }

        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();


        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

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
