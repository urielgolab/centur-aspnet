using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

using Datos;

namespace Servicios
{
    public class srvEventos
    {
        public static String RegistrarEvento(int idEvento,int idEquipo,int? idTren,int idUsuario,string strObservaciones,ref Nullable<int> idLogEvento,ref string strMensaje)
        {
            DC dc = new DC();
            //dc.EventoCrear(,idEvento, idEquipo, idTren, idUsuario, DateTime.Now, strObservaciones, ref idLogEvento, ref strMensaje);
            return strMensaje;
        }
    }
}
