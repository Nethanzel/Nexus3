Public Class MainWindow

    Dim Loading As Integer = -1

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Tb = 100 Then
            Cursor.Hide()
            Timer1.Stop()

            ' Timer4.Start()
            Timer5.Start()
            Settings_BeforeIp()
        Else
            Tb = Tb + 5
            Me.Opacity = Tb / 100

        End If

    End Sub

    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Location = New Drawing.Point((Me.Width / 2) - (Panel1.Width / 2), (Me.Height / 2) - (Panel1.Height / 2))

        TextBox2.Left = Panel1.Left
        TextBox2.Top = (Panel1.Top + Panel1.Height) + 5
       
        Timer1.Start()

    End Sub


    Dim Tb As Integer = 0

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        If Tb = 0 Then
            
            Me.Hide()
        Else
            Tb = Tb - 5
            Me.Opacity = Tb / 100

        End If


    End Sub

    Dim ParamR As Integer = 5
    Dim paramG As Integer = 5
    Dim paramB As Integer = 5
    Dim x As Integer() = {60, 160, 200}

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

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

    End Sub

    Dim StepMarkUp As Integer = 0
    Dim Dead As Boolean = False
    Dim k As Integer = 0

    Private Sub Settings_BeforeIp()

        App_Break(1000)

        ConsoleContains = vbNewLine & "Iniciando..."

        App_Break(1500)


        Dim Ref As String = "-"

        Do While Dead = False
            k = k + 1

            kill_()
            App_Break(500)
            kill_()

            App_Break(1000)

            ConsoleContains = "Confirmando..." & vbNewLine & vbNewLine & ConsoleContains

            App_Break(3000)

            For Each procc As Process In Process.GetProcesses
                If procc.ProcessName = "explorer" Then
                    ConsoleContains = "No se pudo cerrar 'explorer.exe'" & vbNewLine & ConsoleContains
                    Ref = "+"
                    Exit For
                Else
                    Ref = "-"
                End If
            Next


            If Ref = "-" Then

                ConsoleContains = "> Proceso finalizado." & vbNewLine & vbNewLine & vbNewLine & ConsoleContains
                ConsoleContains = "-------------------------------------------------------------------------------" & vbNewLine & ConsoleContains
                Dead = True
            End If

        Loop

        App_Break(1000)

        Dim Up As Boolean = False
        Dim z As Integer = 0
        Dim q As Boolean = False

        Do While Up = False
            z = z + 1

            If z = 1 Then
                If q = False Then
                    ConsoleContains = "Borrando valores de los archivos de sistema" & vbNewLine & vbNewLine & ConsoleContains
                    App_Break(500)
                Else
                    ConsoleContains = ConsoleContains.Remove(0, 50)
                    ConsoleContains = "Borrando valores de los archivos de sistema" & vbNewLine & vbNewLine & ConsoleContains
                    App_Break(500)
                End If
            ElseIf z = 2 Then
                ConsoleContains = ConsoleContains.Remove(0, 47)
                ConsoleContains = "Borrando valores de los archivos de sistema." & vbNewLine & vbNewLine & ConsoleContains
                App_Break(500)
            ElseIf z = 3 Then
                ConsoleContains = ConsoleContains.Remove(0, 48)
                ConsoleContains = "Borrando valores de los archivos de sistema.." & vbNewLine & vbNewLine & ConsoleContains
                App_Break(500)
            ElseIf z = 4 Then
                ConsoleContains = ConsoleContains.Remove(0, 49)
                ConsoleContains = "Borrando valores de los archivos de sistema..." & vbNewLine & vbNewLine & ConsoleContains
                App_Break(500)
                z = 0

                If q = True Then
                    Exit Do
                End If

                q = True
            End If

        Loop


        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount", "0")
        IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Clock\IsRun", "False")
        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", "0")
        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\$Network-%", "False")
        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\-RelojVs", "False")
        IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Vero\IsRun", "False")
        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Btr", "False")

        App_Break(1000)

        ConsoleContains = "-------------------------------------------------------------------------------" & vbNewLine & ConsoleContains


        'AppTualice()

        Timer5.Stop()

        ConsoleContains = "> Inicializacion completada." & vbNewLine & vbNewLine & ConsoleContains

        App_Break(2000)




        Me.Controls.Remove(TextBox1)

        'ToWhat_I_Do = 6
        'Telon.Show()

        Me.Panel1.Visible = True
        Me.TextBox2.Visible = True
        Me.Timer4.Start()

    End Sub



    'Dim appList As New List(Of String)

    'Sub AppTualice()



    '    ConsoleContains = "> Buscando actualizaciones de aplicaciones..." & vbNewLine & vbNewLine & ConsoleContains

    '    App_Break(2000)


    '    '--Se listan todas las aplicaciones


    '    For Each iDir As String In IO.Directory.GetDirectories(AppDir)

    '        Dim Cell As New IO.DirectoryInfo(iDir)

    '        appList.Add(iDir & "\" & Cell.Name & "\bin\Debug\" & Cell.Name & ".exe")

    '    Next

    '    '--Se determina si el ejecutable no esta actualizado

    '    For Each exe As String In appList 'Aplicaciones en Dev folder

    '        Dim x As New IO.FileInfo(exe)

    '        For Each ExtExe As String In IO.Directory.GetFiles(ExeDir) ' Ejecutables existentes

    '            Dim exeInfo As New IO.FileInfo(ExtExe)

    '            If exeInfo.Name = x.Name And Not exeInfo.CreationTime <> x.CreationTime Then 'Determinar si las fechas de creacion son diferentes

    '                appList.Remove(exe)
    '            End If

    '        Next
    '    Next

    '    '--Se calcula el peso total de las aplicaciones que necesitan ser copiadas de nuevo
    '    Dim TotalWeight As Double = 0

    '    For Each It As String In appList

    '        Dim x As New IO.FileInfo(It)
    '        ' IO.File.WriteAllText(ExeDir & "\" & x.Name & ".exe", "")
    '        TotalWeight = TotalWeight + x.Length
    '    Next


    '    ConsoleContains = " Total de aplicaciones: " & appList.Count & " (" & calcularTamano(TotalWeight) & "). Actualizando..." & vbNewLine & vbNewLine & ConsoleContains

    '    App_Break(1000)

    '    '  Iniciar copia de Ejecutables


    '    Runnig = True
    '    Dim ft As Boolean = False

    '    Do While Runnig = True

    '        'MsgBox("")

    '        Dim PrintProgress As String = ""

    '        '               cada barra representa 5 %

    '        If ft = True Then
    '            ConsoleContains = ConsoleContains.Remove(0, 65)
    '        Else
    '            Engine()
    '            ft = True
    '        End If

    '        If Progress < 9 Then

    '            PrintProgress = "0" & Progress
    '            ConsoleContains = " Progreso de la actualizacion: <" & GettxtBarProgress(Progress) & "> - " & PrintProgress & " %" & vbNewLine & vbNewLine & ConsoleContains
    '            '  Application.DoEvents()

    '        ElseIf Progress > 9 Then

    '            PrintProgress = Progress
    '            ConsoleContains = " Progreso de la actualizacion: <" & GettxtBarProgress(Progress) & "> - " & PrintProgress & " %" & vbNewLine & vbNewLine & ConsoleContains


    '            'ElseIf Progress = 100 Then

    '            'PrintProgress = "99"
    '            'ConsoleContains = " Progreso de la actualizacion: <" & GettxtBarProgress(Progress) & "> - " & PrintProgress & " %" & vbNewLine & vbNewLine & ConsoleContains
    '            'Application.DoEvents()

    '        End If


    '        Application.DoEvents()
    '    Loop

    '    ConsoleContains = "-------------------------------------------------------------------------------" & vbNewLine & ConsoleContains

    '    App_Break(1500)

    'End Sub

    'Private Function GettxtBarProgress(ByVal Percent As Integer) As String

    '    Dim Resp As String = ""


    '    If Percent > 99 Then
    '        Resp = "\\\\\\\\\\\\\\\\\\\\"

    '    ElseIf Percent > 94 Then
    '        Resp = "\\\\\\\\\\\\\\\\\\\-"

    '    ElseIf Percent > 89 Then
    '        Resp = "\\\\\\\\\\\\\\\\\\--"

    '    ElseIf Percent > 84 Then
    '        Resp = "\\\\\\\\\\\\\\\\\---"

    '    ElseIf Percent > 79 Then
    '        Resp = "\\\\\\\\\\\\\\\\----"

    '    ElseIf Percent > 74 Then
    '        Resp = "\\\\\\\\\\\\\\\-----"

    '    ElseIf Percent > 69 Then
    '        Resp = "\\\\\\\\\\\\\\------"

    '    ElseIf Percent > 64 Then
    '        Resp = "\\\\\\\\\\\\\-------"

    '    ElseIf Percent > 59 Then
    '        Resp = "\\\\\\\\\\\\--------"

    '    ElseIf Percent > 54 Then
    '        Resp = "\\\\\\\\\\\---------"

    '    ElseIf Percent > 49 Then
    '        Resp = "\\\\\\\\\\----------"

    '    ElseIf Percent > 44 Then
    '        Resp = "\\\\\\\\\-----------"

    '    ElseIf Percent > 39 Then
    '        Resp = "\\\\\\\\------------"

    '    ElseIf Percent > 34 Then
    '        Resp = "\\\\\\\-------------"

    '    ElseIf Percent > 29 Then
    '        Resp = "\\\\\\--------------"

    '    ElseIf Percent > 24 Then
    '        Resp = "\\\\\---------------"

    '    ElseIf Percent > 19 Then
    '        Resp = "\\\\----------------"

    '    ElseIf Percent > 14 Then
    '        Resp = "\\\-----------------"

    '    ElseIf Percent > 9 Then
    '        Resp = "\\------------------"

    '    ElseIf Percent > 4 Then
    '        Resp = "\-------------------"

    '    Else
    '        Resp = "--------------------"
    '    End If


    '    Return Resp

    'End Function

    Sub kill_()

        Try

            For Each App As Process In Process.GetProcesses

                If App.ProcessName = "explorer" Then

                    ConsoleContains = "Cerrando 'explorer.exe'..." & vbNewLine & vbNewLine & ConsoleContains

                    App.Kill()

                End If
            Next

            ConsoleContains = "> 'explorer.exe' cerrado despues de " & k & " intentos." & vbNewLine & ConsoleContains

        Catch ex As Exception
            ConsoleContains = ex.Message & vbNewLine & ConsoleContains
        End Try

    End Sub


    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        TextBox1.Text = ConsoleContains
    End Sub


    Dim MiniStepMark As Integer = 0
    Dim MiniConsole As String = ""

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick

        MiniStepMark = MiniStepMark + 1

        If MiniStepMark = 1 Then
            Me.Timer3.Start()

            Timer1.Stop()
            Timer2.Stop()
            Timer5.Stop()

        End If

        If MiniStepMark = 5 Then
            TextBox2.Text = "Iniciando aplicaciones servidor..."
        End If

        If MiniStepMark = 8 Then
            MiniConsole = TextBox2.Text
            TextBox2.Clear()

            TextBox2.Text = "> Iniciando servidor para 'fecha y hora del sistema'..." & vbNewLine & vbNewLine & MiniConsole
            Process.Start("N:\Nexus\App\DedicateApp\NxReloj\NxReloj\bin\Debug\NxReloj.exe")

        End If

        If MiniStepMark = 11 Then
            
            MiniConsole = TextBox2.Text
            TextBox2.Clear()

            TextBox2.Text = "> Iniciando servidor para 'estado de conexion'..." & vbNewLine & vbNewLine & MiniConsole
            Process.Start("N:\Nexus\App\DedicateApp\WebService\WebService\bin\Debug\WebService.exe")

        End If

        If MiniStepMark = 14 Then

            MiniConsole = TextBox2.Text
            TextBox2.Clear()

            TextBox2.Text = "> Iniciando servidor para 'comunicacion entre aplicaciones'..." & vbNewLine & vbNewLine & MiniConsole
            Process.Start("N:\Nexus\App\SystemApp\AppServer\Go!\bin\Debug\AppServer.exe")

        End If


        If MiniStepMark = 17 Then

            MiniConsole = TextBox2.Text
            TextBox2.Clear()

            TextBox2.Text = "> Iniciando aplicacion para 'notificaciones del sistema'..." & vbNewLine & vbNewLine & MiniConsole
            Process.Start("N:\Nexus\App\SystemApp\NotifierSystem\NotifierSystem\bin\Debug\NotifierSystem.exe")
        End If


        If MiniStepMark = 20 Then
            MiniConsole = TextBox2.Text
            TextBox2.Clear()

            TextBox2.Text = "> Iniciando 'Monitor de bateria'..." & vbNewLine & vbNewLine & MiniConsole
            Process.Start("N:\Nexus\App\DedicateApp\BateryChecking\BateryChecking\bin\Debug\BateryChecking.exe")

        End If


        If MiniStepMark = 23 Then

            MiniConsole = TextBox2.Text
            TextBox2.Clear()

            TextBox2.Text = "> Iniciando aplicacion para 'captura de pantalla'..." & vbNewLine & vbNewLine & MiniConsole
            Process.Start("N:\Nexus\App\SystemApp\ScreenCap\ScreenCap\bin\Debug\ScreenCap.exe")


            Timer1.Stop()
            Timer2.Stop()
            Timer5.Stop()


        End If

        If MiniStepMark = 26 Then

            Timer4.Stop()
            ToWhat_I_Do = 7
            Telon.Show()
        End If

    End Sub



#Region "CopyFile Async"

    'Dim CrntName As String
    'Dim TotalLenght As Long

    'Dim Max As Long
    'Dim PreAdvance As Long
    'Dim AntProgress As Long

    'Dim Progress As Integer

    'Dim pbOnceFile As New ProgressBar

    'Sub xCopyFile(ByVal Source As String, ByVal Destination As String)
    '    Try

    '        Dim sr As New IO.FileStream(Source, IO.FileMode.Open)
    '        Dim sw As New IO.FileStream(Destination, IO.FileMode.Create)

    '        Dim len As Long = sr.Length - 1
    '        Dim buffer(2048) As Byte
    '        Dim bytesread As Integer

    '        While sr.Position < len
    '            bytesread = (sr.Read(buffer, 0, 1024))
    '            sw.Write(buffer, 0, bytesread)
    '            Progress = CInt((sr.Position / len) * pbOnceFile.Maximum)

    '            Try
    '                Dim Pos As Long = sr.Position

    '                PreAdvance = (Pos - AntProgress)

    '                If CrntName.Length > 50 Then
    '                    CrntName = CrntName.Remove(50) & "..."
    '                End If

    '                'Estatus = "Nombre: " & CrntName & vbNewLine & "Copiado: " & CStr(calcularTamano(Pos)) & " de " & CStr(calcularTamano(len)) & vbNewLine & "Velocidad: " & calcularTamano(sr.Position / cTime) & "/s"

    '                If Not PreAdvance < 0 Then
    '                    Max -= PreAdvance
    '                End If

    '                AntProgress = Pos

    '            Catch ex As Exception

    '            End Try

    '            Application.DoEvents()

    '        End While

    '        sw.Flush()
    '        sw.Close()
    '        sr.Close()


    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Dim Runnig As Boolean = False

    'Sub Engine()

    '    TotalLenght = 0
    '    Max = 0

    '    For i As Integer = 0 To appList.Count - 1
    '        Dim finfo As New IO.FileInfo(appList.Item(i))
    '        TotalLenght = TotalLenght + finfo.Length
    '        Max = TotalLenght
    '    Next

    '    For obj As Integer = 0 To appList.Count - 1

    '        Dim finfo As New IO.FileInfo(appList.Item(obj))
    '        CrntName = finfo.Name
    '        'cTime = 0
    '        xCopyFile(appList.Item(obj), ExeDir & "\" & CrntName)

    '        Application.DoEvents()
    '        App_Break(500)


    '    Next

    '    ' Me.Close()
    '    Runnig = False
    '    appList.Clear()

    'End Sub

#End Region




End Class