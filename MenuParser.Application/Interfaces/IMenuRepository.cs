using MenuParser.Domain.Entities;

namespace MenuParser.Application.Interfaces
{
    public interface IMenuRepository
    {
        Task<Menu?> GetIdAsync(Guid id);
        Task AddAsync (Menu menu);
    }
}
