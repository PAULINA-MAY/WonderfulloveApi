namespace Wonderfullove.Dto
{
    public class ProductoActivoDto
    {
        public int ProductoId { get; set; }
        public string TipoProducto { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? DescripcionCorta { get; set; }
        public bool EsPersonalizable { get; set; }
        public string? ImagenId { get; set; }
        public string? Url { get; set; }
        public string? Orden { get; set; }
        public DateTime FechaAlta { get; set; }
        public string? UsuarioAlta { get; set; }
        public int EstatusId { get; set; }
        public string Estatus { get; set; } = null!;
    }
}
