using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightspeedAirlinesDotNetCore2.Entities;
using LightspeedAirlinesDotNetCore2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LightspeedAirlinesDotNetCore2
{
    public class AirlineApiDbContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public AirlineApiDbContext(DbContextOptions options) :  base(options) { }

        public DbSet<AircraftEntity> Aircrafts { get; set; }

        public DbSet<AirportEntity> Airports { get; set; }

//        public DbSet<RouteEntity> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<RouteAirport>()
//                .HasKey(ra => new {ra.RouteId, ra.AirportId});

//            modelBuilder.Entity<RouteAirport>()
//                .HasOne<RouteEntity>(ra => ra.RouteEntity)
//                .HasOne(ra => ra.)
//                .WithMany(r => r.OriginAirports)
//                .HasForeignKey(ra => ra.AirportId).OnDelete(DeleteBehavior.Restrict);
//
//            modelBuilder.Entity<RouteAirport>()
//                .HasOne(ra => ra.RouteEntity)
//                .WithMany(r => r.DestinationAirports)
//                .HasForeignKey(ra => ra.AirportId);
        }
    }
}
