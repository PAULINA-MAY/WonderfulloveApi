using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

public partial class DetalleFigura
{
    [Key]
    public int ProductoId { get; set; }

    [StringLength(50)]
    public string Material { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string Acabado { get; set; } = null!;

    public bool EsFragil { get; set; }

    [StringLength(500)]
    public string? Cuidados { get; set; }

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
    [InverseProperty("DetalleFigura")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("DetalleFigura")]
    public virtual Productos Producto { get; set; } = null!;
}
