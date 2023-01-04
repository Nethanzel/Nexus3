
Imports System.Runtime.InteropServices

Module Module1

    Public lWidth As Single
    Public lHeight As Single

    Private Declare Auto Function EnumDisplaySettings Lib "user32.dll" (<MarshalAs(UnmanagedType.LPTStr)> ByVal lpszDeviceName As String, ByVal iModeNum As Int32, ByRef lpDevMode As DEVMODE) As Boolean

    Private Declare Auto Function ChangeDisplaySettings Lib "user32.dll" (ByRef lpDevMode As DEVMODE, ByVal dwFlags As Int32) As Int32

    Private Const DM_BITSPERPEL As Int32 = &H40000
    Private Const DM_PELSWIDTH As Int32 = &H80000
    Private Const DM_PELSHEIGHT As Int32 = &H100000

    Private Const DISP_CHANGE_SUCCESSFUL As Int32 = 0

    <StructLayout(LayoutKind.Sequential)> Private Structure POINTL
        Public x As Int32
        Public y As Int32
    End Structure

    <StructLayout(LayoutKind.Explicit)> Private Structure DEVMODE_union1
        ' struct {
        <FieldOffset(0)> Public dmOrientation As Int16
        <FieldOffset(2)> Public dmPaperSize As Int16
        <FieldOffset(4)> Public dmPaperLength As Int16
        <FieldOffset(6)> Public dmPaperWidth As Int16
        ' }
        <FieldOffset(0)> Public dmPosition As POINTL
    End Structure

    <StructLayout(LayoutKind.Explicit)> Private Structure DEVMODE_union2
        <FieldOffset(0)> Public dmDisplayFlags As Int32
        <FieldOffset(0)> Public dmNup As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> Private Structure DEVMODE
        Private Const CCDEVICENAME As Int32 = 32
        Private Const CCFORMNAME As Int32 = 32

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCDEVICENAME)> Public dmDeviceName As String
        Public dmSpecVersion As Int16
        Public dmDriverVersion As Int16
        Public dmSize As Int16
        Public dmDriverExtra As Int16
        Public dmFields As Int32
        Public u1 As DEVMODE_union1
        Public dmScale As Int16
        Public dmCopies As Int16
        Public dmDefaultSource As Int16
        Public dmPrintQuality As Int16
        Public dmColor As Int16
        Public dmDuplex As Int16
        Public dmYResolution As Int16
        Public dmTTOption As Int16
        Public dmCollate As Int16
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCFORMNAME)> Public dmFormName As String
        Public dmUnusedPadding As Int16
        Public dmBitsPerPel As Int16
        Public dmPelsWidth As Int32
        Public dmPelsHeight As Int32
        Public u2 As DEVMODE_union2
        Public dmDisplayFrequency As Int32
        Public dmICMMethod As Int32
        Public dmICMIntent As Int32
        Public dmMediaType As Int32
        Public dmDitherType As Int32
        Public dmReserved1 As Int32
        Public dmReserved2 As Int32
        Public dmPanningWidth As Int32
        Public dmPanningHeight As Int32
    End Structure

    Public Function SetResolution(ByVal Width As Int32, ByVal Height As Int32, ByVal BitsPerPixel As Int16) As Boolean
        Dim dm As DEVMODE

        If Not EnumDisplaySettings(Nothing, 0, dm) Then
            Return False
        Else
            With dm
                .dmFields = DM_PELSWIDTH Or DM_PELSHEIGHT Or DM_BITSPERPEL
                .dmPelsWidth = Width
                .dmPelsHeight = Height
                .dmBitsPerPel = BitsPerPixel
            End With


            Return (ChangeDisplaySettings(dm, 0) = DISP_CHANGE_SUCCESSFUL)
        End If

    End Function



End Module


