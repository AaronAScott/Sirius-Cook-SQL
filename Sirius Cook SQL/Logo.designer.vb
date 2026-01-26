<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Logo
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
    Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents lblCopyright As System.Windows.Forms.Label
    Public WithEvents lblWarning As System.Windows.Forms.Label
	Public WithEvents lblVersion As System.Windows.Forms.Label
	Public WithEvents lblPlatform As System.Windows.Forms.Label
	Public WithEvents lblProductName As System.Windows.Forms.Label
    Public WithEvents lblCompanyProduct As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.Frame1 = New System.Windows.Forms.GroupBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblCopyright = New System.Windows.Forms.Label()
		Me.lblWarning = New System.Windows.Forms.Label()
		Me.lblVersion = New System.Windows.Forms.Label()
		Me.lblPlatform = New System.Windows.Forms.Label()
		Me.lblProductName = New System.Windows.Forms.Label()
		Me.lblCompanyProduct = New System.Windows.Forms.Label()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Frame1
		'
		Me.Frame1.BackColor = System.Drawing.Color.Transparent
		Me.Frame1.Controls.Add(Me.Label2)
		Me.Frame1.Controls.Add(Me.lblCopyright)
		Me.Frame1.Controls.Add(Me.lblWarning)
		Me.Frame1.Controls.Add(Me.lblVersion)
		Me.Frame1.Controls.Add(Me.lblPlatform)
		Me.Frame1.Controls.Add(Me.lblProductName)
		Me.Frame1.Controls.Add(Me.lblCompanyProduct)
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.Location = New System.Drawing.Point(8, 4)
		Me.Frame1.Name = "Frame1"
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Size = New System.Drawing.Size(512, 270)
		Me.Frame1.TabIndex = 0
		Me.Frame1.TabStop = False
		'
		'Label2
		'
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Location = New System.Drawing.Point(335, 127)
		Me.Label2.Name = "Label2"
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.Size = New System.Drawing.Size(33, 21)
		Me.Label2.TabIndex = 9
		Me.Label2.Text = "For"
		'
		'lblCopyright
		'
		Me.lblCopyright.BackColor = System.Drawing.Color.Transparent
		Me.lblCopyright.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCopyright.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCopyright.ForeColor = System.Drawing.Color.White
		Me.lblCopyright.Location = New System.Drawing.Point(232, 212)
		Me.lblCopyright.Name = "lblCopyright"
		Me.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCopyright.Size = New System.Drawing.Size(258, 17)
		Me.lblCopyright.TabIndex = 4
		'
		'lblWarning
		'
		Me.lblWarning.BackColor = System.Drawing.Color.Transparent
		Me.lblWarning.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblWarning.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblWarning.ForeColor = System.Drawing.Color.White
		Me.lblWarning.Location = New System.Drawing.Point(14, 248)
		Me.lblWarning.Name = "lblWarning"
		Me.lblWarning.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblWarning.Size = New System.Drawing.Size(381, 13)
		Me.lblWarning.TabIndex = 2
		Me.lblWarning.Text = " Warning: This product is protected by U.S. and International Copyrights."
		'
		'lblVersion
		'
		Me.lblVersion.BackColor = System.Drawing.Color.Transparent
		Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVersion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblVersion.ForeColor = System.Drawing.Color.White
		Me.lblVersion.Location = New System.Drawing.Point(232, 175)
		Me.lblVersion.Name = "lblVersion"
		Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVersion.Size = New System.Drawing.Size(236, 19)
		Me.lblVersion.TabIndex = 5
		Me.lblVersion.Text = "Version 1.0"
		Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblPlatform
		'
		Me.lblPlatform.BackColor = System.Drawing.Color.Transparent
		Me.lblPlatform.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlatform.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlatform.ForeColor = System.Drawing.Color.White
		Me.lblPlatform.Location = New System.Drawing.Point(232, 148)
		Me.lblPlatform.Name = "lblPlatform"
		Me.lblPlatform.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlatform.Size = New System.Drawing.Size(236, 19)
		Me.lblPlatform.TabIndex = 6
		Me.lblPlatform.Text = "Windows"
		Me.lblPlatform.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblProductName
		'
		Me.lblProductName.AutoSize = True
		Me.lblProductName.BackColor = System.Drawing.Color.Transparent
		Me.lblProductName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblProductName.Font = New System.Drawing.Font("Arial", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblProductName.ForeColor = System.Drawing.Color.White
		Me.lblProductName.Location = New System.Drawing.Point(159, 76)
		Me.lblProductName.Name = "lblProductName"
		Me.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblProductName.Size = New System.Drawing.Size(349, 51)
		Me.lblProductName.TabIndex = 8
		Me.lblProductName.Text = "SiriusCook SQL"
		'
		'lblCompanyProduct
		'
		Me.lblCompanyProduct.AutoSize = True
		Me.lblCompanyProduct.BackColor = System.Drawing.Color.Transparent
		Me.lblCompanyProduct.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCompanyProduct.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCompanyProduct.ForeColor = System.Drawing.Color.White
		Me.lblCompanyProduct.Location = New System.Drawing.Point(237, 41)
		Me.lblCompanyProduct.Name = "lblCompanyProduct"
		Me.lblCompanyProduct.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCompanyProduct.Size = New System.Drawing.Size(125, 19)
		Me.lblCompanyProduct.TabIndex = 7
		Me.lblCompanyProduct.Text = "Sirius Software"
		'
		'Timer1
		'
		Me.Timer1.Enabled = True
		Me.Timer1.Interval = 3000
		'
		'Logo
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.BackgroundImage = Global.Sirius_Cook_SQL.My.Resources.Resources.LogoBackground
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
		Me.ClientSize = New System.Drawing.Size(528, 287)
		Me.ControlBox = False
		Me.Controls.Add(Me.Frame1)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.KeyPreview = True
		Me.Location = New System.Drawing.Point(118, 139)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Logo"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Frame1.ResumeLayout(False)
		Me.Frame1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
#End Region
End Class