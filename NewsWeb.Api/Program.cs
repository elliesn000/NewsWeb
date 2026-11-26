using Microsoft.EntityFrameworkCore;
using NewsWeb.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<NewsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("NewsDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
