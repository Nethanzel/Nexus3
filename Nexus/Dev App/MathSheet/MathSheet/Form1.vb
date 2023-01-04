Imports System.Text

Public Class Form1


    Sub RefreshGrid()

        For i As Integer = 0 To SheetView.Rows.Count - 1
            SheetView.Rows(i).HeaderCell.Value = "R" & i + 1

        Next


        For i As Integer = 0 To SheetView.ColumnCount - 1
            SheetView.Columns(i).HeaderCell.Value = "C" & i + 1

        Next


        For i As Integer = 0 To SheetView.Rows.Count - 1

            For s = 0 To SheetView.Rows(i).Cells.Count - 1
                SheetView.Rows(i).Cells(s).Tag = "C" & CStr(SheetView.Rows(i).Cells(s).ColumnIndex + 1) & "R" & CStr(SheetView.Rows(i).Cells(s).RowIndex + 1)
            Next

        Next

    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ComboBox1.Items.Clear()

        'Dim Family_Fnt As FontFamily

        'For Each Family_Fnt In FontFamily.Families
        '    ComboBox1.Items.Add(Family_Fnt.Name)
        'Next

        Load_Me("MathSheet", PictureBox5.Image, ListenNumber)

        Dim s As Integer = 10

        Do While s > 0
            Me.SheetView.Rows.Add()
            s = s - 1
        Loop

        ComboBox3.Items.Clear()

        Dim color As System.Drawing.Color

        For Each color In System.ComponentModel.TypeDescriptor.GetConverter(GetType(Color)).GetStandardValues
            ComboBox3.Items.Add(color.ToKnownColor)
            ComboBox5.Items.Add(color.ToKnownColor)
        Next

        ComboBox4.Items.Clear()

        For i As Integer = 8 To 30
            If i Mod 2 = 0 Then
                ComboBox4.Items.Add(i)
            End If
        Next

        FormatoPanel.Dock = DockStyle.Fill



        RefreshGrid()

    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            If ComboBox2.Text.ToLower = "izquierda" Then
                SheetView.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf ComboBox2.Text.ToLower = "centro" Then
                SheetView.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            ElseIf ComboBox2.Text.ToLower = "derecha" Then
                SheetView.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try
            SheetView.CurrentCell.Style.Font = New Font(SheetView.CurrentCell.Style.Font, CSng(ComboBox4.Text))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try
            SheetView.CurrentCell.Style.ForeColor = Color.FromKnownColor(ComboBox3.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SheetView_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SheetView.CurrentCellChanged

        Try

            If Not SheetView.CurrentCell.Value = Nothing Then

                Label4.Text = "     " & "Seleccion: Celda: " & SheetView.CurrentCell.Tag & " - Val: " & SheetView.CurrentCell.Value
                Label4.SendToBack()
            Else

                Label4.Text = "     " & "Seleccion: Celda " & SheetView.CurrentCell.Tag
                Label4.SendToBack()
            End If

        Catch ex As Exception

        End Try

    End Sub


    Dim Mx As Boolean = False
    Dim lSize As Point
    Dim maximised As Boolean = False

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click


        lSize = Me.Size
        Maximiced()

        Dim lX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim lY As Integer = My.Computer.Screen.WorkingArea.Height

        Me.Left = 0
        Me.Top = 0

        Me.Width = lX
        Me.Height = lY - 11


        Me.MaximumSize = Me.Size

        maximised = True

        Mx = True

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

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel2.BackColor = Color.DarkGray

    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = Color.DimGray
        Panel2.BackColor = Color.DimGray

    End Sub

    Private Sub Form1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

        If Me.Visible = True Then

            If Mx = True Then
                Maximiced()
            End If

        Else
            If Mx = True Then
                NotMaximiced()
            End If

        End If

    End Sub

    Dim Min As Boolean = False

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

        Me.Hide()
        Min = False

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

            If maximised = True Then
                maximised = False
                Mx = False
                Me.Size = lSize
                NotMaximiced()
            End If


        End If
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

                maximised = False
                Mx = False
                Me.Size = New Drawing.Size(lSize)

                NotMaximiced()

            End If

        End If

    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

        If Mx = True Then
            NotMaximiced()
        End If

        Close_Me("MathSheet")

        Me.Close()
    End Sub


    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Try
            SheetView.CurrentCell.Style.BackColor = Color.FromKnownColor(ComboBox5.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel8.Click, Label1.Click
        Panel8.BackColor = Color.FromName("Control")
        Panel9.BackColor = Color.FromName("AppWorkspace")
        Panel10.BackColor = Color.FromName("AppWorkspace")

        FormatoPanel.Dock = DockStyle.Fill
        FormatoPanel.Visible = True
        Hoja.Visible = False
        Formula.Visible = False

    End Sub

    Private Sub Panel9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel9.Click, Label2.Click
        Panel9.BackColor = Color.FromName("Control")
        Panel8.BackColor = Color.FromName("AppWorkspace")
        Panel10.BackColor = Color.FromName("AppWorkspace")

        Hoja.Dock = DockStyle.Fill
        Hoja.Visible = True

        FormatoPanel.Visible = False
        Formula.Visible = False
    End Sub

    Private Sub Panel10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel10.Click, Label3.Click
        Panel10.BackColor = Color.FromName("Control")
        Panel9.BackColor = Color.FromName("AppWorkspace")
        Panel8.BackColor = Color.FromName("AppWorkspace")

        Formula.Dock = DockStyle.Fill
        Formula.Visible = True

        FormatoPanel.Visible = False
        Hoja.Visible = False
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click
        SheetView.Rows.Add()
        RefreshGrid()
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click
        Dim Name As String = "Column" & SheetView.ColumnCount + 1
        SheetView.Columns.Add(Name, "")
        RefreshGrid()
    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

        Dim Name As String = "Column" & SheetView.ColumnCount + 1
        Dim NColumn As New DataGridViewColumn(SheetView.CurrentCell)
        NColumn.Name = Name

        SheetView.Columns.Insert(SheetView.CurrentCell.ColumnIndex + 1, NColumn)

        RefreshGrid()
    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

        SheetView.Rows.Insert(SheetView.CurrentCell.RowIndex + 1, 1)
        RefreshGrid()

    End Sub

    Sub RefreshCalc()

        For i = 0 To SheetView.Rows.Count - 1

            For K = 0 To SheetView.Rows(i).Cells.Count - 1

                Dim Catchr As String = SheetView.Rows(i).Cells(K).ToolTipText

                If Catchr.StartsWith("=") Then

                    SheetView.Rows(i).Cells(K).Value = SimpleOperation(SheetView.Rows(i).Cells(K).ToolTipText)

                Else
                    SheetView.Rows(i).Cells(K).Style.BackColor = Color.FromKnownColor(KnownColor.Window)
                    SheetView.Rows(i).Cells(K).Style.ForeColor = Color.Black
                End If

            Next

        Next

    End Sub

    Private Sub SheetView_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SheetView.CellEndEdit
        Try

            Dim Catcher As String = SheetView.SelectedCells(0).Value

            If Catcher.StartsWith("=") Then

                SheetView.SelectedCells(0).ToolTipText = SheetView.SelectedCells(0).Value.ToString
                SheetView.SelectedCells(0).Value = SimpleOperation(SheetView.SelectedCells(0).Value.ToString)
                SheetView.SelectedCells(0).Style.BackColor = Color.Fuchsia
                SheetView.SelectedCells(0).Style.ForeColor = Color.White

            ElseIf Catcher = Nothing Then
                SheetView.SelectedCells(0).ToolTipText = ""
                SheetView.SelectedCells(0).Style.BackColor = Color.FromKnownColor(KnownColor.Window)
                SheetView.SelectedCells(0).Style.ForeColor = Color.Black
            End If

            RefreshCalc()

        Catch ex As Exception

        End Try

    End Sub



    Function SimpleOperation(ByVal Formulation As String) As String

        Dim m1 As String = Formulation.Replace("=", "")
        Dim m2 As String = Formulation.Substring(m1.IndexOf("+") + 1) 'Nombre valor2
        Dim m3 As String = Formulation.Remove(m1.IndexOf("+") + 1) 'Nombre valor1

        m2 = m2.Replace("+", "")
        m3 = m3.Replace("+", "").Replace("=", "")

        Dim v1 As Integer
        Dim v2 As Integer


        For i = 0 To SheetView.Rows.Count - 1

            For K = 0 To SheetView.Rows(i).Cells.Count - 1


                If SheetView.Rows(i).Cells(K).Tag.ToString.ToLower = m3 Then

                    'SheetView.Rows(i).Cells(K).Style.BackColor = Color.Cyan
                    v1 = SheetView.Rows(i).Cells(K).Value

                ElseIf SheetView.Rows(i).Cells(K).Tag.ToString.ToLower = m2 Then

                    'SheetView.Rows(i).Cells(K).Style.BackColor = Color.LightBlue
                    v2 = SheetView.Rows(i).Cells(K).Value

                End If

            Next


        Next


        Return v1 + v2

    End Function



    Private Sub SheetView_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles SheetView.CellBeginEdit
        If Not SheetView.SelectedCells(0).ToolTipText = Nothing Then
            SheetView.SelectedCells(0).Value = SheetView.SelectedCells(0).ToolTipText

            'Else
            '    Dim Catchr As String = SheetView.SelectedCells(0).ToolTipText

            '    If Catchr.StartsWith("=") Then

            '        SheetView.SelectedCells(0).Value = SimpleOperation(SheetView.SelectedCells(0).ToolTipText)

            '    End If
        End If
    End Sub

End Class
