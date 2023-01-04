Imports System.Reflection
Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1

    Dim ChrStt As String
    Dim Percent As Integer = Nothing
    Dim st As String = Nothing

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        RESPUESTA = "--"

        Dim t As Type = GetType(System.Windows.Forms.PowerStatus)
        Dim pi As PropertyInfo() = t.GetProperties()



        For i = 0 To pi.Length - 1
            Dim propval As Object = pi(i).GetValue(SystemInformation.PowerStatus, Nothing)

            ' TextBox1.Text += pi(i).Name & " * " & propval.ToString() & vbNewLine

            If pi(i).Name = "PowerLineStatus" Then

                If propval.ToString() = "Online" And ChrStt = "High" Then

                    Label1.Text = "Carga completa."
                    Panel3.BackgroundImage = Nothing
                    Panel4.BackgroundImage = Nothing
                    st = "full"
                ElseIf propval.ToString() = "Online" And ChrStt = "High, Charging" Or ChrStt = "Charging" Then

                    Label1.Text = "Cargando..."
                    Panel4.BackgroundImage = My.Resources.WhiteChrg
                    Panel3.BackgroundImage = My.Resources.BlackChrg
                    st = "char"
                Else

                    Label1.Text = "Descargando..."
                    Panel3.BackgroundImage = Nothing
                    Panel4.BackgroundImage = Nothing
                    st = "dis"
                End If

            ElseIf pi(i).Name = "BatteryLifePercent" Then

                Dim BatVal As Double = propval
                percent = BatVal * 100
                Label2.Text = Percent & "%"
                Panel4.Width = (Percent / 100) * Panel3.Width '(ProgressBar1.Value / ProgressBar1.Maximum) * Panel8.Width

            ElseIf pi(i).Name = "BatteryLifeRemaining" Then
                Dim FromSecond As Integer = propval

                If FromSecond < 0 Then
                    Label3.Text = "Estimando..."
                    Return
                Else
                    Dim RemainTime As TimeSpan = TimeSpan.FromSeconds(FromSecond)
                    Dim StringTime As String = ""

                    If RemainTime.Hours > 0 And RemainTime.Hours = 1 And RemainTime.Minutes > 1 Then
                        StringTime = RemainTime.Hours & " hora y " & RemainTime.Minutes & " minutos"

                    ElseIf RemainTime.Hours > 0 And RemainTime.Hours > 1 And RemainTime.Minutes > 1 Then
                        StringTime = RemainTime.Hours & " horas y " & RemainTime.Minutes & " minutos"

                    ElseIf RemainTime.Hours > 0 And RemainTime.Hours > 1 And RemainTime.Minutes <= 1 Then
                        StringTime = RemainTime.Hours & " horas y " & RemainTime.Minutes & " minuto"

                    Else
                        StringTime = RemainTime.Minutes & " minutos."
                    End If


                    Label3.Text = "Quedan " & StringTime & " de uso."

                End If

            ElseIf pi(i).Name = "BatteryChargeStatus" Then
                ChrStt = propval.ToString

            End If



        Next


        
    End Sub

    Private Sub Reader_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reader.Tick

        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 13)
        Me.Left = My.Computer.Screen.WorkingArea.Width - (Me.Width + 5)

        Dim x As String = ""

        Try
            x = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Btr")
        Catch ex As Exception

        End Try

        If x = "True" Then
            Me.Show()
            Me.Opacity = 100%
        Else
            Me.Hide()

        End If

        Label3.Left = (Me.Width / 2) - (Label3.Width / 2)

        RESPUESTA = Percent & "-" & st

        'MsgBox(RESPUESTA)
    End Sub


#Region "Server"

    Dim SERVIDOR As HttpListener
    Dim HEBRA As Threading.Thread
    Dim RESPUESTA As String

    Sub StartServer()
        Try

            SERVIDOR = New HttpListener
            SERVIDOR.Prefixes.Add("http://localhost:13914/bactery/")
            SERVIDOR.Start()
            HEBRA = New Threading.Thread(AddressOf RESPONDE)
            HEBRA.Start()
        Catch ex As Exception
            MsgBox(ex.Message, Nothing, "1")
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
                MsgBox(ex.Message, Nothing, "2")
            End Try
        End While

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            HEBRA.Abort()
            SERVIDOR.Stop()
            Application.Exit()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartServer()
    End Sub


#End Region

End Class
