using MediatR;
using MenuParser.API.Requests.MenuRequests;
using MenuParser.Application.Menus.Commands.CreateMenu;
using MenuParser.Application.Menus.Queries.GetMenuById;
using Microsoft.AspNetCore.Mvc;


namespace MenuParser.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuParserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuParserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateMenu(CreateMenuRequest request)
        //{
        //    var id = await _mediator.Send(new CreateMenuCommand
        //    {
        //        Name = request.Name!
        //    });
        //    return Ok(new { Id = id });
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }


        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var menu = await _mediator.Send(new GetMenuByIdQuery { Id = id });
            return menu is null ? NotFound() : Ok(menu);
        }
    }
}
