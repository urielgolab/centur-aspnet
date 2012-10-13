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
        public class ProgDiaria
        {
            public static void ProgramacionDiariaProcesar()
            {
                string[] fileEntries = Directory.GetFiles(srvParametros.ObtenerParametro("Interfaz.CarpetaEntrada") + "\\INTCFLMOE_PD", "ICMPD*.txt");

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
                                        oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTCFLMOE_PD").idInterfaz, 2);
                                        oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                                        strTrenAnterior = strLinea.Substring(0, 10);
                                    }

                                    INTCFLMOE_PD oIntProgDiaria = new INTCFLMOE_PD();
                                    oIntProgDiaria.idCorrida = oIntCorrida.idCorrida;
                                    oIntProgDiaria.Version = Path.GetFileName(fileName).Substring(5, 3);
                                    oIntProgDiaria.NroTren = strLinea.Substring(0, 10);
                                    oIntProgDiaria.RutaSAP = strLinea.Substring(10, 40);
                                    oIntProgDiaria.OrigenTren = strLinea.Substring(50, 20);
                                    oIntProgDiaria.DestinoTren = strLinea.Substring(70, 20);
                                    oIntProgDiaria.FechaProgramadaSalida = strLinea.Substring(90, 6);
                                    oIntProgDiaria.HoraProgramadaSalida = strLinea.Substring(96, 4);
                                    oIntProgDiaria.FechaProgramadaLlegada = strLinea.Substring(100, 6);
                                    oIntProgDiaria.HoraProgramadaLlegada = strLinea.Substring(106, 4);
                                    oIntProgDiaria.FechaPlanificada = strLinea.Substring(110, 6);
                                    oIntProgDiaria.HoraPlanificada = strLinea.Substring(116, 4);
                                    oIntProgDiaria.EstacionOrigen = strLinea.Substring(120, 20);
                                    oIntProgDiaria.EstacionDestino = strLinea.Substring(140, 20);
                                    oIntProgDiaria.Actividad = strLinea.Substring(160, 2);
                                    oIntProgDiaria.Minutos = strLinea.Substring(162, 3);
                                    oIntProgDiaria.FechaInicio = strLinea.Substring(165, 6);
                                    oIntProgDiaria.HoraInicio = strLinea.Substring(171, 4);
                                    oIntProgDiaria.FechaFin = strLinea.Substring(175, 6);
                                    oIntProgDiaria.HoraFin = strLinea.Substring(181, 4);
                                    oIntProgDiaria.Procesada = 0;

                                    dc.INTCFLMOE_PD.InsertOnSubmit(oIntProgDiaria);

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