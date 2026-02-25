using GameTournamentApi.DTOs;
using GameTournamentApi.Models;
using GameTournamentApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTournamentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //security requirement: all endpoints require authentication
    public class TournamentsController : ControllerBase
    {

       

        private readonly ITournamentService _service;

        public TournamentsController(ITournamentService service)
        {
            _service = service;
        }

        // GET: api/tournaments?search=name
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournaments([FromQuery] string? search)
        {
            // Requirement: get all tournaments or search by title
            var tournaments = await _service.GetAllTournamentsAsync(search);

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

        // POST: api/tournaments
        [HttpPost]
        public async Task<ActionResult<TournamentDto>> CreateTournament([FromBody] TournamentCreateDto createDto)
        {
            // Mapping CreateDto to Entity Model
            var tournament = new Tournament
            {
                Title = createDto.Title,
                Description = createDto.Description,
                MaxPlayers = createDto.MaxPlayers,
                Date = createDto.Date
            };

            var createdTournament = await _service.AddTournamentAsync(tournament);

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

        // PUT: api/tournaments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTournament(int id, [FromBody] TournamentCreateDto updateDto)
        {
            // Map incoming DTO to Model for updating
            var tournamentData = new Tournament
            {
                Title = updateDto.Title,
                Description = updateDto.Description,
                MaxPlayers = updateDto.MaxPlayers,
                Date = updateDto.Date
            };

            var updated = await _service.UpdateTournamentAsync(id, tournamentData);

            if (updated == null)
            {
                return NotFound();
            }

            // Return the updated object as a DTO to be safe
            return Ok(new TournamentDto
            {
                Id = updated.Id,
                Title = updated.Title,
                Description = updated.Description,
                MaxPlayers = updated.MaxPlayers,
                Date = updated.Date
            });
        }

        // DELETE: api/tournaments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var success = await _service.DeleteTournamentAsync(id);

            if (!success)
            {
                return NotFound();
            }

            // Return 204 No Content for successful deletion
            return NoContent();
        }
    }
}