using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal_Repository.models;

public partial class ProjectDbContext : DbContext
{
    public ProjectDbContext()
    {
    }

    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shopping> Shoppings { get; set; }

    public virtual DbSet<SoppingDetail> SoppingDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L9S4R74;Database=ProjectDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Category");

            entity.Property(e => e.NameCategory).HasMaxLength(50);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.NameCompany).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.NameProduct).HasMaxLength(50);
            entity.Property(e => e.Picture).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("date");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Categories");

            entity.HasOne(d => d.Company).WithMany(p => p.Products)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Companies");
        });

        modelBuilder.Entity<Shopping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Soppings");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Remark).HasMaxLength(500);

            entity.HasOne(d => d.Customer).WithMany(p => p.Shoppings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Soppings_Customers");
        });

        modelBuilder.Entity<SoppingDetail>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.SoppingDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoppingDetails_Product");

            entity.HasOne(d => d.Sopping).WithMany(p => p.SoppingDetails)
                .HasForeignKey(d => d.SoppingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoppingDetails_Shoppings");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
