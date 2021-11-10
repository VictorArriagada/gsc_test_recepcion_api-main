using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestRecepcionApi.Models;

namespace TestRecepcionApi.Datos
{
    public class PermisosCirculacionServicio
    {
        private readonly ProveedorConexion _proveedor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<PermisosCirculacionServicio> _log;

        public PermisosCirculacionServicio(ProveedorConexion proveedor, ILogger<PermisosCirculacionServicio> log, IHttpContextAccessor httpContextAccessor)
        {
            _proveedor = proveedor;
            _httpContextAccessor = httpContextAccessor;
            _log = log;
        }

        public RespuestaGenericaModel Ins(PermisoCirculacionInsModel permiso)
        {
            string sp = "PA_Ins_Permiso_Circulacion";

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();

                _log.LogInformation($"Ejecutando {sp} {permiso}");

                RespuestaGenericaModel respuesta = db.QueryFirst<RespuestaGenericaModel>(sp, permiso, null, null, CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return new RespuestaGenericaModel() { resultado = 3, id = null, mensaje_error = e.Message };
            }

        }

        public IEnumerable<PermisoCirculacionModel> Sel()
        {
            string sp = "PA_Sel_Permiso_Circulacion";

            _log.LogInformation($"Ejecutando {sp}");

            try
            {
                using var db = _proveedor.GetDbConnection();
                db.Open();
                var respuesta = db.Query<PermisoCirculacionModel>(sp, null, null, true, null, CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception e)
            {
                _log.LogError($"{e}");

                return new List<PermisoCirculacionModel>().AsEnumerable();
            }

        }

    }
}
