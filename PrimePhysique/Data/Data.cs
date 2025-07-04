using PrimePhysique.Models; // Asegúrate de que este using apunte a tus modelos
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration; // Necesario para ConfigurationBuilder
using System.IO; // Necesario para Directory.GetCurrentDirectory()

namespace PrimePhysique.Data

{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Construye la configuración para leer appsettings.json
            // Esto es crucial para obtener la cadena de conexión.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Establece la base para buscar appsettings.json
                .AddJsonFile("appsettings.json") // Carga el archivo de configuración
                .Build();

            // Crea un DbContextOptionsBuilder para configurar las opciones del contexto.
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Obtiene la cadena de conexión usando el nombre "cnTareas"
            var connectionString = configuration.GetConnectionString("cnTareas");

            // Verifica si la cadena de conexión es nula o vacía
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se encontró la cadena de conexión 'cnTareas' en appsettings.json.");
            }

            // Configura el DbContext para usar SQL Server con la cadena de conexión obtenida.
            optionsBuilder.UseSqlServer(connectionString);

            // Retorna una nueva instancia de AppDbContext con las opciones configuradas.
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
