<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSearchLibrary
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
    Public WithEvents Option1_1 As System.Windows.Forms.RadioButton
    Public WithEvents Option1_0 As System.Windows.Forms.RadioButton
    Public WithEvents Check1_1 As System.Windows.Forms.CheckBox
    Public WithEvents Check1_0 As System.Windows.Forms.CheckBox
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents btnShow As System.Windows.Forms.Button
    Public WithEvents btnFind As System.Windows.Forms.Button
    Public WithEvents btnHeader_2 As System.Windows.Forms.Button
    Public WithEvents btnHeader_1 As System.Windows.Forms.Button
    Public WithEvents btnHeader_0 As System.Windows.Forms.Button
    Public WithEvents VScroll1 As System.Windows.Forms.VScrollBar
    Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _Line1_1 As System.Windows.Forms.Label
    Public WithEvents _Line1_0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchLibrary))
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.Option1_1 = New System.Windows.Forms.RadioButton()
		Me.Option1_0 = New System.Windows.Forms.RadioButton()
		Me.Check1_1 = New System.Windows.Forms.CheckBox()
		Me.Check1_0 = New System.Windows.Forms.CheckBox()
		Me.Text1 = New System.Windows.Forms.TextBox()
		Me.btnShow = New System.Windows.Forms.Button()
		Me.btnFind = New System.Windows.Forms.Button()
		Me.btnHeader_2 = New System.Windows.Forms.Button()
		Me.btnHeader_1 = New System.Windows.Forms.Button()
		Me.btnHeader_0 = New System.Windows.Forms.Button()
		Me.VScroll1 = New System.Windows.Forms.VScrollBar()
		Me.Picture1 = New System.Windows.Forms.PictureBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me._Line1_1 = New System.Windows.Forms.Label()
		Me._Line1_0 = New System.Windows.Forms.Label()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.Option1_2 = New System.Windows.Forms.RadioButton()
		Me.btnHeader_3 = New System.Windows.Forms.Button()
		Me.Check1_2 = New System.Windows.Forms.CheckBox()
		CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Option1_1
		'
		Me.Option1_1.BackColor = System.Drawing.SystemColors.Control
		Me.Option1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Option1_1.Checked = True
		Me.Option1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option1_1.Location = New System.Drawing.Point(248, 65)
		Me.Option1_1.Name = "Option1_1"
		Me.Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option1_1.Size = New System.Drawing.Size(161, 18)
		Me.Option1_1.TabIndex = 6
		Me.Option1_1.TabStop = True
		Me.Option1_1.Text = "Match Any &Word"
		Me.Option1_1.UseVisualStyleBackColor = False
		'
		'Option1_0
		'
		Me.Option1_0.BackColor = System.Drawing.SystemColors.Control
		Me.Option1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Option1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option1_0.Location = New System.Drawing.Point(248, 44)
		Me.Option1_0.Name = "Option1_0"
		Me.Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option1_0.Size = New System.Drawing.Size(161, 18)
		Me.Option1_0.TabIndex = 5
		Me.Option1_0.Text = "Match &All Words"
		Me.Option1_0.UseVisualStyleBackColor = False
		'
		'Check1_1
		'
		Me.Check1_1.BackColor = System.Drawing.SystemColors.Control
		Me.Check1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Check1_1.Checked = True
		Me.Check1_1.CheckState = System.Windows.Forms.CheckState.Checked
		Me.Check1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Check1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Check1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Check1_1.Location = New System.Drawing.Point(12, 65)
		Me.Check1_1.Name = "Check1_1"
		Me.Check1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Check1_1.Size = New System.Drawing.Size(120, 18)
		Me.Check1_1.TabIndex = 3
		Me.Check1_1.Text = "Search Ingredients"
		Me.Check1_1.UseVisualStyleBackColor = False
		'
		'Check1_0
		'
		Me.Check1_0.BackColor = System.Drawing.SystemColors.Control
		Me.Check1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Check1_0.Checked = True
		Me.Check1_0.CheckState = System.Windows.Forms.CheckState.Checked
		Me.Check1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.Check1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Check1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Check1_0.Location = New System.Drawing.Point(12, 44)
		Me.Check1_0.Name = "Check1_0"
		Me.Check1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Check1_0.Size = New System.Drawing.Size(120, 18)
		Me.Check1_0.TabIndex = 2
		Me.Check1_0.Text = "Search Titles"
		Me.Check1_0.UseVisualStyleBackColor = False
		'
		'Text1
		'
		Me.Text1.AcceptsReturn = True
		Me.Text1.BackColor = System.Drawing.SystemColors.Window
		Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text1.Location = New System.Drawing.Point(116, 12)
		Me.Text1.MaxLength = 0
		Me.Text1.Name = "Text1"
		Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text1.Size = New System.Drawing.Size(293, 20)
		Me.Text1.TabIndex = 1
		'
		'btnShow
		'
		Me.btnShow.BackColor = System.Drawing.SystemColors.Control
		Me.btnShow.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnShow.Enabled = False
		Me.btnShow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnShow.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
		Me.btnShow.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnShow.Location = New System.Drawing.Point(501, 114)
		Me.btnShow.Name = "btnShow"
		Me.btnShow.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnShow.Size = New System.Drawing.Size(71, 71)
		Me.btnShow.TabIndex = 13
		Me.btnShow.Text = "Show  &Recipe"
		Me.btnShow.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnShow.UseVisualStyleBackColor = False
		'
		'btnFind
		'
		Me.btnFind.BackColor = System.Drawing.SystemColors.Control
		Me.btnFind.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnFind.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
		Me.btnFind.Location = New System.Drawing.Point(501, 12)
		Me.btnFind.Name = "btnFind"
		Me.btnFind.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnFind.Size = New System.Drawing.Size(71, 71)
		Me.btnFind.TabIndex = 12
		Me.btnFind.Text = "&Find"
		Me.btnFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnFind.UseVisualStyleBackColor = False
		'
		'btnHeader_2
		'
		Me.btnHeader_2.BackColor = System.Drawing.SystemColors.Control
		Me.btnHeader_2.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnHeader_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnHeader_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnHeader_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnHeader_2.Location = New System.Drawing.Point(295, 114)
		Me.btnHeader_2.Name = "btnHeader_2"
		Me.btnHeader_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnHeader_2.Size = New System.Drawing.Size(163, 28)
		Me.btnHeader_2.TabIndex = 10
		Me.btnHeader_2.Text = "Cookbook Title"
		Me.btnHeader_2.UseVisualStyleBackColor = False
		'
		'btnHeader_1
		'
		Me.btnHeader_1.BackColor = System.Drawing.SystemColors.Control
		Me.btnHeader_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnHeader_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnHeader_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnHeader_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnHeader_1.Location = New System.Drawing.Point(200, 114)
		Me.btnHeader_1.Name = "btnHeader_1"
		Me.btnHeader_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnHeader_1.Size = New System.Drawing.Size(96, 28)
		Me.btnHeader_1.TabIndex = 9
		Me.btnHeader_1.Text = "Author"
		Me.btnHeader_1.UseVisualStyleBackColor = False
		'
		'btnHeader_0
		'
		Me.btnHeader_0.BackColor = System.Drawing.SystemColors.Control
		Me.btnHeader_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnHeader_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnHeader_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnHeader_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnHeader_0.Location = New System.Drawing.Point(4, 114)
		Me.btnHeader_0.Name = "btnHeader_0"
		Me.btnHeader_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnHeader_0.Size = New System.Drawing.Size(197, 28)
		Me.btnHeader_0.TabIndex = 8
		Me.btnHeader_0.Text = "Recipe Name"
		Me.btnHeader_0.UseVisualStyleBackColor = False
		'
		'VScroll1
		'
		Me.VScroll1.Cursor = System.Windows.Forms.Cursors.Default
		Me.VScroll1.LargeChange = 1
		Me.VScroll1.Location = New System.Drawing.Point(457, 138)
		Me.VScroll1.Maximum = 32767
		Me.VScroll1.Name = "VScroll1"
		Me.VScroll1.Size = New System.Drawing.Size(17, 229)
		Me.VScroll1.TabIndex = 11
		Me.VScroll1.TabStop = True
		'
		'Picture1
		'
		Me.Picture1.BackColor = System.Drawing.SystemColors.Window
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture1.Location = New System.Drawing.Point(4, 141)
		Me.Picture1.Name = "Picture1"
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Size = New System.Drawing.Size(468, 228)
		Me.Picture1.TabIndex = 10
		Me.Picture1.TabStop = False
		'
		'Label1
		'
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Location = New System.Drawing.Point(12, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.Size = New System.Drawing.Size(101, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "&Search For:"
		'
		'_Line1_1
		'
		Me._Line1_1.BackColor = System.Drawing.SystemColors.ControlLight
		Me._Line1_1.Location = New System.Drawing.Point(0, 2)
		Me._Line1_1.Name = "_Line1_1"
		Me._Line1_1.Size = New System.Drawing.Size(472, 1)
		Me._Line1_1.TabIndex = 14
		'
		'_Line1_0
		'
		Me._Line1_0.BackColor = System.Drawing.SystemColors.ControlDark
		Me._Line1_0.Location = New System.Drawing.Point(0, 0)
		Me._Line1_0.Name = "_Line1_0"
		Me._Line1_0.Size = New System.Drawing.Size(472, 1)
		Me._Line1_0.TabIndex = 15
		'
		'btnClose
		'
		Me.btnClose.BackColor = System.Drawing.SystemColors.Control
		Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
		Me.btnClose.Location = New System.Drawing.Point(501, 216)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnClose.Size = New System.Drawing.Size(71, 71)
		Me.btnClose.TabIndex = 14
		Me.btnClose.Text = "&Close"
		Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnClose.UseVisualStyleBackColor = False
		'
		'Option1_2
		'
		Me.Option1_2.BackColor = System.Drawing.SystemColors.Control
		Me.Option1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Option1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option1_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option1_2.Location = New System.Drawing.Point(248, 86)
		Me.Option1_2.Name = "Option1_2"
		Me.Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option1_2.Size = New System.Drawing.Size(161, 18)
		Me.Option1_2.TabIndex = 7
		Me.Option1_2.Text = "Match Entire &Text"
		Me.Option1_2.UseVisualStyleBackColor = False
		'
		'btnHeader_3
		'
		Me.btnHeader_3.BackColor = System.Drawing.SystemColors.Control
		Me.btnHeader_3.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnHeader_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnHeader_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnHeader_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnHeader_3.Location = New System.Drawing.Point(457, 114)
		Me.btnHeader_3.Name = "btnHeader_3"
		Me.btnHeader_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnHeader_3.Size = New System.Drawing.Size(17, 28)
		Me.btnHeader_3.TabIndex = 16
		Me.btnHeader_3.UseVisualStyleBackColor = False
		'
		'Check1_2
		'
		Me.Check1_2.BackColor = System.Drawing.SystemColors.Control
		Me.Check1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Check1_2.Checked = True
		Me.Check1_2.CheckState = System.Windows.Forms.CheckState.Checked
		Me.Check1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Check1_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Check1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Check1_2.Location = New System.Drawing.Point(12, 86)
		Me.Check1_2.Name = "Check1_2"
		Me.Check1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Check1_2.Size = New System.Drawing.Size(120, 18)
		Me.Check1_2.TabIndex = 4
		Me.Check1_2.Text = "Search Procedures"
		Me.Check1_2.UseVisualStyleBackColor = False
		'
		'frmSearchLibrary
		'
		Me.AcceptButton = Me.btnFind
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ClientSize = New System.Drawing.Size(599, 379)
		Me.Controls.Add(Me.Check1_2)
		Me.Controls.Add(Me.btnHeader_3)
		Me.Controls.Add(Me.Option1_2)
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.Option1_1)
		Me.Controls.Add(Me.Option1_0)
		Me.Controls.Add(Me.Check1_1)
		Me.Controls.Add(Me.Check1_0)
		Me.Controls.Add(Me.Text1)
		Me.Controls.Add(Me.btnShow)
		Me.Controls.Add(Me.btnFind)
		Me.Controls.Add(Me.btnHeader_2)
		Me.Controls.Add(Me.btnHeader_1)
		Me.Controls.Add(Me.btnHeader_0)
		Me.Controls.Add(Me.VScroll1)
		Me.Controls.Add(Me.Picture1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me._Line1_1)
		Me.Controls.Add(Me._Line1_0)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.Location = New System.Drawing.Point(147, 116)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmSearchLibrary"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Search Library"
		CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents Option1_2 As System.Windows.Forms.RadioButton
	Public WithEvents btnHeader_3 As System.Windows.Forms.Button
	Public WithEvents Check1_2 As CheckBox
#End Region
End Class