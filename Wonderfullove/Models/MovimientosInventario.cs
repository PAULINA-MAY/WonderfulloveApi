using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("VarianteId", "FechaAlta", Name = "IX_MovInv_Variante_Fecha")]
public partial class MovimientosInventario
{
    [Key]
    public long MovimientoId { get; set; }

    public int VarianteId { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string TipoMovimiento { get; set; } = null!;

    public int Cantidad { get; set; }

    public int? PedidoId { get; set; }

    [StringLength(300)]
    public string? Nota { get; set; }

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
    [InverseProperty("MovimientosInventario")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("MovimientosInventario")]
    public virtual Pedidos? Pedido { get; set; }

    [ForeignKey("VarianteId")]
    [InverseProperty("MovimientosInventario")]
    public virtual ProductoVariantes Variante { get; set; } = null!;
}
