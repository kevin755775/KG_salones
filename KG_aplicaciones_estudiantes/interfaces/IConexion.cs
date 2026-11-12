using KG_aplicaciones_estudiantes.entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace KG_aplicaciones_estudiantes.interfaces
{
    public interface IConexion
    {
        DbSet<Estudiantes>? Estudiantes { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
