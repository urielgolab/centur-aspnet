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
        public class HojasRuta
        {
            public static void ProgramacionDiariaProcesar()
            {
                string[] fileEntries = Directory.GetFiles(srvParametros.ObtenerParametro("Interfaz.CarpetaEntrada") + "\\INTSAPMOE_HR", "ISMHR*.txt");

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
                                        oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTSAPMOE_HR").idInterfaz, 2);
                                        oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                                        strTrenAnterior = strLinea.Substring(0, 10);
                                    }

                                    INTSAPMOE_HR oIntHojaRuta = new INTSAPMOE_HR();
                                    oIntHojaRuta.idCorrida = oIntCorrida.idCorrida;
                                    oIntHojaRuta.Tren= strLinea.Substring(10, 17);
                                    //oIntHojaRuta.CodigoDestino = strLinea.Substring(10, 40);
                                    //oIntHojaRuta.OrigenTren = strLinea.Substring(50, 20);
                                    //oIntHojaRuta.DestinoTren = strLinea.Substring(70, 20);
                                    //oIntHojaRuta.FechaProgramadaSalida = strLinea.Substring(90, 6);
                                    //oIntHojaRuta.HoraProgramadaSalida = strLinea.Substring(96, 4);
                                    //oIntHojaRuta.FechaProgramadaLlegada = strLinea.Substring(100, 6);
                                    //oIntHojaRuta.HoraProgramadaLlegada = strLinea.Substring(106, 4);
                                    //oIntHojaRuta.FechaPlanificada = strLinea.Substring(110, 6);
                                    //oIntHojaRuta.HoraPlanificada = strLinea.Substring(116, 4);
                                    //oIntHojaRuta.EstacionOrigen = strLinea.Substring(120, 20);
                                    //oIntHojaRuta.EstacionDestino = strLinea.Substring(140, 20);
                                    //oIntHojaRuta.Actividad = strLinea.Substring(160, 2);
                                    //oIntHojaRuta.Minutos = strLinea.Substring(162, 3);
                                    //oIntHojaRuta.FechaInicio = strLinea.Substring(165, 6);
                                    //oIntHojaRuta.HoraInicio = strLinea.Substring(171, 4);
                                    //oIntHojaRuta.FechaFin = strLinea.Substring(175, 6);
                                    //oIntHojaRuta.HoraFin = strLinea.Substring(181, 4);
                                    //oIntHojaRuta.Procesada = 0;

                                    dc.INTSAPMOE_HR.InsertOnSubmit(oIntHojaRuta);

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
            }
        }
    }
}