using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LightspeedAirlinesDotNetCore2.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/")]
    public class RootController : ControllerBase
    {

        [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                aircrafts = new
                {
                    href = Url.Link(nameof(AircraftsController.GetAllAircrafts), null)
                },
                info = new
                {
                    href = Url.Link(nameof(AirlineInfoController.GetAirlineInfo), null)
                }
            };

            return Ok(response);
        }
    }
}
