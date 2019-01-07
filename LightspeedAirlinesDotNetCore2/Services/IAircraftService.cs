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
        IEnumerable<Aircraft> GetAllAircrafts();

        Aircraft GetAircraftById(Guid id);

        Aircraft CreateAircraft(AircraftFormCreate aircraftFormCreate);

        void DeleteAircraft(Guid aircraftId);

        void UpdateAircraft(Guid aircraftId, AircraftFormUpdate aircraftFormUpdate);
    }
}
