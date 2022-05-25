using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainTickets.Models;
using TrainTickets.Data;
using Microsoft.EntityFrameworkCore;

using TrainTickets.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace TrainTickets.Pages
{
    [AllowAnonymous]
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
                string trainDepartDatetime, string trainArrivalDatetime,
                string trainTripDuration, int trainMinPriceTenge) {

            StationsAndDateVM = JsonConvert.DeserializeObject<StationsAndDateVM>((string)TempData.Peek("StationsAndDateVM"));

            TrainVM = new TrainVM {ID = trainID, Name = trainName, FirstStation = trainFirstStation, LastStation = trainLastStation,
                    DepartDatetime = DateTime.Parse(trainDepartDatetime), ArrivalDatetime = DateTime.Parse(trainArrivalDatetime),
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
