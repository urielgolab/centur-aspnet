using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class srvCausas
    {
        public static IQueryable<Causas_Detenciones> ListarCausasDetenciones()
        {
            DC dc = new DC();
            return dc.Causas_Detenciones;
        }
    }
}
