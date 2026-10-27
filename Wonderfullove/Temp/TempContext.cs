using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Temp;

public partial class TempContext : DbContext
{
    public TempContext(DbContextOptions<TempContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VwWfObtenerPorductosAc> VwWfObtenerPorductosAcs { get; set; }

    public virtual DbSet<VwWfObtenerProductosBa> VwWfObtenerProductosBas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VwWfObtenerPorductosAc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_WF_ObtenerPorductos_AC");

            entity.Property(e => e.DescripcionCorta).HasMaxLength(300);
            entity.Property(e => e.Estatus)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasPrecision(0);
            entity.Property(e => e.ImagenId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.NombreCategoria).HasMaxLength(100);
            entity.Property(e => e.Orden)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(170)
                .IsUnicode(false);
            entity.Property(e => e.TipoProducto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Url).HasMaxLength(500);
            entity.Property(e => e.UsuarioAlta)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwWfObtenerProductosBa>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_WF_ObtenerProductos_BA");

            entity.Property(e => e.DescripcionCorta).HasMaxLength(300);
            entity.Property(e => e.Estatus)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.FechaBaja).HasPrecision(0);
            entity.Property(e => e.ImagenId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.NombreCategoria).HasMaxLength(100);
            entity.Property(e => e.Orden)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(170)
                .IsUnicode(false);
            entity.Property(e => e.TipoProducto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Url).HasMaxLength(500);
            entity.Property(e => e.UsuarioBaja)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
