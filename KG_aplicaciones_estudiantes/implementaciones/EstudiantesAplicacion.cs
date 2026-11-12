
using KG_aplicaciones_estudiantes.entidades;
using KG_aplicaciones_estudiantes.interfaces;
using Microsoft.EntityFrameworkCore;

namespace KG_aplicaciones_estudiantes.interfaces
{
    public class EstudiantesAplicacion : IEstudiantesAplicacion
    {
        private IConexion IConexion;

        public EstudiantesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Estudiantes Actualizar(Estudiantes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Estudiantes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Descripcion = "Se actualizo un estudiante",
                    Fecha = DateTime.Now
                }
                );
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Estudiantes Borrar(Estudiantes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Estudiantes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Estudiantes> Buscar(Estudiantes entidad)
        {
            return this.IConexion.Estudiantes!
                .Include(x => x._Usuario)
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))

                .ToList();
        }

        public List<Estudiantes> Consultar()
        {
            return this.IConexion.Estudiantes!.Include(x => x._Usuario).Take(5).ToList();
        }

        public Estudiantes Insertar(Estudiantes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Estudiantes!.Add(entidad!);
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Descripcion = "Se añadio un nuevo estudiante",
                    Fecha = DateTime.Now
                }
                );
            this.IConexion.SaveChanges();
            return entidad;
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