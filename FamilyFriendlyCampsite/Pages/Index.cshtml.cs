using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FamilyFriendlyCampsite.Pages
{
    public class IndexModel : PageModel
    {
        private CampsiteRepository campsiteRepository;
        public IEnumerable<Campsite> Campsites { get; private set; }

        public IndexModel()
        {
            campsiteRepository = new CampsiteRepository();
        }

        public void OnGet()
        {
            Campsites = campsiteRepository.GetCampsites();
        }
    }
}
