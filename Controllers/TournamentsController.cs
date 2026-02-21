
using Microsoft.AspNetCore.Mvc;
using GameTournamentApi.Services;
using GameTournamentApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournaments()
        {
            var tournaments = await _service.GetAllTournamentsAsync();

            return Ok(tournaments);
        }
        


    }
}
