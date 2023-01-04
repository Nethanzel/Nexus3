Imports NexusBrowser.cNexusBrowser

Public Class Form1

#Region "Constant Code" 'El codigo de esta region solo se modifica para cambiar el comportamiento del control

    Friend WithEvents NexusBrowser As New NexusBrowser.cNexusBrowser
    Friend WithEvents PicImage As New PictureBox
    Friend ImgPanel As Panel

    Dim nName As Integer = 1

    Sub configureNew(ByVal Target As Uri)

        NexusBrowser = New NexusBrowser.cNexusBrowser

        NexusBrowser.Dock = DockStyle.Fill
        NexusBrowser.Name = "Browser" & nName

        PicImage = New PictureBox
        ImgPanel = New Panel

        PicImage.Name = "Pict" & nName
        PicImage.Dock = DockStyle.Fill
        PicImage.Image = Image.FromFile("N:\Nexus\Resourses\newtab.png")
        PicImage.BackColor = Color.Silver
        PicImage.SizeMode = PictureBoxSizeMode.Zoom
        PicImage.Tag = NexusBrowser.Name

        ImgPanel.Padding = New System.Windows.Forms.Padding(3, 3, 3, 2)
        ImgPanel.Dock = DockStyle.Top
        ImgPanel.Height = 54
        ImgPanel.Controls.Add(PicImage)

        Me.Panel3.Controls.Add(NexusBrowser)
        Me.Panel7.Controls.Add(ImgPanel)

        PicImage.Parent = ImgPanel
        NexusBrowser.BringToFront()
        NexusBrowser.PictureIcon = PicImage
        NexusBrowser.PanelIcon = ImgPanel
        ImgPanel.SendToBack()

        AddHandler NexusBrowser.AddFavorites, AddressOf AddFav

        AddHandler PicImage.Paint, AddressOf PictureBox_Paint
        AddHandler PicImage.MouseLeave, AddressOf PictureBox_MouseLeave
        AddHandler PicImage.MouseHover, AddressOf PictureBox_MouseHover
        AddHandler PicImage.MouseDown, AddressOf PictureBox_MouseDown
        AddHandler PicImage.MouseUp, AddressOf PictureBox_MouseUp
        AddHandler PicImage.MouseClick, AddressOf PictureBox_MouseClick

        nName = nName + 1

        NexusBrowser.NavigateTo(Target)
        SelectedBrowser = NexusBrowser

    End Sub

    Sub AddFav(ByVal sender As NexusBrowser.cNexusBrowser)

        Try

            Dim xcount As Integer = IO.Directory.EnumerateDirectories("N:\Nexus\AppWork\NxWebShip\Fav").Count + 1
            Dim xRout As String = "N:\Nexus\AppWork\NxWebShip\Fav\Record-" & xcount.ToString

            IO.Directory.CreateDirectory(xRout)

            IO.File.WriteAllText(xRout & "\dir", sender.Url.ToString)
            IO.File.WriteAllText(xRout & "\name", sender.DocName)

            Dim pIcon As Image = sender.PictureIcon.Image

            pIcon.Save(xRout & "\icon.png", Drawing.Imaging.ImageFormat.Png)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub AddNewTab(ByVal sender As System.Object) Handles NexusBrowser.NewWindowAdd

        Try
            Dim xTrgt As New Uri(CType(sender, NexusBrowser.cNexusBrowser).target)
            configureNew(xTrgt)
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub PictureBox_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicImage.MouseLeave
        CType(sender, PictureBox).BackColor = Color.Silver

        If Panel8.Visible = True Then
            Panel8.Visible = False
        End If
    End Sub

    Private Sub PictureBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicImage.Paint
        CircleImgPic(CType(sender, PictureBox), e)
    End Sub

    Private Sub PictureBox_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicImage.MouseHover
        CType(sender, PictureBox).BackColor = Color.LightGray
    End Sub

    Private Sub PictureBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicImage.MouseUp
        CType(sender, PictureBox).BackColor = Color.LightGray
    End Sub

    Private Sub PictureBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicImage.MouseDown
        CType(sender, PictureBox).BackColor = Color.WhiteSmoke
    End Sub

    Dim SelectedBrowser As NexusBrowser.cNexusBrowser

    Private Sub PictureBox_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicImage.MouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Panel8.Visible = True
            Panel8.BringToFront()

            Panel8.Location = New Drawing.Point(75, Cursor.Position.Y - (32 + Me.Top) - 5)
            'Panel8.Location = New Drawing.Point(75, CType(sender, PictureBox).Height - e.Y)

            Dim NameControl As String = CType(sender, PictureBox).Tag.ToString

            For Each Ctrl As Control In Me.Panel3.Controls

                If Ctrl.Name = NameControl Then
                    Label1.Text = CType(Ctrl, NexusBrowser.cNexusBrowser).DocName
                    Exit For
                End If
            Next

            Panel8.Width = Label1.Width + 23
            'ContextWindow.Location = New Drawing.Point(Cursor.Position.X, Cursor.Position.Y)

        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

            Dim NameControl As String = CType(sender, PictureBox).Tag.ToString

            For Each Ctrl As Control In Me.Panel3.Controls

                If Ctrl.Name = NameControl Then
                    CType(Ctrl, NexusBrowser.cNexusBrowser).BringToFront()
                    SelectedBrowser = Ctrl
                    Exit Sub
                End If

            Next

        End If

    End Sub


    Private Sub PictureBox3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox10.MouseDown, PictureBox7.MouseDown, PictureBox9.MouseDown, PictureBox4.MouseDown
        CType(sender, PictureBox).BackColor = Color.DodgerBlue
    End Sub

    Private Sub PictureBox3_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox10.MouseUp, PictureBox7.MouseUp, PictureBox9.MouseUp, PictureBox4.MouseUp
        CType(sender, PictureBox).BackColor = Color.Silver
    End Sub

    Private Sub PictureBox3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox10.Paint, PictureBox7.Paint, PictureBox9.Paint, PictureBox4.Paint
        CircleImgPic(CType(sender, PictureBox), e)
    End Sub

    Private Sub PictureBox7_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseHover
        CType(sender, PictureBox).Image = My.Resources.favH
        CType(sender, PictureBox).BackColor = Color.Silver
    End Sub

    Private Sub PictureBox7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseLeave
        CType(sender, PictureBox).Image = My.Resources.FavN
        CType(sender, PictureBox).BackColor = Color.Transparent
    End Sub

    Private Sub PictureBox10_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseHover, PictureBox7.MouseHover, PictureBox9.MouseHover, PictureBox4.MouseHover
        CType(sender, PictureBox).BackColor = Color.Silver
    End Sub

    Private Sub PictureBox10_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseLeave, PictureBox7.MouseLeave, PictureBox9.MouseLeave, PictureBox4.MouseLeave
        CType(sender, PictureBox).BackColor = Color.Transparent
    End Sub


    Private Sub PictureBox12_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox12.Paint
        CircleImgPic(CType(sender, PictureBox), e)
    End Sub

    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If

    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove

        If aaa = True Then


            Dim tmp As Point = New Point

            tmp.X = Me.Location.X + (e.X - MouseX)
            tmp.Y = Me.Location.Y + (e.Y - MouseY)
            Me.Location = tmp
            tmp = Nothing

            If maximised = True Then
                maximised = False
                Me.Size = Msize
            End If

        End If

    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If

    End Sub


    '________________________________________________________________________
    Public x As Integer, y As Integer, a As Integer = x, b As Integer = y
    Public XY As Point
    '________________________________________________________________________

    Dim Msize As Point = Nothing
    Dim maximised As Boolean = False
    Dim Mx As Boolean = False

    Private Sub PictureBox2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        XY.X = CInt(CLng(x))
        XY.Y = CInt(CLng(y))
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Right Or e.Button = Windows.Forms.MouseButtons.Left Then
            'redimensionamos el ancho
            If (Me.Width + (x + e.X)) > 0 Then

                Me.Width = Me.Width + (x + e.X - 10)
            End If
            'redimensionams el alto
            If (Me.Height + (y + e.Y)) > 0 Then

                Me.Height = Me.Height + (y + e.Y - 10)
            End If



        End If

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Close_Me("WebExplorer")
        IO.File.WriteAllText("N:\Nexus\AppWork\NxWebShip\IsRun", "False")


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Load_Me("WebExplorer", PictureBox1.Image, ListenNumber)

        IO.File.WriteAllText("N:\Nexus\AppWork\NxWebShip\IsRun", "True")

        Dim xTrgt As New Uri("http://www.google.com.do")
        configureNew(xTrgt)

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

    Private Sub Form1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

        If Me.Visible = True Then

            If Mx = True Then
                Maximiced()

            End If

        Else
            If Mx = True Then
                NotMaximiced()
            End If

        End If

    End Sub

    Private Sub CaptureForm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged

        If Mx = True Then
            maximised = False
            Mx = False
            NotMaximiced()

        End If

    End Sub

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel2.BackColor = Color.DarkGray
        Panel4.BackColor = Color.DarkGray
        Panel5.BackColor = Color.DarkGray
        NexusBrowser.ControlColor = Color.DarkGray
    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor
        Panel2.BackColor = SystmColor
        Panel4.BackColor = SystmColor
        Panel5.BackColor = SystmColor
        NexusBrowser.ControlColor = SystmColor
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        If Mx = True Then
            NotMaximiced()
        End If

        Me.Hide()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        If Mx = True Then
            NotMaximiced()
        End If

        Me.Close()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Maximiced()

        Dim lX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim lY As Integer = My.Computer.Screen.WorkingArea.Height
        Msize = Me.Size
        maximised = True

        Me.Left = 0
        Me.Top = 0

        Me.Width = lX
        Me.Height = lY - 11


        Me.MaximumSize = Me.Size

        Mx = True
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Try
            SelectedBrowser.ShowFavorites = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PictureBox12_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseLeave
        CType(sender, PictureBox).BackColor = Color.Transparent

        If Panel8.Visible = True Then
            Panel8.Visible = False
        End If
    End Sub


    Private Sub PictureBox12_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseHover
        CType(sender, PictureBox).BackColor = Color.Silver
    End Sub

    Private Sub PictureBox12_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox12.MouseUp
        CType(sender, PictureBox).BackColor = Color.Silver
    End Sub

    Private Sub PictureBox12_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox12.MouseDown
        CType(sender, PictureBox).BackColor = Color.WhiteSmoke
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox12.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim xTrgt As New Uri("http://www.google.com.do")
            configureNew(xTrgt)
        End If

    End Sub

#End Region


    Private Sub PictureBox7_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.DoubleClick
        ContextWindow.ShowDialog()

    End Sub
End Class
