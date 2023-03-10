Imports System.Net.Sockets
Imports System.IO

Module Load_App


    Public ListenNumber As Integer = 1950

    Dim G_AppName As String
    Dim TaskBarDir As String = "N:\Nexus\AppWork\NxTaskBar\AppConfig"

    Sub Load_Me(ByVal AppName As String, ByVal AppIcon As Image, ByVal CPort As Integer)

        Port.Interval = 10
        G_AppName = AppName
        Port.Enabled = True

        Dim Number_ As Integer = Val(IO.File.ReadAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount"))

        Try

            If IO.Directory.Exists(TaskBarDir & "/" & AppName) = True Then

                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(Number_ + 1))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Prt", CStr(CPort))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/CMD", "")
                AppIcon.Save(TaskBarDir & "/" & AppName & "/Icon.png")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "True")
            Else
                IO.Directory.CreateDirectory(TaskBarDir & "/" & AppName)
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Nmbr", CStr(Number_ + 1))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Prt", CStr(CPort))
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/CMD", "")
                AppIcon.Save(TaskBarDir & "/" & AppName & "/Icon.png")
                IO.File.WriteAllText(TaskBarDir & "/" & AppName & "/Ld", "True")
            End If

        Catch ex As Exception

        End Try

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount", Number_ + 1)


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

        If Line.StartsWith("+") Then



        End If

    End Sub

    Sub Close_Me(ByVal AppName As String)

        Dim Cont As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount")

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

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount", Val(Cont - 1))

    End Sub

   

    Sub Speak(ByVal Owner As String, ByVal CMD As String, ByVal tipe As String)

        client = New TcpClient("localhost", 2000)
        Dim streamw As New StreamWriter(client.GetStream())
        streamw.Write(Owner & "|" & CMD & ";" & tipe)
        streamw.Flush()

    End Sub
    
End Module