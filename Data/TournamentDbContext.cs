using Microsoft.EntityFrameworkCore;
using GameTournamentApi.Models;

namespace GameTournamentApi.Data
{
    // This class represents the database context for the tournament application. It inherits from DbContext, which is a part of Entity Framework Core.
    public class TournamentDbContext : DbContext
    {
        // The constructor takes DbContextOptions as a parameter and passes it to the base class constructor. This allows for configuration of the database connection and other options when setting up the context.
        public TournamentDbContext(DbContextOptions<TournamentDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tournament> Tournaments { get; set; } = null; // This property represents the Tournaments table in the database. It is of type DbSet<Tournament>, which allows for querying and saving instances of the Tournament entity. The null value is used to satisfy the compiler
        public DbSet<Game> Games { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder) // This method is overridden to configure the model and seed initial data into the database. The ModelBuilder parameter allows for configuring the entity models and relationships.
        {
            modelBuilder.Entity<Tournament>().HasData(  // This line seeds initial data into the Tournaments table. It creates a new Tournament object with specified properties and adds it to the database when the context is created.
                new Tournament
                {
                    Id = 1,
                    Title = "Pro League 2026",
                    Description = "Global Finals",
                    MaxPlayers = 100,
                    Date = new DateTime(2026, 02, 16)
                }
            );


        }
    }
}