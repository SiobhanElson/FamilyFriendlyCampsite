using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace FamilyFriendlyCampsite.Pages
{
    public class IndexModel : PageModel
    {
        private ICampsiteRepository CampsiteRepository { get; }
        public IEnumerable<Campsite> Campsites { get; private set; }

        public IndexModel(ICampsiteRepository campsiteRepository)
        {
            CampsiteRepository = campsiteRepository;
        }

        public void OnGet()
        {
            Campsites = CampsiteRepository.GetCampsites();
        }
    }
}
