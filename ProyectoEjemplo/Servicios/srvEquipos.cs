using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Datos;
using System.IO;

namespace Servicios
{
    public class srvEquipos
    {
        public static Equipos ObtenerEquipo(int idEquipo)
        {
            DC dc = new DC();
            return (from x in dc.Equipos
                    where x.idEquipo == idEquipo
                    select x).FirstOrDefault();
        }

        public static IQueryable<Equipos> ListarEquipos()
        {
            DC dc = new DC();
            return dc.Equipos;
        }

        public static IQueryable<Equipos> ListarEquiposActivos(bool blnSoloDisponibles)
        {
            DC dc = new DC();
            if(blnSoloDisponibles)
                return (from eq in dc.Equipos
                        where eq.idEstadoTren == 170 && eq.Estado == 1
                        orderby eq.idFisico
                        select eq);
            else
                return (from eq in dc.Equipos
                        where eq.Estado==1
                        orderby eq.idFisico
                        select eq);
        }

        public static IQueryable MostrarEquipos()
        {

            return (from x in srvEquipos.ListarEquipos()
                    where x.idGPS>0 && x.Equipos_GPS.Estado==1
                     select new
                     {
                         Equipo = x.idEquipo,
                         Progresiva = x.Progresiva,
                         Velocidad = x.Equipos_GPS.Velocidad,
                         Maxima = x.VelocidadCarga,
                         Reporte = x.Equipos_GPS.FechaServer,
                         //Tren = x.Trenes.NroTren,
                         GPS = x.idGPS,
                         Nombre = x.DescripcionAbreviada,
                         Division = srvDivisiones.ObtenerDivision(Convert.ToInt32(x.idDivision)).Nombre,
                         Via=x.idVia
                     });
        }

        //ascendente = false es descendente
        public static Point CalcularXY(Divisiones division, decimal progresiva, int via, bool ascendente,int xInicial, int yInicial)
        {
            foreach (Divisiones_Tramos t in division.Divisiones_Tramos.Where(d => d.idVia == via))
            {
                if ((progresiva >= t.ProgresivaDesde && progresiva <= t.ProgresivaHasta)
                    || (progresiva <= t.ProgresivaDesde && progresiva >= t.ProgresivaHasta))
                {
                    int x = 0;
                    int y = 0;
                    if (progresiva >= t.ProgresivaDesde && progresiva <= t.ProgresivaHasta)
                        x = Convert.ToInt32(t.X + (
                            ((progresiva - t.ProgresivaDesde) / (t.ProgresivaHasta - t.ProgresivaDesde))
                            * t.Width));
                    else
                        x = Convert.ToInt32(t.X + (
                            ((t.ProgresivaDesde-progresiva) / (t.ProgresivaDesde-t.ProgresivaHasta))
                            * t.Width));

                    if (ascendente == true)
                    {
                        y = t.Y - 54;
                    }
                    else
                    {
                        //Si es descendente le resto a x el ancho del boton
                        x = x - 55;
                        y = t.Y + 50;
                    }

                    return new System.Drawing.Point(x-xInicial, y-yInicial);
                }

            }
            return new System.Drawing.Point(0, -2000);
        }

        public static string ObtenerColorEstado(Equipos oEquipo,bool blnGoogleOutput)
        {
            string strColor="";
            if(blnGoogleOutput)
                strColor = "ff98fb98";
            else
                strColor = "PaleGreen";

            if (oEquipo.idEstadoMovimiento == 20/*DETENIDO*/)
                if(blnGoogleOutput)
                    strColor = "ffffffff";
                else
                    strColor = "White";

            if (oEquipo.Equipos_GPS.Velocidad.Value > oEquipo.VelocidadCarga)
                if (blnGoogleOutput)
                    strColor = "ff0000ff";
                else
                    strColor = "Red";

            if (oEquipo.Equipos_GPS.CalidadGPS.Value < 80)
                if (blnGoogleOutput)
                    strColor = "ff00ffff";
                else
                    strColor = "Yellow";

            if (oEquipo.Equipos_GPS.FechaServer.Value.AddMinutes(10) < System.DateTime.Now)
                if (blnGoogleOutput)
                    strColor = "ffd3d3d3";
                else
                    strColor = "LightGray";

            if (oEquipo.Equipos_GPS.FechaServer.Value.AddMinutes(60) < System.DateTime.Now)
                if (blnGoogleOutput)
                    strColor = "ff111111";
                else
                    strColor = "Black";
            
            return strColor;
        }
        
        public static void AbrirEarth(int idEquipo)
        {
            DC dc = new DC();
            Equipos e = (from x in dc.Equipos
                    where x.idEquipo == idEquipo
                    select x).FirstOrDefault();


            StringBuilder KML = new StringBuilder();
            KML.Append("<?xml version='1.0' encoding='UTF-8'?> \n" +
                       "<kml xmlns='http://www.opengis.net/kml/2.2' xmlns:gx='http://www.google.com/kml/ext/2.2' xmlns:kml='http://www.opengis.net/kml/2.2' xmlns:atom='http://www.w3.org/2005/Atom'> \n");

            KML.Append("<Placemark> \n" +
                         "<name>" + e.idEquipo.ToString() +" - "+ System.DateTime.Now.ToShortTimeString() +"</name> \n" +
                         "<description>"+
                         "\n Velocidad: " + "9999" + "km/h " +
                         "\n GSM: " + "9999" + "\n GPS: " + "99" + "% " + 
                         " </description> \n");

                    //Completo el estilo y la Latitud y Longitud del punto
            KML.Append("   <Style id='sn_arrow'> \n" +
                 "        <IconStyle> \n" +
                 "            <color>" + "ffffffff" + "</color> \n" +
                 "            <scale>" + "1.1" + "</scale> \n" +
                 "            <heading>" + (Convert.ToInt32(e.Equipos_GPS.Sentido) + 180).ToString() + "</heading> \n" +
                 "            <Icon> \n" +
                 "	            <href>http://maps.google.com/mapfiles/kml/shapes/arrow.png</href> \n" +
                 "            </Icon> \n" +
                 "        </IconStyle> \n" +
                 "        <LabelStyle> \n" +
                 "            <color>" + "ff7fffff" + "</color> \n" +
                 "            <scale>1.5</scale> \n" +
                 "        </LabelStyle> \n" +
                 "    </Style> \n" +
                 "    <Point> \n" +
                 "        <coordinates>" + e.Equipos_GPS.Longitud.ToString().Replace(",", ".") + "," + e.Equipos_GPS.Latitud.ToString().Replace(",", ".") + ",0</coordinates> \n" +
                 "    </Point> \n" +
                 "</Placemark> \n");

            KML.Append("</kml> \n");

            using (StreamWriter sw = File.CreateText("VerEquipo.KML"))
            {
                sw.Write(KML.ToString());
                sw.Close();
            }

            string commandText = "VerEquipo.KML";
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        public static int ObtenerEstacionEquipoGPS(int idGPS)
        {
            DC dc = new DC();
            try
            {
                return dc.Log_Geocercas.Where(j => j.idGPS == idGPS).OrderByDescending(k => k.idReg).First().idGeocerca;
            }
            catch
            {
                return -1;
            }
        }        
    }
}
