using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Models;

namespace LightspeedAirlinesDotNetCore2.Services.Interfaces
{
    public interface IAirportService
    {
        IEnumerable<Airport> GetAllAirports();

        Airport GetAirportById(Guid id);

        Airport CreateAirport(AirportFormCreate airportFormCreate);

        void DeleteAirport(Guid airportId);

        void UpdateAirport(Guid airportId, AirportFormUpdate airportFormUpdate);
    }
}
