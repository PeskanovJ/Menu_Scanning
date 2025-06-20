using Microsoft.AspNetCore.Http;
using MenuParser.Application.Menus.DTOs;

namespace MenuParser.Application.Interfaces
{
    public interface IMenuImageParser
    {
        Task<List<ParsedMenuItem>> ParseAsync(IFormFile image);
    }
}
