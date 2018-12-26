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
            CreateMap<AircraftEntity, Aircraft>();
            // TODO: Url.Link
        }
    }
}
