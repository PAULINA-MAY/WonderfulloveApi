using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

public partial class DetalleVela
{
    [Key]
    public int ProductoId { get; set; }

    [StringLength(50)]
    public string TipoCera { get; set; } = null!;

    [StringLength(50)]
    public string? TipoMecha { get; set; }

    [StringLength(80)]
    public string? Recipiente { get; set; }

    public short? DuracionHoras { get; set; }

    [StringLength(500)]
    public string? Instrucciones { get; set; }

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
    [InverseProperty("DetalleVela")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("DetalleVela")]
    public virtual Productos Producto { get; set; } = null!;
}
