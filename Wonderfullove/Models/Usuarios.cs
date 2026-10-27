using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("RolId", Name = "IX_Usuarios_Rol")]
[Index("Email", Name = "UQ_Usuarios_Email", IsUnique = true)]
public partial class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }

    public int RolId { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(120)]
    public string? Apellidos { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? PasswordHash { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    public bool AceptaMarketing { get; set; }

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

    [InverseProperty("Usuario")]
    public virtual ICollection<Carritos> Carritos { get; set; } = new List<Carritos>();

    [InverseProperty("Usuario")]
    public virtual Direcciones? Direcciones { get; set; }

    [ForeignKey("Estatus")]
    [InverseProperty("Usuarios")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [InverseProperty("Usuario")]
    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Roles Rol { get; set; } = null!;
}
