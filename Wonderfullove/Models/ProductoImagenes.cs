using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

public partial class ProductoImagenes
{
    [Key]
    public int ImagenId { get; set; }

    public int ProductoId { get; set; }

    public int? VarianteId { get; set; }

    [StringLength(500)]
    public string Url { get; set; } = null!;

    [StringLength(200)]
    public string? TextoAlt { get; set; }

    public short Orden { get; set; }

    public bool EsPrincipal { get; set; }

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
    [InverseProperty("ProductoImagenes")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("ProductoImagenes")]
    public virtual Productos Producto { get; set; } = null!;

    [ForeignKey("VarianteId")]
    [InverseProperty("ProductoImagenes")]
    public virtual ProductoVariantes? Variante { get; set; }
}
