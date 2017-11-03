
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LetsJam.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public virtual ICollection<Band> Bands { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }

        [Required]
        public string instrument { get; set; }

        [Required]
        public string musicStyle { get; set; }

        public string pastExperience { get; set; }

        
        public string ProfileImage { get; set; }
        
        public ICollection<StatusUpdates> updates { get; set; }

        [InverseProperty("Friend")]
        public virtual ICollection<Relation> Friends { get; set; }
    }
}