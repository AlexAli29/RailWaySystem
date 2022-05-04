using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainTickets.Models;
using TrainTickets.Data;
using Microsoft.EntityFrameworkCore;

namespace TrainTickets.Pages {
    public class IndexModel : PageModel {
        private readonly TrainTicketsContext _context;

        public IndexModel(TrainTicketsContext context) {
            _context = context;
        }

        public IList<Station> Station { get; set; }

        public async Task OnGetAsync() {
            Station = await _context.Station.ToListAsync();
        }
    }
}