using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wonderfullove.Models;

namespace Wonderfullove.Data;

public partial class WonderFulLoveContext : DbContext
{
    public WonderFulLoveContext()
    {
    }

    public WonderFulLoveContext(DbContextOptions<WonderFulLoveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aromas> Aromas { get; set; }

    public virtual DbSet<CarritoItems> CarritoItems { get; set; }

    public virtual DbSet<Carritos> Carritos { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<ComboItems> ComboItems { get; set; }

    public virtual DbSet<Cupones> Cupones { get; set; }

    public virtual DbSet<DetalleFigura> DetalleFigura { get; set; }

    public virtual DbSet<DetalleVela> DetalleVela { get; set; }

    public virtual DbSet<Direcciones> Direcciones { get; set; }

    public virtual DbSet<Envios> Envios { get; set; }

    public virtual DbSet<Estatus> Estatus { get; set; }

    public virtual DbSet<Inventario> Inventario { get; set; }

    public virtual DbSet<MovimientosInventario> MovimientosInventario { get; set; }

    public virtual DbSet<Pagos> Pagos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }

    public virtual DbSet<PedidoHistorialEstatus> PedidoHistorialEstatus { get; set; }

    public virtual DbSet<Pedidos> Pedidos { get; set; }

    public virtual DbSet<ProductoImagenes> ProductoImagenes { get; set; }

    public virtual DbSet<ProductoVariantes> ProductoVariantes { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Resenas> Resenas { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<VwCatalogo> VwCatalogo { get; set; }

    public virtual DbSet<VwStockCombos> VwStockCombos { get; set; }

    public virtual DbSet<VwUsuarios> VwUsuarios { get; set; }
    public virtual DbSet<VwProductoActivo> VwProductosActivos { get; set; }
    public virtual DbSet<VwProductoBaja> VwProductosBaja { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aromas>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Aromas_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Aromas_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Aromas_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Aromas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Aromas_Estatus");
        });

        modelBuilder.Entity<CarritoItems>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_CarritoItems_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_CarritoItems_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_CarritoItems_UsuarioAlta");

            entity.HasOne(d => d.Carrito).WithMany(p => p.CarritoItems).HasConstraintName("FK_CarritoItems_Carrito");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.CarritoItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoItems_Estatus");

            entity.HasOne(d => d.Variante).WithMany(p => p.CarritoItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoItems_Variante");
        });

        modelBuilder.Entity<Carritos>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Carritos_Estatus");
            entity.Property(e => e.EstatusCarrito).HasDefaultValue("ACTIVO", "DF_Carritos_EstatusCarrito");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Carritos_FechaAlta");
            entity.Property(e => e.TokenSesion).HasDefaultValueSql("(newid())", "DF_Carritos_Token");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Carritos_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Carritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carritos_Estatus");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Carritos).HasConstraintName("FK_Carritos_Usuario");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Categorias_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Categorias_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Categorias_UsuarioAlta");

            entity.HasOne(d => d.CategoriaPadre).WithMany(p => p.InverseCategoriaPadre).HasConstraintName("FK_Categorias_Padre");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Categorias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categorias_Estatus");
        });

        modelBuilder.Entity<ComboItems>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("TR_ComboItems_Validar"));

            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_ComboItems_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_ComboItems_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_ComboItems_UsuarioAlta");

            entity.HasOne(d => d.ComboProducto).WithMany(p => p.ComboItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComboItems_Combo");

            entity.HasOne(d => d.ComponenteVariante).WithMany(p => p.ComboItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComboItems_Componente");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.ComboItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComboItems_Estatus");
        });

        modelBuilder.Entity<Cupones>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Cupones_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Cupones_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Cupones_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Cupones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cupones_Estatus");
        });

        modelBuilder.Entity<DetalleFigura>(entity =>
        {
            entity.Property(e => e.ProductoId).ValueGeneratedNever();
            entity.Property(e => e.EsFragil).HasDefaultValue(true, "DF_DetalleFigura_Fragil");
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_DetalleFigura_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_DetalleFigura_FechaAlta");
            entity.Property(e => e.Material).HasDefaultValue("Yeso", "DF_DetalleFigura_Material");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_DetalleFigura_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.DetalleFigura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFigura_Estatus");

            entity.HasOne(d => d.Producto).WithOne(p => p.DetalleFigura).HasConstraintName("FK_DetalleFigura_Producto");
        });

        modelBuilder.Entity<DetalleVela>(entity =>
        {
            entity.Property(e => e.ProductoId).ValueGeneratedNever();
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_DetalleVela_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_DetalleVela_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_DetalleVela_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.DetalleVela)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVela_Estatus");

            entity.HasOne(d => d.Producto).WithOne(p => p.DetalleVela).HasConstraintName("FK_DetalleVela_Producto");
        });

        modelBuilder.Entity<Direcciones>(entity =>
        {
            entity.HasIndex(e => e.UsuarioId, "UX_Direcciones_Predeterminada")
                .IsUnique()
                .HasFilter("([EsPredeterminada]=(1) AND [Estatus]=(1))");

            entity.Property(e => e.CodigoPostal).IsFixedLength();
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Direcciones_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Direcciones_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Direcciones_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Direcciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Direcciones_Estatus");

            entity.HasOne(d => d.Usuario).WithOne(p => p.Direcciones).HasConstraintName("FK_Direcciones_Usuario");
        });

        modelBuilder.Entity<Envios>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Envios_Estatus");
            entity.Property(e => e.EstatusEnvio).HasDefaultValue("PREPARANDO", "DF_Envios_EstatusEnvio");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Envios_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Envios_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Envios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Envios_Estatus");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Envios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Envios_Pedido");
        });

        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.Property(e => e.EstatusId).ValueGeneratedNever();
            entity.Property(e => e.Estatus1).HasDefaultValue(1, "DF_Estatus_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Estatus_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Estatus_UsuarioAlta");

            entity.HasOne(d => d.Estatus1Navigation).WithMany(p => p.InverseEstatus1Navigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estatus_Estatus");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.Property(e => e.VarianteId).ValueGeneratedNever();
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Inventario_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Inventario_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Inventario_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Inventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Estatus");

            entity.HasOne(d => d.Variante).WithOne(p => p.Inventario).HasConstraintName("FK_Inventario_Variante");
        });

        modelBuilder.Entity<MovimientosInventario>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK_MovInventario");

            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_MovInv_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_MovInv_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_MovInv_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.MovimientosInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovInv_Estatus");

            entity.HasOne(d => d.Pedido).WithMany(p => p.MovimientosInventario).HasConstraintName("FK_MovInv_Pedido");

            entity.HasOne(d => d.Variante).WithMany(p => p.MovimientosInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovInv_Variante");
        });

        modelBuilder.Entity<Pagos>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Pagos_Estatus");
            entity.Property(e => e.EstatusPago).HasDefaultValue("PENDIENTE", "DF_Pagos_EstatusPago");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Pagos_FechaAlta");
            entity.Property(e => e.FechaPago).HasDefaultValueSql("(sysdatetime())", "DF_Pagos_Fecha");
            entity.Property(e => e.Moneda)
                .IsFixedLength()
                .HasDefaultValue("MXN", "DF_Pagos_Moneda");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Pagos_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Pagos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Estatus");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Pagos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Pedido");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_PedidoDetalle_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_PedidoDetalle_FechaAlta");
            entity.Property(e => e.Importe).HasComputedColumnSql("([Cantidad]*[PrecioUnitario]-[DescuentoLinea])", true);
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_PedidoDetalle_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.PedidoDetalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidoDetalle_Estatus");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoDetalle).HasConstraintName("FK_PedidoDetalle_Pedido");

            entity.HasOne(d => d.Variante).WithMany(p => p.PedidoDetalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidoDetalle_Variante");
        });

        modelBuilder.Entity<PedidoHistorialEstatus>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK_PedidoHistorial");

            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_PedidoHistorial_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_PedidoHistorial_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_PedidoHistorial_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.PedidoHistorialEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidoHistorial_Estatus");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoHistorialEstatus).HasConstraintName("FK_PedidoHistorial_Pedido");
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.Property(e => e.EnvioCp).IsFixedLength();
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Pedidos_Estatus");
            entity.Property(e => e.EstatusPedido).HasDefaultValue("PENDIENTE", "DF_Pedidos_EstatusPedido");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Pedidos_FechaAlta");
            entity.Property(e => e.FechaPedido).HasDefaultValueSql("(sysdatetime())", "DF_Pedidos_Fecha");
            entity.Property(e => e.Folio).HasComputedColumnSql("('PED-'+right('000000'+CONVERT([varchar](10),[PedidoId]),(6)))", true);
            entity.Property(e => e.Total).HasComputedColumnSql("((([Subtotal]-[Descuento])+[CostoEnvio])+[Impuestos])", true);
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Pedidos_UsuarioAlta");

            entity.HasOne(d => d.Cupon).WithMany(p => p.Pedidos).HasConstraintName("FK_Pedidos_Cupon");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Estatus");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Usuario");
        });

        modelBuilder.Entity<ProductoImagenes>(entity =>
        {
            entity.HasIndex(e => e.ProductoId, "UX_Imagenes_Principal")
                .IsUnique()
                .HasFilter("([EsPrincipal]=(1) AND [Estatus]=(1))");

            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Imagenes_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Imagenes_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Imagenes_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.ProductoImagenes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imagenes_Estatus");

            entity.HasOne(d => d.Producto).WithOne(p => p.ProductoImagenes).HasConstraintName("FK_Imagenes_Producto");

            entity.HasOne(d => d.Variante).WithMany(p => p.ProductoImagenes).HasConstraintName("FK_Imagenes_Variante");
        });

        modelBuilder.Entity<ProductoVariantes>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Variantes_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Variantes_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Variantes_UsuarioAlta");

            entity.HasOne(d => d.Aroma).WithMany(p => p.ProductoVariantes).HasConstraintName("FK_Variantes_Aroma");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.ProductoVariantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Variantes_Estatus");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductoVariantes).HasConstraintName("FK_Variantes_Producto");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Productos_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Productos_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Productos_UsuarioAlta");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Categoria");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Estatus");
        });

        modelBuilder.Entity<Resenas>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Resenas_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Resenas_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Resenas_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Resenas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resenas_Estatus");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Resenas).HasConstraintName("FK_Resenas_Pedido");

            entity.HasOne(d => d.Producto).WithMany(p => p.Resenas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resenas_Producto");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Resenas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resenas_Usuario");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.Property(e => e.RolId).ValueGeneratedNever();
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Roles_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Roles_FechaAlta");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Roles_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Roles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles_Estatus");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.Property(e => e.Estatus).HasDefaultValue(1, "DF_Usuarios_Estatus");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Usuarios_FechaAlta");
            entity.Property(e => e.RolId).HasDefaultValue(3, "DF_Usuarios_Rol");
            entity.Property(e => e.UsuarioAlta).HasDefaultValueSql("(suser_sname())", "DF_Usuarios_UsuarioAlta");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Estatus");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Rol");
        });

        modelBuilder.Entity<VwCatalogo>(entity =>
        {
            entity.ToView("vw_Catalogo");
        });

        modelBuilder.Entity<VwStockCombos>(entity =>
        {
            entity.ToView("vw_StockCombos");
        });

        modelBuilder.Entity<VwUsuarios>(entity =>
        {
            entity.ToView("vw_Usuarios");
        });

        modelBuilder.Entity<VwProductoActivo>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("VW_WF_ObtenerPorductos_AC");
        });

        modelBuilder.Entity<VwProductoBaja>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("VW_WF_ObtenerProductos_BA");
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
