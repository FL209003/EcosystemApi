using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection.Metadata;
using Domain.Params;

namespace AccessLogic.Repositories
{
    public class EcosystemContext : DbContext
    {
        public DbSet<Ecosystem> Ecosystems { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Conservation> Conservations { get; set; }
        public DbSet<Param> Limits { get; set; }

        public EcosystemContext(DbContextOptions<EcosystemContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Username).IsUnique(); });

            modelBuilder.Entity<Ecosystem>().OwnsOne(e => e.EcosystemName).HasIndex(n => n.Value).IsUnique();
            modelBuilder.Entity<Ecosystem>().OwnsOne(e => e.EcoDescription);
            modelBuilder.Entity<Ecosystem>().OwnsOne(e => e.GeoDetails);


            modelBuilder.Entity<Country>().OwnsOne(c => c.CountryName).HasIndex(n => n.Value).IsUnique();

            modelBuilder.Entity<Conservation>().OwnsOne(c => c.ConservationName).HasIndex(n => n.Value).IsUnique();

            modelBuilder.Entity<Species>().OwnsOne(s => s.SpeciesName).HasIndex(n => n.Value).IsUnique();
            modelBuilder.Entity<Species>().OwnsOne(e => e.SpeciesDescription);


            modelBuilder.Entity<Threat>().OwnsOne(t => t.ThreatName).HasIndex(n => n.Value).IsUnique();
            modelBuilder.Entity<Threat>().OwnsOne(e => e.ThreatDescription);

            modelBuilder.Entity<Species>()
                .HasOne(s => s.SpeciesConservation)
                .WithMany(c => c.ConservationSpecies)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Conservation>()
                .HasMany(c => c.ConservationSpecies)
                .WithOne(s => s.SpeciesConservation)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Ecosystem>()
                .HasOne(e => e.EcoConservation)
                .WithMany(c => c.ConservationEcosystems)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Conservation>()
                .HasMany(c => c.ConservationEcosystems)
                .WithOne(e => e.EcoConservation)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}