Imports System.Drawing.Drawing2D

Module CodeTools


    Sub CircleImgPic(ByVal picBox As Windows.Forms.PictureBox, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim figura As GraphicsPath = New GraphicsPath
        Dim ancho, alto As Integer

        ancho = picBox.Width
        alto = picBox.Height

        Dim s As Integer

        If ancho > alto Then
            s = alto
            figura.AddEllipse(New Rectangle((ancho / 2) - (alto / 2), 0, s, s))

        ElseIf ancho < alto Then
            s = ancho
            figura.AddEllipse(New Rectangle((ancho / 2) - (alto / 2), 0, s, s))

        ElseIf ancho = alto Then
            figura.AddEllipse(New Rectangle(0, 0, ancho, alto))
        End If

        picBox.Region = New Region(figura)

        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

    End Sub

    Function GetWebIcon(ByVal StrUrl As String) As Image

        Try
            Dim url As Uri = New Uri(StrUrl)

            Dim favicon As Image = Nothing

            If url.HostNameType = UriHostNameType.Dns Then

                Dim iconURL = "http://" & url.Host & "/favicon.ico"
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                Dim response As System.Net.WebResponse = request.GetResponse
                Dim stream As System.IO.Stream = response.GetResponseStream
                favicon = Image.FromStream(stream)

            End If

            Return favicon

        Catch ex As Exception
            Return Nothing

        End Try

    End Function


    Function RedimencionarGrafico(ByVal Rout As String) As Image

        Dim Img As Image = Image.FromFile(Rout)

        If Img.Height = Img.Width Then

            Dim NewGraph As New Bitmap(New Bitmap(Rout), 50, 50)

            Return NewGraph

        Else
            Return Nothing

        End If


    End Function


End Module
