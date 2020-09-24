using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internalSupport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace internalSupport.Pages
{
    public class ViewModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ViewModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public IList<Request> Request { get; set; }
        public async Task OnGetAsync()
        {
            Request = await _db.Request.ToListAsync();
        }

    }
}
