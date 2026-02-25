using GameTournamentApi.Data;
using GameTournamentApi.Services;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using GameTournamentApi.Extensions;




// DI(Dependency Injection) SECTION 

// 1.creating the builder for the application, which will be used to configure services and middleware.
var builder = WebApplication.CreateBuilder(args);

// for swager
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
 

//2. Adding services to the container. This is where you register dependencies that your application will use. In this case its  adding a DbContext for the tournament database
builder.Services.AddDbContext<TournamentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITournamentService, TournamentService>();


builder.Services.AddScoped<IGameService, GameService>();


//3. swager  in net.8
builder.Services.AddEndpointsApiExplorer();

// my method from JwtExtensions.cs (connect  JWT, + SwaggerGen)
builder.Services.AddAuthServices(builder.Configuration);



//4 creating the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();   
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthentication(); //  server looking for the token in the request and validating it before allowing access to protected resources. If the token is valid, the user is authenticated and can access the requested resource. If the token is invalid or missing, 
app.UseAuthorization();  // cheking if the authenticated user has the necessary permissions to access the requested resource. It checks the user's roles, claims, or policies against the authorization requirements defined for that resource. If the user is authorized, they can proceed to access the resource; otherwise, they will receive an unauthorized response.

app.MapControllers();


app.Run();