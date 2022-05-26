using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrainTickets.Pages
{
    [Authorize(Roles = "ADMIN")]
    public class AdminPanelModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
