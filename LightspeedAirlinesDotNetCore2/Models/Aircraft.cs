using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedAirlinesDotNetCore2.Models
{
    public class Aircraft : Resource
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Fin { get; set; }
        public string ManufactureDate { get; set; }
    }
}
