using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[PrimaryKey("ComboProductoId", "ComponenteVarianteId")]
public partial class ComboItems
{
    [Key]
    public int ComboProductoId { get; set; }

    [Key]
    public int ComponenteVarianteId { get; set; }

    public short Cantidad { get; set; }

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

    [ForeignKey("ComboProductoId")]
    [InverseProperty("ComboItems")]
    public virtual Productos ComboProducto { get; set; } = null!;

    [ForeignKey("ComponenteVarianteId")]
    [InverseProperty("ComboItems")]
    public virtual ProductoVariantes ComponenteVariante { get; set; } = null!;

    [ForeignKey("Estatus")]
    [InverseProperty("ComboItems")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;
}
