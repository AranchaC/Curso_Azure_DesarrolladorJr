using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppi_Almacenes.Models;

public partial class AlmacenDbContext : DbContext
{
    private readonly AlmacenDbContext? context;
    public AlmacenDbContext(DbContextOptions<AlmacenDbContext> options) : base(options) { }

    public virtual DbSet<Almacen> Almacenes { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=tcp:almacen-db-server.database.windows.net,1433;Initial Catalog=AlmacenDB;Persist Security Info=False;User ID=administrador;Password=C.rso2025;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
