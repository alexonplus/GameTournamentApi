using GameTournamentApi.Data;
using GameTournamentApi.DTOs;
using GameTournamentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApi.Services
{
    public class GameService : IGameService
    {
        private readonly TournamentDbContext _context;

        public GameService(TournamentDbContext context)
        {
            _context = context;
        }

        // Implementation for getting a specific game by ID
        public async Task<GameDto?> GetGameByIdAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return null;

            return new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Genre = game.Genre,
                TournamentId = game.TournamentId
            };
        }

        public async Task<GameDto?> AddGameAsync(GameCreateDto gameDto)
        {
            var tournament = await _context.Tournaments
                .FirstOrDefaultAsync(t => t.Id == gameDto.TournamentId);

            if (tournament == null) return null;

            var newGame = new Game
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                TournamentId = gameDto.TournamentId
            };

            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();

            return new GameDto
            {
                Id = newGame.Id,
                Name = newGame.Name,
                Genre = newGame.Genre,
                TournamentId = newGame.TournamentId
            };
        }

        public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
        {
            return await _context.Games
                .Select(g => new GameDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Genre = g.Genre,
                    TournamentId = g.TournamentId
                })
                .ToListAsync();
        }

        public async Task<GameDto?> UpdateGameAsync(int id, GameCreateDto gameDto)
        {
            var existing = await _context.Games.FindAsync(id);
            if (existing == null) return null;

            var tournamentExists = await _context.Tournaments.AnyAsync(t => t.Id == gameDto.TournamentId);
            if (!tournamentExists) return null;

            existing.Name = gameDto.Name;
            existing.Genre = gameDto.Genre;
            existing.TournamentId = gameDto.TournamentId;

            await _context.SaveChangesAsync();

            return new GameDto
            {
                Id = existing.Id,
                Name = existing.Name,
                Genre = existing.Genre,
                TournamentId = existing.TournamentId
            };
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return false;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}