using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LightspeedAirlinesDotNetCore2.Entities;
using LightspeedAirlinesDotNetCore2.Models;

namespace LightspeedAirlinesDotNetCore2.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create Map from AircraftEntity to Aircraft Resource
            CreateMap<AircraftEntity, Aircraft>();

            // Create Map from AircraftFormCreate to AircraftEntity
            CreateMap<AircraftFormCreate, AircraftEntity>();

            // Create Map from AircraftFormUpdate to AircraftEntity
            CreateMap<AircraftFormUpdate, AircraftEntity>();

            // Create Map from AirportEntity to Airport Resource
            CreateMap<AirportEntity, Airport>();

            // Create Map from AirportFormCreate to AirportEntity
            CreateMap<AircraftFormCreate, AircraftEntity>();

            // Create Map from AirportFormUpdate to AirportEntity
            CreateMap<AircraftFormUpdate, AircraftEntity>();
        }
    }
}
