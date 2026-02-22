using GameTournamentApi.Data;
using GameTournamentApi.Services;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;




// DI(Dependency Injection) SECTION 

// 1.creating the builder for the application, which will be used to configure services and middleware.
var builder = WebApplication.CreateBuilder(args);

// for swager
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

//2. Adding services to the container. This is where you register dependencies that your application will use. In this case its  adding a DbContext for the tournament database
builder.Services.AddDbContext<TournamentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITournamentService, TournamentService>();


builder.Services.AddScoped<IGameService, GameService>();


//3.this is for swager 
builder.Services.AddOpenApi();


//4 creating the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();   
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();