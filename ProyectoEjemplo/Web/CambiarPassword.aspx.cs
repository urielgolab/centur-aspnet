using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;
using System.Web.Security;

using Servicios;
using Datos;

namespace Web
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if ((txtPasswordNueva.Text == txtRepetirPass.Text) && txtUsuario.Text!="" && txtPassword.Text!="")
            {
                try
                {

                    DC dc = new DC();
                    Usuarios oUser = dc.Usuarios.Single(m => m.Login == txtUsuario.Text && m.Password == txtPassword.Text);
                    oUser.Password = txtPasswordNueva.Text;
                    dc.SubmitChanges();
                    Msg.Text = "Se ha actualizado su password correctamente.";

                }
                catch
                {
                    Msg.Text = "Usuario o Password incorrecta";
                }
            }
        }

        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
