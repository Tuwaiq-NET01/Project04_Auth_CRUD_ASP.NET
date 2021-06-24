using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Web.Models;

#nullable disable

namespace Web.Data
{
    public partial class VulnDbContext : DbContext
    {
        public VulnDbContext()
        {
        }

        public VulnDbContext(DbContextOptions<VulnDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CNA> CNAs { get; set; }
        public virtual DbSet<CPE> CPEs { get; set; }
        public virtual DbSet<CWE> CWEs { get; set; }
        public virtual DbSet<CVE> CVEs { get; set; }
        public virtual DbSet<CveCpeJunction> CveCpeJunctions { get; set; }
        public virtual DbSet<CveCweJunction> CveCweJunctions { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<ReferenceTagJunction> ReferenceTagJunctions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=testing_db;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CNA>(entity =>
            {
                entity.Property(e => e.Email).IsFixedLength(true);

                entity.Property(e => e.Name).IsFixedLength(true);
            });

            modelBuilder.Entity<CPE>(entity =>
            {
                entity.Property(e => e.id).IsFixedLength(true);

                entity.Property(e => e.vector).IsUnicode(false);
            });

            modelBuilder.Entity<CWE>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Abstraction)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CVE>(entity =>
            {
                entity.HasKey(e => new { e.Year, e.Id });

                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.CNANavigation)
                    .WithMany(p => p.Cves)
                    .HasForeignKey(d => d.CNA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CVEs_CNAs");
            });

            modelBuilder.Entity<CveCpeJunction>(entity =>
            {
                entity.HasKey(e => new { e.CPEId, e.CVEId, e.CVEYear });

                entity.Property(e => e.CPEId).IsFixedLength(true);

                entity.Property(e => e.CVEId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CPE)
                    .WithMany(p => p.CveCpeJunctions)
                    .HasForeignKey(d => d.CPEId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CveCpeJunction_CPEs");

                entity.HasOne(d => d.CVE)
                    .WithMany(p => p.CveCpeJunctions)
                    .HasForeignKey(d => new { d.CVEYear, d.CVEId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CveCpeJunction_CVEs");
            });

            modelBuilder.Entity<CveCweJunction>(entity =>
            {
                entity.Property(e => e.CVEId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CWE)
                    .WithMany(p => p.CveCweJunctions)
                    .HasForeignKey(d => d.CWEId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CveCweJunction_CWEs");

                entity.HasOne(d => d.CVE)
                    .WithMany(p => p.CveCweJunctions)
                    .HasForeignKey(d => new { d.CVEYear, d.CVEId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CveCweJunction_CVEs");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.Property(e => e.CVEId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.URL).IsUnicode(false);

                entity.HasOne(d => d.CVE)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => new { d.CVEYear, d.CVEId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_References_CVEs");
            });

            modelBuilder.Entity<ReferenceTagJunction>(entity =>
            {
                entity.HasKey(e => new { e.ReferenceId, e.TagId })
                    .HasName("PK_ReferenceTagJunction_1");

                entity.HasOne(d => d.Reference)
                    .WithMany(p => p.ReferenceTagJunctions)
                    .HasForeignKey(d => d.ReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReferenceTagJunction_References");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ReferenceTagJunctions)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReferenceTagJunction_Tags");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
