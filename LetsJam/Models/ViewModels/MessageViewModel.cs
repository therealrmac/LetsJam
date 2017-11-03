using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsJam.Models.ViewModels
{
    public class MessageViewModel
    {
        public List<StatusUpdates> updates { get; set; }

        public ApplicationUser appUser { get; set; }

    }
}
