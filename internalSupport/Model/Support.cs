using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace internalSupport.Model
{
    public class Support
    {
        [Key]
        public int SupportAnalystId { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }
    }
}
