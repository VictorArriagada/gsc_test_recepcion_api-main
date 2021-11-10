using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRecepcionApi.Models
{
    public class RecepcionModel
    {
        public string usuario { get; set; }

        public string password { get; set; }

        public string placa { get; set; }

        public string numeroMotor { get; set; }

        public int codigoResultado { get; set; }

        public string descripcionResultado { get; set; }

        public string permiso { get; set; }

        public long tamanioPermiso { get; set; }

    }
}
