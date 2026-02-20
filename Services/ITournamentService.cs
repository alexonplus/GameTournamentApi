using GameTournamentApi.Models;
namespace GameTournamentApi.Services
{
    public interface ITournamentService
    {
         // The method promises to return an enumerable list (IEnumerable) of tournaments asynchronously
        Task<IEnumerable<Tournament>> GetAllTournamentsAsync();

        //Enumerable - you can only read.
    }
}
