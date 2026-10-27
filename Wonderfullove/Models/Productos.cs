using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("CategoriaId", Name = "IX_Productos_Categoria")]
[Index("Slug", Name = "UQ_Productos_Slug", IsUnique = true)]
public partial class Productos
{
    [Key]
    public int ProductoId { get; set; }

    public int CategoriaId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string TipoProducto { get; set; } = null!;

    [StringLength(150)]
    public string Nombre { get; set; } = null!;

    [StringLength(170)]
    [Unicode(false)]
    public string Slug { get; set; } = null!;

    [StringLength(300)]
    public string? DescripcionCorta { get; set; }

    public string? Descripcion { get; set; }

    public bool EsPersonalizable { get; set; }

    public bool Destacado { get; set; }

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

    [ForeignKey("CategoriaId")]
    [InverseProperty("Productos")]
    public virtual Categorias Categoria { get; set; } = null!;

    [InverseProperty("ComboProducto")]
    public virtual ICollection<ComboItems> ComboItems { get; set; } = new List<ComboItems>();

    [InverseProperty("Producto")]
    public virtual DetalleFigura? DetalleFigura { get; set; }

    [InverseProperty("Producto")]
    public virtual DetalleVela? DetalleVela { get; set; }

    [ForeignKey("Estatus")]
    [InverseProperty("Productos")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [InverseProperty("Producto")]
    public virtual ProductoImagenes? ProductoImagenes { get; set; }

    [InverseProperty("Producto")]
    public virtual ICollection<ProductoVariantes> ProductoVariantes { get; set; } = new List<ProductoVariantes>();

    [InverseProperty("Producto")]
    public virtual ICollection<Resenas> Resenas { get; set; } = new List<Resenas>();
}
