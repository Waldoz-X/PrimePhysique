using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimePhysique.Models
{
    public class Marca
    {
        // Id: Clave primaria para la marca.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que la base de datos generará el valor
        public int Id { get; set; }

        // Nombre: Nombre de la marca (ej. "YoungLA").
        [Required(ErrorMessage = "El nombre de la marca es obligatorio.")]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // LogoUrl: URL opcional para el logo de la marca.
        [MaxLength(500)]
        public string? LogoUrl { get; set; }

        // Propiedad de navegación para la relación uno a muchos con Producto.
        // Una marca puede tener muchos productos.
        public ICollection<Producto>? Productos { get; set; }
    }
}
