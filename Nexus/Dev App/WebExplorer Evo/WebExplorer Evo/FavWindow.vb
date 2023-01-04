Public Class ContextWindow

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Me.BackColor = Color.DarkGray
       
    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor
        Me.BackColor = SystmColor
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

    Private Sub ContextWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DataGridView1.Rows.Clear()

        For Each Fav As String In IO.Directory.GetDirectories("N:\Nexus\AppWork\NxWebShip\Fav")

            Dim PageIcon As Image = RedimencionarGrafico(Fav & "\icon.png")
            Dim PageTitle As String = IO.File.ReadAllText(Fav & "\name")
            Dim PageDir As String = IO.File.ReadAllText(Fav & "\dir")

            DataGridView1.Rows.Add()

            Dim DTG_Index As Integer = DataGridView1.Rows.Count - 1

            DataGridView1.Rows(DTG_Index).Cells(0).Value = PageIcon
            DataGridView1.Rows(DTG_Index).Cells(1).Value = PageTitle
            DataGridView1.Rows(DTG_Index).Cells(2).Value = PageDir
            DataGridView1.Rows(DTG_Index).Height = 45
            DataGridView1.Rows(DTG_Index).Tag = Fav
        Next

    End Sub


    Private Sub PictureBox3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox3.Paint
        CircleImgPic(CType(sender, PictureBox), e)
    End Sub
End Class