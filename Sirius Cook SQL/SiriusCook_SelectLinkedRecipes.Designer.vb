<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectLinkedRecipes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectLinkedRecipes))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.btnPrintSelected = New System.Windows.Forms.Button()
        Me.btnDontPrint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(347, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This recipe contains one or more links to other recipes.  If you would like to al" & _
    "so print the referenced recipes, select the ones you wish to print."
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(16, 54)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(344, 154)
        Me.CheckedListBox1.TabIndex = 1
        '
        'btnPrintSelected
        '
        Me.btnPrintSelected.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrintSelected.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPrintSelected.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnPrintSelected.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintSelected.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrintSelected.Image = CType(resources.GetObject("btnPrintSelected.Image"), System.Drawing.Image)
        Me.btnPrintSelected.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrintSelected.Location = New System.Drawing.Point(381, 54)
        Me.btnPrintSelected.Name = "btnPrintSelected"
        Me.btnPrintSelected.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrintSelected.Size = New System.Drawing.Size(106, 72)
        Me.btnPrintSelected.TabIndex = 2
        Me.btnPrintSelected.Text = "&Print Selected Recipes"
        Me.btnPrintSelected.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrintSelected.UseVisualStyleBackColor = False
        '
        'btnDontPrint
        '
        Me.btnDontPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnDontPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnDontPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDontPrint.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDontPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDontPrint.Image = CType(resources.GetObject("btnDontPrint.Image"), System.Drawing.Image)
        Me.btnDontPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDontPrint.Location = New System.Drawing.Point(381, 136)
        Me.btnDontPrint.Name = "btnDontPrint"
        Me.btnDontPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDontPrint.Size = New System.Drawing.Size(106, 72)
        Me.btnDontPrint.TabIndex = 3
        Me.btnDontPrint.Text = "&Don't Print Selected Recipes"
        Me.btnDontPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDontPrint.UseVisualStyleBackColor = False
        '
        'frmSelectLinkedRecipes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 221)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnDontPrint)
        Me.Controls.Add(Me.btnPrintSelected)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectLinkedRecipes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Linked Recipes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Public WithEvents btnPrintSelected As System.Windows.Forms.Button
    Public WithEvents btnDontPrint As System.Windows.Forms.Button
End Class
