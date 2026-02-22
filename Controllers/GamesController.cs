using GameTournamentApi.Services;
using Microsoft.AspNetCore.Mvc;
using GameTournamentApi.DTOs;

namespace GameTournamentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }

        // GET: api/games/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);

            if (game == null)
            {
                // Return 404 if the game is not found in database
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(GameCreateDto gameDto)
        {
            var newGame = await _gameService.AddGameAsync(gameDto);

            if (newGame == null)
            {
                return NotFound("Tournament not found");
            }
            return Ok(newGame);
        }

        [HttpPut("{id}")] //this is the endpoint for updating a game, it requires the game ID and the updated game data in the request body
        public async Task<IActionResult> UpdateGame(int id, [FromBody] GameCreateDto gameDto)// The GameCreateDto is used here for simplicity
        {
            var updatedGame = await _gameService.UpdateGameAsync(id, gameDto); // Call the service to update the game

            if (updatedGame == null)
            {
                return NotFound("Game or Tournament not found");
            }

            return Ok(updatedGame);
        }

        [HttpDelete("{id}")] //this is the endpoint for deleting a game, it requires the game ID in the URL
        public async Task<IActionResult> DeleteGame(int id)
        {
            var success = await _gameService.DeleteGameAsync(id); // Call the service to delete the game

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}