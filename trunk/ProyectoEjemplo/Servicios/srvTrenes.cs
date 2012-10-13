using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;

using Datos;

namespace Servicios
{
    public class srvTrenes
    {
        public static Tren_Ficha FichaTrenObtenerUltima(int idTren)
        {
            DC dc = new DC();

            return dc.Tren_Fichas.Where(j => j.idTren == idTren).OrderByDescending(i => i.idFicha).FirstOrDefault();
        }

        public static string FichaTrenRegistrar(Tren_Ficha oTrenFicha)
        {
            try
            {
                string strMensajeRespuesta = "";
                using (TransactionScope ts = new TransactionScope())
                {
                    DC dc = new DC();
                    int idTransaccion = dc.TransaccionCrearSimple(
                        oTrenFicha.idTren,
                        "FichaTrenRegistrar",
                        oTrenFicha.idEquipo,
                        Seguridad.Usuario.idUsuario,
                        "");

                    int idLog = dc.FichaTrenRegistrar(
                        oTrenFicha.FechaTransaccion,
                        oTrenFicha.idConductor,
                        oTrenFicha.LoginConductor,
                        oTrenFicha.ConductorNombre,
                        oTrenFicha.idAyudante,
                        oTrenFicha.LoginAyudante,
                        oTrenFicha.AyudanteNombre,
                        oTrenFicha.idEquipo,
                        oTrenFicha.idUFT,
                        oTrenFicha.idDivision,
                        oTrenFicha.idEstacion,
                        oTrenFicha.VagonesCargados,
                        oTrenFicha.VagonesVacios,
                        oTrenFicha.Tonelaje,
                        oTrenFicha.Longitud,
                        oTrenFicha.NroUltimoVagon,
                        Convert.ToInt32(oTrenFicha.Gasoil),
                        oTrenFicha.Prescinto1,
                        oTrenFicha.Prescinto2,
                        //Otras locomotoras
                        oTrenFicha.idEquipo2,
                        oTrenFicha.idEquipo3,
                        oTrenFicha.idUFT2,
                        oTrenFicha.idUFT3,
                        oTrenFicha.Obs,
                        ref strMensajeRespuesta,
                        idTransaccion,
                        null);

                    ts.Complete();
                }

                if (strMensajeRespuesta != "")
                    return ("Advertencia:" + strMensajeRespuesta);
                return "";
            }
            catch (Exception ex)
            {
                return ("Error:"+ex.Message);
            }
        }

        public static Trenes ObtenerTren(int idTren)
        {
            DC dc = new DC();
            
            return (from x in dc.Trenes
                    where x.idTren == idTren
                    select x).FirstOrDefault();
        }

        public static IQueryable<Trenes> ObtenerTrenes(int idTren)
        {
            DC dc = new DC();

            return (from x in dc.Trenes
                    where x.idTren == idTren
                    select x);
        }

        public static void CargarPasadaPorEstacion(Tren_Pasadas oTrenDetalle)
        {
            DC dc = new DC();

            Tren_Pasadas oUpdatable = dc.Tren_Pasadas.Single(p => p.idPasada == oTrenDetalle.idPasada);

            oUpdatable.Fecha = oTrenDetalle.Fecha;
            oUpdatable.Obs = oTrenDetalle.Obs;

            dc.SubmitChanges();
        }

        
        public static IQueryable<Tren_Pasadas> ListarPasadas(int idTren)
        {
            DC dc = new DC();
            return (from x in dc.Tren_Pasadas
                    where x.idTren == idTren
                    select x);

        }

        public static bool EsTrenDeTerceros(int idTren)
        {
            DC dc = new DC();
            Trenes oTren = dc.Trenes.SingleOrDefault(j => j.idTren == idTren && j.IdFerrocarril !=null && j.IdFerrocarril > 1);
            if (oTren != null)
                return true;
            return false;
        }

        public static int ObtenerDivisionEquipoTren(int idTren)
        {
            DC dc = new DC();
            Trenes oTren = dc.Trenes.Single(j => j.idTren == idTren);
            if (oTren.Equipos1 != null && oTren.Equipos1.idDivision != null)
                return Convert.ToInt16(oTren.Equipos1.idDivision);
            return -1;
        }

        public static IQueryable<Trenes> ObtenerTrenesActivos()
        {
            DC dc = new DC();
            return(from Tren in dc.Trenes
                   join EstadoTren in dc.Estados on Tren.idEstado equals EstadoTren.idEstado
                   where Tren.FechaSalidaProg >= DateTime.Now.AddDays(-7)
                   && Tren.FechaSalidaProg <= DateTime.Now.AddDays(1)
                   && EstadoTren.Nombre != "FINALIZADO_LIBERADO"
                   && EstadoTren.Nombre != "ELIMINADO"
                   && EstadoTren.Nombre != "CANCELADO"
                   select Tren);
        }

        public static int ObtenerDivisionEquipoTren(Equipos oEquipo)
        {
            if (oEquipo != null && oEquipo.idDivision != null)
                return Convert.ToInt16(oEquipo.idDivision);
            return -1;
        }

        public static int? TrenObtenerID(string NroTren)
        {
            DC dc = new DC();
            return dc.TrenObtenerID(NroTren);
        }
    }
}
