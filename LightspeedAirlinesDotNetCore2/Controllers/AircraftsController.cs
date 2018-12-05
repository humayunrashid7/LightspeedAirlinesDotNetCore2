using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LightspeedAirlinesDotNetCore2.Controllers
{
    [ApiController]
    [Route("/Aircrafts")]
    public class AircraftsController : ControllerBase
    {
        [HttpGet(Name = nameof(GetAircrafts))]
        public IActionResult GetAircrafts()
        {
            throw new NotImplementedException();
        }
    }
}
