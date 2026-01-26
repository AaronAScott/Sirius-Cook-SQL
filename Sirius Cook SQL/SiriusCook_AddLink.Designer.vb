<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddLink
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddLink))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLinkText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOkay = New System.Windows.Forms.Button()
        Me.txtLinkRecipeName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Link Text:"
        '
        'txtLinkText
        '
        Me.txtLinkText.Location = New System.Drawing.Point(106, 10)
        Me.txtLinkText.Name = "txtLinkText"
        Me.txtLinkText.Size = New System.Drawing.Size(181, 20)
        Me.txtLinkText.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Link to Recipe:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(298, 53)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 4
        Me.btnBrowse.Text = "&Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(222, 101)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(63, 63)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOkay
        '
        Me.btnOkay.BackColor = System.Drawing.SystemColors.Control
        Me.btnOkay.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOkay.Enabled = False
        Me.btnOkay.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOkay.Image = CType(resources.GetObject("btnOkay.Image"), System.Drawing.Image)
        Me.btnOkay.Location = New System.Drawing.Point(109, 101)
        Me.btnOkay.Name = "btnOkay"
        Me.btnOkay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOkay.Size = New System.Drawing.Size(63, 63)
        Me.btnOkay.TabIndex = 5
        Me.btnOkay.Text = "&Okay"
        Me.btnOkay.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOkay.UseVisualStyleBackColor = False
        '
        'txtLinkRecipeName
        '
        Me.txtLinkRecipeName.Location = New System.Drawing.Point(106, 55)
        Me.txtLinkRecipeName.Name = "txtLinkRecipeName"
        Me.txtLinkRecipeName.ReadOnly = True
        Me.txtLinkRecipeName.Size = New System.Drawing.Size(181, 20)
        Me.txtLinkRecipeName.TabIndex = 3
        '
        'frmAddLink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 176)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtLinkRecipeName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOkay)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLinkText)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddLink"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Link to Another Recipe"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLinkText As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents btnOkay As System.Windows.Forms.Button
    Friend WithEvents txtLinkRecipeName As System.Windows.Forms.TextBox
End Class
