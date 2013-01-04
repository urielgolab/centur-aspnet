﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicioP2.aspx.vb" Inherits="Centur.CrearServicioP2" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
    </script>

    <!-- TinyMCE -->
    <script type="text/javascript" src="Scripts/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        // O2k7 skin
        tinyMCE.init({
            // General options
            mode: "exact",
            elements: "txtDescripcion",
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
	<div id="describe-el-servicio">
        <p class="ch-form-hint">* Datos obligatorios</p>
	    <div class="ch-form-row ch-form-required sell-title">
		    <label for="title">T&iacute;tulo: <em>*</em></label> 
            <asp:TextBox ID="txtTitulo" runat="server" Width="500" placeholder="Ej.: Wimbledon Tenis Club con Estacionamiento, Buffet y 6 canchas." title="Usa palabras clave para que encuentren f&aacute;cilmente tu servicio."></asp:TextBox>
		</div>

        <br />
        
        <label>Dirección : </label> 
        <asp:TextBox ID="txtDireccion" runat="server" placeholder="Ej.: Av. Corrientes 571, Buenos Aires" size="50px"></asp:TextBox>&nbsp;
        <div id="mapa">
    	    <div class='input'>
	            
                    <label>Ciudad: </label> <input id="locality" disabled="disabled" /> <br/>
			        <label>Pa&iacute;s:  </label> <input id="country" disabled="disabled" /> <br/>
			        <label>Lat:      </label> <input id="lat" disabled="disabled" /> <br/>
			        <label>Lng:      </label> <input id="lng" disabled="disabled" /> <br/>
            </div>
            <div id="map"></div>
        </div>

        <br />
        <br />
	    <p class="ch-form-row description ">
		    <label for="description" id="lbl_description">Descripci&oacute;n: <span class="ch-form-hint optional">(opcional)</span></label>
    	    <textarea id="txtDescripcion" name="txtDescripcion" rows="15" cols="80" style="height: 200px;width: 95%">
	        </textarea>
		    <!-- Tiny_MCE -->
	    </p>

        <asp:Button ID="btnSiguiente" runat="server" Text="Continuar"  />
    </div>
	<div id="define-los-tiempos"></div>
    <div id="configuralo"></div>
</div>
</asp:Content>
