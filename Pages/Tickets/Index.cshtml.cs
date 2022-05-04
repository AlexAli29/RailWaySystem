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

namespace TrainTickets.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly TrainTickets.Data.TrainTicketsContext _context;

        public IndexModel(TrainTickets.Data.TrainTicketsContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; }

        public async Task OnGetAsync()
        {
            Ticket = await _context.Ticket
                .Include(t => t.DestTrainStation)
                .Include(t => t.OriginTrainStation).ToListAsync();
        }
    }
}
