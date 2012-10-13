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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Busco si los datos ingresados corresponden con un Usuario habilitado y guardo los datos en variables de sesion
            Usuarios x = Seguridad.Login(txtUsuario.Text, txtPassword.Text);

            if (x == null)
            {
                Msg.Text = "Usuario o Password incorrecta.";
            }
            else
            {
                Session["idUsuario"] = x.idUsuario;
                Session["Nombre"] = x.Nombre;
                Session["Apellido"] = x.Apellido;
                Session["Email"] = x.Email;
                FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, false);
            }
        }
        
        protected void Olvido_Click(object sender, EventArgs e)
        {
            Usuarios x = srvUsuarios.TraerUsuarioPorLogin(txtUsuario.Text);

            if (x == null)
            {
                Msg.Text = "Usuario o Password incorrecta.";
            }
            else
            {
                if (x.Email == null)
                    x.Email = "";
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(x.Email.Trim(), "(?<user>[^@]+)@(?<host>.+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    Msg.Text = "No tiene registrada un email correcto. <br />Contáctese con el administrador";
                }
                else
                {
                    message.To.Add(x.Email);
                    //message.CC.Add("info@soflex.com.ar");
                    message.Subject = "Moebius: Recordatorio de su Password";
                    message.IsBodyHtml = true;
                    message.Body = "<html><body>Estimado Sr./a. <b>" + x.Nombre + " " + x.Apellido + ",</b><br><br>Su password para ingresar al sistema es: " + x.Password + ".<br></body></html>";
                    smtpClient.Send(message);
                    Msg.Text = "Su Password ha sido enviada <br />a su mail.";
                }
            }
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarPassword.aspx");
        }
    }
}
