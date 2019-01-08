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
            IEnumerable<AirportEntity> airports = _context.Airports.ToList();
            if (!airports.Any()) return null;

            return _mapper.Map<IEnumerable<Airport>>(airports);
        }

        public Airport GetAirportById(Guid id)
        {
            AirportEntity entity = _context.Airports.SingleOrDefault(a => a.Id == id);
            if (entity == null) return null;

            return _mapper.Map<Airport>(entity);
        }

        public Airport CreateAirport(AirportFormCreate airportFormCreate)
        {
            AirportEntity entity = _mapper.Map<AirportEntity>(airportFormCreate);
            entity.Id = Guid.NewGuid();

            _context.Airports.Add(entity);
            var created = _context.SaveChanges();
            if (created < 1) throw new InvalidOperationException("Could not create new airport.");

            return _mapper.Map<Airport>(entity);
        }

        public void DeleteAirport(Guid airportId)
        {
            AirportEntity entity = _context.Airports.SingleOrDefault(a => a.Id == airportId);
            if (entity == null) return;

            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateAirport(Guid airportId, AirportFormUpdate airportFormUpdate)
        {
            AirportEntity entity = _context.Airports.SingleOrDefault(a => a.Id == airportId);
            _mapper.Map(airportFormUpdate, entity);

            _context.SaveChanges();
        }
    }
}
