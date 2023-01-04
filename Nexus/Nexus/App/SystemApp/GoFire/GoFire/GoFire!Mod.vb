Imports System.Net
Imports System.IO
Imports System.Net.Sockets

Module GoFire_Mod

    Dim ModFire As Boolean
    Public ConsoleContains As String

    Sub GoFire(ByVal Screen As System.Object, ByVal Parent As Windows.Forms.Form, ByVal Input As System.Object)

        Dim TextBox1 As TextBox = CType(Screen, TextBox)
        Dim TextBox2 As TextBox = CType(Input, TextBox)

        ConsoleContains = TextBox1.Text

        Dim CaracterBuscado As String = ";"
        Dim CharF As String = vbNewLine
        Dim Result As String = ""

        For Each CharF In TextBox1.Text

            If CharF = CaracterBuscado Then

                Result = Result & CharF

                If Result.ToLower = "nexus start;" Then

                    TextBox1.Clear()
                    TextBox1.Text += "         ------------------------------------------------------         "
                    TextBox1.Text += "       >> Comando reconocido!"
                    TextBox1.Text += vbNewLine & vbNewLine
                    TextBox1.Text += ConsoleContains

                ElseIf CBool(Result.ToLower.StartsWith("dirview") And Result.EndsWith(";")) = True Then
                    Try

                        Dim Indx As Integer = Result.IndexOf("'")
                        Dim Dirc As String = Result.Substring(Indx)
                        Dirc = Dirc.Replace("'", "")
                        Dirc = Dirc.Replace(";", "")

                        If SendMessageFiles(Dirc) = True Then
                            TextBox1.Clear()
                            TextBox1.Text += "         ------------------------------------------------------         "
                            TextBox1.Text += "        >> Directorio mostrado: '" & Dirc & "'"
                            TextBox1.Text += vbNewLine & vbNewLine
                            TextBox1.Text += ConsoleContains
                        Else

                            TextBox1.Clear()
                            TextBox1.Text += "         ------------------------------------------------------         "
                            TextBox1.Text += "        >> Err: Problemas de comunicacion..."
                            TextBox1.Text += vbNewLine & vbNewLine
                            TextBox1.Text += ConsoleContains

                        End If


                    Catch ex As Exception
                        TextBox1.Clear()
                        TextBox1.Text += "         ------------------------------------------------------         "
                        TextBox1.Text += "          >> Comando no reconocido!"
                        TextBox1.Text += vbNewLine & vbNewLine
                        TextBox1.Text += ConsoleContains
                    End Try

                ElseIf Result.ToLower = "network;" Then

                    TextBox1.Clear()
                    TextBox1.Text += "         ------------------------------------------------------         "
                    TextBox1.Text += "       >> Direccion local de host: " & GetMe_IP()
                    TextBox1.Text += vbNewLine & vbNewLine
                    TextBox1.Text += ConsoleContains

                ElseIf Result.ToLower = "firemod=true;" Then
                    ModFire = True
                    TextBox1.BackColor = Color.Black
                    TextBox1.ForeColor = Color.White
                    TextBox2.BackColor = Color.Black
                    TextBox2.ForeColor = Color.White

                    TextBox1.Clear()
                    TextBox1.Text += "         ------------------------------------------------------         "
                    TextBox1.Text += "        >> Modo Fuego activado..."
                    TextBox1.Text += vbNewLine & vbNewLine
                    TextBox1.Text += ConsoleContains

                ElseIf Result.ToLower = "firemod=false;" Then
                    ModFire = False

                    TextBox1.BackColor = Color.FromName("Control")
                    TextBox1.ForeColor = Color.Black
                    TextBox2.BackColor = Color.FromName("MenuBar")
                    TextBox2.ForeColor = Color.Black

                    TextBox1.Clear()
                    TextBox1.Text += "         ------------------------------------------------------         "
                    TextBox1.Text += "        >> Modo Fuego desacivado..."
                    TextBox1.Text += vbNewLine & vbNewLine
                    TextBox1.Text += ConsoleContains

                ElseIf Result.ToLower = "end;" Then

                    TextBox1.Clear()
                    TextBox1.Text += "         ------------------------------------------------------         "
                    TextBox1.Text += "        >> Cerrando..."
                    TextBox1.Text += vbNewLine & vbNewLine
                    TextBox1.Text += ConsoleContains

                    App_Break(1500)

                    If Form1.maximised = True Then

                        Form1.NotMaximiced()
                        Form1.maximised = False

                    End If

                    IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Gfire", "False")
                    'Close_Me("GoFire")

                    TextBox1.Clear()
                    Parent.Close()

                ElseIf CBool(Result.ToLower.StartsWith("appserver") And Result.EndsWith(";")) = True Then

                    If ModFire = True Then

                        If Result.Contains("=") Then
                            Dim Index As Integer = Result.IndexOf("=")
                            Dim X As String = Result.Substring(Index + 1)
                            X = X.Replace(";", "")

                            If X.ToLower = "true" Then

                                TextBox1.Clear()
                                TextBox1.Text += "                                                                        "
                                TextBox1.Text += "        >> Ejecutando..."
                                TextBox1.Text += vbNewLine & vbNewLine
                                TextBox1.Text += ConsoleContains
                                ConsoleContains = TextBox1.Text

                                App_Break(2000)
                                Dim xThread As New Threading.Thread(AddressOf ShowShell_AppServer)
                                xThread.Start()

                                TextBox1.Clear()
                                TextBox1.Text += "         ------------------------------------------------------         "
                                TextBox1.Text += "        >> Listo"
                                TextBox1.Text += vbNewLine
                                TextBox1.Text += ConsoleContains

                            ElseIf X.ToLower = "false" Then

                                TextBox1.Clear()
                                TextBox1.Text += "                                                                        "
                                TextBox1.Text += "        >> Ejecutando..."
                                TextBox1.Text += vbNewLine & vbNewLine
                                TextBox1.Text += ConsoleContains
                                ConsoleContains = TextBox1.Text

                                App_Break(1500)
                                Dim sThread As New Threading.Thread(AddressOf HideShell_AppServer)
                                sThread.Start()

                                TextBox1.Clear()
                                TextBox1.Text += "         ------------------------------------------------------         "
                                TextBox1.Text += "        >> Listo"
                                TextBox1.Text += vbNewLine
                                TextBox1.Text += ConsoleContains

                            Else

                                TextBox1.Clear()
                                TextBox1.Text += "         ------------------------------------------------------         "
                                TextBox1.Text += "        >> Parametros incorrectos!"
                                TextBox1.Text += vbNewLine & vbNewLine
                                TextBox1.Text += ConsoleContains
                            End If


                        Else
                            TextBox1.Clear()
                            TextBox1.Text += "         ------------------------------------------------------         "
                            TextBox1.Text += "        >> Parametros incorrectos!"
                            TextBox1.Text += vbNewLine & vbNewLine
                            TextBox1.Text += ConsoleContains
                        End If

                    Else

                        TextBox1.Clear()
                        TextBox1.Text += "         ------------------------------------------------------         "
                        TextBox1.Text += "        >> Para ejecutar este comando debe estar activo el modo fuego."
                        TextBox1.Text += vbNewLine & vbNewLine
                        TextBox1.Text += ConsoleContains

                    End If
                ElseIf CBool(Result.ToLower.StartsWith("logeditor") And Result.EndsWith(";")) = True Then

                    Dim Index As Integer = Result.IndexOf(".")
                    Dim X As String = Result.Substring(Index + 1)
                    X = X.Replace(";", "")

                    If ModFire = True Then

                        If X.ToLower = "run" Then
                            TextBox1.Clear()
                            TextBox1.Text += "                                                                        "
                            TextBox1.Text += "        >> Ejecutando editor de registros de aplicaciones..."
                            TextBox1.Text += vbNewLine & vbNewLine
                            TextBox1.Text += ConsoleContains
                            ConsoleContains = TextBox1.Text

                            Dim What As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxLogEditor\IsRun")

                            If What = "False" Then
                                App_Break(2000)
                                Process.Start("N:\Nexus\App\SystemApp\NxLogEditor\NxLogEditor\bin\Debug\NxLogEditor.exe")

                                TextBox1.Clear()
                                TextBox1.Text += "         ------------------------------------------------------         "
                                TextBox1.Text += "        >> Listo"
                                TextBox1.Text += vbNewLine
                                TextBox1.Text += ConsoleContains
                            Else
                                TextBox1.Clear()
                                TextBox1.Text += "         ------------------------------------------------------         "
                                TextBox1.Text += "        >> No se puede ejecutar el editor de registros de aplicaciones..."
                                TextBox1.Text += vbNewLine & vbNewLine
                                TextBox1.Text += ConsoleContains

                            End If

                        ElseIf X.ToLower = "stop" Then

                            TextBox1.Clear()
                            TextBox1.Text += "                                                                        "
                            TextBox1.Text += "        >> Forzando la detencion del editor de registros de aplicaciones..."
                            TextBox1.Text += vbNewLine & vbNewLine
                            TextBox1.Text += ConsoleContains
                            ConsoleContains = TextBox1.Text

                            For Each proceso As Process In Process.GetProcesses

                                If proceso.ProcessName = "NxLogEditor" Then

                                    Try
                                        App_Break(1500)
                                        IO.File.WriteAllText("N:\Nexus\AppWork\NxLogEditor\IsRun", "False")

                                        proceso.Kill()
                                        TextBox1.Clear()
                                        TextBox1.Text += "         ------------------------------------------------------         "
                                        TextBox1.Text += "        >> Proceso detenido..."
                                        TextBox1.Text += vbNewLine
                                        TextBox1.Text += ConsoleContains
                                        Exit Sub

                                    Catch ex As Exception
                                        Try
                                            App_Break(1500)
                                            IO.File.WriteAllText("N:\Nexus\AppWork\NxLogEditor\IsRun", "False")

                                            proceso.Kill()
                                            TextBox1.Clear()
                                            TextBox1.Text += "         ------------------------------------------------------         "
                                            TextBox1.Text += "        >> Proceso detenido..."
                                            TextBox1.Text += vbNewLine
                                            TextBox1.Text += ConsoleContains
                                            Exit Sub

                                        Catch h As Exception
                                            TextBox1.Clear()
                                            TextBox1.Text += "         ------------------------------------------------------         "
                                            TextBox1.Text += "        >> " & h.Message
                                            TextBox1.Text += vbNewLine & vbNewLine
                                            TextBox1.Text += ConsoleContains
                                            Exit Sub

                                        End Try
                                    End Try


                                End If

                            Next

                            App_Break(2000)
                            TextBox1.Clear()
                            TextBox1.Text += "         ------------------------------------------------------         "
                            TextBox1.Text += "        >> El proceso no se esta ejecutando..."
                            TextBox1.Text += vbNewLine
                            TextBox1.Text += ConsoleContains

                        Else
                            TextBox1.Clear()
                            TextBox1.Text += "         ------------------------------------------------------         "
                            TextBox1.Text += "        >> Parametros incorrectos!"
                            TextBox1.Text += vbNewLine & vbNewLine
                            TextBox1.Text += ConsoleContains
                        End If

                    Else

                        TextBox1.Clear()
                        TextBox1.Text += "         ------------------------------------------------------         "
                        TextBox1.Text += "        >> Para ejecutar este comando debe estar activo el modo fuego."
                        TextBox1.Text += vbNewLine & vbNewLine
                        TextBox1.Text += ConsoleContains

                    End If

                Else
                    TextBox1.Clear()
                    TextBox1.Text += "         ------------------------------------------------------         "
                    TextBox1.Text += "        >> Comando no reconocido!"
                    TextBox1.Text += vbNewLine & vbNewLine
                    TextBox1.Text += ConsoleContains

                End If

                Exit For
            Else
                Result = Result & CharF
            End If
        Next


        TextBox1.SelectionStart = 0


    End Sub


    Function GetMe_IP() As String

        Dim nombrePC As String
        Dim entradasIP As Net.IPHostEntry

        nombrePC = Dns.GetHostName

        entradasIP = Dns.GetHostByName(nombrePC)

        Dim direccion_Ip As String = entradasIP.AddressList(0).ToString

        Return direccion_Ip

    End Function

    Dim client As TcpClient

    Function SendMessageFiles(ByVal line As String) As Boolean

        Try
            client = New TcpClient("localhost", 2000)
            Dim streamw As New StreamWriter(client.GetStream())
            streamw.Write(line)

            streamw.Flush()
            Return True
        Catch ex As Exception

            Return False

        End Try

    End Function



    Sub ShowShell_AppServer()


        Speak("AppServer", "S", "W")


    End Sub

    Sub HideShell_AppServer()


        Speak("AppServer", "H", "W")


    End Sub

    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    Sub App_Break(ByVal Time As Integer)

        Dim retraso As Integer = Time
        retraso = retraso + GetTickCount

        While retraso >= GetTickCount
            Application.DoEvents()
        End While

    End Sub

End Module
