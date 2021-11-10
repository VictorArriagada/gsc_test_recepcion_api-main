using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRecepcionApi.Datos;
using TestRecepcionApi.Models;

namespace TestRecepcionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionPermisosController : ControllerBase
    {
        private readonly PermisosCirculacionServicio _permisosCirculacionServicio;
        private readonly ILogger<RecepcionPermisosController> _log;
        private IWebHostEnvironment _hostEnvironment;

        public RecepcionPermisosController(PermisosCirculacionServicio permisosCirculacionServicio, ILogger<RecepcionPermisosController> log, IWebHostEnvironment environment)
        {
            _permisosCirculacionServicio = permisosCirculacionServicio;
            _log = log;
            _hostEnvironment = environment;
        }

        [HttpPost]
        public RespuestaRecepcionModel Post(RecepcionModel permiso)
        {
            //string usuario, string password, string placa, string numeroMotor, string codigoResultado, string descripcionResultado, string permiso, long tamanioPermiso

            RespuestaRecepcionModel respuesta = new RespuestaRecepcionModel();

            respuesta.codigoRespuesta = 0;
            respuesta.respuesta = "";
            respuesta.fecha = DateTime.Now;

            PermisoCirculacionInsModel nuevoPermiso = new PermisoCirculacionInsModel(){
                placa = permiso.placa,
                numeroMotor = permiso.numeroMotor,
                codigoResultado = permiso.codigoResultado,
                descripcionResultado = permiso.descripcionResultado,
                tamanioPermiso = permiso.tamanioPermiso
            };

            var resultado = _permisosCirculacionServicio.Ins(nuevoPermiso);

            if (permiso.tamanioPermiso > 0 && resultado.resultado == 1)
            {
                string archivo = System.IO.Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", resultado.id.ToString() + ".PDF");

                System.IO.File.WriteAllBytes(archivo, Convert.FromBase64String(permiso.permiso));
            }

            return respuesta;
        }

    }
}
