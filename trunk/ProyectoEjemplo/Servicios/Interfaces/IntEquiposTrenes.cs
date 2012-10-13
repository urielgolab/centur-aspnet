using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Datos;

namespace Servicios.Interfaces
{
    public partial class srvInterfaces
    {
        public class IntEquiposTrenes
        {
            public static void EquiposTrenesProcesar()
            {
                DC dc = new DC();
                Interfaces_Corridas oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTMOESAP_EQUTRE").idInterfaz, 5);

                var varAsignaciones = from asg in dc.Asignaciones
                                   where asg.Procesada == 0
                                   orderby asg.idAsignacion
                                   select asg;


                //actualizo el objeto para asociarlo al dc actual
                oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                if (varAsignaciones.Count() > 0)
                {
                    string strArchivoSalida = "";
                    foreach (Asignaciones Asignacion in varAsignaciones)
                    {
                        strArchivoSalida += dc.Trenes.Single(m=>m.idTren==Asignacion.idTren).NroTren.PadRight(10);
                        strArchivoSalida += (Asignacion.FechaTransaccion != null ? Convert.ToDateTime(Asignacion.FechaTransaccion).ToString("ddMMyy") : "").PadRight(6);
                        strArchivoSalida += (Asignacion.FechaTransaccion != null ? Convert.ToDateTime(Asignacion.FechaTransaccion).ToString("HHmm") : "").PadRight(4);
                        strArchivoSalida += Asignacion.Operacion.PadRight(3);
                        strArchivoSalida += (Asignacion.idEquipo!=null?Asignacion.idEquipo:Asignacion.idUFT).ToString().PadRight(6);
                        strArchivoSalida += Asignacion.Funcion.PadRight(1);
                        strArchivoSalida += dc.Estaciones.Single(j => j.idEstacion == Asignacion.idEstacion).idEstacionSAP.ToString().PadRight(6);
                        strArchivoSalida += Asignacion.ProgresivaPoste.ToString().PadRight(8);
                        strArchivoSalida += dc.Causas_Asignaciones_SAP.Single(j => j.idCausaAsignacion== Asignacion.idCausaAsignacion).CodigoSAP.ToString().PadRight(4);
                        strArchivoSalida += DateTime.Now.ToString("yyyyMMddHHmmss").PadRight(14);
                        strArchivoSalida += "\r\n";

                        Asignacion.Procesada = 1;
                        Asignacion.idCorrida = oIntCorrida.idCorrida;
                        oIntCorrida.Archivo += strArchivoSalida;
                    }

                    string strRutaCompletaArchivo = Path.GetFullPath(srvParametros.ObtenerParametro("Interfaz.CarpetaSalida")) + "\\INTMOESAP_PAS\\IMSPASADAS " + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
                    oIntCorrida.NombreArchivo = Path.GetFileName(strRutaCompletaArchivo);
                    if (!Directory.Exists(Path.GetDirectoryName(strRutaCompletaArchivo)))
                        Directory.CreateDirectory(Path.GetDirectoryName(strRutaCompletaArchivo));

                    StreamWriter fleArchivoGenerado = File.CreateText(strRutaCompletaArchivo);
                    fleArchivoGenerado.Write(oIntCorrida.Archivo.Substring(0, oIntCorrida.Archivo.Length - 2)); //elimina ultimo \r\n
                    fleArchivoGenerado.Close();

                    oIntCorrida.Procesada = 6;
                }
                else
                {
                    oIntCorrida.NombreArchivo = "Sin archivo";
                    oIntCorrida.Procesada = 4;
                }
                dc.SubmitChanges();
            }
        }
    }
}
