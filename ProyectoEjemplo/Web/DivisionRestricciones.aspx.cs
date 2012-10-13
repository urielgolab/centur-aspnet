using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class DivisionRestricciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlDivisiones.SelectedValue.ToString() != "0")
                lnkExcel.Enabled = true;
        }

        protected void ddlDivisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdPAN.DataBind();
            grdRemolqueFrenado.DataBind();
            grdVelocidades.DataBind();
        }

        protected void lnkExcel_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=VelocidadesyPAN.xls");
                Response.Charset = "";

                // If you want the option to open the Excel file without saving than

                // comment out the line below

                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                htmlWrite.WriteLine("<b>Velocidades<b>");
                grdVelocidades.RenderControl(htmlWrite);
                htmlWrite.WriteLine("<br><b>PAN<b>");
                grdPAN.RenderControl(htmlWrite);
                htmlWrite.WriteLine("<br><b>Remolque y Frenado<b>");                
                grdRemolqueFrenado.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch
            {

            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */

        }
    }
}
