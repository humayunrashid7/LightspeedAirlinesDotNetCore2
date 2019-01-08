using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Models;
using LightspeedAirlinesDotNetCore2.Services;
using LightspeedAirlinesDotNetCore2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LightspeedAirlinesDotNetCore2.Controllers
{
    [Route("api/aircrafts")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AircraftsController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;

        public AircraftsController(IAircraftService aircraftService)
        {
            this._aircraftService = aircraftService;
        }


        // GET api/aircrafts
        [HttpGet(Name = nameof(GetAllAircrafts))]
        public IActionResult GetAllAircrafts()
        {
            IEnumerable<Aircraft> aircrafts = _aircraftService.GetAllAircrafts();

            if (aircrafts == null) return NotFound();

            // Enumerate through each single Aircraft and call CreateLinks method.
            aircrafts = aircrafts.Select(aircraft =>
            {
                aircraft = CreateLinks(aircraft);
                return aircraft;
            });

            Link link = new Link
            {
                Href = Url.Link(nameof(GetAllAircrafts), null),
                Relation = "self",
                Method = Link.GetMethod
            };

            var response = new
            {
                Value = aircrafts,
                Links = link
            };

            return Ok(response);
        }


        // GET /aircrafts/{aircraftId}
        [HttpGet("{aircraftId}", Name = nameof(GetAircraftById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetAircraftById(Guid aircraftId)
        {
            Aircraft aircraft = _aircraftService.GetAircraftById(aircraftId);

            if (aircraft == null) return NotFound();

            return Ok(CreateLinks(aircraft));
        }


        // POST api/aircrafts
        [HttpPost(Name = nameof(CreateAircraft))]
        [ProducesResponseType(400)]
        public IActionResult CreateAircraft([FromBody] AircraftFormCreate newAircraftForm)
        {
            if (newAircraftForm == null) return BadRequest();

            // ASP.NET does validation automatically

            // Do some business rules check here, i.e. Check if Aircraft is over 15 years old
            // If Aircraft doesnt meet requirement, return BadRequest
            /* Example:
             * var maxAge = 15;
             * bool tooOld = aircraft.Age > 15
             * if (tooOld) return BadRequest(new ApiError($"The max age is 15 years"));
             */

            Aircraft newCreatedAircraft = _aircraftService.CreateAircraft(newAircraftForm);

            return CreatedAtRoute(
                routeName: nameof(GetAircraftById),
                routeValues: new { aircraftId = newCreatedAircraft.Id },
                value: CreateLinks(newCreatedAircraft));
        }

        // DELETE api/aircrafts/{aircraftId}
        [HttpDelete("{aircraftId}", Name = nameof(DeleteAircraftById))]
        [ProducesResponseType(204)]
        public IActionResult DeleteAircraftById(Guid aircraftId)
        {
            _aircraftService.DeleteAircraft(aircraftId);
            return NoContent();
        }

        // PUT api/aircrafts/{aircraftId}
        [HttpPut("{aircraftId}", Name = nameof(UpdateAircraft))]
        public IActionResult UpdateAircraft(Guid aircraftId, [FromBody] AircraftFormUpdate aircraftForm)
        {
            _aircraftService.UpdateAircraft(aircraftId, aircraftForm);

            return NoContent();
        }


        // Method to create Links for the Resource Aircraft
        public Aircraft CreateLinks(Aircraft aircraft)
        {
            var getHref = Url.Link(nameof(GetAircraftById), new { aircraftId = aircraft.Id });
            aircraft.Links.Add(new Link(getHref, "self", Link.GetMethod));

            var deleteHref = Url.Link(nameof(DeleteAircraftById), new { aircraftId = aircraft.Id });
            aircraft.Links.Add(new Link(deleteHref, "delete-aircraft", Link.DeleteMethod));

            var updateHref = Url.Link(nameof(UpdateAircraft), new { aircraftId = aircraft.Id });
            aircraft.Links.Add(new Link(updateHref, "update-aircraft", Link.UpdateMethod));

            return aircraft;
        }

    }
}
