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

namespace TrainTickets.Pages.Coaches
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
        ViewData["TrainID"] = new SelectList(_context.Train, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Coach Coach { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Coach.Add(Coach);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
