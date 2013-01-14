Public Class Maqueteado

    Public Sub AttachColor(ByVal listControl As ListControl, ByVal itemColor As String, ByVal alternatingColor As String)

        Dim color As String = itemColor

        For Each li As ListItem In listControl.Items
            color = If((color = itemColor), alternatingColor, itemColor)
            li.Attributes("style") = " background-color: " & color
        Next

    End Sub

End Class
