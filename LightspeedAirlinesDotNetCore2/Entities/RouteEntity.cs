using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedAirlinesDotNetCore2.Entities
{
    public class RouteEntity
    {
        public Guid Id { get; set; }
        public AirportEntity OriginAirport { get; set; }
        public AirportEntity DestinationAirport { get; set; }
        public int RouteDistance { get; set; }
    }
}
