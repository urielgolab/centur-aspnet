using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class srvDivisiones
    {
        public static Divisiones ObtenerDivision(int idDivision)
        {
            DC dc = new DC();
            return (from x in dc.Divisiones
                    where x.idDivision == idDivision
                    select x).FirstOrDefault();
        }


        public static IQueryable<Divisiones> ListarDivisiones()
        {
            DC dc = new DC();
            return dc.Divisiones.Where(m => m.Estado == 1).OrderBy(division => division.Nombre);
        }

        public static IQueryable<Estaciones> ListarEstaciones()
        {
            DC dc = new DC();
            return dc.Estaciones.Where(m => m.Estado == 1);
        }

        public static IQueryable<Estaciones> ObtenerEstacionesPorDivision(int idDivision)
        {
            DC dc = new DC();
            return (from det in dc.Divisiones_Detalle
                    //join est in dc.Estaciones on det.idEstacion equals est.idEstacion
                    where det.idDivision==idDivision
                    orderby det.Estaciones.Nombre
                    select det.Estaciones
                    );
        }

        public static Estaciones ObtenerEstacion(int idEstacion)
        {
            DC dc = new DC();
            return (from x in dc.Estaciones
                    where x.idEstacion == idEstacion
                    select x).FirstOrDefault();
        }
        public static string ObtenerNombreEstacion(int idEstacion)
        {
            string nombre;
            DC dc = new DC();
            nombre = (from x in dc.Estaciones
                      where x.idEstacion == idEstacion
                      select x.Nombre).FirstOrDefault();
            return nombre;
        }
    }
}
