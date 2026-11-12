using KG_aplicaciones_estudiantes.entidades;
using KG_aplicaciones_estudiantes.interfaces;
using KG_presentacion_salones.interfaces;



namespace KG_presentacion_salones.implementaciones
{
    public class EstudiantesPresentacion : IEstudiantesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public EstudiantesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Estudiantes Actualizar(Estudiantes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Estudiantes>(
                "Estudiantes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Estudiantes Borrar(Estudiantes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Estudiantes>(
                "Estudiantes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Estudiantes> Buscar(Estudiantes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Estudiantes>>(
                "Estudiantes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Estudiantes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Estudiantes>>(
                "Estudiantes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Estudiantes Insertar(Estudiantes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Estudiantes>(
                "Estudiantes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Estudiantes entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Edad <= 0.0m ||
                entidad.Peso <= 0.0m;

        }
    }
}