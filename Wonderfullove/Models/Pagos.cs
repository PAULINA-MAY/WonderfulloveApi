using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("PedidoId", Name = "IX_Pagos_Pedido")]
public partial class Pagos
{
    [Key]
    public int PagoId { get; set; }

    public int PedidoId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Metodo { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? Pasarela { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ReferenciaExterna { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Monto { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string Moneda { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string EstatusPago { get; set; } = null!;

    [Precision(0)]
    public DateTime FechaPago { get; set; }

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
    [InverseProperty("Pagos")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("Pagos")]
    public virtual Pedidos Pedido { get; set; } = null!;
}
