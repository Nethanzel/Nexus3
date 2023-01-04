Public Class Form2

    Dim Sep As Char

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()

    End Sub



    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
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

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = "Valor del Log: " & ValueLog

        Label4.Text = "Tipo de valor: " & TipeLog

        If Label2.Text.Length > 71 Then
            Label2.Text = Label2.Text.Substring(0, 70) & "..."
        End If

        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If TipeLog = "Ubicacion de archivo" And TextBox1.Text.Contains("\") Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Falso o Verdadero (True or False)" And TextBox1.Text = "True" Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Falso o Verdadero (True or False)" And TextBox1.Text = "False" Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Estado -Play-, -Pause-, -Stopped-" And TextBox1.Text = "Play" Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Estado -Play-, -Pause-, -Stopped-" And TextBox1.Text = "Pause" Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Estado -Play-, -Pause-, -Stopped-" And TextBox1.Text = "Stopped" Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Numerico, no mayor a 31" And Val(TextBox1.Text) <= 31 Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Numerico, no mayor a 23" And Val(TextBox1.Text) <= 23 Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Numerico, no mayor a 59" And Val(TextBox1.Text) <= 59 Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Numerico, no menor a 2000" And Val(TextBox1.Text) >= 2000 Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "Numerico, no mayor a 12" And Val(TextBox1.Text) <= 12 Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        ElseIf TipeLog = "<Unknown Value>" Then
            IO.File.WriteAllText(LogToEdit, TextBox1.Text)
            Me.Close()

        Else


            Label3.Text = Label3.Text & "   <Nuevo valor: Mal ingresado respecto al tipo de valor.>"


        End If





        TextBox1.Clear()



    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If OnlyNumbers = True Then
            If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End If

    End Sub
End Class