using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;
namespace Servicios
{
    public class srvParametros
    {
        public static string ObtenerParametro(string strCodigoParametro)
        {
            DC dc = new DC();

            return (from par in dc.Parametros
                    where par.Codigo == strCodigoParametro
                    select par.Valor).FirstOrDefault();
        }
    }
}
