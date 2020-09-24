using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using internalSupport.Model;

namespace internalSupport.Pages.SupportTicket
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public EditModel(ApplicationDbContext db)
        {
            _db=db;
        }

        [BindProperty]
        public Request Requestt { get; set; }
        public Request Requests { get; set; }
        public List<TicketAssigned> TicketAssigned { get; set; }
        public List<TicketStatus> TicketStatus { get; set; }
        
        public string Attachment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Requestt = await _db.Request.FirstOrDefaultAsync(m => m.Id == id);
            Attachment = Requestt.pathFile;


            TicketAssigned = await _db.Assigned.ToListAsync();
            var ticket1 = new SelectList(TicketAssigned, "AssignedTo", "AssignedTo");
            ViewData["AssignedList"] = ticket1;

            TicketStatus = await _db.Status.ToListAsync();
            var ticket2 = new SelectList(TicketStatus, "Status", "Status");
            ViewData["StatusList"] = ticket2;

            if (Request == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Requestt.Updated = DateTime.Now;

            Requestt.Assigned = Request.Form["AssignedData"].ToString();
            Requestt.Status = Request.Form["StatusData"].ToString();

            _db.Attach(Requestt).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(Requestt.Id))
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

        private bool RequestExists(int id)
        {
            return _db.Request.Any(e => e.Id == id);
        }
    }
}
