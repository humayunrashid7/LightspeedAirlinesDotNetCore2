using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LightspeedAirlinesDotNetCore2.Entities;
using LightspeedAirlinesDotNetCore2.Models;
using LightspeedAirlinesDotNetCore2.Services.Interfaces;

namespace LightspeedAirlinesDotNetCore2.Services
{
    public class AirportService : IAirportService
    {
        private readonly AirlineApiDbContext _context;
        private readonly IMapper _mapper;

        public AirportService(AirlineApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Airport> GetAllAirports()
        {
            throw new NotImplementedException();
        }

        public Airport GetAirportById(Guid id)
        {
            AirportEntity entity = _context.Airports.SingleOrDefault(a => a.Id == id);
            if (entity == null) return null;

            return _mapper.Map<Airport>(entity);
        }

        public Airport CreateAirport(AirportFormCreate airportFormCreate)
        {
            throw new NotImplementedException();
        }

        public void DeleteAirport(Guid airportId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAirport(Guid airportId, AirportFormUpdate airportFormUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
