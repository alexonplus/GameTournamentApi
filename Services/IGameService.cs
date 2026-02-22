using GameTournamentApi.DTOs;

namespace GameTournamentApi.Services
{
    public interface IGameService
    {
        // Returns a DTO to avoid circular reference errors
        Task<GameDto?> AddGameAsync(GameCreateDto gameDto);

        // Returns a list of games for a specific tournament
        Task<IEnumerable<GameDto>> GetAllGamesAsync();
    }
}