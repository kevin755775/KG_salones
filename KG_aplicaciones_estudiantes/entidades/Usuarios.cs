using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KG_aplicaciones_estudiantes.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }
        public string? Contraseña { get; set; }

        [NotMapped] public List<Estudiantes>? Estudiantes { get; set; }
    }
}
