Public Class Form1

    Dim Msize As Point = Nothing
    Dim maximised As Boolean = False

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Maximiced()

        Msize = Me.Size


        Dim lX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim lY As Integer = My.Computer.Screen.WorkingArea.Height

        Me.Left = 0
        Me.Top = 0

        Me.Width = lX
        Me.Height = lY - 11

        maximised = True
        Me.MaximumSize = Me.Size

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

            If maximised = True Then
                Me.Size = Msize

                maximised = False

            End If

        End If



    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub

    Dim x As Integer, y As Integer, a As Integer = x, b As Integer = y
    Private XY As Point


    Private Sub PictureBox3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        XY.X = CInt(CLng(x))
        XY.Y = CInt(CLng(y))
    End Sub

    Private Sub PictureBox3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Right Or e.Button = Windows.Forms.MouseButtons.Left Then
            'redimensionamos el ancho
            If (Me.Width + (x + e.X)) > 0 Then

                Me.Width = Me.Width + (x + e.X)
            End If
            'redimensionams el alto
            If (Me.Height + (y + e.Y)) > 0 Then

                Me.Height = Me.Height + (y + e.Y)
            End If
        End If

        If maximised = True Then
            maximised = False
            NotMaximiced()
        End If
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        If maximised = True Then

            maximised = False
            NotMaximiced()

        End If

        Me.Close()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Hide()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        IO.File.WriteAllText("N:\Nexus\AppWork\NxTxt\IsRun", "False")
        Close_Me("TextBloc")
 
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IO.File.WriteAllText("N:\Nexus\AppWork\NxTxt\IsRun", "True")
        Load_Me("TextBloc", PictureBox5.Image, ListenNumber)

        Dim Family_Fnt As FontFamily
        Dim i As Integer

        For Each Family_Fnt In FontFamily.Families
            i = i + 1

            If i = 30 Then
                Exit For
            End If

            Dim xItem As New ToolStripMenuItem

            xItem.Font = New Font(Family_Fnt.Name, 10)
            xItem.Text = Family_Fnt.Name
            xItem.BackColor = Color.Gainsboro
            xItem.Tag = Family_Fnt.Name
            xItem.Height = 24

            FuenteToolStripMenuItem.DropDownItems.Add(xItem)
        Next

        For xR As Integer = 8 To 30
            If i Mod 2 = 0 Then

                Dim xItem As New ToolStripMenuItem

                xItem.Text = xR
                xItem.BackColor = Color.Gainsboro
                xItem.Height = 24

                TamañoToolStripMenuItem.DropDownItems.Add(xItem)
            End If
        Next


        Dim colors As System.Drawing.Color
        i = 0

        For Each colors In System.ComponentModel.TypeDescriptor.GetConverter(GetType(Color)).GetStandardValues

            Dim xItem As New ToolStripMenuItem

            i = i + 1

            If i = 30 Then
                Exit For
            End If

            xItem.Text = colors.Name
            xItem.ForeColor = colors
            xItem.BackColor = Color.Gainsboro
            xItem.Height = 24
            xItem.Font = New Font(xItem.Font, FontStyle.Bold)
            ColorToolStripMenuItem.DropDownItems.Add(xItem)

        Next


    End Sub


    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        If maximised = True Then

            NotMaximiced()
            maximised = False

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


    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        NotFormatMod()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FormatMod()
    End Sub


    Sub FormatMod()
        LinkLabel2.Enabled = True
        LinkLabel1.Enabled = False

        AlinearToolStripMenuItem.Enabled = True
        EstiloToolStripMenuItem.Enabled = True
        FuenteToolStripMenuItem.Enabled = True
        ColorToolStripMenuItem.Enabled = True
        TamañoToolStripMenuItem.Enabled = True

        RichTextBox1.DetectUrls = True
    End Sub

    Sub NotFormatMod()
        LinkLabel1.Enabled = True
        LinkLabel2.Enabled = False

        AlinearToolStripMenuItem.Enabled = False
        EstiloToolStripMenuItem.Enabled = False
        FuenteToolStripMenuItem.Enabled = False
        ColorToolStripMenuItem.Enabled = False
        TamañoToolStripMenuItem.Enabled = False

        RichTextBox1.DetectUrls = False
    End Sub

    Private Sub FuenteToolStripMenuItem_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles FuenteToolStripMenuItem.DropDownItemClicked

        Try
            RichTextBox1.SelectionFont = New Font(e.ClickedItem.Tag.ToString, RichTextBox1.SelectionFont.Size, RichTextBox1.SelectionFont.Style)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub IzquierdaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IzquierdaToolStripMenuItem.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub CentroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CentroToolStripMenuItem.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub DerechaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DerechaToolStripMenuItem.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub NegritaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NegritaToolStripMenuItem.Click
        RichTextBox1.SelectionFont = New Font(RichTextBox1.SelectionFont, RichTextBox1.SelectionFont.Style + FontStyle.Bold)
    End Sub

    Private Sub CursivaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CursivaToolStripMenuItem.Click
        RichTextBox1.SelectionFont = New Font(RichTextBox1.SelectionFont, RichTextBox1.SelectionFont.Style + FontStyle.Italic)
    End Sub

    Private Sub TachadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TachadoToolStripMenuItem.Click
        RichTextBox1.SelectionFont = New Font(RichTextBox1.SelectionFont, RichTextBox1.SelectionFont.Style + FontStyle.Strikeout)
    End Sub

    Private Sub SubrayadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubrayadoToolStripMenuItem.Click
        RichTextBox1.SelectionFont = New Font(RichTextBox1.SelectionFont, RichTextBox1.SelectionFont.Style + FontStyle.Underline)
    End Sub

    Private Sub ColorToolStripMenuItem_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ColorToolStripMenuItem.DropDownItemClicked
        Try
            Dim Cl As Color = Color.FromName(e.ClickedItem.Text)
            RichTextBox1.SelectionColor = Cl
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TamañoToolStripMenuItem_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TamañoToolStripMenuItem.DropDownItemClicked
        Try
            RichTextBox1.SelectionFont = New Font(e.ClickedItem.Tag.ToString, CSng(e.ClickedItem.Text), RichTextBox1.SelectionFont.Style)
        Catch ex As Exception

        End Try

    End Sub
End Class
