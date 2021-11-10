using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestRecepcionApi.Datos
{
    public class ProveedorConexion
    {
        private readonly string _cadenaConexion;

        public ProveedorConexion(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}
