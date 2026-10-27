using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wonderfullove.Models;

[Index("UsuarioId", "ProductoId", Name = "UQ_Resenas_UsuarioProducto", IsUnique = true)]
public partial class Resenas
{
    [Key]
    public int ResenaId { get; set; }

    public int ProductoId { get; set; }

    public int UsuarioId { get; set; }

    public int? PedidoId { get; set; }

    public byte Calificacion { get; set; }

    [StringLength(1000)]
    public string? Comentario { get; set; }

    public bool Aprobada { get; set; }

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
    [InverseProperty("Resenas")]
    public virtual Estatus EstatusNavigation { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("Resenas")]
    public virtual Pedidos? Pedido { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("Resenas")]
    public virtual Productos Producto { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Resenas")]
    public virtual Usuarios Usuario { get; set; } = null!;
}
