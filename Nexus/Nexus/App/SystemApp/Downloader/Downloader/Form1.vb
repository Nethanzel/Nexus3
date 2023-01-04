Imports System.Net

Public Class Form1

    Dim WithEvents CLIENTE As New WebClient
    Dim FileName As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim RUTA As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\"

            FileName = System.IO.Path.GetFileName(TextBox1.Text)

            Dim GUARDAR As String = RUTA & FileName
            Label10.Text = FileName

            Second = 0
            DownResult = False
            UseColor = Color.DodgerBlue

            Label13.Text = GUARDAR
            Label11.Text = TextBox1.Text
            Label15.Text = ""

            CLIENTE.DownloadFileAsync(New Uri(TextBox1.Text), GUARDAR)

            Timer2.Start()
            Timer1.Start()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CLIENTE_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles CLIENTE.DownloadFileCompleted
        If DownResult = False And Total > 0 Then

            If Stopped = True Then

                UseColor = Color.Orange
                CLIENTE.CancelAsync()
                Timer1.Stop()
                Timer2.Stop()
                Label15.ForeColor = Color.Orange
                Label15.Text = "Descarga detenida"
                Panel1.Refresh()
                Stopped = False
            Else
                UseColor = Color.Red
                CLIENTE.CancelAsync()
                Timer1.Stop()
                Timer2.Stop()
                Label15.ForeColor = Color.Red
                Label15.Text = "Error en la descarga"
                Panel1.Refresh()
            End If
        ElseIf DownResult = True And Total > 0 Then
            UseColor = Color.Green
            CLIENTE.CancelAsync()
            Timer1.Stop()
            Timer2.Stop()
            Label15.ForeColor = Color.Green
            Label15.Text = "Descarga fianlizada"
            Panel1.Refresh()
        End If

    End Sub

    Dim Total As Long = 0
    Dim Current As Long = 0
    Dim percent As Integer = 0

    Private Sub CLIENTE_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles CLIENTE.DownloadProgressChanged

        Total = e.TotalBytesToReceive
        Current = e.BytesReceived
        percent = e.ProgressPercentage

        If Current = Total Then
            DownResult = True
        End If

    End Sub

    Dim Stopped As Boolean = False

    Sub ClearDatas()
        percent = 0
        Label11.Text = "-----"
        Label13.Text = "-----"
        Label10.Text = "-----"
        Label2.Text = "-----"
        Label3.Text = "-----"
        Label5.Text = "-----"
        Label7.Text = "-----"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Stopped = True
        CLIENTE.CancelAsync()
        Timer1.Stop()
        Timer2.Stop()
        ClearDatas()
        Panel1.Refresh()
    End Sub

    Dim Second As Integer
    Dim DownResult As Boolean = False

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            Dim speed As String
            Dim tiempo As Double
            Dim rTiempo As String

            If Second > 0 Then

                speed = Current / Second

                tiempo = (Total - Current) / speed

                Try
                    rTiempo = TimeSpan.FromSeconds(tiempo).ToString
                Catch ex As Exception
                    rTiempo = "Esperando...."
                End Try

                If rTiempo.Contains(".") Then
                    Dim rx As Integer = rTiempo.LastIndexOf(".")
                    rTiempo = rTiempo.Remove(rx)
                End If

                Label2.Text = calcularTamano(Current).ToString
                Label3.Text = calcularTamano(Total - Current)
                Label5.Text = calcularVelocidad(speed)
                Label7.Text = rTiempo

            End If

            Panel1.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If Label11.Text.Length > 60 Then
            Label11.Text = Label11.Text.Remove(60) & "..."
        End If
    End Sub

    Dim lPercent As Integer = -1
    Dim UseColor As Color

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

        CircularDraw(sender, CType(sender, Panel).Size, e, percent, 10, UseColor)

        lPercent = percent

        If Not UseColor = Color.DodgerBlue Then
            CircularDraw(sender, CType(sender, Panel).Size, e, lPercent, 10, UseColor)
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Second += 1

    End Sub

End Class
