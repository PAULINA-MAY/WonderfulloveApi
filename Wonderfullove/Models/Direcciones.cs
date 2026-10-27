using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

public partial class Direcciones
{
    [Key]
    public int DireccionId { get; set; }

    public int UsuarioId { get; set; }

    [StringLength(50)]
    public string? Alias { get; set; }

    [StringLength(150)]
    public string NombreRecibe { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(150)]
    public string Calle { get; set; } = null!;

    [StringLength(20)]
    public string NumExterior { get; set; } = null!;

    [StringLength(20)]
    public string? NumInterior { get; set; }

    [StringLength(100)]
    public string Colonia { get; set; } = null!;

    [StringLength(100)]
    public string Ciudad { get; set; } = null!;

    [StringLength(100)]
    public string Estado { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string CodigoPostal { get; set; } = null!;

    [StringLength(300)]
    public string? Referencias { get; set; }

    public bool EsPredeterminada { get; set; }

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
    [InverseProperty("Direcciones")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Direcciones")]
    public virtual Usuarios Usuario { get; set; } = null!;
}
