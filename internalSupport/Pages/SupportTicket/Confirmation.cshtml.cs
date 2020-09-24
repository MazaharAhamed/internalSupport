using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using internalSupport.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace internalSupport.Pages.SupportTicket
{
    public class ConfirmationModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ConfirmationModel(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Request Request { get; set; }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync(IFormFile filee)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Request.Created = DateTime.Now;
            Request.pathFile = ProcessUploadedFile(filee);
            Request.Status = "Pending";

            _db.Request.Add(Request);
            await _db.SaveChangesAsync();
            return RedirectToPage("./Confirmation");
        }

        private string ProcessUploadedFile(IFormFile filee)
        {
            string uniqueFileName = null;
            if (filee != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "files");
                //uniqueFileName = Guid.NewGuid().ToString() + "_" + filee.FileName;
                uniqueFileName = filee.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                Request.pathFolder = filePath;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    filee.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}