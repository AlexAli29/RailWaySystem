#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainTickets.Data;
using TrainTickets.Models;

namespace TrainTickets.Pages.Places
{
    public class EditModel : PageModel
    {
        private readonly TrainTickets.Data.TrainTicketsContext _context;

        public EditModel(TrainTickets.Data.TrainTicketsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Place Place { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Place = await _context.Place
                .Include(p => p.Coach).FirstOrDefaultAsync(m => m.ID == id);

            if (Place == null)
            {
                return NotFound();
            }
           ViewData["CoachID"] = new SelectList(_context.Coach, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(Place.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlaceExists(int id)
        {
            return _context.Place.Any(e => e.ID == id);
        }
    }
}
