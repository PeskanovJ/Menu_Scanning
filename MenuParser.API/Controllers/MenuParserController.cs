using MediatR;
using MenuParser.API.Requests.MenuRequests;
using MenuParser.Application.Menus.Commands.CreateMenu;
using Microsoft.AspNetCore.Mvc;

namespace MenuParser.API.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuParserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuParserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request)
        {
            var id = await _mediator.Send(new CreateMenuCommand
            {
                Name = request.Name!
            });
            return Ok(new { Id = id });
        }
    }
}
