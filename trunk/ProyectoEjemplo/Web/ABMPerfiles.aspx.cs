using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Datos;
using Servicios;

namespace Web
{
    public partial class ABMGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            DC dc = new DC();
            int idPerfil= Convert.ToInt16(Convert.ToInt16(grdGrupos.SelectedValue));

            dc.Accesos.DeleteAllOnSubmit(dc.Accesos.Where(m => m.idGrupo == idPerfil));
            dc.SubmitChanges();

            foreach (GridViewRow i in grdPuertas.Rows)
                if (((CheckBox)i.FindControl("chkPuerta")).Checked)//agrego puertas recursivamente
                    Seguridad.AgregarPuertasRec(Convert.ToInt16(((CheckBox)i.FindControl("chkPuerta")).ToolTip), idPerfil);

            lblMensajePuertas.Text = "Puertas Almacenadas Correctamente.";
            grdGrupos.DataBind();
            seleccionarValorGrilla(idPerfil);
        }

        protected void seleccionarValorGrilla(int idValor)
        {
            for (int i = 0; i < grdGrupos.DataKeys.Count - 1; i++)
                if ((int)grdGrupos.DataKeys[i].Value == idValor)
                    grdGrupos.SelectedIndex = i;
           
        }

        protected void grdGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdGrupos.SelectedIndex == -1)
                grdPuertas.Visible = btnEnviar.Visible = ltlTableHeader.Visible = false;
            else
                grdPuertas.Visible = btnEnviar.Visible = ltlTableHeader.Visible = true;
            lblMensajePuertas.Text = "";
            /*
            DC dc = new DC();
            Grupos oGrupo=dc.Grupos.Single(m=>m.idGrupo==Convert.ToInt16(grdGrupos.SelectedValue));
            txtPerfil.Text = oGrupo.Nombre;
            txtDescripcion.Text = oGrupo.Observaciones;
            txtDescripcion.Enabled = txtPerfil.Enabled = false;
             */
        }

        protected void lnkNuevoPerfil_Click(object sender, EventArgs e)
        {
            dtvPerfil.ChangeMode(DetailsViewMode.Insert);
            grdGrupos.SelectedIndex = -1;
            grdPuertas.Visible = btnEnviar.Visible = ltlTableHeader.Visible = false;
            lblMensajePuertas.Text = "";
        }

        protected void grdGrupos_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            seleccionarValorGrilla(Convert.ToInt16(grdGrupos.SelectedValue));
        }

        protected void dtvPerfil_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            grdGrupos.DataBind();
        }

        protected void dtvPerfil_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            grdGrupos.DataBind();
        }

        protected void dtvPerfil_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            grdGrupos.DataBind();
        }

        protected void dtvPerfil_ItemCreated(object sender, EventArgs e)
        {
            grdGrupos.DataBind();
        }
    }
}
