using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class srvActividades
    {
        public static bool TrenContieneHuecosActividades(int idTren,DateTime dteFechaPartida)
        {
            DC dc = new DC();

            //Tren_Actividades oTrenActividad = dc.Tren_Actividades.SingleOrDefault(j => j.idTren == idTren).OrderByDescending(k => k.FechaInicio).Take(1).SingleOrDefault();
            Tren_Actividades oTrenActividad = dc.Tren_Actividades.Where(j => j.idTren == idTren).OrderByDescending(k => k.FechaInicio).Take(1).SingleOrDefault();

            if (((DateTime)oTrenActividad.FechaInicio).AddMinutes(Convert.ToDouble(oTrenActividad.Duracion)) >= dteFechaPartida)
                return false;    
            return true;
        }


        public static void AgregarActividadTren(Tren_Actividades oTrenActividad)
        {
            DC dc = new DC();

            dc.Tren_Actividades.InsertOnSubmit(oTrenActividad);
            dc.SubmitChanges();
        }

        public static IQueryable<Actividades> ObtenerActividades()
        {
            DC dc = new DC();
            return dc.Actividades.OrderBy(j=>j.Descripcion);
        }

        public static IQueryable<Actividades_Patio> ObtenerActividadesPatio()
        {
            DC dc = new DC();
            return dc.Actividades_Patio.OrderBy(j => j.Descripcion);
        }

        public static IQueryable<Tren_Actividades> ObtenerActividades(int idTren)
        {
            DC dc = new DC();
            return (from x in dc.Tren_Actividades
                    where x.idTren == idTren
                    select x);

        }

    }
}
