using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wonderfullove.Dto;
using Wonderfullove.Services;
using static Wonderfullove.Dto.Respuesta;

namespace Wonderfullove.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly InterfaceProducto _productos;

        public ProductosController(InterfaceProducto productos)
        {
            _productos = productos;
        }

        // Temporal: cuando tengas autenticación, saldrá del token
        private string UsuarioActual => User.Identity?.Name ?? "sistema";

        // GET: api/productos
        [HttpGet]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoDto>>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var productos = await _productos.ObtenerTodosAsync();

                if (productos.Count == 0)
                {
                    return NotFound(new RespuestaDto<List<ProductoDto>>
                    {
                        Estatus = StatusCodes.Status404NotFound,
                        Mensaje = "No se encontraron productos.",
                        Data = new List<ProductoDto>()
                    });
                }

                return Ok(new RespuestaDto<List<ProductoDto>>
                {
                    Estatus = StatusCodes.Status200OK,
                    Mensaje = "Productos obtenidos.",
                    Data = productos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaDto<List<ProductoDto>>
                {
                    Estatus = StatusCodes.Status500InternalServerError,
                    Mensaje = $"Error al obtener los productos: {ex.Message}",
                    Data = new List<ProductoDto>()
                });
            }
        }


        // GET: api/productos/activos
        [HttpGet("activos")]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoActivoDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoActivoDto>>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoActivoDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerActivos()
        {
            try
            {
                var productos = await _productos.ObtenerActivosVistaAsync();

                if (productos.Count == 0)
                {
                    return NotFound(new RespuestaDto<List<ProductoActivoDto>>
                    {
                        Estatus = StatusCodes.Status404NotFound,
                        Mensaje = "No se encontraron productos activos.",
                        Data = new List<ProductoActivoDto>()
                    });
                }

                return Ok(new RespuestaDto<List<ProductoActivoDto>>
                {
                    Estatus = StatusCodes.Status200OK,
                    Mensaje = "Productos obtenidos.",
                    Data = productos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaDto<List<ProductoActivoDto>>
                {
                    Estatus = StatusCodes.Status500InternalServerError,
                    Mensaje = $"Error al obtener los productos: {ex.Message}",
                    Data = new List<ProductoActivoDto>()
                });
            }
        }

        // GET: api/productos/baja
        [HttpGet("baja")]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoBajaDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoBajaDto>>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoBajaDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerBajas()
        {
            try
            {
                var productos = await _productos.ObtenerBajasVistaAsync();

                if (productos.Count == 0)
                {
                    return NotFound(new RespuestaDto<List<ProductoBajaDto>>
                    {
                        Estatus = StatusCodes.Status404NotFound,
                        Mensaje = "No se encontraron productos dados de baja.",
                        Data = new List<ProductoBajaDto>()
                    });
                }

                return Ok(new RespuestaDto<List<ProductoBajaDto>>
                {
                    Estatus = StatusCodes.Status200OK,
                    Mensaje = "Productos obtenidos.",
                    Data = productos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaDto<List<ProductoBajaDto>>
                {
                    Estatus = StatusCodes.Status500InternalServerError,
                    Mensaje = $"Error al obtener los productos dados de baja: {ex.Message}",
                    Data = new List<ProductoBajaDto>()
                });
            }
        }

        // GET: api/productos/categoria/3
        [HttpGet("categoria/{categoriaId:int}")]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoCategoriaSpDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoCategoriaSpDto>>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoCategoriaSpDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerPorCategoriaSp(int categoriaId)
        {
            try
            {
                var productos = await _productos.ObtenerPorCategoriaSpAsync(categoriaId);

                if (productos.Count == 0)
                {
                    return NotFound(new RespuestaDto<List<ProductoCategoriaSpDto>>
                    {
                        Estatus = StatusCodes.Status404NotFound,
                        Mensaje = $"No se encontraron productos para la categoría {categoriaId}.",
                        Data = new List<ProductoCategoriaSpDto>()
                    });
                }

                return Ok(new RespuestaDto<List<ProductoCategoriaSpDto>>
                {
                    Estatus = StatusCodes.Status200OK,
                    Mensaje = "Productos obtenidos.",
                    Data = productos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaDto<List<ProductoCategoriaSpDto>>
                {
                    Estatus = StatusCodes.Status500InternalServerError,
                    Mensaje = $"Error al obtener los productos de la categoría: {ex.Message}",
                    Data = new List<ProductoCategoriaSpDto>()
                });
            }
        }



        // GET: api/productos/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var producto = await _productos.ObtenerPorIdAsync(id);

            if (producto == null)
                return NotFound(new { mensaje = "Producto no encontrado." });

            return Ok(producto);
        }
        // GET: api/productos/slug/vela-aromatica
        [HttpGet("slug/{slug}")]
        [ProducesResponseType(typeof(RespuestaDto<ProductoDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaDto<ProductoDto?>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RespuestaDto<ProductoDto?>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerPorSlug(string slug)
        {
            try
            {
                var producto = await _productos.ObtenerPorSlugAsync(slug);

                if (producto == null)
                {
                    return NotFound(new RespuestaDto<ProductoDto?>
                    {
                        Estatus = StatusCodes.Status404NotFound,
                        Mensaje = $"No se encontró un producto con el slug '{slug}'.",
                        Data = null
                    });
                }

                return Ok(new RespuestaDto<ProductoDto?>
                {
                    Estatus = StatusCodes.Status200OK,
                    Mensaje = "Producto obtenido.",
                    Data = producto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaDto<ProductoDto?>
                {
                    Estatus = StatusCodes.Status500InternalServerError,
                    Mensaje = $"Error al obtener el producto: {ex.Message}",
                    Data = null
                });
            }
        }

        // GET: api/productos/categoria/3
        //[HttpGet("categoria/{categoriaId:int}")]
        //[ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> ObtenerPorCategoria(int categoriaId)
        //{
        //    var productos = await _productos.ObtenerPorCategoriaAsync(categoriaId);
        //    return Ok(productos);
        //}

        // GET: api/productos/destacados
        [HttpGet("destacados")]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoDto>>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RespuestaDto<List<ProductoDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerDestacados()
        {
            try
            {
                var productos = await _productos.ObtenerDestacadosAsync();

                if (productos.Count == 0)
                {
                    return NotFound(new RespuestaDto<List<ProductoDto>>
                    {
                        Estatus = StatusCodes.Status404NotFound,
                        Mensaje = "No se encontraron productos destacados.",
                        Data = new List<ProductoDto>()
                    });
                }

                return Ok(new RespuestaDto<List<ProductoDto>>
                {
                    Estatus = StatusCodes.Status200OK,
                    Mensaje = "Productos destacados obtenidos.",
                    Data = productos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaDto<List<ProductoDto>>
                {
                    Estatus = StatusCodes.Status500InternalServerError,
                    Mensaje = $"Error al obtener los productos destacados: {ex.Message}",
                    Data = new List<ProductoDto>()
                });
            }
        }

        // POST: api/productos
        [HttpPost]
        [ProducesResponseType(typeof(ProductoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] ProductoGuardarDto dto)
        {
            try
            {
                var producto = await _productos.CrearAsync(dto, UsuarioActual);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.ProductoId }, producto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT: api/productos/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ProductoGuardarDto dto)
        {
            try
            {
                var actualizado = await _productos.ActualizarAsync(id, dto, UsuarioActual);

                if (!actualizado)
                    return NotFound(new { mensaje = "Producto no encontrado." });

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE: api/productos/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _productos.EliminarAsync(id, UsuarioActual);

            if (!eliminado)
                return NotFound(new { mensaje = "Producto no encontrado." });

            return NoContent();
        }
    }
}
