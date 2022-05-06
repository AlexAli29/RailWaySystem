using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrainTickets.Pages
{
    public class MessageModel : PageModel
    {
        public int OrderNumber { get; set; }
        public void OnGet()
        {
            OrderNumber = (int) TempData.Peek("OrderNumber");
        }
    }
}
