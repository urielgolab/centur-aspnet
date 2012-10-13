using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class srvGrupos
    {
        public static Boolean AgregarEvento(int idPuerta, int idGrupo)
        {
            DC dc = new DC();
            try
            {
                Accesos oAcceso = new Accesos();

                oAcceso.idGrupo = idGrupo;
                oAcceso.idPuerta = idPuerta;

                dc.Accesos.InsertOnSubmit(oAcceso);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
