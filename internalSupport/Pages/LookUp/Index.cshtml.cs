using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internalSupport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace internalSupport.Pages.LookUp
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Look> Look { get; set; }
        public async Task OnGet()
        {
            Look = await _db.Look.ToListAsync();
        }
    }
}