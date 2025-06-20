using MediatR;
using Microsoft.AspNetCore.Http;

public record ParseMenuFromImageCommand(IFormFile ImageFile) : IRequest<Guid>; // returns menuId