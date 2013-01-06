Imports System.Drawing
Imports Datos

Public Class CrearServicioP2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub cargarImagen()
        ' Initialize variables
        Dim sSavePath As String
        Dim sThumbExtension As String
        Dim intMaxThumbSize As Integer = 200
        Dim intThumbWidth As Integer = intMaxThumbSize, intThumbHeight As Integer = intMaxThumbSize
        ' Set constant values
        sSavePath = "Images/publicaciones/"
        sThumbExtension = "_thumb"

        ' If file field isn’t empty
        If fleImagenServicio.PostedFile IsNot Nothing Then
            ' Check file size (mustn’t be 0)
            Dim myFile As HttpPostedFile = fleImagenServicio.PostedFile
            Dim nFileLen As Integer = myFile.ContentLength
            If nFileLen = 0 Then
                lblMensajeError.Text = "No se han subido archivos."
                Return
            End If

            ' Check file extension (must be JPG)
            If System.IO.Path.GetExtension(myFile.FileName).ToLower() <> ".jpg" Then
                lblMensajeError.Text = "El archivo debe tener formato JPG"
                Return
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
                Dim sThumbFile As String = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) & sThumbExtension & ".jpg"
                While System.IO.File.Exists(Server.MapPath(sSavePath & sThumbFile))
                    file_append += 1
                    sThumbFile = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) & file_append.ToString() & sThumbExtension & ".jpg"
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
            Catch errArgument As ArgumentException
                ' The file wasn't a valid jpg file
                lblMensajeError.Text = "The file wasn't a valid jpg file."
                System.IO.File.Delete(Server.MapPath(sSavePath & sFilename))
            End Try
        End If
    End Sub

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        cargarImagen()

        Response.Redirect("CrearServicioP3.aspx")
    End Sub

    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function
End Class