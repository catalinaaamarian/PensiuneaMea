using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PensiuneaMea.Models;

namespace PensiuneaMea.Data
{
    public class PensiuneaMeaContext : DbContext
    {
        public PensiuneaMeaContext (DbContextOptions<PensiuneaMeaContext> options)
            : base(options)
        {
        }
 

        public DbSet<PensiuneaMea.Models.Pensiune> Pensiune { get; set; } = default!;
        public DbSet<PensiuneaMea.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<PensiuneaMea.Models.Category> Category { get; set; } = default!;
    }
}
