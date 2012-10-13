using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Servicios;
using Datos;

namespace Servicios
{
    public partial class wMensaje : Form
    {
        //public IQueryable<Equipos> equipos;
        public List<Equipos> equipos = new List<Equipos>();
        public int? idMensajePadre;

        public wMensaje()
        {
            InitializeComponent();
        }

        private void wMensaje_Load(object sender, EventArgs e)
        {
            var dsMensajesPrecargados = from msj in srvMensajes.ObtenerMensajesPrecargados()
                 select new
                 {
                     Texto = msj.Texto,
                     id = msj.id,
                 };

            dpMensajesPrecargados.DataSource = dsMensajesPrecargados.OrderBy(MensajesPrecargados => MensajesPrecargados.Texto);
            dpMensajesPrecargados.ValueMember = "id";
            dpMensajesPrecargados.DisplayMember = "Texto";
            dpMensajesPrecargados.SelectedIndex = -1;
            txtMensaje.Text = "";
        }

        private void wMensaje_Shown(object sender, EventArgs e)
        {
            try
            {
                var ds = from x in equipos
                         select new
                         {
                             Equipo = x.idEquipo,
                         };

                gEquipos.DataSource = ds.ToList();

            }
            catch { }

        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {

                
                foreach (DataGridViewRow r in gEquipos.Rows){
                    if (false)
                    {
                        //if (!Seguridad.PuedeOperarZona(Convert.ToInt32(Convert.ToInt32(r.Cells[0].Value))))
                        //MessageBox.Show("No tiene permiso para operar en esta zona.");
                    }
                    else
                    {
                        DC dc = new DC();
                        //srvMensajes.GuardarMensaje(Convert.ToInt32(r.Cells[0].Value), chkMostrarMensaje.Checked, Convert.ToInt16(dpBeeps.Value), Convert.ToInt16(dpBackLight.Value), Convert.ToInt16(dpPrioridad.Value), txtMensaje.Text, 1);
                        //srvMensajes.GuardarMensaje(                        
                        dc.MensajesSalidaInsertar(txtMensaje.Text, 'O', null, Convert.ToInt32(r.Cells[0].Value), Seguridad.Usuario.idUsuario, Seguridad.idZona,idMensajePadre);

                    }
                }

                this.Close();
                

            }
            catch(Exception err)
            {
                MessageBox.Show("Error al enviar mensaje", "Moebius");
            }

        }

        private void dpMensajesPrecargados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpMensajesPrecargados.SelectedIndex != -1)
                txtMensaje.Text = dpMensajesPrecargados.GetItemText(dpMensajesPrecargados.SelectedItem);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {
            //string[] strLineas = txtMensaje.Split(Environment.NewLine.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            //if(strLineas.Count
            /*
            string strMensaje = txtMensaje.Text;
            if(!strMensaje.EndsWith("\r\n"))
                if (strMensaje.Length != 0 && (((strMensaje.Replace("\r\n", "").Length) % 20) == 0))
                    txtMensaje.Text += "\r\n";
            txtMensaje.SelectionStart = txtMensaje.Text.Length;
             */
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }        
    }
}
