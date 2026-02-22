using GameTournamentApi.Models;

namespace GameTournamentApi.Services
{
    public interface ITournamentService
    {
        // Added 'search' parameter 
        Task<IEnumerable<Tournament>> GetAllTournamentsAsync(string? search);

        Task<Tournament> AddTournamentAsync(Tournament tournament);

        // Required for full CRUD 
        Task<Tournament?> UpdateTournamentAsync(int id, Tournament tournament);

        Task<bool> DeleteTournamentAsync(int id);
    }
}