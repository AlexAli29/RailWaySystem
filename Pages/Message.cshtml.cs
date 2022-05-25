using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace TrainTickets.Pages
{
    [AllowAnonymous]
    public class MessageModel : PageModel
    {
        public int OrderNumber { get; set; }
        public void OnGet()
        {
            OrderNumber = (int) TempData.Peek("OrderNumber");
        }
    }
}
