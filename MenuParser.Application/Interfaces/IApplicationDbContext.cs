using MenuParser.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuParser.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Menu> Menus { get; }
        DbSet<MenuItem> MenuItems { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
