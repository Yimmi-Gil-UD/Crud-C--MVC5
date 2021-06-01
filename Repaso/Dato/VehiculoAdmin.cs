using Repaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repaso.Dato
{
    public class VehiculoAdmin
    {
        public IEnumerable<Vehiculo> Consultar()
        {
            using (RepasoDBEntities contexto = new RepasoDBEntities())
            {
                return contexto.Vehiculo.AsNoTracking().ToList(); // para no quedar con copia de memoria

            }
        }
        

        // Guardar un vehiculo en la base de datos
        public void Guardar(Vehiculo modelo)
        {
            using (RepasoDBEntities contexto = new RepasoDBEntities())
            {
                contexto.Vehiculo.Add(modelo);
                contexto.SaveChanges();
            }
        }

        //Consulta el vehiculo por id
        public Vehiculo Consultar(int id)
        {
            using (RepasoDBEntities contexto = new RepasoDBEntities())
            {
                return contexto.Vehiculo.FirstOrDefault(v => v.Id == id);
            }
        }

        //modificar
        public void Modificar(Vehiculo modelo)
        {
            using (RepasoDBEntities contexto = new RepasoDBEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        //Eliminar Vehiculo
        public void Eliminar(Vehiculo modelo)
        {
            using (RepasoDBEntities contexto = new RepasoDBEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}