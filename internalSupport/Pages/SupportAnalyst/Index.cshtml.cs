using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internalSupport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace internalSupport.Pages.SupportAnalyst
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IList<SupportAnalystt> SupportAnalystt { get; set; }
        public async Task OnGet()
        {
            SupportAnalystt = await _db.SupportAnalystt.ToListAsync();
            //Support sup = new Support();
            //return Partial("_SupportAnalystModelPartial", sup);
        }

        public IActionResult Edit()
        {
            return RedirectToPage("Edit");
        }

        public IActionResult Delete()
        {
            return RedirectToPage("Delete");
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (SupportAnalystt == null)
                {
                    _db.SupportAnalystt.Add((SupportAnalystt)SupportAnalystt);
                }
                else
                {
                    _db.SupportAnalystt.Update((SupportAnalystt)SupportAnalystt);
                }
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}