using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsJam.Models.ViewModels
{
    public class RequestViewModel
    {
        public List<Relation> Relation { get; set; }
        public ApplicationUser AppUser { get; set; }
    }
}
