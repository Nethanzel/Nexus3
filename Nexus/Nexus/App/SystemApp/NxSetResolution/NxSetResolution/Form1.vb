Imports System.Runtime.InteropServices

Public Class Form1

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        IO.File.WriteAllText("N:\Nexus\AppWork\ScreenRslt\IsRun", "False")

        Close_Me("ScreenResolution")
        
    End Sub

    Dim lTam As Size
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Load_Me("ScreenResolution", PictureBox5.Image, ListenNumber)
        IO.File.WriteAllText("N:\Nexus\AppWork\ScreenRslt\IsRun", "True")

        Dim DevM As DEVMODE

        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))

        Dim dMode = 0
        'While 0 <> 
        Do While EnumDisplaySettings(Nothing, dMode, DevM) = True
            'Dim lResult As Integer
            Dim tSize As New Size(DevM.dmPelsWidth, DevM.dmPelsHeight)

            If Not tSize = lTam Then
            
            If DevM.dmPelsWidth > 640 Then
                LVAdd(DevM)
                End If

            End If
            dMode += 1

            lTam = New Size(DevM.dmPelsWidth, DevM.dmPelsHeight)
            'End While
        Loop

        Label2.Text = "Ancho: " & My.Computer.Screen.Bounds.Width & " px"
        Label3.Text = "Alto: " & My.Computer.Screen.Bounds.Height & " px"
        Label4.Text = "BPP: " & My.Computer.Screen.BitsPerPixel.ToString

    End Sub

  


    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel7.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If

    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel7.MouseMove

        If aaa = True Then
            Dim tmp As Point = New Point

            tmp.X = Me.Location.X + (e.X - MouseX)
            tmp.Y = Me.Location.Y + (e.Y - MouseY)
            Me.Location = tmp
            tmp = Nothing

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel7.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If

    End Sub


    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Close()
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        Me.Hide()
    End Sub


    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel7.BackColor = Color.DarkGray

    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = SystmColor
        Panel7.BackColor = SystmColor

    End Sub

    Private Declare Function EnumDisplaySettings Lib "user32" Alias "EnumDisplaySettingsA" (ByVal lpszDeviceName As Integer, ByVal iModeNum As Integer, ByRef lpdmode As DEVMODE) As Boolean

    Const ENUM_CURRENT_SETTINGS As Integer = -1
    Const CDS_UPDATEREGISTRY As Integer = &H1
    Const CDS_TEST As Long = &H2

    Const CCDEVICENAME As Integer = 32
    Const CCFORMNAME As Integer = 32

    Const DISP_CHANGE_SUCCESSFUL As Integer = 0
    Const DISP_CHANGE_RESTART As Integer = 1
    Const DISP_CHANGE_FAILED As Integer = -1

    <StructLayout(LayoutKind.Sequential)> Public Structure DEVMODE
        <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=CCDEVICENAME)> Public dmDeviceName As String
        Public dmSpecVersion As Short
        Public dmDriverVersion As Short
        Public dmSize As Short
        Public dmDriverExtra As Short
        Public dmFields As Integer

        Public dmOrientation As Short
        Public dmPaperSize As Short
        Public dmPaperLength As Short
        Public dmPaperWidth As Short

        Public dmScale As Short
        Public dmCopies As Short
        Public dmDefaultSource As Short
        Public dmPrintQuality As Short
        Public dmColor As Short
        Public dmDuplex As Short
        Public dmYResolution As Short
        Public dmTTOption As Short
        Public dmCollate As Short
        <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=CCFORMNAME)> Public dmFormName As String
        Public dmUnusedPadding As Short
        Public dmBitsPerPel As Short
        Public dmPelsWidth As Integer
        Public dmPelsHeight As Integer

        Public dmDisplayFlags As Integer
        Public dmDisplayFrequency As Integer
    End Structure

    Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height

    'vars set in load
    Private Sub LVAdd(ByVal DevM)
        Dim currres As String

        If DevM.dmPelsHeight = intX And DevM.dmPelsWidth = intY Then
            currres = "Monitor Resolution"
        Else
            currres = ""
        End If

        ListBox1.Items.Add("    " & CStr(DevM.dmPelsWidth) & " X " & CStr(DevM.dmPelsHeight) & CStr(currres))
       
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Refer As String = ListBox1.SelectedItem
        Dim R1 As Integer = Refer.IndexOf("X")

        lHeight = My.Computer.Screen.Bounds.Height
        lWidth = My.Computer.Screen.Bounds.Width

        Dim W As Single = CSng(Refer.Remove(R1 - 1))
        Dim H As Single = CSng(Refer.Substring(R1 + 1))
        Dim BPP As Integer = My.Computer.Screen.BitsPerPixel

        Dim Result As Boolean = SetResolution(W, H, BPP)

        If Result = True Then
           
            Confirm.ShowDialog()
        End If




    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ListBox1.SelectedItems.Count < 1 Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If

        Label2.Text = "Ancho: " & My.Computer.Screen.Bounds.Width & " px"
        Label3.Text = "Alto: " & My.Computer.Screen.Bounds.Height & " px"
        Label4.Text = "BPP: " & My.Computer.Screen.BitsPerPixel.ToString

    End Sub
End Class
