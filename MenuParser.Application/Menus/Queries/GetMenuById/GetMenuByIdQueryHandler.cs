using MediatR;
using MenuParser.Domain.Entities;
using MenuParser.Application.Interfaces;

namespace MenuParser.Application.Menus.Queries.GetMenuById
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, Menu?>
    {
        private readonly IMenuRepository _repository;

        public GetMenuByIdQueryHandler(IMenuRepository repository)
        {
            _repository = repository;
        }

        public async Task<Menu?> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetIdAsync(request.Id);
        }
    }
}
