Public Class RemoteDsc



    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
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

    Dim Loading As Integer = 50
    Dim LoadingColor As Color = Color.DodgerBlue

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint

        e.Graphics.Clear(CType(sender, Panel).BackColor)

        CircularDrawLbl(sender, CType(sender, Panel).Size, e, Loading, 20, LoadingColor, 8, 6)

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False

        For Each Disc As String In IO.Directory.GetDirectories(RemoteRecors)

            Dim x As String = IO.File.ReadAllText(Disc & "/Server")

            If TextBox1.Text.ToLower = x.ToLower Then
                MsgBox("Ya esta agregado.")
                Exit Sub
            End If

        Next

        Dim N As Integer
        Dim D As New IO.DirectoryInfo(RemoteRecors)

        If FTP_Conect(TextBox2.Text, TextBox3.Text, TextBox1.Text) = True Then

            N = D.EnumerateFiles.Count + 1
            IO.Directory.CreateDirectory(RemoteRecors & "Disc-" & N)
            IO.File.WriteAllText(RemoteRecors & "Disc-" & N & "/User", TextBox2.Text)
            IO.File.WriteAllText(RemoteRecors & "Disc-" & N & "/Pass", TextBox3.Text)
            IO.File.WriteAllText(RemoteRecors & "Disc-" & N & "/Server", TextBox1.Text)
            IO.File.WriteAllText(RemoteRecors & "Disc-" & N & "/Name", TextBox4.Text)

            MsgBox("Success")
            Me.Close()
        Else

            MsgBox("An error")
            Button1.Enabled = True
        End If

    End Sub
End Class