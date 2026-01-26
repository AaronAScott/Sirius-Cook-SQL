<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEmail
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
	Public WithEvents cmdSend As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents txtMessage As System.Windows.Forms.TextBox
    Public WithEvents txtSubject As System.Windows.Forms.TextBox
    Public WithEvents txtEmail As System.Windows.Forms.TextBox
    Public WithEvents Option1_3 As System.Windows.Forms.RadioButton
    Public WithEvents Option1_2 As System.Windows.Forms.RadioButton
    Public WithEvents Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Label1_0 As System.Windows.Forms.Label
    Public WithEvents Label1_3 As System.Windows.Forms.Label
    Public WithEvents Label1_2 As System.Windows.Forms.Label
    Public WithEvents Label1_1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmail))
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.cmdSend = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.txtName = New System.Windows.Forms.TextBox()
		Me.txtMessage = New System.Windows.Forms.TextBox()
		Me.txtSubject = New System.Windows.Forms.TextBox()
		Me.txtEmail = New System.Windows.Forms.TextBox()
		Me.Frame1 = New System.Windows.Forms.GroupBox()
		Me.chkIncludeImage = New System.Windows.Forms.CheckBox()
		Me.Option1_3 = New System.Windows.Forms.RadioButton()
		Me.Option1_2 = New System.Windows.Forms.RadioButton()
		Me.Option1_1 = New System.Windows.Forms.RadioButton()
		Me.Label1_0 = New System.Windows.Forms.Label()
		Me.Label1_3 = New System.Windows.Forms.Label()
		Me.Label1_2 = New System.Windows.Forms.Label()
		Me.Label1_1 = New System.Windows.Forms.Label()
		Me.txtSender = New System.Windows.Forms.TextBox()
		Me.Label1_4 = New System.Windows.Forms.Label()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		'
		'cmdSend
		'
		Me.cmdSend.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSend.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSend.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSend.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSend.Image = CType(resources.GetObject("cmdSend.Image"), System.Drawing.Image)
		Me.cmdSend.Location = New System.Drawing.Point(416, 12)
		Me.cmdSend.Name = "cmdSend"
		Me.cmdSend.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSend.Size = New System.Drawing.Size(81, 61)
		Me.cmdSend.TabIndex = 16
		Me.cmdSend.Text = "&Send"
		Me.cmdSend.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdSend.UseVisualStyleBackColor = False
		'
		'cmdClose
		'
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
		Me.cmdClose.Location = New System.Drawing.Point(416, 78)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Size = New System.Drawing.Size(81, 61)
		Me.cmdClose.TabIndex = 17
		Me.cmdClose.Text = "&Close"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdClose.UseVisualStyleBackColor = False
		'
		'txtName
		'
		Me.txtName.AcceptsReturn = True
		Me.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
		Me.txtName.BackColor = System.Drawing.SystemColors.Window
		Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtName.Location = New System.Drawing.Point(110, 178)
		Me.txtName.MaxLength = 0
		Me.txtName.Name = "txtName"
		Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtName.Size = New System.Drawing.Size(161, 20)
		Me.txtName.TabIndex = 6
		'
		'txtMessage
		'
		Me.txtMessage.AcceptsReturn = True
		Me.txtMessage.BackColor = System.Drawing.SystemColors.Window
		Me.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMessage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMessage.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMessage.Location = New System.Drawing.Point(110, 266)
		Me.txtMessage.MaxLength = 0
		Me.txtMessage.Multiline = True
		Me.txtMessage.Name = "txtMessage"
		Me.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtMessage.Size = New System.Drawing.Size(389, 81)
		Me.txtMessage.TabIndex = 13
		'
		'txtSubject
		'
		Me.txtSubject.AcceptsReturn = True
		Me.txtSubject.BackColor = System.Drawing.SystemColors.Window
		Me.txtSubject.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSubject.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSubject.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSubject.Location = New System.Drawing.Point(110, 237)
		Me.txtSubject.MaxLength = 0
		Me.txtSubject.Name = "txtSubject"
		Me.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSubject.Size = New System.Drawing.Size(161, 20)
		Me.txtSubject.TabIndex = 11
		'
		'txtEmail
		'
		Me.txtEmail.AcceptsReturn = True
		Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
		Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEmail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEmail.Location = New System.Drawing.Point(110, 207)
		Me.txtEmail.MaxLength = 0
		Me.txtEmail.Name = "txtEmail"
		Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEmail.Size = New System.Drawing.Size(161, 20)
		Me.txtEmail.TabIndex = 9
		'
		'Frame1
		'
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Controls.Add(Me.chkIncludeImage)
		Me.Frame1.Controls.Add(Me.Option1_3)
		Me.Frame1.Controls.Add(Me.Option1_2)
		Me.Frame1.Controls.Add(Me.Option1_1)
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.Location = New System.Drawing.Point(16, 4)
		Me.Frame1.Name = "Frame1"
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Size = New System.Drawing.Size(181, 135)
		Me.Frame1.TabIndex = 0
		Me.Frame1.TabStop = False
		Me.Frame1.Text = "&Format"
		'
		'chkIncludeImage
		'
		Me.chkIncludeImage.AutoSize = True
		Me.chkIncludeImage.Enabled = False
		Me.chkIncludeImage.Location = New System.Drawing.Point(14, 109)
		Me.chkIncludeImage.Name = "chkIncludeImage"
		Me.chkIncludeImage.Size = New System.Drawing.Size(132, 18)
		Me.chkIncludeImage.TabIndex = 5
		Me.chkIncludeImage.Text = "Include &Image, (if any)"
		Me.chkIncludeImage.UseVisualStyleBackColor = True
		'
		'Option1_3
		'
		Me.Option1_3.BackColor = System.Drawing.SystemColors.Control
		Me.Option1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option1_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Option1_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option1_3.Location = New System.Drawing.Point(14, 74)
		Me.Option1_3.Name = "Option1_3"
		Me.Option1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option1_3.Size = New System.Drawing.Size(161, 19)
		Me.Option1_3.TabIndex = 4
		Me.Option1_3.TabStop = True
		Me.Option1_3.Text = "Send in &Exchange Format"
		Me.Option1_3.UseVisualStyleBackColor = False
		'
		'Option1_2
		'
		Me.Option1_2.BackColor = System.Drawing.SystemColors.Control
		Me.Option1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option1_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option1_2.Location = New System.Drawing.Point(14, 49)
		Me.Option1_2.Name = "Option1_2"
		Me.Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option1_2.Size = New System.Drawing.Size(161, 19)
		Me.Option1_2.TabIndex = 3
		Me.Option1_2.TabStop = True
		Me.Option1_2.Text = "Send as &HTML Attachment"
		Me.Option1_2.UseVisualStyleBackColor = False
		'
		'Option1_1
		'
		Me.Option1_1.BackColor = System.Drawing.SystemColors.Control
		Me.Option1_1.Checked = True
		Me.Option1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option1_1.Location = New System.Drawing.Point(14, 21)
		Me.Option1_1.Name = "Option1_1"
		Me.Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option1_1.Size = New System.Drawing.Size(161, 19)
		Me.Option1_1.TabIndex = 2
		Me.Option1_1.TabStop = True
		Me.Option1_1.Text = "Send as &RTF Attachment"
		Me.Option1_1.UseVisualStyleBackColor = False
		'
		'Label1_0
		'
		Me.Label1_0.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1_0.Location = New System.Drawing.Point(18, 178)
		Me.Label1_0.Name = "Label1_0"
		Me.Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_0.Size = New System.Drawing.Size(85, 21)
		Me.Label1_0.TabIndex = 5
		Me.Label1_0.Text = "Recipient Name:"
		'
		'Label1_3
		'
		Me.Label1_3.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1_3.Location = New System.Drawing.Point(18, 266)
		Me.Label1_3.Name = "Label1_3"
		Me.Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_3.Size = New System.Drawing.Size(85, 21)
		Me.Label1_3.TabIndex = 12
		Me.Label1_3.Text = "&Message:"
		'
		'Label1_2
		'
		Me.Label1_2.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1_2.Location = New System.Drawing.Point(18, 237)
		Me.Label1_2.Name = "Label1_2"
		Me.Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_2.Size = New System.Drawing.Size(85, 21)
		Me.Label1_2.TabIndex = 10
		Me.Label1_2.Text = "Su&bject:"
		'
		'Label1_1
		'
		Me.Label1_1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1_1.Location = New System.Drawing.Point(18, 207)
		Me.Label1_1.Name = "Label1_1"
		Me.Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_1.Size = New System.Drawing.Size(85, 21)
		Me.Label1_1.TabIndex = 8
		Me.Label1_1.Text = "&EMail Addresss:"
		'
		'txtSender
		'
		Me.txtSender.AcceptsReturn = True
		Me.txtSender.BackColor = System.Drawing.SystemColors.Window
		Me.txtSender.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSender.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSender.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSender.Location = New System.Drawing.Point(110, 353)
		Me.txtSender.MaxLength = 0
		Me.txtSender.Name = "txtSender"
		Me.txtSender.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSender.Size = New System.Drawing.Size(161, 20)
		Me.txtSender.TabIndex = 15
		'
		'Label1_4
		'
		Me.Label1_4.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1_4.Location = New System.Drawing.Point(18, 353)
		Me.Label1_4.Name = "Label1_4"
		Me.Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_4.Size = New System.Drawing.Size(85, 21)
		Me.Label1_4.TabIndex = 14
		Me.Label1_4.Text = "&Sender Email:"
		'
		'frmEmail
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(518, 392)
		Me.Controls.Add(Me.txtSender)
		Me.Controls.Add(Me.Label1_4)
		Me.Controls.Add(Me.cmdSend)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.txtName)
		Me.Controls.Add(Me.txtMessage)
		Me.Controls.Add(Me.txtSubject)
		Me.Controls.Add(Me.txtEmail)
		Me.Controls.Add(Me.Frame1)
		Me.Controls.Add(Me.Label1_0)
		Me.Controls.Add(Me.Label1_3)
		Me.Controls.Add(Me.Label1_2)
		Me.Controls.Add(Me.Label1_1)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Location = New System.Drawing.Point(152, 100)
		Me.MaximizeBox = False
		Me.Name = "frmEmail"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Email Recipe"
		Me.Frame1.ResumeLayout(False)
		Me.Frame1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Public WithEvents txtSender As System.Windows.Forms.TextBox
    Public WithEvents Label1_4 As System.Windows.Forms.Label
	Friend WithEvents chkIncludeImage As CheckBox
#End Region
End Class