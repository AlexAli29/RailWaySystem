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

namespace TrainTickets.Pages.Trains
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
            return Page();
        }

        [BindProperty]
        public Train Train { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Train.Add(Train);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
