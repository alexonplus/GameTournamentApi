
using Microsoft.AspNetCore.Mvc;
using GameTournamentApi.Services;
using GameTournamentApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameTournamentApi.DTOs;
using System.Linq;

namespace GameTournamentApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    

    public class TournamentsController:ControllerBase
    
    {
        private readonly ITournamentService _service;

        public TournamentsController(ITournamentService service)
        {
            _service = service;

            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournaments()
        {
            var tournaments = await _service.GetAllTournamentsAsync();

            var dtoList = tournaments.Select(t => new TournamentDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                MaxPlayers = t.MaxPlayers,
                Date = t.Date
            
            });

            return Ok(dtoList);

        }

        //post 
        [HttpPost]
        public async Task<ActionResult<TournamentDto>> CreateTournament([FromBody] TournamentCreateDto createDto)
        {
            // 1. Map the incoming DTO to the Tournament entity model 
            var tournament = new Tournament
            {
                Title = createDto.Title,
                Description = createDto.Description,
                MaxPlayers = createDto.MaxPlayers,
                Date = createDto.Date
            };

            // 2. Save the tournament to the database via the service 
            var createdTournament = await _service.AddTournamentAsync(tournament);

            // 3. Return the result as a DTO (now including the generated ID) i hope  
            var resultDto = new TournamentDto
            {
                Id = createdTournament.Id,
                Title = createdTournament.Title,
                Description = createdTournament.Description,
                MaxPlayers = createdTournament.MaxPlayers,
                Date = createdTournament.Date
            };

            return Ok(resultDto);
        }






    }
}
