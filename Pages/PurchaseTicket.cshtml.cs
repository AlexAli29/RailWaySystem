using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using TrainTickets.Models;
using TrainTickets.Data;
using TrainTickets.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace TrainTickets.Pages
{
    [AllowAnonymous]
    public class PurchaseTicketModel : PageModel {
        private readonly TrainTicketsContext _context;

        public PurchaseTicketModel(TrainTicketsContext context) {
            _context = context;
        }
        public StationsAndDateVM StationsAndDateVM { get; set; }
        public TrainVM TrainVM { get; set; }
        public Coach Coach { get; set; }
        public int PlaceNumber;
        public int OrderNumber { get; set; }
        public async Task OnGetAsync(int coachNumber, int placeNumber) {
            StationsAndDateVM = JsonConvert.DeserializeObject<StationsAndDateVM>((string)TempData.Peek("StationsAndDateVM"));
            TrainVM = JsonConvert.DeserializeObject<TrainVM>((string)TempData.Peek("TrainVM"));

            OrderNumber = new Random().Next(10000, 99999);

            Coach = await _context.Coach
                .FirstOrDefaultAsync(c => c.TrainID == TrainVM.ID && c.CoachNumber == coachNumber);
            PlaceNumber = placeNumber;

            // to be used in the below OnPostAsync method (fields are nulled OnPost since this object's lifecycle is handled
            // by ASP.NET Core)
            TempData["CoachID"] = Coach.ID;
            TempData["PlaceNumber"] = PlaceNumber;
            TempData["OrderNumber"] = OrderNumber;
        }

        public async Task<IActionResult> OnPostAsync(string firstName, string lastName) {
            int originTrainStationID = (int) TempData.Peek("OriginTrainStationID");
            int destTrainStationID = (int) TempData.Peek("DestTrainStationID");

            int coachID = (int)TempData.Peek("CoachID");
            int placeNumber = (int)TempData.Peek("PlaceNumber");
            Place place = await _context.Place.FirstOrDefaultAsync(p => p.CoachID == coachID && p.PlaceNumber == placeNumber);
            int placeID = place.ID;

            
            Ticket newTicket = new Ticket { Place = place, 
                OriginTrainStationID = originTrainStationID, DestTrainStationID = destTrainStationID,
                FirstName = firstName, LastName = lastName, 
                CreatedAt = DateTime.Now};
            _context.Add(newTicket);
            await _context.SaveChangesAsync();

            return Redirect("Message");
        }
    }
}
