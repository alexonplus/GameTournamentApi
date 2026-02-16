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
        public DbSet<Tournament> Tournaments { get; set; } = null;
        public DbSet<Game> Games { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>().HasData(
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