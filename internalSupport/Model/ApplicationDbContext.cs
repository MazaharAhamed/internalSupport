using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internalSupport.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Request> Request { get; set; }

        public DbSet<TicketStatus> Status { get; set; }

        public DbSet<TicketAssigned> Assigned { get; set; }
        public DbSet<Support> Support { get; set; }

        public DbSet<Look> Look { get; set; }

        public DbSet<SupportAnalystt> SupportAnalystt { get; set; }
    }
}
