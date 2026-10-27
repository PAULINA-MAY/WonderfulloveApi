using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("Clave", Name = "UQ_Estatus_Clave", IsUnique = true)]
public partial class Estatus
{
    [Key]
    public int EstatusId { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string Clave { get; set; } = null!;

    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string UsuarioAlta { get; set; } = null!;

    [Precision(0)]
    public DateTime FechaAlta { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UsuarioMod { get; set; }

    [Precision(0)]
    public DateTime? FechaMod { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UsuarioBaja { get; set; }

    [Precision(0)]
    public DateTime? FechaBaja { get; set; }

    [Column("Estatus")]
    public int Estatus1 { get; set; }

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Aromas> Aromas { get; set; } = new List<Aromas>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<CarritoItems> CarritoItems { get; set; } = new List<CarritoItems>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Carritos> Carritos { get; set; } = new List<Carritos>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Categorias> Categorias { get; set; } = new List<Categorias>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<ComboItems> ComboItems { get; set; } = new List<ComboItems>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Cupones> Cupones { get; set; } = new List<Cupones>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<DetalleFigura> DetalleFigura { get; set; } = new List<DetalleFigura>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<DetalleVela> DetalleVela { get; set; } = new List<DetalleVela>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Direcciones> Direcciones { get; set; } = new List<Direcciones>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Envios> Envios { get; set; } = new List<Envios>();

    [ForeignKey("Estatus1")]
    [InverseProperty("InverseEstatus1Navigation")]
    public virtual Estatus Estatus1Navigation { get; set; } = null!;

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();

    [InverseProperty("Estatus1Navigation")]
    public virtual ICollection<Estatus> InverseEstatus1Navigation { get; set; } = new List<Estatus>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<MovimientosInventario> MovimientosInventario { get; set; } = new List<MovimientosInventario>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Pagos> Pagos { get; set; } = new List<Pagos>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; } = new List<PedidoDetalle>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<PedidoHistorialEstatus> PedidoHistorialEstatus { get; set; } = new List<PedidoHistorialEstatus>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<ProductoImagenes> ProductoImagenes { get; set; } = new List<ProductoImagenes>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<ProductoVariantes> ProductoVariantes { get; set; } = new List<ProductoVariantes>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Roles> Roles { get; set; } = new List<Roles>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
