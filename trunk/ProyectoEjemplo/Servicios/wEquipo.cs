using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Datos;

namespace Servicios
{
    public partial class wEquipo : Form
    {
        public int idEquipo = 1;

        public wEquipo()
        {
            InitializeComponent();
        }

        private void wEquipo_Load(object sender, EventArgs e)
        {
            Equipos eq = srvEquipos.ObtenerEquipo(idEquipo);

            try
            {
                DC dc = new DC();
                dgGeocercas.DataSource = dc.EquipoVerGeocercas(eq.idGPS);
                dgEquipo.DataSource = dc.EquipoVerDetalles(eq.idEquipo);
                this.Text = "Detalles del Equipo " + eq.idFisico;

                string ultestacion;
                ultestacion = "\r\nUltima Estacion: " + srvDivisiones.ObtenerNombreEstacion(eq.idGeocercaOnline.Value) + ", Ingreso: " + eq.EntradaOnline.Value.ToString("hh:mm");
                if (eq.SalidaOnline != null)
                {
                    ultestacion = ultestacion + ", Salida: " + eq.SalidaOnline.Value.ToString("HH:mm")
                    + ". Hace " + (System.DateTime.Now.Subtract(eq.SalidaOnline.Value).TotalDays > 1 ? Math.Round(System.DateTime.Now.Subtract(eq.SalidaOnline.Value).TotalDays, 0).ToString() + " días, " : "")
                    + (System.DateTime.Now.Subtract(eq.SalidaOnline.Value).Hours > 0 ? System.DateTime.Now.Subtract(eq.SalidaOnline.Value).Hours.ToString() + " hs. " : "")
                    + System.DateTime.Now.Subtract(eq.SalidaOnline.Value).Minutes.ToString() + " min.";

                }

                DateTime? fechaSinAlim = obtenerFechaSinAlim(int.Parse(eq.idGPS.ToString()));
                string sFechaSinAlim = "";

                if (!(fechaSinAlim == null))
                {

                    sFechaSinAlim = "\r\nSin Alimentación Principal desde: " + fechaSinAlim;
                }

                txDetalles.Text = "Equipo: " + eq.idFisico.ToString()
                        + "\r\nProgresiva: " + eq.Progresiva.ToString()
                        + "\r\nVia: " + dc.ViasObtenerNombre(eq.idVia)
                        + "\r\nVelocidad: " + eq.Equipos_GPS.Velocidad.ToString() + "Kmh. "
                        + "\r\nVelocidad MAX: " + eq.VelocidadCarga.ToString() + "Kmh. " + (object)(eq.Motivo).ToString()
                        + ultestacion
                        + "\r\nUltimo Reporte: " + eq.Equipos_GPS.FechaServer.Value.ToShortTimeString()
                        + ". Hace "
                            + (System.DateTime.Now.Subtract(eq.Equipos_GPS.FechaServer.Value).TotalDays > 1 ? Math.Round(System.DateTime.Now.Subtract(eq.Equipos_GPS.FechaServer.Value).TotalDays, 0).ToString() + " días, " : "")
                            + (System.DateTime.Now.Subtract(eq.Equipos_GPS.FechaServer.Value).Hours > 0 ? System.DateTime.Now.Subtract(eq.Equipos_GPS.FechaServer.Value).Hours.ToString() + " hs. " : "")
                            + System.DateTime.Now.Subtract(eq.Equipos_GPS.FechaServer.Value).Minutes.ToString() + " min."
                        + "\r\n" + eq.Descripcion
                        + sFechaSinAlim;
            }
            catch
            { }
        }

        private DateTime? obtenerFechaSinAlim(int idGPS)
        {

            DC dc = new DC();
            DateTime? dReturn = new DateTime();

            foreach (Equipos_GPS unGPS in dc.Equipos_GPS.Where(g =>
                        g.idGPS == idGPS))
            {
                if (unGPS.SinAlimFechaD == null)
                {
                    dReturn = null;
                }
                else
                {
                    dReturn = DateTime.Parse(unGPS.SinAlimFechaD.ToString());
                }
            }

            return dReturn;

        }

        private void btEnviarMensaje_Click(object sender, EventArgs e)
        {
            if (Seguridad.idZona == 0)
                MessageBox.Show("Debe loguearse a una zona para operar", "Moebius");
            else
            {
                Equipos x = srvEquipos.ObtenerEquipo(idEquipo);
                wMensaje f = new wMensaje();
                f.equipos.Add(x);
                f.ShowDialog();
            }
        }

        private void btVerMapa_Click(object sender, EventArgs e)
        {

            srvEquipos.AbrirEarth(idEquipo);
        }

        private void btVerTren_Click(object sender, EventArgs e)
        {
            Equipos eq=srvEquipos.ObtenerEquipo(idEquipo);

            if (eq.idTren.Equals(null))
                MessageBox.Show("El equipo " + eq.idEquipo.ToString() + " no tiene asignado un tren");
            else
            {
                wTren f = new wTren();
                f.idTren = eq.idTren.Value;

                f.ShowDialog();
            }
        }
    }
}
