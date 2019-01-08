using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Entities;
using LightspeedAirlinesDotNetCore2.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LightspeedAirlinesDotNetCore2
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<AirlineApiDbContext>());
        }

        public static async Task AddTestData(AirlineApiDbContext context)
        {
            if (context.Aircrafts.Any())
            {
                // Already has data, No need to seed
                return;
            }

            context.Aircrafts.Add(new AircraftEntity
            {
                Id = Guid.Parse("3f9f6ae7-486e-405b-b720-b8ec7ce1fa02"),
                Fin = "731",
                ManufactureDate = "March 2007",
                Manufacturer = "Boeing",
                Model = "777-300ER",
                Registration = "C-FITL",
                Capacity = 320
            });

            context.Aircrafts.Add(new AircraftEntity
            {
                Id = Guid.Parse("7cad33ad-7a3b-4e85-ad2b-ef85e76327a2"),
                Fin = "732",
                ManufactureDate = "March 2007",
                Manufacturer = "Boeing",
                Model = "777-200LR",
                Registration = "C-FIZZ",
                Capacity = 300
            });

            context.Aircrafts.Add(new AircraftEntity
            {
                Id = Guid.Parse("de9f6d3d-e697-4da3-b89e-86c9338ec0e8"),
                Fin = "733",
                ManufactureDate = "April 2007",
                Manufacturer = "Boeing",
                Model = "777-200",
                Registration = "C-FILL",
                Capacity = 315
            });

            context.Airports.Add(new AirportEntity
            {
                Id = Guid.Parse("46e009cc-47e2-463b-9dbb-cd412fb094d6"),
                IataCode = "YYZ",
                IcaoCode = "CYYZ",
                Name = "Toronto Pearson International Airport",
                City = "Toronto",
                Country = "Canada",
                Altitude = 569,
                TimeZone = (DateTimeOffset.Now)
            });

            context.Airports.Add(new AirportEntity
            {
                Id = Guid.Parse("4ea02ffd-fe37-4271-87ac-a3e4cb5f691e"),
                IataCode = "YUL",
                IcaoCode = "CYUL",
                Name = "Montréal–Pierre Elliott Trudeau International Airport",
                City = "Montreal",
                Country = "Canada",
                Altitude = 118,
                TimeZone = (DateTimeOffset.Now)
            });

            context.Airports.Add(new AirportEntity
            {
                Id = Guid.Parse("f2decec3-1763-4405-9243-deda35a997c4"),
                IataCode = "YVR",
                IcaoCode = "VYVR",
                Name = "Vancouver International Airport",
                City = "Vancouver",
                Country = "Canada",
                Altitude = 13,
                TimeZone = (DateTimeOffset.Now)
            });

            context.Airports.Add(new AirportEntity
            {
                Id = Guid.Parse("3e7fde05-8c4f-4560-b910-75cb0c84e105"),
                IataCode = "YYC",
                IcaoCode = "CYYC",
                Name = "Calgary International Airport",
                City = "Calgary",
                Country = "Canada",
                Altitude = 3606,
                TimeZone = (DateTimeOffset.Now)
            });

            await context.SaveChangesAsync();

        }
    }
}
