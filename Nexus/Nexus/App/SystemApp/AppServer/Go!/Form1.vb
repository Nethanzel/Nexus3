
Imports System.IO
Imports System.Threading
Imports System.Net.Sockets

Public Class Form1

    Dim Listener As New TcpListener(2000)
    Dim client As TcpClient
    Dim message As String

   
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Listener.Stop()
    End Sub

    Sub Send_Command(ByVal Receptor As String, ByVal Command As String)

        Dim Loaded As Boolean = False
        Dim UsePort As Integer = Nothing
        Dim All As String = "N:\Nexus\AppWork\NxTaskBar\AppConfig"

        For Each Carpt As String In IO.Directory.GetDirectories(All)
            Dim InfoCarpt As New IO.DirectoryInfo(Carpt)

            If InfoCarpt.Name = Receptor Then
                Dim Stt As String = IO.File.ReadAllText(Carpt & "/Ld")

                If Not Stt = "False" Then

                    UsePort = CInt(IO.File.ReadAllText(Carpt & "/Prt"))
                    Loaded = True

                End If

            End If

        Next


        Try
            If Loaded = True Then

                client = New TcpClient("localhost", UsePort)
                Dim streamw As New StreamWriter(client.GetStream())
                streamw.Write(Command)
                TextBox1.AppendText(" ---->> Envio de comando a " & Receptor & " (" & UsePort & "):" & vbNewLine & "  " & "A las: " & TimeOfDay & vbNewLine & "     " & Command & vbNewLine & vbNewLine)
                streamw.Flush()


            Else

                TextBox1.AppendText(" ---->> El receptor no puede recibir el comando." & vbNewLine & vbNewLine)

            End If

        Catch ex As Exception

            TextBox1.AppendText(" ---->> El receptor no puede o se nego a recibir el comando." & vbNewLine)


            TextBox1.AppendText(" ----► La conexion con " & Receptor & " se ha perdido." & vbCrLf & vbCrLf)

        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If fLoad = True Then
            Loader()
            fLoad = False
        End If

        Listener.Start()

        If Listener.Pending = True Then
            message = ""
            client = Listener.AcceptTcpClient

            Dim streamr As New StreamReader(client.GetStream())

            While streamr.Peek > -1
                message = message + Convert.ToChar(streamr.Read()).ToString
            End While

            Dim index As Integer = message.IndexOf("|")
            Dim tIndex As Integer = message.LastIndexOf(";")
            Dim cmd As String = message.Substring(index + 1)
            Dim cIndex = cmd.LastIndexOf(";")
            cmd = cmd.Remove(cIndex)
            Dim Recp As String = message.Remove(index)
            Dim tipo As String = message.Substring(tIndex + 1)


            If tipo.ToLower = "w" Then
                TextBox1.AppendText(" <<---- Solicitud de comunicacion pasiva: " & vbNewLine & "  " & "A las: " & TimeOfDay & vbNewLine & "     " & Recp & "(" & cmd & ")" & vbNewLine & vbNewLine)
                Write_CMD(Recp, cmd)

            ElseIf tipo.ToLower = "shutdown" Then
                TextBox1.AppendText(" ----->> Solicitud para apagado del sistema." & vbNewLine)
                ShutDown()

            ElseIf tipo.ToLower = "break" Then
                TextBox1.AppendText(" ----->> Solicitud para bloquear sesion del sistema." & vbNewLine)
                Break()
            Else
                TextBox1.AppendText(" <<---- Solicitud de comunicacion: " & vbNewLine & "  " & "A las: " & TimeOfDay & vbNewLine & "     " & Recp & "(" & cmd & ")" & vbNewLine & vbNewLine)
                Send_Command(Recp, cmd)

            End If

            Me.TopMost = True
        End If

    End Sub

    Sub Write_CMD(ByVal Receptor As String, ByVal CMD As String)

        If CMD = "S" And Me.Visible = False Then

            Dim cUser As String = IO.File.ReadAllText("N:\Nexus\AppWork\Settings\CrrntUser\Name")
            SystmColor = Color.FromArgb(CInt(IO.File.ReadAllText("N:\Users\" & cUser & "\Configs\SysColr")))

            Me.WindowState = FormWindowState.Normal
            Me.Show()
            Me.Focus()
            Load_Me("AppServer", PictureBox1.Image, ListenNumber)
            TextBox1.AppendText(" ---->> Mostrar interfaz, ejecutado desde linea de comandos." & vbNewLine)

            Exit Sub

        ElseIf CMD = "H" Then

            Close_Me("AppServer")
            Me.Hide()
            TextBox1.AppendText(" ---->> Ocultar interfaz, ejecutado desde linea de comandos." & vbNewLine)
            Exit Sub

        End If


        Dim All As String = "N:\Nexus\AppWork\NxTaskBar\AppConfig"

        For Each Carpt As String In IO.Directory.GetDirectories(All)
            Dim InfoCarpt As New IO.DirectoryInfo(Carpt)

            If InfoCarpt.Name = Receptor Then

                Dim Stt As String = IO.File.ReadAllText(Carpt & "/Ld")

                If Not Stt = "False" Then
                    IO.File.WriteAllText(Carpt & "/CMD", CMD)
                    TextBox1.AppendText(" ---->> Comando entregado." & vbNewLine)
                    Exit Sub
                End If

                TextBox1.AppendText(" ---->> Comando no entregado." & vbNewLine)
                Exit Sub

            End If

        Next

        TextBox1.AppendText(" ---->> Espacio de mandos del receptor no encontrado." & vbNewLine)

    End Sub



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
   
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Close_Me("AppServer")
        Me.Hide()
    End Sub

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel2.BackColor = Color.DarkGray

    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor
        Panel2.BackColor = SystmColor

    End Sub

    Dim fLoad As Boolean = True

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Loader()
        Listener.Start()


    End Sub

    Sub Loader()
        My.Application.ApplicationContext.MainForm.Hide()
        Me.Opacity = 100%
    End Sub


    Sub ShutDown()

        Dim All As String = "N:\Nexus\AppWork\NxTaskBar\AppConfig"

        For Each Carpt As String In IO.Directory.GetDirectories(All)

                Dim Stt As String = IO.File.ReadAllText(Carpt & "/Ld")

            If Not Stt = "False" Then

                IO.File.WriteAllText(Carpt & "/CMD", "0")

            End If
        Next


        TextBox1.AppendText(" ---->> Finalizando..." & vbNewLine)

        App_Break(1000)

        Me.Close()

    End Sub


    Sub Break()

        Dim All As String = "N:\Nexus\AppWork\NxTaskBar\AppConfig"

        For Each Carpt As String In IO.Directory.GetDirectories(All)

            Dim Stt As String = IO.File.ReadAllText(Carpt & "/Ld")

            If Not Stt = "False" Then

                If Carpt.EndsWith("ScreenCap") Then
                    IO.File.WriteAllText(Carpt & "/CMD", "5")

                Else
                    IO.File.WriteAllText(Carpt & "/CMD", "2")

                End If
            End If
        Next


        TextBox1.AppendText(" ---->> Ocultar interfaz." & vbNewLine)
        App_Break(1000)

        Close_Me("AppServer")
        Me.Hide()

    End Sub
End Class
