using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

public partial class Envios
{
    [Key]
    public int EnvioId { get; set; }

    public int PedidoId { get; set; }

    [StringLength(50)]
    public string Paqueteria { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string? NumeroGuia { get; set; }

    [StringLength(400)]
    public string? UrlRastreo { get; set; }

    public int? PesoTotalGramos { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string EstatusEnvio { get; set; } = null!;

    [Precision(0)]
    public DateTime? FechaEnvio { get; set; }

    [Precision(0)]
    public DateTime? FechaEntrega { get; set; }

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
    [InverseProperty("Envios")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("Envios")]
    public virtual Pedidos Pedido { get; set; } = null!;
}
