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
    public class DetailsModel : PageModel
    {
        private readonly TrainTickets.Data.TrainTicketsContext _context;

        public DetailsModel(TrainTickets.Data.TrainTicketsContext context)
        {
            _context = context;
        }

        public Coach Coach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coach = await _context.Coach
                .Include(c => c.Train).FirstOrDefaultAsync(m => m.ID == id);

            if (Coach == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
