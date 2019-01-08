using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedAirlinesDotNetCore2.Models
{
    public class Airport : Resource
    {
        public Guid Id { get; set; }
        public string IataCode { get; set; }
        public string IcaoCode { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Altitude { get; set; }
        public DateTimeOffset TimeZone { get; set; }
    }
}
