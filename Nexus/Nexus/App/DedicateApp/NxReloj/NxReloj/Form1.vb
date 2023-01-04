Imports NxReloj.Form2
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Math
Imports System.Drawing.Drawing2D

Public Class Form1

    Public fInput As Long = Now.TimeOfDay.TotalSeconds


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Label1.Left = (Panel3.Width / 2) - Label1.Width / 2
        Label2.Left = (Panel3.Width / 2) - Label2.Width / 2


        MonthCalendar1.TodayDate = (New System.DateTime(Form2.SystemDateTime.Year, Form2.SystemDateTime.Month, Form2.SystemDateTime.Day))

        Label1.Text = Form2.SystemDateTime.TimeOfDay.ToString & " " & Form2.apm
        Label2.Text = Form2.GetDay(MonthCalendar1.TodayDate.DayOfWeek) & ", " & MonthCalendar1.TodayDate.Day & " de " & Form2.GetMonth(MonthCalendar1.TodayDate.Month) & " del " & MonthCalendar1.TodayDate.Year

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If aaa = True Then
            Dim tmp As Point = New Point

            tmp.X = Me.Location.X + (e.X - MouseX)
            tmp.Y = Me.Location.Y + (e.Y - MouseY)
            Me.Location = tmp
            tmp = Nothing

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        MonthCalendar1.ShowToday = Not MonthCalendar1.ShowToday

        Form2.Show()
        Form2.Hide()


        Me.Left = My.Computer.Screen.WorkingArea.Width - (Me.Width + 3)
        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 13)


        IO.File.WriteAllText("N:\Nexus\AppWork\RelojService\IsRun", "True")


        Label1.Left = (Panel3.Width / 2) - (Label1.Width / 2)
        Label2.Left = (Panel3.Width / 2) - (Label2.Width / 2)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Form2.Show()
        Form2.OnShowMe()

    End Sub

    Dim read As String

    Private Sub Reader_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reader.Tick

        Dim cUser As String = IO.File.ReadAllText("N:\Nexus\AppWork\Settings\CrrntUser\Name")
        Dim wRoute As String = "N:\Users\" & cUser & "\Configs\AppConfig\Time\Format"
        Form2.FormatHour = CBool(IO.File.ReadAllText(wRoute))

        Try
            read = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\-RelojVs")

            If read = "True" Then
                Me.Opacity = 100
                Form2.Opacity = 100
                Me.Visible = True

            ElseIf read = "False" Then
                Me.Visible = False

            ElseIf read = "Cog" Then
                Form2.Show()
                Form2.Opacity = 100
                Form2.OnShowMe()
            End If


        Catch ex As Exception

        End Try


        Me.Left = My.Computer.Screen.WorkingArea.Width - (Me.Width + 3)
        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 13)


    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        IO.File.WriteAllText("N:\Nexus\AppWork\RelojService\IsRun", "False")
    End Sub


    Const R = 3.1415927 / 180

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick


        Dim CentroX As Integer = Panel1.Width / 2
        Dim CentroY As String = Panel1.Height / 2

        SegundoShape.X2 = CentroX + Sin(Form2.SystemDateTime.Second * 6 * R) * 130
        SegundoShape.Y2 = CentroY - Cos(Form2.SystemDateTime.Second * 6 * R) * 130

        MinutosShape.X2 = CentroX + Sin(Form2.SystemDateTime.Minute * 6 * R) * 130
        MinutosShape.Y2 = CentroY - Cos(Form2.SystemDateTime.Minute * 6 * R) * 130

        HorasShape.X2 = CentroX + Sin(Form2.SystemDateTime.Hour * 30 * R) * 100
        HorasShape.Y2 = CentroY - Cos(Form2.SystemDateTime.Hour * 30 * R) * 100



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

    Private Sub Panel1_Paint_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        CircleImg(Me.Panel1, e)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If Panel4.Visible = True Then
            Panel4.Visible = False
            Panel1.Visible = True
        Else
            Panel4.Visible = True
            Panel1.Visible = False
        End If
    End Sub
End Class
