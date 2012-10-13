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
        public class Pasadas
        {
            public static void PasadasACflexProcesar()
            {
                DC dc = new DC();
                Interfaces_Corridas oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTMOECFL_PAS").idInterfaz, 5);

                var TrenPasadas = from pas in dc.Tren_Pasadas
                                  where pas.ProcesadaCFLEX == 0
                                  select new
                                  {
                                      NroTren = pas.Trenes.NroTren,
                                      Fecha = pas.Fecha,
                                      Operacion = pas.Operacion,
                                      idEstacion = pas.idEstacion,
                                      idDivision = pas.idDivision,
                                      ProgresivaPoste = pas.ProgresivaPoste,
                                      Obs = pas.Obs,
                                      idCorridaCFLEX = pas.idCorridaCFLEX,
                                      ProcesadaCFLEX = pas.ProcesadaCFLEX,
                                      Tabla = "PASADAS",
                                      id = pas.idPasada
                                  };
                var TrenDetYPasadas = from det in dc.Tren_Detenciones
                                      where det.ProcesadaCFLEX == 0
                                      select new
                                      {
                                          NroTren = dc.Trenes.SingleOrDefault(m => m.idTren == det.idTren).NroTren,
                                          Fecha = det.Fecha,
                                          Operacion = det.Operacion,
                                          idEstacion = det.idEstacion,
                                          idDivision = det.idDivision,
                                          ProgresivaPoste = det.ProgresivaPoste,
                                          Obs = det.Obs,
                                          idCorridaCFLEX = det.idCorridaCFLEX,
                                          ProcesadaCFLEX = det.ProcesadaCFLEX,
                                          Tabla = "DETENCIONES",
                                          id = det.idDetencion
                                      };
                TrenDetYPasadas.Union(TrenPasadas);

                //actualizo el objeto para asociarlo al dc actual
                oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                if (TrenDetYPasadas.Count() > 0)
                {
                    string strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<Pasada>\r\n";
                    foreach (var Pasada in TrenDetYPasadas)
                    {
                        strArchivoSalida +=
                            "<PasadaReg>\r\n" +
                                "\t<NumeroTren>" + Pasada.NroTren + "</NumeroTren>\r\n" +
                                "\t<FechaTransaccion>" + (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("ddMMyy") : "") + "</FechaTransaccion>\r\n" +
                                "\t<HoraTransaccion>" + (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("HHmm") : "") + "</HoraTransaccion>\r\n" +
                                "\t<Operacion>" + Pasada.Operacion + "</Operacion>\r\n" +
                                "\t<EstacionTramo>" + dc.Estaciones.Single(j => j.idEstacion == Pasada.idEstacion).idEstacionCFLEX + "</Estacion>\r\n" + //idESTACIONCFLEX
                                "\t<Division>" + dc.Divisiones.Single(m => m.idDivision == Pasada.idDivision).Nombre + "</Division>\r\n" +
                                "\t<Progresiva>" + Pasada.ProgresivaPoste.ToString() + "</Progresiva>\r\n" +
                                "\t<Observacion>" + Pasada.Obs + "</Observacion>\r\n" +
                            "</PasadaReg>\r\n";
                        //
                        if (Pasada.Tabla == "PASADAS")
                        {
                            Tren_Pasadas TrenPasada = dc.Tren_Pasadas.Single(m => m.idPasada == Pasada.id);
                            TrenPasada.ProcesadaCFLEX = 1;
                            TrenPasada.idCorridaCFLEX = oIntCorrida.idCorrida;
                        }
                        else
                        {
                            Tren_Detenciones TrenDetencion = dc.Tren_Detenciones.Single(m => m.idDetencion == Pasada.id);
                            TrenDetencion.ProcesadaCFLEX = 1;
                            TrenDetencion.idCorridaCFLEX = oIntCorrida.idCorrida;
                        }

                        INTMOECFL_PAS oIntPasada = new INTMOECFL_PAS();
                        oIntPasada.idCorrida = Pasada.idCorridaCFLEX;
                        oIntPasada.NroTren = Pasada.NroTren;
                        oIntPasada.Fecha = (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("ddMMyy") : "");
                        oIntPasada.Hora = (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("HHmm") : "");
                        oIntPasada.Operacion = Pasada.Operacion;
                        oIntPasada.Estacion = dc.Estaciones.Single(m => m.idEstacion == Pasada.idEstacion).Nombre;
                        oIntPasada.Division = dc.Divisiones.Single(m => m.idDivision == Pasada.idDivision).Nombre;
                        oIntPasada.Progresiva = Pasada.ProgresivaPoste;
                        oIntPasada.Obs = Pasada.Obs;
                        dc.INTMOECFL_PAS.InsertOnSubmit(oIntPasada);
                    }
                    strArchivoSalida += "</Pasada>\r\n";

                    string strRutaCompletaArchivo = Path.GetFullPath(srvParametros.ObtenerParametro("Interfaz.CarpetaSalida")) + "\\INTMOECFL_PAS\\IMCPASADAS " + DateTime.Now.ToString("yyyyMMddHHmm") + ".xml";
                    oIntCorrida.NombreArchivo = Path.GetFileName(strRutaCompletaArchivo);
                    if (!Directory.Exists(Path.GetDirectoryName(strRutaCompletaArchivo)))
                        Directory.CreateDirectory(Path.GetDirectoryName(strRutaCompletaArchivo));

                    StreamWriter fleArchivoGenerado = File.CreateText(strRutaCompletaArchivo);
                    fleArchivoGenerado.Write(strArchivoSalida);
                    fleArchivoGenerado.Close();

                    oIntCorrida.Archivo = strArchivoSalida;
                    oIntCorrida.Procesada = 6;
                }
                else
                {
                    oIntCorrida.NombreArchivo = "Sin archivo";
                    oIntCorrida.Procesada = 4;
                }

                dc.SubmitChanges();
            }
            public static void PasadasASapProcesar()
            {
                DC dc = new DC();
                Interfaces_Corridas oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTMOESAP_PAS").idInterfaz, 5);

                var TrenPasadas = from pas in dc.Tren_Pasadas
                                  where pas.ProcesadaSAP == 0
                                  orderby pas.idLog
                                  select new
                                  {
                                      NroTren = pas.Trenes.NroTren,
                                      Fecha = pas.Fecha,
                                      Operacion = pas.Operacion,
                                      idEstacion = dc.Estaciones.Single(j => j.idEstacion == pas.idEstacion).idEstacionSAP,
                                      idDivision = pas.idDivision,
                                      ProgresivaPoste = pas.ProgresivaPoste,
                                      Obs = pas.Obs,
                                      idCorridaCFLEX = pas.ProcesadaSAP,
                                      ProcesadaCFLEX = pas.ProcesadaSAP,
                                      CausaDetencion = (int?)null,
                                      Tabla = "PASADAS",
                                      id = pas.idPasada
                                  };
                var TrenDetYPasadas = from det in dc.Tren_Detenciones
                                      where det.ProcesadaSAP == 0
                                      orderby det.idLog
                                      select new
                                      {
                                          NroTren = dc.Trenes.SingleOrDefault(m => m.idTren == det.idTren).NroTren,
                                          Fecha = det.Fecha,
                                          Operacion = det.Operacion,
                                          idEstacion = dc.Estaciones.Single(j => j.idEstacion == det.idEstacion).idEstacionSAP,
                                          idDivision = det.idDivision,
                                          ProgresivaPoste = det.ProgresivaPoste,
                                          Obs = det.Obs,
                                          idCorridaCFLEX = det.ProcesadaSAP,
                                          ProcesadaCFLEX = det.ProcesadaSAP,
                                          CausaDetencion = det.idCausaDetencion,
                                          Tabla = "DETENCIONES",
                                          id = det.idDetencion
                                      };
                TrenDetYPasadas.Union(TrenPasadas);

                //actualizo el objeto para asociarlo al dc actual
                oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                if (TrenDetYPasadas.Count() > 0)
                {
                    string strArchivoSalida = "";
                    foreach (var Pasada in TrenDetYPasadas)
                    {
                        strArchivoSalida += Pasada.NroTren.PadRight(10);
                        strArchivoSalida += (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("ddMMyy") : "").PadRight(6);
                        strArchivoSalida += (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("HHmm") : "").PadRight(4);
                        strArchivoSalida += Pasada.Operacion.PadRight(3);
                        strArchivoSalida += Pasada.idEstacion.ToString().PadRight(6);
                        strArchivoSalida += Pasada.ProgresivaPoste.ToString().PadRight(8);
                        strArchivoSalida += Pasada.CausaDetencion.ToString().PadRight(4);
                        strArchivoSalida += DateTime.Now.ToString("yyyyMMddHHmmss").PadRight(14);
                        strArchivoSalida += "\r\n";

                        if (Pasada.Tabla == "PASADAS")
                        {
                            Tren_Pasadas TrenPasada = dc.Tren_Pasadas.Single(m => m.idPasada == Pasada.id);
                            TrenPasada.ProcesadaSAP = 1;
                            TrenPasada.idCorridaSAP = oIntCorrida.idCorrida;
                        }
                        else
                        {
                            Tren_Detenciones TrenDetencion = dc.Tren_Detenciones.Single(m => m.idDetencion == Pasada.id);
                            TrenDetencion.ProcesadaSAP = 1;
                            TrenDetencion.idCorridaSAP = oIntCorrida.idCorrida;
                        }
                        oIntCorrida.Archivo += strArchivoSalida;
                    }

                    string strRutaCompletaArchivo = Path.GetFullPath(srvParametros.ObtenerParametro("Interfaz.CarpetaSalida")) + "\\INTMOESAP_PAS\\IMSPASADAS " + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
                    oIntCorrida.NombreArchivo = Path.GetFileName(strRutaCompletaArchivo);
                    if (!Directory.Exists(Path.GetDirectoryName(strRutaCompletaArchivo)))
                        Directory.CreateDirectory(Path.GetDirectoryName(strRutaCompletaArchivo));

                    StreamWriter fleArchivoGenerado = File.CreateText(strRutaCompletaArchivo);
                    fleArchivoGenerado.Write(oIntCorrida.Archivo.Substring(0,oIntCorrida.Archivo.Length-2)); //elimina ultimo \r\n
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
