using MenuParser.Application.Interfaces;
using MediatR;
using MenuParser.Domain.Entities;

namespace MenuParser.Application.Menus.Commands
{

    public class ParseMenuFromImageHandler : IRequestHandler<ParseMenuFromImageCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public ParseMenuFromImageHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(ParseMenuFromImageCommand request, CancellationToken cancellationToken)
        {
            // 1. Use request.ImageFile to do OCR + parse the menu text here

            var menu = new Menu("Parsed Menu");

            // 2. Add parsed items to the menu here

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken);

            // 3. Return the new menu's Id
            return menu.Id;
        }
    }
    
}
