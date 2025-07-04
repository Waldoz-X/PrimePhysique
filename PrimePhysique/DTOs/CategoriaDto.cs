namespace PrimePhysique.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        // No incluyas ICollection<Producto> aquí, ya que eso causaría el ciclo.
    }
}
