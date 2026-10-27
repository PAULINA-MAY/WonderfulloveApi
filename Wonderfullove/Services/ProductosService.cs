using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wonderfullove.Data;
using Wonderfullove.Dto;
using Wonderfullove.Models;

namespace Wonderfullove.Services
{
    public class ProductosService: InterfaceProducto
    {
        //Servicios

        private const int ESTATUS_ACTIVO = 1;
        private const int ESTATUS_BAJA = 2;

        private readonly WonderFulLoveContext _context;

        public ProductosService(WonderFulLoveContext context)
        {
            _context = context;
        }

        // Proyección reutilizable: EF la traduce a SQL y solo trae estas columnas
        private static readonly Expression<Func<Productos, ProductoDto>> ADto = p => new ProductoDto
        {
            ProductoId = p.ProductoId,
            CategoriaId = p.CategoriaId,
            TipoProducto = p.TipoProducto,
            Nombre = p.Nombre,
            Slug = p.Slug,
            DescripcionCorta = p.DescripcionCorta,
            Descripcion = p.Descripcion,
            EsPersonalizable = p.EsPersonalizable,
            Destacado = p.Destacado,
            Estatus = p.Estatus,
            FechaAlta = p.FechaAlta
        };

        private IQueryable<Productos> Activos() =>
            _context.Productos.AsNoTracking().Where(p => p.Estatus == ESTATUS_ACTIVO);

        public async Task<List<ProductoDto>> ObtenerTodosAsync()
        {
            return await Activos()
                .OrderBy(p => p.Nombre)
                .Select(ADto)
                .ToListAsync();
        }

        //public async Task<List<ProductoDto>> ObtenerPorCategoriaAsync(int categoriaId)
        //{
        //    return await Activos()
        //        .Where(p => p.CategoriaId == categoriaId)
        //        .OrderBy(p => p.Nombre)
        //        .Select(ADto)
        //        .ToListAsync();
        //}

        public async Task<List<ProductoActivoDto>> ObtenerActivosVistaAsync()
        {
            return await _context.VwProductosActivos
                .AsNoTracking()
                .OrderBy(v => v.Nombre)
                .ThenBy(v => v.Orden)
                .Select(v => new ProductoActivoDto
                {
                    ProductoId = v.ProductoId,
                    TipoProducto = v.TipoProducto,
                    Nombre = v.Nombre,
                    CategoriaId = v.CategoriaId,
                    NombreCategoria = v.NombreCategoria,
                    Slug = v.Slug,
                    DescripcionCorta = v.DescripcionCorta,
                    EsPersonalizable = v.EsPersonalizable,
                    ImagenId = v.ImagenId,
                    Url = v.Url,
                    Orden = v.Orden,
                    FechaAlta = v.FechaAlta,
                    UsuarioAlta = v.UsuarioAlta,
                    EstatusId = v.EstatusId,
                    Estatus = v.Estatus
                })
                .ToListAsync();
        }

        public async Task<List<ProductoBajaDto>> ObtenerBajasVistaAsync()
        {
            return await _context.VwProductosBaja
                .AsNoTracking()
                .OrderByDescending(v => v.FechaBaja)
                .Select(v => new ProductoBajaDto
                {
                    ProductoId = v.ProductoId,
                    TipoProducto = v.TipoProducto,
                    Nombre = v.Nombre,
                    CategoriaId = v.CategoriaId,
                    NombreCategoria = v.NombreCategoria,
                    Slug = v.Slug,
                    DescripcionCorta = v.DescripcionCorta,
                    EsPersonalizable = v.EsPersonalizable,
                    ImagenId = v.ImagenId,
                    Url = v.Url,
                    Orden = v.Orden,
                    FechaBaja = v.FechaBaja,
                    UsuarioBaja = v.UsuarioBaja,
                    EstatusId = v.EstatusId,
                    Estatus = v.Estatus
                })
                .ToListAsync();
        }

        public async Task<List<ProductoCategoriaSpDto>> ObtenerPorCategoriaSpAsync(int categoriaId)
        {
            // SqlQuery parametriza automáticamente el valor interpolado (no hay SQL injection)
            return await _context.Database
                .SqlQuery<ProductoCategoriaSpDto>(
                    $"EXEC SP_WF_ObtenerProductoByCategoria @CategoriaId = {categoriaId}")
                .ToListAsync();
        }

        public async Task<ProductoDto?> ObtenerPorIdAsync(int id)
        {
            return await Activos()
                .Where(p => p.ProductoId == id)
                .Select(ADto)
                .FirstOrDefaultAsync();
        }

        public async Task<ProductoDto?> ObtenerPorSlugAsync(string slug)
        {
            var slugNormalizado = slug.Trim().ToLower();

            return await Activos()
                .Where(p => p.Slug == slugNormalizado)
                .Select(ADto)
                .FirstOrDefaultAsync();
        }



        public async Task<List<ProductoDto>> ObtenerDestacadosAsync()
        {
            return await Activos()
                .Where(p => p.Destacado)
                .OrderBy(p => p.Nombre)
                .Select(ADto)
                .ToListAsync();
        }

        public async Task<ProductoDto> CrearAsync(ProductoGuardarDto dto, string usuario)
        {
            await ValidarAsync(dto, idExcluir: null);

            var producto = new Productos
            {
                CategoriaId = dto.CategoriaId,
                TipoProducto = dto.TipoProducto.Trim(),
                Nombre = dto.Nombre.Trim(),
                Slug = dto.Slug.Trim().ToLower(),
                DescripcionCorta = dto.DescripcionCorta,
                Descripcion = dto.Descripcion,
                EsPersonalizable = dto.EsPersonalizable,
                Destacado = dto.Destacado,
                UsuarioAlta = usuario,
                FechaAlta = DateTime.Now,
                Estatus = ESTATUS_ACTIVO
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return (await ObtenerPorIdAsync(producto.ProductoId))!;
        }

        public async Task<bool> ActualizarAsync(int id, ProductoGuardarDto dto, string usuario)
        {
            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.ProductoId == id && p.Estatus == ESTATUS_ACTIVO);

            if (producto == null) return false;

            await ValidarAsync(dto, idExcluir: id);

            producto.CategoriaId = dto.CategoriaId;
            producto.TipoProducto = dto.TipoProducto.Trim();
            producto.Nombre = dto.Nombre.Trim();
            producto.Slug = dto.Slug.Trim().ToLower();
            producto.DescripcionCorta = dto.DescripcionCorta;
            producto.Descripcion = dto.Descripcion;
            producto.EsPersonalizable = dto.EsPersonalizable;
            producto.Destacado = dto.Destacado;
            producto.UsuarioMod = usuario;
            producto.FechaMod = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        // Borrado lógico: no se elimina el registro, solo cambia el estatus
        public async Task<bool> EliminarAsync(int id, string usuario)
        {
            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.ProductoId == id && p.Estatus == ESTATUS_ACTIVO);

            if (producto == null) return false;

            producto.Estatus = ESTATUS_BAJA;
            producto.UsuarioBaja = usuario;
            producto.FechaBaja = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task ValidarAsync(ProductoGuardarDto dto, int? idExcluir)
        {
            var categoriaExiste = await _context.Categorias
                .AnyAsync(c => c.CategoriaId == dto.CategoriaId);

            if (!categoriaExiste)
                throw new InvalidOperationException("La categoría no existe.");

            var slug = dto.Slug.Trim().ToLower();

            var slugOcupado = await _context.Productos
                .AnyAsync(p => p.Slug == slug && p.ProductoId != idExcluir);

            if (slugOcupado)
                throw new InvalidOperationException("Ya existe un producto con ese slug.");
        }


    }
}
