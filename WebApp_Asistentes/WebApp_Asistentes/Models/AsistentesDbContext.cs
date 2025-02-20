using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp_Asistentes.Models;

public partial class AsistentesDbContext : DbContext
{
    public AsistentesDbContext()
    {
    }

    public AsistentesDbContext(DbContextOptions<AsistentesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistente> Asistentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:asistentes-server.database.windows.net,1433;Initial Catalog=AsistentesDB;Persist Security Info=False;User ID=administrador;Password=Pa$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistente>(entity =>
        {
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
