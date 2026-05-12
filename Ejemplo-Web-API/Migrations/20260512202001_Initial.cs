using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejemplo_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ocupacion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
