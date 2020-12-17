using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GE_DB
{
    public partial class GE_DBContext : DbContext
    {
        public virtual DbSet<EnergySource> EnergySources { get; set; }
        public virtual DbSet<Inverter> Inverters { get; set; }
        public virtual DbSet<Accumulator> Accumulators { get; set; }
        public virtual DbSet<Region> Regions { get; set; }

        protected string Connection_String { get; set; }

        public GE_DBContext(string Connection_String)
        {
            this.Connection_String = Connection_String;
            Database.EnsureCreated();
        }
        
        public GE_DBContext(DbContextOptions<GE_DBContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection_String);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnergySource>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Inverter>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Accumulator>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => new { e.Province_ID, e.InProvince_ID });
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
