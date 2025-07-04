using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimePhysique.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    TallaColorInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Sabor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ropa" },
                    { 2, "Suplementos" },
                    { 3, "Pre-entrenos" },
                    { 4, "Proteínas" },
                    { 5, "Creatinas" },
                    { 6, "Hoodies" },
                    { 7, "Pantalones" },
                    { 8, "Playeras de Compresión" }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "LogoUrl", "Nombre" },
                values: new object[,]
                {
                    { 1, "https://example.com/youngla_logo.png", "YoungLA" },
                    { 2, "https://example.com/gymshark_logo.png", "Gymshark" },
                    { 3, "https://example.com/evogen_logo.png", "Evogen" },
                    { 4, "https://example.com/dragonpharma_logo.png", "Dragon Pharma" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Contenido", "Descripcion", "ImagenUrl", "MarcaId", "Nombre", "Precio", "Sabor", "TallaColorInfo" },
                values: new object[,]
                {
                    { 1, 8, null, "Playera de algodón premium con corte oversize, ideal para el gimnasio o uso casual. Comodidad y estilo.", "https://placehold.co/600x400/000000/FFFFFF?text=Playera+YoungLA", 1, "Playera Oversize 'Signature'", 35.99m, null, "[{'talla':'M', 'color':'Negro'}, {'talla':'L', 'color':'Gris'}, {'talla':'XL', 'color':'Blanco'}]" },
                    { 2, 6, null, "Sudadera con capucha de tejido suave y ajuste atlético. Perfecta para el calentamiento o el día a día.", "https://placehold.co/600x400/1a202c/FFFFFF?text=Hoodie+Gymshark", 2, "Hoodie 'Legacy'", 59.99m, null, "[{'talla':'S', 'color':'Verde'}, {'talla':'M', 'color':'Negro'}, {'talla':'L', 'color':'Azul'}]" },
                    { 3, 3, "20 servicios", "Fórmula de pre-entreno sin estimulantes diseñada para maximizar el bombeo muscular y la hidratación.", "https://placehold.co/600x400/2f855a/FFFFFF?text=Pre-entreno+Evogen", 3, "Pre-entreno EVP-AQ", 45.00m, "Ponche de Frutas", null },
                    { 4, 4, "2 Lbs", "Aislado de proteína de suero de leche de rápida absorción, ideal para la recuperación post-entrenamiento.", "https://placehold.co/600x400/805ad5/FFFFFF?text=Proteina+DragonPharma", 4, "Proteína IsoPhorm", 70.00m, "Chocolate", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
