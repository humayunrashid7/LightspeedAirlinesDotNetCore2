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
    [ApiVersion("1.0")]
    [Route("api/aircrafts")]
    public class AircraftsController : ControllerBase
    {
        private readonly IAircraftService aircraftService;

        public AircraftsController(IAircraftService aircraftService)
        {
            this.aircraftService = aircraftService;
        }

        [HttpGet(Name = nameof(GetAllAircrafts))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetAllAircrafts()
        {
            IEnumerable<Aircraft> aircrafts = aircraftService.GetAllAircrafts();

            if (aircrafts == null) return NotFound();

            // Enumerate through each single Aircraft and call CreaLinks method.
            aircrafts = aircrafts.Select(aircraft =>
            {
                aircraft = CreateLinks(aircraft);
                return aircraft;
            });

            return Ok(aircrafts);
        }

        // GET /aircrafts/{aircraftId}
        [HttpGet("{aircraftId}", Name = nameof(GetAircraftById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetAircraftById(Guid aircraftId)
        {
            Aircraft aircraft = aircraftService.GetAircraftById(aircraftId);
            if (aircraft == null) return NotFound();

            return Ok(CreateLinks(aircraft));
        }

        // Method to create Links for the Resource Aircraft
        public Aircraft CreateLinks(Aircraft aircraft)
        {
            var href = Url.Link(nameof(GetAircraftById), new { aircraftId = aircraft.Id });
            aircraft.Links.Add(new Link(href, "self", Link.GetMethod));

            return aircraft;
        }
    }
}
