using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class srvObservacionesPlaneamiento
    {
        public static IQueryable<Observaciones> ListarObservaciones()
        {
            DC dc = new DC();
            return dc.Observaciones;
        }

    }
}
