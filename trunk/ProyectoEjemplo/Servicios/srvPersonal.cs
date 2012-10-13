using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class srvPersonal
    {
        public static Personal ObtenerPersonal(int idPersonal)
        {
            DC dc = new DC();
            return (from x in dc.Personal
                    where x.Legajo == idPersonal
                    select x).FirstOrDefault();
        }

        public static IQueryable<Personal> ListarPersonal()
        {
            DC dc = new DC();
            return dc.Personal.OrderBy(j=>j.Legajo);
        }

        public static IQueryable<Personal> ListarPersonalActivo(bool blnSoloDisponible)
        {
            DC dc = new DC();
            if(blnSoloDisponible)
                return (from per in dc.Personal
                        where per.idestado == 460 && per.Estado == 1
                        orderby per.Legajo
                        select per);
            else
                return (from per in dc.Personal
                        where per.Estado == 1
                        orderby per.Legajo
                        select per);
        }

    }
}
