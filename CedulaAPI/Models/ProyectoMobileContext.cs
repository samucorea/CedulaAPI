using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CedulaAPI.Models
{
    public partial class ProyectoMobileContext : DbContext
    {
        public ProyectoMobileContext()
        {
        }

        public ProyectoMobileContext(DbContextOptions<ProyectoMobileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cedula> Cedulas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cedula>(entity =>
            {
                entity.HasKey(e => e.NumeroCedula);

                entity.ToTable("Cedula");

                entity.Property(e => e.NumeroCedula)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("numeroCedula")
                    .IsFixedLength();

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(35)
                    .HasColumnName("estadoCivil");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("date")
                    .HasColumnName("fechaExpiracion");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.LugarNacimiento)
                    .HasMaxLength(35)
                    .HasColumnName("lugarNacimiento");

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(35)
                    .HasColumnName("nacionalidad");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(75)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.Ocupacion)
                    .HasMaxLength(35)
                    .HasColumnName("ocupacion");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sexo")
                    .IsFixedLength();

                entity.Property(e => e.TipoSangre)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("tipoSangre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
