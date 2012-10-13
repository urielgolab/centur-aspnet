using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class srvMensajes
    {
        public static Mensajes ObtenerMensaje(int idMensaje)
        {
            DC dc = new DC();
            return (from x in dc.Mensajes
                    where x.idMensaje == idMensaje
                    select x).FirstOrDefault();
        }

        public static IQueryable<Mensajes> ObtenerMensajes(char? chrSentido,string strEstado,DateTime? dteFechaDesde,DateTime? dteFechaHasta)
        {
            DC dc = new DC();
            var varMensajes= from Mensaje in dc.Mensajes select Mensaje;

            if(strEstado!=null)
                return varMensajes = varMensajes.Where(m => m.Estado == strEstado);
            if(chrSentido!=null)
                varMensajes = varMensajes.Where(m => m.Sentido == chrSentido);
            if(dteFechaDesde!=null)
                varMensajes = varMensajes.Where(m => m.Fecha >= dteFechaDesde);
            if(dteFechaHasta!=null)
                varMensajes = varMensajes.Where(m => m.Fecha <= dteFechaHasta);
            return varMensajes.OrderByDescending(m=>m.Fecha);
        }


        public static void GuardarMensaje(int idEquipo, Boolean blnMostrarMensaje,int intNroBeeps, int intBackLight,int intPrioridad, string strMensaje, int idUsuario)
        {
            string[] strMensajeFormateado = FormatearMensaje(strMensaje) ;

            DC dc = new DC();
            Mensajes msg = new Mensajes();
            msg.idEquipo = idEquipo;
            msg.Fecha = DateTime.Now;
            msg.Texto = "MSG " + (blnMostrarMensaje ? "1" : "0") + " " + intPrioridad.ToString() + " " + intBackLight.ToString().PadLeft(2, '0') + " " + intNroBeeps.ToString() +
                               " " + strMensajeFormateado[0] + " " + strMensajeFormateado[1] + " " + strMensajeFormateado[2] + " " + strMensajeFormateado[3];
            msg.idDivision = srvEquipos.ObtenerEquipo(idEquipo).idDivision;
            msg.Estado = "Pendiente";
            msg.Sentido = 'S';

            dc.Mensajes.InsertOnSubmit(msg);
            dc.SubmitChanges();
        }

        public static IQueryable<Mensajes_Precargados> ObtenerMensajesPrecargados()
        {
            DC dc = new DC();
            return dc.Mensajes_Precargados;
        }
 
        public static string[] FormatearMensaje(string strMensaje)
        {
            int intI,intLinea=0;
            string[] strSalida={},strLineas = strMensaje.Split(Environment.NewLine.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string strLinea in strLineas)
            {
                intLinea= strSalida.Length;
                intI = 0;
                while (strLinea.Substring(intI*20).Length > 20)
                {
                    Array.Resize(ref strSalida, strSalida.Length+1);
                    strSalida[intLinea+intI] = strLinea.Substring((intI * 20), 20 + (intI * 20));
                    intI++;
                }
                Array.Resize(ref strSalida, strSalida.Length + 1);
                strSalida[intLinea+intI] = strLinea.Substring(intI * 20);
            }
            intLinea = 0;

            if (strSalida.Length < 4)
                Array.Resize(ref strSalida, 5 - strSalida.Length);

            foreach (string strLinea in strSalida)
                strSalida[intLinea++] = ((strLinea==null)?("".PadRight(20, (char)32)):strLinea.PadRight(20, (char)32)); //agrego espacios, no funciona el ' '.
            return strSalida;
        }

        public static Boolean ValidarMensaje(string strMensaje)
        {
            string[] strMensajeFormateado = FormatearMensaje(strMensaje);

            if (strMensajeFormateado.Length > 4)
                return false;
            return true;
        }


        public static IQueryable<MSG> ListarMSG()
        {
            DC dc = new DC();
            return dc.MSG;
        }

    }
}
