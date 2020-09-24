using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace internalSupport.Model
{
    public class TicketAssigned
    {
        [Key]
        public int Id { get; set; }

        public string AssignedTo { get; set; }
    }
}
