Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Text
Imports System.Net


Public Class Form2

#Region "OldCode"

    ''______________________________
    'Dim s As Integer = TimeOfDay.Second
    'Dim m As Integer = TimeOfDay.Minute
    'Dim h As Integer = TimeOfDay.Hour
    ''_____________________________
    'Dim ToDay As Integer = Now.Day
    'Dim Mont As Integer = Now.Month
    'Dim Year As Integer = Now.Year

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    s = s + 1

    '    '___________________________________________
    '    If s > 59 Then
    '        s = 0
    '        m = m + 1
    '    End If

    '    '_____________________________________________


    '    If m > 59 Then
    '        m = 0
    '        h = h + 1
    '        ChangeDay = False
    '    End If

    '    '_____________________________________________

    '    If h > 23 Then
    '        h = 0
    '    End If



    'End Sub

    'Dim Mes As Integer = Mont
    'Dim Dia As Integer = ToDay
    'Dim Año As Integer = Year

    'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Seconds As String = s
    '    Dim Minutes As String = m
    '    Dim Hours As String = h


    '    TYear = Year

    '    If Seconds <= 9 Then
    '        Seconds = "0" & Seconds
    '        TSecond = Seconds
    '    Else
    '        Seconds = Seconds
    '        TSecond = Seconds
    '    End If

    '    If Minutes <= 9 Then
    '        Minutes = "0" & Minutes
    '        TMinutos = Minutes
    '    Else
    '        Minutes = Minutes
    '        TMinutos = Minutes
    '    End If

    '    If Hours <= 9 Then
    '        Hours = "0" & Hours
    '        THoras = Hours
    '    Else
    '        Hours = Hours
    '        THoras = Hours
    '    End If

    '    Form1.Label1.Text = Hours & ":" & Minutes & ":" & Seconds


    '    If Dia <= 9 Then
    '        Dia = "0" & Dia
    '        TDay = "0" & Dia
    '    Else
    '        Dia = Dia
    '        TDay = Dia
    '    End If

    '    If Mes <= 9 Then
    '        Mes = "0" & Mes
    '        TMes = "0" & Mes

    '    Else
    '        Mes = Mes
    '        TMes = Mes
    '    End If


    '    Dim DoceOclock As String = Hours & ":" & Minutes & ":" & Seconds


    '    If DoceOclock = "00:00:00" Then
    '        'ChangeDay = False
    '        If Not ChangeDay = True Then
    '            Dia = Dia + 1
    '            'TDay = Dia
    '            ChangeDay = True
    '        End If

    '    End If


    '    Try
    '        'Form1.MonthCalendar1.TodayDate = (New System.DateTime(TYear, TMes, TDay))
    '    Catch ex As Exception

    '    End Try

    '    'Form1.Label2.Text = GetDay(Form1.MonthCalendar1.TodayDate.DayOfWeek) & ", " & Dia & " de " & GetMonth(Mes) & " del " & Año


    '    ' MsgBox(TimeSpan.FromTicks(x).ToString)

    'End Sub

    'Dim ChangeDay As Boolean = True
    'Dim client As TcpClient
    'Dim HostDirection As String = "localhost"

    'Public Sub SendCommand()

    '    Try
    '        client = New TcpClient(HostDirection, 2200)
    '        Dim streamw As New StreamWriter(client.GetStream())
    '        streamw.Write(NetworkTime)

    '        streamw.Flush()

    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Public Sub SendCommandGG()

    '    Try
    '        client = New TcpClient(HostDirection, 2210)
    '        Dim streamw As New StreamWriter(client.GetStream())
    '        streamw.Write(NetworkTime)

    '        streamw.Flush()

    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim thread2 As New Thread(New ThreadStart(AddressOf SendCommandGG))
    '    thread2.Start()
    'End Sub

    'Public NetworkTime As String


    'Private Sub Writer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Try
    '    '    IO.File.WriteAllText("N:\NexusFrameWork\Date-$-Time/#Seconds", TSecond)
    '    '    IO.File.WriteAllText("N:\NexusFrameWork\Date-$-Time/#Minutes", TMinutos)
    '    '    IO.File.WriteAllText("N:\NexusFrameWork\Date-$-Time/#Horas", THoras)

    '    '    IO.File.WriteAllText("N:\NexusFrameWork\Date-$-Time/#Day", TDay)
    '    '    IO.File.WriteAllText("N:\NexusFrameWork\Date-$-Time/#Month", TMes)
    '    '    IO.File.WriteAllText("N:\NexusFrameWork\Date-$-Time/#Year", Year)
    '    'Catch ex As Exception

    '    'End Try

    '    NetworkTime = THoras & ":" & TMinutos & ":" & TSecond & "*" & TDay & "-" & TMes & "-" & Year

    '    Dim thread As New Thread(New ThreadStart(AddressOf SendCommand))
    '    thread.Start()

    'End Sub

#End Region


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
        Me.Hide()

    End Sub

    Sub OnShowMe()

        NumericUpDown1.Value = SystemDateTime.Hour.ToString
        NumericUpDown2.Value = SystemDateTime.Minute.ToString
        NumericUpDown3.Value = SystemDateTime.Second.ToString

        NumericUpDown6.Value = SystemDateTime.Day.ToString
        NumericUpDown5.Value = SystemDateTime.Month.ToString
        NumericUpDown4.Value = SystemDateTime.Year.ToString

        If FormatHour = True Then
            ComboBox1.SelectedIndex = 0
        Else
            ComboBox1.SelectedIndex = 1
        End If

        Me.Opacity = 100%
    End Sub

#Region "NewCode"


    Public SystemHour As String
    Public SystemDate As String = Now.Day & "/" & Now.Month & "/" & Now.Year

    Public SystemDateTime As Date

    Public apm As String

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Form1.fInput > 86399 Then
            Form1.fInput = 0
            NewDate()
        End If


        If FormatHour = False Then
            SystemHour = TimeSpan.FromSeconds(Form1.fInput).ToString
            apm = ""
        Else

            Dim SstmHour As String = TimeSpan.FromSeconds(Form1.fInput).ToString

            '''''
            If CDate(SstmHour).Hour > -1 And CDate(SstmHour).Hour < 12 Then
                apm = "a.m."
            Else
                apm = "p.m."
            End If

            If CDate(SstmHour).Hour > 12 Then
                SystemHour = (CDate(SstmHour).Hour - 12) & ":" & CDate(SstmHour).Minute & ":" & CDate(SstmHour).Second
            ElseIf CDate(SstmHour).Hour = 0 Then
                SystemHour = "12:" & CDate(SstmHour).Minute & ":" & CDate(SstmHour).Second

            Else
                SystemHour = TimeSpan.FromSeconds(Form1.fInput).ToString
            End If
        End If

        SystemDateTime = SystemDate & " " & SystemHour

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'incrementador del tiempo
        Form1.fInput = Form1.fInput + 1
        'end incrementador
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        Dim NwHour As String
        NwHour = NumericUpDown1.Value & ":" & NumericUpDown2.Value & ":" & NumericUpDown3.Value

        Dim NwDate As String
        NwDate = NumericUpDown4.Value & "/" & NumericUpDown5.Value & "/" & NumericUpDown6.Value

        Dim NwDateTime As Date = NwDate & " " & NwHour

        Form1.fInput = NwDateTime.TimeOfDay.TotalSeconds

        SystemDate = NwDateTime.Day & "/" & NwDateTime.Month & "/" & NwDateTime.Year

    End Sub

    Sub NewDate()

        Dim x As Boolean = True

        Do While x = True

            If SystemDateTime.Month = 1 And SystemDateTime.Day = 31 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 2 And SystemDateTime.Day = 28 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 3 And SystemDateTime.Day = 31 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 4 And SystemDateTime.Day = 30 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 5 And SystemDateTime.Day = 31 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 6 And SystemDateTime.Day = 30 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 7 And SystemDateTime.Day = 31 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 8 And SystemDateTime.Day = 31 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 9 And SystemDateTime.Day = 30 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 10 And SystemDateTime.Day = 31 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 11 And SystemDateTime.Day = 30 Then
                SystemDate = 1 & "/" & SystemDateTime.Month + 1 & "/" & SystemDateTime.Year

            ElseIf SystemDateTime.Month = 12 And SystemDateTime.Day = 31 Then
                SystemDate = 1 & "/" & 1 & "/" & SystemDateTime.Year + 1

            Else

                SystemDate = SystemDateTime.Day + 1 & "/" & SystemDateTime.Month & "/" & SystemDateTime.Year

            End If

            x = False
        Loop

    End Sub


    Public FormatHour As Boolean
    Dim cUser As String

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        cUser = IO.File.ReadAllText("N:\Nexus\AppWork\Settings\CrrntUser\Name")
        Dim wRoute As String = "N:\Users\" & cUser & "\Configs\AppConfig\Time\Format"


        If ComboBox1.SelectedIndex = 0 Then
            FormatHour = True
        Else
            FormatHour = False
        End If

        IO.File.WriteAllText(wRoute, FormatHour.ToString)

    End Sub


#End Region


#Region "Server"


    Dim SERVIDOR As HttpListener
    Dim HEBRA As Threading.Thread
    Dim RESPUESTA As String

    Sub StartServer()
        Try

            SERVIDOR = New HttpListener
            SERVIDOR.Prefixes.Add("http://localhost:13513/SystemTime/")
            SERVIDOR.Start()
            HEBRA = New Threading.Thread(AddressOf RESPONDE)
            HEBRA.Start()
        Catch ex As Exception

            SERVIDOR.Close()
        End Try

    End Sub

    Public Sub RESPONDE()
        While True
            Try
                Dim CONTEXTO As HttpListenerContext = SERVIDOR.GetContext
                CONTEXTO.Response.ContentLength64 = Encoding.UTF8.GetByteCount(RESPUESTA)
                CONTEXTO.Response.StatusCode = HttpStatusCode.OK
                Dim MISTREAM As Stream = CONTEXTO.Response.OutputStream
                Using (MISTREAM)
                    Using ESCRITOR As StreamWriter = New StreamWriter(MISTREAM)
                        ESCRITOR.Write(RESPUESTA)
                    End Using
                End Using
            Catch ex As Exception

            End Try
        End While

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            HEBRA.Abort()
            SERVIDOR.Stop()
            Application.Exit()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartServer()
    End Sub

    Private Sub IsRunningServer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles IsRunningServer.Tick
        RESPUESTA = SystemDateTime & " " & apm
    End Sub

#End Region




End Class