
Imports ClaseImagenes.Apolo

Public Class Form1

    Dim ImagesHandler As New TratamientoImagenes

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)



    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs)



    End Sub

    Dim Directory As String = ""

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Ext As String = ""
    Dim l As Integer = 0

    Sub Pic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic.Click
        BM1 = Bitmap.FromFile(CType(sender, PictureBox).Tag)
        PictureBox1.Image = BM1

        Dim ImgExt As New IO.FileInfo(CType(sender, PictureBox).Tag)
        Ext = ImgExt.Extension

        cImage = Image.FromFile(CType(sender, PictureBox).Tag)

        Dim thrd As New Threading.Thread(AddressOf LoadFiltersPreview)
        thrd.Start()

    End Sub

    Friend WithEvents Pic As PictureBox

    Public Sub Add_Imgage(ByVal Route As String, ByVal Container As Object)

        Dim separator As New Panel

        l += 1

        separator.Dock = DockStyle.Top
        separator.Height = 5

        Pic = New PictureBox

        Dim Imag As Image = Image.FromFile(Route)

        With Pic

            .Dock = DockStyle.Top
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Silver
            .Image = Imag
            .SizeMode = ImageLayout.Zoom
            .Tag = Route
            .Name = "Panelles" & l
        End With

        AddHandler Pic.Click, AddressOf Pic_Click

        CType(Container, Panel).Controls.Add(Pic)
        Pic.Height = 190

        CType(Container, Panel).Controls.Add(separator)


    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

        IO.File.WriteAllText("N:\Nexus\AppWork\NxPicViewer\Shown", "False")

        Me.Hide()


    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        If maximised = True Then

            maximised = False
            NotMaximiced()

        End If

        Me.Close()
    End Sub

    Dim lSize As Point = Nothing
    Dim maximised As Boolean = Nothing

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

        Maximiced()

        lSize = Me.Size


        Dim lX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim lY As Integer = My.Computer.Screen.WorkingArea.Height

        Me.Left = 0
        Me.Top = 0

        Me.Width = lX
        Me.Height = lY - 11

        maximised = True
        Me.MaximumSize = Me.Size

    End Sub


    '________________________________________________
    Private aaa As Boolean = Nothing
    Private MouseX As Integer = 0
    Private MouseY As Integer = 0
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

            If maximised = True Then

                maximised = False

                Me.Size = New Drawing.Size(lSize)

                NotMaximiced()
            End If

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub

    '________________________________________________________________________
    Dim x As Integer = 0
    Dim y As Integer = 0
    Dim a As Integer = 0
    Dim b As Integer = 0
    Private XY As Point = Nothing
    '________________________________________________________________________


    Private Sub PictureBox6_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        XY.X = CInt(CLng(x))
        XY.Y = CInt(CLng(y))


    End Sub

    Private Sub PictureBox6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Right Or e.Button = Windows.Forms.MouseButtons.Left Then
            'redimensionamos el ancho
            If (Me.Width + (x + e.X)) > 0 Then

                Me.Width = Me.Width + (x + e.X)
            End If
            'redimensionams el alto
            If (Me.Height + (y + e.Y)) > 0 Then

                Me.Height = Me.Height + (y + e.Y)
            End If
        End If

    End Sub


    Dim PicSize As Size = Nothing
    Dim PnlSize As Size = Nothing
    Dim MySize As Size = Nothing

    Private Sub PantallaCompletaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PantallaCompletaToolStripMenuItem.Click

        PicSize = Panel9.Size
        PnlSize = Panel4.Size
        MySize = Me.Size

        Panel5.Visible = False
        Panel4.Visible = False
        Panel1.Visible = False
        Label1.Visible = False

        Me.WindowState = FormWindowState.Maximized

        Panel9.Dock = DockStyle.Fill

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Normal

        Panel5.Visible = True
        Panel4.Visible = True
        Panel1.Visible = True
        Label1.Visible = True

        Me.Size = MySize
        Panel9.Dock = DockStyle.None
        Panel9.Size = PicSize
        Panel9.Anchor = AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top
    End Sub

    Private Sub Form1_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IO.File.WriteAllText("N:\Nexus\AppWork\NxPicViewer\IsRun", "True")

        Load_Me("PicViewer", PictureBox2.Image, ListenNumber)
        a = x
        b = y

        Panel9.AutoScroll = True
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        If maximised = True Then
            maximised = False
            NotMaximiced()

        End If

        Panel9.Anchor = AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top

    End Sub




    Sub SaveChanges()
        Try
            'rImage.Save(ListView1.SelectedItems(0).ToolTipText)
        Catch ex As Exception

        End Try


        AddHandler PictureBox3.Click, AddressOf Form1_Load


    End Sub


    Private Sub CambiarCada5SegToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarCada5SegToolStripMenuItem.Click
        Present5s.Start()

    End Sub

    Private Sub CambiarCada10SegToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarCada10SegToolStripMenuItem.Click
        Present10s.Start()

    End Sub

    Private Sub SiguienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SiguienteToolStripMenuItem.Click
        Try
            ' ListView1.Items(ListView1.SelectedItems(0).Index + 1).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AnteriorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnteriorToolStripMenuItem.Click
        'ListView1.Items(ListView1.SelectedItems(0).Index - 1).Selected = True
    End Sub


    'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Listen.Tick
    '    Dim nFile As String
    '    Dim ReadFile As String
    '    Dim lvElemt As ListViewItem
    '    Dim ImgInfo As IO.FileInfo

    '    Try

    '        nFile = IO.File.ReadAllText("N:\NexusFrameWork\NxPicViewer\nFile")
    '        ReadFile = IO.File.ReadAllText("N:\NexusFrameWork\NxPicViewer\rFile")

    '    Catch ex As Exception

    '    End Try

    '    If ReadFile = "False" Then
    '        IO.File.WriteAllText("N:\NexusFrameWork\NxPicViewer\rFile", "True")

    '        PictureBox1.Image = Image.FromFile(nFile)

    '        ImgInfo = My.Computer.FileSystem.GetFileInfo(nFile)

    '        Dim lImage As Image = Image.FromFile(nFile)

    '        ImageList1.Images.Add(lImage)

    '        lvElemt = New ListViewItem(ImgInfo.Name, ImageList1.Images.Count - 1)
    '        lvElemt.ToolTipText = nFile

    '        ListView1.Items.Add(lvElemt)


    '        Me.Focus()

    '    End If


    'End Sub

    'Private Sub Timer2_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

    '    Dim ShowMe As String = IO.File.ReadAllText("N:\NexusFrameWork\NxPicViewer\Shown")

    '    If ShowMe = "False" Then
    '        Me.Hide()
    '        IO.File.WriteAllText("N:\NexusFrameWork\NxPicViewer\Shown", "")
    '    Else
    '        If ShowMe = "True" Then
    '            Me.Show()
    '            Me.BringToFront()
    '            IO.File.WriteAllText("N:\NexusFrameWork\NxPicViewer\Shown", "")
    '        End If
    '    End If
    'End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Present5s.Stop()
        Present10s.Stop()
    End Sub

    Private Sub ListView1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)


        If e.KeyCode = Keys.Down Then
            Present5s.Stop()
            Present10s.Stop()
        End If

        If e.KeyCode = Keys.Up Then
            Present5s.Stop()
            Present10s.Stop()
        End If

        If e.KeyCode = Keys.Left Then
            Present5s.Stop()
            Present10s.Stop()
        End If

        If e.KeyCode = Keys.Right Then
            Present5s.Stop()
            Present10s.Stop()
        End If

    End Sub


    Dim P5s As Integer = 0

    Private Sub Present5s_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Present5s.Tick

        P5s = P5s + 1

        If P5s = 5 Then

            P5s = 0

            ' ListView1.Items(ListView1.SelectedItems(0).Index + 1).Selected = True

        End If

    End Sub

    Dim P10s As Integer = 0

    Private Sub Present10s_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Present10s.Tick
        P10s = P10s + 1

        If P10s = 10 Then

            P10s = 0

            ' ListView1.Items(ListView1.SelectedItems(0).Index + 1).Selected = True

        End If
    End Sub


    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel2.BackColor = Color.DarkGray
        Panel5.BackColor = Color.DarkGray
    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor
        Panel2.BackColor = SystmColor
        Panel5.BackColor = SystmColor
    End Sub

    Sub Maximiced()

        Dim Value As String

        Try
            Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
        Catch ex As Exception
            Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")

        End Try

        Dim X As Integer = Val(Value) + 1

        Try
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
        Catch ex As Exception
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))

        End Try

    End Sub


    Sub NotMaximiced()

        Dim Value As String

        Try
            Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
        Catch ex As Exception
            Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
        End Try

        Dim X As Integer = Val(Value) - 1

        Try
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
        Catch ex As Exception
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
        End Try


    End Sub

    Public cImage As Image

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Not cImage Is Nothing Then

            Label1.Text = "Alto: " & CInt(cImage.Height) & " pixeles | Ancho: " & CInt(cImage.Width) & " pixeles | Extencion: " & Ext

        End If


    End Sub

    Private Sub Form1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

        If Me.Visible = True Then

            If maximised = True Then
                Maximiced()

            End If

        Else
            If maximised = True Then
                NotMaximiced()
            End If

        End If

    End Sub


    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        If Panel4.Width = 10 Then

            Do While Panel4.Width < 240
                Panel4.Width = Panel4.Width + 5
                Application.DoEvents()
            Loop
            Label3.Text = "<<"
        Else

            Do While Panel4.Width > 10
                Panel4.Width = Panel4.Width - 5
                Application.DoEvents()
            Loop

            Label3.Text = ">>"
        End If


    End Sub


    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

        If Panel8.Width = 255 Then

            Do While Panel8.Width > 0
                Panel8.Width = Panel8.Width - 5
                Application.DoEvents()
            Loop

        End If

    End Sub

    Private Sub Form1_FormClosing_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Close_Me("PicViewer")
        IO.File.WriteAllText("N:\Nexus\AppWork\NxPicViewer\IsRun", "False")
    End Sub

    Private Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Directory = FolderBrowserDialog1.SelectedPath
            ScanDirectory(Directory)
            
        End If
    End Sub


    Public Sub ScanDirectory(ByVal Dir As String)

        Panel6.Visible = False
        Panel6.Controls.Clear()

        Dim Counter As Integer = 0

        For Each Img As String In My.Computer.FileSystem.GetFiles(Dir)

            Dim InfoExt As New IO.FileInfo(Img)

            If InfoExt.Extension.ToLower = ".jpg" Then
                Counter += 1

            ElseIf InfoExt.Extension.ToLower = ".png" Then
                Counter += 1

                Add_Imgage(Img, Panel6)
            ElseIf InfoExt.Extension.ToLower = ".bmp" Then
                Counter += 1

                Add_Imgage(Img, Panel6)
            ElseIf InfoExt.Extension.ToLower = ".tif" Then
                Counter += 1
                Add_Imgage(Img, Panel6)

            ElseIf InfoExt.Extension.ToLower = ".gif" Then
                Counter += 1
                Add_Imgage(Img, Panel6)

            ElseIf InfoExt.Extension.ToLower = ".jpeg" Then
                Counter += 1
                Add_Imgage(Img, Panel6)

            End If

            Label2.Text = Counter & " imagenes cargadas"
            Application.DoEvents()
        Next
        Panel6.Visible = True

    End Sub


    Private Sub PictureBox3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click

        If Panel8.Width = 0 Then

            Do While Panel8.Width < 255
                Panel8.Width = Panel8.Width + 5
                Application.DoEvents()
            Loop

        End If
    End Sub

    Public BM1 As Bitmap 'GUARDA LA IMAGEN INICIAL
    Dim MIX As Integer 'GUARDA LA POSICION INICIAL EN X DEL MOUSE
    Dim MIY As Integer 'GUARDA LA POSICION INICIAL EN Y DEL MOUSE
    Dim MUEVE As Boolean 'CONTROLA EL MOVIMIENTO DEL MOUSE

    Private Sub ZoonInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoonInToolStripMenuItem.Click
        If Not PictureBox1.Image Is Nothing Then
            Dim BM2 As New Bitmap(BM1, PictureBox1.Image.Width * 1.1, PictureBox1.Image.Height * 1.1)
            PictureBox1.Image = BM2
        End If
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomOutToolStripMenuItem.Click
        If Not PictureBox1.Image Is Nothing Then
            Dim BM2 As New Bitmap(BM1, PictureBox1.Image.Width * 0.9, PictureBox1.Image.Height * 0.9)
            PictureBox1.Image = BM2
        End If
    End Sub

    Private Sub ZoomNormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomNormalToolStripMenuItem.Click
        If Not PictureBox1.Image Is Nothing Then
            PictureBox1.Image = BM1
            Panel9.AutoScrollPosition = New Point(0, 0)
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown

        'DETERMINA LA POSICION EN LA QUE SE HA PRESIONADO EL MOUSE
        MIX = e.Location.X
        MIY = e.Location.Y

        MUEVE = True 'SE HA INICIADO EL DESPLAZAMIENTO

    End Sub


    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove

        If MUEVE Then

            'DETERMINA LA DIFERENCIA DE POSICION DEL MOUSE
            Dim DIFX As Integer = (MIX - e.X)
            Dim DIFY As Integer = (MIY - e.Y)

            'NUEVA POSICION DE LAS BARRAS DE SCROLL DEL PANEL
            Panel9.AutoScrollPosition = New Point((DIFX - Panel9.AutoScrollPosition.X), (DIFY - Panel9.AutoScrollPosition.Y))


        End If

    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp

        MUEVE = False 'SE HA TERMINADO EL DESPLAZAMIENTO

    End Sub

    Private Sub PictureBox5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox5.Paint
        Dim pen As Graphics = e.Graphics
        pen.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        pen.DrawString("+", New Font("Microsoft Sans Serif", 20), Brushes.Black, New Point((PictureBox5.Width / 2) - 13, (PictureBox5.Height / 2) - 16))


    End Sub

    Private Sub PictureBox4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox4.Paint
        Dim pen As Graphics = e.Graphics
        pen.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        pen.DrawString("-", New Font("Microsoft Sans Serif", 20), Brushes.Black, New Point((PictureBox5.Width / 2) - 10, (PictureBox5.Height / 2) - 19))
    End Sub

    Private Sub PictureBox5_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseDown
        CType(sender, PictureBox).BackColor = Color.SkyBlue
    End Sub

    Private Sub PictureBox5_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseUp
        CType(sender, PictureBox).BackColor = Color.White
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        CType(sender, PictureBox).BackColor = Color.White
    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        CType(sender, PictureBox).BackColor = Color.SkyBlue
    End Sub

    Private Sub PictureBox7_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox7.MouseUp
        CType(sender, PictureBox).BackColor = Color.White
    End Sub

    Private Sub PictureBox7_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox7.MouseDown
        CType(sender, PictureBox).BackColor = Color.SkyBlue
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        If Not PictureBox1.Image Is Nothing Then
            Dim BM2 As New Bitmap(BM1, PictureBox1.Image.Width * 1.1, PictureBox1.Image.Height * 1.1)
            PictureBox1.Image = BM2
        End If

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        If Not PictureBox1.Image Is Nothing Then
            Dim BM2 As New Bitmap(BM1, PictureBox1.Image.Width * 0.9, PictureBox1.Image.Height * 0.9)
            PictureBox1.Image = BM2
        End If
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click

        PicSize = Panel9.Size
        PnlSize = Panel4.Size
        MySize = Me.Size

        Panel5.Visible = False
        Panel4.Visible = False
        Panel1.Visible = False
        Label1.Visible = False

        Me.WindowState = FormWindowState.Maximized

        Panel9.Dock = DockStyle.Fill

    End Sub


#Region "ImageEdition"

    Dim FilterPictureBox As PictureBox
    Dim ImageLst As List(Of Image)

    Sub LoadFiltersPreview()

        ImageLst = New List(Of Image)
        Application.DoEvents()

        Dim bmp As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EscalaGrises(bmp))


        Dim bmp2 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EfectoAumentarLuz(bmp2))


        Dim bmp3 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EfectoAntigSobreex(bmp3))


        Dim bmp4 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EfectoAumentarRasgos(bmp4))


        Dim bmp5 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EfectoContornoSombreado(bmp5))


        Dim bmp6 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EfectoContornoSombreado2(bmp6))


        Dim bmp7 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EfectoDisminuirRasgos(bmp7))


        Dim bmp8 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EfectoMarino(bmp8))


        Dim bmp9 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.EfectoMarte(bmp9))


        Dim bmp10 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.BlancoNegro(bmp10))


        Dim bmp11 As New Bitmap(PictureBox1.Image)
        ImageLst.Add(ImagesHandler.sepia(bmp11))

       

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Panel10.Controls.Clear()

        For i = 0 To ImageLst.Count - 1

            FilterPictureBox = New PictureBox
            FilterPictureBox.Name = "Filter" & i
            FilterPictureBox.SizeMode = PictureBoxSizeMode.Zoom
            FilterPictureBox.Dock = DockStyle.Top
            FilterPictureBox.Height = 220

            FilterPictureBox.Image = ImageLst.Item(i)

            Panel10.Controls.Add(FilterPictureBox)

        Next
    End Sub

#End Region


End Class

