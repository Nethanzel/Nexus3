<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IconsForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Icon3 = New System.Windows.Forms.PictureBox()
        Me.Icon2 = New System.Windows.Forms.PictureBox()
        Me.Icon1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.Icon3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Icon2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Icon1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Icon3)
        Me.Panel1.Controls.Add(Me.Icon2)
        Me.Panel1.Controls.Add(Me.Icon1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(86, 30)
        Me.Panel1.TabIndex = 0
        '
        'Icon3
        '
        Me.Icon3.BackColor = System.Drawing.Color.Silver
        Me.Icon3.Location = New System.Drawing.Point(59, 3)
        Me.Icon3.Name = "Icon3"
        Me.Icon3.Size = New System.Drawing.Size(22, 22)
        Me.Icon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Icon3.TabIndex = 6
        Me.Icon3.TabStop = False
        Me.Icon3.Visible = False
        '
        'Icon2
        '
        Me.Icon2.BackColor = System.Drawing.Color.Silver
        Me.Icon2.Location = New System.Drawing.Point(31, 3)
        Me.Icon2.Name = "Icon2"
        Me.Icon2.Size = New System.Drawing.Size(22, 22)
        Me.Icon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Icon2.TabIndex = 5
        Me.Icon2.TabStop = False
        Me.Icon2.Visible = False
        '
        'Icon1
        '
        Me.Icon1.BackColor = System.Drawing.Color.Silver
        Me.Icon1.Location = New System.Drawing.Point(3, 3)
        Me.Icon1.Name = "Icon1"
        Me.Icon1.Size = New System.Drawing.Size(22, 22)
        Me.Icon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Icon1.TabIndex = 4
        Me.Icon1.TabStop = False
        Me.Icon1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'IconsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(90, 34)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "IconsForm"
        Me.Opacity = 0.0R
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        CType(Me.Icon3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Icon2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Icon1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Icon1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Icon3 As System.Windows.Forms.PictureBox
    Friend WithEvents Icon2 As System.Windows.Forms.PictureBox
End Class
