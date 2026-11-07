using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AcademyGraduationCeremonySupplyManagementSystem.Models;

public partial class AcademyGraduationPreparationDBContext : DbContext
{
    public AcademyGraduationPreparationDBContext()
    {
    }

    public AcademyGraduationPreparationDBContext(DbContextOptions<AcademyGraduationPreparationDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=AcademyGraduationPreparationDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0731BD8D25");

            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Offer__3214EC07DAEAADDB");

            entity.ToTable("Offer");

            entity.HasIndex(e => e.SupplierId, "UQ__Offer__4BE666B5F1AA8D50").IsUnique();

            entity.Property(e => e.OfferName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Offers)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Offer__CategoryI__5DCAEF64");

            entity.HasOne(d => d.Supplier).WithOne(p => p.Offer)
                .HasForeignKey<Offer>(d => d.SupplierId)
                .HasConstraintName("FK__Offer__SupplierI__5EBF139D");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07A94E0317");

            entity.ToTable("Supplier");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
