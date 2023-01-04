<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HolaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HolaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlinearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IzquierdaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CentroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DerechaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstiloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NegritaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CursivaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TachadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubrayadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TamañoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConFormatoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel2.Size = New System.Drawing.Size(632, 529)
        Me.Panel2.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.RichTextBox1)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(626, 523)
        Me.Panel3.TabIndex = 9
        '
        'RichTextBox1
        '
        Me.RichTextBox1.AcceptsTab = True
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.AutoWordSelection = True
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.RichTextBox1.DetectUrls = False
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RichTextBox1.HideSelection = False
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ShortcutsEnabled = False
        Me.RichTextBox1.Size = New System.Drawing.Size(620, 491)
        Me.RichTextBox1.TabIndex = 9
        Me.RichTextBox1.Text = " "
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.ContextMenuStrip1.DropShadowEnabled = False
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HolaToolStripMenuItem, Me.HolaToolStripMenuItem1, Me.PegarToolStripMenuItem, Me.ToolStripSeparator1, Me.AlinearToolStripMenuItem, Me.EstiloToolStripMenuItem, Me.FuenteToolStripMenuItem, Me.ColorToolStripMenuItem, Me.TamañoToolStripMenuItem, Me.ToolStripSeparator2, Me.GuardarToolStripMenuItem, Me.GuardarComoToolStripMenuItem, Me.AbrirToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.ShowItemToolTips = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(151, 280)
        '
        'HolaToolStripMenuItem
        '
        Me.HolaToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.HolaToolStripMenuItem.Name = "HolaToolStripMenuItem"
        Me.HolaToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.HolaToolStripMenuItem.Text = "Cortar"
        '
        'HolaToolStripMenuItem1
        '
        Me.HolaToolStripMenuItem1.BackColor = System.Drawing.Color.Gainsboro
        Me.HolaToolStripMenuItem1.Name = "HolaToolStripMenuItem1"
        Me.HolaToolStripMenuItem1.Size = New System.Drawing.Size(150, 24)
        Me.HolaToolStripMenuItem1.Text = "Copiar"
        '
        'PegarToolStripMenuItem
        '
        Me.PegarToolStripMenuItem.Name = "PegarToolStripMenuItem"
        Me.PegarToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.PegarToolStripMenuItem.Text = "Pegar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'AlinearToolStripMenuItem
        '
        Me.AlinearToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IzquierdaToolStripMenuItem, Me.CentroToolStripMenuItem, Me.DerechaToolStripMenuItem})
        Me.AlinearToolStripMenuItem.Enabled = False
        Me.AlinearToolStripMenuItem.Name = "AlinearToolStripMenuItem"
        Me.AlinearToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.AlinearToolStripMenuItem.Text = "Alinear"
        '
        'IzquierdaToolStripMenuItem
        '
        Me.IzquierdaToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.IzquierdaToolStripMenuItem.Name = "IzquierdaToolStripMenuItem"
        Me.IzquierdaToolStripMenuItem.Size = New System.Drawing.Size(134, 24)
        Me.IzquierdaToolStripMenuItem.Text = "Izquierda"
        Me.IzquierdaToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CentroToolStripMenuItem
        '
        Me.CentroToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.CentroToolStripMenuItem.Name = "CentroToolStripMenuItem"
        Me.CentroToolStripMenuItem.Size = New System.Drawing.Size(134, 24)
        Me.CentroToolStripMenuItem.Text = "Centro"
        '
        'DerechaToolStripMenuItem
        '
        Me.DerechaToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.DerechaToolStripMenuItem.Name = "DerechaToolStripMenuItem"
        Me.DerechaToolStripMenuItem.Size = New System.Drawing.Size(134, 24)
        Me.DerechaToolStripMenuItem.Text = "Derecha"
        '
        'EstiloToolStripMenuItem
        '
        Me.EstiloToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NegritaToolStripMenuItem, Me.CursivaToolStripMenuItem, Me.TachadoToolStripMenuItem, Me.SubrayadoToolStripMenuItem})
        Me.EstiloToolStripMenuItem.Enabled = False
        Me.EstiloToolStripMenuItem.Name = "EstiloToolStripMenuItem"
        Me.EstiloToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.EstiloToolStripMenuItem.Text = "Estilo"
        '
        'NegritaToolStripMenuItem
        '
        Me.NegritaToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.NegritaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NegritaToolStripMenuItem.Name = "NegritaToolStripMenuItem"
        Me.NegritaToolStripMenuItem.Size = New System.Drawing.Size(143, 24)
        Me.NegritaToolStripMenuItem.Text = "Negrita"
        '
        'CursivaToolStripMenuItem
        '
        Me.CursivaToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.CursivaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic)
        Me.CursivaToolStripMenuItem.Name = "CursivaToolStripMenuItem"
        Me.CursivaToolStripMenuItem.Size = New System.Drawing.Size(143, 24)
        Me.CursivaToolStripMenuItem.Text = "Cursiva"
        '
        'TachadoToolStripMenuItem
        '
        Me.TachadoToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.TachadoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Strikeout)
        Me.TachadoToolStripMenuItem.Name = "TachadoToolStripMenuItem"
        Me.TachadoToolStripMenuItem.Size = New System.Drawing.Size(143, 24)
        Me.TachadoToolStripMenuItem.Text = "Tachado"
        '
        'SubrayadoToolStripMenuItem
        '
        Me.SubrayadoToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.SubrayadoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Underline)
        Me.SubrayadoToolStripMenuItem.Name = "SubrayadoToolStripMenuItem"
        Me.SubrayadoToolStripMenuItem.Size = New System.Drawing.Size(143, 24)
        Me.SubrayadoToolStripMenuItem.Text = "Subrayado"
        '
        'FuenteToolStripMenuItem
        '
        Me.FuenteToolStripMenuItem.Enabled = False
        Me.FuenteToolStripMenuItem.Name = "FuenteToolStripMenuItem"
        Me.FuenteToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.FuenteToolStripMenuItem.Text = "Fuente"
        '
        'ColorToolStripMenuItem
        '
        Me.ColorToolStripMenuItem.Enabled = False
        Me.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        Me.ColorToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.ColorToolStripMenuItem.Text = "Color"
        '
        'TamañoToolStripMenuItem
        '
        Me.TamañoToolStripMenuItem.Enabled = False
        Me.TamañoToolStripMenuItem.Name = "TamañoToolStripMenuItem"
        Me.TamañoToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.TamañoToolStripMenuItem.Text = "Tamaño"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(147, 6)
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Enabled = False
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.GuardarComoToolStripMenuItem.Text = "Guardar como..."
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlanoToolStripMenuItem1, Me.ConFormatoToolStripMenuItem1})
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(150, 24)
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'PlanoToolStripMenuItem1
        '
        Me.PlanoToolStripMenuItem1.BackColor = System.Drawing.Color.Gainsboro
        Me.PlanoToolStripMenuItem1.Name = "PlanoToolStripMenuItem1"
        Me.PlanoToolStripMenuItem1.Size = New System.Drawing.Size(156, 24)
        Me.PlanoToolStripMenuItem1.Text = "Plano"
        '
        'ConFormatoToolStripMenuItem1
        '
        Me.ConFormatoToolStripMenuItem1.BackColor = System.Drawing.Color.Gainsboro
        Me.ConFormatoToolStripMenuItem1.Name = "ConFormatoToolStripMenuItem1"
        Me.ConFormatoToolStripMenuItem1.Size = New System.Drawing.Size(156, 24)
        Me.ConFormatoToolStripMenuItem1.Text = "Con formato"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.LinkLabel2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.PictureBox3)
        Me.Panel4.Controls.Add(Me.LinkLabel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 497)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(626, 26)
        Me.Panel4.TabIndex = 10
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Enabled = False
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(70, 5)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(39, 15)
        Me.LinkLabel2.TabIndex = 12
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Plano"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "|"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.PictureBox3.Location = New System.Drawing.Point(610, 10)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(7, 5)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(53, 15)
        Me.LinkLabel1.TabIndex = 11
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Formato"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(632, 30)
        Me.Panel1.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(549, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 29)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "_"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(575, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 29)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "□"
        '
        'PictureBox5
        '
        Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(28, 30)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 3
        Me.PictureBox5.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(602, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 29)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "X"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 559)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HolaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HolaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PegarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AlinearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IzquierdaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CentroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DerechaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstiloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NegritaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CursivaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TachadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubrayadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FuenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TamañoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlanoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConFormatoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
