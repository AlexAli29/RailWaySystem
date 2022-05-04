using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainTickets.Models;
using TrainTickets.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using TrainTickets.Models.ViewModels;

namespace TrainTickets.Pages
{
    public class SelectTrainModel : PageModel
    {
        private readonly TrainTicketsContext _context;

        public SelectTrainModel(TrainTicketsContext context) {
            _context = context;
        }

        public IList<TrainVM> TrainVM { get; set; } = new List<TrainVM>();
        [FromQuery]
        public string OriginStation { get; set; }
        [FromQuery]
        public string DestStation { get; set; }
        [FromQuery]
        public string DepartureDate { get; set; }

        public async Task OnGetAsync(string originStation, string destStation, string departureDate) {
            DateTime departDatetime = DateTime.ParseExact(departureDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            IList<Train> trains = await _context.Train
                .Include(t => t.TrainStations)
                    .ThenInclude(ts => ts.Station)
                .Include(t => t.Coaches)
                .ToListAsync();

            foreach (Train train in trains) {
                TrainStation originTS = null;
                TrainStation destTS = null;
                bool departDateMatches = false;
                foreach (TrainStation ts in train.TrainStations.ToList()) {
                    if (ts.Station.Name.Equals(originStation)) {
                        originTS = ts;
                    }
                    if (originTS != null && ts.Station.Name.Equals(destStation)) {
                        destTS = ts;
                    }
                    if (ts.DepartureAt.Date.Equals(departDatetime.Date)) {
                        departDateMatches = true;
                    }
                }
                if (originTS != null && destTS != null && departDateMatches) {
                    TimeSpan tripTimespan = destTS.ArrivalAt - originTS.DepartureAt;
                    TrainVM.Add(new Models.ViewModels.TrainVM {
                        ID = train.ID,
                        Name = train.Name,
                        FirstStation = train.TrainStations.First().Station.Name,
                        LastStation = train.TrainStations.Last().Station.Name,
                        DepartDate = DateOnly.FromDateTime(originTS.DepartureAt),
                        DepartTime = TimeOnly.FromDateTime(originTS.DepartureAt),
                        ArrivalDate = DateOnly.FromDateTime(destTS.ArrivalAt),
                        ArrivalTime = TimeOnly.FromDateTime(destTS.ArrivalAt),
                        TripDuration = ToReadableString(tripTimespan),
                        MinPriceTenge = MinPriceAmongCoaches(train.Coaches.ToList())
                    });
                }
            }
        }

        private int MinPriceAmongCoaches(IList<Coach> coaches) {
            int minPrice = coaches.First().PriceTenge;
            foreach (var coach in coaches) {
                if (coach.PriceTenge < minPrice) {
                    minPrice = coach.PriceTenge;
                }
            }
            return minPrice;
        }

        private string ToReadableString(TimeSpan span) {
            return string.Format("{0}{1}{2}",
                        span.Duration().Days > 0 ? string.Format("{0:0}d ", span.Days) : string.Empty,
                        span.Duration().Hours > 0 ? string.Format("{0:0}h ", span.Hours) : string.Empty,
                        span.Duration().Minutes > 0 ? string.Format("{0:0}m ", span.Minutes) : string.Empty);
        }
    }
}
