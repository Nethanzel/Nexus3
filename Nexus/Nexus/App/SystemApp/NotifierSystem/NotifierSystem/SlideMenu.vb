Public Class SlideMenu

   
   
    Private Sub SlideMenu_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

        If Me.Visible = True Then
            Me.Focus()
            Me.Height = My.Computer.Screen.WorkingArea.Height - 30
            Me.Top = ((My.Computer.Screen.WorkingArea.Height / 2) - (Me.Height / 2)) - 5
            Me.Left = My.Computer.Screen.WorkingArea.Width + 270

        End If

    End Sub
End Class