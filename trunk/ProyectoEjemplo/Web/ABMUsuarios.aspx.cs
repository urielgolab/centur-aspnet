using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Servicios;
using Datos;

namespace Web
{
    public partial class ABMUsuarios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dtvUsuario_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            lblMensajeError.Text = "";
            if (e.Exception == null)
                grdUsuarios.DataBind();
            else
            {
                lblMensajeError.Text = "Compruebe datos ingresados";
                e.ExceptionHandled = true;
                e.KeepInInsertMode= true;
            }
        }

        protected void dtvUsuario_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            grdUsuarios.DataBind();
        }

        protected void dtvUsuario_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            lblMensajeError.Text = "";
            if (e.Exception == null)
                grdUsuarios.DataBind();
            else
            {
                lblMensajeError.Text = "Compruebe datos ingresados";
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
            }
        }

        protected void btAgregarGrupo_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(dpGrupos.SelectedValue)>0)
                if(srvUsuarios.AgregarAGrupo(Convert.ToInt32(grdUsuarios.SelectedValue),Convert.ToInt32(dpGrupos.SelectedValue))){
                    grdGrupos_Usuario.DataBind();
                    lblMensajeGrupo.Text = "Grabado con &eacute;xito";
                }
                else
                    lblMensajeGrupo.Text = "Ya contiene el grupo elegido";

        }

        protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool blnSelected = (grdUsuarios.SelectedIndex != -1 ? true : false);
            dpGrupos.Visible = grdGrupos_Usuario.Visible = btAgregarGrupo.Visible = blnSelected;
            dpZonas.Visible = grdZonas.Visible = btnAgregarZona.Visible = blnSelected;
            dpSectores.Visible = grdSectores.Visible = btnAgregarSector.Visible = blnSelected;
            lblMensajeGrupo.Text = lblMensajeZona.Text=lblMensajeZona.Text=lblMensajeError.Text="";
        }

        protected void lnkNuevoUsuario_Click(object sender, EventArgs e)
        {
            dtvUsuario.ChangeMode(DetailsViewMode.Insert);
        }

        protected void btnAgregarZona_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dpZonas.SelectedValue) > 0)
                if (srvUsuarios.AgregarAZona(Convert.ToInt32(grdUsuarios.SelectedValue), Convert.ToInt32(dpZonas.SelectedValue)))
                {
                    grdZonas.DataBind();
                    lblMensajeZona.Text = "Grabado con &eacute;xito";
                }
                else
                    lblMensajeZona.Text = "Ya contiene la zona elegida";
        }

        protected void btnAgregarSector_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dpSectores.SelectedValue) > 0)
                if (srvUsuarios.AgregarASector(Convert.ToInt32(grdUsuarios.SelectedValue), Convert.ToInt32(dpSectores.SelectedValue)))
                {
                    grdSectores.DataBind();
                    lblMensajeSector.Text = "Grabado con &eacute;xito";
                }
                else
                    lblMensajeSector.Text = "Ya contiene el sector elegido";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

      }
}
