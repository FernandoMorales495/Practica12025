using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Registro.Models;

public partial class RegistroAcademicoBaseContext : DbContext
{
    public RegistroAcademicoBaseContext()
    {
    }

    public RegistroAcademicoBaseContext(DbContextOptions<RegistroAcademicoBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Docente> Docentes { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PK__Docentes__64A8726E8C684834");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Docentes__531402F3DBA694F8").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TituloAcademico)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
