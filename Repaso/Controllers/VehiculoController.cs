using Repaso.Dato;
using Repaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repaso.Controllers
{
    public class VehiculoController : Controller
    {
        VehiculoAdmin admin = new VehiculoAdmin();
        // GET: Vehiculo
        public ActionResult Index()
        {
            IEnumerable<Vehiculo> lista = admin.Consultar();
            ViewBag.mensaje = "";
            return View(lista);
        }

        public ActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }

        public ActionResult Nuevo(Vehiculo modelo)
        {
            admin.Guardar(modelo);
            ViewBag.mensaje = "Vehiculo Guardado";
            return View("Guardar",modelo);
        }

        public ActionResult Detalle(int id=0)
        {
            ViewBag.mensaje = "";
            Vehiculo modelo = admin.Consultar(id);
            return View(modelo);
        }

        public ActionResult Modificar(int id=0)
        {
            ViewBag.mensaje = "";
            Vehiculo modelo = admin.Consultar(id);
            return View(modelo);
        }
        
        public ActionResult Actualizar(Vehiculo modelo)
        {
            admin.Modificar(modelo);
            ViewBag.mensaje = "Vehiculo Modificado";
            return View("Modificar", modelo);
        }

        public ActionResult Eliminar(int id = 0)
        {
            Vehiculo modelo = new Vehiculo()
            {
                Id = id
            };
            admin.Eliminar(modelo);
            IEnumerable<Vehiculo> lista = admin.Consultar();
            ViewBag.mensaje = "Vehiculo Eliminado";
            return View("Index",lista);
        }
    }
}