using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Keyless]
public partial class VwCatalogo
{
    public int ProductoId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string TipoProducto { get; set; } = null!;

    [StringLength(150)]
    public string Nombre { get; set; } = null!;

    [StringLength(170)]
    [Unicode(false)]
    public string Slug { get; set; } = null!;

    [StringLength(100)]
    public string Categoria { get; set; } = null!;

    public int VarianteId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string Sku { get; set; } = null!;

    [StringLength(100)]
    public string NombreVariante { get; set; } = null!;

    [StringLength(80)]
    public string? Aroma { get; set; }

    [StringLength(50)]
    public string? Color { get; set; }

    [StringLength(30)]
    public string? Tamano { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PrecioComparacion { get; set; }

    public int StockDisponible { get; set; }

    public bool HechoBajoPedido { get; set; }

    [StringLength(500)]
    public string? ImagenPrincipal { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? CalificacionPromedio { get; set; }

    public int TotalResenas { get; set; }
}
