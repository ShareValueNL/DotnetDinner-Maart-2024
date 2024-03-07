// Program.cs
using Microsoft.EntityFrameworkCore;
using DotnetDinnerApi;
using DotnetDinnerApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DinnerDbContext>(options => options.UseInMemoryDatabase("DinnerDb"));
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapGet("/", async (DinnerDbContext db) =>
{
    await db.Database.EnsureCreatedAsync();
    var visitors = await db.Visitors.ToListAsync();
    var random = new Random();
    var winners = visitors.OrderBy(x => random.Next()).Take(2).ToList();
    return Results.Ok(new { FirstPrize = winners[0].Name, SecondPrize = winners[1].Name });
});

app.Run();