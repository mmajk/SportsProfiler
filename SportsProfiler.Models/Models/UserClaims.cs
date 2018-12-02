using System;
using System.ComponentModel.DataAnnotations;

namespace SportsProfiler.Models.Models
{
    public class UserClaims
    {
        [Key]
        public int UserClaimId { get; set; }
        
        [Required]
        public string ClaimType { get; set; }
        
        [Required]
        public string ClaimValue { get; set; }

        public Guid UserId { get; set; }
    }
}