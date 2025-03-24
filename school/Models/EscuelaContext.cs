using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace school.Models;

public partial class EscuelaContext : DbContext
{
    public EscuelaContext()
    {
    }

    public EscuelaContext(DbContextOptions<EscuelaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC27B8C55CFB");

            entity.ToTable("Estudiante");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaInscripcion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Promedio).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
