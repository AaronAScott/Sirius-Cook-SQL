<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewRecipe
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewRecipe))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.picNext = New System.Windows.Forms.PictureBox()
		Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuMinimize = New System.Windows.Forms.ToolStripMenuItem()
		Me.ZoomFactorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnu80 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnu90 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnu100 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnu125 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnu150 = New System.Windows.Forms.ToolStripMenuItem()
		Me.picPrevious = New System.Windows.Forms.PictureBox()
		Me.picAddRecipe = New System.Windows.Forms.PictureBox()
		Me.lblRecipeName = New System.Windows.Forms.Label()
		Me.PictureBox2 = New System.Windows.Forms.PictureBox()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.Panel1.SuspendLayout()
		CType(Me.picNext, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ContextMenuStrip1.SuspendLayout()
		CType(Me.picPrevious, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picAddRecipe, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.picNext)
		Me.Panel1.Controls.Add(Me.picPrevious)
		Me.Panel1.Controls.Add(Me.picAddRecipe)
		Me.Panel1.Controls.Add(Me.lblRecipeName)
		Me.Panel1.Controls.Add(Me.PictureBox2)
		Me.Panel1.Controls.Add(Me.PictureBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(800, 36)
		Me.Panel1.TabIndex = 2
		'
		'picNext
		'
		Me.picNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.picNext.ContextMenuStrip = Me.ContextMenuStrip1
		Me.picNext.Enabled = False
		Me.picNext.Location = New System.Drawing.Point(697, 3)
		Me.picNext.Name = "picNext"
		Me.picNext.Size = New System.Drawing.Size(32, 32)
		Me.picNext.TabIndex = 5
		Me.picNext.TabStop = False
		Me.ToolTip1.SetToolTip(Me.picNext, "View Next Recipe")
		'
		'ContextMenuStrip1
		'
		Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuClose, Me.mnuMinimize, Me.ZoomFactorToolStripMenuItem})
		Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
		Me.ContextMenuStrip1.Size = New System.Drawing.Size(143, 70)
		'
		'mnuClose
		'
		Me.mnuClose.Name = "mnuClose"
		Me.mnuClose.Size = New System.Drawing.Size(142, 22)
		Me.mnuClose.Text = "&Close"
		'
		'mnuMinimize
		'
		Me.mnuMinimize.Name = "mnuMinimize"
		Me.mnuMinimize.Size = New System.Drawing.Size(142, 22)
		Me.mnuMinimize.Text = "&Minimize"
		'
		'ZoomFactorToolStripMenuItem
		'
		Me.ZoomFactorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu80, Me.mnu90, Me.mnu100, Me.mnu125, Me.mnu150})
		Me.ZoomFactorToolStripMenuItem.Name = "ZoomFactorToolStripMenuItem"
		Me.ZoomFactorToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
		Me.ZoomFactorToolStripMenuItem.Text = "&Zoom Factor"
		'
		'mnu80
		'
		Me.mnu80.Name = "mnu80"
		Me.mnu80.Size = New System.Drawing.Size(102, 22)
		Me.mnu80.Text = "80%"
		'
		'mnu90
		'
		Me.mnu90.Name = "mnu90"
		Me.mnu90.Size = New System.Drawing.Size(102, 22)
		Me.mnu90.Text = "90%"
		'
		'mnu100
		'
		Me.mnu100.Name = "mnu100"
		Me.mnu100.Size = New System.Drawing.Size(102, 22)
		Me.mnu100.Text = "100%"
		'
		'mnu125
		'
		Me.mnu125.Name = "mnu125"
		Me.mnu125.Size = New System.Drawing.Size(102, 22)
		Me.mnu125.Text = "125%"
		'
		'mnu150
		'
		Me.mnu150.Name = "mnu150"
		Me.mnu150.Size = New System.Drawing.Size(102, 22)
		Me.mnu150.Text = "150%"
		'
		'picPrevious
		'
		Me.picPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.picPrevious.ContextMenuStrip = Me.ContextMenuStrip1
		Me.picPrevious.Enabled = False
		Me.picPrevious.Location = New System.Drawing.Point(104, 4)
		Me.picPrevious.Name = "picPrevious"
		Me.picPrevious.Size = New System.Drawing.Size(32, 32)
		Me.picPrevious.TabIndex = 4
		Me.picPrevious.TabStop = False
		Me.ToolTip1.SetToolTip(Me.picPrevious, "View Previous Recipe")
		'
		'picAddRecipe
		'
		Me.picAddRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.picAddRecipe.ContextMenuStrip = Me.ContextMenuStrip1
		Me.picAddRecipe.Location = New System.Drawing.Point(50, 4)
		Me.picAddRecipe.Name = "picAddRecipe"
		Me.picAddRecipe.Size = New System.Drawing.Size(32, 32)
		Me.picAddRecipe.TabIndex = 3
		Me.picAddRecipe.TabStop = False
		Me.ToolTip1.SetToolTip(Me.picAddRecipe, "Open Another Recipe")
		'
		'lblRecipeName
		'
		Me.lblRecipeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRecipeName.Location = New System.Drawing.Point(142, 8)
		Me.lblRecipeName.Name = "lblRecipeName"
		Me.lblRecipeName.Size = New System.Drawing.Size(549, 23)
		Me.lblRecipeName.TabIndex = 2
		Me.lblRecipeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'PictureBox2
		'
		Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
		Me.PictureBox2.Location = New System.Drawing.Point(756, 3)
		Me.PictureBox2.Name = "PictureBox2"
		Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
		Me.PictureBox2.TabIndex = 1
		Me.PictureBox2.TabStop = False
		'
		'PictureBox1
		'
		Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
		Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
		Me.PictureBox1.Location = New System.Drawing.Point(12, 3)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		'
		'WebView21
		'
		Me.WebView21.AllowExternalDrop = True
		Me.WebView21.CreationProperties = Nothing
		Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
		Me.WebView21.Dock = System.Windows.Forms.DockStyle.Fill
		Me.WebView21.Location = New System.Drawing.Point(0, 36)
		Me.WebView21.Name = "WebView21"
		Me.WebView21.Size = New System.Drawing.Size(800, 414)
		Me.WebView21.TabIndex = 3
		Me.WebView21.ZoomFactor = 1.0R
		'
		'frmViewRecipe
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.ControlBox = False
		Me.Controls.Add(Me.WebView21)
		Me.Controls.Add(Me.Panel1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmViewRecipe"
		Me.Panel1.ResumeLayout(False)
		CType(Me.picNext, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ContextMenuStrip1.ResumeLayout(False)
		CType(Me.picPrevious, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picAddRecipe, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Panel1 As Panel
	Friend WithEvents PictureBox2 As PictureBox
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents lblRecipeName As Label
	Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
	Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
	Friend WithEvents mnuClose As ToolStripMenuItem
	Friend WithEvents mnuMinimize As ToolStripMenuItem
	Friend WithEvents ZoomFactorToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents mnu80 As ToolStripMenuItem
	Friend WithEvents mnu90 As ToolStripMenuItem
	Friend WithEvents mnu100 As ToolStripMenuItem
	Friend WithEvents mnu125 As ToolStripMenuItem
	Friend WithEvents mnu150 As ToolStripMenuItem
	Friend WithEvents picNext As PictureBox
	Friend WithEvents picPrevious As PictureBox
	Friend WithEvents picAddRecipe As PictureBox
	Friend WithEvents ToolTip1 As ToolTip
End Class
