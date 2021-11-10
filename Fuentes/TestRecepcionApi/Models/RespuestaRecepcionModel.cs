using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRecepcionApi.Models
{
    public class RespuestaRecepcionModel
    {
        public int codigoRespuesta { get; set; }

        public string respuesta { get; set; }

        public DateTime fecha { get; set; }

    }
}
