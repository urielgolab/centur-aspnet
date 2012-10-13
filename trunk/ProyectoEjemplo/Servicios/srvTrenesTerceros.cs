using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;

using Datos;

namespace Servicios
{
    public class srvTrenesTerceros
    {
        public static TrenesTercero ObtenerTrenTercero(int idTrenTercero)
        {
            DC dc = new DC();
            
            return (from x in dc.TrenesTerceros
                    where x.idTrenTercero == idTrenTercero
                    select x).FirstOrDefault();
        }

           
        
        
    }
}
