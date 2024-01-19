using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using DotnetDinner;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DinnerDbContext>(options => options.UseInMemoryDatabase("DinnerDb"));
var app = builder.Build();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DinnerDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.MapGet("/", async (DinnerDbContext db) =>
{
    var rng = new Random();
    var visitors = await db.Visitors.ToListAsync();
    var winners = visitors.OrderBy(x => rng.Next()).Take(2).ToList();
    return new { FirstPrize = new { Winner = winners[0].Name, Prize = ".NET zomerhoedje" }, SecondPrize = new { Winner = winners[1].Name, Prize = ".NET sokken" } };
});

app.Run();