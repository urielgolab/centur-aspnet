using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Web
{
    public class funciones
    {
        public void cambiarEstadoATexto(System.Web.UI.WebControls.GridView unaGrilla)
        {
            //Cambia la columna estado de una grilla de 1 o 0 a "Activa" o "Inactiva"
            int indiceColumna = -1;

            for (int i = 0; i < unaGrilla.Columns.Count; i++)
            {
                if (unaGrilla.Columns[i].HeaderText.ToString() == "Estado")
                    indiceColumna = i;
            }

            if (indiceColumna > -1)
            {
                for (int i = 0; i < unaGrilla.Rows.Count; i++)
                {
                    String sTexto = unaGrilla.Rows[i].Cells[indiceColumna].Text.ToString() == "1" ? "Activa" : "Inactiva";
                    unaGrilla.Rows[i].Cells[indiceColumna].Text = sTexto;                    
                }
            }
        }

        public void cambiarColumnaCheckBox(System.Web.UI.WebControls.GridView unaGrilla, String sColumna)
        {

            int indiceColumna = obtenerIndiceColumna(unaGrilla, sColumna);

            if (indiceColumna > -1)
            {
                for (int i = 0; i < unaGrilla.Rows.Count; i++)
                {
                    //String sTexto = unaGrilla.Rows[i].Cells[indiceColumna].Text.ToString() == "1" ? "Activa" : "Inactiva";
                    System.Web.UI.WebControls.CheckBox chk = new System.Web.UI.WebControls.CheckBox();
                    chk.Checked = unaGrilla.Rows[i].Cells[indiceColumna].Text.ToString() == "1";
                    unaGrilla.Rows[i].Cells[indiceColumna].Text = "";
                    unaGrilla.Rows[i].Cells[indiceColumna].Controls.Add(chk);
                }
            }
        }

        public void cambiarColumnaPorUsuario(System.Web.UI.WebControls.GridView unaGrilla, String sColumna)
        {
            int indiceColumna = obtenerIndiceColumna(unaGrilla, sColumna);
            DC dc = new DC();

            if (indiceColumna > -1)
            {
                for (int i = 0; i < unaGrilla.Rows.Count; i++)
                {

                    String sUsuario = unaGrilla.Rows[i].Cells[indiceColumna].Text.ToString();
                    var usuarios = (from tUsuario in dc.Usuarios
                                    where tUsuario.idUsuario.ToString() == sUsuario
                                    select tUsuario).Single();

                    unaGrilla.Rows[i].Cells[indiceColumna].Text = usuarios.Nombre;
                }
            }
        }

        public int obtenerIndiceColumna(System.Web.UI.WebControls.GridView unaGrilla, String nombreColumna)
        {
            int indiceColumna = -1;

            for (int i = 0; i < unaGrilla.Columns.Count; i++)
            {
                if (unaGrilla.Columns[i].HeaderText.ToString() == nombreColumna)
                    indiceColumna = i;
            }

            return indiceColumna;
        }

        public void exportarGridViewExcel(System.Web.UI.WebControls.GridView unaGrilla, string archivoNombre)
        {
            try
            {
                string[] colVacias = new string[0];
                exportarGridViewExcel(unaGrilla, archivoNombre, colVacias);
            }
            catch
            {

            }
        }
        
        public void exportarGridViewExcel(System.Web.UI.WebControls.GridView unaGrilla, string archivoNombre, string[] columnasAOcultar)
        {
            /* AUTOR: Juan Martin Szwarcberg
             * DESC:  La idea es facilitar el tema de exportar a excel, ya que 
             *        casi todas las grillas deben hacerlo y hasta ahora
             *        se copiaba y pegaba el mismo codigo
             * 
             */
            
            //NOTA IMPORTANTE: 
            
            //en la pagina que llame esta funcion no puede faltar
            //EnableEventValidation="false" en el @page
            //busque si existia la forma de hacer esta asignacion por programacion, pero no encontre nada

            //y en el codebehind debe estar el override VerifyRenderingInServerForm


            try
            {
                //HttpContext.Current.Response es lo mismo que escribir Response afuera

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + archivoNombre + ".xls");
                HttpContext.Current.Response.Charset = "";

                // If you want the option to open the Excel file without saving than

                // comment out the line below

                //Response.Cache.SetCacheability(HttpCacheability.NoCache);

                HttpContext.Current.Response.ContentType = "application/vnd.xls";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();

                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                
                
                unaGrilla.AllowPaging = false;
                unaGrilla.AllowSorting = false;
                unaGrilla.DataBind();

                for (int i = 0; i < columnasAOcultar.Count(); i++)
                {
                    int colOcultar = obtenerIndiceColumna(unaGrilla, columnasAOcultar[i]);
                    if (colOcultar >= 0 && colOcultar < unaGrilla.Columns.Count)
                    {
                        unaGrilla.Columns[colOcultar].Visible = false;
                    }
                }

                unaGrilla.RenderControl(htmlWrite);

                HttpContext.Current.Response.Write(stringWrite.ToString());

                HttpContext.Current.Response.End();                

            }
            catch
            {

            }
        }

        public bool validarProgresivaInput(string progresiva, string nombreInput, out string error)
        {
            error = "";            

            decimal dout;
            if (!(Decimal.TryParse(progresiva, out dout)))
            {
                error = nombreInput + " debe tener formato decimal, 7 enteros y 3 decimales como máximo.";
                return false;
            }

            string[] vsplit = progresiva.Split('.');
            string parteEntera = vsplit[0];
            string parteDecimal = "";

            if (vsplit.Length > 1)
            {
                parteDecimal = vsplit[1];
            }

            if (parteEntera.Length > 7)
            {
                error = nombreInput + " debe tener formato decimal, 7 enteros y 3 decimales como máximo.";
                return false;
            }

            if (parteDecimal.Length > 3)
            {
                error = nombreInput + " debe tener formato decimal, 7 enteros y 3 decimales como máximo.";
                return false;
            }
        
            return true;
        }

    }
}
