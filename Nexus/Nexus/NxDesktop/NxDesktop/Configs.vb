Public Class Configs


    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Close()
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

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click, Panel6.Click, Label1.Click

        Panel5.Dock = DockStyle.Fill
        Panel5.Visible = True
        Panel9.Visible = False

        Panel6.BackColor = Color.DarkGray
        Panel8.BackColor = Color.LightGray

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click, Panel8.Click, Label2.Click
        Panel9.Dock = DockStyle.Fill
        Panel9.Visible = True
        Panel5.Visible = False


        Panel8.BackColor = Color.DarkGray
        Panel6.BackColor = Color.LightGray
    End Sub


    Private Sub Panel13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Desktop.Panel1.BackColor = Color.FromArgb(ColorValor, Panel13.BackColor)
        Desktop.Panel14.BackColor = Color.FromArgb(ColorValor, Panel13.BackColor)
    End Sub

    Private Sub Panel14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Desktop.Panel1.BackColor = Color.FromArgb(ColorValor, Panel14.BackColor)
        Desktop.Panel14.BackColor = Color.FromArgb(ColorValor, Panel14.BackColor)
    End Sub

    Private Sub Panel18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Desktop.Panel1.BackColor = Color.FromArgb(ColorValor, Panel18.BackColor)
        Desktop.Panel14.BackColor = Color.FromArgb(ColorValor, Panel18.BackColor)
    End Sub

    Private Sub Panel21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Desktop.Panel1.BackColor = Color.FromArgb(ColorValor, Panel21.BackColor)
        Desktop.Panel14.BackColor = Color.FromArgb(ColorValor, Panel21.BackColor)
    End Sub

    Private Sub Panel16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Desktop.Panel1.BackColor = Color.FromArgb(ColorValor, Panel16.BackColor)
        Desktop.Panel14.BackColor = Color.FromArgb(ColorValor, Panel16.BackColor)
    End Sub


    Public ColorValor As Integer

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Desktop.Panel1.BackColor = Color.FromArgb(TrackBar1.Value, Desktop.Panel1.BackColor)
        Desktop.Panel14.BackColor = Color.FromArgb(TrackBar1.Value, Desktop.Panel1.BackColor)

        ColorValor = TrackBar1.Value


    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Desktop.BackgroundImage = Nothing
    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text = "Proporcional" Then
            Desktop.BackgroundImageLayout = ImageLayout.Zoom
            Desktop.Refresh()
            IO.File.WriteAllText(SvConfig & "BgForm", "2")
        ElseIf ComboBox1.Text = "Ajustado" Then
            Desktop.BackgroundImageLayout = ImageLayout.Stretch
            Desktop.Refresh()
            IO.File.WriteAllText(SvConfig & "BgForm", "1")
        ElseIf ComboBox1.Text = "Mozaicos" Then
            Desktop.BackgroundImageLayout = ImageLayout.Tile
            Desktop.Refresh()
            IO.File.WriteAllText(SvConfig & "BgForm", "3")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PictureBox3.Image = Image.FromFile(OpenFileDialog1.FileName)

                Button2.Enabled = True

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Configs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox3.Image = Desktop.BackgroundImage
    End Sub



    Sub RefreshUserBg()

        Dim fInfo As IO.FileInfo
        bGround.Dispose()

        'If uClick_Int = 1 Then

        For Each File As String In My.Computer.FileSystem.GetFiles(UsersPath & "\" & uClick_Str & "\bGround")
            fInfo = My.Computer.FileSystem.GetFileInfo(File)

            If fInfo.Name.Contains("bGimage") Then
                My.Computer.FileSystem.DeleteFile(File)
                fInfo = My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName)
                My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, UsersPath & "\" & uClick_Str & "\bGround\bGimage" & fInfo.Extension)

            End If
        Next

        'ElseIf uClick_Int = 2 Then
        'For Each File As String In My.Computer.FileSystem.GetFiles("N:\NexusFrameWork\Users\User1\bGround")
        '    fInfo = My.Computer.FileSystem.GetFileInfo(File)

        '    If fInfo.Name.Contains("bGimage") Then
        '        My.Computer.FileSystem.DeleteFile(File)
        '        fInfo = My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName)
        '        My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, "N:\NexusFrameWork\Users\User1\bGround\bGimage" & fInfo.Extension)

        '    End If
        'Next

        'ElseIf uClick_Int = 3 Then

        'For Each File As String In My.Computer.FileSystem.GetFiles("N:\NexusFrameWork\Users\User2\bGround")
        '    fInfo = My.Computer.FileSystem.GetFileInfo(File)

        '    If fInfo.Name.Contains("bGimage") Then
        '        My.Computer.FileSystem.DeleteFile(File)
        '        fInfo = My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName)
        '        My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, "N:\NexusFrameWork\Users\User2\bGround\bGimage" & fInfo.Extension)

        '    End If
        'Next

        'End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Button2.Enabled = False
            Desktop.BackgroundImage = PictureBox3.Image

            Desktop.Refresh()

            RefreshUserBg()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel25_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel40.Paint, Panel39.Paint, Panel36.Paint, Panel35.Paint, Panel34.Paint, Panel33.Paint, Panel32.Paint, Panel31.Paint, Panel30.Paint, Panel29.Paint, Panel28.Paint, Panel27.Paint, Panel26.Paint, Panel25.Paint
        CircleImg(CType(sender, Panel), e)

    End Sub

    Private Sub Panel38_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel38.Paint, Panel37.Paint, Panel24.Paint, Panel23.Paint, Panel22.Paint, Panel21.Paint, Panel20.Paint, Panel19.Paint, Panel18.Paint, Panel17.Paint, Panel16.Paint, Panel15.Paint, Panel14.Paint, Panel13.Paint
        CircleImg(CType(sender, Panel), e)
    End Sub

    Private Sub Panel41_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel42.Paint, Panel41.Paint
        CircleImg(CType(sender, Panel), e)
    End Sub

    Private Sub Panel43_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel44.Paint, Panel43.Paint
        CircleImg(CType(sender, Panel), e)
    End Sub

    Private Sub TrackBar1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseUp

        'If uClick_Int = 1 Then

        Dim This As String = UsersPath & "\" & uClick_Str & "\Configs\TskOpc"
        IO.File.WriteAllText(This, CStr(TrackBar1.Value))

        'ElseIf uClick_Int = 2 Then

        'Dim This As String = UserPath & "\User1\Configs\TskOpc"
        'IO.File.WriteAllText(This, CStr(TrackBar1.Value))

        'ElseIf uClick_Int = 3 Then

        'Dim This As String = UserPath & "\User2\Configs\TskOpc"
        'IO.File.WriteAllText(This, CStr(TrackBar1.Value))

        'End If

    End Sub

    Private Sub Panel38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel38.Click, Panel37.Click, Panel24.Click, Panel23.Click, Panel22.Click, Panel21.Click, Panel20.Click, Panel19.Click, Panel18.Click, Panel17.Click, Panel16.Click, Panel15.Click, Panel14.Click, Panel13.Click

        'If uClick_Int = 1 Then

        Dim This As String = UsersPath & "\" & uClick_Str & "\Configs\TskColor"
        IO.File.WriteAllText(This, CStr(CType(sender, Panel).BackColor.Name))
        IO.File.WriteAllText(UsersPath & "\" & uClick_Str & "\Configs\SysColr", CStr(CType(sender, Panel).BackColor.ToArgb))
        Desktop.Panel1.BackColor = Color.FromArgb(ColorValor, CType(sender, Panel).BackColor)
        Desktop.Panel14.BackColor = Color.FromArgb(ColorValor, CType(sender, Panel).BackColor)

        'ElseIf uClick_Int = 2 Then

        'Dim This As String = UserPath & "\User1\Configs\TskColor"
        'IO.File.WriteAllText(UserPath & "\User1\Configs\SysColr", CStr(CType(sender, Panel).BackColor.ToArgb))
        'IO.File.WriteAllText(This, CStr(CType(sender, Panel).BackColor.Name))
        'Desktop.Panel1.BackColor = Color.FromArgb(ColorValor, CType(sender, Panel).BackColor)
        'Desktop.Panel14.BackColor = Color.FromArgb(ColorValor, CType(sender, Panel).BackColor)
        'ElseIf uClick_Int = 3 Then

        'Dim This As String = UserPath & "\User2\Configs\TskColor"
        'IO.File.WriteAllText(UserPath & "\User2\Configs\SysColr", CStr(CType(sender, Panel).BackColor.ToArgb))
        'IO.File.WriteAllText(This, CStr(CType(sender, Panel).BackColor.Name))
        'Desktop.Panel1.BackColor = Color.FromArgb(ColorValor, CType(sender, Panel).BackColor)
        'Desktop.Panel14.BackColor = Color.FromArgb(ColorValor, CType(sender, Panel).BackColor)
        'End If

        SystmColor = CType(sender, Panel).BackColor

    End Sub

    Private Sub Panel25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel40.Click, Panel39.Click, Panel36.Click, Panel35.Click, Panel34.Click, Panel33.Click, Panel32.Click, Panel31.Click, Panel30.Click, Panel29.Click, Panel28.Click, Panel27.Click, Panel26.Click, Panel25.Click

        'If uClick_Int = 1 Then

        Dim This As String = UsersPath & "\" & uClick_Str & "\Configs\BgColor"
        IO.File.WriteAllText(This, CStr(CType(sender, Panel).BackColor.Name))
        Desktop.BackColor = Color.FromArgb(255, CType(sender, Panel).BackColor)
        Desktop.BackColor = Color.FromArgb(255, CType(sender, Panel).BackColor)

        'ElseIf uClick_Int = 2 Then

        'Dim This As String = UserPath & "\User1\Configs\BgColor"
        'IO.File.WriteAllText(This, CStr(CType(sender, Panel).BackColor.Name))
        'Desktop.BackColor = Color.FromArgb(255, CType(sender, Panel).BackColor)
        'Desktop.BackColor = Color.FromArgb(255, CType(sender, Panel).BackColor)
        'ElseIf uClick_Int = 3 Then

        'Dim This As String = UserPath & "\User2\Configs\BgColor"
        'IO.File.WriteAllText(This, CStr(CType(sender, Panel).BackColor.Name))
        'Desktop.BackColor = Color.FromArgb(255, CType(sender, Panel).BackColor)
        'Desktop.BackColor = Color.FromArgb(255, CType(sender, Panel).BackColor)
        'End If
    End Sub


    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel2.BackColor = Color.DarkGray

    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor
        Panel2.BackColor = SystmColor

    End Sub

   
End Class