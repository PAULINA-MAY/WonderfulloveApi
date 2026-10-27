using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Keyless]
public partial class VwUsuarios
{
    public int UsuarioId { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(120)]
    public string? Apellidos { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    public int RolId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string RolClave { get; set; } = null!;

    [StringLength(50)]
    public string Rol { get; set; } = null!;

    public int EsInvitado { get; set; }

    public bool AceptaMarketing { get; set; }

    [Precision(0)]
    public DateTime FechaRegistro { get; set; }
}
