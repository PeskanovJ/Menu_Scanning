using MediatR;

namespace MenuParser.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommand : IRequest<Guid>
    {
        public String Name { get; set; } = string.Empty;
    }
}
