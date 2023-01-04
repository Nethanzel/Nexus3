Module mFicheros

  
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



    Public Enum eUnidades
        Bytes
        KB
        MB
        GB
    End Enum




    Function calcularVelocidad(ByVal lTamano As Long) As String
        Dim sCadena As String

        If (lTamano < 1024 ^ eVelocidades.GHz) Then ' Hasta 1GB
            sCadena = Format(lTamano / (1024 ^ 2), "F") & " MHz"

        Else ' A partir de 1 GB
            sCadena = Format(lTamano / (1024 ^ 3), "F") & " GHz"
        End If

        Return sCadena
    End Function



    Public Enum eVelocidades
        BHz
        KHz
        MHz
        GHz
    End Enum



End Module
