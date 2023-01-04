Option Explicit On

Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Net

Public Class Desktop

    Dim bMenuPos As Point
    Dim bMenuPos2 As Point

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bMenuPos = Panel14.Location
        bMenuPos2 = New Point(1, bMenuPos.Y + 10)

        reValue()
        ' Process.Start("N:\Aplicaciones\ScreenCap\ScreenCap\bin\Debug\ScreenCap.exe")

        IO.File.WriteAllText("N:\Nexus\AppWork\Interface/#IsReady-", "True")
        StarConfig()

        UserToLog(uClick_Str)

        getbGround()

        TaskProcess.Enabled = True
        TaskProcess.Interval = 50

        StartMenu.Show()
        StartMenu.Hide()
        IconsForm.Opacity = 100%

        TimeDateToScreen.Start()
        TaskBar.Start()
        Batery.Start()

        ' LoadDesktop()
        Me.BackgroundImage = bGround
        StartMenu.Opacity = 100%

        Dim LoadThread As New Threading.Thread(AddressOf Welcome)
        LoadThread.Start()


    End Sub

    Dim NameNtf As String

    Sub Welcome()
        App_Break(1200)
        Speak("Notifier", "N:\Nexus\Resourses\StartButon.png-Nexus OSS 3.0+Inicio de sesion^Bienvenido " & NameNtf, "C")
    End Sub

    Sub LoadDesktop()
        Dim Info As IO.FileInfo


        Try
            For Each File As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Desktop)
                Info = My.Computer.FileSystem.GetFileInfo(File)

                'ListView1.Items.Add(Info.Name, 0)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Sub UserToLog(ByVal User As String)

        StartMenu.Label1.Text = User 'Admin
        StartMenu.Label2.Text = UserAcces 'AdTipe
        StartMenu.PictureBox1.BackgroundImage = UserImg ' ImgAd
        NameNtf = User 'Admin


    End Sub



    Sub StarConfig()

        Panel1.BackColor = Color.FromArgb(100, Panel1.BackColor)
        Panel14.BackColor = Color.FromArgb(1, Panel1.BackColor)
        Panel16.BackColor = Color.FromArgb(1, Panel1.BackColor)
        Panel14.BackColor = Color.FromArgb(1, Panel1.BackColor)
        Panel17.BackColor = Color.FromArgb(1, Panel1.BackColor)
        Panel18.BackColor = Color.FromArgb(1, Panel1.BackColor)
        Panel19.BackColor = Color.FromArgb(1, Panel1.BackColor)


    End Sub


    Dim nStatus As String

    Public Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternetService.Tick
        Try
            Dim request As WebRequest = WebRequest.Create("http://localhost:15315/SystemConection/")

            request.Credentials = CredentialCache.DefaultCredentials

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadLine()

            nStatus = (responseFromServer)

            reader.Close()
            dataStream.Close()
            response.Close()

            If nStatus.ToLower = "conectando..." Then
                PictureBox4.Image = My.Resources.Off

            ElseIf nStatus.ToLower = "conectado" Then
                PictureBox4.Image = My.Resources.Good

            ElseIf nStatus.ToLower = "error" Then
                PictureBox4.Image = My.Resources.Regular

            ElseIf nStatus.ToLower = "sin medios" Then

                PictureBox4.Image = My.Resources.Bad

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        IO.File.WriteAllText("N:\Nexus\AppWork\Interface/#IsReady-", "False")
        TimeDateToScreen.Stop()
        TaskBar.Stop()
        Batery.Stop()

    End Sub

    Private Sub Panel13_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Configs.Show()
    End Sub



    Private Sub TimeDate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeDate.Tick
        Try
            Dim request As WebRequest = WebRequest.Create("http://localhost:13513/systemtime/")

            request.Credentials = CredentialCache.DefaultCredentials

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            TimeAndDate = (responseFromServer)

            reader.Close()
            dataStream.Close()
            response.Close()
        Catch ex As Exception

        End Try
    End Sub

    Dim Reloj As String

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel3.Click, Label4.Click, Label3.Click
        'MsgBox(Label3.Text.Replace(" ", "-"))


        Try

            If My.Computer.FileSystem.FileExists("N:\Nexus\AppWork\Interface\-RelojVs") = False Then
                IO.File.WriteAllText("N:\Nexus\AppWork\Interface\-RelojVs", "False")
            Else

                Reloj = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\-RelojVs")
            End If


            If Reloj = "False" Then
                IO.File.WriteAllText("N:\Nexus\AppWork\Interface\-RelojVs", "True")
                IO.File.WriteAllText("N:\Nexus\AppWork\Interface/$Network-%", "False")
                Dim sProcess As New Threading.Thread(AddressOf This)
                sProcess.Start()
            Else

                IO.File.WriteAllText("N:\Nexus\AppWork\Interface\-RelojVs", "False")

            End If

        Catch ex As Exception

        End Try



    End Sub

    Dim net As String

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click


        Try
            net = IO.File.ReadAllText("N:\Nexus\AppWork\Interface/$Network-%")

            If net = "False" Then
                IO.File.WriteAllText("N:\Nexus\AppWork\Interface/$Network-%", "True")
                IO.File.WriteAllText("N:\Nexus\AppWork\Interface\-RelojVs", "False")
                Dim sProcess As New Threading.Thread(AddressOf This)
                sProcess.Start()
                IconsForm.Hide()
            Else
                IO.File.WriteAllText("N:\Nexus\AppWork\Interface/$Network-%", "False")

            End If
        Catch ex As Exception

        End Try


    End Sub

    Dim F2Show As Boolean = False

    Private Sub Panel14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel14.Click
        StartMenu.Opacity = 90

        UserToLog(uClick_Str)

        Try

            If F2Show = False Then
                F2Show = True
                StartMenu.Show()
            Else
                F2Show = False
                StartMenu.Hide()
                StartMenu.Cr = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim ToolsIcons As Integer = 1
    Dim NxRep As String
    Dim NxState As String
    Dim wRead As Boolean = False
    Dim n As String

    Private Sub RepNx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepNx.Tick
        n = NxState

        Try
            NxRep = IO.File.ReadAllText("N:\Nexus\AppWork\NxReproductor/IsRun")

            NxState = IO.File.ReadAllText("N:\Nexus\AppWork\NxReproductor/&State}")


        Catch ex As Exception

        End Try


        NxPlayerIcon()



        If Not NxState = n Then
            If NxState = "Play" Then

                NxIcon.Image = My.Resources.nxPlayState

            Else

                NxIcon.Image = My.Resources.nxPlayStopped

            End If


        Else
            Exit Sub


        End If








    End Sub


    Sub NxPlayerIcon()

        If NxRep = "True" Then

            NxIcon.Parent = IconsForm.Panel1
            NxIcon.Location = IconsForm.Icon1.Location

            'NxIcon.Location = New Drawing.Point(30, 14)
            'OtherIcon.Location = New Drawing.Point(5, 14)

            NxIcon.Visible = True
        Else

            NxIcon.Visible = False
        End If






    End Sub

    Private Sub NxIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NxIcon.Click


        Dim sProcess As New Threading.Thread(AddressOf This2)
        sProcess.Start()


    End Sub

    Private Sub me_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        T1.Stop()
        T2.Start()
        HideFloatTools()
    End Sub

    Private Sub Panel16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel19.Click, Panel16.Click
        T1.Stop()
        T2.Start()
        HideFloatTools()
    End Sub

    Private Sub Form1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        T1.Stop()
        T2.Start()
        HideFloatTools()

    End Sub



    Private Sub AdminDeTareasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminDeTareasToolStripMenuItem.Click

        Dim IsRun As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxProcessManage\IsRun")

        If IsRun = "False" Then

            'Process.Start("N:\System\NxProcessManage\NxProcessManage\bin\Debug\NxProcessManage.exe")

        End If

    End Sub

    Private Sub EjecutarPorComandoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EjecutarPorComandoToolStripMenuItem.Click
        Runner.Show()
    End Sub


    Private Sub ConfiguracionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguracionToolStripMenuItem.Click

        SlideMenu.Height = My.Computer.Screen.WorkingArea.Height - 30


        If CogShow = False Then

            SlideMenu.Show()
            SlideMenu.Focus()
            SlideMenu.Top = ((My.Computer.Screen.WorkingArea.Height / 2) - (SlideMenu.Height / 2)) - 5
            SlideMenu.Left = My.Computer.Screen.WorkingArea.Width + 270
            T1.Start()


        Else
            SlideMenu.Close()
        End If
    End Sub

    Dim CogShow As Boolean = False


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

        For Each Contrl As Control In Me.Controls

            Contrl.Refresh()
        Next

    End Sub

    Private Sub RepIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepIcon.Click
        ' IO.File.WriteAllText("N:\NexusFrameWork\NxReproductor\Shown", "True")

        Dim xZ As String

        Try
            xZ = IO.File.ReadAllText("N:\Nexus\AppWork\Settings\Vero\IsRun")

            If xZ = "False" Then
                'Process.Start("N:\System\Nexo\Nexo\bin\Debug\Nexo.exe")
            End If

        Catch ex As Exception

        End Try

    End Sub



    Dim Increment As Integer = 35

    Private Sub T1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1.Tick

        If SlideMenu.Location.X <= My.Computer.Screen.WorkingArea.Width - SlideMenu.Width Then

            T1.Stop()
            T2.Stop()
        Else
            Increment = Increment - 1
            SlideMenu.Left = SlideMenu.Location.X - Increment
            T2.Stop()
        End If


    End Sub



    Private Sub T2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2.Tick
        If SlideMenu.Location.X >= My.Computer.Screen.WorkingArea.Width + SlideMenu.Width Then
            T2.Stop()
            T1.Stop()
            Increment = 35
            SlideMenu.Hide()
        Else
            Increment = Increment + 1

            If Increment > 35 Then
                T2.Stop()
                T1.Stop()
                Increment = 35

            Else
                SlideMenu.Left = SlideMenu.Location.X + Increment
                T1.Stop()
            End If




        End If
    End Sub


    Private Sub ShowCursorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowCursorToolStripMenuItem.Click
        Cursor.Show()
    End Sub



    Private Sub Panel14_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel14.Paint
        CircleImg(Panel14, e)
    End Sub

    Private Sub Panel14_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel14.MouseLeave
        ' Panel14.BackgroundImage = My.Resources.NexusSB

        ArcTimer.Stop()
        Panel14.BackColor = Color.Transparent
        pArcEfect = Nothing

    End Sub

    Private Sub Panel14_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel14.MouseHover
        'Panel14.BackgroundImage = My.Resources.NexusSB2

        pArcEfect = CType(sender, Panel)
        ArcTimer.Start()

    End Sub

    'Private Sub RepIcon_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepIcon.MouseLeave
    '    ArcTimer.Stop()
    '    RepIcon.BackColor = Color.Transparent
    '    pArcEfect = Nothing
    'End Sub

    'Private Sub RepIcon_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepIcon.MouseHover
    '    pArcEfect = CType(sender, Panel)
    '    ArcTimer.Start()
    'End Sub

    Private Sub GadgetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GadgetsToolStripMenuItem.Click
        Gadgets.Show()

    End Sub

    Dim WithEvents AppPanel As System.Windows.Forms.Panel
    Dim TaskBarDir As String = "N:\Nexus\AppWork\NxTaskBar\AppConfig"

    Dim AppName As String
    Dim AppIcon As Image
    Dim AppRoute As String
    Dim AppNumber As String

    Sub TaskBarNeat()

        For Each AppDirect As String In IO.Directory.GetDirectories(TaskBarDir)

            Dim DirInfo As New IO.DirectoryInfo(AppDirect)
            Dim StatusApp As String = ""

            Try
                StatusApp = IO.File.ReadAllText(AppDirect & "/Ld")

            Catch ex As Exception

                Try
                    StatusApp = IO.File.ReadAllText(AppDirect & "/Ld")
                Catch x As Exception

                    Try
                        StatusApp = IO.File.ReadAllText(AppDirect & "/Ld")
                    Catch exx As Exception

                    End Try
                End Try


            End Try

            If StatusApp = "True" Then

                Try
                    AppName = DirInfo.Name
                    AppIcon = Image.FromFile(AppDirect & "/Icon.png")
                    AppNumber = IO.File.ReadAllText(AppDirect & "/Nmbr")

                    AppPanel = New System.Windows.Forms.Panel


                    With AppPanel
                        .Parent = Panel16
                        .Name = AppName
                        .BorderStyle = BorderStyle.None
                        .BackgroundImageLayout = ImageLayout.Zoom
                        .BackgroundImage = AppIcon
                        .BackColor = Color.Transparent
                        .Size = New Drawing.Size(55, 46)
                        .Top = 1
                        .Tag = AppName

                        If AppNumber = 1 Then
                            .Left = 0
                        Else
                            .Left = 57 * Val(AppNumber) - 57
                        End If


                    End With

                    IO.File.WriteAllText(AppDirect & "/Ld", "Wait")

                    AddHandler AppPanel.Click, AddressOf TaskBar_Click
                    AddHandler AppPanel.MouseHover, AddressOf TaskPanel_MoveHover
                    AddHandler AppPanel.MouseLeave, AddressOf TaskPanel_MoveLeave
                    AddHandler AppPanel.MouseDown, AddressOf TaskPanel_MouseDown
                    AddHandler AppPanel.MouseUp, AddressOf TaskPanel_Up

                    Panel16.Controls.Add(AppPanel)
                    TaskList.Add(AppName)

                Catch ex As Exception
                    TaskBarNeat()
                    Reorganizar()
                End Try


            ElseIf StatusApp = "False" Then

                IO.File.WriteAllText(AppDirect & "/Ld", "")

                AppName = DirInfo.Name
                TaskList.Remove(AppName)

                For Each Pnel As Panel In Panel16.Controls

                    If CType(Pnel, System.Windows.Forms.Panel).Tag = AppName Then
                        Panel16.Controls.RemoveByKey(CType(Pnel, System.Windows.Forms.Panel).Tag)
                    End If

                Next


                If DirInfo.Name = "ScreenCap" Then
                    IO.File.WriteAllText(AppDirect & "/Ld", "Ready")

                End If

                Reorganizar()

            End If
        Next

    End Sub

    Private Sub TaskPanel_MoveHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppPanel.MouseHover
        CType(sender, Panel).BorderStyle = BorderStyle.None
        CType(sender, Panel).BackColor = SystmColor

    End Sub


    Private Sub TaskPanel_MoveLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppPanel.MouseLeave
        CType(sender, Panel).BorderStyle = BorderStyle.None
        CType(sender, Panel).BackColor = Color.Transparent

    End Sub

    Private Sub TaskPanel_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AppPanel.MouseDown

        CType(sender, Panel).BackColor = Color.DimGray

    End Sub

    Private Sub TaskPanel_Up(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AppPanel.MouseUp

        CType(sender, Panel).BackColor = SystmColor

    End Sub

    Sub ShowAppServer()
        Speak("AppServer", "", "S")
    End Sub

    Private Sub TaskBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppPanel.Click

        Try

            Dim TaskClicked As String = CType(sender, System.Windows.Forms.Panel).Tag
            Dim WorkDir As String = TaskBarDir & "/" & TaskClicked & "/CMD"

            If TaskClicked = "ScreenCap" Then
                IO.File.WriteAllText(WorkDir, "4")

            ElseIf TaskClicked = "AppServer" Then
                Dim xProcess As New Threading.Thread(AddressOf ShowAppServer)
                xProcess.Start()

            Else
                IO.File.WriteAllText(WorkDir, "1")
            End If

        Catch ex As Exception

        End Try


    End Sub

    Dim TaskList As New List(Of String)
    Public WithEvents TaskProcess As New System.Windows.Forms.Timer

    Sub TaskProcess_Tick() Handles TaskProcess.Tick

        TaskBarNeat()

    End Sub


    Sub Reorganizar()

        If Not TaskList.Count = 0 Then

            For i = 0 To TaskList.Count - 1
                Dim PrcsName As String = TaskList(i)

                For Each Pnel As Panel In Panel16.Controls

                    If CType(Pnel, System.Windows.Forms.Panel).Tag = PrcsName Then

                        If i + 1 = 1 Then
                            Pnel.Left = 0
                        Else

                            Pnel.Left = 56 * Val(i + 1) - 56
                        End If


                    End If

                Next

            Next

        End If

    End Sub



    Private Sub HacerRecorteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HacerRecorteToolStripMenuItem.Click
        Dim sProcess As New Threading.Thread(AddressOf ScreenCapIt)
        sProcess.Start()
    End Sub

    Sub ScreenCapIt()
        Speak("ScreenCap", "1", "W")
    End Sub

    Dim Refer As String = ""

    Private Sub FileSystemWatcher1_Changed(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed

        exec = True

        Try
            Refer = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
        Catch ex As Exception
            Refer = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
        End Try


    End Sub

    Dim exec As Boolean = False

    Private Sub TaskBar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskBar.Tick

        If exec = True Then

            If Refer = "0" Then

                Panel14.Size = New Size(60, 60)
                Panel14.Left = 1
                StartMenu.Panel14.Visible = True

            ElseIf StartMenu.Visible = True Then
                Panel14.Size = New Size(60, 60)
                Panel14.Left = 1
                StartMenu.Panel14.Visible = True

            Else
                Panel14.Size = New Size(50, 50)
                Panel14.Left = 1
                StartMenu.Panel14.Visible = False

            End If

            Panel14.Top = Me.Height - Panel14.Height

        End If



    End Sub



    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click

        If VsRefer = False Then
            Speak("Notifier", "+", "W")
            VsRefer = True

        Else
            Speak("Notifier", "-", "W")
            VsRefer = False
        End If

    End Sub

    Private Sub RepIcon_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles RepIcon.Paint
        CircleImgVero(CType(sender, Panel), e)
    End Sub



    Dim ParamR As Integer = 5
    Dim paramG As Integer = 5
    Dim paramB As Integer = 5
    Dim x As Integer() = {50, 150, 125}

    Dim pArcEfect As Panel

    Private Sub ArcTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArcTimer.Tick


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

        pArcEfect.BackColor = nColor

    End Sub

    Private Sub RepIcon_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepIcon.MouseLeave
        ArcTimer.Stop()
        RepIcon.BackColor = Color.Transparent
        pArcEfect = Nothing
    End Sub

    Private Sub RepIcon_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepIcon.MouseHover
        pArcEfect = CType(sender, Panel)
        ArcTimer.Start()
    End Sub


    Private Sub TimeDateToScreen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeDateToScreen.Tick
        Try
            sSeconds = IO.File.ReadAllText("N:\Users\" & uClick_Str & "\Configs\AppConfig\Time\sSeconds")

            If TimeAndDate.EndsWith(".") Then

                Dim x As Date = CDate(TimeAndDate.Remove(TimeAndDate.Length - 5))

                If sSeconds = "True" Then
                    Label4.Text = x.TimeOfDay.ToString & " " & TimeAndDate.Substring(TimeAndDate.Length - 4)
                Else
                    Label4.Text = x.TimeOfDay.ToString.Remove(x.TimeOfDay.ToString.Length - 3) & " " & TimeAndDate.Substring(TimeAndDate.Length - 4)
                End If

                If x.Month > 9 Then
                    'Label3.Text = x.Day & "/" & x.Month & "/" & x.Year

                    If x.Day > 9 Then
                        Label3.Text = x.Day & "/" & x.Month & "/" & x.Year
                    Else
                        Label3.Text = "0" & x.Day & "/" & x.Month & "/" & x.Year
                    End If

                Else
                    If x.Day > 9 Then
                        Label3.Text = x.Day & "/0" & x.Month & "/" & x.Year
                    Else
                        Label3.Text = "0" & x.Day & "/0" & x.Month & "/" & x.Year
                    End If

                End If

            Else
                Dim x As Date = CDate(TimeAndDate)

                If sSeconds = "True" Then
                    Label4.Text = x.TimeOfDay.ToString
                Else
                    Label4.Text = x.TimeOfDay.ToString.Remove(x.TimeOfDay.ToString.Length - 3)
                End If

                If x.Month > 9 Then

                    If x.Day > 9 Then
                        Label3.Text = x.Day & "/" & x.Month & "/" & x.Year
                    Else
                        Label3.Text = "0" & x.Day & "/" & x.Month & "/" & x.Year
                    End If
                Else
                    If x.Day > 9 Then
                        Label3.Text = x.Day & "/0" & x.Month & "/" & x.Year
                    Else
                        Label3.Text = "0" & x.Day & "/0" & x.Month & "/" & x.Year
                    End If

                    ' Label3.Text = x.Day & "/0" & x.Month & "/" & x.Year

                End If

            End If

        Catch ex As Exception

        End Try

        Label3.Left = (Panel3.Width / 2) - (Label3.Width / 2)
        Label4.Left = (Panel3.Width / 2) - (Label4.Width / 2)

    End Sub


    Private Sub OtherIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherIcon.Click
        HideFloatTools()

        IconsForm.Opacity = 100%

        If IconsForm.Visible = False Then
            IconsForm.Visible = True
        Else
            IconsForm.Visible = False
        End If


    End Sub

    Dim Bat As String

    Private Sub Panel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel6.Click, Panel5.Click, Panel4.Click
        'HideFloatTools()

        Try
            Bat = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Btr")

            If Bat = "False" Then

                IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Btr", "True")
                IO.File.WriteAllText("N:\Nexus\AppWork\Interface\-RelojVs", "False")
                Dim sProcess As New Threading.Thread(AddressOf This)
                sProcess.Start()
                IconsForm.Hide()
            Else
                IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Btr", "False")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Batery_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Batery.Tick
        Dim BatData As String = ""

        Try
            Dim request As WebRequest = WebRequest.Create("http://localhost:13914/bactery/")

            request.Credentials = CredentialCache.DefaultCredentials

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            BatData = (responseFromServer)

            reader.Close()
            dataStream.Close()
            response.Close()
        Catch ex As Exception

        End Try


        Try


            Dim Percent As Integer = CInt(BatData.Remove(BatData.IndexOf("-")))
            Dim Stat As String = BatData.Substring(BatData.IndexOf("-") + 1)

            Panel6.Width = (Percent / 100) * Panel5.Width

            If Stat = "char" And Panel6.BackgroundImage Is Nothing Then

                Panel6.BackgroundImage = My.Resources.WC
                Panel5.BackgroundImage = My.Resources.Bc


            ElseIf Stat = "dis" And Not Panel6.BackgroundImage Is Nothing Then
                Panel6.BackgroundImage = Nothing
                Panel5.BackgroundImage = Nothing
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FondoArcoIrisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FondoArcoIrisToolStripMenuItem.Click
        ArcoIrs.Show()
    End Sub


    Dim Param2R As Integer = 5
    Dim param2G As Integer = 5
    Dim param2B As Integer = 5
    Dim x2 As Integer() = {50, 150, 125}

    Private Sub FondoArcoIris_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FondoArcoIris.Tick

        If x2(0) >= 255 Then
            Param2R = -5
        ElseIf x2(0) <= 0 Then
            Param2R = 5
        End If


        If x2(1) >= 255 Then
            param2G = -5
        ElseIf x2(1) <= 0 Then
            param2G = 5
        End If


        If x2(2) >= 255 Then
            param2B = -5
        ElseIf x2(2) <= 0 Then
            param2B = 5
        End If


        x2.SetValue(CInt(x2(0) + (Param2R)), 0)
        x2.SetValue(CInt(x2(1) + (param2G)), 1)
        x2.SetValue(CInt(x2(2)), 2)

        Dim nColor As Color = Color.FromArgb(x2(0), x2(1), x2(2))
        Me.BackColor = nColor

    End Sub


   
End Class

