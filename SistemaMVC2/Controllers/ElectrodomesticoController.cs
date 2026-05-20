using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVC2.Models;

namespace SistemaMVC2.Controllers
{
    public class ElectrodomesticoController : Controller
    {
        // GET: Electrodomestico
        public ActionResult Index()
        {
            List<Electrodomestico> electrodomesticos = new List<Electrodomestico>()
            {
                new Electrodomestico { ElectrodomesticoId = 1, Tipo = "Nevera", Modelo = "RF-2024", Precio = 450.00m },
                new Electrodomestico { ElectrodomesticoId = 2, Tipo = "Lavadora", Modelo = "LW-500", Precio = 320.00m }
            };
            return View(electrodomesticos);
        }

        // GET: Electrodomestico/Details/5
        public ActionResult Details(int id)
        {
            Electrodomestico electrodomestico = new Electrodomestico { ElectrodomesticoId = id, Tipo = "Nevera", Modelo = "RF-2024", Precio = 450.00m };
            return View(electrodomestico);
        }

        // GET: Electrodomestico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Electrodomestico/Create
        [HttpPost]
        public ActionResult Create(Electrodomestico electrodomestico)
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

        // GET: Electrodomestico/Edit/5
        public ActionResult Edit(int id)
        {
            Electrodomestico electrodomestico = new Electrodomestico { ElectrodomesticoId = id, Tipo = "Nevera", Modelo = "RF-2024", Precio = 450.00m };
            return View(electrodomestico);
        }

        // POST: Electrodomestico/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Electrodomestico electrodomestico)
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

        // GET: Electrodomestico/Delete/5
        public ActionResult Delete(int id)
        {
            Electrodomestico electrodomestico = new Electrodomestico { ElectrodomesticoId = id, Tipo = "Nevera", Modelo = "RF-2024", Precio = 450.00m };
            return View(electrodomestico);
        }

        // POST: Electrodomestico/Delete/5
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
