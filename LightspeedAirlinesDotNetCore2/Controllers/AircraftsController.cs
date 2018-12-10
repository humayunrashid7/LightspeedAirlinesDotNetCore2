using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Models;
using LightspeedAirlinesDotNetCore2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LightspeedAirlinesDotNetCore2.Controllers
{
    [ApiController]
    [Route("/Aircrafts")]
    public class AircraftsController : ControllerBase
    {
        private readonly IAircraftService aircraftService;

        public AircraftsController(IAircraftService aircraftService)
        {
            this.aircraftService = aircraftService;
        }

        [HttpGet(Name = nameof(GetAircrafts))]
        public IActionResult GetAircrafts()
        {
            throw new NotImplementedException();
        }

        // GET /aircrafts/{aircraftId}
        [HttpGet("{aircraftId}", Name = nameof(GetAircraftById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Aircraft>> GetAircraftById(Guid aircraftId)
        {
            var aircraft = await aircraftService.GetAircraftAsync(aircraftId);
            if (aircraft == null) return NotFound();

            return aircraft;
        }
    }
}
