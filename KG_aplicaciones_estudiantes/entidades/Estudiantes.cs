using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KG_aplicaciones_estudiantes.entidades
{
    public class Estudiantes
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public decimal Peso { get; set; }
        public int Usuario { get; set; }
        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }


    }
}
