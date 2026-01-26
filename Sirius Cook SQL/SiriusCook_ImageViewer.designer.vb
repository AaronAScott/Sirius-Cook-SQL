<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageViewer
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageViewer))
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
		Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
		Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuUndo = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuFlipV = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuFlipH = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuRotateLeft = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuRotateRight = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuDeskew = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.lblSkewAngle = New System.Windows.Forms.Label()
		Me.TrackBar1 = New System.Windows.Forms.TrackBar()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.hsbZoom = New System.Windows.Forms.HScrollBar()
		Me.lblZoomPercent = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
		Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
		Me.Panel2 = New System.Windows.Forms.Panel()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MenuStrip1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.SuspendLayout()
		'
		'PictureBox1
		'
		Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(544, 460)
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		'
		'PrintPreviewDialog1
		'
		Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
		Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
		Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
		Me.PrintPreviewDialog1.Enabled = True
		Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
		Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
		Me.PrintPreviewDialog1.Visible = False
		'
		'PrintDialog1
		'
		Me.PrintDialog1.UseEXDialog = True
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(765, 24)
		Me.MenuStrip1.TabIndex = 16
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'ToolStripMenuItem4
		'
		Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUndo, Me.mnuFlipV, Me.mnuFlipH, Me.mnuRotateLeft, Me.mnuRotateRight, Me.mnuDeskew})
		Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
		Me.ToolStripMenuItem4.Size = New System.Drawing.Size(39, 20)
		Me.ToolStripMenuItem4.Text = "&Edit"
		'
		'mnuUndo
		'
		Me.mnuUndo.Enabled = False
		Me.mnuUndo.Name = "mnuUndo"
		Me.mnuUndo.Size = New System.Drawing.Size(164, 22)
		Me.mnuUndo.Text = "&Undo Flip/Rotate"
		'
		'mnuFlipV
		'
		Me.mnuFlipV.Name = "mnuFlipV"
		Me.mnuFlipV.Size = New System.Drawing.Size(164, 22)
		Me.mnuFlipV.Text = "Flip &Vertical"
		'
		'mnuFlipH
		'
		Me.mnuFlipH.Name = "mnuFlipH"
		Me.mnuFlipH.Size = New System.Drawing.Size(164, 22)
		Me.mnuFlipH.Text = "Flip &Horizontal"
		'
		'mnuRotateLeft
		'
		Me.mnuRotateLeft.Name = "mnuRotateLeft"
		Me.mnuRotateLeft.Size = New System.Drawing.Size(164, 22)
		Me.mnuRotateLeft.Text = "Rotate 90° &Left"
		'
		'mnuRotateRight
		'
		Me.mnuRotateRight.Name = "mnuRotateRight"
		Me.mnuRotateRight.Size = New System.Drawing.Size(164, 22)
		Me.mnuRotateRight.Text = "Rotate 90° &Right"
		'
		'mnuDeskew
		'
		Me.mnuDeskew.Name = "mnuDeskew"
		Me.mnuDeskew.Size = New System.Drawing.Size(164, 22)
		Me.mnuDeskew.Text = "&Skew Correction"
		'
		'ToolTip1
		'
		Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.ToolTip1.ToolTipTitle = "View Document Full Size"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.lblSkewAngle)
		Me.GroupBox1.Controls.Add(Me.TrackBar1)
		Me.GroupBox1.Enabled = False
		Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.GroupBox1.Location = New System.Drawing.Point(17, 20)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(128, 100)
		Me.GroupBox1.TabIndex = 18
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Skew Adjust"
		'
		'lblSkewAngle
		'
		Me.lblSkewAngle.AutoSize = True
		Me.lblSkewAngle.Location = New System.Drawing.Point(52, 66)
		Me.lblSkewAngle.Name = "lblSkewAngle"
		Me.lblSkewAngle.Size = New System.Drawing.Size(22, 13)
		Me.lblSkewAngle.TabIndex = 10
		Me.lblSkewAngle.Text = "0.0"
		'
		'TrackBar1
		'
		Me.TrackBar1.LargeChange = 10
		Me.TrackBar1.Location = New System.Drawing.Point(6, 34)
		Me.TrackBar1.Maximum = 500
		Me.TrackBar1.Minimum = -500
		Me.TrackBar1.Name = "TrackBar1"
		Me.TrackBar1.Size = New System.Drawing.Size(116, 45)
		Me.TrackBar1.TabIndex = 9
		Me.TrackBar1.TickFrequency = 50
		'
		'btnClose
		'
		Me.btnClose.BackColor = System.Drawing.SystemColors.Control
		Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
		Me.btnClose.Location = New System.Drawing.Point(64, 279)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnClose.Size = New System.Drawing.Size(81, 61)
		Me.btnClose.TabIndex = 19
		Me.btnClose.Text = "&Close"
		Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnClose.UseVisualStyleBackColor = False
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.hsbZoom)
		Me.GroupBox2.Controls.Add(Me.lblZoomPercent)
		Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.GroupBox2.Location = New System.Drawing.Point(11, 142)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(128, 100)
		Me.GroupBox2.TabIndex = 20
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "&Zoom"
		'
		'hsbZoom
		'
		Me.hsbZoom.LargeChange = 25
		Me.hsbZoom.Location = New System.Drawing.Point(6, 34)
		Me.hsbZoom.Maximum = 200
		Me.hsbZoom.Minimum = 10
		Me.hsbZoom.Name = "hsbZoom"
		Me.hsbZoom.Size = New System.Drawing.Size(116, 17)
		Me.hsbZoom.SmallChange = 10
		Me.hsbZoom.TabIndex = 12
		Me.hsbZoom.Value = 100
		'
		'lblZoomPercent
		'
		Me.lblZoomPercent.AutoSize = True
		Me.lblZoomPercent.Location = New System.Drawing.Point(47, 71)
		Me.lblZoomPercent.Name = "lblZoomPercent"
		Me.lblZoomPercent.Size = New System.Drawing.Size(33, 13)
		Me.lblZoomPercent.TabIndex = 10
		Me.lblZoomPercent.Text = "100%"
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.PictureBox1)
		Me.Panel1.Location = New System.Drawing.Point(16, 36)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(546, 459)
		Me.Panel1.TabIndex = 21
		'
		'VScrollBar1
		'
		Me.VScrollBar1.Location = New System.Drawing.Point(563, 36)
		Me.VScrollBar1.Name = "VScrollBar1"
		Me.VScrollBar1.Size = New System.Drawing.Size(17, 480)
		Me.VScrollBar1.TabIndex = 2
		Me.VScrollBar1.Visible = False
		'
		'HScrollBar1
		'
		Me.HScrollBar1.Location = New System.Drawing.Point(16, 499)
		Me.HScrollBar1.Name = "HScrollBar1"
		Me.HScrollBar1.Size = New System.Drawing.Size(544, 17)
		Me.HScrollBar1.TabIndex = 1
		Me.HScrollBar1.Visible = False
		'
		'Panel2
		'
		Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
		Me.Panel2.Controls.Add(Me.btnClose)
		Me.Panel2.Controls.Add(Me.GroupBox2)
		Me.Panel2.Controls.Add(Me.GroupBox1)
		Me.Panel2.Location = New System.Drawing.Point(587, 36)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(162, 480)
		Me.Panel2.TabIndex = 22
		'
		'frmImageViewer
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(765, 532)
		Me.Controls.Add(Me.HScrollBar1)
		Me.Controls.Add(Me.VScrollBar1)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MainMenuStrip = Me.MenuStrip1
		Me.MinimumSize = New System.Drawing.Size(425, 425)
		Me.Name = "frmImageViewer"
		Me.Text = "View Recipe Image"
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
	Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
	Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
	Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
	Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
	Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
	Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
	Friend WithEvents mnuUndo As ToolStripMenuItem
	Friend WithEvents mnuFlipV As ToolStripMenuItem
	Friend WithEvents mnuFlipH As ToolStripMenuItem
	Friend WithEvents mnuRotateLeft As ToolStripMenuItem
	Friend WithEvents mnuRotateRight As ToolStripMenuItem
	Friend WithEvents mnuDeskew As ToolStripMenuItem
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents lblSkewAngle As Label
	Friend WithEvents TrackBar1 As TrackBar
	Public WithEvents btnClose As Button
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents lblZoomPercent As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents VScrollBar1 As VScrollBar
	Friend WithEvents HScrollBar1 As HScrollBar
	Friend WithEvents Panel2 As Panel
	Friend WithEvents hsbZoom As HScrollBar
End Class
