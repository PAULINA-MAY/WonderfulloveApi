using System;
using System.Collections.Generic;

namespace Wonderfullove.Temp;

public partial class VwWfObtenerProductosBa
{
    public int ProductoId { get; set; }

    public string TipoProducto { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? DescripcionCorta { get; set; }

    public bool EsPersonalizable { get; set; }

    public string ImagenId { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Orden { get; set; } = null!;

    public DateTime? FechaBaja { get; set; }

    public string? UsuarioBaja { get; set; }

    public int EstatusId { get; set; }

    public string Estatus { get; set; } = null!;
}
