Imports System.Drawing.Drawing2D

Public Class Form1


    Private WithEvents SpeechEngine As New System.Speech.Recognition.SpeechRecognitionEngine(System.Globalization.CultureInfo.GetCultureInfo("es-ES"))

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Vero\IsRun", "False")
        SpeechEngine.RecognizeAsyncCancel()
        SpeechEngine.Dispose()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Vero\IsRun", "True")

        Form2.Show()

        SpeechEngine.LoadGrammar(New System.Speech.Recognition.DictationGrammar)
        SpeechEngine.SetInputToDefaultAudioDevice()
        SpeechEngine.RecognizeAsync(Speech.Recognition.RecognizeMode.Multiple)

    End Sub

    Private Sub SpeechEngine_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles SpeechEngine.SpeechRecognized

        Timer1.Stop()
        Label1.Text = "Espera..."

        Panel1.BackColor = Color.WhiteSmoke

        Dim Wait As Integer = (e.Result.Audio.Duration.TotalSeconds) * 1000

        Get_Response(e.Result.Text.ToLower)

        App_Break(Wait)

        Label1.Text = "Dime algo..."
        Timer1.Start()

    End Sub


    Dim ParamR As Integer = 5
    Dim paramG As Integer = 5
    Dim paramB As Integer = 5
    Dim x As Integer() = {50, 150, 125}

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If x(0) >= 255 Then
            ParamR = -5
        ElseIf x(0) <= 0 Then
            ParamR = 5
        End If


        If x(1) >= 255 Then
            paramG = -5
        ElseIf x(1) <= 0 Then
            paramG = 5
        End If


        If x(2) >= 255 Then
            paramB = -5
        ElseIf x(2) <= 0 Then
            paramB = 5
        End If


        x.SetValue(CInt(x(0) + (ParamR)), 0)
        x.SetValue(CInt(x(1) + (paramG)), 1)
        x.SetValue(CInt(x(2)), 2)

        Dim nColor As New Color

        nColor = Color.FromArgb(x(0), x(1), x(2))

        Panel1.BackColor = nColor

        Label1.Left = (Me.Width / 2) - (Label1.Width / 2)


    End Sub



    Sub CircleImg(ByVal Panel As Windows.Forms.Panel, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim figura As GraphicsPath = New GraphicsPath
        Dim x, y, ancho, alto As Integer

        ancho = Panel.Width
        alto = Panel.Height

        x = (Panel.Width - ancho) / 2
        y = (Panel.Height - alto) / 2

        figura.AddEllipse(New Rectangle(x + 3, y + 2, ancho - 8, alto - 5))

        Panel.Region = New Region(figura)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        CircleImg(Panel1, e)
    End Sub

    
End Class
