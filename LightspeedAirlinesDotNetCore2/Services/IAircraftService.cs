using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Models;

namespace LightspeedAirlinesDotNetCore2.Services
{
    public interface IAircraftService
    {
        Aircraft GetAircraftById(Guid id);
        IEnumerable<Aircraft> GetAllAircrafts();
    }
}
