using Microsoft.EntityFrameworkCore;
using RepairMind.API.Data;
using RepairMind.API.Services;
using RepairMind.API.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using RepairMind.API.Validators;
using RepairMind.API.Models;
using RepairMind.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=repairmind.db"));
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<Item>, ItemValidator>();
builder.Services.AddScoped<IValidator<RepairRequest>, RepairRequestValidator>();
builder.Services.AddScoped<IRepairSuggestionService, RepairSuggestionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            error = "Something went wrong. Please try again later."
        });
    });
});

app.MapControllers();

app.Run();
