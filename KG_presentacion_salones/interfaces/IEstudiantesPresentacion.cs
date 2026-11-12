
using KG_aplicaciones_estudiantes.entidades;

namespace KG_presentacion_salones.interfaces
{
    public interface IEstudiantesPresentacion
    {
        Estudiantes Insertar(Estudiantes entidad);
        Estudiantes Actualizar(Estudiantes entidad);
        List<Estudiantes> Consultar();
        List<Estudiantes> Buscar(Estudiantes entidad);
        Estudiantes Borrar(Estudiantes entidad);
    }
}