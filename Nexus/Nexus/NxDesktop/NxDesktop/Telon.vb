Public Class Telon

    Dim NwOpacity As Integer = 0

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If NwOpacity = 0 Then
            Timer1.Stop()
            Me.Close()

        Else
            NwOpacity = NwOpacity - 5
            Me.Opacity = NwOpacity / 100

        End If

    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If NwOpacity = 100 Then
            Timer2.Stop()
            What_I_Do(ToWhat_I_Do)
            Timer1.Start()
        Else
            NwOpacity = NwOpacity + 5
            Me.Opacity = NwOpacity / 100

        End If
    End Sub

   
    Public Sub What_I_Do(ByVal ref As Integer)
        HideFloatTools()

       
        If ref = 1 Then

            Desktop.Show()
            LoginLookScreen.Hide()
            reValue()



        ElseIf ref = 2 Then

            Desktop.Hide()
            LoginLookScreen.Show()
            LoginLookScreen.lookscreen = True
            LoginLookScreen.Panel2.Visible = False
            LoginLookScreen.WhatU_Want()
            LoginLookScreen.Label7.BringToFront()
            LoginLookScreen.Label7.BackColor = Color.White
            LoginLookScreen.Timer4.Start()

            reValue()


        ElseIf ref = 3 Then

            Desktop.Close()
            LoginLookScreen.Show()
            LoginLookScreen.UserChanging()
            LoginLookScreen.lookscreen = False
            LoginLookScreen.WhatU_Want()
            reValue()


        ElseIf ref = 4 Then
            MainWindow.BackgroundImage = My.Resources.SmartWorldTech_

        ElseIf ref = 5 Then
            MainWindow.BackgroundImage = My.Resources.NexusRight

        ElseIf ref = 6 Then
            'MainWindow.Panel1.Visible = True
            'MainWindow.TextBox2.Visible = True

            'MainWindow.Timer4.Start()

        ElseIf ref = 7 Then

            LoginLookScreen.Show()
            MainWindow.Hide()


        End If

    End Sub

    Private Sub Telon_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim x As Integer = My.Computer.Screen.WorkingArea.Width * 0.5
        Dim y As Integer = (My.Computer.Screen.WorkingArea.Height + 40) * 0.5

        Cursor.Position = New Drawing.Point(x, y)

        Cur_Sho()


    End Sub

    Sub Cur_Hid()
        Cursor.Hide()
        Cursor.Hide()
    End Sub

    Sub Cur_Sho()
        Cursor.Show()
        Cursor.Show()
    End Sub

    Private Sub Telon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer2.Start()

        Cur_Hid()

    End Sub
End Class