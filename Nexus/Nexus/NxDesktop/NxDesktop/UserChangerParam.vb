Public Class UserChangerParam

    Private Sub UserChangerParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UserToLog(uClick_Str)

    End Sub


    Sub UserToLog(ByVal User As String)

        'If User = 1 Then

        Label1.Text = User 'Admin
        TextBox1.Text = User 'Admin
        Label2.Text = UserAcces 'AdTipe
        PictureBox1.BackgroundImage = UserImg 'ImgAd


        'ElseIf User = 2 Then

        'Label1.Text = UserName
        'TextBox1.Text = UserName
        'Label2.Text = UserAcces
        'PictureBox1.BackgroundImage = UserImg


        'ElseIf User = 3 Then

        'Label1.Text = user2
        'TextBox1.Text = user2
        'Label2.Text = U2Tipe
        'PictureBox1.BackgroundImage = ImgU2

        'End If

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

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Close()
    End Sub

    Dim EditMode As Boolean = False

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click


        If EditMode = True Then
            TextBox1.Enabled = False

            PictureBox3.Image = My.Resources.pencil


            EditMode = False
        Else

            TextBox1.Clear()
            TextBox1.Enabled = True
            TextBox1.Focus()
            PictureBox3.Image = My.Resources.MsgEstulyGood

            EditMode = True

        End If


    End Sub

    Dim EditModeForPassW As Boolean = False

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click


        If EditModeForPassW = True Then
            TextBox2.Enabled = False
            TextBox4.Enabled = False
            PictureBox4.Image = My.Resources.pencil

            EditModeForPassW = False
        Else

            TextBox2.Clear()
            TextBox2.Enabled = True
            TextBox4.Enabled = True
            TextBox2.Focus()
            PictureBox4.Image = My.Resources.MsgEstulyGood

            EditModeForPassW = True

        End If

    End Sub



    Sub UserSaveConfig(ByVal User As String)

        Dim fInfo As IO.FileInfo
        Dim NewImage As Image = PictureBox1.BackgroundImage

        ' If User = 1 Then
        StartMenu.PictureBox1.BackgroundImage.Dispose()
        LoginLookScreen.PictureBox2.BackgroundImage.Dispose()
        UserImg.Dispose()

        For Each File As String In My.Computer.FileSystem.GetFiles(UsersPath & "\" & User)
            fInfo = My.Computer.FileSystem.GetFileInfo(File)

            If fInfo.Name.Contains("uImage") Then
                My.Computer.FileSystem.DeleteFile(File)
                fInfo = My.Computer.FileSystem.GetFileInfo(PictureBox1.Tag)
                'My.Computer.FileSystem.CopyFile(PictureBox1.Tag, "N:\NexusFrameWork\Users\Admin\uImage" & fInfo.Extension)

                NewImage.Save(UsersPath & "\" & User & "\uImage" & fInfo.Extension)
            End If
        Next

        'ElseIf User = 2 Then

        'StartMenu.PictureBox1.BackgroundImage.Dispose()
        'LoginLookScreen.PictureBox1.BackgroundImage.Dispose()
        'UserImg.Dispose()

        'For Each File As String In My.Computer.FileSystem.GetFiles("N:\NexusFrameWork\Users\User1")
        '    fInfo = My.Computer.FileSystem.GetFileInfo(File)

        '    If fInfo.Name.Contains("uImage") Then
        '        My.Computer.FileSystem.DeleteFile(File)
        '        fInfo = My.Computer.FileSystem.GetFileInfo(PictureBox1.Tag)
        '        ' My.Computer.FileSystem.CopyFile(PictureBox1.Tag, "N:\NexusFrameWork\Users\User1\uImage" & fInfo.Extension)

        '        NewImage.Save("N:\NexusFrameWork\Users\User1\uImage" & fInfo.Extension)

        '    End If
        'Next


        'ElseIf User = 3 Then

        'StartMenu.PictureBox1.BackgroundImage.Dispose()
        'LoginLookScreen.PictureBox3.BackgroundImage.Dispose()
        'ImgU2.Dispose()

        'For Each File As String In My.Computer.FileSystem.GetFiles("N:\NexusFrameWork\Users\User2")
        '    fInfo = My.Computer.FileSystem.GetFileInfo(File)

        '    If fInfo.Name.Contains("uImage") Then
        '        My.Computer.FileSystem.DeleteFile(File)
        '        fInfo = My.Computer.FileSystem.GetFileInfo(PictureBox1.Tag)
        '        'My.Computer.FileSystem.CopyFile(PictureBox1.Tag, "N:\NexusFrameWork\Users\User2\uImage" & fInfo.Extension)

        '        NewImage.Save("N:\NexusFrameWork\Users\User2\uImage" & fInfo.Extension)

        '    End If
        'Next


        'End If

        GetImages()

        reValue()

        Desktop.UserToLog(uClick_Str)

    End Sub

    Dim ImagChange As Boolean = False

    Private Sub LinkLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel1.Click

        Dim ImgOpenDialog As New OpenFileDialog

        ImgOpenDialog.Multiselect = False
        ImgOpenDialog.Title = "Seleccionar imagen..."
        ImgOpenDialog.FileName = ""

        If ImgOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            PictureBox1.BackgroundImage = Image.FromFile(ImgOpenDialog.FileName)
            PictureBox1.Tag = ImgOpenDialog.FileName
            ImagChange = True
        End If


    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        If ImagChange = True Then
            ImagChange = False
            UserSaveConfig(uClick_Str)
        End If
        '__________________________________________________________________________________________

        If TextBox1.Text = StartMenu.Label1.Text Then

            MsgBox("Ingrese un nuevo nombre. Este es igual al actual.")

        ElseIf TextBox1.Text = Nothing Then

            MsgBox("Ingrese un nuevo nombre.")

        Else

            'If uClick_Int = 1 Then
            IO.File.WriteAllText(UsersPath & "\" & uClick_Str & "\Name", EncriptIt(TextBox1.Text))
            reValue()
            Desktop.UserToLog(uClick_Str)
            Label1.Text = UserName

            'End If


            'If uClick_Int = 2 Then
            '    IO.File.WriteAllText("N:\NexusFrameWork\Users\User1\Name", EncriptIt(TextBox1.Text))
            '    reValue()
            '    Desktop.UserToLog(uClick_Int)
            '    Label1.Text = UserName
            'End If


            'If uClick_Int = 3 Then
            '    IO.File.WriteAllText("N:\NexusFrameWork\Users\User2\Name", EncriptIt(TextBox1.Text))
            '    reValue()
            '    Desktop.UserToLog(uClick_Int)
            '    Label1.Text = user2
            'End If

        End If

        '__________________________________________________________________________________________


        If TextBox2.Text = TextBox4.Text And TextBox2.Text.Length > 1 Then

            'If uClick_Int = 1 And TextBox3.Text = AdPass Then
            IO.File.WriteAllText(UsersPath & "\" & uClick_Str & "\Password", EncriptIt(TextBox2.Text))

            'End If

            'If uClick_Int = 2 And TextBox3.Text = UserKey Then

            '    IO.File.WriteAllText("N:\NexusFrameWork\Users\User1\Password", EncriptIt(TextBox2.Text))
            'End If

            'If uClick_Int = 3 And TextBox3.Text = U2Pass Then
            '    IO.File.WriteAllText("N:\NexusFrameWork\Users\User2\Password", EncriptIt(TextBox2.Text))

            'End If

        Else
            'Las claves no son iguales


        End If
    End Sub

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
       
    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor


    End Sub


   
End Class