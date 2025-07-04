using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimePhysique.Models
{
    public class Categoria
    {
        // Id: Clave primaria para la categoría.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que la base de datos generará el valor
        public int Id { get; set; }

        // Nombre: Nombre de la categoría (ej. "Ropa", "Suplementos").
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Propiedad de navegación para la relación uno a muchos con Producto.
        // Una categoría puede tener muchos productos.
        public ICollection<Producto>? Productos { get; set; }
    }
}
