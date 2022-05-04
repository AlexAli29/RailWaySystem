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

namespace TrainTickets.Pages.Trains
{
    public class DeleteModel : PageModel
    {
        private readonly TrainTickets.Data.TrainTicketsContext _context;

        public DeleteModel(TrainTickets.Data.TrainTicketsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Train = await _context.Train.FindAsync(id);

            if (Train != null)
            {
                _context.Train.Remove(Train);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
