using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("Slug", Name = "UQ_Categorias_Slug", IsUnique = true)]
public partial class Categorias
{
    [Key]
    public int CategoriaId { get; set; }

    public int? CategoriaPadreId { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(120)]
    [Unicode(false)]
    public string Slug { get; set; } = null!;

    [StringLength(500)]
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

    [ForeignKey("CategoriaPadreId")]
    [InverseProperty("InverseCategoriaPadre")]
    public virtual Categorias? CategoriaPadre { get; set; }

    [ForeignKey("Estatus")]
    [InverseProperty("Categorias")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [InverseProperty("CategoriaPadre")]
    public virtual ICollection<Categorias> InverseCategoriaPadre { get; set; } = new List<Categorias>();

    [InverseProperty("Categoria")]
    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
