using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace internalSupport.Model
{
    public class Look
    {
        [Key]
        public int Id { get; set; }

        public String Description { get; set; }
    }
}
