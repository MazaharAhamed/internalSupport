using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internalSupport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace internalSupport.Pages.SupportTicket
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public PaginatedList<Request> Request { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public async Task OnGetAsync(int? PageIndex)
        {
            
            IQueryable<Request> RequestIQ = from s in _db.Request
                                                          select s;
            int pageSize = 10;
            Request = await PaginatedList<Request>.CreateAsync(
                RequestIQ, PageIndex ?? 1, pageSize);
        }
    }
}