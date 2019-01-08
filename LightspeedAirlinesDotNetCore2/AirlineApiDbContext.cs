using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Entities;
using LightspeedAirlinesDotNetCore2.Models;
using Microsoft.EntityFrameworkCore;

namespace LightspeedAirlinesDotNetCore2
{
    public class AirlineApiDbContext : DbContext
    {
        public AirlineApiDbContext(DbContextOptions options) :  base(options) { }

        public DbSet<AircraftEntity> Aircrafts { get; set; }

        public DbSet<AirportEntity> Airports { get; set; }
    }
}
