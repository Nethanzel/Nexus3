Public Class LoginLookScreen

    Dim Clicked As Boolean = False
    Public lookscreen As Boolean = False

    Private Sub LoginLookScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Hide()

        Timer3.Start()

        Label1.BackColor = Color.FromArgb(0, Color.White)
        Label2.BackColor = Color.FromArgb(0, Color.White)
        Label3.BackColor = Color.FromArgb(0, Color.White)
        Label4.BackColor = Color.FromArgb(0, Color.White)
        Label5.BackColor = Color.FromArgb(0, Color.White)
        Label6.BackColor = Color.FromArgb(0, Color.White)
        Label7.BackColor = Color.FromArgb(0, Color.White)

        Panel1.Left = Me.Width / 2 - Panel1.Width / 2
        Panel1.Top = Me.Height / 2 - Panel1.Height / 2

        GetValues()

    End Sub

    Private Sub LoginLookScreen_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Panel1.Left = Me.Width / 2 - Panel1.Width / 2
        Panel1.Top = Me.Height / 2 - Panel1.Height / 2
    End Sub


    Sub GetValues()

        Try





            'Label1.Text = UserName
            'Label4.Text = UserAcces

            'Label2.Text = Admin
            'Label5.Text = AdTipe

            'Label3.Text = user2
            'Label6.Text = U2Tipe


            'PictureBox1.BackgroundImage = UserImg
            'PictureBox2.BackgroundImage = ImgAd
            'PictureBox3.BackgroundImage = ImgU2


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ErrorOnPassWord()

        LineShape1.Visible = True
        LineShape2.Visible = True
        LineShape3.Visible = True
        LineShape4.Visible = True

    End Sub


    Sub GoOnPassWord()

        LineShape1.Visible = False
        LineShape2.Visible = False
        LineShape3.Visible = False
        LineShape4.Visible = False

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click, Panel3.Click, Label4.Click, Label1.Click
        If lookscreen = False Then

            If Clicked = False Then

                uClick_Str = "User1"
                Panel3.BringToFront()
                Timer1.Start()
            Else

                Timer2.Start()
            End If

        Else

            Panel2.Visible = True
            HidePassParam = 0
            Timer4.Start()
            TextBox1.Focus()
        End If

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel5.Click, Label6.Click, Label3.Click, PictureBox3.Click

        If lookscreen = False Then
            If Clicked = False Then

                uClick_Str = "User2"
                Panel5.BringToFront()

                Timer1.Start()
            Else
                Timer2.Start()

            End If

        Else
            Panel2.Visible = True
            HidePassParam = 0
            Timer4.Start()
            TextBox1.Focus()
        End If





    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click, Panel4.Click, Label5.Click, Label2.Click
        If lookscreen = False Then

            If Clicked = False Then

                uClick_Str = "Admin"
                Panel4.BringToFront()
                Timer1.Start()

            Else
                Timer2.Start()

            End If
        Else
            Panel2.Visible = True
            HidePassParam = 0
            Timer4.Start()
            TextBox1.Focus()
        End If


    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

            If TextBox1.Text = DesEncriptIt(UserKey) Then

                GoOnPassWord()
                Label8.Visible = False

                Telon.Show()
                ToWhat_I_Do = 1

                IO.File.WriteAllText(AppWork & "\NxDisckExplorer\SDroot", uClick_Str)
                IO.File.WriteAllText(AppWork & "\Settings\CrrntUser\Name", uClick_Str)
                Panel2.Visible = False

                TextBox1.Clear()

                Cursor.Hide()
            Else
                Label8.Visible = True

                TextBox1.Clear()

                ErrorOnPassWord()
            End If

        End If


    End Sub



    Sub WhatU_Want()

        If lookscreen = True Then

            Panel2.Visible = True
            Label7.Visible = True
        Else
            Panel2.Visible = False
            Label7.Visible = False
        End If
        reValue()
        GetValues()
    End Sub


    Sub UserChanging()

        Timer2.Start()

        reValue()
        GetValues()
    End Sub


    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click

        ShutDown()
        killProg()

        Dim PROCESO1 As New Process() 'EL PROCESO QUE SE VA A EJECUTAR
        PROCESO1.StartInfo.FileName = "N:\Stop.bat" 'RUTA DEL ELECUTABLE
        ' PROCESO1.StartInfo.Arguments = TextBoxARGUMENTOS1.Text 'ARGUMENTOS PARA EL PROCESO
        PROCESO1.StartInfo.UseShellExecute = False 'PARA QUE NO USE SHELL PARA ABRIR EL PROCESO
        'PROCESO1.StartInfo.RedirectStandardOutput = True 'PARA QUE REDIRIJA EL OUTPUT DEL PROCESO A NUESTRA APLICACION
        'PROCESO1.StartInfo.RedirectStandardError = True 'PARA QUE REDIRIJA LOS ERRORES DEL PROCESO A NUESTRA APLICACION
        PROCESO1.StartInfo.CreateNoWindow = True 'PARA QUE NO MUESTRE LA VENTANA DEL PROCESO

        PROCESO1.Start()
        End

    End Sub

    Dim StartShow As Integer = 0

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        StartShow = StartShow + 1

        If StartShow >= 5 Then
            Panel1.Visible = True
            PictureBox5.Visible = True
            Timer2.Start()
            Timer3.Stop()
        End If
        Cursor.Show()


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Panel3.Location.Y >= 125 Then
            Timer1.Stop()
            Timer2.Stop()

            UserKey = IO.File.ReadAllText(UsersPath & "\" & uClick_Str & "\Password")

            Panel2.Visible = True
            Clicked = True
            TextBox1.Focus()
        Else
            Panel3.Top = Panel3.Location.Y + 5
            Panel5.Top = Panel5.Location.Y - 5
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Panel3.Location.Y <= 40 Then
            Timer1.Stop()
            Timer2.Stop()

        Else
            Panel3.Top = Panel3.Location.Y - 5
            Panel5.Top = Panel5.Location.Y + 5

            Panel2.Visible = False
            Clicked = False
        End If
    End Sub

   
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If lookscreen = True Then
            GoOnPassWord()
            HidePassParam = 0
        End If
    End Sub

    Dim HidePassParam As Integer = 0

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick

        If lookscreen = True Then

            HidePassParam = HidePassParam + 1

            If HidePassParam >= 6 Then
                Timer4.Stop()

                Panel2.Visible = False
                Label8.Visible = False
                TextBox1.Clear()
                GoOnPassWord()
                HidePassParam = 0

            End If
        End If
    End Sub

   
    Private Sub PictureBox3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox3.Paint
        CircleImgPic(Me.PictureBox3, e)
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        CircleImgPic(Me.PictureBox1, e)
    End Sub

    Private Sub PictureBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint
        CircleImgPic(Me.PictureBox2, e)
    End Sub
End Class