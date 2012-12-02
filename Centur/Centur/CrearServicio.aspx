<%@ Page Title="Agregar servicio" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicio.aspx.vb" Inherits="Centur.CrearServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
    <script src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script src="Scripts/addressPicker.js"></script>
      
    <script>
    $(function() {
        $("#tabs").tabs();
    });

//    $(function() {
//        $( document ).tooltip();
//    });

    $(function () {
        $("button")
            .button()
            .click(function (event) {
                var activeTab = $("#tabs").tabs("option", "active");
                if (activeTab < 4)
                    $("#tabs").tabs("option", "active", activeTab + 1);
                else {
                    return;
                }
            });
        });

        $(function () {
            var jsonData = new Object();
            jsonData.idCategoria = $ID("lstCategoria").val();
            $.ajax({
                url: "CrearServicio.aspx/getCategorias",
                type: "POST",
                data: jsonData ? JSON.stringify(jsonData) : null,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success:
                function (resultado) {
                    $.each(resultado.d, function (index, item) {
                        $ID("lstCategoria").get(0).options[$ID("lstCategoria").get(0).options.length] = new Option(item.text, item.value);
                    })
                }
            });
        });

        $(function () {
            var addresspicker = $("#addresspicker").addresspicker();
            var addresspickerMap = $("#addresspicker_map").addresspicker({
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
            elements: "descripcion",
            theme: 'advanced',
            language: 'es',
            skin: "o2k7",
            plugins: 'style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu',
            disk_cache : true,
	     	debug : false,


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

    <style type="text/css">
        #picContainer {
            position: relative;
            padding-top: 100px;
            width: 160px;
            height: 60px;
            }
        .sell-pictures .repeat.ch-icon-camera.top {
        top: 15px;
        left: 40px;
        }
        sellmedia="screen, projection"
        .sell-pictures .repeat.ch-icon-camera {
        position: absolute;
        }
        sellmedia="screen, projection"
        .sell-pictures .ch-icon-camera {
        background-color: white;
        border: 1px solid #DADADA;
        border-radius: 3px;
        position: relative;
        width: 37px;
        height: 38px;
        padding: 10px 14px 11px 7px;
        }
        i, cite, em, var, address, dfn {
        font-style: italic;
        }
        .ch-btn-skin:hover {
        background-color: #DCECFB;
        background-image: -webkit-linear-gradient(#DCECFB,#C2DDF5);
        background-image: -moz-linear-gradient(#DCECFB,#C2DDF5);
        background-image: -o-linear-gradient(#DCECFB,#C2DDF5);
        background-image: linear-gradient(#DCECFB,#C2DDF5);
        }
        
        .ch-btn-skin, .ch-btn-skin:focus, .ch-btn-skin:visited {
        background-color: #C0DAEC;
        background-image: -webkit-linear-gradient(#D0E6F8,#A6CDEE);
        background-image: -moz-linear-gradient(#D0E6F8,#A6CDEE);
        background-image: -o-linear-gradient(#D0E6F8,#A6CDEE);
        background-image: linear-gradient(#D0E6F8,#A6CDEE);
        border: 1px solid #79A8C7;
        -webkit-box-shadow: inset 0 1px rgba(255, 255, 255, .9);
        box-shadow: inset 0 1px rgba(255, 255, 255, .9);
        color: #476274;
        text-shadow: 0 1px 1px rgba(255, 255, 255, 0.75);
        }     
        .sell-pictures i.ch-icon-camera::before, .thumbnails i.ch-icon-camera::before, .ie7 .sell-pictures .ch-icon-camera, .ie7 .thumbnails .ch-icon-camera {
        font-size: 50px;
        }
        .ch-icon-camera::before {
        content: "\fot";
        }   
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <br />
    </p>

    <div id="tabs">
	<ul>
		<li><a href="#elige-la-categoria">Elige la categoría</a></li>
		<li><a href="#describe-el-servicio">Describe el servicio</a></li>
		<li><a href="#define-los-tiempos">Define tiempos</a></li>
        <li><a href="#configuralo">Configuralo</a></li>
	</ul>
	<div id="elige-la-categoria">
        <asp:Label ID="lblCategorias" runat="server" Text="Categoría elegidas" Visible="false"></asp:Label>
        <asp:HiddenField ID="hidCategoriaPadre" runat="server" Value="True" />
        <asp:ListBox ID="lstCategoria" runat="server" Height="91px" 
            Width="179px" Rows="10"></asp:ListBox>

        <br />

        <button id="tabPage1">Continuar</button>
        <br />
    </div>
	<div id="describe-el-servicio">
        <p class="ch-form-hint">* Datos obligatorios</p>
	    <div class="ch-form-row ch-form-required sell-title">
		    <label for="title">T&iacute;tulo: <em>*</em></label> 
		
		    <input type="text" value="" id="title" name="title.title" required="required" size="70" placeholder="Ej.: Wimbledon Tenis Club con Estacionamiento, Buffet y 6 canchas." title="Usa palabras clave para que encuentren f&aacute;cilmente tu servicio."/>
		
		    <span class="ch-form-hint">Restan <span id="display">60</span> caracteres.</span>
		</div>
        
        <div id="picContainer" class="ready clear" style="z-index: 0;">
                <i class="repeat top ch-icon-camera"></i>
                <i class="repeat mid ch-icon-camera"></i>
                <i class="repeat bottom ch-icon-camera"></i>

                
                <p class="ch-form-hint"><span id="imgAmount">1</span> foto disponible</p>
                <a type="button" id="addImgs" rel="prevent-not-needed" class="ch-btn-skin ch-btn-small trigger">Agregar fotos</a> 
        </div>
        <br />
    	<div class='input'>
	        <label>Dirección : </label> <input id="addresspicker_map" placeholder="Ej.: Av. Corrientes 571, Buenos Aires" size="50px" />   <br/>
			<label>Locality: </label> <input id="locality" disabled="disabled"> <br/>
			<label>Country:  </label> <input id="country" disabled="disabled"> <br/>
			<label>Lat:      </label> <input id="lat" disabled="disabled"> <br/>
			<label>Lng:      </label> <input id="lng" disabled="disabled"> <br/>
        </div>
        <div id="map"></div>

        <br />
        <div class="ui-widget">
	        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
		        <p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
		            <strong>No incluyas datos de contacto en tu publicación porque será dada de baja.</strong>
                </p>
	        </div>
        </div>

	    <p class="ch-form-row description ">
		    <label for="description" id="lbl_description">Descripci&oacute;n: <span class="ch-form-hint optional">(opcional)</span></label>

    	    <textarea id="descripcion" name="elm2" rows="15" cols="80" style="height: 200px;width: 95%">
	        </textarea>
		    <!-- Tiny_MCE -->
	    </p>


        <button id="tabPage2">Continuar</button>
    </div>
	<div id="define-los-tiempos">
        <p>
            Nam dui erat, auctor a, dignissim quis, sollicitudin eu, felis. Pellentesque nisi urna, interdum eget, sagittis et, consequat vestibulum, lacus. Mauris porttitor ullamcorper augue.
        </p>
        <button id="Button1">Continuar</button>
    </div>
    <div id="configuralo">
        <p>REGLAS PERSONALIZADAS</p>
        <button id="Button2">Finalizar</button>
    </div>
</div>

</asp:Content>
