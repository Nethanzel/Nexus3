Public Class Form1

    Dim PerformanceC1 As New PerformanceCounter
    Dim PerformanceC2 As New PerformanceCounter
    Dim PerformanceC3 As New PerformanceCounter
    Dim PerformanceC4 As New PerformanceCounter

    Dim InfoSistema As New InfoSistema.irInforSistema

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim r = calcularTamano(tMemory) 'returns the size of memory as gygabytes
        'Dim l As Decimal = r.Remove(r.Length - 3, 3) 'Removes the string part from the result (GB)

        'Dim x As ULong = ((tMemory / 32000) * Math.Ceiling(l))
        'MsgBox(x)
        'ProgressBar1.Maximum = (tMemory / 1000)

        For i = 1 To InfoSistema.CantidadProcesadores
            Try

                If i = 1 Then
                    PerformanceC1.MachineName = "."
                    PerformanceC1.InstanceLifetime = PerformanceCounterInstanceLifetime.Global
                    PerformanceC1.CategoryName = "Procesador"
                    PerformanceC1.CounterName = "% de tiempo de procesador"
                    PerformanceC1.InstanceName = "0"
                    Panel15.Visible = True
                    Label12.Visible = True
                    Me.components.Add(PerformanceC1)
                ElseIf i = 2 Then

                    PerformanceC2.MachineName = "."
                    PerformanceC2.InstanceLifetime = PerformanceCounterInstanceLifetime.Global
                    PerformanceC2.CategoryName = "Procesador"
                    PerformanceC2.CounterName = "% de tiempo de procesador"
                    PerformanceC2.InstanceName = "1"
                    Panel17.Visible = True
                    Label13.Visible = True
                    Me.components.Add(PerformanceC2)

                ElseIf i = 3 Then

                    PerformanceC3.MachineName = "."
                    PerformanceC3.InstanceLifetime = PerformanceCounterInstanceLifetime.Global
                    PerformanceC3.CategoryName = "Procesador"
                    PerformanceC3.CounterName = "% de tiempo de procesador"
                    PerformanceC3.InstanceName = "2"
                    Panel19.Visible = True
                    Label14.Visible = True
                    Me.components.Add(PerformanceC3)
                ElseIf i = 4 Then

                    PerformanceC4.MachineName = "."
                    PerformanceC4.InstanceLifetime = PerformanceCounterInstanceLifetime.Global
                    PerformanceC4.CategoryName = "Procesador"
                    PerformanceC4.CounterName = "% de tiempo de procesador"
                    PerformanceC4.InstanceName = "3"
                    Panel21.Visible = True
                    Label15.Visible = True
                    Me.components.Add(PerformanceC4)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Next

        IO.File.WriteAllText("N:\Nexus\AppWork\NxProcessManage\IsRun", "True")
        Load_Me("TaskManager", PictureBox1.Image, ListenNumber)

    End Sub

    Dim NxPlayer As String
    Dim NxWebShip As String
    Dim NxDisckExp As String
    Dim NxPicViewer As String

    Dim NxP As ListViewItem
    Dim NxWs As ListViewItem
    Dim NxDe As ListViewItem
    Dim NxPw As ListViewItem


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppTimer.Tick


        GetMyProcess()





    End Sub

    Dim ListVwItem As ListViewItem


    Sub BackGroundToForeGround(ByVal Name As String)

        MsgBox(Name)



    End Sub


    Sub KillApp(ByVal Name As String)

        Try

            For Each App As Process In Process.GetProcesses

                If App.ProcessName = Name Then
                    App.Kill()

                End If
            Next

        Catch ex As Exception

        End Try



    End Sub


    Dim Index As Integer

    Sub GetMyProcess()

        ListView1.Items.Clear()

        For Each proc As Process In Process.GetProcesses

            If proc.ProcessName = "NxPlayer" Then

                ListVwItem = New ListViewItem("NxPlayer", 0)
                ListVwItem.SubItems.Add("Activo")
                ListVwItem.SubItems.Add(proc.StartTime)
                ListVwItem.ToolTipText = proc.ProcessName
                ListView1.Items.Add(ListVwItem).Group = ListView1.Groups(0)

            ElseIf proc.ProcessName = "DisckExplorer" Then

                ListVwItem = New ListViewItem("NxDisckExplorer", 2)
                ListVwItem.SubItems.Add("Activo")
                ListVwItem.SubItems.Add(proc.StartTime)
                ListVwItem.ToolTipText = proc.ProcessName
                ListView1.Items.Add(ListVwItem).Group = ListView1.Groups(0)

            ElseIf proc.ProcessName = "PicViewer" Then

                ListVwItem = New ListViewItem("NxPicViewer", 1)
                ListVwItem.SubItems.Add("Activo")
                ListVwItem.SubItems.Add(proc.StartTime)
                ListVwItem.ToolTipText = proc.ProcessName
                ListView1.Items.Add(ListVwItem).Group = ListView1.Groups(0)

            ElseIf proc.ProcessName = "WebExplorer" Then

                ListVwItem = New ListViewItem("NxWebShip", 3)
                ListVwItem.SubItems.Add("Activo")
                ListVwItem.SubItems.Add(proc.StartTime)
                ListVwItem.ToolTipText = proc.ProcessName
                ListView1.Items.Add(ListVwItem).Group = ListView1.Groups(0)

            End If



        Next




        For Each Service As Process In Process.GetProcesses


            If Service.ProcessName = "NxLogEditor" Then

                NxServiceItem = New ListViewItem("NxLogEditor", 4)
                NxServiceItem.SubItems.Add("Activo")
                NxServiceItem.SubItems.Add(Service.StartTime)
                NxServiceItem.ToolTipText = Service.ProcessName
                ListView1.Items.Add(NxServiceItem).Group = ListView1.Groups(2)


            ElseIf Service.ProcessName = "NxProcessManage" Then

                NxServiceItem = New ListViewItem("NxProcessManage", 5)
                NxServiceItem.SubItems.Add("Activo")
                NxServiceItem.SubItems.Add(Service.StartTime)
                NxServiceItem.ToolTipText = Service.ProcessName
                ListView1.Items.Add(NxServiceItem).Group = ListView1.Groups(2)

            ElseIf Service.ProcessName = "NxReloj" Then

                NxServiceItem = New ListViewItem("NxReloj", 6)
                NxServiceItem.SubItems.Add("Activo")
                NxServiceItem.SubItems.Add(Service.StartTime)
                NxServiceItem.ToolTipText = Service.ProcessName
                ListView1.Items.Add(NxServiceItem).Group = ListView1.Groups(1)

            ElseIf Service.ProcessName = "WebService" Then

                NxServiceItem = New ListViewItem("NxInternet I/O", 7)
                NxServiceItem.SubItems.Add("Activo")
                NxServiceItem.SubItems.Add(Service.StartTime)
                NxServiceItem.ToolTipText = Service.ProcessName
                ListView1.Items.Add(NxServiceItem).Group = ListView1.Groups(1)

            End If


        Next

        Try
            ListView1.Items(Index).Selected = True
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Close()

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Hide()
    End Sub


    Dim NxServiceItem As ListViewItem
  


    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseMove
        If aaa = True Then
            Dim tmp As Point = New Point

            tmp.X = Me.Location.X + (e.X - MouseX)
            tmp.Y = Me.Location.Y + (e.Y - MouseY)
            Me.Location = tmp
            tmp = Nothing

        
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub

    Dim Porciento As Integer
    Dim tMemory As ULong = My.Computer.Info.TotalPhysicalMemory

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RamMonitor.Tick

        Dim uMemory As ULong = My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory

        Try

            'ProgressBar1.Value = Convert.ToInt32(uMemory / 2)

            'Porciento = (ProgressBar1.Value / ProgressBar1.Maximum) * 100

            percente = Porciento
            Label8.Text = Porciento & "%"

            Me.Refresh()

            'Panel13.Width = (ProgressBar1.Value / ProgressBar1.Maximum) * Panel12.Width

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        TextBox1.Text = vbNewLine & "     Memoria total en este equipo: " & calcularTamano(My.Computer.Info.TotalPhysicalMemory) & " <(Utilizable " & calcularTamano(My.Computer.Info.TotalPhysicalMemory) & ")>" & vbNewLine & vbNewLine & "<Total de memoria siendo ultulizada: " & calcularTamano(My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory) & ">"



        'If Val(Label8.Text) < 60 Then
        '    Panel13.BackColor = Color.DodgerBlue
        'End If

        'If Val(Label8.Text) > 60 Then
        '    Panel13.BackColor = Color.Yellow
        'End If

        'If Val(Label8.Text) > 75 Then
        '    Panel13.BackColor = Color.Orange
        'End If

        'If Val(Label8.Text) > 90 Then
        '    Panel13.BackColor = Color.Red
        'End If

    End Sub

    Private Sub ProcessorMonitor_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessorMonitor.Tick
        Try
            If InfoSistema.CantidadProcesadores = 1 Then


            ElseIf InfoSistema.CantidadProcesadores = 2 Then
                ProgressBar2.Value = PerformanceC1.NextValue
                ProgressBar3.Value = PerformanceC2.NextValue

            ElseIf InfoSistema.CantidadProcesadores = 3 Then
                ProgressBar2.Value = PerformanceC1.NextValue
                ProgressBar3.Value = PerformanceC2.NextValue
                ProgressBar4.Value = PerformanceC3.NextValue

            ElseIf InfoSistema.CantidadProcesadores = 4 Then
                ProgressBar2.Value = PerformanceC1.NextValue
                ProgressBar3.Value = PerformanceC2.NextValue
                ProgressBar4.Value = PerformanceC3.NextValue
                ProgressBar5.Value = PerformanceC4.NextValue

            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

        'Panel16.Width = (ProgressBar2.Value / ProgressBar2.Maximum) * Panel15.Width
        Core1 = (ProgressBar2.Value / ProgressBar2.Maximum) * 100

        'Panel18.Width = (ProgressBar3.Value / ProgressBar3.Maximum) * Panel17.Width
        Core2 = (ProgressBar3.Value / ProgressBar3.Maximum) * 100

        'Panel20.Width = (ProgressBar4.Value / ProgressBar4.Maximum) * Panel19.Width
        Core3 = (ProgressBar4.Value / ProgressBar4.Maximum)

        'Panel22.Width = (ProgressBar5.Value / ProgressBar5.Maximum) * Panel21.Width
        Core4 = (ProgressBar5.Value / ProgressBar5.Maximum)

        TextBox2.Text = vbNewLine & "   <Procesador: " & InfoSistema.NombreProcesador & ">" & vbNewLine & "<" & InfoSistema.CantidadProcesadores & " Nucleos>" & vbNewLine & "<Velocidad: " & InfoSistema.VelocidadProcesador & " MHz>"




    End Sub

    Private Sub ProcesorMonitorII_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcesorMonitorII.Tick


        ProgressBar6.Value = PerformanceCounter1.NextValue

        'Panel24.Width = (ProgressBar6.Value / ProgressBar6.Maximum) * Panel23.Width

        ProPercent = (ProgressBar6.Value / ProgressBar6.Maximum) * 100

        GeneralProcessor_Graphic()

        NulceoIProcesor()
        NucleoIIProcesor()
        NucleoIIIProcesor()
        NucleoIVProcesor()



    End Sub

    Sub GeneralProcessor_Graphic()
        If Val(ProgressBar6.Value) < 60 Then
            Panel24.BackColor = Color.DodgerBlue
        End If

        If Val(ProgressBar6.Value) > 60 Then
            Panel24.BackColor = Color.Yellow
        End If

        If Val(ProgressBar6.Value) > 75 Then
            Panel24.BackColor = Color.Orange
        End If

        If Val(ProgressBar6.Value) > 90 Then
            Panel24.BackColor = Color.Red
        End If


    End Sub

    Sub NulceoIProcesor()


        If Val(ProgressBar2.Value) < 60 Then
            Panel16.BackColor = Color.DodgerBlue
        End If

        If Val(ProgressBar2.Value) > 60 Then
            Panel16.BackColor = Color.Yellow
        End If

        If Val(ProgressBar2.Value) > 75 Then
            Panel16.BackColor = Color.Orange
        End If

        If Val(ProgressBar2.Value) > 90 Then
            Panel16.BackColor = Color.Red
        End If




    End Sub

    Sub NucleoIIProcesor()


        If Val(ProgressBar3.Value) < 60 Then
            Panel18.BackColor = Color.DodgerBlue
        End If

        If Val(ProgressBar3.Value) > 60 Then
            Panel18.BackColor = Color.Yellow
        End If

        If Val(ProgressBar3.Value) > 75 Then
            Panel18.BackColor = Color.Orange
        End If

        If Val(ProgressBar3.Value) > 90 Then
            Panel18.BackColor = Color.Red
        End If

    End Sub

    Sub NucleoIIIProcesor()


        If Val(ProgressBar4.Value) < 60 Then
            Panel20.BackColor = Color.DodgerBlue
        End If

        If Val(ProgressBar4.Value) > 60 Then
            Panel20.BackColor = Color.Yellow
        End If

        If Val(ProgressBar4.Value) > 75 Then
            Panel20.BackColor = Color.Orange
        End If

        If Val(ProgressBar4.Value) > 90 Then
            Panel20.BackColor = Color.Red
        End If

    End Sub

    Sub NucleoIVProcesor()


        If Val(ProgressBar5.Value) < 60 Then
            Panel22.BackColor = Color.DodgerBlue
        End If

        If Val(ProgressBar5.Value) > 60 Then
            Panel22.BackColor = Color.Yellow
        End If

        If Val(ProgressBar5.Value) > 75 Then
            Panel22.BackColor = Color.Orange
        End If

        If Val(ProgressBar5.Value) > 90 Then
            Panel22.BackColor = Color.Red
        End If

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click, Panel8.Click, Label3.Click
        Me.Size = New Drawing.Size(399, 505)

        Panel7.Location = New Drawing.Point(5, 3)

        Panel7.Size = New Drawing.Size(385, 402)

        Panel10.Visible = False
        Panel7.Visible = True

        RamMonitor.Stop()
        ProcesorMonitorII.Stop()
        ProcessorMonitor.Stop()

        Panel8.BackColor = Color.WhiteSmoke
        Panel9.BackColor = Color.Silver
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click, Panel9.Click, Label2.Click
        Me.Size = New Drawing.Size(568, 567)

        Panel10.Location = New Drawing.Point(8, 8)

        Panel10.Size = New Drawing.Size(540, 437)


        Panel10.Visible = True
        Panel7.Visible = False

        RamMonitor.Start()
        ProcesorMonitorII.Start()
        ProcessorMonitor.Start()

        Panel9.BackColor = Color.WhiteSmoke
        Panel8.BackColor = Color.Silver
    End Sub

    Dim AppToChange As String

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        KillApp(AppToChange)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Index = ListView1.SelectedItems(0).Index
            AppToChange = ListView1.SelectedItems(0).ToolTipText
        Catch ex As Exception

        End Try


    End Sub


    Dim MyNum As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount")

    Sub MyIconInTaskbar()

        MyNum = Val(MyNum) + 1

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\Process\ProcessCount", Val(MyNum))

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTaskBar\AppConfig\ProcessNum", Val(MyNum))

    End Sub


    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        IO.File.WriteAllText("N:\Nexus\AppWork\NxProcessManage\IsRun", "False")

        Close_Me("TaskManager")


    End Sub

    Private Sub Timer1_Tick_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim ShowMe As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxProcessManage\Shown")


        If ShowMe = "False" Then
            Me.Hide()
            IO.File.WriteAllText("N:\Nexus\AppWork\NxProcessManage\Shown", "")
        Else
            If ShowMe = "True" Then
                Me.Show()
                Me.BringToFront()
                IO.File.WriteAllText("N:\Nexus\AppWork\NxProcessManage\Shown", "")
            End If
        End If

    End Sub

   
    Private Sub TraerAlFrenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TraerAlFrenteToolStripMenuItem.Click
      
        BackGroundToForeGround(AppToChange)


    End Sub

    Dim percente As Integer = 0

    Private Sub Panel26_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel26.Paint
        e.Graphics.Clear(CType(sender, Panel).BackColor)

        If percente >= 90 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, percente, 13, Color.Red, 10, 5)

        ElseIf percente > 80 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, percente, 13, Color.Orange, 10, 5)

        ElseIf percente > 70 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, percente, 13, Color.Yellow, 10, 5)

        Else

            CircularDraw(sender, CType(sender, Panel).Size, e, percente, 13, Color.Blue, 10, 5)
        End If

    End Sub

    Dim ProPercent As Integer

    Private Sub Panel27_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel27.Paint
        e.Graphics.Clear(CType(sender, Panel).BackColor)

        If ProPercent >= 90 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, ProPercent, 13, Color.Red, 10, 5)

        ElseIf ProPercent > 80 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, ProPercent, 13, Color.Orange, 10, 5)

        ElseIf ProPercent > 70 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, ProPercent, 13, Color.Yellow, 10, 5)

        Else

            CircularDraw(sender, CType(sender, Panel).Size, e, ProPercent, 13, Color.Blue, 10, 5)
        End If
    End Sub

    Dim Core1, Core2, Core3, Core4 As Integer

    Private Sub Panel29_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel29.Paint
        e.Graphics.Clear(CType(sender, Panel).BackColor)

        If Core1 >= 90 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core1, 9, Color.Red, 5, 2)

        ElseIf Core1 > 80 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core1, 9, Color.Orange, 5, 2)

        ElseIf Core1 > 70 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core1, 9, Color.Yellow, 5, 2)

        Else

            CircularDraw(sender, CType(sender, Panel).Size, e, Core1, 9, Color.Blue, 5, 2)
        End If
    End Sub

    Private Sub Panel30_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel30.Paint
        e.Graphics.Clear(CType(sender, Panel).BackColor)

        If Core2 >= 90 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core2, 9, Color.Red, 5, 2)

        ElseIf Core2 > 80 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core2, 9, Color.Orange, 5, 2)

        ElseIf Core2 > 70 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core2, 9, Color.Yellow, 5, 2)

        Else

            CircularDraw(sender, CType(sender, Panel).Size, e, Core2, 9, Color.Blue, 5, 2)
        End If
    End Sub

    Private Sub Panel31_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel31.Paint
        e.Graphics.Clear(CType(sender, Panel).BackColor)

        If Core3 >= 90 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core3, 9, Color.Red, 5, 2)

        ElseIf Core3 > 80 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core3, 9, Color.Orange, 5, 2)

        ElseIf Core3 > 70 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core3, 9, Color.Yellow, 5, 2)

        Else

            CircularDraw(sender, CType(sender, Panel).Size, e, Core3, 9, Color.Blue, 5, 2)
        End If
    End Sub

    Private Sub Panel32_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel32.Paint
        e.Graphics.Clear(CType(sender, Panel).BackColor)

        If Core4 >= 90 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core4, 9, Color.Red, 5, 2)

        ElseIf Core4 > 80 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core4, 9, Color.Orange, 5, 2)

        ElseIf Core4 > 70 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Core4, 9, Color.Yellow, 5, 2)

        Else

            CircularDraw(sender, CType(sender, Panel).Size, e, Core4, 9, Color.Blue, 5, 2)
        End If
    End Sub

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel2.BackColor = Color.DarkGray
        Panel3.BackColor = Color.DarkGray
        Panel4.BackColor = Color.DarkGray
    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel2.BackColor = SystmColor
        Panel3.BackColor = SystmColor
        Panel4.BackColor = SystmColor
    End Sub

End Class
