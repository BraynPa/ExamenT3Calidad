using Microsoft.AspNetCore.Mvc;
using Pajares_T3.Web.Models;
using Pajares_T3.Web.Repository;
using Pajares_T3.Web.Service;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Pajares_T3.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        

        private readonly IUsuarioRepository _context;
        private readonly ICookieAuthService _cookieAuthService;
        
        [Obsolete]
        public HomeController(IUsuarioRepository _context, ICookieAuthService _cookieAuthService)
        {
            this._context = _context;
            this._cookieAuthService = _cookieAuthService;
            _cookieAuthService.SetHttpContext(HttpContext);
        }
        public IActionResult Index()
        {

            _cookieAuthService.SetHttpContext(HttpContext);
            ViewBag.Nombre = _cookieAuthService.LoggedUser().Username;
            ViewBag.Historial = _context.ListaHistorial();
                return View();

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Especie = _context.ListaEspecies();
            ViewBag.Raza = _context.ListaRazas();
            ViewBag.Sexo = _context.ListaSexos();
            return View(new Historial());

        }
        [HttpPost]
        public IActionResult Create(Historial historial)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaRegistro = historial.FechaDeRegistro;
            DateTime fechaNacimiento = historial.FechaNacimientoMascota;
            bool valido = false;
            if (new EmailAddressAttribute().IsValid(historial.CorreoDuenio))
            {
                valido = true;
            }
            if (DateTime.Compare(fechaRegistro,fechaActual) > 0)
            {
                ModelState.AddModelError("fechaRegistro", "Fecha No valida");
            }
            if (DateTime.Compare(fechaNacimiento,fechaActual) > 0)
            {
                ModelState.AddModelError("fechaNacimiento", "Fecha No valida");
            }
            if (valido == false)
            {
                ModelState.AddModelError("Correo", "Correo No valido");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Especie = _context.ListaEspecies();
                ViewBag.Raza = _context.ListaRazas();
                ViewBag.Sexo = _context.ListaSexos();
                return View("Create", historial);
            }

            _context.RegistrarHistorial(historial);
            return RedirectToAction("Index");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}