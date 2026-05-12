using Ejemplo_Web_API.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


/*
 * Crear variable para la cadena de conexion, que se enceuetnra en el archivo appsettings.json
 */
var conectionString = builder.Configuration.GetConnectionString("Connection");

/*
 * Registrar servicio para conexion
 */
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(conectionString));

/*
Se registran los servicios para los controladores.
Esto permite que la API reconozca y gestione peticiones HTTP.
*/
builder.Services.AddControllers();

/*
Se registra OpenAPI para generar la documentación de la API.
*/
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    /*
    Expone el documento OpenAPI en:
    /openapi/v1.json
    */
    app.MapOpenApi();

    /*
    Habilita la interfaz visual de Swagger UI.
    */
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Ejemplo-Web-API v1");
    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();