#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainTickets.Data;
using TrainTickets.Models;

namespace TrainTickets.Pages.Coaches
{
    public class IndexModel : PageModel
    {
        private readonly TrainTickets.Data.TrainTicketsContext _context;

        public IndexModel(TrainTickets.Data.TrainTicketsContext context)
        {
            _context = context;
        }

        public IList<Coach> Coach { get;set; }

        public async Task OnGetAsync()
        {
            Coach = await _context.Coach
                .Include(c => c.Train).ToListAsync();
        }
    }
}
