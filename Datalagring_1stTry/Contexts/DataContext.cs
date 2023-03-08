using System;
using System.Collections.Generic;
using Datalagring_1stTry.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Datalagring_1stTry.Contexts;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jespe\\Desktop\\Santa_Datalagring\\Datalagring_1stTry\\Datalagring_1stTry\\Contexts\\sql_db.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC0787F0CE3F");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StreetName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC070E1379EC");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D1053415D105C4").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customers__Addre__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
