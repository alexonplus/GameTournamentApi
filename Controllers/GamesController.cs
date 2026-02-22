
using GameTournamentApi.Services;
using Microsoft.AspNetCore.Mvc;
using GameTournamentApi.DTOs;
using GameTournamentApi.Models;

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
    }
}