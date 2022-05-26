#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainTickets.Data;
using TrainTickets.Models;

namespace TrainTickets.Pages.Trains
{
    [Authorize(Roles = "ADMIN")]
    public class DetailsModel : PageModel
    {
        private readonly TrainTickets.Data.TrainTicketsContext _context;

        public DetailsModel(TrainTickets.Data.TrainTicketsContext context)
        {
            _context = context;
        }

        public Train Train { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Train = await _context.Train.FirstOrDefaultAsync(m => m.ID == id);

            if (Train == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
