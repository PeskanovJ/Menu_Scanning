using MenuParser.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuParser.Infrastructure.Persistence
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options) { }

        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(menu =>
            {
                menu.HasKey(x => x.Id);
                menu.Property(x => x.Name).IsRequired();
                menu.Property(x => x.CreatedAt);

                menu.HasMany(x => x.Items)
                     .WithOne()
                     .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<MenuItem>(item =>
            {
                item.HasKey(i => i.Id);
                item.Property(i => i.Name).IsRequired();
                item.Property(i => i.IsDeleted);

                item.OwnsOne(i => i.Price, price =>
                {
                    price.Property(p => p.Amount).HasColumnName("Amount");
                    price.Property(p => p.Currency).HasColumnName("Currency");
                });
            });
        }
    }
}
