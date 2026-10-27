using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

public partial class PedidoHistorialEstatus
{
    [Key]
    public int HistorialId { get; set; }

    public int PedidoId { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? EstatusPedidoAnterior { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string EstatusPedidoNuevo { get; set; } = null!;

    [StringLength(300)]
    public string? Comentario { get; set; }

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
    [InverseProperty("PedidoHistorialEstatus")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("PedidoHistorialEstatus")]
    public virtual Pedidos Pedido { get; set; } = null!;
}
