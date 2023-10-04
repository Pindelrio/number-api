using Microsoft.EntityFrameworkCore;
using NumberAPI.Data;
using NumberAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("NumbersDb"));

var app = builder.Build();

app.UseHttpsRedirection();

//Get All
app.MapGet("api/numbers", async (AppDbContext context) => {

    var items = await context.Numbers.ToListAsync();

    return Results.Ok(items);
});

//Post
app.MapPost("api/numbers", async (AppDbContext context, NumItem item) => {

    await context.Numbers.AddAsync(item);
    await context.SaveChangesAsync();
    return Results.Created($"api/numbers/{item.Id}",item);

});

app.Run();
