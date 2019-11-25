using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyFriendlyCampsite
{
    public class Campsite
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string LocationCounty { get; set; }
        public string LocationTown { get; set; }
        public string ContactWebsite { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
    }
}
