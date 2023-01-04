Public Class StartMenu

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)

        X1(Me.Panel4)

        Me.Left = 7
        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 12)
    End Sub

    Public Cr As Boolean = False


    Private Sub Panel13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel13.Click

        Dim eValue As String = IO.File.ReadAllText(AppWork & "\Interface\Gfire")

        If eValue = "False" Then

            Process.Start("N:\Nexus\App\SystemApp\GoFire\GoFire\bin\Debug\Fireline.exe")

        End If

        Me.Hide()

    End Sub

    Private Sub Panel11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel11.Click
        Cursor.Hide()

        HideApps()

        Telon.Show()
        Me.Hide()

        ToWhat_I_Do = 2


    End Sub


    Sub This4()
        Speak("Notifier", "*", "W")
    End Sub


    Private Sub Panel10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel10.Click

        Dim Xpr As New Threading.Thread(AddressOf This4)
        Xpr.Start()

        HideApps2()

        Cursor.Hide()
        Telon.Show()
        Me.Hide()

        ToWhat_I_Do = 3
        Me.Opacity = 0%

    End Sub


    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If TextBox1.Text = "Que buscas?...." Then

            TextBox1.Clear()


        End If
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If TextBox1.Text.Length < 1 Then
            TextBox1.ForeColor = Color.Gray
            TextBox1.Text = "Que buscas?...."

        ElseIf TextBox1.Text = "Que buscas?...." Then
            TextBox1.ForeColor = Color.Gray

        Else
            TextBox1.ForeColor = Color.Black
        End If


    End Sub


    Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        CircleImgPic(Me.PictureBox1, e)
    End Sub

    Private Sub PictureBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint
        CircleImgPic(Me.PictureBox2, e)
    End Sub

    Private Sub Panel14_Paint(sender As Object, e As PaintEventArgs) Handles Panel14.Paint
        CircleImg(Me.Panel14, e)
    End Sub

    Private Sub StartMenu_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        Me.Left = 2
        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 12)

        If Me.Visible = False Then
            Panel15.Width = 32
            Ot = False
        End If

        Panel2.BackColor = Color.FromArgb(55, SystmColor)
        Panel1.BackColor = Color.FromArgb(30, SystmColor)

    End Sub

    


    Private Sub Panel13_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel13.MouseLeave, Panel12.MouseLeave, Panel11.MouseLeave, Panel10.MouseLeave
        CType(sender, Panel).BackColor = Color.Transparent

    End Sub

    Private Sub Panel13_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel13.MouseHover, Panel12.MouseHover, Panel11.MouseHover, Panel10.MouseHover
        CType(sender, Panel).BackColor = SystmColor

    End Sub


    Dim Ot As Boolean = False

    Private Sub Panel12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel12.Click

        If Ot = False Then

            Do While Panel15.Width < 100

                Panel15.Width = Panel15.Width + 2
                Application.DoEvents()
            Loop

            Ot = True

        ElseIf Ot = True Then

            'Run the shutdown here

            Do While Panel15.Width > 32

                Panel15.Width = Panel15.Width - 2
                Application.DoEvents()
            Loop

            Ot = False

        End If

    End Sub
   

    Private Sub Panel12_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel12.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then

            If Ot = True Then
                Do While Panel15.Width > 32

                    Panel15.Width = Panel15.Width - 2
                    Application.DoEvents()
                Loop

                Ot = False

            End If

        End If
    End Sub

   
    Private Sub Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click
        UserChangerParam.Show()
        Me.Hide()
    End Sub
End Class