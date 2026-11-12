using KG_aplicaciones_estudiantes.entidades;
using KG_aplicaciones_estudiantes.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KG_servicios_salones.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstudiantesController : ControllerBase
    {
        private IEstudiantesAplicacion IEstudiantesAplicacion;

        public EstudiantesController(IEstudiantesAplicacion IEstudiantesAplicacion)
        {
            this.IEstudiantesAplicacion = IEstudiantesAplicacion;
        }

        [HttpGet]
        public List<Estudiantes> Consultar()
        {
            return this.IEstudiantesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Estudiantes> Buscar(Estudiantes entidad)
        {
            return this.IEstudiantesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Estudiantes Insertar(Estudiantes entidad)
        {
            return this.IEstudiantesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Estudiantes Actualizar(Estudiantes entidad)
        {
            return this.IEstudiantesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Estudiantes Borrar(Estudiantes entidad)
        {
            return this.IEstudiantesAplicacion.Borrar(entidad);
        }
    }
}
