using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimePhysique.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 9, "Accesorios" },
                    { 10, "Camisetas" },
                    { 11, "Camisetas de Manga Larga" },
                    { 12, "Tanks" },
                    { 13, "Quema Grasas" },
                    { 14, "Aminoácidos" }
                });

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "https://www.youngla.com/cdn/shop/files/spaced_logo_Black_32dec808-d736-4b71-87a2-b92272e92b0a.png?v=1742116144&width=2745");

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "https://cdn.gymshark.com/images/branding/gs-icon-text.svg");

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LogoUrl", "Nombre" },
                values: new object[] { "https://www.evogennutrition.com/cdn/shop/files/Evogen-Brand-Logo.jpg?height=150&v=1626896369", "Evogen Nutrition" });

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "LogoUrl",
                value: "https://proteinpalacemx.com/cdn/shop/collections/DRAGON_PHARMA_590x.jpg?v=1631223146");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoriaId", "ImagenUrl", "TallaColorInfo" },
                values: new object[] { 10, "https://www.youngla.com/cdn/shop/products/DSC08705-11.jpg?v=1720554448&width=300", "Tallas: M, L, XL | Colores: Negro, Gris, Blanco, Roja" });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImagenUrl", "TallaColorInfo" },
                values: new object[] { "https://cdn.shopify.com/s/files/1/0156/6146/files/LegacyHoodieBlackA5A2X-BB2J-0733_384x.jpg?v=1722505055", "Tallas: S, M, L | Colores: Verde, Negro, Azul" });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descripcion", "ImagenUrl" },
                values: new object[] { "Fórmula de pre-entreno sin estimulantes diseñada para maximizar el bombeo muscular y la hidratación. Ideal para entrenamientos intensos.", "https://www.evogennutrition.com/cdn/shop/files/EVP_AQ_SourApple.png?crop=center&height=540&v=1722693127&width=540" });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Descripcion", "ImagenUrl" },
                values: new object[] { "Aislado de proteína de suero de leche de rápida absorción, ideal para la recuperación post-entrenamiento. Baja en carbohidratos y grasas.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0049_iso-phrom-whitechocolate-2L-front_720x.png?v=1691498671" });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Contenido", "Descripcion", "ImagenUrl", "MarcaId", "Nombre", "Precio", "Sabor", "TallaColorInfo" },
                values: new object[,]
                {
                    { 7, 8, null, "Camiseta de capa base con ajuste de compresión, diseñada para un rendimiento óptimo.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-GFXLifting6BaselayerT_ShirtGSBlackA2B7Q_BB2J_0752_384x.jpg?v=1747685881", 2, "GSLC Baselayer T-Shirt", 27.00m, null, "Tallas: S, M, L, XL | Colores: Black, White" },
                    { 12, 6, null, "Sudadera con cremallera de 1/4 sin costuras, ajuste delgado, perfecta para capas.", "https://cdn.shopify.com/s/files/1/0156/6146/files/CleanContourSeamlessSportsBraGSBlackB2C1I-BB2J6351_08e31e70-5086-454e-83a3-9779061fcfb2_1920x.jpg?v=1735645373", 2, "Clean Contour Seamless 1/4 Zip", 30.80m, null, "Tallas: S, M, L, XL | Colores: Black/White" },
                    { 15, 8, null, "Camiseta sin costuras Onyx 5.0, ajuste de compresión para un soporte óptimo durante el ejercicio.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-A6A3G_BB24_8_640x.jpg?v=1746696933", 2, "Onyx 5.0 Seamless T-Shirt", 50.00m, null, "Tallas: S, M, L, XL | Colores: Black/Light Grey, Black/Carmine Red, Black/Onyx Grey" },
                    { 16, 8, null, "Camiseta de compresión con diseño de Superman, ideal para entrenamientos o uso casual. Ajuste ceñido.", "https://www.youngla.com/cdn/shop/files/YLA5.30_baeb29b0-ea4a-4d22-838e-428a7f9c6fa3.jpg?v=1751418341&width=300", 1, "4117 - Camiseta de Compresión Superman", 45.00m, null, "Tallas: S, M, L, XL | Colores: Negro, Azul, Carbón, Rojo" },
                    { 19, 6, null, "Sudadera con capucha de alta calidad con el legado de Superman, ideal para el frío.", "https://www.youngla.com/cdn/shop/files/YLA5.27_92dd2563-c481-407e-b49b-578fdc72ab50.jpg?v=1750966138&width=200", 1, "5079 - Sudadera con Capucha del Legado de Superman", 62.00m, null, "Tallas: S, M, L, XL | Colores: Lavado negro, Lavado azul, Gris brezo" },
                    { 21, 7, null, "Sudadera cómoda de Superman, ideal para el uso diario y para los fans del héroe.", "https://www.youngla.com/cdn/shop/files/YLA5.3e0_33bd2e66-10f6-4785-b963-12bf50a10326.jpg?v=1750973332&width=200", 1, "2032 - Superman Sudadera", 62.00m, null, "Tallas: S, M, L, XL | Colores: Lavado negro, Lavado azul, Gris brezo" },
                    { 23, 7, null, "Pantalones deportivos cómodos y versátiles, perfectos para entrenar o relajarse.", "https://www.youngla.com/cdn/shop/files/YLA_10.2_13761032-5736-4c6a-a4d0-3fd4dd79e5b3.jpg?v=1699481570&width=200", 1, "249 - Pantalones Deportivos Flagship", 50.00m, null, "Tallas: S, M, L, XL, XXL | Colores: Negro, Borgoña, Morado oscuro, Verde jungla, Blanquecino, Neón negro, Carbón, Marina de guerra, Gris, Rojo, Gris azul" },
                    { 26, 4, "5 Lbs", "Ganador de masa muscular diseñado para maximizar el crecimiento y la recuperación. Alto en calorías y proteínas.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0068_Mockup-Mass-Phorm-Dragon-Pharma-Vanilla-Milkshake-Pose-3_720x.png?v=1691498083", 4, "MASSPHORM - Ganador de Masa Definitivo", 69.00m, "Chocolate, Vainilla", null },
                    { 27, 4, "2 Lbs", "Proteína de suero de alta calidad para el desarrollo y mantenimiento muscular. Excelente sabor y disolución.", "https://dragonpharmalabs.com/cdn/shop/files/Mockup-WheyPhorm-2Lb-BirthdayCake-Pose1_bcc559b4-706d-4800-8b69-20e434a42bcf_720x.png?v=1732523043", 4, "WHEYPHORM® - Proteína de Suero", 49.90m, "Chocolate, Vainilla, Fresa", null },
                    { 29, 3, "50 servicios", "Pre-entrenamiento termogénico diseñado para energía extrema, enfoque y quema de grasa. Sabor limón.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023-venom-cotton-candy_720x.png?v=1740674377", 4, "VENOM INFERNO - Pre-entrenamiento", 49.99m, "Limón", null },
                    { 30, 2, "60 cápsulas", "Suplemento para el desarrollo muscular y la fuerza, optimizado para mujeres. Soporte hormonal natural.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0028_new-fema-front_720x.png?v=1691501701", 4, "FEMATROPE®", 79.99m, null, null },
                    { 31, 5, "60 servicios", "Sistema de creatina avanzado para aumentar la fuerza, potencia y resistencia muscular. Sin hinchazón.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0002_atp-force-v2-ppina-colada-front_720x.png?v=1697047885", 4, "ATP Force - Sistema de Creatina Mejorado", 45.00m, "Sin Sabor", null },
                    { 32, 2, "80 cápsulas", "Diurético natural para ayudar a eliminar el exceso de agua y lograr una apariencia más definida.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0026_new-dryup-front_720x.png?v=1691501775", 4, "DRYUP® - Diurético Natural", 34.99m, null, null },
                    { 34, 2, "30 servicios", "Mezcla de superalimentos verdes y rojos para soporte nutricional completo y antioxidantes.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0014_Mockup---Dragon-Pharma---Reds-n-Greens---Lemonade---Posicao-1_720x.png?v=1691501627", 4, "VERDES Y ROJOS - Superalimentos", 44.99m, "Berry Blast", null },
                    { 36, 2, "30 servicios", "Suplemento de hidratación avanzada con electrolitos y minerales para optimizar el rendimiento.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0029_Mockup---Hydra---Dragon-Pharma---Pose-1_720x.png?v=1691502355", 4, "HYDRA - Hidratación Avanzada", 79.99m, "Sandía", null },
                    { 38, 2, "60 cápsulas", "Vitamina D3 esencial para la salud ósea, el sistema inmunológico y el bienestar general.", "https://www.evogennutrition.com/cdn/shop/files/VitaminD3_0524render_1.png?v=1724778512&width=900", 3, "Vitamina D3", 12.99m, null, null },
                    { 39, 2, "14 días", "Programa de limpieza y desintoxicación digestiva de 14 días para una sensación ligera y firme.", "https://www.evogennutrition.com/cdn/shop/files/Light_TightFront1123.png?v=1709738054&width=900", 3, "Light & Tight - Limpieza Digestiva", 29.95m, null, null },
                    { 40, 2, "120 cápsulas", "Potenciador natural de testosterona para mejorar la fuerza, el rendimiento y la vitalidad.", "https://www.evogennutrition.com/cdn/shop/files/Evoboostrenderrebuild.png?v=1702568583&width=900", 3, "Evoboost-T - Potenciador de Testosterona", 64.95m, null, null },
                    { 43, 2, "60 cápsulas", "Optimizador de nutrientes para ayudarte a aprovechar al máximo tus comidas trampa sin remordimientos.", "https://www.evogennutrition.com/cdn/shop/files/EVOLOGasset.jpg?v=1703292233&width=900", 3, "Evolog - Ganancias con Comidas Trampa", 39.95m, null, null },
                    { 46, 4, "2 Lbs", "Mezcla de proteínas de liberación sostenida para una recuperación y crecimiento muscular óptimos.", "https://www.evogennutrition.com/cdn/shop/files/Evofusion_2lbvanillabean1223.png?v=1719718852&width=900", 3, "Mezcla de Proteínas Evofusion", 44.95m, "Chocolate, Vainilla", null },
                    { 48, 7, null, "Joggers modernos y cómodos, ideales para el gimnasio o el estilo de vida activo.", "https://www.evogennutrition.com/cdn/shop/files/Olympiaassetsgreyjogger.jpg?v=1700195164", 3, "Joggers de Última Generación", 50.00m, null, "Tallas: S, M, L, XL | Colores: Negro, Gris" },
                    { 49, 6, null, "Sudadera con capucha de diseño moderno, perfecta para mantenerte abrigado y con estilo.", "https://www.evogennutrition.com/cdn/shop/files/12_20_drop_hoodie_01.jpg?v=1734657585&width=900", 3, "Sudadera con Capucha de Última Generación", 55.00m, null, "Tallas: S, M, L, XL | Colores: Negro, Azul" },
                    { 5, 11, null, "Camiseta de manga larga sin costuras, ajuste muscular. Ideal para entrenamientos de alto rendimiento.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-ShadowLSMuscleFitTeeGSBlackA1B5B_BB2J_1219_384x.jpg?v=1746634334", 2, "Shadow Seamless Long Sleeve T-Shirt", 36.00m, null, "Tallas: S, M, L, XL | Colores: Meteor Grey, Black, Faded Blue" },
                    { 6, 10, null, "Camiseta acanalada de ajuste muscular, cómoda y estilosa para el gimnasio o el día a día.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-RibbedMuscleT_ShirtGSBlackA2B5T_BB2J_1267_0175_384x.jpg?v=1747813607", 2, "Ribbed T-Shirt", 19.20m, null, "Tallas: S, M, L, XL | Colores: Black, White, Stone Grey Marl" },
                    { 8, 11, null, "Camiseta de manga larga de capa base con ajuste de compresión, ideal para cualquier actividad.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-ElementBaselayerGSStrengthGreenT_ShirtA2B4C_ECJH_0151_384x.jpg?v=1747311667", 2, "Element Baselayer Long Sleeve T-Shirt", 27.00m, null, "Tallas: S, M, L, XL | Colores: White, Dark Grey" },
                    { 9, 12, null, "Tank top con ajuste de compresión, perfecto para entrenamientos intensos y máxima movilidad.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-ElementTankGSCarmineRed_GSBlackA2C4U_RB2R_0225_384x.jpg?v=1747311526", 2, "Element Tank", 19.80m, null, "Tallas: S, M, L, XL | Colores: White, Carmine Red" },
                    { 10, 10, null, "Camiseta de punto urdido, diseño moderno y tejido ligero para el uso diario.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-everywearWarpKnitT_ShirtGSBlackA1B9Y_BB2J_1210_384x.jpg?v=1748293907", 2, "everywear Warp Knit T-Shirt", 77.00m, null, "Tallas: S, M, L, XL | Colores: Black, Tame Grey, Pale Blue" },
                    { 11, 10, null, "Camiseta sin costuras con ajuste muscular, patrón tectónico para un look distintivo.", "https://cdn.shopify.com/s/files/1/0156/6146/files/TectonicSeamlessTShirtGSAsphaltGrey-GSBlackA1B1P-GCWT-0243_ab73a218-b3b7-4261-a921-23d269f2d1df_384x.jpg?v=1733829349", 2, "Tectonic Seamless T Shirt", 22.80m, null, "Tallas: S, M, L, XL | Colores: Asphalt Grey/Black, Cargo Blue/Cool Blue, Trail Green/Classic Green" },
                    { 13, 12, null, "Tank top de compresión Onyx 5.0, diseñado para un soporte y libertad de movimiento superiores.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-Onyx5_0TankGSBlackGSCarmineRedA1B1N_BB4J_5412_A_640x.jpg?v=1746629027", 2, "Onyx 5.0 Tank", 44.00m, null, "Tallas: S, M, L, XL | Colores: Black/Light Grey, Black/Carmine Red, Black/Onyx Grey" },
                    { 14, 11, null, "Camiseta de manga larga sin costuras Onyx 5.0, ajuste de compresión para un rendimiento máximo.", "https://cdn.shopify.com/s/files/1/0156/6146/files/images-Onyx5_0SeamlessLST_ShirtSS25GSBlackGSLightGreyA6A3G_BB23_5385_6e9b9a93-3a9e-4982-88a4-926b484f2df4_640x.jpg?v=1746628707", 2, "Onyx 5.0 Seamless Long Sleeve T-Shirt", 56.00m, null, "Tallas: S, M, L, XL | Colores: Black/Light Grey, Black/Carmine Red, Black/Onyx Grey" },
                    { 17, 10, null, "Camiseta de algodón con gráficos icónicos de Superman. Perfecta para mostrar tu lado heroico.", "https://www.youngla.com/cdn/shop/files/4044_chrome-logo_003_07_01_bryan_lifestyle_a3e17d95-0c82-4af4-9e39-fe1e6292db43.jpg?v=1751418166&width=1000", 1, "4044 - Camiseta Gráfica de Superman", 42.00m, null, "Tallas: S, M, L, XL | Diseños: Logotipo de Chrome, En acción, Legado, Limitado al espacio, La pintura" },
                    { 18, 10, null, "Camisa raglán 3/4 con diseño de Superman, cómoda y con estilo deportivo.", "https://www.youngla.com/cdn/shop/files/8072_black-red_004_07_01_bryan_lifestyle.jpg?v=1750966526&width=300", 1, "8072 - Camisa Raglán 3/4 de Superman", 45.00m, null, "Tallas: S, M, L, XL | Colores: Negro/Rojo, Blanco y negro, Blanco/Azul" },
                    { 20, 12, null, "Camiseta sin mangas estilo cut-off de Superman, perfecta para mostrar tus músculos en el gimnasio.", "https://www.youngla.com/cdn/shop/files/YLA5.2220_da90ba32-ef1c-47ef-8316-47e67fec04de.jpg?v=1751418105&width=200", 1, "3004 - Superman Cut-Offs", 40.00m, null, "Tallas: S, M, L, XL | Diseños: A prueba de balas, Limitado al espacio, La pintura" },
                    { 22, 9, null, "Gorra con el icónico escudo de Superman, un accesorio imprescindible para cualquier fan.", "https://www.youngla.com/cdn/shop/files/YLA5.210.jpg?v=1750886929&width=200", 1, "9092 - Sombrero Escudo de Superman", 36.00m, null, "Talla: Única | Colores: Negro, Gris claro, Rojo" },
                    { 24, 10, null, "Camiseta con diseño de guerrero, ideal para un estilo audaz y motivador.", "https://www.youngla.com/cdn/shop/files/Jerdani_WarriorTee-28.jpg?v=1714602066&width=200", 1, "4118 - Camiseta de Guerrero", 34.00m, null, "Tallas: S, M, L, XL | Colores: Lavado negro, Lavado gris, Lavado azul claro, Lavado rosa" },
                    { 25, 10, null, "Camiseta corta de base, ideal para entrenamientos intensos y para mantener la frescura.", "https://www.youngla.com/cdn/shop/files/4138_forest-green-wash_0016_06_25_johnny_ecomm_5f8af11d-c9b3-4f68-9d6c-48b4bb83a6cf.jpg?v=1719336250&width=200", 1, "4138 - Camiseta Corta de Base", 36.00m, null, "Tallas: XS, S, M, L | Colores: Lavado negro, Lavado marrón, Lavado verde bosque, Lavado gris" },
                    { 28, 14, "30 servicios", "Fórmula completa de aminoácidos esenciales (EAA) para la recuperación y el rendimiento. Ideal intra-entrenamiento.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0005_dr-feaar-v2-peach-guava-front_720x.png?v=1691501874", 4, "DR. FEAAR® - Aminoácido Esencial Completo", 45.00m, "Blue Raspberry, Mango", null },
                    { 33, 14, "300g", "Glutamina de alta pureza para la recuperación muscular y el soporte del sistema inmunológico.", "https://dragonpharmalabs.com/cdn/shop/files/RENDERS-600X600-2023_0018_Mockup---Glutamine-Essentials---Dragon-Pharma---Sem-Fundo1_720x.png?v=1691501674", 4, "GLUTAMINA FERMENTADA", 24.90m, "Sin Sabor", null },
                    { 35, 13, "30 servicios", "L-Carnitina líquida de alta potencia para la quema de grasa y la producción de energía.", "https://dragonpharmalabs.com/cdn/shop/products/600x600-lcarnitine-mango-1_720x.png?v=1695741775", 4, "L-CARNITINA-3000", 34.99m, "Manzana Verde", null },
                    { 37, 13, "90 cápsulas", "CLA de alta pureza para apoyar la composición corporal y la quema de grasa.", "https://www.evogennutrition.com/cdn/shop/files/CLA_0624_bottle_1200x1200_443cdc93-72d0-4f90-a25f-912da81c9c87.png?v=1724779938&width=900", 3, "CLA - Ácido Linoleico Conjugado", 19.95m, null, null },
                    { 41, 14, "200g", "L-Citrulina en polvo para mejorar el flujo sanguíneo, el bombeo muscular y la resistencia.", "https://www.evogennutrition.com/cdn/shop/files/renderCITRULLINE.jpg?v=1727985466&width=900", 3, "Polvo de L-Citrulina", 27.99m, "Sin Sabor", null },
                    { 42, 14, "200g", "Beta-Alanina en polvo para aumentar la resistencia muscular y reducir la fatiga durante el ejercicio.", "https://www.evogennutrition.com/cdn/shop/files/renderBetaAlaninerender02.jpg?v=1727985106&width=900", 3, "Polvo de Beta-Alanina", 19.95m, "Sin Sabor", null },
                    { 44, 13, "30 servicios", "Carnitina líquida de alta calidad para la movilización de grasas y la producción de energía.", "https://www.evogennutrition.com/cdn/shop/files/Carnigen_new_blue_label_grape_24.png?v=1733491617&width=900", 3, "Carnitina Líquida Premium Carnigen", 34.95m, "Mango", null },
                    { 45, 13, "30 servicios", "Termogénico en polvo de acción rápida para quemar grasa y aumentar la energía. Sabor refrescante.", "https://www.evogennutrition.com/cdn/shop/files/LipocideIR_GRAPECC.png?v=1716135069&width=900", 3, "Polvo Termogénico Lipocide IR", 49.95m, "Ponche de Frutas", null },
                    { 47, 10, null, "Camiseta con el logo distintivo de Evogen en forma de arco. Comodidad para el día a día.", "https://www.evogennutrition.com/cdn/shop/files/evogenarcbluetee.jpg?v=1716434815&width=900", 3, "Camiseta de Arco", 35.00m, null, "Tallas: S, M, L, XL | Colores: Negro, Gris" },
                    { 50, 9, null, "Cinturón de cuero resistente de 6mm para soporte lumbar en levantamientos pesados.", "https://www.evogennutrition.com/cdn/shop/products/BeltBackView.jpg?v=1630508778&width=900", 3, "Cinturón de Levantamiento de Cuero Clásico 6mm", 75.00m, null, "Tallas: S, M, L, XL | Color: Negro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "https://example.com/youngla_logo.png");

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "https://example.com/gymshark_logo.png");

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LogoUrl", "Nombre" },
                values: new object[] { "https://example.com/evogen_logo.png", "Evogen" });

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "LogoUrl",
                value: "https://example.com/dragonpharma_logo.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoriaId", "ImagenUrl", "TallaColorInfo" },
                values: new object[] { 8, "https://placehold.co/600x400/000000/FFFFFF?text=Playera+YoungLA", "[{'talla':'M', 'color':'Negro'}, {'talla':'L', 'color':'Gris'}, {'talla':'XL', 'color':'Blanco'}]" });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImagenUrl", "TallaColorInfo" },
                values: new object[] { "https://placehold.co/600x400/1a202c/FFFFFF?text=Hoodie+Gymshark", "[{'talla':'S', 'color':'Verde'}, {'talla':'M', 'color':'Negro'}, {'talla':'L', 'color':'Azul'}]" });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descripcion", "ImagenUrl" },
                values: new object[] { "Fórmula de pre-entreno sin estimulantes diseñada para maximizar el bombeo muscular y la hidratación.", "https://placehold.co/600x400/2f855a/FFFFFF?text=Pre-entreno+Evogen" });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Descripcion", "ImagenUrl" },
                values: new object[] { "Aislado de proteína de suero de leche de rápida absorción, ideal para la recuperación post-entrenamiento.", "https://placehold.co/600x400/805ad5/FFFFFF?text=Proteina+DragonPharma" });
        }
    }
}
