#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainTickets.Data;
using TrainTickets.Models;

namespace TrainTickets.Pages.Places
{
    public class CreateModel : PageModel
    {
        private readonly TrainTickets.Data.TrainTicketsContext _context;

        public CreateModel(TrainTickets.Data.TrainTicketsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CoachID"] = new SelectList(_context.Coach, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Place Place { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Place.Add(Place);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
