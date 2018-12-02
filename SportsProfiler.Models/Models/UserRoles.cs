using System;
using System.ComponentModel.DataAnnotations;

namespace SportsProfiler.Models.Models
{
    public class UserRoles
    {
        public Guid UserRoleId { get; set; }
        
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}