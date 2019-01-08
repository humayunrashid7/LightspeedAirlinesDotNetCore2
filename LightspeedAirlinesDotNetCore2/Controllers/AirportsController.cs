using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Models;
using LightspeedAirlinesDotNetCore2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LightspeedAirlinesDotNetCore2.Controllers
{
    [Route("api/airports")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            this._airportService = airportService;
        }

        // GET api/airports
        [HttpGet(Name = nameof(GetAllAirports))]
        public IActionResult GetAllAirports()
        {
            IEnumerable<Airport> airports = _airportService.GetAllAirports();
            if (airports == null) return NotFound();

            // Enumerate through each single Aircraft and call CreateLinks method.
            airports = airports.Select(airport =>
            {
                airport = CreateLinks(airport);
                return airport;
            });

            Link link = new Link
            {
                Href = Url.Link(nameof(GetAllAirports), null),
                Relation = "self",
                Method = Link.GetMethod
            };

            var response = new
            {
                Value = airports,
                Links = link
            };

            return Ok(response);
        }

        // GET /airports/{airportId}
        [HttpGet("{airportId}", Name = nameof(GetAirportById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetAirportById(Guid airportId)
        {
            Airport airport = _airportService.GetAirportById(airportId);

            if (airport == null) return NotFound();

            return Ok(CreateLinks(airport));
        }


        // POST api/airports
        [HttpPost(Name = nameof(CreateAirport))]
        [ProducesResponseType(400)]
        public IActionResult CreateAirport([FromBody] AirportFormCreate newAirportForm)
        {
            if (newAirportForm == null) return BadRequest();

            Airport newCreatedAirport = _airportService.CreateAirport(newAirportForm);

            return CreatedAtRoute(
                routeName: nameof(GetAirportById),
                routeValues: new { airportId = newCreatedAirport.Id },
                value: CreateLinks(newCreatedAirport));
        }

        // DELETE api/airports/{airportId}
        [HttpDelete("{airportId}", Name = nameof(DeleteAirportById))]
        [ProducesResponseType(204)]
        public IActionResult DeleteAirportById(Guid airportId)
        {
            _airportService.DeleteAirport(airportId);
            return NoContent();
        }

        // PUT api/aircrafts/{airportId}
        [HttpPut("{airportId}", Name = nameof(UpdateAirport))]
        public IActionResult UpdateAirport(Guid airportId, [FromBody] AirportFormUpdate airportForm)
        {
            _airportService.UpdateAirport(airportId, airportForm);

            return NoContent();
        }

        // Method to create Links for the Resource Airport
        public Airport CreateLinks(Airport airport)
        {
            var getHref = Url.Link(nameof(GetAirportById), new { airportId = airport.Id });
            airport.Links.Add(new Link(getHref, "self", Link.GetMethod));

            var deleteHref = Url.Link(nameof(DeleteAirportById), new { airportId = airport.Id });
            airport.Links.Add(new Link(deleteHref, "delete-airport", Link.DeleteMethod));

            var updateHref = Url.Link(nameof(UpdateAirport), new { airportId = airport.Id });
            airport.Links.Add(new Link(updateHref, "update-airport", Link.UpdateMethod));

            return airport;
        }
    }
}
