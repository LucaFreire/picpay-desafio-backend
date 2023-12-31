﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace picpay_desafio_backend.Model;

public partial class PicpayDesafioBackendContext : DbContext
{
    public PicpayDesafioBackendContext()
    {
    }

    public PicpayDesafioBackendContext(DbContextOptions<PicpayDesafioBackendContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LUCAFREIRE;Initial Catalog=picpay_desafio_backend;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__transact__85C600AF05BB4E3C");

            entity.ToTable("transactions");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Payee).HasColumnName("payee");
            entity.Property(e => e.Payer).HasColumnName("payer");
            entity.Property(e => e.TransactionValue)
                .HasColumnType("money")
                .HasColumnName("transaction_value");

            entity.HasOne(d => d.PayeeNavigation).WithMany(p => p.TransactionPayeeNavigations)
                .HasForeignKey(d => d.Payee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__transacti__payee__5165187F");

            entity.HasOne(d => d.PayerNavigation).WithMany(p => p.TransactionPayerNavigations)
                .HasForeignKey(d => d.Payer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__transacti__payer__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FEF63504B");

            entity.ToTable("users");

            entity.HasIndex(e => e.Document, "UQ__users__1D810B12258C394C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164273ABB5F").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Balance)
                .HasColumnType("money")
                .HasColumnName("balance");
            entity.Property(e => e.Document)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("document");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.UserType).HasColumnName("user_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
