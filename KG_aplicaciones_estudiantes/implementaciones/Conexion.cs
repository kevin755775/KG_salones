using KG_aplicaciones_estudiantes.entidades;
using KG_aplicaciones_estudiantes.interfaces;
using KG_aplicaciones_estudiantes.nucleo;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KG_aplicaciones_estudiantes.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.StringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Estudiantes>? Estudiantes { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
    }
}
