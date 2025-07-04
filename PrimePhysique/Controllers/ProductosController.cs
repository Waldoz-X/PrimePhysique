using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimePhysique.Models; // Tus modelos de Entity Framework Core
using PrimePhysique.DTOs; // ¡Asegúrate de que este using apunte a tus DTOs!
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimePhysique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        // Obtiene todos los productos, ahora devolviendo ProductoDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos() // <-- Cambiado a ProductoDto
        {
            var productos = await _context.Productos
                                          .Include(p => p.Categoria)
                                          .Include(p => p.Marca)
                                          .ToListAsync();

            // Mapea la lista de Producto a una lista de ProductoDto
            var productoDtos = productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                ImagenUrl = p.ImagenUrl,
                MarcaId = p.MarcaId,
                CategoriaId = p.CategoriaId,
                MarcaNombre = p.Marca?.Nombre, // Null-conditional operator para evitar NRE si Marca es null
                CategoriaNombre = p.Categoria?.Nombre, // Null-conditional operator para evitar NRE si Categoria es null
                TallaColorInfo = p.TallaColorInfo,
                Sabor = p.Sabor,
                Contenido = p.Contenido
            }).ToList();

            return productoDtos; // Devuelve la lista de DTOs
        }

        // GET: api/Productos/{id}
        // Obtiene un producto específico por su ID, devolviendo ProductoDto
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id) // <-- Cambiado a ProductoDto
        {
            var producto = await _context.Productos
                                         .Include(p => p.Categoria)
                                         .Include(p => p.Marca)
                                         .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            // Mapea el Producto a un ProductoDto
            var productoDto = new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                ImagenUrl = producto.ImagenUrl,
                MarcaId = producto.MarcaId,
                CategoriaId = producto.CategoriaId,
                MarcaNombre = producto.Marca?.Nombre,
                CategoriaNombre = producto.Categoria?.Nombre,
                TallaColorInfo = producto.TallaColorInfo,
                Sabor = producto.Sabor,
                Contenido = producto.Contenido
            };

            return productoDto; // Devuelve el DTO
        }

        // GET: api/Productos/buscar?nombre={textoBusqueda}
        // Busca productos por nombre, devolviendo ProductoDto
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> BuscarProductos([FromQuery] string nombre) // <-- Cambiado a ProductoDto
        {
            IQueryable<Producto> query = _context.Productos
                                                 .Include(p => p.Categoria)
                                                 .Include(p => p.Marca);

            if (!string.IsNullOrWhiteSpace(nombre)) // Usamos !string.IsNullOrWhiteSpace para manejar cadenas vacías o solo espacios
            {
                // Solución para el error de traducción de LINQ:
                // Convierte tanto el nombre del producto como el término de búsqueda a minúsculas
                // antes de usar Contains. Esto permite que Entity Framework Core lo traduzca a SQL.
                string lowerCaseSearchTerm = nombre.ToLower();
                query = query.Where(p => p.Nombre.ToLower().Contains(lowerCaseSearchTerm));
            }
            // else: Si el nombre está vacío, la consulta devuelve todos los productos (como ya manejas)

            var productos = await query.ToListAsync();

            // Mapea a DTOs
            var productoDtos = productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                ImagenUrl = p.ImagenUrl,
                MarcaId = p.MarcaId,
                CategoriaId = p.CategoriaId,
                MarcaNombre = p.Marca?.Nombre,
                CategoriaNombre = p.Categoria?.Nombre,
                TallaColorInfo = p.TallaColorInfo,
                Sabor = p.Sabor,
                Contenido = p.Contenido
            }).ToList();

            return productoDtos; // Devuelve la lista de DTOs
        }

        // GET: api/Productos/filtrar?categoriaId={idCategoria}&marcaId={idMarca}
        // Filtra productos por ID de categoría y/o ID de marca, devolviendo ProductoDto
        [HttpGet("filtrar")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> FiltrarProductos( // <-- Cambiado a ProductoDto
            [FromQuery] int? categoriaId,
            [FromQuery] int? marcaId)
        {
            var query = _context.Productos
                                 .Include(p => p.Categoria)
                                 .Include(p => p.Marca)
                                 .AsQueryable();

            if (categoriaId.HasValue && categoriaId.Value != 0) // Agrego .Value != 0 por si 0 significa "todos"
            {
                query = query.Where(p => p.CategoriaId == categoriaId.Value);
            }

            if (marcaId.HasValue && marcaId.Value != 0) // Agrego .Value != 0 por si 0 significa "todos"
            {
                query = query.Where(p => p.MarcaId == marcaId.Value);
            }

            var productos = await query.ToListAsync();

            // Mapea a DTOs
            var productoDtos = productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                ImagenUrl = p.ImagenUrl,
                MarcaId = p.MarcaId,
                CategoriaId = p.CategoriaId,
                MarcaNombre = p.Marca?.Nombre,
                CategoriaNombre = p.Categoria?.Nombre,
                TallaColorInfo = p.TallaColorInfo,
                Sabor = p.Sabor,
                Contenido = p.Contenido
            }).ToList();

            return productoDtos; // Devuelve la lista de DTOs
        }

        // POST: api/Productos
        // Crea un nuevo producto. El cliente envía un objeto Producto, pero respondemos con un ProductoDto
        [HttpPost]
        public async Task<ActionResult<ProductoDto>> PostProducto(Producto producto) // <-- Respuesta cambiada a ProductoDto
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            // Para devolver un DTO completo, debemos cargar las referencias que queremos incluir
            // Si no necesitas CategoriaNombre y MarcaNombre en la respuesta de un POST,
            // puedes omitir estas líneas y simplemente devolver un ProductoDto más simple.
            await _context.Entry(producto).Reference(p => p.Categoria).LoadAsync();
            await _context.Entry(producto).Reference(p => p.Marca).LoadAsync();

            var productoDto = new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                ImagenUrl = producto.ImagenUrl,
                MarcaId = producto.MarcaId,
                CategoriaId = producto.CategoriaId,
                MarcaNombre = producto.Marca?.Nombre,
                CategoriaNombre = producto.Categoria?.Nombre,
                TallaColorInfo = producto.TallaColorInfo,
                Sabor = producto.Sabor,
                Contenido = producto.Contenido
            };

            // Retorna 201 CreatedAtAction con la URL del nuevo recurso y el DTO
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, productoDto);
        }

        // PUT: api/Productos/{id}
        // Actualiza un producto existente. Recibe Producto, retorna NoContent.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Productos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
