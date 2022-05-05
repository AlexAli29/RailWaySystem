using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainTickets.Models;
using TrainTickets.Data;
using Microsoft.EntityFrameworkCore;

using TrainTickets.Models.ViewModels;
using Newtonsoft.Json;

namespace TrainTickets.Pages
{
    public class SelectCoachModel : PageModel {
        private readonly TrainTicketsContext _context;
        public SelectCoachModel(TrainTicketsContext context) {
            _context = context;
        }

        public StationsAndDateVM StationsAndDateVM { get; set; }
        public TrainVM TrainVM { get; set; }

        public IList<Coach> PlatzcartCoaches { get; set; }
        public IList<Coach> KupeCoaches { get; set; }

        public async Task OnGetAsync(int trainID, string trainName, string trainFirstStation, string trainLastStation,
                string trainDepartDate, string trainDepartTime, string trainArrivalDate, string trainArrivalTime,
                string trainTripDuration, int trainMinPriceTenge) {

            StationsAndDateVM = JsonConvert.DeserializeObject<StationsAndDateVM>((string)TempData.Peek("StationsAndDateVM"));

            TrainVM = new TrainVM {ID = trainID, Name = trainName, FirstStation = trainFirstStation, LastStation = trainLastStation,
                    DepartDate = DateOnly.Parse(trainDepartDate), DepartTime = TimeOnly.Parse(trainDepartTime), 
                    ArrivalDate = DateOnly.Parse(trainArrivalDate), ArrivalTime = TimeOnly.Parse(trainArrivalTime),
                    TripDuration = trainTripDuration, MinPriceTenge = trainMinPriceTenge};
            TempData["TrainVM"] = JsonConvert.SerializeObject(TrainVM);

            Train train = await _context.Train
                .Include(t => t.Coaches)
                    .ThenInclude(c => c.Places)
                .FirstOrDefaultAsync(t => t.ID == trainID);

            PlatzcartCoaches = train.Coaches.Where(c => c.Type.Equals("Platzcart")).ToList();
            KupeCoaches = train.Coaches.Where(c => c.Type.Equals("Kupe")).ToList();
        }
    }
}
