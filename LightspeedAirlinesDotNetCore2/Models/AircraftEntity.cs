using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedAirlinesDotNetCore2.Models
{
    public class AircraftEntity
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Fin { get; set; }
        public string ManufactureDate { get; set; }
        //public ICollection<AircraftSeat> AircraftSeats { get; set; }


        //public AircraftEntity(Guid aircraftId, string manufacturer, string model, string registration, string fin, string manufactureDate)
        //{
        //    this.AircraftId = aircraftId;
        //    this.Manufacturer = manufacturer;
        //    this.Model = model;
        //    this.Registration = registration;
        //    this.Fin = fin;
        //    this.ManufactureDate = manufactureDate;
        //}
    }
}
