using Microsoft.EntityFrameworkCore;
using RepairMind.API.Data;
using RepairMind.API.Services;
using RepairMind.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=repairmind.db"));
builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
