using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace minimal_api.Models;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog = VentasCorporativasDB; Integrated Security = true; Encrypt = true; TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
