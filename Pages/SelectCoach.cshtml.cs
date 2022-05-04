using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainTickets.Models;
using TrainTickets.Data;
using Microsoft.EntityFrameworkCore;

namespace TrainTickets.Pages
{
    public class SelectCoachModel : PageModel {
        private readonly TrainTicketsContext _context;
        public SelectCoachModel(TrainTicketsContext context) {
            _context = context;
        }

        public IList<Coach> PlatzcartCoaches { get; set; }
        public IList<Coach> KupeCoaches { get; set; }

        [FromQuery]
        public int TrainID { get; set; }
        [FromQuery]
        public string OriginStation { get; set; }
        [FromQuery]
        public string DestStation { get; set; }
        [FromQuery]
        public string DepartureDate { get; set; }

        // TrainVM info
        [FromQuery]
        public string TrainName { get; set; }
        [FromQuery]
        public string TrainFirstStation { get; set; }
        [FromQuery]
        public string TrainLastStation { get; set; }


        public async Task OnGetAsync() {
            Train train = await _context.Train
                .Include(t => t.Coaches)
                    .ThenInclude(c => c.Places)
                .FirstOrDefaultAsync();
            
        }
    }
}
