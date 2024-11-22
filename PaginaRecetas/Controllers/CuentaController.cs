using Microsoft.AspNetCore.Mvc;

namespace PaginaRecetas.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Cuenta()
        {
            return View();
        }

        public IActionResult RecetasPublicadas()
        {
            return View();
        }

        public IActionResult CrearReceta()
        {
            return View();
        }

        public IActionResult EditarReceta()
        {
            return View();
        }
    }
}