using System.ComponentModel.DataAnnotations;

namespace Wonderfullove.Dto
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public string TipoProducto { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? DescripcionCorta { get; set; }
        public string? Descripcion { get; set; }
        public bool EsPersonalizable { get; set; }
        public bool Destacado { get; set; }
        public int Estatus { get; set; }
        public DateTime FechaAlta { get; set; }
    }

    // Lo que recibe la API para crear o actualizar
    public class ProductoGuardarDto
    {
        [Required]
        public int CategoriaId { get; set; }

        [Required, StringLength(10)]
        public string TipoProducto { get; set; } = null!;

        [Required, StringLength(150)]
        public string Nombre { get; set; } = null!;

        [Required, StringLength(170)]
        public string Slug { get; set; } = null!;

        [StringLength(300)]
        public string? DescripcionCorta { get; set; }

        public string? Descripcion { get; set; }

        public bool EsPersonalizable { get; set; }

        public bool Destacado { get; set; }
    }
}
