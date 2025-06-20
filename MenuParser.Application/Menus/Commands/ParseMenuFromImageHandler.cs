using MenuParser.Application.Interfaces;
using MediatR;
using MenuParser.Domain.Entities;
using Microsoft.AspNetCore.Http;
using MenuParser.Domain.ValueObjects;

namespace MenuParser.Application.Menus.Commands
{
    public class ParseMenuFromImageHandler : IRequestHandler<ParseMenuFromImageCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMenuImageParser _parser;

        public ParseMenuFromImageHandler(IApplicationDbContext context, IMenuImageParser parser)
        {
            _context = context;
            _parser = parser;
        }

        public async Task<Guid> Handle(ParseMenuFromImageCommand request, CancellationToken cancellationToken)
        {
            var parsedItems = await _parser.ParseAsync(request.ImageFile);
            var menu = new Menu("Parsed Menu");

            foreach (var item in parsedItems)
            {
                var menuItem = new MenuItem(item.Name, new Price(item.Amount, item.Currency));
                menu.AddItem(menuItem);
            }

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken);
            return menu.Id;
        }
    }

}
