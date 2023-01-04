Imports GGClock.Form2
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Net

Public Class Form1
    Dim Mes As String
    Dim DiaDelaSemana As String

    Dim AppDirection As String = "N:\Nexus\AppWork\Settings\Clock"


    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If aaa = True Then
            Dim tmp As Point = New Point

            tmp.X = Me.Location.X + (e.X - MouseX)
            tmp.Y = Me.Location.Y + (e.Y - MouseY)
            Me.Location = tmp
            tmp = Nothing

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub





    Const R = 3.1415927 / 180

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Dim CentroX As Integer = Me.Width / 2
        Dim CentroX2 As Integer = Panel2.Width / 2


        LineShape1.X2 = CentroX + Sin(Second(NetworkTime) * 6 * R) * (CentroX - (CentroX / 6))
        LineShape1.Y2 = CentroX - Cos(Second(NetworkTime) * 6 * R) * (CentroX - (CentroX / 6))
        SegundoShape.X2 = CentroX2 + Sin(Second(NetworkTime) * 6 * R) * (CentroX2 - (CentroX2 / 6))
        SegundoShape.Y2 = CentroX2 - Cos(Second(NetworkTime) * 6 * R) * (CentroX2 - (CentroX2 / 6))

        MinutosShape.X2 = CentroX + Sin(Minute(NetworkTime) * 6 * R) * (CentroX - (CentroX / 6))
        MinutosShape.Y2 = CentroX - Cos(Minute(NetworkTime) * 6 * R) * (CentroX - (CentroX / 6))

        HorasShape.X2 = CentroX + Sin(Hour(NetworkTime) * 30 * R) * (CentroX - (CentroX / 4))
        HorasShape.Y2 = CentroX - Cos(Hour(NetworkTime) * 30 * R) * (CentroX - (CentroX / 4))


        'panel1.Refresh()
    End Sub



    Sub CircleImg(ByVal Panel As Windows.Forms.Panel, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim figura As GraphicsPath = New GraphicsPath
        Dim x, y, ancho, alto As Integer

        ancho = Panel.Width
        alto = Panel.Height

        x = (Panel.Width - ancho) / 2
        y = (Panel.Height - alto) / 2

        figura.AddEllipse(New Rectangle(x, y, ancho, alto))

        Panel.Region = New Region(figura)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

    End Sub

    Private Sub Panel1_Paint_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        CircleImg(Me.Panel1, e)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Form2.Show()

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        CircleImg(Me.Panel2, e)
    End Sub

    Dim Listener As New TcpListener(2210)
    Dim client As TcpClient
    Dim message As String

    Dim HH
    Dim NetworkTime As Date

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        Try
            Dim request As WebRequest = WebRequest.Create("http://localhost:13513/systemtime/")

            request.Credentials = CredentialCache.DefaultCredentials

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            If responseFromServer.EndsWith(".") Then
                NetworkTime = responseFromServer.Remove(responseFromServer.Length - 5)
            Else
                NetworkTime = responseFromServer
            End If


            reader.Close()
            dataStream.Close()
            response.Close()

        Catch ex As Exception

        End Try

        'Try

        '    Listener.Start()

        '    If Listener.Pending = True Then
        '        Message = ""
        '        client = Listener.AcceptTcpClient
        '        Dim streamr As New StreamReader(client.GetStream())
        '        While streamr.Peek > -1
        '            Message = Message + Convert.ToChar(streamr.Read()).ToString
        '        End While

        '        Dim CommandRec As String = Message

        '        Dim pst As Integer = CommandRec.IndexOf("*")
        '        HH = CommandRec.Remove(pst)

        '        NetworkTime = Now.Date & " " & HH

        '    End If

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

        Try
            IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Clock/IsRun", "False")
        Catch ex As Exception
            IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Clock/IsRun", "False")
        End Try

        End

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Clock/IsRun", "True")
        Catch ex As Exception
            IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Clock/IsRun", "True")
        End Try


    End Sub
End Class
