Imports System.Drawing.Drawing2D

Module NotifierMod

    Dim WithEvents NotifyPanel As New Panel
    Dim WithEvents Prent As New Panel
    Dim Pnumero As Integer = 1

    Sub addNotify(ByVal Title As String, ByVal Coment As String, ByVal UseIcon As String, ByVal Container As Object)

        Dim NotifyImage As Image = Image.FromFile(UseIcon)

        Dim PicImage As New PictureBox
        PicImage.Image = NotifyImage
        PicImage.SizeMode = PictureBoxSizeMode.Zoom

        Dim Separar As New Panel

        With Separar
            .BackColor = Color.White
            .Dock = DockStyle.Bottom
            .Height = 8
            .Name = "Separador" & Pnumero
        End With

        Prent = New Panel

        With Prent
            .Dock = DockStyle.Bottom
            .BackColor = Color.White
            .Height = 85
            .Name = "Padre" & Pnumero
        End With

        NotifyPanel = New Panel

        With NotifyPanel
            .BackColor = Color.LightGray
            .Width = 0
            .Parent = Prent
            .Height = 85
            .BorderStyle = BorderStyle.FixedSingle
            .Name = "Notify" & Pnumero
            .Controls.Add(PicImage)
            .Tag = "Separador" & Pnumero
        End With


        AddHandler NotifyPanel.Click, AddressOf Panel_Out
        AddHandler NotifyPanel.MouseHover, AddressOf Nofity_MouseHover
        AddHandler NotifyPanel.MouseLeave, AddressOf Nofity_MouseLeave
        AddHandler NotifyPanel.MouseDown, AddressOf Notify_MouseDown
        AddHandler NotifyPanel.MouseUp, AddressOf Notify_Up

        Prent.Controls.Add(NotifyPanel)
        CType(Container, Panel).Controls.Add(Prent)
        CType(Container, Panel).Controls.Add(Separar)

        PicImage.Dock = DockStyle.Left

        NotifyPanel.Left = Prent.Width
        PWidth = Prent.Width
        PicImage.Width = 65

        Keep.Interval = 10000
        Keep.Enabled = True
        AddHandler Keep.Tick, AddressOf Keep_Timer


        Pnumero = Pnumero + 1

        Timer1.Interval = 10
        Timer1.Start()


    End Sub

    Dim WithEvents Keep As New Timer

    Private Sub Keep_Timer(ByVal sender As Object, ByVal e As System.EventArgs) Handles Keep.Tick

        For i = 0 To 10

            If i = 10 Then


                CType(sender, Timer).Dispose()

            End If
        Next

    End Sub

    Dim PWidth As Integer
    Dim WithEvents Timer1 As New Timer

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        NotifyPanel.Width = NotifyPanel.Width + 10
        NotifyPanel.Left = NotifyPanel.Left - 10

        If NotifyPanel.Width >= PWidth - 2 Then
            Timer1.Stop()
        End If

    End Sub

    Dim WithEvents Timer2 As New Timer
    Dim RemovePanel As New Panel

    Dim Wait As Boolean = False

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Try

            RemovePanel.Width = RemovePanel.Width - 10
            RemovePanel.Left = RemovePanel.Left + 10

            If RemovePanel.Width <= 0 Then
                Timer2.Stop()
                Dim z As Panel = RemovePanel.Parent
                z.Size = New Size(0, 0)
                pPanel.Parent.Controls.RemoveByKey(KeyRemove)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Dim pPanel As Panel
    Dim KeyRemove As String

    Private Sub Panel_Out(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyPanel.Click

        RemovePanel = CType(sender, Panel)
        Timer2.Interval = 10
        Timer2.Start()
        pPanel = CType(sender, Panel).Parent
        KeyRemove = CType(sender, Panel).Tag

    End Sub


    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    Sub App_Break(ByVal Time As Integer)

        Dim retraso As Integer = Time
        retraso = retraso + GetTickCount

        While retraso >= GetTickCount
            Application.DoEvents()
        End While

    End Sub

    Private Sub Nofity_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyPanel.MouseHover

        CType(sender, Panel).BackColor = Color.DarkGray

    End Sub

    Private Sub Nofity_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyPanel.MouseLeave

        CType(sender, Panel).BackColor = Color.LightGray

    End Sub

    Private Sub Notify_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyPanel.MouseDown

        CType(sender, Panel).BackColor = Color.DimGray

    End Sub

    Private Sub Notify_Up(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyPanel.MouseUp

        CType(sender, Panel).BackColor = Color.DarkGray

    End Sub


End Module
