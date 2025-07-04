namespace PrimePhysique.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;

        // Propiedades de las claves foráneas
        public int MarcaId { get; set; }
        public int CategoriaId { get; set; }

        // Propiedades para incluir los NOMBRES de la categoría y la marca (NO los objetos completos)
        public string? MarcaNombre { get; set; }
        public string? CategoriaNombre { get; set; }

        // Incluye las propiedades opcionales que quieras exponer
        public string? TallaColorInfo { get; set; }
        public string? Sabor { get; set; }
        public string? Contenido { get; set; }
    }
}
