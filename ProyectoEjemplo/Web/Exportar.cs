using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

namespace Servicios
{
    public class Exportar
    {
        public string ExportarExcel(GridView grilla,int colInicial, string cssTitulo, string cssContenido, string colorFondoTitulo, string colorFondoContenido)
        {
            StringBuilder sb = new System.Text.StringBuilder();
            StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            //Preparo para armar una TABLA
            HtmlTable table = new HtmlTable();
            HtmlTableRow tr;
            HtmlTableCell td;

            //Configuro tabla
            table.Border = 1;

            int nColumnas = grilla.Rows[0].Cells.Count;

            foreach (TableCell cel in grilla.HeaderRow.Cells)
            {
                cel.Text = plancharCelda(cel);
            }
            foreach (GridViewRow row in grilla.Rows)
            {
                foreach (TableCell cel in row.Cells)
                {
                    cel.Text = plancharCelda(cel);
                }
            }

            //Pongo titulos con html propio
            tr = new HtmlTableRow();
            table.Controls.Add(tr);
            table.Border = 0;
            table.CellPadding = 2;
            table.CellSpacing = 0;

            //foreach (TableCell s in grilla.HeaderRow.Cells)
            for (int i = colInicial; i < grilla.Columns.Count; i++)
            {
                td = new HtmlTableCell();
                td.BgColor = colorFondoTitulo;
                td.InnerHtml = "<div " + cssTitulo + ">" + grilla.HeaderRow.Cells[i].Text + "</div>";
                table.Controls[table.Controls.Count - 1].Controls.Add(td);
            }

            //Copio contenido de la grilla
            foreach (GridViewRow g in grilla.Rows)
            {
                tr = new HtmlTableRow();
                table.Controls.Add(tr);
                for (int i = colInicial; i < grilla.Columns.Count; i++)
                {
                    td = new HtmlTableCell();
                    td.BgColor = colorFondoContenido;
                    //Si quiero darle formato concateno en el innerHtml
                    td.InnerHtml = "<div " + cssContenido + ">" + g.Cells[i].Text + "</div>";
                    table.Controls[table.Controls.Count - 1].Controls.Add(td);
                }
            }

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(table);

            page.RenderControl(htw);

            return sb.ToString();
        }

        private string plancharCelda(TableCell cel)
        {
            for (int i = 0; i < cel.Controls.Count; i++)
            {
                string aux = cel.Controls[i].GetType().ToString();
                aux = aux.Substring(aux.LastIndexOf('.')+1);
                switch (aux)
                {
                    case "DataControlLinkButton":
                        cel.Text = cel.Text + ((LinkButton)cel.Controls[i]).Text;
                        break;
                    case "LinkButton":
                        cel.Text = cel.Text + ((LinkButton)cel.Controls[i]).Text;
                        break;
                    case "HyperLink":
                        cel.Text = cel.Text + ((HyperLink)cel.Controls[i]).Text;
                        break;
                    case "TextBox":
                        cel.Text = cel.Text + ((TextBox)cel.Controls[i]).Text;
                        break;
                    case "Label":
                        cel.Text = cel.Text + ((Label)cel.Controls[i]).Text;
                        break;
                    case "CheckBox":
                        cel.Text = cel.Text + (((CheckBox)cel.Controls[i]).Checked ? "Si" : "No");
                        break;
                    case "ImageButton":
                        var x = ((ImageButton)cel.Controls[i]);
                        string valor = x.ImageUrl.Remove(0,x.ImageUrl.LastIndexOf('/')+1).ToString();
                        if (valor.StartsWith("1"))
                            cel.Text = cel.Text + "Activo";
                        else if (valor.StartsWith("99"))
                            cel.Text = cel.Text + "Inactivo";
                        else if(valor.StartsWith("2"))
                            cel.Text = cel.Text + "En Taller";
                        break;
                } 
            }
            return cel.Text;
        }
    }
}
