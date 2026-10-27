using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("TokenSesion", Name = "IX_Carritos_Token")]
[Index("UsuarioId", Name = "IX_Carritos_Usuario")]
public partial class Carritos
{
    [Key]
    public int CarritoId { get; set; }

    public int? UsuarioId { get; set; }

    public Guid TokenSesion { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string EstatusCarrito { get; set; } = null!;

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

    [InverseProperty("Carrito")]
    public virtual ICollection<CarritoItems> CarritoItems { get; set; } = new List<CarritoItems>();

    [ForeignKey("Estatus")]
    [InverseProperty("Carritos")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Carritos")]
    public virtual Usuarios? Usuario { get; set; }
}
