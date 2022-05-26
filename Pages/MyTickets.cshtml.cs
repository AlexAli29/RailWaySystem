using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainTickets.Models;
using TrainTickets.Data;
using TrainTickets.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Web;
using TrainTickets.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace TrainTickets.Pages
{
    public class MyTicketsModel : PageModel
    {
        private readonly TrainTicketsContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyTicketsModel(TrainTicketsContext context, UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;
        }
        public IList<TicketVM> TicketVM { get; set; } = new List<TicketVM>();

        public async Task OnGetAsync() {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null) {
                throw new Exception("Currently logged in user is null");
            }
            IList<Ticket> tickets = await _context.Ticket
                .Include(t => t.OriginTrainStation)
                    .ThenInclude(ts => ts.Train)
                .Include(t => t.OriginTrainStation)
                    .ThenInclude(ots => ots.Station)
                .Include(t => t.DestTrainStation)
                    .ThenInclude(dts => dts.Station)
                .Include(t => t.Place)
                    .ThenInclude(p => p.Coach)
                .OrderByDescending(t => t.ID)
                .ToListAsync();



            for (int i = 0; i < tickets.Count; i++) {
                Ticket ticket = tickets[i];
                DateTime departAt = ticket.OriginTrainStation.DepartureAt;
                DateTime arrivalAt = ticket.DestTrainStation.ArrivalAt;
                TimeSpan tripTimespan = arrivalAt - departAt;
                TicketVM.Add(new TicketVM {
                    TicketOrdinal = tickets.Count - i,
                    CreatedAt = ticket.CreatedAt,
                    TrainName = ticket.OriginTrainStation.Train.Name, // could be DestTrainStations as well, no difference
                    OriginStation = ticket.OriginTrainStation.Station.Name,
                    DestStation = ticket.DestTrainStation.Station.Name,
                    DepartDatetime = departAt,
                    ArrivalDatetime = arrivalAt,
                    TripDuration = ToReadableString(tripTimespan),
                    CoachNumber = ticket.Place.Coach.CoachNumber,
                    PlaceNumber = ticket.Place.PlaceNumber,
                    CoachType = ticket.Place.Coach.Type,
                    PriceTenge = ticket.Place.Coach.PriceTenge
                });
            }
        }

        private string ToReadableString(TimeSpan span) {
            return string.Format("{0}{1}{2}",
                        span.Duration().Days > 0 ? string.Format("{0:0}d ", span.Days) : string.Empty,
                        span.Duration().Hours > 0 ? string.Format("{0:0}h ", span.Hours) : string.Empty,
                        span.Duration().Minutes > 0 ? string.Format("{0:0}m ", span.Minutes) : string.Empty);
        }
    }
}
