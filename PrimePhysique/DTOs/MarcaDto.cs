namespace PrimePhysique.DTOs
{
    public class MarcaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        // No incluyas ICollection<Producto> aquí.
    }
}
