using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MPEGtest.Models
{
    public partial class mdipContext : DbContext
    {
        public mdipContext()
        {
        }

        public mdipContext(DbContextOptions<mdipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Mpeg> Mpegs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=mdip;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.ToTable("agent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");


                entity.HasMany(d => d.Mpegs)
                    .WithMany(p => p.Agents);

            });

            modelBuilder.Entity<Mpeg>(entity =>
            {
                entity.HasKey(e => new { e.Id });
                entity.ToTable("mpeg");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Concept)
                    .HasMaxLength(50)
                    .HasColumnName("concept");

                entity.Property(e => e.Evt)
                    .HasMaxLength(50)
                    .HasColumnName("evt");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .HasColumnName("place");

                entity.Property(e => e.Relation)
                    .HasMaxLength(50)
                    .HasColumnName("relation");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");

                

                
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
