using Wonderfullove.Dto;

namespace Wonderfullove.Services
{
    public interface InterfaceProducto
    {
        //Metodos


        // Existentes
        Task<List<ProductoDto>> ObtenerTodosAsync();
        Task<ProductoDto?> ObtenerPorIdAsync(int id);
        Task<ProductoDto?> ObtenerPorSlugAsync(string slug);
        //Task<List<ProductoDto>> ObtenerPorCategoriaAsync(int categoriaId);
        Task<List<ProductoDto>> ObtenerDestacadosAsync();
        Task<ProductoDto> CrearAsync(ProductoGuardarDto dto, string usuario);
        Task<bool> ActualizarAsync(int id, ProductoGuardarDto dto, string usuario);
        Task<bool> EliminarAsync(int id, string usuario);

        // Nuevos (vistas y SP)
        Task<List<ProductoActivoDto>> ObtenerActivosVistaAsync();
        Task<List<ProductoBajaDto>> ObtenerBajasVistaAsync();
        Task<List<ProductoCategoriaSpDto>> ObtenerPorCategoriaSpAsync(int categoriaId);
    }



}

