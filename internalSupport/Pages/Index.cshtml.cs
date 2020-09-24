using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using internalSupport.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace internalSupport.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;

        public IndexModel(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public IFormFile filee { get; set; }

        [BindProperty]
        public Request Request { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public void OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //Request.Created = DateTime.Now;
            //Request.Updated = null;

            //Request.pathFile = ProcessUploadedFile();

            //_db.Request.Add(Request);
            //await _db.SaveChangesAsync();
            //return RedirectToPage("./View");

        }

        //private string ProcessUploadedFile()
        //{
        //    string uniqueFileName = null;
        //    if (filee != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "files");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + filee.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            filee.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}

    }
}
