Imports System.Net.Sockets
Imports System.IO

Module Load_App

    Public ListenNumber As Integer = 1901
    Dim G_AppName As String
    Dim TaskBarDir As String = "N:\Nexus\AppWork\NxTaskBar\AppConfig"

    Sub Load_Me(ByVal AppName As String, ByVal AppIcon As Image, ByVal CPort As Integer)

        Port.Interval = 10
        G_AppName = AppName

        Try

            If IO.Directory.Exists(TaskBarDir & "/" & AppName) = True Then

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Prt", CStr(CPort))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "Wait")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/CMD", "")
                AppIcon.Save(TaskBarDir & "/" & AppName & "/Icon.png")

            Else
                IO.Directory.CreateDirectory(TaskBarDir & "/" & AppName)
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Prt", CStr(CPort))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "Wait")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/CMD", "")
                AppIcon.Save(TaskBarDir & "/" & AppName & "/Icon.png")

            End If

        Catch ex As Exception

        End Try

        Port.Enabled = True

    End Sub

    Dim WithEvents Port As New Timer

    Private Sub ListenPort(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Port.Tick

        Dim VisState As String = ""

        Try
            VisState = IO.File.ReadAllText(TaskBarDir & "/" & G_AppName & "/CMD")
        Catch ex As Exception

        End Try

        ListenPort()

        If VisState = "0" Then
            My.Application.ApplicationContext.MainForm.Close()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")

        ElseIf VisState = "1" Then
            My.Application.ApplicationContext.MainForm.Show()
            My.Application.ApplicationContext.MainForm.Focus()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")

        ElseIf VisState = "2" Then
            My.Application.ApplicationContext.MainForm.Hide()
            IO.File.WriteAllText(TaskBarDir & "/" & G_AppName & "/CMD", "")

        ElseIf VisState = "+" Then
            SlideMenu.Opacity = 100%
            Form1.T2.Stop()
            Form1.T1.Start()

        ElseIf VisState = "-" Then
            Form1.T1.Stop()
            Form1.T2.Start()

        ElseIf VisState = "*" Then
            SlideMenu.Panel1.Controls.Clear()

        End If

    End Sub

    Dim localhost As Net.IPAddress = Net.Dns.GetHostEntry("localhost").AddressList(1)
    Dim Listener As New TcpListener(localhost, ListenNumber)
    Dim client As TcpClient
    Dim message As String

    Sub ListenPort()

        Try

            Listener.Start()

            If Listener.Pending = True Then
                message = ""
                client = Listener.AcceptTcpClient
                Dim streamr As New StreamReader(client.GetStream())
                While streamr.Peek > -1
                    message = message + Convert.ToChar(streamr.Read()).ToString
                End While
                CMD(message)

            End If


        Catch ex As Exception

        End Try

    End Sub


    Sub CMD(ByVal Line As String)
        Form1.Focus()
        Try

            Dim MinusIndex As Integer = Line.IndexOf("-")
            Dim ImgRt As String = Line.Remove(MinusIndex)

            Dim AppTtl As String = Line.Substring(MinusIndex + 1)
            Dim PlusIndex As Integer = AppTtl.IndexOf("+")
            AppTtl = AppTtl.Remove(PlusIndex)

            Dim PlsIndex As Integer = Line.IndexOf("+")
            Dim TitleTxt As String = Line.Substring(PlsIndex + 1)
            Dim Exponent As Integer = TitleTxt.LastIndexOf("^")
            TitleTxt = TitleTxt.Remove(Exponent)

            Dim Expnnt As Integer = Line.IndexOf("^")
            Dim Detailss As String = Line.Substring(Expnnt + 1)

            If AppTtl.ToLower = "nxplayer" Then

                AddNotify2(ImgRt, TitleTxt, AppTtl, Detailss, Form1.Paneles, "", False)
                My.Computer.Audio.Play("N:\Nexus\Resourses\BlopMark.wav", AudioPlayMode.Background)

            Else
                AddNotify2(ImgRt, TitleTxt, AppTtl, Detailss, Form1.Paneles, "", True)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try





    End Sub


    Sub Close_Me(ByVal AppName As String)

       
        Try

            If IO.Directory.Exists(TaskBarDir & "/" & AppName) = True Then

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(0))

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "False")


            Else
                IO.Directory.CreateDirectory(TaskBarDir & "/" & AppName)

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(0))

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "False")


            End If

        Catch ex As Exception

        End Try



    End Sub

    Sub Speak(ByVal Owner As String, ByVal CMD As String, ByVal tipe As String)

        client = New TcpClient("localhost", 2000)
        Dim streamw As New StreamWriter(client.GetStream())
        streamw.Write(Owner & "|" & CMD & ";" & tipe)
        streamw.Flush()

    End Sub
    
End Module