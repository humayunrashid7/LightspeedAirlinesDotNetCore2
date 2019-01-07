using System;
using System.Collections.Generic;

namespace LightspeedAirlinesDotNetCore2.Entities
{
    public class PassengerEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressEntity Address { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public ICollection<FlightEntity> Flights { get; set; }
    }
}
