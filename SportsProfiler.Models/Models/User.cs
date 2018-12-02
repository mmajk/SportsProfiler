using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SportsProfiler.Models.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        public String FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}