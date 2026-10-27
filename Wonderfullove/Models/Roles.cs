using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("Clave", Name = "UQ_Roles_Clave", IsUnique = true)]
public partial class Roles
{
    [Key]
    public int RolId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Clave { get; set; } = null!;

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(200)]
    public string? Descripcion { get; set; }

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
    [InverseProperty("Roles")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [InverseProperty("Rol")]
    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
