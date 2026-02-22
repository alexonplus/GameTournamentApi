using GameTournamentApi.Data;
using GameTournamentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApi.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly TournamentDbContext _context;

        public TournamentService(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournament>> GetAllTournamentsAsync(string? search)
        {
            var query = _context.Tournaments.AsQueryable();

            // Requirement: search in Title via query parameter
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(t => t.Title.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<Tournament> AddTournamentAsync(Tournament tournament)
        {
            // Requirement: Date cannot be in the past
            if (tournament.Date < DateTime.Now)
            {
                throw new ArgumentException("Tournament date cannot be in the past.");
            }

            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        // Implements UpdateTournamentAsync to fix CS0535
        public async Task<Tournament?> UpdateTournamentAsync(int id, Tournament updatedData)
        {
            var existing = await _context.Tournaments.FindAsync(id);
            if (existing == null) return null;

            if (updatedData.Date < DateTime.Now)
            {
                throw new ArgumentException("Tournament date cannot be in the past.");
            }

            existing.Title = updatedData.Title;
            existing.Description = updatedData.Description;
            existing.MaxPlayers = updatedData.MaxPlayers;
            existing.Date = updatedData.Date;

            await _context.SaveChangesAsync();
            return existing;
        }

        // Implements DeleteTournamentAsync 
        public async Task<bool> DeleteTournamentAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null) return false;

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}