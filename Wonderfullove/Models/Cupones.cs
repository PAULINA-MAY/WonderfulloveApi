using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("Codigo", Name = "UQ_Cupones_Codigo", IsUnique = true)]
public partial class Cupones
{
    [Key]
    public int CuponId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string TipoDescuento { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Valor { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoMinimo { get; set; }

    public int? UsosMaximos { get; set; }

    public int UsosActuales { get; set; }

    [Precision(0)]
    public DateTime FechaInicio { get; set; }

    [Precision(0)]
    public DateTime? FechaFin { get; set; }

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
    [InverseProperty("Cupones")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [InverseProperty("Cupon")]
    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
}
