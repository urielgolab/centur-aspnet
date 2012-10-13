using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Web
{
    public partial class Divisiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void ddlDivisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            //grdDivision.DataBind();
            llenarGrillaDivision();
            llenarGrillaDivisionDetalle();
            llenarGrillaObservaciones();
            //grdDivisionDetalle.DataBind();
            //dtvObservaciones.DataBind();        
        }

        void llenarGrillaDivision()
        {

            DC dc = new DC();
      
            var dsDivision = from x in dc.Divisiones
                             join y in dc.Estaciones on x.idEstacionDesde equals y.idEstacion
                             join z in dc.Estaciones on x.idEstacionHasta equals z.idEstacion
                             join tZonas in dc.Zonas on x.idZona equals tZonas.idZona
                             where x.idDivision == int.Parse(ddlDivisiones.SelectedValue.ToString())
                             select new
                             {
                                 Zona = tZonas.Descripcion,                                 
                                 Desde = y.Nombre,
                                 Hasta = z.Nombre
                             };

            grdDivision.DataSource = dsDivision;
            grdDivision.DataBind();

        }

        void llenarGrillaDivisionDetalle()
        {
            DC dc = new DC();

            var dsDivisionDetalle = (from x in dc.Divisiones_Detalle
                                     join tEstacionCFlex in dc.Estaciones_CFLEX on x.idEstacionCFLEX equals tEstacionCFlex.idEstacionCFLEX into j1
                                     from j2 in j1.DefaultIfEmpty()                                     
                                     
                                     join tEstacionSap in dc.Estaciones_SAP on x.idEstacionSAP equals tEstacionSap.idEstacionSAP into j3
                                     from j4 in j3.DefaultIfEmpty()
                                     
                                     where x.idDivision == int.Parse(ddlDivisiones.SelectedValue.ToString())
                                     orderby x.ProgresivaPoste
                                     select new
                                      {
                                          Estacion = x.Text,
                                          ProgresivaPoste = x.ProgresivaPoste,
                                          ProgresivaDivision = x.ProgresivaDivision,
                                          Disntacia = x.Distancia,
                                          Tiempo = x.TiempoCarga,
                                          Long = "Long",
                                          ComNavegacion = x.ComunicacionNavegacion,
                                          ComBase = x.ComunicacionBase,
                                          EstacionCflex = j2 == null ? "" : j2.idCFLEX,
                                          EstacionSap = j4==null?"":j4.Descripcion
                                      });

            
            grdDivisionDetalle.DataSource = dsDivisionDetalle;
            grdDivisionDetalle.DataBind();
        }

        void llenarGrillaObservaciones()
        {

            DC dc = new DC();

            var dsObservaciones = from x in dc.Divisiones                             
                             where x.idDivision == int.Parse(ddlDivisiones.SelectedValue.ToString())
                             select new
                             {
                                 Observaciones = x.Observaciones,
                                 Reglamento = x.Reglamento                                 
                             };

            dtvObservaciones.DataSource = dsObservaciones;
            dtvObservaciones.DataBind();

        }

        protected void Exportar_Click(object sender, EventArgs e)
        {
             
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=Divisiones.xls");
            Response.Charset = "";

            // If you want the option to open the Excel file without saving than

            // comment out the line below

            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            grdDivisionDetalle.RenderControl(htmlWrite);            

            Response.Write(stringWrite.ToString());

            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */

        }
    }
}
