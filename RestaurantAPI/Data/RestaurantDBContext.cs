using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Data;

public partial class RestaurantDBContext : DbContext
{
    public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB7D590BD8AD");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__4849DA01E69E9F53").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__AB6E61643074F324").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__Foods__77EAEA39779A2466");

            entity.Property(e => e.FoodId).HasColumnName("foodId");
            entity.Property(e => e.FoodName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("foodName");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__9B57CF727D52CF14");

            entity.Property(e => e.TransactionId).HasColumnName("transactionId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.FoodId).HasColumnName("foodId");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.TransactionDate).HasColumnName("transactionDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__custo__3D5E1FD2");

            entity.HasOne(d => d.Food).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__foodI__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
