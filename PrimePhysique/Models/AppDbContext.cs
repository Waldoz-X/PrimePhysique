using Microsoft.EntityFrameworkCore;

namespace PrimePhysique.Models
{
    public class AppDbContext : DbContext
    {
        // Constructor que recibe las opciones del DbContext (ej. cadena de conexión).
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet para la entidad Producto. Esto mapeará a una tabla 'Productos' en la DB.
        public DbSet<Producto> Productos { get; set; }

        // DbSet para la entidad Categoria. Esto mapeará a una tabla 'Categorias' en la DB.
        public DbSet<Categoria> Categorias { get; set; }

        // DbSet para la entidad Marca. Esto mapeará a una tabla 'Marcas' en la DB.
        public DbSet<Marca> Marcas { get; set; }

        // Método OnModelCreating: Se usa para configurar el modelo de datos.
        // Aquí puedes definir relaciones, claves primarias/foráneas, índices, etc.
        // También se puede usar para inicializar la base de datos con datos de prueba (Seed Data).
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación uno a muchos entre Categoria y Producto
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria) // Un Producto tiene una Categoria
                .WithMany(c => c.Productos) // Una Categoria tiene muchos Productos
                .HasForeignKey(p => p.CategoriaId) // La clave foránea es CategoriaId en Producto
                .OnDelete(DeleteBehavior.Restrict); // Comportamiento al eliminar: Restringe la eliminación de una categoría si tiene productos asociados.

            // Configuración de la relación uno a muchos entre Marca y Producto
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Marca) // Un Producto tiene una Marca
                .WithMany(m => m.Productos) // Una Marca tiene muchos Productos
                .HasForeignKey(p => p.MarcaId) // La clave foránea es MarcaId en Producto
                .OnDelete(DeleteBehavior.Restrict); // Comportamiento al eliminar: Restringe la eliminación de una marca si tiene productos asociados.

            // --- Seed Data (Datos iniciales para la base de datos) ---
            // Esto es útil para tener datos con los que trabajar inmediatamente después de la migración.

            // Seed de Categorías
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Ropa" },
                new Categoria { Id = 2, Nombre = "Suplementos" },
                new Categoria { Id = 3, Nombre = "Pre-entrenos" },
                new Categoria { Id = 4, Nombre = "Proteínas" },
                new Categoria { Id = 5, Nombre = "Creatinas" },
                new Categoria { Id = 6, Nombre = "Hoodies" },
                new Categoria { Id = 7, Nombre = "Pantalones" },
                new Categoria { Id = 8, Nombre = "Playeras de Compresión" },
                new Categoria { Id = 9, Nombre = "Accesorios" }, // Nueva categoría para sombreros, cinturones, etc.
                new Categoria { Id = 10, Nombre = "Camisetas" }, // Categoría más general para camisetas
                new Categoria { Id = 11, Nombre = "Camisetas de Manga Larga" },
                new Categoria { Id = 12, Nombre = "Tanks" },
                new Categoria { Id = 13, Nombre = "Quema Grasas" },
                new Categoria { Id = 14, Nombre = "Aminoácidos" }
            );

            // Seed de Marcas
            modelBuilder.Entity<Marca>().HasData(
                new Marca { Id = 1, Nombre = "YoungLA", LogoUrl = "https://www.youngla.com/cdn/shop/files/spaced_logo_Black_32dec808-d736-4b71-87a2-b92272e92b0a.png?v=1742116144&width=2745" },
                new Marca { Id = 2, Nombre = "Gymshark", LogoUrl = "https://cdn.gymshark.com/images/branding/gs-icon-text.svg" },
                new Marca { Id = 3, Nombre = "Evogen Nutrition", LogoUrl = "https://www.evogennutrition.com/cdn/shop/files/Evogen-Brand-Logo.jpg?height=150&v=1626896369" },
                new Marca { Id = 4, Nombre = "Dragon Pharma", LogoUrl = "https://proteinpalacemx.com/cdn/shop/collections/DRAGON_PHARMA_590x.jpg?v=1631223146" }
            );

            // Seed de Productos (continuación desde el ID 1)
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Playera Oversize 'Signature'",
                    Descripcion = "Playera de algodón premium con corte oversize, ideal para el gimnasio o uso casual. Comodidad y estilo.",
                    Precio = 35.99m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/products/DSC08705-11.jpg?v=1720554448&width=300",
                    MarcaId = 1, // YoungLA
                    CategoriaId = 10, // Camisetas
                    TallaColorInfo = "Tallas: M, L, XL | Colores: Negro, Gris, Blanco, Roja",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Hoodie 'Legacy'",
                    Descripcion = "Sudadera con capucha de tejido suave y ajuste atlético. Perfecta para el calentamiento o el día a día.",
                    Precio = 59.99m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/LegacyHoodieBlackA5A2X-BB2J-0733_384x.jpg?v=1722505055",
                    MarcaId = 2, // Gymshark
                    CategoriaId = 6, // Hoodies
                    TallaColorInfo = "Tallas: S, M, L | Colores: Verde, Negro, Azul",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 3,
                    Nombre = "Pre-entreno EVP-AQ",
                    Descripcion = "Fórmula de pre-entreno sin estimulantes diseñada para maximizar el bombeo muscular y la hidratación. Ideal para entrenamientos intensos.",
                    Precio = 45.00m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/EVP_AQ_SourApple.png?crop=center&height=540&v=1722693127&width=540",
                    MarcaId = 3, // Evogen
                    CategoriaId = 3, // Pre-entrenos
                    TallaColorInfo = null,
                    Sabor = "Ponche de Frutas",
                    Contenido = "20 servicios"
                },
                new Producto
                {
                    Id = 4,
                    Nombre = "Proteína IsoPhorm",
                    Descripcion = "Aislado de proteína de suero de leche de rápida absorción, ideal para la recuperación post-entrenamiento. Baja en carbohidratos y grasas.",
                    Precio = 70.00m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0049_iso-phrom-whitechocolate-2L-front_720x.png?v=1691498671",
                    MarcaId = 4, // Dragon Pharma
                    CategoriaId = 4, // Proteínas
                    TallaColorInfo = null,
                    Sabor = "Chocolate",
                    Contenido = "2 Lbs"
                },

                // --- Productos Gymshark (MarcaId = 2) ---
                new Producto
                {
                    Id = 5,
                    Nombre = "Shadow Seamless Long Sleeve T-Shirt",
                    Descripcion = "Camiseta de manga larga sin costuras, ajuste muscular. Ideal para entrenamientos de alto rendimiento.",
                    Precio = 36.00m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-ShadowLSMuscleFitTeeGSBlackA1B5B_BB2J_1219_384x.jpg?v=1746634334",
                    MarcaId = 2,
                    CategoriaId = 11, // Camisetas de Manga Larga
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Meteor Grey, Black, Faded Blue",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 6,
                    Nombre = "Ribbed T-Shirt",
                    Descripcion = "Camiseta acanalada de ajuste muscular, cómoda y estilosa para el gimnasio o el día a día.",
                    Precio = 19.20m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-RibbedMuscleT_ShirtGSBlackA2B5T_BB2J_1267_0175_384x.jpg?v=1747813607",
                    MarcaId = 2,
                    CategoriaId = 10, // Camisetas
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Black, White, Stone Grey Marl",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 7,
                    Nombre = "GSLC Baselayer T-Shirt",
                    Descripcion = "Camiseta de capa base con ajuste de compresión, diseñada para un rendimiento óptimo.",
                    Precio = 27.00m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-GFXLifting6BaselayerT_ShirtGSBlackA2B7Q_BB2J_0752_384x.jpg?v=1747685881",
                    MarcaId = 2,
                    CategoriaId = 8, // Playeras de Compresión
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Black, White",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 8,
                    Nombre = "Element Baselayer Long Sleeve T-Shirt",
                    Descripcion = "Camiseta de manga larga de capa base con ajuste de compresión, ideal para cualquier actividad.",
                    Precio = 27.00m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-ElementBaselayerGSStrengthGreenT_ShirtA2B4C_ECJH_0151_384x.jpg?v=1747311667",
                    MarcaId = 2,
                    CategoriaId = 11, // Camisetas de Manga Larga
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: White, Dark Grey",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 9,
                    Nombre = "Element Tank",
                    Descripcion = "Tank top con ajuste de compresión, perfecto para entrenamientos intensos y máxima movilidad.",
                    Precio = 19.80m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-ElementTankGSCarmineRed_GSBlackA2C4U_RB2R_0225_384x.jpg?v=1747311526",
                    MarcaId = 2,
                    CategoriaId = 12, // Tanks
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: White, Carmine Red",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 10,
                    Nombre = "everywear Warp Knit T-Shirt",
                    Descripcion = "Camiseta de punto urdido, diseño moderno y tejido ligero para el uso diario.",
                    Precio = 77.00m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-everywearWarpKnitT_ShirtGSBlackA1B9Y_BB2J_1210_384x.jpg?v=1748293907",
                    MarcaId = 2,
                    CategoriaId = 10, // Camisetas
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Black, Tame Grey, Pale Blue",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 11,
                    Nombre = "Tectonic Seamless T Shirt",
                    Descripcion = "Camiseta sin costuras con ajuste muscular, patrón tectónico para un look distintivo.",
                    Precio = 22.80m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/TectonicSeamlessTShirtGSAsphaltGrey-GSBlackA1B1P-GCWT-0243_ab73a218-b3b7-4261-a921-23d269f2d1df_384x.jpg?v=1733829349",
                    MarcaId = 2,
                    CategoriaId = 10, // Camisetas
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Asphalt Grey/Black, Cargo Blue/Cool Blue, Trail Green/Classic Green",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 12,
                    Nombre = "Clean Contour Seamless 1/4 Zip",
                    Descripcion = "Sudadera con cremallera de 1/4 sin costuras, ajuste delgado, perfecta para capas.",
                    Precio = 30.80m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/CleanContourSeamlessSportsBraGSBlackB2C1I-BB2J6351_08e31e70-5086-454e-83a3-9779061fcfb2_1920x.jpg?v=1735645373",
                    MarcaId = 2,
                    CategoriaId = 6, // Hoodies (o Ropa si es más general)
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Black/White",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 13,
                    Nombre = "Onyx 5.0 Tank",
                    Descripcion = "Tank top de compresión Onyx 5.0, diseñado para un soporte y libertad de movimiento superiores.",
                    Precio = 44.00m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-Onyx5_0TankGSBlackGSCarmineRedA1B1N_BB4J_5412_A_640x.jpg?v=1746629027",
                    MarcaId = 2,
                    CategoriaId = 12, // Tanks
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Black/Light Grey, Black/Carmine Red, Black/Onyx Grey",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 14,
                    Nombre = "Onyx 5.0 Seamless Long Sleeve T-Shirt",
                    Descripcion = "Camiseta de manga larga sin costuras Onyx 5.0, ajuste de compresión para un rendimiento máximo.",
                    Precio = 56.00m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-Onyx5_0SeamlessLST_ShirtSS25GSBlackGSLightGreyA6A3G_BB23_5385_6e9b9a93-3a9e-4982-88a4-926b484f2df4_640x.jpg?v=1746628707",
                    MarcaId = 2,
                    CategoriaId = 11, // Camisetas de Manga Larga
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Black/Light Grey, Black/Carmine Red, Black/Onyx Grey",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 15,
                    Nombre = "Onyx 5.0 Seamless T-Shirt",
                    Descripcion = "Camiseta sin costuras Onyx 5.0, ajuste de compresión para un soporte óptimo durante el ejercicio.",
                    Precio = 50.00m,
                    ImagenUrl = "https://cdn.shopify.com/s/files/1/0156/6146/files/images-A6A3G_BB24_8_640x.jpg?v=1746696933",
                    MarcaId = 2,
                    CategoriaId = 8, // Playeras de Compresión
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Black/Light Grey, Black/Carmine Red, Black/Onyx Grey",
                    Sabor = null,
                    Contenido = null
                },

                // --- Productos YoungLA (MarcaId = 1) ---
                new Producto
                {
                    Id = 16,
                    Nombre = "4117 - Camiseta de Compresión Superman",
                    Descripcion = "Camiseta de compresión con diseño de Superman, ideal para entrenamientos o uso casual. Ajuste ceñido.",
                    Precio = 45.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/YLA5.30_baeb29b0-ea4a-4d22-838e-428a7f9c6fa3.jpg?v=1751418341&width=300",
                    MarcaId = 1,
                    CategoriaId = 8, // Playeras de Compresión
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Negro, Azul, Carbón, Rojo",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 17,
                    Nombre = "4044 - Camiseta Gráfica de Superman",
                    Descripcion = "Camiseta de algodón con gráficos icónicos de Superman. Perfecta para mostrar tu lado heroico.",
                    Precio = 42.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/4044_chrome-logo_003_07_01_bryan_lifestyle_a3e17d95-0c82-4af4-9e39-fe1e6292db43.jpg?v=1751418166&width=1000",
                    MarcaId = 1,
                    CategoriaId = 10, // Camisetas
                    TallaColorInfo = "Tallas: S, M, L, XL | Diseños: Logotipo de Chrome, En acción, Legado, Limitado al espacio, La pintura",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 18,
                    Nombre = "8072 - Camisa Raglán 3/4 de Superman",
                    Descripcion = "Camisa raglán 3/4 con diseño de Superman, cómoda y con estilo deportivo.",
                    Precio = 45.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/8072_black-red_004_07_01_bryan_lifestyle.jpg?v=1750966526&width=300",
                    MarcaId = 1,
                    CategoriaId = 10, // Camisetas
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Negro/Rojo, Blanco y negro, Blanco/Azul",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 19,
                    Nombre = "5079 - Sudadera con Capucha del Legado de Superman",
                    Descripcion = "Sudadera con capucha de alta calidad con el legado de Superman, ideal para el frío.",
                    Precio = 62.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/YLA5.27_92dd2563-c481-407e-b49b-578fdc72ab50.jpg?v=1750966138&width=200",
                    MarcaId = 1,
                    CategoriaId = 6, // Hoodies
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Lavado negro, Lavado azul, Gris brezo",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 20,
                    Nombre = "3004 - Superman Cut-Offs",
                    Descripcion = "Camiseta sin mangas estilo cut-off de Superman, perfecta para mostrar tus músculos en el gimnasio.",
                    Precio = 40.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/YLA5.2220_da90ba32-ef1c-47ef-8316-47e67fec04de.jpg?v=1751418105&width=200",
                    MarcaId = 1,
                    CategoriaId = 12, // Tanks
                    TallaColorInfo = "Tallas: S, M, L, XL | Diseños: A prueba de balas, Limitado al espacio, La pintura",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 21,
                    Nombre = "2032 - Superman Sudadera",
                    Descripcion = "Sudadera cómoda de Superman, ideal para el uso diario y para los fans del héroe.",
                    Precio = 62.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/YLA5.3e0_33bd2e66-10f6-4785-b963-12bf50a10326.jpg?v=1750973332&width=200",
                    MarcaId = 1,
                    CategoriaId = 7, // Pantalones (asumiendo que "Suda" se refiere a pantalones de sudadera)
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Lavado negro, Lavado azul, Gris brezo",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 22,
                    Nombre = "9092 - Sombrero Escudo de Superman",
                    Descripcion = "Gorra con el icónico escudo de Superman, un accesorio imprescindible para cualquier fan.",
                    Precio = 36.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/YLA5.210.jpg?v=1750886929&width=200",
                    MarcaId = 1,
                    CategoriaId = 9, // Accesorios
                    TallaColorInfo = "Talla: Única | Colores: Negro, Gris claro, Rojo",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 23,
                    Nombre = "249 - Pantalones Deportivos Flagship",
                    Descripcion = "Pantalones deportivos cómodos y versátiles, perfectos para entrenar o relajarse.",
                    Precio = 50.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/YLA_10.2_13761032-5736-4c6a-a4d0-3fd4dd79e5b3.jpg?v=1699481570&width=200",
                    MarcaId = 1,
                    CategoriaId = 7, // Pantalones
                    TallaColorInfo = "Tallas: S, M, L, XL, XXL | Colores: Negro, Borgoña, Morado oscuro, Verde jungla, Blanquecino, Neón negro, Carbón, Marina de guerra, Gris, Rojo, Gris azul",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 24,
                    Nombre = "4118 - Camiseta de Guerrero",
                    Descripcion = "Camiseta con diseño de guerrero, ideal para un estilo audaz y motivador.",
                    Precio = 34.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/Jerdani_WarriorTee-28.jpg?v=1714602066&width=200",
                    MarcaId = 1,
                    CategoriaId = 10, // Camisetas
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Lavado negro, Lavado gris, Lavado azul claro, Lavado rosa",
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 25,
                    Nombre = "4138 - Camiseta Corta de Base",
                    Descripcion = "Camiseta corta de base, ideal para entrenamientos intensos y para mantener la frescura.",
                    Precio = 36.00m,
                    ImagenUrl = "https://www.youngla.com/cdn/shop/files/4138_forest-green-wash_0016_06_25_johnny_ecomm_5f8af11d-c9b3-4f68-9d6c-48b4bb83a6cf.jpg?v=1719336250&width=200",
                    MarcaId = 1,
                    CategoriaId = 10, // Camisetas
                    TallaColorInfo = "Tallas: XS, S, M, L | Colores: Lavado negro, Lavado marrón, Lavado verde bosque, Lavado gris",
                    Sabor = null,
                    Contenido = null
                },

                // --- Productos Dragon Pharma (MarcaId = 4) ---
                new Producto
                {
                    Id = 26,
                    Nombre = "MASSPHORM - Ganador de Masa Definitivo",
                    Descripcion = "Ganador de masa muscular diseñado para maximizar el crecimiento y la recuperación. Alto en calorías y proteínas.",
                    Precio = 69.00m, // Precio de 69.00 de la segunda mención
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0068_Mockup-Mass-Phorm-Dragon-Pharma-Vanilla-Milkshake-Pose-3_720x.png?v=1691498083",
                    MarcaId = 4,
                    CategoriaId = 4, // Proteínas (o Suplementos si es más general)
                    TallaColorInfo = null,
                    Sabor = "Chocolate, Vainilla", // Inventado
                    Contenido = "5 Lbs"
                },
                new Producto
                {
                    Id = 27,
                    Nombre = "WHEYPHORM® - Proteína de Suero",
                    Descripcion = "Proteína de suero de alta calidad para el desarrollo y mantenimiento muscular. Excelente sabor y disolución.",
                    Precio = 49.90m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/Mockup-WheyPhorm-2Lb-BirthdayCake-Pose1_bcc559b4-706d-4800-8b69-20e434a42bcf_720x.png?v=1732523043",
                    MarcaId = 4,
                    CategoriaId = 4, // Proteínas
                    TallaColorInfo = null,
                    Sabor = "Chocolate, Vainilla, Fresa",
                    Contenido = "2 Lbs"
                },
                new Producto
                {
                    Id = 28,
                    Nombre = "DR. FEAAR® - Aminoácido Esencial Completo",
                    Descripcion = "Fórmula completa de aminoácidos esenciales (EAA) para la recuperación y el rendimiento. Ideal intra-entrenamiento.",
                    Precio = 45.00m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0005_dr-feaar-v2-peach-guava-front_720x.png?v=1691501874",
                    MarcaId = 4,
                    CategoriaId = 14, // Aminoácidos
                    TallaColorInfo = null,
                    Sabor = "Blue Raspberry, Mango", // Inventado
                    Contenido = "30 servicios"
                },
                new Producto
                {
                    Id = 29,
                    Nombre = "VENOM INFERNO - Pre-entrenamiento",
                    Descripcion = "Pre-entrenamiento termogénico diseñado para energía extrema, enfoque y quema de grasa. Sabor limón.",
                    Precio = 49.99m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023-venom-cotton-candy_720x.png?v=1740674377",
                    MarcaId = 4,
                    CategoriaId = 3, // Pre-entrenos
                    TallaColorInfo = null,
                    Sabor = "Limón",
                    Contenido = "50 servicios"
                },
                new Producto
                {
                    Id = 30,
                    Nombre = "FEMATROPE®",
                    Descripcion = "Suplemento para el desarrollo muscular y la fuerza, optimizado para mujeres. Soporte hormonal natural.",
                    Precio = 79.99m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0028_new-fema-front_720x.png?v=1691501701",
                    MarcaId = 4,
                    CategoriaId = 2, // Suplementos
                    TallaColorInfo = null,
                    Sabor = null,
                    Contenido = "60 cápsulas"
                },
                new Producto
                {
                    Id = 31,
                    Nombre = "ATP Force - Sistema de Creatina Mejorado",
                    Descripcion = "Sistema de creatina avanzado para aumentar la fuerza, potencia y resistencia muscular. Sin hinchazón.",
                    Precio = 45.00m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0002_atp-force-v2-ppina-colada-front_720x.png?v=1697047885",
                    MarcaId = 4,
                    CategoriaId = 5, // Creatinas
                    TallaColorInfo = null,
                    Sabor = "Sin Sabor",
                    Contenido = "60 servicios"
                },
                new Producto
                {
                    Id = 32,
                    Nombre = "DRYUP® - Diurético Natural",
                    Descripcion = "Diurético natural para ayudar a eliminar el exceso de agua y lograr una apariencia más definida.",
                    Precio = 34.99m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0026_new-dryup-front_720x.png?v=1691501775",
                    MarcaId = 4,
                    CategoriaId = 2, // Suplementos
                    TallaColorInfo = null,
                    Sabor = null,
                    Contenido = "80 cápsulas"
                },
                new Producto
                {
                    Id = 33,
                    Nombre = "GLUTAMINA FERMENTADA",
                    Descripcion = "Glutamina de alta pureza para la recuperación muscular y el soporte del sistema inmunológico.",
                    Precio = 24.90m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0018_Mockup---Glutamine-Essentials---Dragon-Pharma---Sem-Fundo1_720x.png?v=1691501674",
                    MarcaId = 4,
                    CategoriaId = 14, // Aminoácidos
                    TallaColorInfo = null,
                    Sabor = "Sin Sabor",
                    Contenido = "300g"
                },
                new Producto
                {
                    Id = 34,
                    Nombre = "VERDES Y ROJOS - Superalimentos",
                    Descripcion = "Mezcla de superalimentos verdes y rojos para soporte nutricional completo y antioxidantes.",
                    Precio = 44.99m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0014_Mockup---Dragon-Pharma---Reds-n-Greens---Lemonade---Posicao-1_720x.png?v=1691501627",
                    MarcaId = 4,
                    CategoriaId = 2, // Suplementos
                    TallaColorInfo = null,
                    Sabor = "Berry Blast", // Inventado
                    Contenido = "30 servicios"
                },
                new Producto
                {
                    Id = 35,
                    Nombre = "L-CARNITINA-3000",
                    Descripcion = "L-Carnitina líquida de alta potencia para la quema de grasa y la producción de energía.",
                    Precio = 34.99m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/products/600x600-lcarnitine-mango-1_720x.png?v=1695741775",
                    MarcaId = 4,
                    CategoriaId = 13, // Quema Grasas
                    TallaColorInfo = null,
                    Sabor = "Manzana Verde", // Inventado
                    Contenido = "30 servicios"
                },
                new Producto
                {
                    Id = 36,
                    Nombre = "HYDRA - Hidratación Avanzada",
                    Descripcion = "Suplemento de hidratación avanzada con electrolitos y minerales para optimizar el rendimiento.",
                    Precio = 79.99m,
                    ImagenUrl = "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0029_Mockup---Hydra---Dragon-Pharma---Pose-1_720x.png?v=1691502355",
                    MarcaId = 4,
                    CategoriaId = 2, // Suplementos
                    TallaColorInfo = null,
                    Sabor = "Sandía", // Inventado
                    Contenido = "30 servicios"
                },

                // --- Productos Evogen Nutrition (MarcaId = 3) ---
                new Producto
                {
                    Id = 37,
                    Nombre = "CLA - Ácido Linoleico Conjugado",
                    Descripcion = "CLA de alta pureza para apoyar la composición corporal y la quema de grasa.",
                    Precio = 19.95m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/CLA_0624_bottle_1200x1200_443cdc93-72d0-4f90-a25f-912da81c9c87.png?v=1724779938&width=900",
                    MarcaId = 3,
                    CategoriaId = 13, // Quema Grasas
                    TallaColorInfo = null,
                    Sabor = null,
                    Contenido = "90 cápsulas"
                },
                new Producto
                {
                    Id = 38,
                    Nombre = "Vitamina D3",
                    Descripcion = "Vitamina D3 esencial para la salud ósea, el sistema inmunológico y el bienestar general.",
                    Precio = 12.99m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/VitaminD3_0524render_1.png?v=1724778512&width=900",
                    MarcaId = 3,
                    CategoriaId = 2, // Suplementos
                    TallaColorInfo = null,
                    Sabor = null,
                    Contenido = "60 cápsulas"
                },
                new Producto
                {
                    Id = 39,
                    Nombre = "Light & Tight - Limpieza Digestiva",
                    Descripcion = "Programa de limpieza y desintoxicación digestiva de 14 días para una sensación ligera y firme.",
                    Precio = 29.95m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/Light_TightFront1123.png?v=1709738054&width=900",
                    MarcaId = 3,
                    CategoriaId = 2, // Suplementos
                    TallaColorInfo = null,
                    Sabor = null,
                    Contenido = "14 días"
                },
                new Producto
                {
                    Id = 40,
                    Nombre = "Evoboost-T - Potenciador de Testosterona",
                    Descripcion = "Potenciador natural de testosterona para mejorar la fuerza, el rendimiento y la vitalidad.",
                    Precio = 64.95m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/Evoboostrenderrebuild.png?v=1702568583&width=900",
                    MarcaId = 3,
                    CategoriaId = 2, // Suplementos
                    TallaColorInfo = null,
                    Sabor = null,
                    Contenido = "120 cápsulas"
                },
                new Producto
                {
                    Id = 41,
                    Nombre = "Polvo de L-Citrulina",
                    Descripcion = "L-Citrulina en polvo para mejorar el flujo sanguíneo, el bombeo muscular y la resistencia.",
                    Precio = 27.99m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/renderCITRULLINE.jpg?v=1727985466&width=900",
                    MarcaId = 3,
                    CategoriaId = 14, // Aminoácidos
                    TallaColorInfo = null,
                    Sabor = "Sin Sabor",
                    Contenido = "200g"
                },
                new Producto
                {
                    Id = 42,
                    Nombre = "Polvo de Beta-Alanina",
                    Descripcion = "Beta-Alanina en polvo para aumentar la resistencia muscular y reducir la fatiga durante el ejercicio.",
                    Precio = 19.95m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/renderBetaAlaninerender02.jpg?v=1727985106&width=900",
                    MarcaId = 3,
                    CategoriaId = 14, // Aminoácidos
                    TallaColorInfo = null,
                    Sabor = "Sin Sabor",
                    Contenido = "200g"
                },
                new Producto
                {
                    Id = 43,
                    Nombre = "Evolog - Ganancias con Comidas Trampa",
                    Descripcion = "Optimizador de nutrientes para ayudarte a aprovechar al máximo tus comidas trampa sin remordimientos.",
                    Precio = 39.95m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/EVOLOGasset.jpg?v=1703292233&width=900",
                    MarcaId = 3,
                    CategoriaId = 2, // Suplementos
                    TallaColorInfo = null,
                    Sabor = null,
                    Contenido = "60 cápsulas"
                },
                new Producto
                {
                    Id = 44,
                    Nombre = "Carnitina Líquida Premium Carnigen",
                    Descripcion = "Carnitina líquida de alta calidad para la movilización de grasas y la producción de energía.",
                    Precio = 34.95m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/Carnigen_new_blue_label_grape_24.png?v=1733491617&width=900",
                    MarcaId = 3,
                    CategoriaId = 13, // Quema Grasas
                    TallaColorInfo = null,
                    Sabor = "Mango", // Inventado
                    Contenido = "30 servicios"
                },
                new Producto
                {
                    Id = 45,
                    Nombre = "Polvo Termogénico Lipocide IR",
                    Descripcion = "Termogénico en polvo de acción rápida para quemar grasa y aumentar la energía. Sabor refrescante.",
                    Precio = 49.95m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/LipocideIR_GRAPECC.png?v=1716135069&width=900",
                    MarcaId = 3,
                    CategoriaId = 13, 
                    TallaColorInfo = null,
                    Sabor = "Ponche de Frutas", 
                    Contenido = "30 servicios"
                },
                new Producto
                {
                    Id = 46,
                    Nombre = "Mezcla de Proteínas Evofusion",
                    Descripcion = "Mezcla de proteínas de liberación sostenida para una recuperación y crecimiento muscular óptimos.",
                    Precio = 44.95m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/Evofusion_2lbvanillabean1223.png?v=1719718852&width=900",
                    MarcaId = 3,
                    CategoriaId = 4, 
                    TallaColorInfo = null,
                    Sabor = "Chocolate, Vainilla", 
                    Contenido = "2 Lbs"
                },
                new Producto
                {
                    Id = 47,
                    Nombre = "Camiseta de Arco",
                    Descripcion = "Camiseta con el logo distintivo de Evogen en forma de arco. Comodidad para el día a día.",
                    Precio = 35.00m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/evogenarcbluetee.jpg?v=1716434815&width=900",
                    MarcaId = 3,
                    CategoriaId = 10, 
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Negro, Gris", 
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 48,
                    Nombre = "Joggers de Última Generación",
                    Descripcion = "Joggers modernos y cómodos, ideales para el gimnasio o el estilo de vida activo.",
                    Precio = 50.00m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/Olympiaassetsgreyjogger.jpg?v=1700195164",
                    MarcaId = 3,
                    CategoriaId = 7, 
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Negro, Gris", 
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 49,
                    Nombre = "Sudadera con Capucha de Última Generación",
                    Descripcion = "Sudadera con capucha de diseño moderno, perfecta para mantenerte abrigado y con estilo.",
                    Precio = 55.00m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/files/12_20_drop_hoodie_01.jpg?v=1734657585&width=900",
                    MarcaId = 3,
                    CategoriaId = 6, 
                    TallaColorInfo = "Tallas: S, M, L, XL | Colores: Negro, Azul", 
                    Sabor = null,
                    Contenido = null
                },
                new Producto
                {
                    Id = 50,
                    Nombre = "Cinturón de Levantamiento de Cuero Clásico 6mm",
                    Descripcion = "Cinturón de cuero resistente de 6mm para soporte lumbar en levantamientos pesados.",
                    Precio = 75.00m,
                    ImagenUrl = "https://www.evogennutrition.com/cdn/shop/products/BeltBackView.jpg?v=1630508778&width=900",
                    MarcaId = 3,
                    CategoriaId = 9, // Accesorios
                    TallaColorInfo = "Tallas: S, M, L, XL | Color: Negro",
                    Sabor = null,
                    Contenido = null
                }
            );
        }
    }
}

