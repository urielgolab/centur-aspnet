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
        public class FichaTren
        {
            public static void TrenFichaProcesar()
            {
                DC dc = new DC();
                Interfaces_Corridas oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == "INTMOECFL_FT").idInterfaz, 5);

                var TrenFichas = from ft in dc.Tren_Ficha
                                 where ft.Procesada == 0
                                 select ft;


                //actualizo el objeto para asociarlo al dc actual
                oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                if (TrenFichas.Count() > 0)
                {
                    string strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<FichaTren>\r\n";
                    foreach (Tren_Ficha TrenFicha in TrenFichas)
                    {
                        strArchivoSalida +=
                            "<FichaTrenReg>\r\n" +
                                "\t<NumeroTren>" + TrenFicha.Trenes.NroTren + "</NumeroTren>\r\n" +
                                "\t<FechaTransaccion>" + (TrenFicha.FechaTransaccion != null ? Convert.ToDateTime(TrenFicha.FechaTransaccion).ToString("ddMMyy") : "") + "</FechaTransaccion>\r\n" +
                                "\t<HoraTransaccion>" + (TrenFicha.FechaTransaccion != null ? Convert.ToDateTime(TrenFicha.FechaTransaccion).ToString("HHmm") : "") + "</HoraTransaccion>\r\n" +
                                "\t<Conductor>" + (TrenFicha.idConductor != null ? dc.Personal.Single(m => m.Legajo == TrenFicha.idConductor).Nombre : "") + "</Conductor>\r\n" +
                                "\t<JefeTren>" + (TrenFicha.idAyudante != null ? dc.Personal.Single(m => m.Legajo == TrenFicha.idAyudante).Nombre : "") + "</JefeTren>\r\n" +
                                "\t<Locomotora>" + TrenFicha.idEquipo + "</Locomotora>\r\n" +
                                "\t<UFT>" + TrenFicha.idUFT + "</UFT>\r\n" +
                            //REVISAR: Division y Estacion CFLEX dc.Estaciones_CFLEX.Single(m=>m.idEstacionCFLEX==dc.Estaciones.Single(j=>j.idEstacion==TrenFicha.idEstacion).idEstacionCFLEX).Division
                                "\t<Division>" + TrenFicha.idDivision + "</Division>\r\n" +
                                "\t<Estacion>" + TrenFicha.idEstacion + "</Estacion>\r\n" +
                                "\t<VagonesCargados>" + TrenFicha.VagonesCargados.ToString() + "</VagonesCargados>\r\n" +
                                "\t<VagonesVacios>" + TrenFicha.VagonesVacios.ToString() + "</VagonesVacios>\r\n" +
                                "\t<Tonelaje>" + TrenFicha.Tonelaje.ToString() + "</Tonelaje>\r\n" +
                                "\t<Longitud>" + TrenFicha.Longitud.ToString() + "</Longitud>\r\n" +
                                "\t<NumeroUltimoVagon>" + TrenFicha.NroUltimoVagon.ToString() + "</NumeroUltimoVagon>\r\n" +
                                "\t<Gasoil>" + TrenFicha.Gasoil.ToString() + "</Gasoil>\r\n" +
                                "\t<Precinto1>" + TrenFicha.Prescinto1.ToString() + "</Precinto1>\r\n" +
                                "\t<Precinto2>" + TrenFicha.Prescinto2.ToString() + "</Precinto2>\r\n" +
                                "\t<OtrasLocomotoras>" + TrenFicha.idEquipo2.ToString() + (TrenFicha.idEquipo3 != null ? ", " + TrenFicha.idEquipo3.ToString() : "") + (TrenFicha.idUFT2 != null ? ",UFT: " + TrenFicha.idUFT2.ToString() : "") + "</OtrasLocomotoras>\r\n" +
                                "\t<Observaciones>" + TrenFicha.Obs + "</Observaciones>\r\n" +
                            "</FichaTrenReg>\r\n";
                        TrenFicha.Procesada = 1;
                        TrenFicha.idCorrida = oIntCorrida.idCorrida;


                        INTMOECFL_FT oIntFichaTren = new INTMOECFL_FT();
                        oIntFichaTren.idCorrida = TrenFicha.idCorrida;
                        oIntFichaTren.NroTren = TrenFicha.Trenes.NroTren;
                        oIntFichaTren.Fecha = (TrenFicha.FechaTransaccion != null ? Convert.ToDateTime(TrenFicha.FechaTransaccion).ToString("ddMMyy") : "");
                        oIntFichaTren.Hora = (TrenFicha.FechaTransaccion != null ? Convert.ToDateTime(TrenFicha.FechaTransaccion).ToString("HHmm") : "");
                        oIntFichaTren.Conductor = (TrenFicha.idConductor != null ? dc.Personal.Single(m => m.Legajo == TrenFicha.idConductor).Nombre : "");
                        oIntFichaTren.JefeTren = (TrenFicha.idAyudante != null ? dc.Personal.Single(m => m.Legajo == TrenFicha.idAyudante).Nombre : "");
                        oIntFichaTren.Locomotora = TrenFicha.idEquipo;
                        oIntFichaTren.UFT = TrenFicha.idUFT;
                        oIntFichaTren.Estacion = TrenFicha.idEstacion.ToString();
                        oIntFichaTren.VagonesCargados = TrenFicha.VagonesCargados;
                        oIntFichaTren.VagonesVacios = TrenFicha.VagonesVacios;
                        oIntFichaTren.Tonelaje = TrenFicha.Tonelaje;
                        oIntFichaTren.Longitud = TrenFicha.Longitud;
                        oIntFichaTren.NroUltimoVagon = TrenFicha.NroUltimoVagon;
                        oIntFichaTren.Gasoil = TrenFicha.Gasoil;
                        oIntFichaTren.Prescinto1 = TrenFicha.Prescinto1;
                        oIntFichaTren.Prescinto2 = TrenFicha.Prescinto2;
                        oIntFichaTren.OtrasLocomotoras = TrenFicha.idEquipo2.ToString() + (TrenFicha.idEquipo3 != null ? ", " + TrenFicha.idEquipo3.ToString() : "") + (TrenFicha.idUFT2 != null ? ",UFT: " + TrenFicha.idUFT2.ToString() : "");
                        oIntFichaTren.Obs = TrenFicha.Obs;
                        dc.INTMOECFL_FT.InsertOnSubmit(oIntFichaTren);
                    }
                    strArchivoSalida += "</FichaTren>\r\n";

                    string strRutaCompletaArchivo = Path.GetFullPath(srvParametros.ObtenerParametro("Interfaz.CarpetaSalida")) + "\\INTMOECFL_FT\\IMCFTR " + DateTime.Now.ToString("yyyyMMddHHmm") + ".xml";
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