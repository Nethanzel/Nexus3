<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Desktop
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Desktop))
        Me.InternetService = New System.Windows.Forms.Timer(Me.components)
        Me.TimeDateToScreen = New System.Windows.Forms.Timer(Me.components)
        Me.TimeDate = New System.Windows.Forms.Timer(Me.components)
        Me.RepNx = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GadgetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PantallaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FondoDinamicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HacerRecorteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowCursorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskBar = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AdminDeTareasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EjecutarPorComandoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.T1 = New System.Windows.Forms.Timer(Me.components)
        Me.T2 = New System.Windows.Forms.Timer(Me.components)
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.ArcTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Batery = New System.Windows.Forms.Timer(Me.components)
        Me.FondoArcoIrisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FondoArcoIris = New System.Windows.Forms.Timer(Me.components)
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.NxIcon = New System.Windows.Forms.PictureBox()
        Me.OtherIcon = New System.Windows.Forms.PictureBox()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.RepIcon = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OtherIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel17.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'InternetService
        '
        Me.InternetService.Enabled = True
        '
        'TimeDateToScreen
        '
        Me.TimeDateToScreen.Interval = 1
        '
        'TimeDate
        '
        Me.TimeDate.Enabled = True
        Me.TimeDate.Interval = 1
        '
        'RepNx
        '
        Me.RepNx.Enabled = True
        Me.RepNx.Interval = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Empty
        Me.ImageList1.Images.SetKeyName(0, "copy-icon.png")
        Me.ImageList1.Images.SetKeyName(1, "MsgEstileAdvertencia.png")
        Me.ImageList1.Images.SetKeyName(2, "MsgEstulyError.png")
        Me.ImageList1.Images.SetKeyName(3, "MsgEstulyGood.png")
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ContextMenuStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.PantallaToolStripMenuItem, Me.ConfiguracionToolStripMenuItem, Me.ShowCursorToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(182, 114)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem1.Text = "Actualizar"
        Me.ToolStripMenuItem1.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GadgetsToolStripMenuItem})
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem2.Text = "Ver"
        '
        'GadgetsToolStripMenuItem
        '
        Me.GadgetsToolStripMenuItem.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.GadgetsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.GadgetsToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.GadgetsToolStripMenuItem.Name = "GadgetsToolStripMenuItem"
        Me.GadgetsToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.GadgetsToolStripMenuItem.Text = "Gadgets"
        '
        'PantallaToolStripMenuItem
        '
        Me.PantallaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FondoDinamicoToolStripMenuItem, Me.HacerRecorteToolStripMenuItem})
        Me.PantallaToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.PantallaToolStripMenuItem.Name = "PantallaToolStripMenuItem"
        Me.PantallaToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.PantallaToolStripMenuItem.Text = "Pantalla"
        '
        'FondoDinamicoToolStripMenuItem
        '
        Me.FondoDinamicoToolStripMenuItem.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.FondoDinamicoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FondoArcoIrisToolStripMenuItem})
        Me.FondoDinamicoToolStripMenuItem.Name = "FondoDinamicoToolStripMenuItem"
        Me.FondoDinamicoToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.FondoDinamicoToolStripMenuItem.Text = "Fondo dinamico"
        '
        'HacerRecorteToolStripMenuItem
        '
        Me.HacerRecorteToolStripMenuItem.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.HacerRecorteToolStripMenuItem.Name = "HacerRecorteToolStripMenuItem"
        Me.HacerRecorteToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.HacerRecorteToolStripMenuItem.Text = "Hacer recorte"
        '
        'ConfiguracionToolStripMenuItem
        '
        Me.ConfiguracionToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem"
        Me.ConfiguracionToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ConfiguracionToolStripMenuItem.Text = "Configuracion"
        '
        'ShowCursorToolStripMenuItem
        '
        Me.ShowCursorToolStripMenuItem.Name = "ShowCursorToolStripMenuItem"
        Me.ShowCursorToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ShowCursorToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ShowCursorToolStripMenuItem.Text = "Show Cursor"
        Me.ShowCursorToolStripMenuItem.Visible = False
        '
        'TaskBar
        '
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminDeTareasToolStripMenuItem, Me.EjecutarPorComandoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(205, 48)
        '
        'AdminDeTareasToolStripMenuItem
        '
        Me.AdminDeTareasToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.AdminDeTareasToolStripMenuItem.Name = "AdminDeTareasToolStripMenuItem"
        Me.AdminDeTareasToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.AdminDeTareasToolStripMenuItem.Text = "Admin. de tareas"
        '
        'EjecutarPorComandoToolStripMenuItem
        '
        Me.EjecutarPorComandoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.EjecutarPorComandoToolStripMenuItem.Name = "EjecutarPorComandoToolStripMenuItem"
        Me.EjecutarPorComandoToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.EjecutarPorComandoToolStripMenuItem.Text = "Ejecutar desde comando"
        '
        'T1
        '
        Me.T1.Interval = 10
        '
        'T2
        '
        Me.T2.Interval = 10
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.IncludeSubdirectories = True
        Me.FileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.LastWrite
        Me.FileSystemWatcher1.Path = "N:\Nexus\AppWork\Interface"
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'ArcTimer
        '
        Me.ArcTimer.Interval = 25
        '
        'Batery
        '
        Me.Batery.Interval = 200
        '
        'FondoArcoIrisToolStripMenuItem
        '
        Me.FondoArcoIrisToolStripMenuItem.Name = "FondoArcoIrisToolStripMenuItem"
        Me.FondoArcoIrisToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FondoArcoIrisToolStripMenuItem.Text = "Fondo arco iris"
        '
        'FondoArcoIris
        '
        Me.FondoArcoIris.Interval = 3
        '
        'Panel14
        '
        Me.Panel14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel14.BackColor = System.Drawing.Color.Transparent
        Me.Panel14.BackgroundImage = CType(resources.GetObject("Panel14.BackgroundImage"), System.Drawing.Image)
        Me.Panel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel14.Location = New System.Drawing.Point(0, 471)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(60, 60)
        Me.Panel14.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel19)
        Me.Panel1.Controls.Add(Me.Panel18)
        Me.Panel1.Controls.Add(Me.Panel17)
        Me.Panel1.Controls.Add(Me.Panel16)
        Me.Panel1.Controls.Add(Me.RepIcon)
        Me.Panel1.Location = New System.Drawing.Point(-1, 482)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1040, 50)
        Me.Panel1.TabIndex = 0
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.Panel4)
        Me.Panel19.Controls.Add(Me.PictureBox4)
        Me.Panel19.Controls.Add(Me.NxIcon)
        Me.Panel19.Controls.Add(Me.OtherIcon)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel19.Location = New System.Drawing.Point(828, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(82, 48)
        Me.Panel19.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Location = New System.Drawing.Point(30, 14)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(22, 22)
        Me.Panel4.TabIndex = 13
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Location = New System.Drawing.Point(1, 6)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(18, 11)
        Me.Panel5.TabIndex = 13
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel6.Location = New System.Drawing.Point(-1, -1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 13)
        Me.Panel6.TabIndex = 13
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Image = Global.NxDesktop.My.Resources.Resources.Off
        Me.PictureBox4.Location = New System.Drawing.Point(56, 16)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 4
        Me.PictureBox4.TabStop = False
        '
        'NxIcon
        '
        Me.NxIcon.Location = New System.Drawing.Point(-32, 15)
        Me.NxIcon.Name = "NxIcon"
        Me.NxIcon.Size = New System.Drawing.Size(22, 22)
        Me.NxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NxIcon.TabIndex = 3
        Me.NxIcon.TabStop = False
        Me.NxIcon.Visible = False
        '
        'OtherIcon
        '
        Me.OtherIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.OtherIcon.Image = CType(resources.GetObject("OtherIcon.Image"), System.Drawing.Image)
        Me.OtherIcon.Location = New System.Drawing.Point(5, 14)
        Me.OtherIcon.Name = "OtherIcon"
        Me.OtherIcon.Size = New System.Drawing.Size(22, 22)
        Me.OtherIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OtherIcon.TabIndex = 2
        Me.OtherIcon.TabStop = False
        '
        'Panel18
        '
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel18.Location = New System.Drawing.Point(910, 0)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(3, 48)
        Me.Panel18.TabIndex = 6
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.Panel3)
        Me.Panel17.Controls.Add(Me.Panel2)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel17.Location = New System.Drawing.Point(913, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.Panel17.Size = New System.Drawing.Size(125, 48)
        Me.Panel17.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(97, 48)
        Me.Panel3.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "00/00/0000"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "00:00:00 a.m."
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(97, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(26, 48)
        Me.Panel2.TabIndex = 2
        '
        'Panel16
        '
        Me.Panel16.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel16.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Panel16.Location = New System.Drawing.Point(114, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(713, 48)
        Me.Panel16.TabIndex = 4
        '
        'RepIcon
        '
        Me.RepIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RepIcon.BackColor = System.Drawing.Color.Transparent
        Me.RepIcon.BackgroundImage = CType(resources.GetObject("RepIcon.BackgroundImage"), System.Drawing.Image)
        Me.RepIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RepIcon.Location = New System.Drawing.Point(63, 0)
        Me.RepIcon.Name = "RepIcon"
        Me.RepIcon.Size = New System.Drawing.Size(48, 48)
        Me.RepIcon.TabIndex = 5
        '
        'Desktop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1036, 532)
        Me.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel14)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Desktop"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OtherIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel17.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents NxIcon As System.Windows.Forms.PictureBox
    Friend WithEvents OtherIcon As System.Windows.Forms.PictureBox
    Friend WithEvents InternetService As System.Windows.Forms.Timer
    Friend WithEvents TimeDateToScreen As System.Windows.Forms.Timer
    Friend WithEvents TimeDate As System.Windows.Forms.Timer
    Friend WithEvents RepNx As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TaskBar As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AdminDeTareasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EjecutarPorComandoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GadgetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PantallaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguracionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FondoDinamicoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T1 As System.Windows.Forms.Timer
    Friend WithEvents T2 As System.Windows.Forms.Timer
    Friend WithEvents ShowCursorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents RepIcon As System.Windows.Forms.Panel
    Friend WithEvents HacerRecorteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ArcTimer As System.Windows.Forms.Timer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Batery As System.Windows.Forms.Timer
    Friend WithEvents FondoArcoIrisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FondoArcoIris As System.Windows.Forms.Timer
End Class
