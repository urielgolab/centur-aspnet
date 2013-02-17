Imports System.Security.Cryptography
Imports Datos
Public Class ReservarTurno
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()
    Dim oServicio As Servicio
    Dim dc As New DC()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Mensaje As String = ""
        Dim Status As Boolean = False

        Dim TurnoHoraInicio As String = CStr(Request.QueryString("horaInicio"))
        Dim TurnoHoraFin As String = CStr(Request.QueryString("horaFin"))
        Dim TurnoFecha As Date = CDate(CStr(Request.QueryString("fecha")))
        Dim ServicioID As Integer = CInt(Request.QueryString("servicioID"))
        Dim oTurno As Entities.Turno

        'Dim esProveedor As Boolean
        'If CType(Session("Usuario"), Entities.Usuario).TipoUsuario = "P" Then
        '    esProveedor = True
        'Else
        '    esProveedor = False
        'End If

        oServicio = dc.Servicios.Single(Function(x) x.idServicio = ServicioID)

        If oServicio.mercadoPago OrElse Not Request.QueryString("MPStatus") Is Nothing Then
            If Not Request.QueryString("MPStatus") Is Nothing Then
                Select Case Request.QueryString("MPStatus")
                    Case 1 'status ok
                        Status = False
                        oTurno = oBuscarServicioService.ReservarTurno(ServicioID, TurnoFecha, TurnoHoraInicio, TurnoHoraFin, CType(Session("Usuario"), Entities.Usuario).idUsuario, False, Mensaje, Status)
                    Case Else 'fail or pending
                        Status = True
                        TurnoStatus.InnerText = "El pago del turno ha quedado pendiente. Comuníquese con el proveedor."
                End Select
            Else
                buildPayment()
            End If

        Else
            oTurno = oBuscarServicioService.ReservarTurno(ServicioID, TurnoFecha, TurnoHoraInicio, TurnoHoraFin, CType(Session("Usuario"), Entities.Usuario).idUsuario, False, Mensaje, Status)
        End If

        If Not oTurno Is Nothing Then
            If Not Status Then
                TurnoStatus.InnerText = "Reservado!! De " + oTurno.horaInicio + " a " + oTurno.horaFin
            Else
                TurnoStatus.InnerText = Mensaje
            End If
        End If

    End Sub
    Private Function rebuildQueryString() As String
        Dim strReturn As String = ""
        For Each key As String In Request.QueryString.AllKeys
            strReturn += key + "=" + Request.QueryString(key) + "&"
        Next
        Return strReturn.Substring(0, strReturn.Length - 1)
    End Function

    Private Sub buildPayment()
        Dim idServicio As Integer = 13
        Dim idUsuario As Integer = 1024

        If Request.QueryString("idServicio") <> "" AndAlso Request.QueryString("idUsuario") <> "" Then
            idServicio = CInt(Request.QueryString("idServicio"))
            idUsuario = CInt(Request.QueryString("idUsuario"))
        End If

        If idServicio > 0 Then
            'Dim cntPlaceHolder As ContentPlaceHolder = DirectCast(Master.FindControl("Form1"), Form)



            Page.Form.Method = "POST"
            Page.Form.Action = "https://www.mercadopago.com/checkout/init"
            Page.Form.Enctype = "application/x-www-form-urlencoded"
            Page.Form.Target = ""

            Dim oUsuario = dc.Usuarios.Single(Function(x) x.idUsuario = idUsuario)

            'Dim strClientID As String = "8419012852371072"
            'Dim strClientSecret As String = "wEqlohjSpu62st97OLubmOdPEdLQVu71"

            Dim strBoton As String
            strBoton = "" &
            "<p><h2>Turno con reserva pendiente de pago</h2></p>" &
            "<!-- Autenticación y hash MD5 -->" &
            "<input type='hidden' name='client_id' value='" + oServicio.MercadoPago_ClientID + "'/>" &
            "<input type='hidden' name='md5' value='" + obtenerMD5(oServicio.MercadoPago_ClientID & oServicio.MercadoPago_ClientSecret & "1" & "ARS" & oServicio.precioReserva.ToString() & "" & "") + "'/>" &
            "<!-- Datos obligatorios del item -->" &
            "<input type='hidden' name='item_title' value='" + oServicio.nombre + "'/>" &
            "<input type='hidden' name='item_quantity' value='1'/>" &
            "<input type='hidden' name='item_currency_id' value='ARS'/>" &
            "<input type='hidden' name='item_unit_price' value='" + oServicio.precioReserva.ToString() + "'/>" &
            "" &
            "<input type='hidden' name='payer_name' value='" + oUsuario.nombre + " " + oUsuario.apellido + "'/>" &
            "<input type='hidden' name='payer_surname' value='" + oUsuario.nombreUsuario + "'/>" &
            "<input type='hidden' name='payer_email' value='" + oUsuario.email + "'/>"
            Dim strQueryString As String = rebuildQueryString()
            Dim baseURL As String = "http://centur.ugserver.com.ar/UrielWeb/" 'http://localhost:50931/
            strBoton += "<input type='hidden' name='item_picture_url' value='" + baseURL + "Images/publicaciones/" + oServicio.foto + ".jpg'/>" &
            "<input type='hidden' name='back_url_success' value='" + baseURL + "ReservarTurno.aspx?MPStatus=1" + strQueryString + "'/>" &
            "<input type='hidden' name='back_url_pending' value='" + baseURL + "ReservarTurno.aspx?MPStatus=0" + strQueryString + "'/>" &
            "" &
            "<!-- Boton de pago -->" &
            "<button type='submit' class='lightblue-rn-m-tr' name='MP-Checkout'>Pagar y confirmar turno</button>" &
            "<!-- Pega este código antes de cerrar la etiqueta </body> -->" &
            "<script type='text/javascript'>" &
            "	(function () {" &
            "		function $MPBR_load() {" &
            "			window.$MPBR_loaded !== true && (function () {" &
            "				var s = document.createElement('script'); s.type = 'text/javascript'; s.async = true;" &
            "				s.src = ('https:' == document.location.protocol ? 'https://www.mercadopago.com/org-img/jsapi/mptools/buttons/' : 'http://mp-tools.mlstatic.com/buttons/') + 'render.js';" &
            "				var x = document.getElementsByTagName('script')[0]; x.parentNode.insertBefore(s, x); window.$MPBR_loaded = true;" &
            "			})();" &
            "		}" &
            "		window.$MPBR_loaded !== true ? (window.attachEvent ? window.attachEvent('onload', $MPBR_load) : window.addEventListener('load', $MPBR_load, false)) : null;" &
            "	})();" &
            "</script>"
            ltlMercadoPago.Text = strBoton

            '            "<!-- Datos opcionales -->" &
            '"<input type='hidden' name='item_id' value='id_del_item'/>" &
            '"<input type='hidden' name='external_reference' value='referencia_externa_del_vendedor'/>" &


        End If
    End Sub

    Private Function obtenerMD5(ByVal md5String As String) As String

        ' Get md5 hash
        Dim md5 As String = ""
        Dim textBytes As Byte() = System.Text.Encoding.[Default].GetBytes(md5String)

        Dim cryptHandler As MD5CryptoServiceProvider
        cryptHandler = New MD5CryptoServiceProvider()
        Dim hash As Byte() = cryptHandler.ComputeHash(textBytes)
        For Each a As Byte In hash
            md5 += a.ToString("x2")
        Next

        Return md5
    End Function
End Class