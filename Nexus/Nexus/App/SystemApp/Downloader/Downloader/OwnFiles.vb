

Module OwnFiles

    Public ShowHide As Boolean = False
    Public RutaActual As String = ""
    Public RootUser As String

    Function calcularTamano(ByVal lTamano As Long) As String
        Dim sCadena As String

        ' Cálculo del tamaño dependiendo de ciertos límites
        If lTamano < 1024 Then ' Hasta 1KB
            sCadena = lTamano & " Bytes"
        ElseIf (lTamano < 1024 ^ eUnidades.MB) Then ' Hasta 1MB
            sCadena = Format(lTamano / 1024, "F") & " KB"
        ElseIf (lTamano < 1024 ^ eUnidades.GB) Then ' Hasta 1GB
            sCadena = Format(lTamano / (1024 ^ 2), "F") & " MB"
        Else ' A partir de 1 GB
            sCadena = Format(lTamano / (1024 ^ 3), "F") & " GB"
        End If

        Return sCadena
    End Function

    Function calcularTamanoII(ByVal lTamano As Long) As String
        Dim sCadena As String

        ' Cálculo del tamaño dependiendo de ciertos límites
        If lTamano < 1024 Then ' Hasta 1KB
            sCadena = lTamano & " Bytes"
        ElseIf (lTamano < 1024 ^ eUnidadess.MB) Then ' Hasta 1MB
            sCadena = Format(lTamano / 1024, "F") & " KB"
        Else
            sCadena = Format(lTamano / (1024 ^ 2), "F") & " MB"
        End If

        Return sCadena
    End Function


    Function calcularVelocidad(ByVal lTamano As Long) As String
        Dim sCadena As String

        ' Cálculo del tamaño dependiendo de ciertos límites
        If lTamano < 1024 Then ' Hasta 1KB
            sCadena = lTamano & " Bytes/Seg"
        ElseIf (lTamano < 1024 ^ eUnidades.MB) Then ' Hasta 1MB
            sCadena = Format(lTamano / 1024, "F") & " Kb/Seg"
        ElseIf (lTamano < 1024 ^ eUnidades.GB) Then ' Hasta 1GB
            sCadena = Format(lTamano / (1024 ^ 2), "F") & " Mb/Seg"
        Else ' A partir de 1 GB
            sCadena = Format(lTamano / (1024 ^ 3), "F") & " Gb/Seg"
        End If

        Return sCadena
    End Function

    Public Enum eUnidades
        Bytes
        KB
        MB
        GB
    End Enum

    Public Enum eUnidadess
        Bytes
        KB
        MB
    End Enum


End Module
