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

        public async Task<GameDto?> AddGameAsync(GameCreateDto gameDto)
        {
            // 1. Verify that the tournament exists
            var tournament = await _context.Tournaments
                .FirstOrDefaultAsync(t => t.Id == gameDto.TournamentId);

            if (tournament == null)
            {
                return null;
            }

            // 2. Map DTO to Model
            var newGame = new Game
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                TournamentId = gameDto.TournamentId
            };

            // 3. Save to database
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();

            // 4. Return clean DTO (prevents 500 circular reference error)
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
    }
}