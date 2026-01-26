<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmListBox
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
    Public WithEvents txtSearchFor As System.Windows.Forms.TextBox
    Public WithEvents btnSearch As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents btnSelect As System.Windows.Forms.Button
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents Label2_0 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListBox))
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.txtSearchFor = New System.Windows.Forms.TextBox()
		Me.btnSearch = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSelect = New System.Windows.Forms.Button()
		Me.Image1 = New System.Windows.Forms.PictureBox()
		Me.Label2_0 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Picture1 = New System.Windows.Forms.PictureBox()
		Me.VScroll1 = New System.Windows.Forms.VScrollBar()
		Me.btnColumnHeader_6 = New System.Windows.Forms.Button()
		CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'txtSearchFor
		'
		Me.txtSearchFor.AcceptsReturn = True
		Me.txtSearchFor.BackColor = System.Drawing.SystemColors.Window
		Me.txtSearchFor.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSearchFor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSearchFor.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSearchFor.Location = New System.Drawing.Point(168, 52)
		Me.txtSearchFor.MaxLength = 0
		Me.txtSearchFor.Name = "txtSearchFor"
		Me.txtSearchFor.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSearchFor.Size = New System.Drawing.Size(121, 20)
		Me.txtSearchFor.TabIndex = 1
		'
		'btnSearch
		'
		Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
		Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
		Me.btnSearch.Location = New System.Drawing.Point(300, 306)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnSearch.Size = New System.Drawing.Size(66, 60)
		Me.btnSearch.TabIndex = 4
		Me.btnSearch.Text = "&Search"
		Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnSearch.UseVisualStyleBackColor = False
		'
		'btnCancel
		'
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
		Me.btnCancel.Location = New System.Drawing.Point(300, 223)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCancel.Size = New System.Drawing.Size(66, 60)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "&Cancel"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnCancel.UseVisualStyleBackColor = False
		'
		'btnSelect
		'
		Me.btnSelect.BackColor = System.Drawing.SystemColors.Control
		Me.btnSelect.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnSelect.Enabled = False
		Me.btnSelect.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSelect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnSelect.Image = CType(resources.GetObject("btnSelect.Image"), System.Drawing.Image)
		Me.btnSelect.Location = New System.Drawing.Point(300, 140)
		Me.btnSelect.Name = "btnSelect"
		Me.btnSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnSelect.Size = New System.Drawing.Size(66, 60)
		Me.btnSelect.TabIndex = 2
		Me.btnSelect.Text = "&Select"
		Me.btnSelect.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnSelect.UseVisualStyleBackColor = False
		'
		'Image1
		'
		Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
		Me.Image1.Location = New System.Drawing.Point(10, 38)
		Me.Image1.Name = "Image1"
		Me.Image1.Size = New System.Drawing.Size(32, 32)
		Me.Image1.TabIndex = 16
		Me.Image1.TabStop = False
		'
		'Label2_0
		'
		Me.Label2_0.BackColor = System.Drawing.SystemColors.Control
		Me.Label2_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2_0.Location = New System.Drawing.Point(12, 4)
		Me.Label2_0.Name = "Label2_0"
		Me.Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2_0.Size = New System.Drawing.Size(277, 31)
		Me.Label2_0.TabIndex = 14
		Me.Label2_0.Text = "Type characters into the field below to search the currently sorted column for th" &
	"e closest occurence."
		'
		'Label1
		'
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label1.Location = New System.Drawing.Point(60, 52)
		Me.Label1.Name = "Label1"
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.Size = New System.Drawing.Size(109, 21)
		Me.Label1.TabIndex = 0
		'
		'Picture1
		'
		Me.Picture1.BackColor = System.Drawing.SystemColors.Window
		Me.Picture1.Location = New System.Drawing.Point(13, 143)
		Me.Picture1.Name = "Picture1"
		Me.Picture1.Size = New System.Drawing.Size(267, 222)
		Me.Picture1.TabIndex = 17
		Me.Picture1.TabStop = False
		'
		'VScroll1
		'
		Me.VScroll1.Location = New System.Drawing.Point(266, 140)
		Me.VScroll1.Name = "VScroll1"
		Me.VScroll1.Size = New System.Drawing.Size(15, 222)
		Me.VScroll1.TabIndex = 18
		'
		'btnColumnHeader_6
		'
		Me.btnColumnHeader_6.BackColor = System.Drawing.SystemColors.Control
		Me.btnColumnHeader_6.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnColumnHeader_6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnColumnHeader_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnColumnHeader_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnColumnHeader_6.Location = New System.Drawing.Point(266, 119)
		Me.btnColumnHeader_6.Name = "btnColumnHeader_6"
		Me.btnColumnHeader_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnColumnHeader_6.Size = New System.Drawing.Size(15, 21)
		Me.btnColumnHeader_6.TabIndex = 13
		Me.btnColumnHeader_6.UseVisualStyleBackColor = False
		Me.btnColumnHeader_6.Visible = False
		'
		'frmListBox
		'
		Me.AcceptButton = Me.btnSelect
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(388, 381)
		Me.ControlBox = False
		Me.Controls.Add(Me.VScroll1)
		Me.Controls.Add(Me.Picture1)
		Me.Controls.Add(Me.btnColumnHeader_6)
		Me.Controls.Add(Me.txtSearchFor)
		Me.Controls.Add(Me.btnSearch)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnSelect)
		Me.Controls.Add(Me.Image1)
		Me.Controls.Add(Me.Label2_0)
		Me.Controls.Add(Me.Label1)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = True
		Me.Location = New System.Drawing.Point(128, 78)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmListBox"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.TopMost = True
		CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Picture1 As System.Windows.Forms.PictureBox
    Friend WithEvents VScroll1 As System.Windows.Forms.VScrollBar
    Public WithEvents btnColumnHeader_6 As System.Windows.Forms.Button
#End Region 
End Class