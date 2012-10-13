using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class srvMenu
    {

        public static string CrearMenuJScript(Boolean blnMostrarVertical)
        {
            return 
                "<script type='text/javascript'>\n"+
                "var mm0 = new TMainMenu('mm0','"+(blnMostrarVertical==true?"vertical":"horizontal")+"');\n"
                    + DibujarNodoMenuJS(0,null) + 
                "</script>\n";
        }

        public static string CrearMenuJScript(Boolean blnMostrarVertical,int idUsuario)
        {
            return
                "<script type='text/javascript'>\n" +
                "var mm0 = new TMainMenu('mm0','" + (blnMostrarVertical == true ? "vertical" : "horizontal") + "');\n"
                    + DibujarNodoMenuJS(0, idUsuario) +
                "</script>\n";
        }

        private static string DibujarNodoMenuJS(int idPadre,int? idUsuario)
        {
            string strSalida = "";
            int intLastNode = idPadre;

            DC dc = new DC();
            IQueryable<Menu> oMenu = from x in dc.Menu
                                     where x.idMenuPadre == idPadre
                                     select x;
            
            foreach (var oItemMenu in oMenu)
            {
                if (oItemMenu.idPuerta != null && (idUsuario > 0 && !Seguridad.VerificarAcceso(Convert.ToInt16(idUsuario), Convert.ToInt16(oItemMenu.idPuerta))))
                    strSalida += "";
                else
                {
                    strSalida += "var menuItem" + oItemMenu.idMenu + " = new TPopMenu('" + oItemMenu.Texto + "','" + (oItemMenu.Icono != null ? oItemMenu.Icono : "") + "','" + ((oItemMenu.TipoAccion != null) ? oItemMenu.TipoAccion.ToString() : "") + "',\"" + (oItemMenu.Accion != null ? oItemMenu.Accion.ToString() : "") + "\",'" + oItemMenu.Descripcion + "');\n";
                    if (idPadre == 0)
                        strSalida += "mm0.Add(menuItem" + oItemMenu.idMenu.ToString() + ");\n";
                    else
                        if ((intLastNode != Convert.ToInt16(oItemMenu.idMenu)))
                            strSalida += "menuItem" + intLastNode.ToString() + ".Add(menuItem" + oItemMenu.idMenu.ToString() + ");\n";

                    intLastNode = (Convert.ToInt16(oItemMenu.idMenuPadre) == 0 ? Convert.ToInt16(oItemMenu.idMenu) : Convert.ToInt16(oItemMenu.idMenuPadre));
                    strSalida += srvMenu.DibujarNodoMenuJS(Convert.ToInt16(oItemMenu.idMenu), idUsuario);
                }
            }                     
            return strSalida;
            
        }
    }
}
