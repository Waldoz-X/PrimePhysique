using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimePhysique.DTOs;
using PrimePhysique.Models; // Asegúrate de que este using apunte a tus modelos
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimePhysique.Controllers
{
    [Route("api/[controller]")] // Define la ruta base para este controlador (ej. /api/marcas)
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor: Inyecta el AppDbContext.
        public MarcasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Marcas
        // Obtiene todas las marcas, ahora devolviendo MarcaDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> GetMarcas() // <-- Tipo de retorno cambiado a MarcaDto
        {
            var marcas = await _context.Marcas.ToListAsync();

            // Mapea la lista de Marca a una lista de MarcaDto
            var marcaDtos = marcas.Select(m => new MarcaDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                LogoUrl = m.LogoUrl // Incluye el LogoUrl si lo tienes en tu DTO
            }).ToList();

            return marcaDtos; // Devuelve la lista de DTOs
        }

        // GET: api/Marcas/{id}
        // Obtiene una marca específica por su ID, ahora devolviendo MarcaDto
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaDto>> GetMarca(int id) // <-- Tipo de retorno cambiado a MarcaDto
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            // Mapea la Marca encontrada a un MarcaDto
            var marcaDto = new MarcaDto
            {
                Id = marca.Id,
                Nombre = marca.Nombre,
                LogoUrl = marca.LogoUrl // Incluye el LogoUrl si lo tienes en tu DTO
            };

            return marcaDto; // Devuelve el DTO
        }

        // Si tienes métodos POST, PUT, DELETE para Marca, también deberías considerar
        // usar MarcaDto para las respuestas, similar a como lo hicimos con Producto.
        // Ejemplo de POST (recibe Marca, devuelve MarcaDto)
        /*
        [HttpPost]
        public async Task<ActionResult<MarcaDto>> PostMarca(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            var marcaDto = new MarcaDto
            {
                Id = marca.Id,
                Nombre = marca.Nombre,
                LogoUrl = marca.LogoUrl
            };

            return CreatedAtAction(nameof(GetMarca), new { id = marca.Id }, marcaDto);
        }
        */
    }
}

