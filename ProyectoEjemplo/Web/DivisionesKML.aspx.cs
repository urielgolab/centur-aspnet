using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;

using Servicios;

namespace Web
{
    public partial class DivisionesKML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstDivisiones.DataSource = srvDivisiones.ListarDivisiones().OrderBy(m=>m.Nombre);
                lstDivisiones.DataBind();
            }
        }

        protected void btGenerar_Click(object sender, EventArgs e)
        {
            string strDivisionesSeleccionadas = "-1";
            foreach (int intListIndex in lstDivisiones.GetSelectedIndices())
                strDivisionesSeleccionadas += "," + lstDivisiones.Items[intListIndex].Value.ToString();
            GenerarArchivoKML(strDivisionesSeleccionadas,chkGenerarTramos.Checked);
        }

        void GenerarArchivoKML(string strDivisionesSeleccionadas,bool blnGenerarTramos)
        {
            //Creo la conexion con la Base de Datos
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Moebius"].ConnectionString);
            myConn.Open();

            string ssql = " SELECT " +
                                "ISNULL(v.Nombre,'Sin Asignar') Via" +
                                ",d.Nombre Division" +
                                ",'0' TipoTrama" +
                                ",dd.ProgresivaPoste" +
                                ",e.Longitud1 Longitud" +
                                ",e.Latitud1 Latitud" +
                                ",e.Nombre Nombre" +
                                ",'Progresiva: '+CAST(dd.ProgresivaPoste AS VARCHAR) Descripcion " +
                                "FROM divisiones_detalle dd " +
                                "INNER JOIN divisiones d ON d.iddivision=dd.iddivision " +
                                "LEFT JOIN vias v ON dd.idvia=v.idvia " +
                                "INNER JOIN estaciones e ON e.idestacion=dd.idestacion " +
                                "WHERE d.idDivision IN (" + strDivisionesSeleccionadas + @") AND e.Longitud1 IS NOT NULL " +
                            "UNION " +
                            "SELECT " +
                                "ISNULL(vi.Nombre,'Sin Asignar') Via" +
                                ",d.Nombre Division" +
                                ",CAST(v.idTipoRestriccion AS VARCHAR) TipoTrama" +
                                ",v.ProgresivaDesde ProgresivaPoste" +
                                ",v.Longitud1 Longitud" +
                                ",v.Latitud1 Latitud" +
                                ",CAST(v.VelocidadCarga AS VARCHAR) Nombre" +
                                ",'Progresiva: '+CAST(v.ProgresivaDesde AS VARCHAR)+'<br />Motivo: '+ISNULL(v.Motivo,'') Descripcion " +
                                "FROM velocidades v " +
                                "INNER JOIN divisiones d ON d.iddivision=v.iddivision " +
                                "LEFT JOIN vias vi ON v.idvia=vi.idvia " +
                                "WHERE d.idDivision IN (" + strDivisionesSeleccionadas + @")  AND v.Longitud1 IS NOT NULL " +
                            "UNION " +
                            "SELECT " +
                                "ISNULL(v.Nombre,'Sin Asignar') Via" +
                                ",d.Nombre Division" +
                                ",'3' TipoTrama" +
                                ",p.ProgresivaPoste" +
                                ",p.Longitud1 'Longitud'" +
                                ",p.Latitud1  'Latitud'" +
                                ",'Prog:'+CAST(p.ProgresivaPoste AS VARCHAR) Nombre" +
                                ",p.Observaciones Descripcion " +
                                "FROM Progresivas p " +
                                "INNER JOIN divisiones d ON d.iddivision=p.iddivision " +
                                "LEFT JOIN vias v ON p.idvia=v.idvia " +
                                "WHERE p.idDivision IN (" + strDivisionesSeleccionadas + @") AND p.Longitud1 IS NOT NULL ";
                    if(blnGenerarTramos)
                    {
                        ssql += "UNION " +
                                "SELECT " +
                                "ISNULL(v.Nombre,'Sin Asignar') Via " +
                                ",d.Nombre Division" +
                                ",'4' TipoTrama" +
                                ",NULL 'ProgresivaPoste'" +
                                ",NULL 'Latitud'" +
                                ",NULL 'Longitud'" +
                                ",NULL 'Descripcion'" +
                                ",'<Placemark><name>'+CAST(p1.Secuencia AS VARCHAR)+'</name><visibility>1</visibility>" +
                                "<description>Division:'+CAST(p1.idDivision AS VARCHAR)+'<br />ProgresivaDesde:'+CAST(p1.ProgresivaPoste AS VARCHAR)+'-ProgresivaHasta:'+CAST(p2.ProgresivaPoste AS VARCHAR)+'</description>" +
                                "<styleUrl>#estiloVia'+CAST(p1.idVia AS VARCHAR)+'</styleUrl>" +
                                "<LineString>" +
                                "<extrude>1</extrude>" +
                                "<tessellate>1</tessellate>" +
                                "<coordinates>'" +
                                "+REPLACE(CAST (p2.Longitud1 AS VARCHAR),',','.')+','+CAST (p2.Latitud1 AS VARCHAR)+',0 '" +
                                "+REPLACE(CAST (p1.Longitud1 AS VARCHAR),',','.')+','+CAST (p1.Latitud1 AS VARCHAR)+',0 " +
                                "</coordinates>" +
                                "</LineString>" +
                                "</Placemark>' " +
                                "FROM progresivas p1 " +
                                "INNER JOIN progresivas p2 ON (p1.iddivision=p2.iddivision AND p1.secuencia+1=p2.secuencia AND p1.idvia=p2.idvia) " +
                                "INNER JOIN divisiones d ON d.iddivision=p2.iddivision " +
                                "INNER JOIN vias v ON p2.idvia=v.idvia " +
                                "WHERE p1.idDivision IN (" + strDivisionesSeleccionadas + @") AND p1.Longitud1 IS NOT NULL ";
                    }
                            //2012-06-14 UG: Se deshabilita el uso de mapa de progresivas por no tener valor funcional. 
                            //"UNION "+
                            //"SELECT "+
                            //    "ISNULL(v.Nombre,'Sin Asignar') Via" +
                            //    ",d.Nombre Division"+
                            //    ",'4' TipoTrama"+
                            //    ",NULL 'ProgresivaPoste'"+
                            //    ",NULL 'Latitud'"+
                            //    ",NULL 'Longitud'"+
                            //    ",NULL 'Descripcion'"+
                            //    ",'<Placemark><name>'+CAST(p1.Secuencia AS VARCHAR)+'</name><visibility>0</visibility>" +
                            //        "<description>Division:'+CAST(p1.idDivision AS VARCHAR)+'<br />ProgresivaDesde:'+CAST(p1.ProgresivaPoste AS VARCHAR)+'-ProgresivaHasta:'+CAST(p2.ProgresivaPoste AS VARCHAR)+'</description>"+
                            //        "<styleUrl>#estilo'+CAST(p1.idVia AS VARCHAR)+'</styleUrl>"+
                            //        "<Polygon><tessellate>1</tessellate>"+
                            //            "<outerBoundaryIs>"+
                            //                "<LinearRing>"+
                            //                "<coordinates>'+"+
                            //                    "REPLACE(CAST (p2.Longitud1 AS VARCHAR),',','.')+','+CAST (p1.Latitud1 AS VARCHAR)+',0 "+
                            //                    "'+REPLACE(CAST (p2.Longitud1 AS VARCHAR),',','.')+','+CAST (p2.Latitud1 AS VARCHAR)+',0 "+
                            //                    "'+REPLACE(CAST (p1.Longitud1 AS VARCHAR),',','.')+','+CAST (p2.Latitud1 AS VARCHAR)+',0 "+
                            //                    "'+REPLACE(CAST (p1.Longitud1 AS VARCHAR),',','.')+','+CAST (p1.Latitud1 AS VARCHAR)+',0 "+
                            //                "</coordinates>"+
                            //                "</LinearRing>"+
                            //            "</outerBoundaryIs>"+
                            //        "</Polygon>"+
                            //    "</Placemark>' "+
                            //"FROM progresivas p1 "+
                            //"INNER JOIN progresivas p2 ON (p1.iddivision=p2.iddivision AND p1.secuencia+1=p2.secuencia AND p1.idvia=p2.idvia) "+
                            //"INNER JOIN divisiones d ON d.iddivision=p2.iddivision "+
                            //"INNER JOIN vias v ON p2.idvia=v.idvia " +
                            //"WHERE p1.idDivision IN (" + strDivisionesSeleccionadas + @") " +
                    ssql += "ORDER BY 2,1,3,4";


            SqlCommand myCmd = new SqlCommand(ssql, myConn);
            SqlDataReader myRead;
            myCmd.CommandType = CommandType.Text;
            myRead = myCmd.ExecuteReader();


            StringBuilder KML = new StringBuilder();
            KML.Append(@"<?xml version='1.0' encoding='UTF-8'?>
                        <kml xmlns='http://earth.google.com/kml/2.2' xmlns:gx='http://www.google.com/kml/ext/2.2' xmlns:kml='http://www.opengis.net/kml/2.2' xmlns:atom='http://www.w3.org/2005/Atom'>
                        <Document id='Divisiones'>
                            <name>Divisiones</name>
                            <visibility>1</visibility>
                            <open>0</open>
                            <StyleMap id='msn_ylw-pushpin'>
	                            <Pair>
		                            <key>normal</key>
		                            <styleUrl>#sn_ylw-pushpin</styleUrl>
	                            </Pair>
	                            <Pair>
		                            <key>highlight</key>
		                            <styleUrl>#sh_ylw-pushpin</styleUrl>
	                            </Pair>
                            </StyleMap>
                            <Style id='sh_ylw-pushpin'>
	                            <IconStyle>
		                            <scale>0.7</scale>
		                            <Icon>
			                            <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
		                            </Icon>
		                            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
	                            </IconStyle>
	                            <LineStyle>
		                            <color>7fffff55</color>
		                            <width>5</width>
	                            </LineStyle>
                            </Style>
                            <Style id='sn_ylw-pushpin'>
	                            <IconStyle>
		                            <scale>0.7</scale>
		                            <Icon>
			                            <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
		                            </Icon>
		                            <hotSpot x='20' y='2' xunits='pixels' yunits='pixels'/>
	                            </IconStyle>
	                            <LineStyle>
		                            <color>7fffff55</color>
		                            <width>5</width>
	                            </LineStyle>
                            </Style>
	                        <StyleMap id='msn_placemark_circlePROG'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_placemark_circlePROG</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_placemark_circle_highlightPROG</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <Style id='sn_placemark_circlePROG'>
		                        <IconStyle>
			                        <scale>0.6</scale>
									<color>ff24749c</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png</href>
			                        </Icon>
		                        </IconStyle>
	                        </Style>
	                        <Style id='sh_placemark_circle_highlightPROG'>
		                        <IconStyle>
			                        <scale>0.7</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle_highlight.png</href>
			                        </Icon>
		                        </IconStyle>
	                        </Style>
	                        <StyleMap id='msn_placemark_circlePAN'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_placemark_circlePAN</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_placemark_circle_highlightPAN</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <StyleMap id='msn_placemark_circleVEL'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_placemark_circleVEL</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_placemark_circle_highlightVEL</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <Style id='sn_placemark_circlePAN'>
		                        <IconStyle>
			                        <scale>0.6</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png</href>
			                        </Icon>
		                        </IconStyle>
	                        </Style>
                            <Style id='sn_placemark_circleVEL'>
		                        <IconStyle>
			                        <scale>0.6</scale>
                                    <color>ff00ffff</color>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png</href>
			                        </Icon>
		                        </IconStyle>
	                        </Style>
	                        <Style id='sh_placemark_circle_highlightPAN'>
		                        <IconStyle>
			                        <scale>0.7</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle_highlight.png</href>
			                        </Icon>
		                        </IconStyle>
	                        </Style>
                            <Style id='sh_placemark_circle_highlightVEL'>
		                        <IconStyle>
                                    <color>ff00ffff</color>
			                        <scale>0.7</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/placemark_circle_highlight.png</href>
			                        </Icon>
		                        </IconStyle>
	                        </Style>

	                        <StyleMap id='msn_placemark_EST'>
		                        <Pair>
			                        <key>normal</key>
			                        <styleUrl>#sn_rail</styleUrl>
		                        </Pair>
		                        <Pair>
			                        <key>highlight</key>
			                        <styleUrl>#sh_rail</styleUrl>
		                        </Pair>
	                        </StyleMap>
	                        <Style id='sh_rail'>
		                        <IconStyle>
			                        <scale>0.6</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/rail.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <ListStyle>
		                        </ListStyle>
	                        </Style>
	                        <Style id='sn_rail'>
		                        <IconStyle>
			                        <scale>0.6</scale>
			                        <Icon>
				                        <href>http://maps.google.com/mapfiles/kml/shapes/rail.png</href>
			                        </Icon>
			                        <hotSpot x='0.5' y='0' xunits='fraction' yunits='fraction'/>
		                        </IconStyle>
		                        <ListStyle>
		                        </ListStyle>
	                        </Style>
                                <Style id='estiloVia27'><LineStyle><color>ff818064</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia50'><LineStyle><color>ff899035</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia51'><LineStyle><color>ff618827</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia52'><LineStyle><color>ff504181</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia60'><LineStyle><color>ff456403</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia61'><LineStyle><color>ff298872</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia64'><LineStyle><color>ff673849</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia65'><LineStyle><color>ff461596</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia66'><LineStyle><color>ff482298</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia67'><LineStyle><color>ff014286</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia68'><LineStyle><color>ff338156</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia69'><LineStyle><color>ff864326</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia70'><LineStyle><color>ff715658</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia71'><LineStyle><color>ff507303</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia72'><LineStyle><color>ff113879</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia1'><LineStyle><color>ff122476</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia2'><LineStyle><color>ff395720</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia3'><LineStyle><color>ff450117</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia4'><LineStyle><color>ff306664</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia5'><LineStyle><color>ff260381</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia6'><LineStyle><color>ff696874</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia7'><LineStyle><color>ff483884</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia8'><LineStyle><color>ff944156</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia9'><LineStyle><color>ff480637</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia10'><LineStyle><color>ff803435</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia11'><LineStyle><color>ff693774</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia12'><LineStyle><color>ff972992</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia13'><LineStyle><color>ff648919</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia14'><LineStyle><color>ff102941</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia15'><LineStyle><color>ff489233</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia16'><LineStyle><color>ff631235</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia17'><LineStyle><color>ff048146</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia18'><LineStyle><color>ff286186</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia19'><LineStyle><color>ff300875</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia20'><LineStyle><color>ff526633</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia21'><LineStyle><color>ff820666</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia22'><LineStyle><color>ff210163</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia29'><LineStyle><color>ff396586</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia40'><LineStyle><color>ff416323</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia41'><LineStyle><color>ff673255</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia42'><LineStyle><color>ff607633</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia43'><LineStyle><color>ff933953</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia44'><LineStyle><color>ff788715</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia46'><LineStyle><color>ff852316</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia62'><LineStyle><color>ff527153</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia99'><LineStyle><color>ff681479</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia39'><LineStyle><color>ff733368</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia47'><LineStyle><color>ff061348</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia45'><LineStyle><color>ff457840</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia31'><LineStyle><color>ff469303</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia32'><LineStyle><color>ff989128</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia33'><LineStyle><color>ff180687</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia34'><LineStyle><color>ff961280</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia35'><LineStyle><color>ff504874</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia36'><LineStyle><color>ff213083</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia37'><LineStyle><color>ff715134</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia38'><LineStyle><color>ff766709</color><width>2.5</width></LineStyle></Style>
                                <Style id='estiloVia63'><LineStyle><color>ff225811</color><width>2.5</width></LineStyle></Style>
                            ");

            string strDivisionAnt = "", strTipoTramaAnt = "", strViaAnt="";
            bool blnCloseVia = true;

            while (myRead.Read())
            {
                if (myRead["Division"].ToString() != strDivisionAnt)
                {
                    strTipoTramaAnt = "";
                    if (strDivisionAnt != "")
                    {
                        KML.Append("</Folder>\n"); //cierro carpeta de Trama Anterior
                        KML.Append("</Folder>"); //cierro carpeta de via anterior
                        KML.Append("</Folder>"); //cierro carpeta de división anterior
                        blnCloseVia = false;
                    }
                    KML.Append("<Folder> \n <name>" + myRead["Division"].ToString() + "</name><visibility>1</visibility><open>0</open>\n");
                    strDivisionAnt = myRead["Division"].ToString();
                }

                if (myRead["Via"].ToString() != strViaAnt || !blnCloseVia)
                {
                    strTipoTramaAnt = "";
                    if (strViaAnt != "")
                    {
                        if (blnCloseVia)
                        {
                            KML.Append("</Folder>\n"); //cierro carpeta de Trama Anterior
                            KML.Append("</Folder>"); //cierro carpeta de via anterior    
                        }
                        blnCloseVia = true;
                    }
                    KML.Append("<Folder> \n <name>Via: " + myRead["Via"].ToString() + "</name><visibility>1</visibility><open>0</open>\n");
                    strViaAnt = myRead["Via"].ToString();
                }

                if (myRead["TipoTrama"].ToString() != strTipoTramaAnt)
                {
                    if (strTipoTramaAnt != "")
                        KML.Append("</Folder>\n"); //cierro TipoTrama anterior
                    KML.Append("<Folder>\n <name>");
                    switch(myRead["TipoTrama"].ToString())
                    {
                        case "0":
                            KML.Append("Estaciones");
                            break;
                        case "1":
                            KML.Append("Velocidades");
                            break;
                        case "2":
                            KML.Append("PAN");
                            break;
                        case "3":
                            KML.Append("Progresivas");
                            break;
                        case "4":
                            KML.Append("Mapa Progresivas");
                            break;                                
                    }
                    KML.Append("</name>\n");
                    KML.Append("<visibility>"+(myRead["TipoTrama"].ToString()!="4"?"1":"0")+"</visibility>\n");

                    strTipoTramaAnt = myRead["TipoTrama"].ToString();
                }

                if (myRead["TipoTrama"].ToString() != "4")
                {
                    KML.Append(@"
		                <Placemark>
			                <name>" + myRead["Nombre"].ToString() + @"</name>
                            <styleUrl>");
                    switch (myRead["TipoTrama"].ToString())
                    {
                        case "0":
                            KML.Append("#msn_placemark_EST");
                            break;
                        case "1":
                            KML.Append("#msn_placemark_circleVEL");
                            break;
                        case "2":
                            KML.Append("#msn_placemark_circlePAN");
                            break;
                        case "3":
                            KML.Append("#msn_placemark_circlePROG");
                            break;
                    }
                    KML.Append(@"</styleUrl>
			                <Point>
				                <coordinates>" + myRead["Longitud"].ToString().Replace(",", ".") + "," + myRead["Latitud"].ToString().Replace(",", ".") + @",0</coordinates>
			                </Point>
                            <description>" + myRead["Descripcion"].ToString() + @"</description>
		                </Placemark>");
                }
                else
                    KML.Append(myRead["Descripcion"].ToString());
            }

            KML.Append("</Folder>\n"); //cierro carpeta de Velocidad/PAN Anterior
            KML.Append("</Folder>"); //cierro carpeta de via anterior
            KML.Append("</Folder>"); //cierro carpeta de división anterior

            KML.Append("</Document></kml> \n");

            string attachment = "attachment; filename=Divisiones.kml";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.google-earth.kml+xml";

            Response.Write(KML);
            Response.End();

            //Cierro la conexion
            myRead.Close();
            myConn.Close();

       }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string strDivisionesSeleccionadas = "-1";
            foreach (int intListIndex in lstDivisiones.GetSelectedIndices())
                strDivisionesSeleccionadas += "," + lstDivisiones.Items[intListIndex].Value.ToString();
            GenerarArchivoKML(strDivisionesSeleccionadas,chkGenerarTramos.Checked);
        }
    }
}
