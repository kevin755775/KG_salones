using KG_aplicaciones_estudiantes.implementaciones;
using KG_aplicaciones_estudiantes.interfaces;
using KG_presentacion_salones.implementaciones;
using KG_presentacion_salones.interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IEstudiantesPresentacion, EstudiantesPresentacion>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();
