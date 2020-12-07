using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GE_BD
{
    public partial class GE_BDContext : DbContext
    {
        public virtual DbSet<EnergySource> EnergySources { get; set; }
        //public virtual DbSet<Inverter> Inverters { get; set; }
        //public virtual DbSet<Accumulator> Accumulators { get; set; }
        //public virtual DbSet<Region> Regions { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        public GE_BDContext()
        {
            Database.EnsureCreated();
        }

        public GE_BDContext(DbContextOptions<GE_BDContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GE_BD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnergySource>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
