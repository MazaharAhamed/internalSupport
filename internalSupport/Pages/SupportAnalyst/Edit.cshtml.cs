using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internalSupport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace internalSupport.Pages.SupportAnalyst
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public SupportAnalystt SupportAnalystt { get; set; }
        public async Task OnGet(int id)
        {
            SupportAnalystt = await _db.SupportAnalystt.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            { 
            var SupportAnalysttFromDb = await _db.SupportAnalystt.FindAsync(SupportAnalystt.SupportAnalystId);
            SupportAnalysttFromDb.Name = SupportAnalystt.Name;
            SupportAnalysttFromDb.Email = SupportAnalystt.Email;

            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}