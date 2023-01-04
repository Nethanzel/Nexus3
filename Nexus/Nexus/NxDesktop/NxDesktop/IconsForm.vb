Public Class IconsForm

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Me.Left = Desktop.Panel19.Left - 2
        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 12)
        Me.Size = New Drawing.Size(90, 34)


    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.BackColor = SystmColor
    End Sub



End Class