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
        private readonly AirlineApiDbContext context;
        private readonly IMapper mapper;

        public DefaultAircraftService(AirlineApiDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            IEnumerable<AircraftEntity> aircrafts = context.Aircrafts.ToList();
            if (aircrafts.Count() == 0) return null;

            return mapper.Map<IEnumerable<Aircraft>>(aircrafts);
        }

        public Aircraft GetAircraftById(Guid id)
        {
            AircraftEntity aircraftEntity = context.Aircrafts.SingleOrDefault(a => a.Id == id);

            if (aircraftEntity == null) return null;

            // Return Mapp.Map to Aircraft(JsonResource) from the Aircraft(DatabaseEntity)
            return mapper.Map<Aircraft>(aircraftEntity);

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
    }
}
