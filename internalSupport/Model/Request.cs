using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace internalSupport.Model
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public String Your_Email { get; set; }

        public String Subject { get; set; }

        public String Description { get; set; }

        public DateTime Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd}")]
        public DateTime? Updated { get; set; }

        public String pathFile { get; set; }

        public string Status { get; set; }

        public string Assigned { get; set; }

        public string pathFolder { get; set; }
    }
}
