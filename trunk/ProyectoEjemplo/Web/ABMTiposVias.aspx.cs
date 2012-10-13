using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Web
{
    public partial class ABMTiposVias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkNuevo.Visible = false;
            linkCancelar.Visible = false;
            linkEliminar.Visible = false;
            linkModificar.Visible = false;
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void linkInsertar_Click(object sender, EventArgs e)
        {

        }

        protected void linkModificar_Click(object sender, EventArgs e)
        {

        }

        protected void linkEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void linkCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void grdVias_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            configurarFormulario();



            Tipos_Via unaTipoVia = obtenerTipoVia(int.Parse(grdTipoVias.SelectedValue.ToString()));
            txtDescripcion.Text = unaTipoVia.Descripcion;
            dropEstadoPosicion.SelectedValue = unaTipoVia.idTipoVia.ToString();
                        
            linkInsertar.Visible = false;
            linkEliminar.Visible = false; //por ahora no hay eliminar
             */ 

        }

        protected Tipos_Via obtenerTipoVia(int cod)
        {
            
            DC dc = new DC();
            Tipos_Via unTipoVia = dc.Tipos_Via.Single(u => u.idTipoVia == (cod));
            return unTipoVia;
        }

        protected void cargarComboEstadoPosicion()
        {
            DC dc = new DC();
            dropEstadoPosicion.DataSource = dc.TipoViaListar();
            dropEstadoPosicion.DataTextField = "Descripcion";
            dropEstadoPosicion.DataValueField = "Codigo";
            dropEstadoPosicion.DataBind();
        }

        protected void configurarFormulario()
        {
            pnAlta.Visible = true;
            cargarComboEstadoPosicion();
           
        }

    }
}
