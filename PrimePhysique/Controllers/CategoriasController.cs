using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimePhysique.Models; // Asegúrate de que este using apunte a tus modelos
using PrimePhysique.DTOs;  // ¡IMPORTANTE! Agrega este using para tus DTOs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimePhysique.Controllers
{
    [Route("api/[controller]")] // Define la ruta base para este controlador (ej. /api/categorias)
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor: Inyecta el AppDbContext.
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        // Obtiene todas las categorías, ahora devolviendo CategoriaDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategorias() // <-- Tipo de retorno cambiado a CategoriaDto
        {
            var categorias = await _context.Categorias.ToListAsync();

            // Mapea la lista de Categoria a una lista de CategoriaDto
            var categoriaDtos = categorias.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre
            }).ToList();

            return categoriaDtos; // Devuelve la lista de DTOs
        }

        // GET: api/Categorias/{id}
        // Obtiene una categoría específica por su ID, ahora devolviendo CategoriaDto
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetCategoria(int id) // <-- Tipo de retorno cambiado a CategoriaDto
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            // Mapea la Categoria encontrada a un CategoriaDto
            var categoriaDto = new CategoriaDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };

            return categoriaDto; // Devuelve el DTO
        }
    }
}