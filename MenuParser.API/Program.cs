using MenuParser.Application;
using MenuParser.Application.Interfaces;
using MenuParser.Infrastructure;
using MediatR;
using MenuParser.Application.Menus.Commands.CreateMenu; // or any class from Application layer
using MenuParser.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplicationServices();
builder.Services.AddInfrastructureServices("Data Source=menuparser.db");
builder.Services.AddDbContext<MenuDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<MenuDbContext>());

// Add MediatR manually (optional since Application already does it)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateMenuCommandHandler).Assembly));

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
