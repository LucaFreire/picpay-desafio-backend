using System;
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

    public virtual DbSet<TypeUser> TypeUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LUCAFREIRE;Initial Catalog=picpay_desafio_backend;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__transact__85C600AF6A4C6ED9");

            entity.ToTable("transactions");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Payee).HasColumnName("payee");
            entity.Property(e => e.Payer).HasColumnName("payer");
            entity.Property(e => e.TransactionValue)
                .HasColumnType("money")
                .HasColumnName("transaction_value");

            entity.HasOne(d => d.PayeeNavigation).WithMany(p => p.TransactionPayeeNavigations)
                .HasForeignKey(d => d.Payee)
                .HasConstraintName("FK__transacti__payee__4D94879B");

            entity.HasOne(d => d.PayerNavigation).WithMany(p => p.TransactionPayerNavigations)
                .HasForeignKey(d => d.Payer)
                .HasConstraintName("FK__transacti__payer__4E88ABD4");
        });

        modelBuilder.Entity<TypeUser>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__type_use__2C000598711E3E6A");

            entity.ToTable("type_users");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370F7781CBC4");

            entity.ToTable("users");

            entity.HasIndex(e => e.CpfCnpj, "UQ__users__5A6A2947E57EB6E7").IsUnique();

            entity.HasIndex(e => e.UserEmail, "UQ__users__B0FBA212E9DE04F8").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Balance)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money")
                .HasColumnName("balance");
            entity.Property(e => e.CpfCnpj)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CPF_CNPJ");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.UserEmail)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserType).HasColumnName("user_type");

            entity.HasOne(d => d.UserTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserType)
                .HasConstraintName("FK__users__user_type__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
