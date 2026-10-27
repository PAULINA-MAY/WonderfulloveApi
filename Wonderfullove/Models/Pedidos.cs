using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("EstatusPedido", Name = "IX_Pedidos_EstatusPedido")]
[Index("UsuarioId", "FechaPedido", Name = "IX_Pedidos_Usuario", IsDescending = new[] { false, true })]
public partial class Pedidos
{
    [Key]
    public int PedidoId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Folio { get; set; }

    public int UsuarioId { get; set; }

    public int? CuponId { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string EstatusPedido { get; set; } = null!;

    [StringLength(150)]
    public string EnvioNombre { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? EnvioTelefono { get; set; }

    [StringLength(400)]
    public string EnvioDireccion { get; set; } = null!;

    [StringLength(100)]
    public string EnvioCiudad { get; set; } = null!;

    [StringLength(100)]
    public string EnvioEstado { get; set; } = null!;

    [Column("EnvioCP")]
    [StringLength(5)]
    [Unicode(false)]
    public string EnvioCp { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Descuento { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal CostoEnvio { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Impuestos { get; set; }

    [Column(TypeName = "decimal(13, 2)")]
    public decimal? Total { get; set; }

    public bool EsRegalo { get; set; }

    [StringLength(300)]
    public string? MensajeRegalo { get; set; }

    [StringLength(500)]
    public string? NotasCliente { get; set; }

    [Precision(0)]
    public DateTime FechaPedido { get; set; }

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

    public int Estatus { get; set; }

    [ForeignKey("CuponId")]
    [InverseProperty("Pedidos")]
    public virtual Cupones? Cupon { get; set; }

    [InverseProperty("Pedido")]
    public virtual ICollection<Envios> Envios { get; set; } = new List<Envios>();

    [ForeignKey("Estatus")]
    [InverseProperty("Pedidos")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [InverseProperty("Pedido")]
    public virtual ICollection<MovimientosInventario> MovimientosInventario { get; set; } = new List<MovimientosInventario>();

    [InverseProperty("Pedido")]
    public virtual ICollection<Pagos> Pagos { get; set; } = new List<Pagos>();

    [InverseProperty("Pedido")]
    public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; } = new List<PedidoDetalle>();

    [InverseProperty("Pedido")]
    public virtual ICollection<PedidoHistorialEstatus> PedidoHistorialEstatus { get; set; } = new List<PedidoHistorialEstatus>();

    [InverseProperty("Pedido")]
    public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();

    [ForeignKey("UsuarioId")]
    [InverseProperty("Pedidos")]
    public virtual Usuarios Usuario { get; set; } = null!;
}
