using GameTournamentApi.Data;
using GameTournamentApi.Services;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

// DI(Dependency Injection) SECTION 

// 1.creating the builder for the application, which will be used to configure services and middleware.
var builder = WebApplication.CreateBuilder(args);

//2. Adding services to the container. This is where you register dependencies that your application will use. In this case its  adding a DbContext for the tournament database
builder.Services.AddDbContext<TournamentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITournamentService, TournamentService>();


//3.this is for swager 
builder.Services.AddOpenApi();


//4 creating the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
