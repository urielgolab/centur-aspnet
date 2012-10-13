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
        public static Interfaces_Corridas CrearCorrida(int idInterfaz,int intEstadoInicial)
        {
            DC dc = new DC();


            Interfaces_Corridas oIntCorrida = new Interfaces_Corridas();
            oIntCorrida.Archivo = "";
            oIntCorrida.idInterfaz=idInterfaz;
            oIntCorrida.Procesada = Convert.ToByte(intEstadoInicial);
            oIntCorrida.Fecha=DateTime.Now;
            oIntCorrida.NombreArchivo = "";
            dc.Interfaces_Corridas.InsertOnSubmit(oIntCorrida);
            dc.SubmitChanges();

            return oIntCorrida;
        }

        public static void ProcesarInterfazSalida(string strNombreInterfaz)
        {
            DC dc = new DC();
            Interfaces_Corridas oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == strNombreInterfaz).idInterfaz, 5);
            oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
            
            string strArchivoSalida = "";
            string strNombreArchivo = "";
            int intRegistrosProcesados = 0;

            switch (strNombreInterfaz)
            {
                case "INTMOESAP_EQUTRE":
                    strNombreArchivo = "IMSEQUTRE ";
                    
                    foreach (Asignaciones Asignacion in dc.Asignaciones.Where(m => m.Procesada == 0).OrderBy(j => j.idAsignacion))
                    {
                        intRegistrosProcesados++;
                        strArchivoSalida += dc.Trenes.Single(m => m.idTren == Asignacion.idTren).NroTren.PadRight(10);
                        strArchivoSalida += (Asignacion.FechaTransaccion != null ? Convert.ToDateTime(Asignacion.FechaTransaccion).ToString("ddMMyy") : "").PadRight(6);
                        strArchivoSalida += (Asignacion.FechaTransaccion != null ? Convert.ToDateTime(Asignacion.FechaTransaccion).ToString("HHmm") : "").PadRight(4);
                        strArchivoSalida += Asignacion.Operacion.PadRight(3);
                        strArchivoSalida += (Asignacion.idEquipo != null ? Asignacion.idEquipo : Asignacion.idUFT).ToString().PadRight(6);
                        strArchivoSalida += Asignacion.Funcion.PadRight(1);
                        strArchivoSalida += dc.Estaciones.Single(j => j.idEstacion == Asignacion.idEstacion).idEstacionSAP.ToString().PadRight(6);
                        strArchivoSalida += Asignacion.ProgresivaPoste.ToString().PadRight(8);
                        strArchivoSalida += dc.Causas_Asignaciones_SAP.Single(j => j.idCausaAsignacion == Asignacion.idCausaAsignacion).CodigoSAP.ToString().PadRight(4);
                        strArchivoSalida += DateTime.Now.ToString("yyyyMMddHHmmss").PadRight(14);
                        strArchivoSalida += "\r\n";

                        Asignacion.Procesada = 1;
                        Asignacion.idCorrida = oIntCorrida.idCorrida;
                        oIntCorrida.Archivo += strArchivoSalida;
                    }
                    break;
                case "INTMOECFL_OBS":
                    strNombreArchivo = "IMCOBS";

                    strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<Obs>\r\n";
                    foreach (Tren_Obs ObsPlan in dc.Tren_Obs.Where(m=>m.Procesada==0).OrderBy(j=>j.idTrenObs))
                    {
                        intRegistrosProcesados++;
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

                    break;
                case "INTMOECFL_FT":
                    strNombreArchivo = "IMCFTR ";

                    strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<FichaTren>\r\n";
                    foreach (Tren_Ficha TrenFicha in dc.Tren_Ficha.Where(m => m.Procesada == 0).OrderBy(j => j.idFicha))
                    {
                        intRegistrosProcesados++;
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
                    break;
                default:// ES UNA PASADA SAP O CFLEX INTMOECFL_PAS - INTMOECFL_PAS
                    if (strNombreInterfaz == "INTMOECFL_PAS")
                        strNombreArchivo = "IMCPASADAS ";
                    else if (strNombreInterfaz == "INTMOESAP_PAS")
                        strNombreArchivo = "IMSPASADAS ";
                        else
                            return;

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
                                          idCorrida = (strNombreInterfaz=="INTMOECFL_PAS"?pas.idCorridaCFLEX:pas.idCorridaSAP),
                                          Procesada= (strNombreInterfaz=="INTMOECFL_PAS"?pas.ProcesadaCFLEX:pas.ProcesadaSAP),
                                          CausaDetencion = (int?)null,
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
                                              idCorrida = (strNombreInterfaz == "INTMOECFL_PAS" ? det.idCorridaCFLEX : det.idCorridaSAP),
                                              Procesada = (strNombreInterfaz == "INTMOECFL_PAS" ? det.ProcesadaCFLEX : det.ProcesadaSAP),
                                              CausaDetencion = det.idCausaDetencion,
                                              Tabla = "DETENCIONES",
                                              id = det.idDetencion
                                          };
                    TrenDetYPasadas.Union(TrenPasadas);
                    
                    strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<Pasada>\r\n";
                    foreach (var Pasada in TrenDetYPasadas)
                    {
                        intRegistrosProcesados++;

                        if (strNombreInterfaz == "INTMOECFL_PAS")
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
                        }
                        else
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
                        }

                        if (Pasada.Tabla == "PASADAS")
                        {
                            Tren_Pasadas TrenPasada = dc.Tren_Pasadas.Single(m => m.idPasada == Pasada.id);
                            if (strNombreInterfaz == "INTMOECFL_PAS")
                            {
                                TrenPasada.ProcesadaCFLEX = 1;
                                TrenPasada.idCorridaCFLEX = oIntCorrida.idCorrida;
                            }
                            else
                            {
                                TrenPasada.ProcesadaSAP = 1;
                                TrenPasada.idCorridaSAP= oIntCorrida.idCorrida;
                            }
                        }
                        else
                        {
                            Tren_Detenciones TrenDetencion = dc.Tren_Detenciones.Single(m => m.idDetencion == Pasada.id);
                            if (strNombreInterfaz == "INTMOECFL_PAS")
                            {
                                TrenDetencion.ProcesadaCFLEX = 1;
                                TrenDetencion.idCorridaCFLEX = oIntCorrida.idCorrida;
                            }
                            else
                            {
                                TrenDetencion.ProcesadaSAP = 1;
                                TrenDetencion.idCorridaSAP = oIntCorrida.idCorrida;
                            }
                        }

                        INTMOECFL_PAS oIntPasada = new INTMOECFL_PAS();
                        oIntPasada.idCorrida = Pasada.idCorrida;
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

                    break;
            }
            if(intRegistrosProcesados>0)
            {
                string strRutaCompletaArchivo = Path.GetFullPath(srvParametros.ObtenerParametro("Interfaz.CarpetaSalida")) + "\\"+strNombreInterfaz+"\\"+strNombreArchivo + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
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
        public static void ProcesarInterfazEntrada(string strNombreInterfaz)
        {
            string strNombreArchivo="";
            bool blnCorridaUnica = true;
            switch (strNombreInterfaz)
            {
                case "INTSAPMOE_LOCEST": //EstadoLocomotoras
                    strNombreArchivo = "ISMLOCEST";
                    break;
                case "INTSAPMOE_HR": //HojasRuta
                    strNombreArchivo = "ISMHR";
                    break;
                case "INTPERMOE_APT": //Personal
                    strNombreArchivo = "IPMPERTRE ";
                    break;
                case "INTCFLMOE_PD": //ProgDiaria
                    strNombreArchivo = "ICMPD";
                    blnCorridaUnica = false;
                    break;
            }
            string[] fileEntries = Directory.GetFiles(srvParametros.ObtenerParametro("Interfaz.CarpetaEntrada") + "\\" + strNombreInterfaz, strNombreArchivo + "*.txt");

            DC dc = new DC();
            foreach (string fileName in fileEntries)
            {
                //verifico que no se haya procesado el archivo.
                //if (dc.Interfaces_Corridas.Count(m => m.NombreArchivo == Path.GetFileName(fileName)) == 0)

                //Procedo a leer el archivo de programación diaria
                try
                {
                    using (StreamReader fleArchivo = new StreamReader(fileName, Encoding.GetEncoding(1252))) //CODIFICACIÓN LATINA: Ñ, Á, ETC.
                    {
                        String strLinea, strTrenAnterior = "";
                        Interfaces_Corridas oIntCorrida = null;
                        while ((strLinea = fleArchivo.ReadLine()) != null)
                        {
                            if (blnCorridaUnica)
                            {
                                oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == strNombreInterfaz).idInterfaz, 2);
                                oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
                            }

                            switch (strNombreInterfaz)
                            {
                                case "INTSAPMOE_LOCEST": //EstadoLocomotoras
                                    INTSAPMOE_LOCEST oIntEstadoLoc = new INTSAPMOE_LOCEST();
                                    oIntEstadoLoc.idCorrida = oIntCorrida.idCorrida;
                                    oIntEstadoLoc.IdEquipo = strLinea.Substring(0, 4);
                                    oIntEstadoLoc.EstadoMecanico = strLinea.Substring(4, 4);
                                    oIntEstadoLoc.FechaEstado = strLinea.Substring(8, 12);
                                    oIntEstadoLoc.Procesada = 0;

                                    dc.INTSAPMOE_LOCEST.InsertOnSubmit(oIntEstadoLoc);
                                    break;
                                case "INTSAPMOE_HR": //HojasRuta
                                    INTSAPMOE_HR oIntHojaRuta = new INTSAPMOE_HR();
                                    oIntHojaRuta.idCorrida = oIntCorrida.idCorrida;
                                    oIntHojaRuta.Tren = strLinea.Substring(10, 17);

                                    dc.INTSAPMOE_HR.InsertOnSubmit(oIntHojaRuta);
                                    break;
                                case "INTPERMOE_APT": //Personal
                                    INTPERMOE_APT oIntPersonal = new INTPERMOE_APT();
                                    oIntPersonal.idCorrida = oIntCorrida.idCorrida;
                                    oIntPersonal.Tren = strLinea.Substring(0, 10);
                                    oIntPersonal.Legajo = strLinea.Substring(10, 16);
                                    oIntPersonal.Documento = strLinea.Substring(26, 8);
                                    oIntPersonal.Nombre = strLinea.Substring(34, 50);
                                    oIntPersonal.Estacion = strLinea.Substring(84, 6);
                                    oIntPersonal.Funcion = Convert.ToChar(strLinea.Substring(90, 1));
                                    oIntPersonal.FechaAsignacion = strLinea.Substring(91, 6);
                                    oIntPersonal.HoraAsignacion = strLinea.Substring(97, 4);
                                    oIntPersonal.Procesada = 0;

                                    dc.INTPERMOE_APT.InsertOnSubmit(oIntPersonal);
                                    break;
                                case "INTCFLMOE_PD": //ProgDiaria
                                    if (strLinea.Substring(0, 10) != strTrenAnterior)
                                    {
                                        oIntCorrida = srvInterfaces.CrearCorrida(dc.Interfaces.Single(l => l.Nombre == strNombreInterfaz).idInterfaz, 2);
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
                                    break;
                            }

                            //Actualizo la corrida
                            oIntCorrida.NombreArchivo = Path.GetFileName(fileName);
                            oIntCorrida.Procesada = 0;
                            oIntCorrida.Archivo += strLinea + Environment.NewLine;
                        }
                        //Elimino el archivo procesado
                        fleArchivo.Close();
                        File.Delete(fileName);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("No se pudo leer el archivo " + fileName);
                    Console.WriteLine(e.Message);
                }
            }
            dc.SubmitChanges();
        }
    }
}
