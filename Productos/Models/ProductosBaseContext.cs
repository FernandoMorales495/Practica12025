using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Productos.Models;

public partial class ProductosBaseContext : DbContext
{
    public ProductosBaseContext()
    {
    }

    public ProductosBaseContext(DbContextOptions<ProductosBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC071E77E794");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
