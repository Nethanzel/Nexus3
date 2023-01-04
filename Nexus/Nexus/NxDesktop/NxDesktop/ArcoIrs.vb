
Public Class ArcoIrs

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel2.BackColor = Color.DarkGray

    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor
        Panel2.BackColor = SystmColor

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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = False Then
            CheckBox1.Text = "Activar"
            TrackBar1.Enabled = False
            Desktop.FondoArcoIris.Stop()
            getbGround()
            Desktop.BackgroundImage = bGround
        Else
            CheckBox1.Text = "Desactivar"
            TrackBar1.Enabled = True
            Desktop.BackgroundImage = Nothing
            Desktop.Panel1.BackColor = Color.FromArgb(255, Desktop.Panel1.BackColor)
            Desktop.FondoArcoIris.Start()

        End If

    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Desktop.FondoArcoIris.Interval = TrackBar1.Value * 10
    End Sub

    Private Sub ArcoIrs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Desktop.FondoArcoIris.Enabled = True Then
            CheckBox1.Checked = True
            CheckBox1.Text = "Desactivar"
            TrackBar1.Enabled = True
            Desktop.FondoArcoIris.Start()
            TrackBar1.Value = Desktop.FondoArcoIris.Interval / 10
        Else
            CheckBox1.Checked = False
            CheckBox1.Text = "Activar"
            TrackBar1.Enabled = False

        End If


    End Sub
End Class