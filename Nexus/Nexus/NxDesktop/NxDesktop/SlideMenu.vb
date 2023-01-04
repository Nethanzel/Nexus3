

Public Class SlideMenu


    Private Sub Panel11_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel9.MouseHover, Panel5.MouseHover, Panel4.MouseHover, Panel3.MouseHover, Panel11.MouseHover

        CType(sender, Panel).BackColor = SystmColor


    End Sub

    Private Sub Panel11_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel9.MouseLeave, Panel5.MouseLeave, Panel4.MouseLeave, Panel3.MouseLeave, Panel11.MouseLeave
        CType(sender, Panel).BackColor = Color.Gainsboro
    End Sub

    Private Sub Panel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel4.Click

        Dim IsRun As String = IO.File.ReadAllText("N:\NexusFrameWork\ScreenRslt\IsRun")

        If IsRun = "False" Then

            Process.Start("N:\System\NxSetResolution\NxSetResolution\bin\Debug\NxSetResolution.exe")
            Desktop.T1.Stop()
            Desktop.T2.Start()

        End If

    End Sub

    Private Sub Panel11_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel9.MouseDown, Panel5.MouseDown, Panel4.MouseDown, Panel3.MouseDown, Panel11.MouseDown
        CType(sender, Panel).BackColor = Color.DimGray
    End Sub

    Private Sub Panel11_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel9.MouseUp, Panel5.MouseUp, Panel4.MouseUp, Panel3.MouseUp, Panel11.MouseUp
        CType(sender, Panel).BackColor = SystmColor
    End Sub

    Private Sub Panel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel5.Click
        UserChangerParam.Show()

        Desktop.T1.Stop()
        Desktop.T2.Start()
    End Sub

    Private Sub Panel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel3.Click
        Configs.Show()

        Desktop.T1.Stop()
        Desktop.T2.Start()
    End Sub

    Private Sub Panel9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel9.Click

        CgClock.Show()

        Desktop.T1.Stop()
        Desktop.T2.Start()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class