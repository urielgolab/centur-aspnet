using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using Servicios;
using Datos;
namespace Web
{
    public partial class moebiusWeb : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Lang = "es-DO";   // Español - Argentina

            System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo(Lang);
            cult.NumberFormat.CurrencyDecimalSeparator = ".";
            cult.NumberFormat.CurrencyGroupSeparator = " ";
            cult.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            cult.DateTimeFormat.LongDatePattern = "dd/MM/yyyy HH:mm";
            cult.DateTimeFormat.ShortTimePattern = "HH:mm";
            cult.DateTimeFormat.LongTimePattern = "HH:mm";

            System.Threading.Thread.CurrentThread.CurrentCulture = cult; //new System.Globalization.CultureInfo("es-DO");


            menu.Text = srvMenu.CrearMenuJScript(false,Convert.ToInt16(Session["idUsuario"]));


            DC dc = new DC();
            Datos.Menu oMenu = (from j in dc.Menu
                               where SqlMethods.Like(Request.Url.AbsolutePath, "%" + j.Accion)
                               select j).FirstOrDefault();

            int idUsuario=Convert.ToInt16(Session["idUsuario"]);
            if (oMenu != null && oMenu.idPuerta!=null && idUsuario>0)
            {
                if (!Seguridad.VerificarAcceso(idUsuario, Convert.ToInt16(oMenu.idPuerta)))
                {
                    lblPuerta.InnerHtml = "No tiene permisos para ingresar a este módulo del sistema";
                    cphPrincipal.Visible = false;
                }
            }
        }

        protected void btnHome_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
    }
}
