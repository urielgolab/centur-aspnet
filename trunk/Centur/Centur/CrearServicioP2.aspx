<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicioP2.aspx.vb" Inherits="Centur.CrearServicioP2" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        html, body {
	        margin: 0;
	        padding: 0;
	        width: 100%;
	        height: 100%; 
        }

        .contenido {
	        min-height: 90%;
	        position: relative;
	        overflow: auto;
	        z-index: 0; 
        }

        .background {
	        position: absolute;
	        z-index: -1;
	        top: 0;
	        bottom: 0;
	        margin: 0;
	        padding: 0;
        }

        .top_block {
	        width: 100%;
	        display: block; 
        }

        .bottom_block {
	        position: absolute;
	        width: 100%;
	        display: block;
	        bottom: 0; 
        }

        .left_block {
	        display: block;
	        float: left; 
        }

        .right_block {
	        display: block;
	        float: right; 
        }

        .center_block {
	        display: block;
	        width: auto; 
        }

        .background.block_2 {
	        height: auto !important;
	        padding-bottom: 0;
	        left: 0;
	        width: 50%;
	        background-color: #999999; 
        }

        .block_2 {
	        height: auto;
	        width: 50%;
	        padding-bottom: 0px;
        }
        
        table td
        {
        	vertical-align:top;
        }
    </style>
    
    <script src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script src="Scripts/addressPicker.js"></script>

    <script language="javascript">
        $(function () {
            $("#tabs").tabs();
            $("#tabs").tabs('option', 'disabled', [0, 2, 3]);
            $("#tabs").tabs("select", 1)
            $ID("btnSiguiente").button();
        });

        $(function () {
            var addresspickerMap = $ID("txtDireccion").addresspicker({
                elements: {
                    map: "#map",
                    lat: "#lat",
                    lng: "#lng",
                    locality: '#locality',
                    country: '#country'
                }
            });
            var gmarker = addresspickerMap.addresspicker("marker");
            gmarker.setVisible(true);
            addresspickerMap.addresspicker("updatePosition");
        });

        function toogleMap(idMap) {
            if($(idMap).css('display')!="none")
                $(idMap).css('display','none');
            else
                $(idMap).css('display', 'block');
        }
    </script>

    <!-- TinyMCE -->
    <script type="text/javascript" src="Scripts/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        // O2k7 skin
        tinyMCE.init({
            // General options
            mode: "exact",
            elements: "MainContent_txtDescripcion",
            theme: 'advanced',
            language: 'es',
            skin: "o2k7",
            plugins: "autolink,lists,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen, preview,noneditable,visualchars,nonbreaking,template,wordcount,advlist, media",
            //plugins: 'style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu',
            disk_cache: true,
            debug: false,
            theme_advanced_buttons1: "fontselect, fontsizeselect,|,forecolor,backcolor,|,bold,italic,underline,|,cut,copy,paste,|,bullist,numlist,|,newdocument,undo,redo,|,fullscreen, preview,|, image, media, |, justifyleft, justifycenter, justifyright, justifyfull",

            // Theme options
            /*
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,
            */

            // Example content CSS (should be your site CSS)
            content_css: "Styles/Site.css",

            // Drop lists for link/image/media/template dialogs
            template_external_list_url: "lists/template_list.js",
            external_link_list_url: "lists/link_list.js",
            external_image_list_url: "lists/image_list.js",
            media_external_list_url: "lists/media_list.js"
        });
    </script>
    <!-- /TinyMCE -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="tabs">
	    <ul>
		    <li><a href="#elige-la-categoria">Elige la categoría</a></li>
		    <li><a href="#describe-el-servicio">Describe el servicio</a></li>
		    <li><a href="#define-los-tiempos">Define tiempos</a></li>
            <li><a href="#configuralo">Configuralo</a></li>
	    </ul>
	    <div id="elige-la-categoria"></div>
	    <div id="describe-el-servicio" class="contenido">
            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>

            <p class="ch-form-hint">* Datos obligatorios</p>

            <table>
            <tr>
                <td>T&iacute;tulo: *</td>
                <td><asp:TextBox ID="txtTitulo" runat="server" Width="500" placeholder="Ej.: Wimbledon Tenis Club con Estacionamiento, Buffet y 6 canchas." title="Usa palabras clave para que encuentren f&aacute;cilmente tu servicio."></asp:TextBox></td>
            </tr>
            <tr>
                <td>Imagen: </td>
                <td>
                    <div id="photoUploader" style="border:1px solid lightblue;">
                        <div style="float:left"><asp:FileUpload ID="fleImagenServicio" runat="server"/></div>
                        <div>
                            <asp:Image ID="imgFotoServicio" runat="server" ImageUrl="~/Images/photo_camera_up.png" style="float:right" />
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>Direcci&oacute;n: *</td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server" placeholder="Ej.: Av. Corrientes 571, Buenos Aires" size="50px"></asp:TextBox>
                    <div title="Mostrar mapa" onclick="toogleMap(mapa);" style="display:inline-block;border: 1px solid black;margin-left: 5px;background: black url(Images/locationArrow.jpg) center center no-repeat;height: 21px;width: 38px;vertical-align: bottom;margin-top: 0px;margin-bottom: 2px;"></div>

                    <div id="mapa" style="display:none;">
    	                <div class='input'>
                                <label>Ciudad: </label> <input id="locality" disabled="disabled" /> <br/>
			                    <label>Pa&iacute;s:  </label> <input id="country" disabled="disabled" /> <br/>
			                    <label>Lat:      </label> <input id="lat" disabled="disabled" /> <br/>
			                    <label>Lng:      </label> <input id="lng" disabled="disabled" /> <br/>
                        </div>
                        <div id="map"></div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>Seleccione la zona:*</td>
                <td>
                    <div id="Zonas">
                        <div style="clear:both;margin-bottom: 9px;">
                            <asp:LinkButton ID="lnkZonaPadre" runat="server" title="Volver a la zona raiz"></asp:LinkButton>
                        </div>
                        <div>
                            <asp:ListBox ID="lstZonas" runat="server" AutoPostBack="True" style="background: white;width: 268px;padding: 5px;font-size: 16px;line-height: 1;border: 0;border-radius: 0;height: 200px;"></asp:ListBox>
                        </div>
                    </div>                
                </td>
            </tr>
            <tr>
                <td colspan="2"><label for="description" id="lbl_description">Descripci&oacute;n: <span class="ch-form-hint optional">(opcional)</span></label></td>
            </tr>
            <tr>
                <td colspan="2">
	                <p class="ch-form-row description ">
    	                <textarea id="txtDescripcion" runat="server" name="txtDescripcion" rows="15" cols="80" style="height: 200px;width: 95%" />
		                <!-- Tiny_MCE -->
	                </p>                
                </td>
            </tr>
            </table>



            <asp:Button ID="btnSiguiente" runat="server" Text="Continuar" Enabled="false"  />
        </div>
	    <div id="define-los-tiempos"></div>
        <div id="configuralo"></div>
    </div>
</asp:Content>
