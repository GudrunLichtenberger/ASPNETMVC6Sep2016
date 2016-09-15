namespace TheOldWebAPIService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Formula1Model : DbContext
    {
        public Formula1Model()
            : base("name=Formula1Model1")
        {
        }

        public virtual DbSet<Circuit> Circuits { get; set; }
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        public virtual DbSet<Racer> Racers { get; set; }
        public virtual DbSet<Race> Races { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Circuit>()
                .HasMany(e => e.Races)
                .WithRequired(e => e.Circuit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceResult>()
                .Property(e => e.Points)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Racer>()
                .HasMany(e => e.RaceResults)
                .WithRequired(e => e.Racer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Race>()
                .HasMany(e => e.RaceResults)
                .WithRequired(e => e.Race)
                .WillCascadeOnDelete(false);
        }
    }
}
