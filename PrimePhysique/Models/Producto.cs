using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimePhysique.Models
{
    public class Producto
    {
        // Id: Clave primaria para el producto.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que la base de datos generará el valor
        public int Id { get; set; }

        // Nombre: Nombre del producto (ej. "Playera Oversize", "Pre-entreno EVP-AQ").
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [MaxLength(250)]
        public string Nombre { get; set; } = string.Empty;

        // Descripcion: Descripción detallada del producto.
        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;

        // Precio: Precio del producto.
        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [Column(TypeName = "decimal(18, 2)")] // Define el tipo de dato en SQL Server para precisión decimal
        public decimal Precio { get; set; }

        // ImagenUrl: URL de la imagen principal del producto. Puede ser local o en línea.
        [Required(ErrorMessage = "La URL de la imagen es obligatoria.")]
        [MaxLength(1500)]
        public string ImagenUrl { get; set; } = string.Empty;

        // MarcaId: Clave foránea para la Marca a la que pertenece el producto.
        [Required(ErrorMessage = "El producto debe tener una marca asociada.")]
        public int MarcaId { get; set; }

        // CategoriaId: Clave foránea para la Categoría a la que pertenece el producto.
        [Required(ErrorMessage = "El producto debe tener una categoría asociada.")]
        public int CategoriaId { get; set; }

        // Propiedad de navegación para la relación uno a muchos con Marca.
        // Un producto pertenece a una Marca.
        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }

        // Propiedad de navegación para la relación uno a muchos con Categoria.
        // Un producto pertenece a una Categoría.
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }

        // --- Campos Opcionales para Variaciones y Atributos Específicos ---

        // TallaColorInfo: Campo para almacenar información sobre tallas y colores de ropa.
        // Se puede almacenar como una cadena JSON (ej. "[{'talla':'M', 'color':'Negro'}, {'talla':'L', 'color':'Blanco'}]")
        // o simplemente una descripción de texto como "Disponible en S, M, L (Negro, Gris)".
        // Es nullable porque no aplica a suplementos.
        [MaxLength(1000)]
        public string? TallaColorInfo { get; set; }

        // Sabor: Campo para el sabor de los suplementos (ej. "Ponche de Frutas", "Chocolate").
        // Es nullable porque no aplica a la ropa.
        [MaxLength(100)]
        public string? Sabor { get; set; }

        // Contenido: Campo para el contenido o tamaño del envase de los suplementos (ej. "500g", "30 servicios").
        // Es nullable porque no aplica a la ropa.
        [MaxLength(100)]
        public string? Contenido { get; set; }
    }
}
