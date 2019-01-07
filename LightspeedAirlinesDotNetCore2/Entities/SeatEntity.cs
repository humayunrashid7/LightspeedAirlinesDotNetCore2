using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedAirlinesDotNetCore2.Entities
{
    public class SeatEntity
    {
        public Guid Id { get; set; }
        public string SeatNumber { get; set; }
        public string SeatClass { get; set; }
    }
}
