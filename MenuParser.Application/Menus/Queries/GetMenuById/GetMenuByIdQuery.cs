using MediatR;
using MenuParser.Domain.Entities;
using System.Net;

namespace MenuParser.Application.Menus.Queries.GetMenuById
{
    public class GetMenuByIdQuery: IRequest<Menu?>
    {
        public Guid Id { get; set; }
    }
}
