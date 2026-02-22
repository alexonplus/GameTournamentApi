using GameTournamentApi.DTOs;

namespace GameTournamentApi.Services
{
    public interface IGameService
    {
        Task<GameDto?> AddGameAsync(GameCreateDto gameDto);
        Task<IEnumerable<GameDto>> GetAllGamesAsync();

        // Added for Get a single game by its unique ID
        Task<GameDto?> GetGameByIdAsync(int id);

        Task<GameDto?> UpdateGameAsync(int id, GameCreateDto gameDto);
        Task<bool> DeleteGameAsync(int id);
    }
}