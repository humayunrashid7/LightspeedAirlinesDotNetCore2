using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LightspeedAirlinesDotNetCore2.Controllers
{
    [Route("/AirlineInfo")]
    [ApiController]
    public class AirlineInfoController : ControllerBase
    {
        private readonly AirlineInfo airlineInfo;

        public AirlineInfoController(IOptions<AirlineInfo> airlineInfoWrapper)
        {
            this.airlineInfo = airlineInfoWrapper.Value;
        }

        [HttpGet(Name = nameof(GetAirlineInfo))]
        public ActionResult<AirlineInfo> GetAirlineInfo() //Used ActionResult instead of IActionResult because to return strongly typed resource.
        {
            airlineInfo.Href = Url.Link(nameof(GetAirlineInfo), null);
            return airlineInfo;
        }
    }
}
