using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Categorias.Models;

public partial class CategoriasBaseContext : DbContext
{
    public CategoriasBaseContext()
    {
    }

    public CategoriasBaseContext(DbContextOptions<CategoriasBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0731006ABC");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
