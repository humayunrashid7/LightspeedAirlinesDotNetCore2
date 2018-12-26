using System;

namespace LightspeedAirlinesDotNetCore2.Entities
{
    public class AircraftEntity
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Fin { get; set; }
        public string ManufactureDate { get; set; }
        public int Capacity { get; set; }
    }
}
