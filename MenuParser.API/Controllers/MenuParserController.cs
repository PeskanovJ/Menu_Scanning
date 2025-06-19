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

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");
            var command = new ParseMenuFromImageCommand(file);
            var result = await _mediator.Send(command);
            return Ok(new { Menuid = result });
        }

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
