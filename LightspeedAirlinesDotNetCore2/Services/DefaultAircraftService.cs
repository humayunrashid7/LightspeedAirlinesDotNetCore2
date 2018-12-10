using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task<Aircraft> GetAircraftAsync(Guid id)
        {
            var entity = await context.Aircrafts.SingleAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            // Return the map to "Aircraft" using the "entity" object
            return mapper.Map<Aircraft>(entity);

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
