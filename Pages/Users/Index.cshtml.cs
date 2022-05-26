using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using TrainTickets.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace TrainTickets.Areas.Identity.Pages.Users
{
    [Authorize(Roles = "ADMIN")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public IList<ApplicationUser> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = _userManager.Users.ToList();
            IList<ApplicationUser> usersNotAdmins = new List<ApplicationUser>();
            foreach (var user in Users) {
                if (!(await _userManager.IsInRoleAsync(user, "ADMIN"))) {
                    usersNotAdmins.Add(user);
                }
            }
            Users = usersNotAdmins;
            return Page();
        }
    }
}
