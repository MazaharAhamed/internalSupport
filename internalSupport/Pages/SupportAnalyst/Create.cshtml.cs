using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internalSupport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace internalSupport.Pages.SupportAnalyst
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public SupportAnalystt SupportAnalystt { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.SupportAnalystt.Add(SupportAnalystt);
            await _db.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}