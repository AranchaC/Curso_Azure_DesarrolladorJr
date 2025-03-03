using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi_Concesionario.Models;

public partial class ConcesionarioDbContext : DbContext
{
    private readonly ConcesionarioDbContext? context;
    public ConcesionarioDbContext(DbContextOptions<ConcesionarioDbContext> options) : base(options) { }

    public virtual DbSet<Concesionario> Concesionarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=tcp:almacen-db-server.database.windows.net,1433;Initial Catalog=AlmacenDB;Persist Security Info=False;User ID=administrador;Password=C.rso2025;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concesionario>(entity =>
        {
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                 .HasColumnType("REAL")
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
