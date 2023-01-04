
Imports NotifyPanel

Module NotifierModule

    Dim WithEvents EspNwNotify As New EspNotifyPanel.EspNotifyPanel
    Dim WithEvents nwNotify As New NotifyPanel.NotifyPanel

    Dim Numero As Integer = 1

    Sub AddNotify2(ByVal ImgRt As String, ByVal TitleTxt As String, ByVal AppName As String, ByVal Detls As String, ByVal Parent As Object, ByVal memory As String, ByVal SaveNtf As Boolean)
        Form1.Show()
        Form1.Focus()

        Dim ntImage As Image = Image.FromFile(ImgRt)
        Dim Separar As New Panel
        Dim EspSeparar As New Panel

        With Separar
            .BackColor = Color.White
            .Dock = DockStyle.Bottom
            .Height = 8
            .Name = "Separador" & Numero
            .BackColor = Color.FromKnownColor(KnownColor.ScrollBar)
        End With

        With EspSeparar
            .BackColor = Color.WhiteSmoke
            .Dock = DockStyle.Top
            .Height = 5
            .Name = "Separador" & Numero
            .Visible = False
        End With

        nwNotify = New NotifyPanel.NotifyPanel
        nwNotify.TitleText = TitleTxt
        nwNotify.Memory = memory
        nwNotify.DetailsText = Detls
        nwNotify.AppNameText = AppName
        nwNotify.Dock = DockStyle.Bottom
        nwNotify.Tag = Separar.Name
        nwNotify.BackColor = Color.FromKnownColor(KnownColor.ScrollBar)

        AddHandler nwNotify.Removed, AddressOf nwNotifyRemoved
        AddHandler nwNotify.Clicked, AddressOf nwNotify_Clicked

        Dim pWidth As Integer = CType(Parent, Panel).Width

        CType(Parent, Panel).Controls.Add(nwNotify)
        nwNotify.NtfImage = ntImage
        nwNotify.Width = pWidth - 2
        CType(Parent, Panel).Controls.Add(Separar)

        If SaveNtf = True Then
            EspNwNotify = New EspNotifyPanel.EspNotifyPanel
            EspNwNotify.TitleText = TitleTxt
            EspNwNotify.Memory = memory
            EspNwNotify.DetailsText = Detls
            EspNwNotify.AppNameText = AppName
            EspNwNotify.Tag = EspSeparar.Name

            AddHandler EspNwNotify.Removed, AddressOf EspNotifyRemoved
            'AddHandler EspNwNotify.Clicked, AddressOf nwNotify_Clicked

            Dim espWidth As Integer = SlideMenu.Panel1.Width

            SlideMenu.Panel1.Controls.Add(EspNwNotify)
            EspNwNotify.NtfImage = ntImage
            EspNwNotify.Dock = DockStyle.Top
            EspNwNotify.SendToBack()

            SlideMenu.Panel1.Controls.Add(EspSeparar)

        End If

        Numero = Numero + 1

        Form1.Focus()
    End Sub

    Private Sub nwNotifyRemoved(ByVal sender As System.Object) Handles nwNotify.Removed

        Dim SenderParent As Panel = CType(sender, NotifyPanel.NotifyPanel).Parent
        Dim KeyRemove As String = CType(sender, NotifyPanel.NotifyPanel).Tag

        Try
            SenderParent.Controls.RemoveByKey(KeyRemove)
            SenderParent.Controls.Remove(CType(sender, NotifyPanel.NotifyPanel))

        Catch ex As Exception

        End Try


    End Sub

    Dim lSender As String = ""

    Private Sub nwNotify_Clicked(ByVal sender As System.Object) Handles nwNotify.Clicked

        Dim crrnt As String = CType(sender, NotifyPanel.NotifyPanel).Tag

        If crrnt <> lSender Then
            lSender = crrnt
            '----Instruciones del evento------
            If CType(sender, NotifyPanel.NotifyPanel).Memory.StartsWith("fs") Then
                Try
                    If Not IO.File.ReadAllText("N:\Nexus\AppWork\NxDisckExplorer\IsRun") = "True" Then

                        Process.Start("N:\Dev App\DickExplorer\DickExplorer\bin\Debug\DickExplorer.exe")

                        While Not IO.File.ReadAllText("N:\Nexus\AppWork\NxDisckExplorer\IsRun") = "True"
                            Application.DoEvents()
                        End While

                        Speak("DiskExplorer", "+" & CType(sender, NotifyPanel.NotifyPanel).Memory.Substring(3), "C")

                    Else
                        Speak("DiskExplorer", "+" & CType(sender, NotifyPanel.NotifyPanel).Memory.Substring(3), "C")
                    End If

                Catch ex As Exception

                End Try

            End If

            '---------------------------------
        End If

    End Sub


    Private Sub EspNotifyRemoved(ByVal sender As System.Object) Handles EspNwNotify.Removed

        Dim SenderParent As Panel = CType(sender, EspNotifyPanel.EspNotifyPanel).Parent
        Dim KeyRemove As String = CType(sender, EspNotifyPanel.EspNotifyPanel).Tag

        Try
            SenderParent.Controls.RemoveByKey(KeyRemove)
            SenderParent.Controls.Remove(CType(sender, EspNotifyPanel.EspNotifyPanel))

        Catch ex As Exception

        End Try


    End Sub

End Module
