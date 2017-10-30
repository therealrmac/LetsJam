using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsJam.Models.ViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<ApplicationUser> user { get; set; }
        
    }
}
