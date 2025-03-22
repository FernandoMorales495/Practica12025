using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Medidas.Models;

public partial class MedidasContext : DbContext
{
    public MedidasContext()
    {
    }

    public MedidasContext(DbContextOptions<MedidasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UnidadesDeMedidum> UnidadesDeMedida { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UnidadesDeMedidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Unidades__3214EC07E32BDAC6");

            entity.Property(e => e.Abreviatura).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
