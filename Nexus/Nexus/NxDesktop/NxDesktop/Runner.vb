Public Class Runner

    Private Sub Runner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 5
        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 15)

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text.ToLower = "logeditor" Then

            Dim Isrun As String = IO.File.ReadAllText(AppWork & "\NxLogEditor\IsRun")

            If Isrun = "False" Then

                Process.Start("N:\Nexus\App\SystemApp\NxLogEditor\NxLogEditor\bin\Debug\NxLogEditor.exe")
                Me.Close()
            End If

        End If
    End Sub

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray


    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor


    End Sub

End Class