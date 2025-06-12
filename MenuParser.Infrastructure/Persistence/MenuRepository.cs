using MenuParser.Domain.Entities;
using MenuParser.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MenuParser.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MenuDbContext _context;

        public MenuRepository(MenuDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task<Menu?> GetIdAsync(Guid id)
        {
            return await _context.Menus.Include(m => m.Items).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
