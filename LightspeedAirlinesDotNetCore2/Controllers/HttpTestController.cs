using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LightspeedAirlinesDotNetCore2.Controllers
{
    [Route("api/test")]
    public class HttpTestController : ControllerBase
    {
        private readonly SingaporeClient _singaporeClient;

        public HttpTestController(SingaporeClient client)
        {
            _singaporeClient = client;
        }

        [HttpGet]
        public async Task<ActionResult> GetSingaporeData()
        {
            Dictionary<string, string> request = new Dictionary<string, string>();
            request.Add("originAirportCode", "SIN");
            request.Add("scheduledDepartureDate", "2019-01-27");
            request.Add("destinationAirportCode", "LHR");
            request.Add("scheduledArrivalDate", "2019-01-27");

            var clientUUID = "humayun77";

            var request2 = new
            {
                request = request,
                clientUUID = clientUUID
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(request2);
            
//            var result = await _singaporeClient.Client.PostAsJsonAsync("", new StringContent(json, Encoding.UTF8, "application/json"));
            var result = await _singaporeClient.Client.PostAsJsonAsync("", request2);

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<ExpandoObject>();
                return Ok(data);
            }

            return NotFound();
        }
    }
}
