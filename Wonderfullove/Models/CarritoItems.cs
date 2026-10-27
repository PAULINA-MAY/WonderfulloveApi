using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

public partial class CarritoItems
{
    [Key]
    public int CarritoItemId { get; set; }

    public int CarritoId { get; set; }

    public int VarianteId { get; set; }

    public short Cantidad { get; set; }

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

    [ForeignKey("CarritoId")]
    [InverseProperty("CarritoItems")]
    public virtual Carritos Carrito { get; set; } = null!;

    [ForeignKey("Estatus")]
    [InverseProperty("CarritoItems")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("VarianteId")]
    [InverseProperty("CarritoItems")]
    public virtual ProductoVariantes Variante { get; set; } = null!;
}
