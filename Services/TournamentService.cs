using GameTournamentApi.Data;
using GameTournamentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApi.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly TournamentDbContext _context;

        //// Constructor:  ask the system to give us access to the database
        public TournamentService(TournamentDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tournament>> GetAllTournamentsAsync()
        {
            return await _context.Tournaments.ToListAsync();
        }

    
        public async Task<Tournament> AddTournamentAsync(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

    }
}
