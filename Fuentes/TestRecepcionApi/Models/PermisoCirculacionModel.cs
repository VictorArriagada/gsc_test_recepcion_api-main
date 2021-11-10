using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRecepcionApi.Models
{
    public class PermisoCirculacionModel
    {
        public int id_permiso_circulacion { get; set; }

        public string placa { get; set; }

        public string numeroMotor { get; set; }

        public int codigoResultado { get; set; }

        public string descripcionResultado { get; set; }

        public long tamanioPermiso { get; set; }

    }
}
