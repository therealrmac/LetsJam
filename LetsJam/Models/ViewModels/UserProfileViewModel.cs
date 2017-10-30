using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsJam.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public List<Band> Band { get; set; }
   
        public ApplicationUser User { get; set; }

        public Relation relation { get; set; }

        public bool checkconnectedbutnotconfirmed { get; set; }
        public bool checkConnectedAndConfirmed { get; set; }
        public bool checkConnectedAndConfirmed2 { get; set; }
        public List<Relation> friendList { get; set; }
        public List<Relation> friendList2 { get; set; }
        public List<Relation> friendList3 { get; set; }
        public List<Relation> friendList4 { get; set; }
        public List<Band> thebands { get; set; }
        public IEnumerable<Band> Currentbands { get; set; }
      
    }
}
