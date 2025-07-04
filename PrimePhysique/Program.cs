using PrimePhysique.Models; // Asegúrate de que este using apunte a tus modelos
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization; // Necesario para ReferenceHandler
using Microsoft.OpenApi.Models; // Necesario si usas Swagger

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar contexto de base de datos
// Asegúrate que "cnTareas" es el nombre de tu cadena de conexión en appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnTareas")));

// 2. Configurar controladores y opciones de serialización JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Preservar referencias (introduce $id y $ref en el JSON)
        // Esto es necesario si tus modelos tienen referencias circulares y no usas DTOs
        // o si tu frontend está adaptado para manejar $values.
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

        // Opcional: Formatear el JSON para que sea más legible en desarrollo
        options.JsonSerializerOptions.WriteIndented = true;
    });

// 3. Configurar CORS (Cross-Origin Resource Sharing)
// ¡ADVERTENCIA: NO USAR ESTA POLÍTICA EN PRODUCCIÓN REAL POR RAZONES DE SEGURIDAD!
// Es ideal para desarrollo y pruebas locales.
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app => // Nombre de tu política CORS, como en tu ejemplo
    {
        app.AllowAnyOrigin()   // Permite solicitudes desde CUALQUIER dominio
           .AllowAnyHeader()   // Permite cualquier encabezado HTTP en la solicitud
           .AllowAnyMethod();  // Permite cualquier método HTTP (GET, POST, PUT, DELETE, etc.)
        // Si necesitaras enviar cookies o credenciales (ej. autenticación),
        // NO puedes usar AllowAnyOrigin() con AllowCredentials().
        // En ese caso, deberías volver a WithOrigins específicos y usar AllowCredentials().
    });
});


// 4. Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer(); // Necesario para el descubrimiento de endpoints de la API
builder.Services.AddSwaggerGen(c => // Genera la documentación Swagger
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PrimePhysique API", Version = "v1" });
});

var app = builder.Build();

// 5. Configuración del Pipeline de Solicitudes HTTP

// Habilitar Swagger UI en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita el middleware de Swagger
    app.UseSwaggerUI(c => // Habilita la interfaz de usuario de Swagger
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrimePhysique API V1");
    });
}

// Redireccionar a HTTPS (recomendado para seguridad)
app.UseHttpsRedirection();

// ¡IMPORTANTE! Activar la política CORS.
// Debe ir ANTES de app.UseAuthorization() y app.MapControllers().
app.UseCors("NuevaPolitica"); // <-- ¡Aquí se activa tu política de CORS!

app.UseAuthorization(); // Habilita la autorización (si la usas en tus controladores)

app.MapControllers(); // Mapea los controladores a las rutas de la API

app.Run(); // Inicia la aplicación ASP.NET Core