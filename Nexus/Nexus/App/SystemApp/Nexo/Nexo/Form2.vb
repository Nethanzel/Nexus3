Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Interval = 1
        Label1.BackColor = Color.FromArgb(1, Me.BackColor)

    End Sub

    Dim WithEvents Timer1 As New Timer

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Form1.Focus()

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Vero\IsRun", "False")

        End
    End Sub
End Class