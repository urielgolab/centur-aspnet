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
        public class EstadoLocomotoras
        {
            public static void EstadoLocomotorasProcesar()
            {
                string[] fileEntries = Directory.GetFiles(srvParametros.ObtenerParametro("Interfaz.CarpetaEntrada") + "\\INTSAPMOE_LOCEST", "ISMLOCEST*.txt");

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
                                        oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTSAPMOE_LOCEST").idInterfaz, 2);
                                        oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                                        strTrenAnterior = strLinea.Substring(0, 10);
                                    }

                                    INTSAPMOE_LOCEST oIntEstadoLoc = new INTSAPMOE_LOCEST();
                                    oIntEstadoLoc.idCorrida = oIntCorrida.idCorrida;
                                    oIntEstadoLoc.IdEquipo= strLinea.Substring(0, 4);
                                    oIntEstadoLoc.EstadoMecanico = strLinea.Substring(4, 4);
                                    oIntEstadoLoc.FechaEstado= strLinea.Substring(8, 12);
                                    oIntEstadoLoc.Procesada = 0;

                                    dc.INTSAPMOE_LOCEST.InsertOnSubmit(oIntEstadoLoc);

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