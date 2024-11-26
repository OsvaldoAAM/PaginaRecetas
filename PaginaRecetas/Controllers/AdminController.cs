﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaginaRecetas.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Estadisticas()
        {
            return View();
        }
        public ActionResult GestionUs()
        {
            return View();
        }
        public ActionResult GestionFlt()
        {
            return View();
        }
        public ActionResult GestionElDest()
        {
            return View();
        }
        public ActionResult Reportes()
        {
            return View();
        }
        public ActionResult RectNuevas()
        {
            return View();
        }

        public ActionResult FiltroTipo()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
