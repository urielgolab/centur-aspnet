Imports System.Drawing
Imports Datos

Public Class CrearServicioP2
    Inherits System.Web.UI.Page

    Dim oServicio As Servicio
    Dim dc As DC

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("oDataContext") Is Nothing Then
            dc = DirectCast(Session("oDataContext"), DC)
        Else
            dc = New DC()
        End If

        If Not Session("oServicio") Is Nothing Then
            oServicio = DirectCast(Session("oServicio"), Servicio)
        End If

        If Not oServicio Is Nothing AndAlso oServicio.idZona > 0 AndAlso lstZonas.SelectedValue = "" Then
            cargarZona(oServicio.idZona)
        Else
            cargaroZonasHijo(lstZonas.SelectedValue)
        End If

        If Not Page.IsPostBack Then
            cargarDatosServicio()
        End If
    End Sub
    Private Sub cargarDatosServicio()
        txtTitulo.Text = oServicio.nombre
        txtDireccion.Text = oServicio.direccion
        txtDescripcion.Value = oServicio.descripcion
        If oServicio.foto <> "" Then
            imgFotoServicio.ImageUrl = "Images/publicaciones/thumb_" + oServicio.foto
        Else
            imgFotoServicio.Visible = False
        End If
    End Sub
    Private Function cargarImagen(ByRef strNombreArchivo As String) As String
        ' Initialize variables
        Dim sSavePath As String
        Dim sThumbExtension As String
        Dim intMaxThumbSize As Integer = 100
        Dim intThumbWidth As Integer = intMaxThumbSize, intThumbHeight As Integer = intMaxThumbSize
        ' Set constant values
        sSavePath = "Images/publicaciones/"
        sThumbExtension = "thumb_"

        ' If file field isn’t empty
        If fleImagenServicio.PostedFile IsNot Nothing Then
            ' Check file size (mustn’t be 0)
            Dim myFile As HttpPostedFile = fleImagenServicio.PostedFile
            Dim nFileLen As Integer = myFile.ContentLength
            If nFileLen = 0 Then
                lblMensajeError.Text = "No se han subido archivos."
                Return True
            End If

            ' Check file extension (must be JPG)
            If System.IO.Path.GetExtension(myFile.FileName).ToLower() <> ".jpg" Then
                lblMensajeError.Text = "El archivo debe tener formato JPG"
                Return False
            End If

            ' Read file into a data stream
            Dim myData As Byte() = New [Byte](nFileLen - 1) {}
            myFile.InputStream.Read(myData, 0, nFileLen)

            ' Make sure a duplicate file doesn’t exist.  If it does, keep on appending an 
            ' incremental numeric until it is unique
            Dim sFilename As String = System.IO.Path.GetFileName(myFile.FileName)
            Dim file_append As Integer = 0
            While System.IO.File.Exists(Server.MapPath(sSavePath & sFilename))
                file_append += 1
                sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) & file_append.ToString() & ".jpg"
                strNombreArchivo = sFilename
            End While

            ' Save the stream to disk
            Dim newFile As New System.IO.FileStream(Server.MapPath(sSavePath & sFilename), System.IO.FileMode.Create)
            newFile.Write(myData, 0, myData.Length)
            newFile.Close()

            ' Check whether the file is really a JPEG by opening it
            Dim myCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
            Dim myBitmap As Bitmap
            Try
                myBitmap = New Bitmap(Server.MapPath(sSavePath & sFilename))

                ' If jpg file is a jpeg, create a thumbnail filename that is unique.
                file_append = 0
                Dim sThumbFile As String = sThumbExtension & System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) & ".jpg"
                While System.IO.File.Exists(Server.MapPath(sSavePath & sThumbFile))
                    file_append += 1
                    sThumbFile = sThumbExtension & System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) & file_append.ToString() & ".jpg"
                End While

                ' Save thumbnail and output it onto the webpage
                Dim ratio As Double

                If (myBitmap.Width > myBitmap.Height) Then 'find the greater proportion
                    ratio = intThumbWidth / myBitmap.Width
                    intThumbHeight = myBitmap.Height * ratio
                Else
                    ratio = intThumbHeight / myBitmap.Height
                    intThumbWidth = myBitmap.Width * ratio
                End If

                Dim myThumbnail As System.Drawing.Image = myBitmap.GetThumbnailImage(intThumbWidth, intThumbHeight, myCallBack, IntPtr.Zero)
                myThumbnail.Save(Server.MapPath(sSavePath & sThumbFile))
                imgFotoServicio.ImageUrl = sSavePath & sThumbFile

                ' Displaying success information
                'lblMensajeError.Text = "File uploaded successfully!"

                ' Destroy objects
                myThumbnail.Dispose()
                myBitmap.Dispose()
                Return True
            Catch errArgument As ArgumentException
                ' The file wasn't a valid jpg file
                lblMensajeError.Text = "The file wasn't a valid jpg file."
                System.IO.File.Delete(Server.MapPath(sSavePath & sFilename))
                Return False
            End Try
        End If
        Return True
    End Function

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        Dim strNombreArchivo As String = Nothing
        If cargarImagen(strNombreArchivo) Then
            With oServicio
                .nombre = txtTitulo.Text
                .direccion = txtDireccion.Text
                .descripcion = txtDescripcion.Value
                .foto = strNombreArchivo
                .idZona = lstZonas.SelectedValue
            End With

            Session("oServicio") = oServicio

            Response.Redirect("CrearServicioP3.aspx")
        End If
    End Sub

    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Protected Sub lstZonas_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstZonas.SelectedIndexChanged

    End Sub

    Private Sub cargarZona(ByVal idZona As Integer)
        Dim Categorias = (From c In dc.Zonas
                         Join sch In dc.SubZonas On c.idZona Equals sch.idZonaHijo
                         Where sch.idZonaPadre = dc.SubCategorias.Single(Function(x) x.idCategoriaHijo = idZona).idCategoriaPadre
                         Select c).ToList()

        If Categorias.Count > 0 Then
            'If strCategoria <> "" Then
            '    lnkCategoriaPadre.Text = lstCategoria.Items(lstCategoria.SelectedIndex).Text
            '    lnkCategoriaPadre.ToolTip = lstCategoria.Items(lstCategoria.SelectedIndex).Value
            'End If
            lnkCategoriaPadre.Text = dc.ZonaObtenerPadre(idZona)

            btnSiguiente.Enabled = True

            lstZonas.DataSource = Categorias
            lstZonas.DataTextField = "descripcion"
            lstZonas.DataValueField = "idZona"
            lstZonas.DataBind()

            lstZonas.SelectedValue = idZona
        End If
    End Sub

    Private Sub cargaroZonasHijo(ByVal strZona As String)
        Dim idZona As Integer?

        If strZona <> "" Then idZona = strZona

        Dim Zonas = dc.ZonaBuscar(CType(IIf(idZona Is Nothing, "R", "H"), Char), idZona).ToList()

        If Zonas.Count > 0 Then
            'If strCategoria <> "" Then
            '    lnkCategoriaPadre.Text = lstCategoria.Items(lstCategoria.SelectedIndex).Text
            '    lnkCategoriaPadre.ToolTip = lstCategoria.Items(lstCategoria.SelectedIndex).Value
            'End If
            lnkCategoriaPadre.Text = dc.ZonaObtenerPadre(idZona)

            btnSiguiente.Enabled = False

            lstZonas.DataSource = Zonas
            lstZonas.DataTextField = "descripcion"
            lstZonas.DataValueField = "idZona"
            lstZonas.DataBind()
        Else
            btnSiguiente.Enabled = True
        End If

    End Sub
End Class