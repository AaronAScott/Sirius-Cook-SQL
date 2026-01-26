<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmListBoxSearch
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Option2_0 As System.Windows.Forms.RadioButton
    Public WithEvents Option2_1 As System.Windows.Forms.RadioButton
    Public WithEvents Option2_2 As System.Windows.Forms.RadioButton
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Option1_0 As System.Windows.Forms.RadioButton
    Public WithEvents Option1_1 As System.Windows.Forms.RadioButton
    Public WithEvents Option1_2 As System.Windows.Forms.RadioButton
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Combo1 As System.Windows.Forms.ComboBox
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdSearch As System.Windows.Forms.Button
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.Option2_0 = New System.Windows.Forms.RadioButton
        Me.Option2_1 = New System.Windows.Forms.RadioButton
        Me.Option2_2 = New System.Windows.Forms.RadioButton
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Option1_0 = New System.Windows.Forms.RadioButton
        Me.Option1_1 = New System.Windows.Forms.RadioButton
        Me.Option1_2 = New System.Windows.Forms.RadioButton
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.Option2_0)
        Me.Frame2.Controls.Add(Me.Option2_1)
        Me.Frame2.Controls.Add(Me.Option2_2)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(12, 176)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(301, 97)
        Me.Frame2.TabIndex = 10
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "&Match Fields"
        '
        'Option2_0
        '
        Me.Option2_0.BackColor = System.Drawing.SystemColors.Control
        Me.Option2_0.Checked = True
        Me.Option2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2_0.Location = New System.Drawing.Point(8, 20)
        Me.Option2_0.Name = "Option2_0"
        Me.Option2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2_0.Size = New System.Drawing.Size(241, 21)
        Me.Option2_0.TabIndex = 11
        Me.Option2_0.TabStop = True
        Me.Option2_0.Text = "Fields E&qual to Search Value"
        Me.Option2_0.UseVisualStyleBackColor = False
        '
        'Option2_1
        '
        Me.Option2_1.BackColor = System.Drawing.SystemColors.Control
        Me.Option2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2_1.Enabled = False
        Me.Option2_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2_1.Location = New System.Drawing.Point(8, 44)
        Me.Option2_1.Name = "Option2_1"
        Me.Option2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2_1.Size = New System.Drawing.Size(241, 21)
        Me.Option2_1.TabIndex = 12
        Me.Option2_1.TabStop = True
        Me.Option2_1.Text = "Fields &Greater or Equal to Search Value"
        Me.Option2_1.UseVisualStyleBackColor = False
        '
        'Option2_2
        '
        Me.Option2_2.BackColor = System.Drawing.SystemColors.Control
        Me.Option2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2_2.Enabled = False
        Me.Option2_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2_2.Location = New System.Drawing.Point(8, 68)
        Me.Option2_2.Name = "Option2_2"
        Me.Option2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2_2.Size = New System.Drawing.Size(241, 21)
        Me.Option2_2.TabIndex = 13
        Me.Option2_2.TabStop = True
        Me.Option2_2.Text = "Fields &Less or Equal to Search Value"
        Me.Option2_2.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Option1_0)
        Me.Frame1.Controls.Add(Me.Option1_1)
        Me.Frame1.Controls.Add(Me.Option1_2)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(12, 60)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(145, 89)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Search T&ype"
        '
        'Option1_0
        '
        Me.Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me.Option1_0.Checked = True
        Me.Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1_0.Location = New System.Drawing.Point(12, 20)
        Me.Option1_0.Name = "Option1_0"
        Me.Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1_0.Size = New System.Drawing.Size(121, 18)
        Me.Option1_0.TabIndex = 3
        Me.Option1_0.TabStop = True
        Me.Option1_0.Text = "S&tart of Field"
        Me.Option1_0.UseVisualStyleBackColor = False
        '
        'Option1_1
        '
        Me.Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me.Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1_1.Location = New System.Drawing.Point(12, 40)
        Me.Option1_1.Name = "Option1_1"
        Me.Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1_1.Size = New System.Drawing.Size(121, 18)
        Me.Option1_1.TabIndex = 4
        Me.Option1_1.TabStop = True
        Me.Option1_1.Text = "&Entire Field"
        Me.Option1_1.UseVisualStyleBackColor = False
        '
        'Option1_2
        '
        Me.Option1_2.BackColor = System.Drawing.SystemColors.Control
        Me.Option1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1_2.Location = New System.Drawing.Point(12, 60)
        Me.Option1_2.Name = "Option1_2"
        Me.Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1_2.Size = New System.Drawing.Size(121, 18)
        Me.Option1_2.TabIndex = 5
        Me.Option1_2.TabStop = True
        Me.Option1_2.Text = "Any &Part of Field"
        Me.Option1_2.UseVisualStyleBackColor = False
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(276, 96)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(145, 20)
        Me.Text1.TabIndex = 9
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(276, 68)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(145, 22)
        Me.Combo1.TabIndex = 7
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(348, 244)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(77, 29)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSearch.Enabled = False
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSearch.Location = New System.Drawing.Point(348, 208)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSearch.Size = New System.Drawing.Size(77, 29)
        Me.cmdSearch.TabIndex = 14
        Me.cmdSearch.Text = "&Search"
        Me.cmdSearch.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(172, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 21)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Search F&or:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(172, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Search in &Field:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(172, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(153, 21)
        Me.Label2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(149, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Table to Search:"
        '
        'frmListBoxSearch
        '
        Me.AcceptButton = Me.cmdSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(439, 288)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(158, 145)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListBoxSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Table"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class