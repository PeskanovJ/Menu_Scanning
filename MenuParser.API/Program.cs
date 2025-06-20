using MenuParser.Application;
using MenuParser.Application.Interfaces;
using MenuParser.Infrastructure;
using MediatR;
using MenuParser.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MenuParser.Infrastructure.Services;
using MenuParser.Application.Menus.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<MenuDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMenuRepository, MenuRepository>();

builder.Services.AddScoped<IMenuImageParser, TesseractMenuImageParser>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ParseMenuFromImageHandler).Assembly);
});



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
