using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVC2.Models;

namespace SistemaMVC2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente { ClienteId = 1, Nombre = "Juan", Apellidos = "Pérez García", DNI = "12345678A", Direccion = "Calle Principal 123", Telefono = "555-1234" },
                new Cliente { ClienteId = 2, Nombre = "María", Apellidos = "López Martínez", DNI = "87654321B", Direccion = "Avenida Central 456", Telefono = "555-5678" }
            };
            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            Cliente cliente = new Cliente { ClienteId = id, Nombre = "Juan", Apellidos = "Pérez García", DNI = "12345678A", Direccion = "Calle Principal 123", Telefono = "555-1234" };
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
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

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            Cliente cliente = new Cliente { ClienteId = id, Nombre = "Juan", Apellidos = "Pérez García", DNI = "12345678A", Direccion = "Calle Principal 123", Telefono = "555-1234" };
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            Cliente cliente = new Cliente { ClienteId = id, Nombre = "Juan", Apellidos = "Pérez García", DNI = "12345678A", Direccion = "Calle Principal 123", Telefono = "555-1234" };
            return View(cliente);
        }

        // POST: Cliente/Delete/5
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
