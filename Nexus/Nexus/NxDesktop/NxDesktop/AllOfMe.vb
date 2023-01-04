Imports System.Drawing.Drawing2D
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading

Module Module1

    Public SystmColor As Color ' color del sistema

    Public AppDir As String = "N:\Dev App"
    Public ExeDir As String = "N:\Nexus\App\ToolApp"

    Public VsRefer As Boolean = False ' indica si el notificador es visible


    Public UsersPath As String = "N:\Users" ' Ruta donde estan los registros de cada usuario
    Public AppWork As String = "N:\Nexus\AppWork" ' Ruta donde estan los registros de las aplicaciones

    Public ToWhat_I_Do As Integer ' Memoria para referencia de cambio de pantalla


    Public bGround As Image ' Imagen que se usara como fondo
    Public SvConfig As String 'Ruta para guardar registros de usuario actual

    Public ConsoleContains As String 'Contenido de la consola de inicio

    Public TimeAndDate As String 'Hora y fecha
    Public sSeconds As String 'Inidica si se muestran los segundos en el relog de la barra de tareas

    Public uClick_Str As String 'Referencia de usuario actual en formato string

    '---------User---------------------------------------
    Public UserName As String '= DesEncriptIt(IO.File.ReadAllText(UserPath & "\User1\Name"))
    Public UserAcces As String '= DesEncriptIt(IO.File.ReadAllText(UserPath & "\User1\Tipe"))
    Public UserKey As String '= DesEncriptIt(IO.File.ReadAllText(UserPath & "\User1\Password"))
    Public UserImg As Image '= Image.FromFile(UserPath & "\User1\UnknownUser.png")
    '-----------------------------------------------------


    Public Sub reValue()

        GetImages()


        '---------User1---------------------------------------
        UserName = DesEncriptIt(IO.File.ReadAllText(UsersPath & "\" & uClick_Str & "\Name"))
        UserAcces = DesEncriptIt(IO.File.ReadAllText(UsersPath & "\" & uClick_Str & "\Tipe"))
        UserKey = DesEncriptIt(IO.File.ReadAllText(UsersPath & "\" & uClick_Str & "\Password"))

        '-----------------------------------------------------

    End Sub

    Public Sub HideFloatTools()

        StartMenu.Hide()
        IconsForm.Hide()

        Dim Procs As New Threading.Thread(AddressOf HereGo)
        Procs.Start()


    End Sub

    Sub HereGo()
        Try

            IO.File.WriteAllText(AppWork & "\Interface\$Network-%", "False")
            IO.File.WriteAllText(AppWork & "\Interface\-RelojVs", "False")
            IO.File.WriteAllText(AppWork & "\NxReproductor/V_E_NxP", "False")
            IO.File.WriteAllText(AppWork & "\Interface\Btr", "False")

            If VsRefer = True Then
                Dim sProces As New Threading.Thread(AddressOf This3)
                sProces.Start()
                VsRefer = False
            End If

            Dim x As String = IO.File.ReadAllText(AppWork & "\NxReproductor\IsRun")

            If x = "True" Then
                Dim sProcess As New Threading.Thread(AddressOf This)
                sProcess.Start()
            End If



        Catch ex As Exception

        End Try
    End Sub

    Sub This()
        Speak("NxPlayer", "4", "W")
    End Sub

    Sub This2()
        Speak("NxPlayer", "3", "W")
    End Sub

    Sub This3()
        Speak("Notifier", "-", "W")
    End Sub

    Public Sub killProg()

        IconsForm.Hide()
        Configs.Close()
        SlideMenu.Close()
        Runner.Close()
        UserChangerParam.Close()
        Gadgets.Close()
        CgClock.Close()


        For Each program As Process In Process.GetProcesses
            Try
                If program.ProcessName = "WebService" Then
                    program.Kill()
                End If
            Catch ex As Exception
                program.Kill()
            End Try
            '_____________________________________________________________________

            Try
                If program.ProcessName = "NxReloj" Then
                    program.Kill()
                End If
            Catch ex As Exception
                program.Kill()
            End Try
            '_____________________________________________________________________

            Try
                If program.ProcessName = "BateryChecking" Then
                    program.Kill()
                End If
            Catch ex As Exception
                program.Kill()
            End Try
            '_____________________________________________________________________
        Next

        Dim ShutProcess As New Threading.Thread(AddressOf ShutDown)
        ShutProcess.Start()

        IO.File.WriteAllText(AppWork & "\NxTaskBar\Process\ProcessCount", "0")

        IO.File.WriteAllText(AppWork & "\NxDisckExplorer\IsRun", "False")

        IO.File.WriteAllText(AppWork & "\NxLogEditor\IsRun", "False")

        IO.File.WriteAllText(AppWork & "\NxPicViewer\IsRun", "False")

        IO.File.WriteAllText(AppWork & "\NxProcessManage\IsRun", "False")

        IO.File.WriteAllText(AppWork & "\NxReproductor\IsRun", "False")

        IO.File.WriteAllText(AppWork & "\NxWebShip\IsRun", "False")

        IO.File.WriteAllText(AppWork & "\ScreenRslt\IsRun", "False")


    End Sub

    Public Sub HideApps()

        StartMenu.Hide()
        IconsForm.Hide()

        Dim Procs As New Threading.Thread(AddressOf HereGo)
        Procs.Start()

        Dim BreakProcess As New Threading.Thread(AddressOf BreakOut)
        BreakProcess.Start()

        App_Break(1500)


    End Sub

    Public Sub HideApps2()

        StartMenu.Hide()
        IconsForm.Hide()
        IO.File.WriteAllText(AppWork & "\NxTaskBar\Process\ProcessCount", "0")

        Dim Procs As New Threading.Thread(AddressOf HereGo)
        Procs.Start()

        Dim BreakProcess As New Threading.Thread(AddressOf ShutDown)
        BreakProcess.Start()


        App_Break(1500)


    End Sub

    Sub BreakOut()
        Speak("AppServer", "", "Break")
    End Sub

    Sub ShutDown()
        Speak("AppServer", "", "ShutDown")
    End Sub

    Sub startGadgets()
        Dim Cg As String = IO.File.ReadAllText(AppWork & "\ScreenRslt\IsRun")
    End Sub

    Public Sub GetImages()

        Dim fInfo As IO.FileInfo

        For Each File As String In My.Computer.FileSystem.GetFiles(UsersPath & "\" & uClick_Str)
            fInfo = My.Computer.FileSystem.GetFileInfo(File)

            If fInfo.Name.Contains("uImage") Then
                UserImg = Image.FromFile(File)

            End If
        Next



    End Sub

#Region "Saved"
    'Public Sub getbGround()


    '    Dim fInfo As IO.FileInfo

    '    If uClick_Int = 1 Then

    '        For Each File As String In My.Computer.FileSystem.GetFiles(UserPath & "\Admin\bGround")
    '            fInfo = My.Computer.FileSystem.GetFileInfo(File)

    '            If fInfo.Name.Contains("bGimage") Then
    '                bGround = Image.FromFile(File)
    '                SvConfig = UserPath & "\Admin\"
    '            End If
    '        Next

    '        Dim This As String = UserPath & "\Admin\Configs\TskOpc"
    '        Dim Value As Integer = Val(IO.File.ReadAllText(This))

    '        Dim ThisBg As String = IO.File.ReadAllText(UserPath & "\Admin\Configs\TskColor")
    '        Dim BgColor As Color = Color.FromName(ThisBg)

    '        Desktop.Panel1.BackColor = Color.FromArgb(Value, BgColor)
    '        Desktop.Panel14.BackColor = Color.FromArgb(Value, BgColor)

    '        Configs.TrackBar1.Value = Value
    '        Configs.ColorValor = Value

    '        Dim ThisBgDesk As String = IO.File.ReadAllText(UserPath & "\Admin\Configs\BgColor")
    '        Dim BgColorDesk As Color = Color.FromName(ThisBgDesk)

    '        Desktop.BackColor = BgColorDesk

    '    ElseIf uClick_Int = 2 Then

    '        For Each File As String In My.Computer.FileSystem.GetFiles(UserPath & "\User1\bGround")
    '            fInfo = My.Computer.FileSystem.GetFileInfo(File)

    '            If fInfo.Name.Contains("bGimage") Then
    '                bGround = Image.FromFile(File)
    '                SvConfig = UserPath & "\User1\"
    '            End If
    '        Next

    '        Dim This As String = UserPath & "\User1\Configs\TskOpc"
    '        Dim Value As Integer = Val(IO.File.ReadAllText(This))

    '        Dim ThisBg As String = IO.File.ReadAllText(UserPath & "\User1\Configs\TskColor")
    '        Dim BgColor As Color = Color.FromName(ThisBg)

    '        Desktop.Panel1.BackColor = Color.FromArgb(Value, BgColor)
    '        Desktop.Panel14.BackColor = Color.FromArgb(Value, BgColor)

    '        Configs.TrackBar1.Value = Value
    '        Configs.ColorValor = Value

    '        Dim ThisBgDesk As String = IO.File.ReadAllText(UserPath & "\User1\Configs\BgColor")
    '        Dim BgColorDesk As Color = Color.FromName(ThisBgDesk)
    '        Desktop.BackColor = BgColorDesk

    '    ElseIf uClick_Int = 3 Then

    '        For Each File As String In My.Computer.FileSystem.GetFiles(UserPath & "\User2\bGround")
    '            fInfo = My.Computer.FileSystem.GetFileInfo(File)

    '            If fInfo.Name.Contains("bGimage") Then
    '                bGround = Image.FromFile(File)
    '                SvConfig = UserPath & "\User2\"
    '            End If
    '        Next

    '        Dim This As String = UserPath & "\User2\Configs\TskOpc"
    '        Dim Value As Integer = Val(IO.File.ReadAllText(This))

    '        Dim ThisBg As String = IO.File.ReadAllText(UserPath & "\User2\Configs\TskColor")
    '        Dim BgColor As Color = Color.FromName(ThisBg)

    '        Desktop.Panel1.BackColor = Color.FromArgb(Value, BgColor)
    '        Desktop.Panel14.BackColor = Color.FromArgb(Value, BgColor)

    '        Configs.TrackBar1.Value = Value
    '        Configs.ColorValor = Value

    '        Dim ThisBgDesk As String = IO.File.ReadAllText(UserPath & "\User2\Configs\BgColor")
    '        Dim BgColorDesk As Color = Color.FromName(ThisBgDesk)

    '        Desktop.BackColor = BgColorDesk

    '    End If

    '    Dim bgAdjust As String = IO.File.ReadAllText(SvConfig & "BgForm")

    '    SystmColor = Color.FromArgb(CInt(IO.File.ReadAllText(SvConfig & "Configs\SysColr")))


    '    If bgAdjust = "1" Then
    '        Desktop.BackgroundImageLayout = ImageLayout.Stretch

    '    ElseIf bgAdjust = "2" Then
    '        Desktop.BackgroundImageLayout = ImageLayout.Zoom

    '    ElseIf bgAdjust = "3" Then
    '        Desktop.BackgroundImageLayout = ImageLayout.Tile

    '    End If


    'End Sub

#End Region


    Public Sub getbGround()


        Dim fInfo As IO.FileInfo
        Dim Now As String = UsersPath & "\" & uClick_Str

        For Each File As String In My.Computer.FileSystem.GetFiles(Now & "\bGround")
            fInfo = My.Computer.FileSystem.GetFileInfo(File)

            If fInfo.Name.Contains("bGimage") Then
                bGround = Image.FromFile(File)
                SvConfig = Now
            End If
        Next

        Dim This As String = Now & "\Configs\TskOpc"
        Dim Value As Integer = Val(IO.File.ReadAllText(This))

        Dim ThisBg As String = IO.File.ReadAllText(Now & "\Configs\TskColor")
        Dim BgColor As Color = Color.FromName(ThisBg)

        Desktop.Panel1.BackColor = Color.FromArgb(Value, BgColor)
        Desktop.Panel14.BackColor = Color.FromArgb(Value, BgColor)

        Configs.TrackBar1.Value = Value
        Configs.ColorValor = Value

        Dim ThisBgDesk As String = IO.File.ReadAllText(Now & "\Configs\BgColor")
        Dim BgColorDesk As Color = Color.FromName(ThisBgDesk)

        Desktop.BackColor = BgColorDesk



        Dim bgAdjust As String = IO.File.ReadAllText(SvConfig & "\BgForm")

        SystmColor = Color.FromArgb(CInt(IO.File.ReadAllText(SvConfig & "\Configs\SysColr")))


        If bgAdjust = "1" Then
            Desktop.BackgroundImageLayout = ImageLayout.Stretch

        ElseIf bgAdjust = "2" Then
            Desktop.BackgroundImageLayout = ImageLayout.Zoom

        ElseIf bgAdjust = "3" Then
            Desktop.BackgroundImageLayout = ImageLayout.Tile

        End If


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


    Sub CircleImgVero(ByVal Panel As Windows.Forms.Panel, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim figura As GraphicsPath = New GraphicsPath
        Dim x, y, ancho, alto As Integer

        ancho = Panel.Width
        alto = Panel.Height

        x = (Panel.Width - ancho) / 2
        y = (Panel.Height - alto) / 2

        figura.AddEllipse(New Rectangle(x + 3, y + 2, ancho - 7, alto - 7))

        Panel.Region = New Region(figura)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

    End Sub

    Sub CircleImgPic(ByVal picBox As Windows.Forms.PictureBox, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim figura As GraphicsPath = New GraphicsPath
        Dim x, y, ancho, alto As Integer

        ancho = picBox.Width
        alto = picBox.Height

        x = (picBox.Width - ancho) / 2
        y = (picBox.Height - alto) / 2

        figura.AddEllipse(New Rectangle(x, y, ancho, alto))

        picBox.Region = New Region(figura)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

    End Sub


    Dim client As TcpClient

    Sub Speak(ByVal Owner As String, ByVal CMD As String, ByVal tipe As String)

        Try
            client = New TcpClient("localhost", 2000)
            Dim streamw As New StreamWriter(client.GetStream())
            streamw.Write(Owner & "|" & CMD & ";" & tipe)
            streamw.Flush()
        Catch ex As Exception

        End Try


    End Sub


    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    Sub App_Break(ByVal Time As Integer)

        Dim retraso As Integer = Time
        retraso = retraso + GetTickCount

        While retraso >= GetTickCount
            Application.DoEvents()
        End While

    End Sub



    Public Enum eUnidades
        Bytes
        KB
        MB
        GB
    End Enum

    Function calcularTamano(ByVal lTamano As Long) As String
        Dim sCadena As String

        ' Cálculo del tamaño dependiendo de ciertos límites
        If lTamano < 1024 Then ' Hasta 1KB
            sCadena = lTamano & " Bytes"
        ElseIf (lTamano < 1024 ^ eUnidades.MB) Then ' Hasta 1MB
            sCadena = Format(lTamano / 1024, "F") & " KB"
        ElseIf (lTamano < 1024 ^ eUnidades.GB) Then ' Hasta 1GB
            sCadena = Format(lTamano / (1024 ^ 2), "F") & " MB"
        Else ' A partir de 1 GB
            sCadena = Format(lTamano / (1024 ^ 3), "F") & " GB"
        End If

        Return sCadena
    End Function


#Region "StartMenu Apps"

    Dim WithEvents AppPanel As Panel
    Dim PicApp As PictureBox
    Dim LabApp As Label
    Dim WithEvents FrameApp As Panel

    Sub X1(ByVal Parent As Panel)

        For Each AppDirectory As String In IO.Directory.GetDirectories("N:\Dev App")

            Dim read As New DirectoryInfo(AppDirectory)
            Dim Icon As Image = Image.FromFile(AppDirectory & "\" & read.Name & "\Resources\Icon.png")

            '--Step 1-- New Control
            FrameApp = New Panel
            AppPanel = New Panel
            PicApp = New PictureBox
            LabApp = New Label

            '--Step 2-- Designing the control
            With FrameApp
                .BackColor = Color.Transparent
                .Dock = DockStyle.Top
                .Height = 46
            End With

            PicApp.SizeMode = PictureBoxSizeMode.Zoom
            PicApp.Width = 45
            PicApp.Dock = DockStyle.Left
            PicApp.Image = Icon
            PicApp.Enabled = True

            LabApp.AutoSize = True
            LabApp.Text = read.Name
            LabApp.Font = New Drawing.Font("Microsoft Sans Serif", 14)
            LabApp.Location = New Drawing.Point(48, 10)
            LabApp.Enabled = True

            With AppPanel
                .Dock = DockStyle.Top
                .Height = 45
                .BackColor = Color.Transparent
                .Tag = AppDirectory & "\" & read.Name & "\bin\Debug\" & read.Name & ".exe"
            End With

            AppPanel.Controls.Add(PicApp)
            AppPanel.Controls.Add(LabApp)
            FrameApp.Controls.Add(AppPanel)

            '--Step 3-- Using the control

            Parent.Controls.Add(FrameApp)

            AddHandler AppPanel.MouseHover, AddressOf m_In
            AddHandler AppPanel.MouseLeave, AddressOf m_Out
            AddHandler AppPanel.Click, AddressOf m_Click

        Next



    End Sub


    Sub m_In(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppPanel.MouseHover
        CType(sender, Panel).BackColor = SystmColor
    End Sub


    Sub m_Out(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppPanel.MouseLeave
        CType(sender, Panel).BackColor = Color.Transparent
    End Sub

    Sub m_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppPanel.Click
        Process.Start(CType(sender, Panel).Tag)
    End Sub

#End Region

End Module
