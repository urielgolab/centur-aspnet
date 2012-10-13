using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Datos;

namespace Servicios
{
    public partial class srvInterfaces
    {
        public class ObsPlan
        {
            public static void TrenObsPlanProcesar()
            {
                DC dc = new DC();
                Interfaces_Corridas oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTMOECFL_OBS").idInterfaz, 5);

                var TrenObservaciones = from obs in dc.Tren_Obs
                                        where obs.Procesada == 0
                                        select obs;

                //actualizo el objeto para asociarlo al dc actual
                oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                if (TrenObservaciones.Count() > 0)
                {
                    string strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<Obs>\r\n";
                    foreach (Tren_Obs ObsPlan in TrenObservaciones)
                    {
                        strArchivoSalida +=
                            "<ObsReg>\r\n" +
                                "\t<NumeroTren>" + ObsPlan.Trenes.NroTren + "</NumeroTren>\r\n" +
                                "\t<FechaTransaccion>" + (ObsPlan.FechaInicio != null ? Convert.ToDateTime(ObsPlan.FechaInicio).ToString("ddMMyy") : "") + "</FechaTransaccion>\r\n" +
                                "\t<HoraTransaccion>" + (ObsPlan.FechaInicio != null ? Convert.ToDateTime(ObsPlan.FechaInicio).ToString("HHmm") : "") + "</HoraTransaccion>\r\n" +
                                "\t<Duracion>" + ObsPlan.Duracion.ToString() + "</Duracion>\r\n" +
                                "\t<EstacionTramo>" + dc.Estaciones.Single(m => m.idEstacion == ObsPlan.idEstacion).Nombre + "</Estacion>\r\n" +
                                "\t<Division>" + dc.Divisiones.Single(m => m.idDivision == ObsPlan.idDivision).Nombre + "</Division>\r\n" +
                                "\t<Progresiva>" + ObsPlan.ProgresivaPoste.ToString() + "</Progresiva>\r\n" +
                                "\t<CodigoObservacion>" + ObsPlan.idObservacion.ToString() + "</CodigoObservacion>\r\n" +
                                "\t<TextoObservacion>" + ObsPlan.Texto + "</TextoObservacion>\r\n" +
                            "</ObsReg>\r\n";
                        ObsPlan.Procesada = 1;
                        ObsPlan.idCorrida = oIntCorrida.idCorrida;


                        INTMOECFL_OBS oIntObservacionPlan = new INTMOECFL_OBS();
                        oIntObservacionPlan.idCorrida = ObsPlan.idCorrida;
                        oIntObservacionPlan.NroTren = ObsPlan.Trenes.NroTren;
                        oIntObservacionPlan.Fecha = (ObsPlan.FechaInicio != null ? Convert.ToDateTime(ObsPlan.FechaInicio).ToString("ddMMyy") : "");
                        oIntObservacionPlan.Hora = (ObsPlan.FechaInicio != null ? Convert.ToDateTime(ObsPlan.FechaInicio).ToString("HHmm") : "");
                        oIntObservacionPlan.Duracion = ObsPlan.Duracion;
                        oIntObservacionPlan.Estacion = dc.Estaciones.Single(m => m.idEstacion == ObsPlan.idEstacion).Nombre;
                        oIntObservacionPlan.Division = dc.Divisiones.Single(m => m.idDivision == ObsPlan.idDivision).Nombre;
                        oIntObservacionPlan.Progresiva = ObsPlan.ProgresivaPoste;
                        oIntObservacionPlan.idObservacion = ObsPlan.idObservacion;
                        oIntObservacionPlan.Texto = ObsPlan.Texto;
                        dc.INTMOECFL_OBS.InsertOnSubmit(oIntObservacionPlan);
                    }
                    strArchivoSalida += "</Obs>\r\n";

                    string strRutaCompletaArchivo = Path.GetFullPath(srvParametros.ObtenerParametro("Interfaz.CarpetaSalida")) + "\\INTMOECFL_OBS\\IMCOBS" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xml";
                    oIntCorrida.NombreArchivo = Path.GetFileName(strRutaCompletaArchivo);
                    if (!Directory.Exists(Path.GetDirectoryName(strRutaCompletaArchivo)))
                        Directory.CreateDirectory(Path.GetDirectoryName(strRutaCompletaArchivo));

                    StreamWriter fleArchivoGenerado = File.CreateText(oIntCorrida.NombreArchivo);
                    fleArchivoGenerado.Write(strArchivoSalida);
                    fleArchivoGenerado.Close();

                    oIntCorrida.Archivo = strArchivoSalida;
                    oIntCorrida.Procesada = 6;
                }
                else
                {
                    oIntCorrida.Archivo = "Sin archivo";
                    oIntCorrida.Procesada = 4;
                }

                dc.SubmitChanges();
            }
        }
    }
}