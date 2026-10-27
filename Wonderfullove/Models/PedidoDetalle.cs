using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("PedidoId", Name = "IX_PedidoDetalle_Pedido")]
public partial class PedidoDetalle
{
    [Key]
    public int PedidoDetalleId { get; set; }

    public int PedidoId { get; set; }

    public int VarianteId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string Sku { get; set; } = null!;

    [StringLength(260)]
    public string NombreProducto { get; set; } = null!;

    public short Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal DescuentoLinea { get; set; }

    [Column(TypeName = "decimal(17, 2)")]
    public decimal? Importe { get; set; }

    [StringLength(200)]
    public string? TextoPersonalizacion { get; set; }

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

    [ForeignKey("Estatus")]
    [InverseProperty("PedidoDetalle")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("PedidoDetalle")]
    public virtual Pedidos Pedido { get; set; } = null!;

    [ForeignKey("VarianteId")]
    [InverseProperty("PedidoDetalle")]
    public virtual ProductoVariantes Variante { get; set; } = null!;
}
