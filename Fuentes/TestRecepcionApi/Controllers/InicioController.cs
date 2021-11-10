using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRecepcionApi.Datos;

namespace TestRecepcionApi.Controllers
{
    public class InicioController : Controller
    {
        private readonly PermisosCirculacionServicio _permisosCirculacionServicio;
        private readonly ILogger<InicioController> _log;

        public InicioController(PermisosCirculacionServicio permisosCirculacionServicio, ILogger<InicioController> log)
        {
            _permisosCirculacionServicio = permisosCirculacionServicio;
            _log = log;
        }

        public IActionResult Index()
        {
            var permisos = _permisosCirculacionServicio.Sel();

            return View(permisos);
        }
    }
}
