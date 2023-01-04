Public Class Form1
    Dim hDrives As New System.Collections.Generic.List(Of String)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Me("Notifier", Nothing, ListenNumber)

        SlideMenu.Show()
        SlideMenu.Opacity = 0%

        Dim EspNwNotify As EspNotifyPanel.EspNotifyPanel
        EspNwNotify = New EspNotifyPanel.EspNotifyPanel
        EspNwNotify.TitleText = ""
        EspNwNotify.Memory = ""
        EspNwNotify.DetailsText = ""
        EspNwNotify.AppNameText = ""
        EspNwNotify.Tag = """"
        SlideMenu.Panel1.Controls.Add(EspNwNotify)
        EspNwNotify.NtfImage = Nothing
        EspNwNotify.Dock = DockStyle.Top
        EspNwNotify.SendToBack()

        For i = 0 To My.Computer.FileSystem.Drives.Count - 1
            hDrives.Add(My.Computer.FileSystem.Drives(i).Name)
        Next

        SlideMenu.Panel1.Controls.Remove(EspNwNotify)


    End Sub


    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Close_Me("Notifier")

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Determine()
    End Sub

    Dim DriveList As New System.Collections.Generic.List(Of String)
    Dim DrivesCount As Integer = My.Computer.FileSystem.Drives.Count

    Sub Determine()

        If DrivesCount <> My.Computer.FileSystem.Drives.Count Then

            DriveList.Clear()

            For i = 0 To My.Computer.FileSystem.Drives.Count - 1

                DriveList.Add(My.Computer.FileSystem.Drives(i).Name)

            Next


            If DriveList.Count > hDrives.Count Then

                For i = 0 To DriveList.Count - 1

                    If Not hDrives.Contains(DriveList.Item(i)) Then

                        SpeakLine = "Se ha conectado un nuevo dispositivo extraible."
                        Dim xPrc As New Threading.Thread(AddressOf Mouth)
                        xPrc.Start()

                        AddNotify2("N:\Nexus\Resourses\DevicesR.png", "Unidad " & DriveList.Item(i), "File System", "Se ha conectado una nueva unidad de disco", Me.Paneles, "fs-" & DriveList.Item(i), True)

                    End If

                Next

                DriveList.Clear()
                hDrives.Clear()

                For i = 0 To My.Computer.FileSystem.Drives.Count - 1

                    DriveList.Add(My.Computer.FileSystem.Drives(i).Name)
                    hDrives.Add(My.Computer.FileSystem.Drives(i).Name)
                Next

            Else

                DriveList.Clear()
                hDrives.Clear()

                For i = 0 To My.Computer.FileSystem.Drives.Count - 1

                    DriveList.Add(My.Computer.FileSystem.Drives(i).Name)
                    hDrives.Add(My.Computer.FileSystem.Drives(i).Name)
                Next

            End If

            DrivesCount = My.Computer.FileSystem.Drives.Count

        End If

    End Sub


    Private Sub T1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1.Tick

        If SlideMenu.Location.X <= My.Computer.Screen.WorkingArea.Width - SlideMenu.Width Then

            T1.Stop()
            T2.Stop()
        Else
            Increment = Increment - 1
            SlideMenu.Left = SlideMenu.Location.X - Increment
            T2.Stop()
        End If


    End Sub


    Dim Increment As Integer = 35

    Private Sub T2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2.Tick
        If SlideMenu.Location.X >= My.Computer.Screen.WorkingArea.Width + SlideMenu.Width Then
            T2.Stop()
            T1.Stop()
            Increment = 35
            SlideMenu.Opacity = 0%
        Else
            Increment = Increment + 1

            If Increment > 35 Then
                T2.Stop()
                T1.Stop()
                Increment = 35

            Else
                SlideMenu.Left = SlideMenu.Location.X + Increment
                T1.Stop()
            End If




        End If
    End Sub


End Class
