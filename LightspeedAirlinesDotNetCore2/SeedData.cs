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
                Registration = "C-FITL"
            });

            context.Aircrafts.Add(new AircraftEntity
            {
                Id = Guid.Parse("7cad33ad-7a3b-4e85-ad2b-ef85e76327a2"),
                Fin = "732",
                ManufactureDate = "March 2007",
                Manufacturer = "Boeing",
                Model = "777-200LR",
                Registration = "C-FITL"
            });

            context.Aircrafts.Add(new AircraftEntity
            {
                Id = Guid.Parse("de9f6d3d-e697-4da3-b89e-86c9338ec0e8"),
                Fin = "733",
                ManufactureDate = "April 2007",
                Manufacturer = "Boeing",
                Model = "777-200",
                Registration = "C-FITL"
            });

            await context.SaveChangesAsync();

        }
    }
}
