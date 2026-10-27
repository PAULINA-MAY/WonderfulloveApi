using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("Nombre", Name = "UQ_Aromas_Nombre", IsUnique = true)]
public partial class Aromas
{
    [Key]
    public int AromaId { get; set; }

    [StringLength(80)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    public string? Familia { get; set; }

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
    [InverseProperty("Aromas")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [InverseProperty("Aroma")]
    public virtual ICollection<ProductoVariantes> ProductoVariantes { get; set; } = new List<ProductoVariantes>();
}
