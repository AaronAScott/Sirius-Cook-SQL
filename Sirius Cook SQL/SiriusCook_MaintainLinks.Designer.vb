<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintainLinks
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintainLinks))
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ListBox1 = New System.Windows.Forms.ListBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(13, 23)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(81, 23)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "&Select Link:"
		'
		'ListBox1
		'
		Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Location = New System.Drawing.Point(123, 23)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(215, 186)
		Me.ListBox1.TabIndex = 1
		'
		'Label2
		'
		Me.Label2.Enabled = False
		Me.Label2.Location = New System.Drawing.Point(13, 218)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(81, 23)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Link &Text:"
		'
		'TextBox1
		'
		Me.TextBox1.Enabled = False
		Me.TextBox1.Location = New System.Drawing.Point(123, 215)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(215, 20)
		Me.TextBox1.TabIndex = 3
		'
		'btnSave
		'
		Me.btnSave.Enabled = False
		Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
		Me.btnSave.Location = New System.Drawing.Point(354, 209)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(32, 32)
		Me.btnSave.TabIndex = 4
		Me.ToolTip1.SetToolTip(Me.btnSave, "Save Changes")
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
		Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnCancel.Enabled = False
		Me.btnCancel.Location = New System.Drawing.Point(438, 209)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(32, 32)
		Me.btnCancel.TabIndex = 6
		Me.ToolTip1.SetToolTip(Me.btnCancel, "Cancel Changes")
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnDelete
		'
		Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
		Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnDelete.Enabled = False
		Me.btnDelete.Location = New System.Drawing.Point(396, 209)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(32, 32)
		Me.btnDelete.TabIndex = 5
		Me.ToolTip1.SetToolTip(Me.btnDelete, "Delete Link")
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'btnClose
		'
		Me.btnClose.BackColor = System.Drawing.SystemColors.Control
		Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
		Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnClose.Location = New System.Drawing.Point(372, 23)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnClose.Size = New System.Drawing.Size(79, 74)
		Me.btnClose.TabIndex = 7
		Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnClose.UseVisualStyleBackColor = False
		'
		'frmMaintainLinks
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(483, 261)
		Me.ControlBox = False
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.btnDelete)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnSave)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.ListBox1)
		Me.Controls.Add(Me.Label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmMaintainLinks"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Maintain Recipe Links"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Public WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
