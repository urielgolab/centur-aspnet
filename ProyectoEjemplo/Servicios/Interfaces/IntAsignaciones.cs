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
        public class IntAsignaciones
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

                    string strRutaCompletaArchivo = Path.GetFullPath(srvParametros.ObtenerParametro("Interfaz.CarpetaSalida")) + "\\INTMOESAP_EQUTRE\\IMSEQUTRE " + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
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
            
            /*public static void PersonalProcesar()
            {
                string[] fileEntries = Directory.GetFiles(srvParametros.ObtenerParametro("Interfaz.CarpetaEntrada") + "\\INTPERMOE_APT", "IPMPERTRE *.txt");

                DC dc = new DC();
                foreach (string fileName in fileEntries)
                {
                    //verifico que no se haya procesado el archivo.
                    if (dc.Interfaces_Corridas.Count(m => m.NombreArchivo == Path.GetFileName(fileName)) == 0)
                    {
                        //Procedo a leer el archivo de programación diaria
                        try
                        {
                            using (StreamReader fleArchivo = new StreamReader(fileName, Encoding.GetEncoding(1252))) //CODIFICACIÓN LATINA: Ñ, Á, ETC.
                            {
                                String strLinea, strTrenAnterior = "";
                                Interfaces_Corridas oIntCorrida = null;
                                while ((strLinea = fleArchivo.ReadLine()) != null)
                                {
                                    if (strLinea.Substring(0, 10) != strTrenAnterior)
                                    {
                                        oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTPERMOE_APT").idInterfaz, 2);
                                        oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                                        strTrenAnterior = strLinea.Substring(0, 10);
                                    }

                                    INTPERMOE_APT oIntPersonal = new INTPERMOE_APT();
                                    oIntPersonal.idCorrida = oIntCorrida.idCorrida;
                                    oIntPersonal.Tren= strLinea.Substring(0, 10);
                                    oIntPersonal.Legajo = strLinea.Substring(10, 16);
                                    oIntPersonal.Documento = strLinea.Substring(26, 8);
                                    oIntPersonal.Nombre= strLinea.Substring(34, 50);
                                    oIntPersonal.Estacion= strLinea.Substring(84, 6);
                                    oIntPersonal.Funcion = Convert.ToChar(strLinea.Substring(90, 1));
                                    oIntPersonal.FechaAsignacion= strLinea.Substring(91, 6);
                                    oIntPersonal.HoraAsignacion= strLinea.Substring(97, 4);
                                    oIntPersonal.Procesada = 0;

                                    dc.INTPERMOE_APT.InsertOnSubmit(oIntPersonal);

                                    //Actualizo la corrida
                                    oIntCorrida.NombreArchivo = Path.GetFileName(fileName);
                                    oIntCorrida.Procesada = 0;
                                    oIntCorrida.Archivo += strLinea + Environment.NewLine;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("No se pudo leer el archivo " + fileName);
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                dc.SubmitChanges();
            }            */
        }
    }
}
