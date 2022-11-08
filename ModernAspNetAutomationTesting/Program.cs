using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IServiceCollection serviceCollection = builder.Services.AddDbContext<ProductDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
var dbService = app.Services.GetService<ProductDbContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    dbService.Database.EnsureCreated();
}

dbService.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();