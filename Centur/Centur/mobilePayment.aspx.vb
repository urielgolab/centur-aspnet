﻿Imports Datos
Imports System.Security.Cryptography
Public Class mobilePayment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim idServicio As Integer = 13

            If Request.QueryString("idServicio") <> "" Then
                idServicio = CInt(Request.QueryString("idServicio"))
            End If

            If idServicio > 0 Then
                form1.Method = "POST"
                form1.Action = "https://www.mercadopago.com/checkout/init"
                form1.Enctype = "application/x-www-form-urlencoded"
                form1.Target = ""


                Dim dc As New DC()

                Dim oServicio = dc.Servicios.Single(Function(x) x.idServicio = idServicio)

                Dim strClientID As String = "858246848027532"
                Dim strClientSecret As String = "jOJr8QeUAcj3PHuXiuc9V16GvY8TT3h3"

                Dim strBoton As String
                strBoton = "<form action='https://www.mercadopago.com/checkout/init' method='post' enctype='application/x-www-form-urlencoded' target=''>	" &
                "<!-- Autenticación y hash MD5 -->" &
                "<input type='hidden' name='client_id' value='" + strClientID + "'/>" &
                "<input type='hidden' name='md5' value='" + obtenerMD5(strClientID & strClientSecret & "1" & "ARS" & oServicio.precioReserva.ToString() & "" & "") + "'/>" &
                "<!-- Datos obligatorios del item -->" &
                "<input type='hidden' name='item_title' value='" + oServicio.nombre + "'/>" &
                "<input type='hidden' name='item_quantity' value='1'/>" &
                "<input type='hidden' name='item_currency_id' value='ARS'/>" &
                "<input type='hidden' name='item_unit_price' value='" + oServicio.precioReserva.ToString() + "'/>" &
                "" &
                "<input type='hidden' name='payer_name' value='" + oServicio.Usuario.nombre + " " + oServicio.Usuario.apellido + "'/>" &
                "<input type='hidden' name='payer_surname' value='" + oServicio.Usuario.nombreUsuario + "'/>" &
                "<input type='hidden' name='payer_email' value='" + oServicio.Usuario.email + "'/>" &
                "<input type='hidden' name='item_picture_url' value='http://centur.ugserver.com.ar/UrielWeb/Images/publicaciones/" + oServicio.foto + ".jpg'/>" &
                "<input type='hidden' name='back_url_success' value='http://centur.ugserver.com.ar/UrielOK'/>" &
                "<input type='hidden' name='back_url_pending' value='http://centur.ugserver.com.ar/UrielFAIL'/>" &
                "" &
                "<!-- Boton de pago -->" &
                "<button type='submit' class='lightblue-rn-m-tr' name='MP-Checkout'>Pagar</button>" &
                "</form>"
                ltlMercadoPago.Text = strBoton

                '            "<!-- Datos opcionales -->" &
                '"<input type='hidden' name='item_id' value='id_del_item'/>" &
                '"<input type='hidden' name='external_reference' value='referencia_externa_del_vendedor'/>" &


            End If
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