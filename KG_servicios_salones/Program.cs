
using KG_aplicaciones_estudiantes.implementaciones;
using KG_aplicaciones_estudiantes.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IEstudiantesAplicacion, EstudiantesAplicacion>();



var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();
