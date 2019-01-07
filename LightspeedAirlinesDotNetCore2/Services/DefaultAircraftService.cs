using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LightspeedAirlinesDotNetCore2.Entities;
using LightspeedAirlinesDotNetCore2.Models;
using Microsoft.EntityFrameworkCore;

namespace LightspeedAirlinesDotNetCore2.Services
{
    public class DefaultAircraftService : IAircraftService
    {
        private readonly AirlineApiDbContext _context;
        private readonly IMapper _mapper;

        public DefaultAircraftService(AirlineApiDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }


        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            IEnumerable<AircraftEntity> aircrafts = _context.Aircrafts.ToList();
            if (!aircrafts.Any()) return null;

            return _mapper.Map<IEnumerable<Aircraft>>(aircrafts);
        }


        public Aircraft GetAircraftById(Guid id)
        {
            AircraftEntity entity = _context.Aircrafts.SingleOrDefault(a => a.Id == id);

            if (entity == null) return null;

            // Return Mapper.Map to Aircraft(JsonResource) from the Aircraft(DatabaseEntity)
            return _mapper.Map<Aircraft>(entity);

            // The mapping below is replaced by the automapper above.
            //return new Aircraft
            //{
            //    Href = null, //Url.Link(nameof(GetAircraftById), new { aircraftId = entity.Id }),
            //    Manufacturer = entity.Manufacturer,
            //    Model = entity.Model,
            //    Registration = entity.Registration,
            //    Fin = entity.Fin,
            //    ManufactureDate = entity.ManufactureDate
            //};
        }


        public Aircraft CreateAircraft(AircraftFormCreate aircraftForm)
        {
            Guid newId = Guid.NewGuid();
            AircraftEntity newAircraftEntity = _mapper.Map<AircraftEntity>(aircraftForm);

            _context.Aircrafts.Add(newAircraftEntity);

            var created = _context.SaveChanges();
            if (created < 1) throw new InvalidOperationException("Could not create new aircraft.");

            return _mapper.Map<Aircraft>(newAircraftEntity);
        }

        public void DeleteAircraft(Guid aircraftId)
        {
            AircraftEntity aircraft = _context.Aircrafts.SingleOrDefault(a => a.Id == aircraftId);
            if (aircraft == null) return;

            _context.Remove(aircraft);
            _context.SaveChanges();
        }

        public void UpdateAircraft(Guid aircraftId, AircraftFormUpdate aircraftFormUpdate)
        {
            AircraftEntity aircrafEntity = _context.Aircrafts.SingleOrDefault(a => a.Id == aircraftId);

            // Mapper.Map(Source, Dest), It converts the data from AircraftFormUpdate into AircraftEntity
            // by Overriding the fields. After all it is required is to save changes
            _mapper.Map(aircraftFormUpdate, aircrafEntity);

            _context.SaveChanges();
        }
    }
}
