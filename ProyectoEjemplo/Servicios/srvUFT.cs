using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;
namespace Servicios
{
    public class srvUFT
    {
        public static IQueryable<UFTs> ListarUFT()
        {
            DC dc = new DC();
            return dc.UFTs;
        }
        public static UFTs ObtenerUFT(int idUFT)
        {
            DC dc = new DC();
            return (from x in dc.UFTs
                    where x.idUFT == idUFT
                    select x).FirstOrDefault();
        }
        public static IQueryable<UFTs> ListarUFTActivas(bool blnSoloDisponibles)
        {
            DC dc = new DC();
            if(blnSoloDisponibles)
                return (from uft in dc.UFTs
                    where uft.Estado == 1 && uft.idEstado == 270
                    orderby uft.idFisico
                    select uft);
            else
                return (from uft in dc.UFTs
                        where uft.Estado == 1
                        orderby uft.idFisico
                        select uft);
        }
    }
}
