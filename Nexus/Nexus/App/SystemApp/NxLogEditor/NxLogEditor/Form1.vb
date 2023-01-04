Public Class Form1


    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Close_Me("LogEditor")
        IO.File.WriteAllText("N:\Nexus\AppWork\NxLogEditor\IsRun", "False")


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        IO.File.WriteAllText("N:\Nexus\AppWork\NxLogEditor\IsRun", "True")

        Load_Me("LogEditor", PictureBox2.Image, ListenNumber)


        Dim parentnode As TreeNode

        Dim childnode0 As New TreeNode

        Dim childnode1 As New TreeNode

        Dim iDir As IO.DirectoryInfo



        '______________________________________________________________________________________________________________
        For Each Dir0 As String In My.Computer.FileSystem.GetDirectories("N:\Nexus\AppWork")

            iDir = My.Computer.FileSystem.GetDirectoryInfo(Dir0)



            parentnode = New TreeNode(iDir.Name)
            parentnode.ToolTipText = Dir0
            parentnode.Tag = 0
            TreeView1.Nodes.Add(parentnode)


            For Each Dir1 As String In My.Computer.FileSystem.GetDirectories(Dir0)
                iDir = My.Computer.FileSystem.GetDirectoryInfo(Dir1)


                childnode0 = parentnode.Nodes.Add("", iDir.Name, 0)
                childnode0.ToolTipText = Dir1
                childnode0.Tag = 0




                Dim childnode2 As New TreeNode


                For Each Dir2 As String In My.Computer.FileSystem.GetDirectories(Dir1)

                    iDir = My.Computer.FileSystem.GetDirectoryInfo(Dir2)



                    childnode2 = childnode0.Nodes.Add("", iDir.Name, 0)
                    childnode2.ToolTipText = Dir2
                    childnode2.Tag = 0


                    Dim childnode3 As New TreeNode

                    For Each Dir3 As String In My.Computer.FileSystem.GetDirectories(Dir2)

                        iDir = My.Computer.FileSystem.GetDirectoryInfo(Dir3)

                        childnode3 = childnode2.Nodes.Add("", iDir.Name, 0)
                        childnode3.ToolTipText = Dir3
                        childnode3.Tag = 0


                        Dim childnode4 As New TreeNode

                        For Each Dir4 As String In My.Computer.FileSystem.GetDirectories(Dir3)

                            iDir = My.Computer.FileSystem.GetDirectoryInfo(Dir4)

                            childnode4 = childnode3.Nodes.Add("", iDir.Name, 0)
                            childnode4.ToolTipText = Dir4
                            childnode3.Tag = 0

                        Next
                    Next


                Next


            Next



        Next






    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try

            e.Node.SelectedImageIndex = e.Node.ImageIndex

            Label1.Text = e.Node.ToolTipText



        Catch ex As Exception

            Label1.Text = e.Node.ToolTipText

        End Try

        Try
            ListView1.Items.Clear()

            Dim fInfo As IO.FileInfo
            Dim LvElemt As ListViewItem
            Dim NimageIndex As Integer

            For Each File As String In My.Computer.FileSystem.GetFiles(e.Node.ToolTipText)


                fInfo = My.Computer.FileSystem.GetFileInfo(File)

                If fInfo.Extension = ".jpg" Then

                    NimageIndex = 1

                ElseIf fInfo.Extension = ".png" Then

                    NimageIndex = 1

                ElseIf fInfo.Extension = ".gif" Then

                    NimageIndex = 1

                Else
                    NimageIndex = 0

                End If


                LvElemt = New ListViewItem(fInfo.Name, NimageIndex)
                LvElemt.ToolTipText = File
                ListView1.Items.Add(LvElemt)




            Next

        Catch ex As Exception

        End Try



    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

        Try

            TextBox1.Text = IO.File.ReadAllText(ListView1.SelectedItems(0).ToolTipText)

        Catch ex As Exception

            TextBox1.Text = Nothing

        End Try

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

                Me.Size = New Drawing.Size(lSize)

            End If

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub


    '________________________________________________________________________
    Dim x As Integer, y As Integer, a As Integer = x, b As Integer = y
    Private XY As Point
    '________________________________________________________________________


    Private Sub PictureBox6_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        XY.X = CInt(CLng(x))
        XY.Y = CInt(CLng(y))


    End Sub

    Private Sub PictureBox6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseMove
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

    End Sub

    Dim lSize As Point
    Dim maximised As Boolean = False

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Maximiced()

        lSize = Me.Size

        Dim lX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim lY As Integer = My.Computer.Screen.WorkingArea.Height

        Me.Left = 0
        Me.Top = 0

        Me.Width = lX
        Me.Height = lY - 11


        Me.MaximumSize = Me.Size
        maximised = True

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Hide()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

        If maximised = True Then

            NotMaximiced()
            maximised = False

        End If

        Me.Close()

    End Sub

    Private Sub ModificarLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarLogToolStripMenuItem.Click
        Try


            If ListView1.SelectedItems.Count > 0 Then

                LogToEdit = ListView1.SelectedItems(0).ToolTipText

                ValueLog = IO.File.ReadAllText(ListView1.SelectedItems(0).ToolTipText)


                If ValueLog.Contains("\") Then
                    TipeLog = "Ubicacion de archivo"
                    OnlyNumbers = False
                ElseIf ValueLog = "True" Then
                    TipeLog = "Falso o Verdadero (True or False)"
                    OnlyNumbers = False
                ElseIf ValueLog = "False" Then
                    TipeLog = "Falso o Verdadero (True or False)"
                    OnlyNumbers = False
                ElseIf ValueLog = "Readed" Then
                    TipeLog = "Falso o Verdadero (True or False)"
                    OnlyNumbers = False
                ElseIf ValueLog = "Stopped" Then

                    TipeLog = "Estado -Play-, -Pause-, -Stopped-"
                    OnlyNumbers = False
                ElseIf ValueLog = "Play" Then
                    OnlyNumbers = False
                    TipeLog = "Estado -Play-, -Pause-, -Stopped-"

                ElseIf ListView1.SelectedItems(0).Text = "&WebState&" Then

                    TipeLog = "Estado de la red actual (No modificable)"
                    Form2.TextBox1.Enabled = False
                    Form2.PictureBox1.Enabled = False
                    OnlyNumbers = False
                ElseIf ValueLog > 0 And ListView1.SelectedItems(0).Text = "#Day" Then
                    TipeLog = "Numerico, no mayor a 30"
                    OnlyNumbers = True
                ElseIf ValueLog > 0 And ListView1.SelectedItems(0).Text = "#Horas" Then
                    TipeLog = "Numerico, no mayor a 23"
                    OnlyNumbers = True
                ElseIf ValueLog > 0 And ListView1.SelectedItems(0).Text = "#Minutes" Then
                    TipeLog = "Numerico, no mayor a 59"
                    OnlyNumbers = True
                ElseIf ValueLog > 0 And ListView1.SelectedItems(0).Text = "#Seconds" Then
                    TipeLog = "Numerico, no mayor a 59"
                    OnlyNumbers = True
                ElseIf ValueLog > 0 And ListView1.SelectedItems(0).Text = "#Year" Then
                    TipeLog = "Numerico, no menor que 2000"
                    OnlyNumbers = True
                ElseIf ValueLog > 0 And ListView1.SelectedItems(0).Text = "#Month" Then
                    TipeLog = "Numerico, no mayor a 12"

                    OnlyNumbers = True
                Else

                    TipeLog = "<Unknown Value>"
                    OnlyNumbers = False

                End If

                Form2.ShowDialog()

            End If
        Catch ex As Exception

            TipeLog = "<Unknown Value>"
            OnlyNumbers = False
            Form2.ShowDialog()
        End Try

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


    Private Sub Form1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged

        If maximised = True Then

            NotMaximiced()
            maximised = False

        End If

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
End Class
