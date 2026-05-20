using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SistemaMVC2.Models;

namespace SistemaMVC2.Controllers
{
    public class ReparacionController : Controller
    {
        static List<Reparacion> lista = new List<Reparacion>()
        {
            new Reparacion
            {
                Id = 1,
                Descripcion = "Reparación de compresor",
                Fecha = DateTime.Now,
                Hora = "09:00",
                Coste = 250.00m,
                Garantia = "1 año"
            },

            new Reparacion
            {
                Id = 2,
                Descripcion = "Cambio de motor",
                Fecha = DateTime.Now.AddDays(-1),
                Hora = "14:30",
                Coste = 180.00m,
                Garantia = "6 meses"
            }
        };

        public ActionResult Index()
        {
            return View(lista);
        }

        public ActionResult Details(int id)
        {
            var reparacion = lista.Find(x => x.Id == id);

            return View(reparacion);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reparacion reparacion)
        {
            reparacion.Id = lista.Max(x => x.Id) + 1;

            lista.Add(reparacion);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var reparacion = lista.Find(x => x.Id == id);

            return View(reparacion);
        }

        [HttpPost]
        public ActionResult Edit(Reparacion reparacion)
        {
            var dato = lista.Find(x => x.Id == reparacion.Id);

            dato.Descripcion = reparacion.Descripcion;
            dato.Fecha = reparacion.Fecha;
            dato.Hora = reparacion.Hora;
            dato.Coste = reparacion.Coste;
            dato.Garantia = reparacion.Garantia;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var reparacion = lista.Find(x => x.Id == id);

            return View(reparacion);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var reparacion = lista.Find(x => x.Id == id);

            lista.Remove(reparacion);

            return RedirectToAction("Index");
        }
    }
}