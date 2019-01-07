using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedAirlinesDotNetCore2.Entities
{
    public class FlightEntity
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public AircraftEntity Aircraft { get; set; }
        public RouteEntity Route { get; set; }
        public ICollection<PassengerEntity> Passengers { get; set; }
    }
}
