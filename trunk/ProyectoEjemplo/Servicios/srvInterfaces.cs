using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

using Datos;

namespace Servicios
{
    public partial class srvInterfaces
    {
        struct tipoDetencionAsignacion
        {
            public string NroTren;
            public DateTime? Fecha;
            public string Operacion;
            public int? idEstacion;
            public int? idEstacionProxima;
            public int? idDivision;
            public decimal? ProgresivaPoste;
            public string Obs;
            public int? idCorrida;
            public short? Procesada;
            public int? CausaDetencion;
            public string Tabla;
            public int id;
        }

        public static Interfaces_Corridas CrearCorrida(DC dc,int idInterfaz,int intEstadoInicial)
        {
            //DC dc = new DC();
            Interfaces_Corridas oIntCorrida = new Interfaces_Corridas();
            oIntCorrida.Archivo = "";
            oIntCorrida.idInterfaz=idInterfaz;
            oIntCorrida.Procesada = intEstadoInicial;
            oIntCorrida.Fecha=DateTime.Now;
            oIntCorrida.NombreArchivo = "";
            dc.Interfaces_Corridas.InsertOnSubmit(oIntCorrida);
            dc.SubmitChanges();

            return oIntCorrida;
        }
        public static bool ExisteInterfaz(string strNombreInterfaz)
        {
            DC dc = new DC();
            return (dc.Interfaces.Count(m => m.Nombre == strNombreInterfaz && m.Estado==1) == 1? true: false);
        }


        public static void ProcesarInterfazSalida(string strNombreInterfaz)
        {
            DC dc = new DC();
            Interfaces oInterfaz=dc.Interfaces.Single(l => l.Nombre == strNombreInterfaz);
            Interfaces_Corridas oIntCorrida = srvInterfaces.CrearCorrida(dc,oInterfaz.idInterfaz, 4/*sin archivo*/);
            //oIntCorrida = dc.Interfaces_Corridas.Single(m => m.idCorrida == oIntCorrida.idCorrida);
            
            string strArchivoSalida = "";
            string strNombreArchivo = "";
            int intRegistrosProcesados = 0;
            bool blnConAdvertencias = false;
            string strCflexExport ="";

                switch (strNombreInterfaz)
                {
                    case "INTMOESAP_EQUTRE":
                        strNombreArchivo = "IMSEQUTRE ";

                        foreach (Asignaciones Asignacion in dc.Asignaciones.Where(m => m.Procesada == 0 && m.idConductor == null).OrderBy(j => j.idAsignacion))
                        {
                            try
                            {
                                string strRegistro = "";
                                intRegistrosProcesados++;
                                strRegistro += dc.Trenes.Single(m => m.idTren == Asignacion.idTren).NroTren.PadRight(10);
                                strRegistro += (Asignacion.FechaTransaccion != null ? Convert.ToDateTime(Asignacion.FechaTransaccion).ToString("ddMMyy") : "").PadRight(6);
                                strRegistro += (Asignacion.FechaTransaccion != null ? Convert.ToDateTime(Asignacion.FechaTransaccion).ToString("HHmm") : "").PadRight(4);
                                strRegistro += (Asignacion.Operacion == "ASI" ? (Asignacion.idEquipo != null ? "ALT" : "AUT") : (Asignacion.idEquipo != null ? "LLT" : "LUT")).PadRight(3);
                                strRegistro += (Asignacion.idEquipo != null ? dc.Equipos.Single(m => m.idEquipo == Asignacion.idEquipo).idSAP : dc.UFTs.Single(m => m.idUFT == Asignacion.idUFT).idSAP).ToString().PadRight(6);
                                strRegistro += (Asignacion.idEquipo != null ? Asignacion.Funcion.Substring(Asignacion.Funcion.IndexOf('_') + 1, 1) : (Asignacion.Funcion == "UFT_PRINCIPAL" ? "1" : "2")).PadRight(1);
                                strRegistro += dc.Divisiones_Detalle.Single(j => j.idEstacion == (Asignacion.idEstacion != null ? Asignacion.idEstacion : Asignacion.idEstacionProxima) && j.idDivision == Asignacion.idDivision).idEstacionSAP.ToString().PadRight(6);
                                strRegistro += Asignacion.ProgresivaPoste.ToString().PadLeft(8).Replace(',', '.').Substring(0, 8);
                                strRegistro += dc.Causas_Asignaciones_SAP.Single(j => j.idCausaAsignacion == Asignacion.idCausaAsignacion).CodigoSAP.ToString().PadRight(4);
                                strRegistro += DateTime.Now.ToString("yyyyMMddHHmmss").PadRight(14);
                                strRegistro += "\r\n";
                                strArchivoSalida += strRegistro;

                                Asignacion.Procesada = 1;
                                Asignacion.idCorrida = oIntCorrida.idCorrida;
                            }
                            catch 
                            {
                                Asignacion.Procesada = 2; //con error
                                Asignacion.idCorrida = oIntCorrida.idCorrida;
                                blnConAdvertencias = true;
                            }                          
                        }
                        break;
                    case "INTMOECFL_OBS":
                        strNombreArchivo = "IMCOBS";
                        strCflexExport="O";
                        strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<Obs>\r\n";
                        foreach (Tren_Obs ObsPlan in dc.Tren_Obs.Where(m => m.Procesada == 0 && m.Estado == 1).OrderBy(j => j.idTrenObs))
                        {
                            try
                            {
                                Estaciones_CFLEX oEstacion = dc.Estaciones_CFLEX.SingleOrDefault(g => g.idEstacionCFLEX == dc.Divisiones_Detalle.SingleOrDefault(j => j.idEstacion == ObsPlan.idEstacion && j.idDivision == ObsPlan.idDivision).idEstacionCFLEX);
                                if (oEstacion != null)
                                {
                                    intRegistrosProcesados++;
                                    strArchivoSalida +=
                                        "<ObsReg>\r\n" +
                                            "\t<NumeroTren>" + ObsPlan.Trenes.NroTren + "</NumeroTren>\r\n" +
                                            "\t<FechaTransaccion>" + (ObsPlan.FechaInicio != null ? Convert.ToDateTime(ObsPlan.FechaInicio).ToString("ddMMyy") : "") + "</FechaTransaccion>\r\n" +
                                            "\t<HoraTransaccion>" + (ObsPlan.FechaInicio != null ? Convert.ToDateTime(ObsPlan.FechaInicio).ToString("HHmm") : "") + "</HoraTransaccion>\r\n" +
                                            "\t<Duracion>" + ObsPlan.Duracion.ToString() + "</Duracion>\r\n" +
                                            "\t<EstacionTramo>" + oEstacion.idCFLEX.ToString() + "</EstacionTramo>\r\n" +
                                            "\t<Division>" + oEstacion.Division + "</Division>\r\n" +
                                            "\t<Progresiva>" + ObsPlan.ProgresivaPoste.ToString().Replace(',', '.') + "</Progresiva>\r\n" +
                                            //CodigoObservacion=0 si idObservacionCflex=null
                                            "\t<CodigoObservacion>" + (ObsPlan.Observaciones!=null && ObsPlan.Observaciones.idObservacionCFLEX!=null? ObsPlan.Observaciones.idObservacionCFLEX.ToString() : "0") + "</CodigoObservacion>\r\n" +
                                            "\t<TextoObservacion>" + (ObsPlan.Observaciones!=null ? ObsPlan.Observaciones.Descripcion :"") + ObsPlan.Texto + "</TextoObservacion>\r\n" +
                                        "</ObsReg>\r\n";
                                    ObsPlan.Procesada = 1;
                                    ObsPlan.idCorrida = oIntCorrida.idCorrida;
                                }
                                else
                                {
                                    ObsPlan.Procesada = 6; //con advertencias
                                    ObsPlan.idCorrida = oIntCorrida.idCorrida;
                                    blnConAdvertencias = true;
                                }
                            }
                            catch
                            {
                                ObsPlan.Procesada = 2; //con error
                                ObsPlan.idCorrida = oIntCorrida.idCorrida;
                                blnConAdvertencias = true;
                            }                          
                        }
                        strArchivoSalida += "</Obs>\r\n";

                        break;
                    case "INTMOECFL_FT":
                        strNombreArchivo = "IMCFTR ";
                        strCflexExport="I";
                        strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<FichaTren>\r\n";
                        foreach (Tren_Ficha TrenFicha in dc.Tren_Fichas.Where(m => m.Procesada == 0 && m.Estado==1).OrderBy(j => j.idFicha))
                        {
                            try
                            {
                                bool blnEsTrenTerceros = TrenFicha.Trenes != null && TrenFicha.Trenes.IdFerrocarril != 1;
                                Estaciones_CFLEX oEstacion = dc.Estaciones_CFLEX.SingleOrDefault(g => g.idEstacionCFLEX == dc.Divisiones_Detalle.SingleOrDefault(j => j.idEstacion == TrenFicha.idEstacion && j.idDivision == TrenFicha.idDivision).idEstacionCFLEX);
                                
                                if (oEstacion != null) //20120828 UG: Solo se exportan las FT con equivalencia en Cflex. 
                                {
                                    intRegistrosProcesados++;
                                    strArchivoSalida +=
                                    "<FichaTrenReg>\r\n" +
                                        "\t<NumeroTren>" + TrenFicha.Trenes.NroTren + "</NumeroTren>\r\n" +
                                        "\t<FechaTransaccion>" + (TrenFicha.FechaTransaccion != null ? Convert.ToDateTime(TrenFicha.FechaTransaccion).ToString("ddMMyy") : "") + "</FechaTransaccion>\r\n" +
                                        "\t<HoraTransaccion>" + (TrenFicha.FechaTransaccion != null ? Convert.ToDateTime(TrenFicha.FechaTransaccion).ToString("HHmm") : "") + "</HoraTransaccion>\r\n";
                                    if (blnEsTrenTerceros)
                                    {
                                        strArchivoSalida +=
                                            "\t<Conductor>" + TrenFicha.ConductorNombre + "</Conductor>\r\n" +
                                            "\t<JefeTren>" + TrenFicha.AyudanteNombre + "</JefeTren>\r\n" +
                                            "\t<Locomotora>" + TrenFicha.idEquipo.ToString() + "</Locomotora>\r\n" +
                                            "\t<UFT>" + TrenFicha.idUFT.ToString() + "</UFT>\r\n" +
                                            "\t<OtrasLocomotoras>" + (TrenFicha.idEquipo2 != null ? ", " + TrenFicha.idEquipo2.ToString() : "") + (TrenFicha.idEquipo3 != null ? ", " + TrenFicha.idEquipo3.ToString() : "") + (TrenFicha.idUFT2 != null ? ",UFT: " + TrenFicha.idUFT2.ToString() : "") + "</OtrasLocomotoras>\r\n";
                                    }
                                    else
                                    {
                                        strArchivoSalida +=
                                            "\t<Conductor>" + (TrenFicha.idConductor != null ? dc.Personal.Single(m => m.Legajo == TrenFicha.idConductor).Nombre : "") + "</Conductor>\r\n" +
                                            "\t<JefeTren>" + (TrenFicha.idAyudante != null ? dc.Personal.Single(m => m.Legajo == TrenFicha.idAyudante).Nombre : "") + "</JefeTren>\r\n" +
                                            "\t<Locomotora>" + srvEquipos.ObtenerEquipo(TrenFicha.idEquipo).idFisico + "</Locomotora>\r\n" +
                                            "\t<UFT>" + (TrenFicha.idUFT != null ? dc.UFTs.Single(m => m.idUFT == TrenFicha.idUFT).idSAP.ToString() : "") + "</UFT>\r\n" +
                                            "\t<OtrasLocomotoras>" + (TrenFicha.idEquipo2 != null ? ", " + srvEquipos.ObtenerEquipo(Convert.ToInt32(TrenFicha.idEquipo2)).idFisico : "") + (TrenFicha.idEquipo3 != null ? ", " + srvEquipos.ObtenerEquipo(Convert.ToInt32(TrenFicha.idEquipo3)).idFisico : "") + (TrenFicha.idUFT2 != null ? ",UFT: " + dc.UFTs.Single(m => m.idUFT == TrenFicha.idUFT2).idSAP.ToString() : "") + "</OtrasLocomotoras>\r\n";
                                    }
                                    strArchivoSalida += "\t<Division>" + oEstacion.Division + "</Division>\r\n" +
                                        "\t<Estacion>" + oEstacion.idCFLEX.ToString() + "</Estacion>\r\n" +
                                        "\t<VagonesCargados>" + TrenFicha.VagonesCargados.ToString() + "</VagonesCargados>\r\n" +
                                        "\t<VagonesVacios>" + TrenFicha.VagonesVacios.ToString() + "</VagonesVacios>\r\n" +
                                        "\t<Tonelaje>" + TrenFicha.Tonelaje.ToString() + "</Tonelaje>\r\n" +
                                        "\t<Longitud>" + TrenFicha.Longitud.ToString() + "</Longitud>\r\n" +
                                        "\t<NumeroUltimoVagon>" + TrenFicha.NroUltimoVagon.ToString() + "</NumeroUltimoVagon>\r\n" +
                                        "\t<Gasoil>" + TrenFicha.Gasoil.ToString() + "</Gasoil>\r\n" +
                                        "\t<Precinto1>" + TrenFicha.Prescinto1.ToString() + "</Precinto1>\r\n" +
                                        "\t<Precinto2>" + TrenFicha.Prescinto2.ToString() + "</Precinto2>\r\n" +
                                        "\t<Observaciones>" + TrenFicha.Obs + "</Observaciones>\r\n" +
                                    "</FichaTrenReg>\r\n";
                                    TrenFicha.Procesada = 1;
                                    TrenFicha.idCorrida = oIntCorrida.idCorrida;
                                }
                                else
                                {
                                    TrenFicha.Procesada = 6; //con advertencias
                                    TrenFicha.idCorrida = oIntCorrida.idCorrida;
                                    blnConAdvertencias = true;
                                }
                            }
                            catch
                            {
                                TrenFicha.Procesada = 2; //con error
                                TrenFicha.idCorrida = oIntCorrida.idCorrida;
                                blnConAdvertencias = true;
                            }                          
                        }
                        strArchivoSalida += "</FichaTren>\r\n";
                        break;
                    default:// ES UNA PASADA SAP O CFLEX INTMOECFL_PAS - INTMOESAP_PAS
                        if (strNombreInterfaz == "INTMOECFL_PAS")
                        {
                            strNombreArchivo = "IMCPASADAS ";
                            strCflexExport="P";
                            strArchivoSalida = "<?xml version=\"1.0\"?>\r\n<Pasada>\r\n";
                        }
                        else
                        {
                            if (strNombreInterfaz == "INTMOESAP_PAS")
                            {
                                strNombreArchivo = "IMSPASADAS ";
                                strArchivoSalida = "";
                            }
                            else
                                return;
                        }


                        var TrenPasadas =
                            from pas in dc.Tren_Pasadas
                            where (strNombreInterfaz == "INTMOECFL_PAS" ? pas.ProcesadaCFLEX : pas.ProcesadaSAP) == 0 && pas.Estado==1
                            select new tipoDetencionAsignacion
                            {
                                NroTren = dc.Trenes.SingleOrDefault(m => m.idTren == pas.idTren).NroTren,
                                Fecha = pas.Fecha,
                                Operacion = pas.Operacion,
                                idEstacion = pas.idEstacion,
                                idEstacionProxima = 1,
                                idDivision = pas.idDivision,
                                ProgresivaPoste = pas.ProgresivaPoste,
                                Obs = pas.Obs,
                                idCorrida = (strNombreInterfaz == "INTMOECFL_PAS" ? pas.idCorridaCFLEX : pas.idCorridaSAP),
                                Procesada = (strNombreInterfaz == "INTMOECFL_PAS" ? pas.ProcesadaCFLEX : pas.ProcesadaSAP),
                                CausaDetencion = (int?)null,
                                Tabla = "PASADAS",
                                id = pas.idPasada
                            };

                        var TrenDetenciones =
                            from det in dc.Tren_Detenciones
                            where (strNombreInterfaz == "INTMOECFL_PAS" ? det.ProcesadaCFLEX : det.ProcesadaSAP) == 0
                            select new tipoDetencionAsignacion
                            {
                                NroTren = dc.Trenes.SingleOrDefault(m => m.idTren == det.idTren).NroTren,
                                Fecha = det.Fecha,
                                Operacion = det.Operacion,
                                idEstacion = det.idEstacion,
                                idEstacionProxima = det.idEstacionProxima,
                                idDivision = det.idDivision,
                                ProgresivaPoste = det.ProgresivaPoste,
                                Obs = det.Obs,
                                idCorrida = (strNombreInterfaz == "INTMOECFL_PAS" ? det.idCorridaCFLEX : det.idCorridaSAP),
                                Procesada = (strNombreInterfaz == "INTMOECFL_PAS" ? det.ProcesadaCFLEX : det.ProcesadaSAP),
                                CausaDetencion = det.idCausaDetencion,
                                Tabla = "DETENCIONES",
                                id = det.idDetencion
                            };
                        var TrenDetencionesYPasadas = TrenPasadas.Union(TrenDetenciones);

                        foreach (var Pasada in TrenDetencionesYPasadas)
                        {
                            intRegistrosProcesados++;
                            try
                            {
                                if (strNombreInterfaz == "INTMOECFL_PAS")
                                {
                                    string strRegistro = "";
                                    strRegistro +=
                                        "<PasadaReg>\r\n" +
                                            "\t<NumeroTren>" + Pasada.NroTren + "</NumeroTren>\r\n" +
                                            "\t<FechaTransaccion>" + (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("ddMMyy") : "") + "</FechaTransaccion>\r\n" +
                                            "\t<HoraTransaccion>" + (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("HHmm") : "") + "</HoraTransaccion>\r\n" +
                                            "\t<Operacion>" + Pasada.Operacion + "</Operacion>\r\n";
                                            string strEstacionCflex = dc.Estaciones_CFLEX.Single(g => g.idEstacionCFLEX == ((Pasada.Tabla == "PASADAS") || (Pasada.Tabla == "DETENCIONES" && Pasada.idEstacion != null)
                                                                    ? dc.Divisiones_Detalle.Single(j => j.idEstacion == Pasada.idEstacion && j.idDivision == Pasada.idDivision).idEstacionCFLEX
                                                                    : dc.Estaciones_CFLEX.Single(
                                                                        l => dc.Divisiones_Cflex.Single(d => d.idDivision == Pasada.idDivision).Descripcion == l.Division
                                                                            && (l.ProgresivaDesde <= Pasada.ProgresivaPoste && l.ProgresivaHasta >= Pasada.ProgresivaPoste) || (l.ProgresivaDesde >= Pasada.ProgresivaPoste && l.ProgresivaHasta <= Pasada.ProgresivaPoste)).idEstacionCFLEX)
                                                                    ).idCFLEX.ToString();
                                            strRegistro += "\t<EstacionTramo>" + strEstacionCflex + "</EstacionTramo>\r\n" + //idESTACIONCFLEX
                                            "\t<Division>" + dc.Estaciones_CFLEX.Single(j=>j.idCFLEX==strEstacionCflex).Division + "</Division>\r\n" +
                                            "\t<Progresiva>" + Pasada.ProgresivaPoste.ToString().Replace(',', '.')+ "</Progresiva>\r\n" +
                                            "\t<Observacion>" + Pasada.Obs + "</Observacion>\r\n" +
                                        "</PasadaReg>\r\n";
                                        strArchivoSalida += strRegistro;
                                }
                                else
                                {
                                    string strRegistro = "";
                                    strRegistro += Pasada.NroTren.PadRight(10);
                                    strRegistro += (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("ddMMyy") : "").PadRight(6);
                                    strRegistro += (Pasada.Fecha != null ? Convert.ToDateTime(Pasada.Fecha).ToString("HHmm") : "").PadRight(4);
                                    strRegistro += Pasada.Operacion.PadRight(3);
                                    strRegistro += dc.Divisiones_Detalle.Single(j => j.idEstacion ==
                                        ((Pasada.Tabla == "PASADAS") || (Pasada.Tabla == "DETENCIONES" && Pasada.idEstacion != null) ? Pasada.idEstacion : Pasada.idEstacionProxima)
                                        && j.idDivision == Pasada.idDivision).idEstacionSAP.ToString().PadRight(6);
                                    strRegistro += Pasada.ProgresivaPoste.ToString().PadLeft(8).Replace(',', '.').Substring(0, 8);
                                    strRegistro += Pasada.CausaDetencion.ToString().PadRight(4);
                                    strRegistro += DateTime.Now.ToString("yyyyMMddHHmmss").PadRight(14);
                                    strRegistro += "\r\n";
                                    strArchivoSalida += strRegistro;
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
                                        TrenPasada.idCorridaSAP = oIntCorrida.idCorrida;
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
                            }
                            catch
                            {
                                if (Pasada.Tabla == "PASADAS")
                                {
                                    Tren_Pasadas TrenPasada = dc.Tren_Pasadas.Single(m => m.idPasada == Pasada.id);
                                    if (strNombreInterfaz == "INTMOECFL_PAS")
                                    {
                                        TrenPasada.ProcesadaCFLEX = 2; //con error
                                        TrenPasada.idCorridaCFLEX = oIntCorrida.idCorrida;
                                    }
                                    else
                                    {
                                        TrenPasada.ProcesadaSAP = 2; //con error
                                        TrenPasada.idCorridaSAP = oIntCorrida.idCorrida;
                                    }
                                }
                                else
                                {
                                    Tren_Detenciones TrenDetencion = dc.Tren_Detenciones.Single(m => m.idDetencion == Pasada.id);
                                    if (strNombreInterfaz == "INTMOECFL_PAS")
                                    {
                                        TrenDetencion.ProcesadaCFLEX = 2; //con error
                                        TrenDetencion.idCorridaCFLEX = oIntCorrida.idCorrida;
                                    }
                                    else
                                    {
                                        TrenDetencion.ProcesadaSAP = 2; //con error
                                        TrenDetencion.idCorridaSAP = oIntCorrida.idCorrida;
                                    }
                                }
                                blnConAdvertencias = true;
                            }                          
                        }
                        if (strNombreInterfaz == "INTMOECFL_PAS")
                            strArchivoSalida += "</Pasada>\r\n";
                        break;
                }

                if(intRegistrosProcesados>0)
                {
                    try
                    {
                        oIntCorrida.Archivo = strArchivoSalida;
                        string strRutaCompletaArchivo = Path.GetFullPath(dc.Interfaces.Single(j => j.idInterfaz == oIntCorrida.idInterfaz).CarpetaArchivos) + "\\" + strNombreInterfaz + "\\" + strNombreArchivo + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
                        oIntCorrida.NombreArchivo = Path.GetFileName(strRutaCompletaArchivo);
                        if (!Directory.Exists(Path.GetDirectoryName(strRutaCompletaArchivo)))
                            Directory.CreateDirectory(Path.GetDirectoryName(strRutaCompletaArchivo));

                        File.WriteAllText(strRutaCompletaArchivo,
                                            oIntCorrida.Archivo.Substring(0, oIntCorrida.Archivo.Length - 2), //elimina ultimo \r\n
                                            oInterfaz.FormatoArchivos!=null && existEncoding(oInterfaz.FormatoArchivos) ? Encoding.GetEncoding(oInterfaz.FormatoArchivos) : Encoding.Default);

                        oIntCorrida.Procesada = (!blnConAdvertencias ? 5/*OK*/: 6/*Con_Advertencias*/);

                        //MODIFICACIÓN 29/11/2010 CFLEX
                        if (strCflexExport != "")
                        {
                            string strSQL = @"
                                INSERT INTO MoebiusMENSAJES_RECIBIDOS
                                (sendKey,mesaje,tipo,status,timestamp)
                                VALUES(
                                NULL,'" + oIntCorrida.Archivo.Substring(0, oIntCorrida.Archivo.Length - 2) + "','" + strCflexExport + "','RECEIVED',GETDATE())";

                            SqlConnection myConn = new SqlConnection(
                                //DESENCRIPTADO DE CLAVE
                                ConfigurationManager.ConnectionStrings["Cflex"].ConnectionString.Contains("Data Source") ? ConfigurationManager.ConnectionStrings["Cflex"].ConnectionString : Datos.DC.desencriptarConexion(ConfigurationManager.ConnectionStrings["Cflex"].ConnectionString, ConfigurationManager.ConnectionStrings["clavePublica"].ConnectionString));
                            myConn.Open();

                            SqlCommand myCmd = new SqlCommand(strSQL, myConn);
                            myCmd.CommandType = CommandType.Text;
                            myCmd.ExecuteNonQuery();

                            myConn.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        oIntCorrida.Archivo = "Error al almacenar el archivo o entrada BD de Cflex: "+ex.Message ;
                        oIntCorrida.Procesada = 6;
                    }
                }
                else
                {
                    if(blnConAdvertencias)
                        oIntCorrida.Procesada = 6/*Con advertencias*/;
                    else
                        oIntCorrida.Procesada = 4/*Sin Archivo*/;

                    oIntCorrida.NombreArchivo = "Sin archivo";
                }
                dc.SubmitChanges();
        }

        private static bool existEncoding(string strEnconding)
        {
            try
            {
                Encoding.GetEncoding(strEnconding);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ProcesarInterfazEntrada(string strNombreInterfaz)
        {
            string strNombreArchivo="";
            bool blnCorridaUnica = true;
            switch (strNombreInterfaz)
            {
                case "INTSAPMOE_LOCEST": //EstadoLocomotoras
                    strNombreArchivo = @"ISMLOCEST\d+";
                    break;
                case "INTSAPMOE_HR": //HojasRuta
                    strNombreArchivo = @"ISMHR\d+";
                    break;
                case "INTPERMOE_APT": //Personal
                    strNombreArchivo = @"IPMPERTRE\d+";
                    break;
                case "INTCFLMOE_PD": //ProgDiaria
                    strNombreArchivo = @"ICMPD\d+";
                    blnCorridaUnica = false;
                    break;
                case "INTCFLMOE_PAS": //ProgDiaria
                    strNombreArchivo = @"\d{9}";
                    break;
            }
            DC dc = new DC();
            Interfaces oInterfaz=dc.Interfaces.Single(l => l.Nombre == strNombreInterfaz);
            IEnumerable<String> fileEntries;
            Interfaces_Corridas oIntCorrida = null;
            int intCantidadLineas=0;

            try
            {
                var regexTest = new Func<string, bool>(i => Regex.IsMatch(i, strNombreArchivo+@".txt\b", RegexOptions.Compiled | RegexOptions.IgnoreCase));
                fileEntries = Directory.GetFiles(oInterfaz.CarpetaArchivos + (oInterfaz.CarpetaArchivos.Substring(oInterfaz.CarpetaArchivos.Length - 1) == "\\" ? "" : "\\") + strNombreInterfaz).Where(regexTest);
            }
            catch(Exception ex)
            {
                oIntCorrida = srvInterfaces.CrearCorrida(dc, oInterfaz.idInterfaz, (strNombreInterfaz == "INTCFLMOE_PD" ? 599 : 3)/*No encontró archivo*/);
                oIntCorrida.NombreArchivo="ERROR: Carpeta "+oInterfaz.CarpetaArchivos + (oInterfaz.CarpetaArchivos.Substring(oInterfaz.CarpetaArchivos.Length-2)=="\\"?"":"\\") + strNombreInterfaz+ " inaccesible o incorrecta.";
                oIntCorrida.Archivo = ex.Message;
                dc.SubmitChanges();
                return;
            }

            List<int> intProcesarCorridas=new List<int>();


            foreach (string fileName in fileEntries)
            {
                using (StreamReader fleArchivo = new StreamReader(fileName, oInterfaz.FormatoArchivos!=null && existEncoding(oInterfaz.FormatoArchivos) ? Encoding.GetEncoding(oInterfaz.FormatoArchivos) : Encoding.Default))
                {
                    String strLinea, strTrenAnterior = "";
                    intCantidadLineas = 0;

                    if (blnCorridaUnica)
                    {
                        oIntCorrida = srvInterfaces.CrearCorrida(dc, oInterfaz.idInterfaz, 0/*Sin Validar*/);
                        oIntCorrida.NombreArchivo = Path.GetFileName(fileName);
                        intProcesarCorridas.Add(oIntCorrida.idCorrida);
                    }
                    while ((strLinea = fleArchivo.ReadLine()) != null)
                    {
                        intCantidadLineas++;
                        if (strLinea != "")
                        {
                            switch (strNombreInterfaz)
                            {
                                case "INTSAPMOE_LOCEST": //EstadoLocomotoras
                                    INTSAPMOE_LOCEST oIntEstadoLoc = new INTSAPMOE_LOCEST();
                                    try
                                    {
                                        oIntEstadoLoc.idCorrida = oIntCorrida.idCorrida;
                                        oIntEstadoLoc.IdEquipo = strLinea.Substring(0, 4);
                                        oIntEstadoLoc.EstadoMecanico = strLinea.Substring(4, 4);
                                        oIntEstadoLoc.FechaEstado = strLinea.Substring(8, 12);
                                        oIntEstadoLoc.Procesada = 0;
                                    }
                                    catch (Exception ex)
                                    {
                                        oIntEstadoLoc.Procesada = -1;
                                        if (ex.Message.Length <= 150)
                                            oIntEstadoLoc.Error = ex.Message;
                                        else
                                            oIntEstadoLoc.Error = ex.Message.Substring(0, 150);
                                    }
                                    dc.INTSAPMOE_LOCEST.InsertOnSubmit(oIntEstadoLoc);
                                    break;
                                case "INTSAPMOE_HR": //HojasRuta
                                    INTSAPMOE_HR oIntHojaRuta = new INTSAPMOE_HR();
                                    try
                                    {
                                        oIntHojaRuta.idCorrida = oIntCorrida.idCorrida;
                                        oIntHojaRuta.Tren = strLinea.Substring(0, 10).Trim();
                                        oIntHojaRuta.TrenJuliano = strLinea.Substring(10, 7).Trim();
                                        oIntHojaRuta.CodigoPatio = strLinea.Substring(17, 4).Trim();
                                        oIntHojaRuta.NombrePatio = strLinea.Substring(21, 50).Trim();
                                        oIntHojaRuta.IdEquipo = strLinea.Substring(71, 4).Trim();
                                        oIntHojaRuta.ToneladasLocomotora = strLinea.Substring(75, 7).Trim();
                                        oIntHojaRuta.LongitudLocomotora = strLinea.Substring(82, 7).Trim();
                                        oIntHojaRuta.TotalVagones = strLinea.Substring(89, 3).Trim();
                                        oIntHojaRuta.TotalVagonesVacios = strLinea.Substring(92, 3).Trim();
                                        oIntHojaRuta.TotalVagonesCargados = strLinea.Substring(95, 3).Trim();
                                        oIntHojaRuta.ToneladasBrutas = strLinea.Substring(98, 7).Trim();
                                        oIntHojaRuta.ToneladasNetas = strLinea.Substring(105, 7).Trim();
                                        oIntHojaRuta.UFT = strLinea.Substring(112, 6).Trim();
                                        oIntHojaRuta.LongitudTren = strLinea.Substring(118, 7).Trim();
                                        oIntHojaRuta.LongitudVagones = strLinea.Substring(125, 7).Trim();
                                        oIntHojaRuta.TotalEjes = strLinea.Substring(132, 3).Trim();
                                        oIntHojaRuta.NumeroSecuencia = strLinea.Substring(135, 3).Trim();
                                        oIntHojaRuta.Usuario = strLinea.Substring(138, 10).Trim();
                                        oIntHojaRuta.TipoEquipo = strLinea[148];
                                        oIntHojaRuta.NumeroVagon = strLinea.Substring(149, 6).Trim();
                                        oIntHojaRuta.EstadoFreno = strLinea[155];
                                        oIntHojaRuta.EstadoFrenoReal = strLinea[156];
                                        oIntHojaRuta.CodigoTrafico = strLinea.Substring(157, 2).Trim();
                                        oIntHojaRuta.LongitudVagon = strLinea.Substring(159, 5).Trim();
                                        oIntHojaRuta.ToneladasVagon = strLinea.Substring(164, 6).Trim();
                                        oIntHojaRuta.ProductoVagon = strLinea.Substring(170, 25).Trim();
                                        oIntHojaRuta.CodigoDestino = strLinea.Substring(195, 6).Trim();
                                        oIntHojaRuta.Destino = strLinea.Substring(201, 21).Trim();
                                        oIntHojaRuta.Pedido = strLinea.Substring(222, 6).Trim();
                                        oIntHojaRuta.Consignatario = strLinea.Substring(228).Length > 19 ? strLinea.Substring(228, 19).Trim() : strLinea.Substring(228).Trim();
                                        oIntHojaRuta.Procesada = 0;
                                    }
                                    catch (Exception ex)
                                    {
                                        oIntHojaRuta.Procesada = -1;
                                        if (ex.Message.Length <= 150)
                                            oIntHojaRuta.Error = ex.Message;
                                        else
                                            oIntHojaRuta.Error = ex.Message.Substring(0, 150);
                                    }
                                    dc.INTSAPMOE_HR.InsertOnSubmit(oIntHojaRuta);
                                    break;
                                case "INTPERMOE_APT": //Personal
                                    INTPERMOE_APT oIntPersonal = new INTPERMOE_APT();
                                    try
                                    {
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
                                    }
                                    catch (Exception ex)
                                    {
                                        oIntPersonal.Procesada = -1;
                                        if (ex.Message.Length <= 150)
                                            oIntPersonal.Error = ex.Message;
                                        else
                                            oIntPersonal.Error = ex.Message.Substring(0, 150);
                                    }
                                    dc.INTPERMOE_APT.InsertOnSubmit(oIntPersonal);
                                    break;
                                case "INTCFLMOE_PD": //ProgDiaria
                                    INTCFLMOE_PD oIntProgDiaria = new INTCFLMOE_PD();
                                    try
                                    {
                                        if (strLinea.Substring(0, 10) != strTrenAnterior)
                                        {
                                            oIntCorrida = srvInterfaces.CrearCorrida(dc, oInterfaz.idInterfaz, 600/*Sin Validar*/);
                                            oIntCorrida.NombreArchivo = Path.GetFileName(fileName);
                                            intProcesarCorridas.Add(oIntCorrida.idCorrida);
                                            strTrenAnterior = strLinea.Substring(0, 10);
                                        }

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
                                        oIntProgDiaria.Procesada = 0;//sin validar
                                    }
                                    catch (Exception ex)
                                    {
                                        oIntCorrida.Procesada = 2/*Sin Archivo*/;
                                        intProcesarCorridas.Remove(oIntCorrida.idCorrida); //no procesar esta corrida
                                        oIntCorrida.Archivo = "ERROR en Procesamiento: " + ex.Message;

                                        oIntProgDiaria.Procesada = -1;
                                        if (ex.Message.Length <= 150)
                                            oIntProgDiaria.Error = ex.Message;
                                        else
                                            oIntProgDiaria.Error = ex.Message.Substring(0, 150);
                                    }
                                    dc.INTCFLMOE_PD.InsertOnSubmit(oIntProgDiaria);
                                    break;
                                case "INTCFLMOE_PAS": //Pasadas Cflex
                                    if (strLinea != "=")//fin de linea
                                    {
                                        INTCFLMOE_PA oIntPasada = new INTCFLMOE_PA();
                                        try
                                        {

                                                oIntPasada.idCorrida = oIntCorrida.idCorrida;
                                                oIntPasada.Tren = strLinea.Substring(0, 10);
                                                oIntPasada.Fecha = strLinea.Substring(10, 12);
                                                oIntPasada.Operacion = strLinea.Substring(22, 3);
                                                if (oIntPasada.Operacion == "PAS")
                                                {
                                                    oIntPasada.EstacionSAP = strLinea.Substring(25, 6);
                                                    oIntPasada.FechaSalida = strLinea.Substring(31, 12);
                                                }
                                                oIntPasada.Procesada = 0;

                                        }
                                        catch (Exception ex)
                                        {
                                            oIntPasada.Procesada = -1;
                                            if (ex.Message.Length <= 150)
                                                oIntPasada.Error = ex.Message;
                                            else
                                                oIntPasada.Error = ex.Message.Substring(0, 150);
                                        }
                                        dc.INTCFLMOE_PAs.InsertOnSubmit(oIntPasada);
                                    }
                                    break;
                            }

                            //Actualizo la corrida
                            oIntCorrida.Procesada = (strNombreInterfaz == "INTCFLMOE_PD" ? 600/*sin validar*/: 0/*sin validar*/);
                            oIntCorrida.Archivo += strLinea + Environment.NewLine;
                        }
                    }
                    fleArchivo.Close();
                }

                if (!Directory.Exists(Path.GetDirectoryName(fileName) + "\\PROCESADOS\\"))
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName) + "\\PROCESADOS\\");
                if (oIntCorrida == null)
                {
                    oIntCorrida = srvInterfaces.CrearCorrida(dc, oInterfaz.idInterfaz, (strNombreInterfaz == "INTCFLMOE_PD" ? 599:2)/*Sin Archivo*/);
                    oIntCorrida.NombreArchivo = Path.GetFileName(fileName);
                }

                if (File.Exists(Path.GetDirectoryName(fileName) + "\\PROCESADOS\\" + Path.GetFileName(fileName)))
                {
                    int cantArchivos =(from proc in dc.Interfaces_Corridas
                                      where proc.idInterfaz == oInterfaz.idInterfaz && proc.NombreArchivo.StartsWith(oIntCorrida.NombreArchivo.Replace(".txt",""))
                                      select proc).Count();
                    File.Move(fileName, Path.GetDirectoryName(fileName) + "\\PROCESADOS\\" + Path.GetFileNameWithoutExtension(fileName) + "_" + cantArchivos.ToString("D3") + ".txt");
                    oIntCorrida.NombreArchivo = Path.GetFileNameWithoutExtension(fileName) + "_" + cantArchivos.ToString("D3") + ".txt";
                }
                else
                    File.Move(fileName, Path.GetDirectoryName(fileName) + "\\PROCESADOS\\" + Path.GetFileName(fileName));

                if (oIntCorrida != null && intCantidadLineas == 0 && blnCorridaUnica)
                {
                    oIntCorrida.Procesada = 7;
                    try
                    {//intento cancelar el procesamiento de la última corrida.
                        int iCorrida=intProcesarCorridas.FindLastIndex(j => j == oIntCorrida.idCorrida);
                        intProcesarCorridas.RemoveAt(iCorrida);
                    }
                    catch{}
                }
            }
            dc.SubmitChanges();
            

            if (intProcesarCorridas.Count() == 0 && oIntCorrida==null)
            {
                oIntCorrida = srvInterfaces.CrearCorrida(dc, oInterfaz.idInterfaz, (strNombreInterfaz == "INTCFLMOE_PD" ? 599 : 2));
                oIntCorrida.NombreArchivo = "Sin archivo";
                dc.SubmitChanges();
            }
            else
            {
                foreach (int intProcesarCorrida in intProcesarCorridas)
                {
                    try
                    {
                        switch (strNombreInterfaz)
                        {
                            case "INTSAPMOE_LOCEST": //EstadoLocomotoras
                                dc.INTSAPMOE_LOCEST_Procesamiento(intProcesarCorrida);
                                break;
                            case "INTSAPMOE_HR": //HojasRuta
                                dc.INTSAPMOE_HR_Procesamiento(intProcesarCorrida);
                                break;
                            case "INTPERMOE_APT": //Personal
                                dc.INTPERMOE_APT_Procesamiento(intProcesarCorrida);
                                break;
                            case "INTCFLMOE_PD": //ProgDiaria
                                dc.INTCFLMOE_PD_Validacion(intProcesarCorrida);
                                break;
                            case "INTCFLMOE_PAS": //Ceflex Pasadas
                                dc.INTCFLMOE_PAS_Procesamiento (intProcesarCorrida);
                                break;
                        }
                    }
                    catch(Exception ex)
                    {
                        DC dcCorrida = new DC();
                        oIntCorrida=dcCorrida.Interfaces_Corridas.Single(j => j.idCorrida == intProcesarCorrida);
                        oIntCorrida.Archivo = "ERROR en Procesamiento: " + ex.Message;
                        oIntCorrida.Procesada = (strNombreInterfaz=="INTCFLMOE_PD"?602:3);
                        dcCorrida.SubmitChanges();
                    }
                }
            }
        }
    }
}
