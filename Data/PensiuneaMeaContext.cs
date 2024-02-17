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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurarea relației auto-referențiale în Publisher
            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.ChildPublishers) // Un Publisher poate avea mai mulți copii
                .WithOne(p => p.ParentPublisher) // Fiecare copil are un singur părinte
                .HasForeignKey(p => p.ParentPublisherID) // Cheia străină este ParentPublisherID
                .OnDelete(DeleteBehavior.Restrict); // Prevenirea ștergerii în cascada
        }


        public DbSet<PensiuneaMea.Models.Pensiune> Pensiune { get; set; } = default!;
        public DbSet<PensiuneaMea.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<PensiuneaMea.Models.Category> Category { get; set; } = default!;
    }
}
