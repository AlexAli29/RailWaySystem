using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using TrainTickets.Models;
using TrainTickets.Data;
using TrainTickets.Models.ViewModels;
using Newtonsoft.Json;

namespace TrainTickets.Pages
{
    public class PurchaseTicketModel : PageModel {
        private readonly TrainTicketsContext _context;

        public PurchaseTicketModel(TrainTicketsContext context) {
            _context = context;
        }
        public StationsAndDateVM StationsAndDateVM { get; set; }
        public TrainVM TrainVM { get; set; }
        public Coach Coach { get; set; }
        public int PlaceNumber;
        public async Task OnGetAsync(int coachNumber, int placeNumber) {
            StationsAndDateVM = JsonConvert.DeserializeObject<StationsAndDateVM>((string)TempData.Peek("StationsAndDateVM"));
            TrainVM = JsonConvert.DeserializeObject<TrainVM>((string)TempData.Peek("TrainVM"));

            Coach = await _context.Coach
                .FirstOrDefaultAsync(c => c.TrainID == TrainVM.ID && c.CoachNumber == coachNumber);
            PlaceNumber = placeNumber;
        }
    }
}
