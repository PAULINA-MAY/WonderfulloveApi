using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

public partial class Inventario
{
    [Key]
    public int VarianteId { get; set; }

    public int Stock { get; set; }

    public int StockMinimo { get; set; }

    public bool HechoBajoPedido { get; set; }

    public short? DiasFabricacion { get; set; }

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
    [InverseProperty("Inventario")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("VarianteId")]
    [InverseProperty("Inventario")]
    public virtual ProductoVariantes Variante { get; set; } = null!;
}
