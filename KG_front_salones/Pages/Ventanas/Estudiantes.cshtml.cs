using KG_aplicaciones_estudiantes.entidades;
using KG_aplicaciones_estudiantes.interfaces;
using KG_aplicaciones_estudiantes.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KG_presentacion_salones.interfaces;

namespace KG_front_salones.Pages.Ventanas
{
    public class EstudiantesModel : PageModel
    {
        private IEstudiantesPresentacion IEstudiantesPresentacion;

        public EstudiantesModel(IEstudiantesPresentacion IEstudiantesPresentacion)
        {
            this.IEstudiantesPresentacion = IEstudiantesPresentacion;
            this.Filtro = new Estudiantes();
        }

        [BindProperty] public List<Estudiantes> Lista { get; set; }
        [BindProperty] public Estudiantes? Filtro { get; set; }
        [BindProperty] public Estudiantes? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Nombre = Filtro!.Nombre ?? "";
                Lista = this.IEstudiantesPresentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new Estudiantes();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IEstudiantesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IEstudiantesPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.IEstudiantesPresentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}
