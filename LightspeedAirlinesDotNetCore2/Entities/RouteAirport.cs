using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedAirlinesDotNetCore2.Entities
{
    public class RouteAirport
    {
        public Guid RouteId { get; set; }
        public RouteEntity RouteEntity { get; set; }

        public Guid AirportId { get; set; }
        public AirportEntity AirportEntity { get; set; }
    }
}
