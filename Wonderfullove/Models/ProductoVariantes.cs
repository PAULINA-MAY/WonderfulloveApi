using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("ProductoId", Name = "IX_Variantes_Producto")]
[Index("Sku", Name = "UQ_Variantes_Sku", IsUnique = true)]
public partial class ProductoVariantes
{
    [Key]
    public int VarianteId { get; set; }

    public int ProductoId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string Sku { get; set; } = null!;

    [StringLength(100)]
    public string NombreVariante { get; set; } = null!;

    public int? AromaId { get; set; }

    [StringLength(50)]
    public string? Color { get; set; }

    [StringLength(30)]
    public string? Tamano { get; set; }

    [Column(TypeName = "decimal(6, 2)")]
    public decimal? AltoCm { get; set; }

    [Column(TypeName = "decimal(6, 2)")]
    public decimal? AnchoCm { get; set; }

    public int? PesoGramos { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PrecioComparacion { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Costo { get; set; }

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

    [ForeignKey("AromaId")]
    [InverseProperty("ProductoVariantes")]
    public virtual Aromas? Aroma { get; set; }

    [InverseProperty("Variante")]
    public virtual ICollection<CarritoItems> CarritoItems { get; set; } = new List<CarritoItems>();

    [InverseProperty("ComponenteVariante")]
    public virtual ICollection<ComboItems> ComboItems { get; set; } = new List<ComboItems>();

    [ForeignKey("Estatus")]
    [InverseProperty("ProductoVariantes")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [InverseProperty("Variante")]
    public virtual Inventario? Inventario { get; set; }

    [InverseProperty("Variante")]
    public virtual ICollection<MovimientosInventario> MovimientosInventario { get; set; } = new List<MovimientosInventario>();

    [InverseProperty("Variante")]
    public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; } = new List<PedidoDetalle>();

    [ForeignKey("ProductoId")]
    [InverseProperty("ProductoVariantes")]
    public virtual Productos Producto { get; set; } = null!;

    [InverseProperty("Variante")]
    public virtual ICollection<ProductoImagenes> ProductoImagenes { get; set; } = new List<ProductoImagenes>();
}
