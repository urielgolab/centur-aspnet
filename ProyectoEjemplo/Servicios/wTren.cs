using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Datos;
using Servicios;

namespace Servicios
{
    public partial class wTren : Form
    {
        public int idTren = 1;

        public wTren()
        {
            InitializeComponent();
        }

        private void wTren_Load(object sender, EventArgs e)
        {
            DC dc = new DC();
            Trenes tr = srvTrenes.ObtenerTren(idTren);
            this.Text = "Detalles del Tren " + tr.NroTren;
        }

        private void tbFicha_Enter(object sender, EventArgs e)
        {
            DC dc = new DC();
            dgFicha.DataSource = dc.TrenVerFicha(idTren);
        }

        private void tbPasadas_Enter(object sender, EventArgs e)
        {
            DC dc = new DC();
            dgPasadas.DataSource = dc.TrenVerPasadas(idTren);
        }

        private void tbLog_Enter(object sender, EventArgs e)
        {
            DC dc = new DC();
            dgLog.DataSource = dc.TrenVerLog(idTren);
        }

        private void tbAsignaciones_Enter(object sender, EventArgs e)
        {
            DC dc = new DC();
            grdAsignaciones.DataSource = dc.TrenVerAsignaciones(idTren);
        }

        private void tbFormacion_Enter(object sender, EventArgs e)
        {
            DC dc = new DC();
            grdEquipos.DataSource = dc.TrenVerFormacionEquipo(idTren);

            if (srvTrenes.EsTrenDeTerceros(idTren))
            {
                lblPersonal.Visible = lblUFT.Visible = false;
                grdPersonal.Visible = grdUFT.Visible = false;
            }
            else
            {
                grdUFT.DataSource = dc.TrenVerFormacionUFT(idTren);
                grdPersonal.DataSource = dc.TrenVerFormacionPersonal(idTren);
            }
        }

        private void tbDatosGenerales_Enter(object sender, EventArgs e)
        {
            DC dc = new DC();
            dgTren.DataSource = dc.TrenVerDetalles(idTren);
        }

        private void tbProgramacion_Enter(object sender, EventArgs e)
        {
            DC dc = new DC();
            grdPasadasProg.DataSource = dc.TrenVerProgramacionPasadas(idTren);
            grdActProg.DataSource = dc.TrenVerProgramacionActividades(idTren);
        }

        private void dgLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            marcarFilaInactiva(dgLog);            

        }

        private void marcarFilaInactiva(DataGridView grdGrilla)
        {
            DataGridViewCellStyle st = new DataGridViewCellStyle();
            st.ForeColor = Color.Red;

            foreach (DataGridViewRow fila in grdGrilla.Rows)
                if (fila.Cells["Estado"].Value.ToString() == "Anulada")
                    fila.DefaultCellStyle = st;
        }

        private void dgPasadas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            marcarFilaInactiva(dgPasadas);

            for (int i = 0; i < dgPasadas.ColumnCount; i++)
            {
                if (dgPasadas.Columns[i].HeaderText == "FechaOrden")
                {
                    dgPasadas.Columns[i].Visible = false;
                }
            }
        }
    }
}
