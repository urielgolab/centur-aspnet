using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Datos;

namespace Web
{
    public partial class ABMPuertas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            intPerfil.Value = Request.QueryString["idPerfil"];
            /*
            DC dc = new DC();
            int idPuerta;

            idPuerta = Convert.ToInt16(Request.QueryString["idPerfil"]);
            if (Request.QueryString["idPerfil"] != "")
            {
                Grupos oGrupo = dc.Grupos.SingleOrDefault(m => m.idGrupo == idPuerta);
                if (oGrupo != null)
                {
                    intPerfil.Value = Request.QueryString["idPerfil"];
                    txtPerfil.Text = oGrupo.Nombre;
                    txtDescripcion.Text = oGrupo.Observaciones;
                    txtPerfil.Enabled = txtDescripcion.Enabled = false;
                }
            }
            else
                idPuerta = 0;

            lblPermisos.Text = @"
                <table>
                    <tr>
                        <td>idPuerta</td>
                        <td>Descripción</td>
                        <td>Permitido</td>   
                    </tr>";

            foreach(Puertas oPuerta in dc.Puertas.OrderBy(m=>m.Secuencia))
            {
                lblPermisos.Text += @"
                    <tr>
                        <td>"+oPuerta.idPuerta.ToString()+@"</td>
                        <td>" +PadString("",(oPuerta.Nivel-1)*5,"&nbsp;") +oPuerta.Descripcion.ToString() + @"</td>
                        <td><input type='checkbox' name=chkPuerta" + oPuerta.idPuerta.ToString() + (dc.Accesos.SingleOrDefault(m=>m.idPuerta==oPuerta.idPuerta && m.idGrupo==idPuerta)!=null? " checked":"") +@"</td>   
                    </tr>";
            }

            lblPermisos.Text += "</table>";
            */ 
        }

        private string PadString(string strCadena, int intTimes, string strPad)
        {
            for (int i = 0; i < intTimes; i++)
                strCadena += strPad;
            return strCadena;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            DC dc = new DC();
            if (intPerfil.Value == "")
            {
                Grupos oGrupo = new Grupos();
                oGrupo.Nombre = txtPerfil.Text;
                oGrupo.Observaciones = txtDescripcion.Text;
                dc.Grupos.InsertOnSubmit(oGrupo);
                dc.SubmitChanges();
                intPerfil.Value = dc.Grupos.Max(m=>m.idGrupo).ToString();
            }


            int idPerfil=Convert.ToInt16(intPerfil.Value);

            dc.Accesos.DeleteAllOnSubmit(dc.Accesos.Where(m => m.idGrupo == idPerfil));
            foreach (GridViewRow i in grdPuertas.Rows)
                if (((CheckBox)i.FindControl("chkPuerta")).Checked)
                {
                    Accesos oAcceso = new Accesos();

                    oAcceso.idGrupo = idPerfil;
                    oAcceso.idPuerta = Convert.ToInt16(((CheckBox)i.FindControl("chkPuerta")).ToolTip);
                    dc.Accesos.InsertOnSubmit(oAcceso);
                }

            dc.SubmitChanges();

            grdPuertas.DataBind();
        }
    }
}
