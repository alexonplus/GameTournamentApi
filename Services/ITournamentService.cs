using GameTournamentApi.Models;
namespace GameTournamentApi.Services
{
    public interface ITournamentService
    {
         // The method promises to return an enumerable list (IEnumerable) of tournaments asynchronously
        Task<IEnumerable<Tournament>> GetAllTournamentsAsync();

        //Enumerable - you can only read.

        Task<Tournament> AddTournamentAsync(Tournament tournament);// Adds a tournament and returns the created entity with its generated ID.

    }
}
