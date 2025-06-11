using MediatR;
using MenuParser.Application.Interfaces;
using MenuParser.Domain.Entities;

namespace MenuParser.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler: IRequestHandler<CreateMenuCommand, Guid>
    {
        private readonly IMenuRepository _repository;

        public CreateMenuCommandHandler(IMenuRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateMenuCommand request, CancellationToken cancelationToken)
        {
            var menu = new Menu(request.Name);
            await _repository.AddAsync(menu);
            return menu.Id;
        }
    }
}
