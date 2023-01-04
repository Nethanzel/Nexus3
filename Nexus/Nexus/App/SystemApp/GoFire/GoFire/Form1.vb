Public Class Form1



    Dim Counter As Integer = 0

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim Contains As String = TextBox1.Text

        Counter = Counter + 1


        If Counter = 1 Then

            TextBox1.Text += "                      Smart World Technologies © 2017"

        ElseIf Counter = 3 Then
            TextBox1.Clear()


            TextBox1.Text += "                               FireLine v2.0" & vbNewLine
            TextBox1.Text += Contains
        ElseIf Counter = 5 Then
            TextBox1.Clear()

            'TextBox1.Text += vbNewLine & vbNewLine
            TextBox1.Text += vbNewLine & "Ready..." & vbNewLine & vbNewLine
            TextBox1.Text += "                              Nexus OSS v3.0" & vbNewLine
            TextBox1.Text += Contains

            TextBox2.Focus()

            Timer1.Stop()
        End If

    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Gfire", "True")
            Load_Me("GoFire", PictureBox5.Image, ListenNumber)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Gfire", "False")
            Close_Me("GoFire")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        If maximised = True Then
            NotMaximiced()
        End If
        Me.Close()
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

            If maximised = True Then

                NotMaximiced()
                maximised = False
                Me.Size = Msize

            End If

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If

    End Sub

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel2.BackColor = Color.DarkGray

    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor
        Panel2.BackColor = SystmColor

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

            Dim Log As String = TextBox1.Text

            TextBox1.Clear()
            TextBox1.Text = TextBox2.Text & vbNewLine & vbNewLine & Log
            TextBox2.Clear()

            GoFire(TextBox1, Me, TextBox2)
        End If

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Hide()
    End Sub

    Dim Msize As Point = Nothing
    Public maximised As Boolean = False

    Private Sub Form1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

        If Me.Visible = True Then

            If maximised = True Then
                Maximiced()

            End If

        Else
            If maximised = True Then
                NotMaximiced()
            End If

        End If

    End Sub



    Sub Maximiced()

        Dim Value As String

        Try
            Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
        Catch ex As Exception
            Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")

        End Try

        Dim X As Integer = Val(Value) + 1

        Try
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
        Catch ex As Exception
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))

        End Try

    End Sub


    Sub NotMaximiced()

        Dim Value As String

        Try
            Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
        Catch ex As Exception
            Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
        End Try

        Dim X As Integer = Val(Value) - 1

        Try
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
        Catch ex As Exception
            IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
        End Try


    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Maximiced()

        Msize = Me.Size


        Dim lX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim lY As Integer = My.Computer.Screen.WorkingArea.Height

        Me.Left = 0
        Me.Top = 0

        Me.Width = lX / 2
        Me.Height = lY - 11

        maximised = True
        Me.MaximumSize = Me.Size
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged

        If maximised = True Then

            NotMaximiced()
            maximised = False

        End If

    End Sub
End Class
