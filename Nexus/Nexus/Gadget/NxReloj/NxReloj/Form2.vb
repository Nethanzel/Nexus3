Imports System.Net.Sockets
Imports System.IO
Imports System.Threading

Public Class Form2


    Function GetDay(ByVal DayN As Integer) As String

        If DayN = 0 Then
            Return "Domingo"

        ElseIf DayN = 1 Then

            Return "Lunes"
        ElseIf DayN = 2 Then

            Return "Martes"
        ElseIf DayN = 3 Then

            Return "Miercoles"
        ElseIf DayN = 4 Then

            Return "Jueves"
        ElseIf DayN = 5 Then

            Return "Viernes"
        ElseIf DayN = 6 Then
            Return "Sabado"
        End If


    End Function

    Function GetMonth(ByVal Month As Integer) As String

        If Month = 1 Then

            Return "Enero"

        ElseIf Month = 2 Then
            Return "Febrero"

        ElseIf Month = 3 Then
            Return "Marzo"

        ElseIf Month = 4 Then
            Return "Abril"

        ElseIf Month = 5 Then
            Return "Mayo"

        ElseIf Month = 6 Then
            Return "Junio"

        ElseIf Month = 7 Then
            Return "Julio"

        ElseIf Month = 8 Then
            Return "Agosto"

        ElseIf Month = 9 Then
            Return "Septiembre"

        ElseIf Month = 10 Then
            Return "Octubre"

        ElseIf Month = 11 Then
            Return "Noviembre"

        ElseIf Month = 12 Then
            Return "Diciembre"
        End If


    End Function


    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If

    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove

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

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()

    End Sub


    Public NetworkTime As String

    Dim client As TcpClient
    Dim HostDirection As String = "localhost"

    Public Sub SendCommand()

        Try
            client = New TcpClient(HostDirection, 2200)
            Dim streamw As New StreamWriter(client.GetStream())
            streamw.Write(NetworkTime)

            streamw.Flush()

        Catch ex As Exception

        End Try


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Size = New Size(200, 200)

        Form1.OvalShape1.Location = New Point((Form1.Width / 2) - (Form1.OvalShape1.Width / 2), (Form1.Height / 2) - (Form1.OvalShape1.Height / 2))

        Form1.LineShape1.X1 = 100
        Form1.LineShape1.Y1 = 100

        Form1.MinutosShape.X1 = 100
        Form1.MinutosShape.Y1 = 100

        Form1.HorasShape.X1 = 100
        Form1.HorasShape.Y1 = 100

        Form1.PictureBox1.Location = New Point(171, 165)
        Form1.Label1.Location = New Point(11, 20)
        Form1.Panel2.Size = New Size(60, 60)
        Form1.Panel2.Location = New Point(45, 105)

        Form1.SegundoShape.X1 = 30
        Form1.SegundoShape.Y1 = 30



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form1.Size = New Size(300, 300)

        Form1.OvalShape1.Location = New Point((Form1.Width / 2) - (Form1.OvalShape1.Width / 2), (Form1.Height / 2) - (Form1.OvalShape1.Height / 2))

        Form1.LineShape1.X1 = 150
        Form1.LineShape1.Y1 = 150

        Form1.MinutosShape.X1 = 150
        Form1.MinutosShape.Y1 = 150

        Form1.HorasShape.X1 = 150
        Form1.HorasShape.Y1 = 150

        Form1.PictureBox1.Location = New Point(257, 249)
        Form1.Label1.Location = New Point(20, 35)
        Form1.Panel2.Size = New Size(80, 80)
        Form1.Panel2.Location = New Point(60, 170)

        Form1.SegundoShape.X1 = 40
        Form1.SegundoShape.Y1 = 40

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form1.Panel1.BackgroundImage = My.Resources.GGClock

        Form1.LineShape1.BorderColor = Color.Gray
        Form1.MinutosShape.BorderColor = Color.RoyalBlue
        Form1.HorasShape.BorderColor = Color.LightSlateGray
        Form1.OvalShape1.BackColor = Color.Black


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form1.LineShape1.BorderColor = Color.Gray
        Form1.MinutosShape.BorderColor = Color.RoyalBlue
        Form1.HorasShape.BorderColor = Color.LightSlateGray
        Form1.OvalShape1.BackColor = Color.Black

        Form1.Panel1.BackgroundImage = My.Resources.NxGGClock
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form1.LineShape1.BorderColor = Color.Gray
        Form1.Panel2.Visible = False

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form1.LineShape1.BorderColor = Color.Transparent
        Form1.Panel2.Visible = True
    End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.LineShape1.BorderColor = Color.White
        Form1.MinutosShape.BorderColor = Color.White
        Form1.HorasShape.BorderColor = Color.White
        Form1.OvalShape1.BackColor = Color.White

        Form1.Panel1.BackgroundImage = My.Resources.GGClockv1

        If Form1.Panel2.Visible = True Then
            Form1.LineShape1.BorderColor = Color.Transparent
        End If

    End Sub
End Class