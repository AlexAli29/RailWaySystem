using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using TrainTickets.Areas.Identity.Data;

namespace TrainTickets.Areas.Identity.Pages.Users
{
    [Authorize(Roles = "ADMIN")]
    public class DeleteModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteModel(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public ApplicationUser UserToDelete { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id == null) {
                return NotFound();
            }

            UserToDelete = await _userManager.FindByIdAsync(id);

            if (UserToDelete == null) {
                return NotFound();
            }
            if (await _userManager.IsInRoleAsync(UserToDelete, "ADMIN")) {
                return BadRequest();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            UserToDelete = await _userManager.FindByIdAsync(id);

            if (UserToDelete != null) {
                await _userManager.DeleteAsync(UserToDelete);
            }

            return RedirectToPage("./Index");
        }
    }
}
