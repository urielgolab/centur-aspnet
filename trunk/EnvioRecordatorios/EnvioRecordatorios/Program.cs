using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
        
namespace EnvioRecordatorios
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn=new SqlConnection("Data Source=centur.ugserver.com.ar,109;Initial Catalog=Uriel;Persist Security Info=True;User ID=Uriel;Password=centur");
            SqlCommand comando = new SqlCommand("RecordatoriosOtener", conn);
            comando.Parameters.Add(new SqlParameter("@fecha", DateTime.Now));
            conn.Open();
            SqlDataReader dr;
            comando.CommandType = CommandType.StoredProcedure;
            dr = comando.ExecuteReader();

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("centurapp@gmail.com", "centurutn");

            while (dr.Read())   
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(dr["email"].ToString()));
                msg.From = new MailAddress("centurapp@gmail.com");
                msg.Subject = "CENTUR: Envio de Recordatorio";
                msg.Body = "Tiene un turno para el Servicio " + dr["nombreServicio"].ToString() + " el dia " + dr["fecha"].ToString().Substring(0, 10) + " de " + dr["horaInicio"].ToString().Substring(0, 5) + " a " + dr["horaFin"].ToString().Substring(0, 5) + ".";
                msg.IsBodyHtml = false; 

                smtp.Send(msg);
            }

            dr.Close();
            
        }
    }
}
