using System;
using System.Globalization;

namespace SportsProfiler.Models.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Addres { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int PostalCode { get; set; }

        public Guid UserId { get; set; }
    }
}