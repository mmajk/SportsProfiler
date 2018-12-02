using System;
using System.ComponentModel.DataAnnotations;

namespace SportsProfiler.Models.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        public string RoleDescription { get; set; }
    }
}