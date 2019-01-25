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

        public Guid OriginAirportId { get; set; }
        public AirportEntity OriginAirport { get; set; }

        public Guid DestinationAirportId { get; set; }
        public AirportEntity DestinationAirport { get; set; }

        public int Distance { get; set; }

        public IList<RouteAirport> OriginAirports { get; set; }
        public IList<RouteAirport> DestinationAirports { get; set; }
    }
}
