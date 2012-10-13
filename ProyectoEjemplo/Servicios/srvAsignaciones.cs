using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;

using Datos;

namespace Servicios
{
    public class srvAsignaciones
    {
        public static List<int> ObtenerAsignaciones(int idTren, string entidad)
        {
            DC dc = new DC();
            List<int> oReturnList=new List<int>();
            if (entidad == "Equipos")
            {               
                foreach(TrenObtenerEquiposAsignadosResult Tren in dc.TrenObtenerEquiposAsignados(idTren))
                {
                    oReturnList.Add(int.Parse(Tren.idEquipo.ToString()));                    
                    
                }               
            }

            if(entidad=="UFT")
            {
                foreach (TrenObtenerUFTAsignadosResult UFT in dc.TrenObtenerUFTAsignados(idTren))
                {
                    oReturnList.Add(int.Parse(UFT.idUFT.ToString()));

                }                             
            }

            return oReturnList;
        }

        public static int? ObtenerUltimaAsignacion(int idTren, string strFuncionPrincipal)
        {
            //Trae el último idAsignacion del tren. No verifica desasginados. 
            //Asume que la función principal no coincide entre las entidades UFT, Equipo y Personal

            DC dc = new DC();

            Asignaciones oAsignacion;
            if ((oAsignacion = dc.Asignaciones.OrderByDescending(j => j.idAsignacion).FirstOrDefault(m =>
                                m.idTren == idTren &&
                                m.Funcion == strFuncionPrincipal &&
                                m.Operacion == "ASI" &&
                                (m.Equipos!=null || m.UFTs!=null || m.Personal!=null)
                                )) == null)
                return null;
            else
                return (oAsignacion.idEquipo!=null?(int?)oAsignacion.idEquipo:(oAsignacion.idUFT!=null?oAsignacion.idUFT:oAsignacion.idConductor));

        }
      
    }
}
