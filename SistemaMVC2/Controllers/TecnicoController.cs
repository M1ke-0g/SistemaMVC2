using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVC2.Models;

namespace SistemaMVC2.Controllers
{
    public class TecnicoController : Controller
    {
        // GET: Tecnico
        public ActionResult Index()
        {
            List<Tecnico> tecnicos = new List<Tecnico>()
            {
                new Tecnico { TecnicoId = 1, Nombre = "Carlos", Apellidos = "Ruiz Sánchez", NIF = "11223344C", Movil = "666-1111" },
                new Tecnico { TecnicoId = 2, Nombre = "Ana", Apellidos = "Fernández López", NIF = "44332211D", Movil = "666-2222" }
            };
            return View(tecnicos);
        }

        // GET: Tecnico/Details/5
        public ActionResult Details(int id)
        {
            Tecnico tecnico = new Tecnico { TecnicoId = id, Nombre = "Carlos", Apellidos = "Ruiz Sánchez", NIF = "11223344C", Movil = "666-1111" };
            return View(tecnico);
        }

        // GET: Tecnico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnico/Create
        [HttpPost]
        public ActionResult Create(Tecnico tecnico)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tecnico/Edit/5
        public ActionResult Edit(int id)
        {
            Tecnico tecnico = new Tecnico { TecnicoId = id, Nombre = "Carlos", Apellidos = "Ruiz Sánchez", NIF = "11223344C", Movil = "666-1111" };
            return View(tecnico);
        }

        // POST: Tecnico/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tecnico tecnico)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tecnico/Delete/5
        public ActionResult Delete(int id)
        {
            Tecnico tecnico = new Tecnico { TecnicoId = id, Nombre = "Carlos", Apellidos = "Ruiz Sánchez", NIF = "11223344C", Movil = "666-1111" };
            return View(tecnico);
        }

        // POST: Tecnico/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
