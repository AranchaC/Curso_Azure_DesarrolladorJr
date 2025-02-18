using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppi_VentasCorporativas.Models;

public partial class VentasCorporativasDbContext : DbContext
{
    public VentasCorporativasDbContext()
    {
    }

    public VentasCorporativasDbContext(DbContextOptions<VentasCorporativasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Vendedore> Vendedores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog = VentasCorporativasDB; Integrated Security = true; Encrypt = true;\nTrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.ProductoId).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendedore>(entity =>
        {
            entity.HasKey(e => e.IdVendedor);

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Movil)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Clientes");

            entity.HasOne(d => d.ProductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Producto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Productos");

            entity.HasOne(d => d.VendedorNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Vendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Vendedores");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
