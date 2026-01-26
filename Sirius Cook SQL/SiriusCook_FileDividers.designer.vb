<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmFileDividers
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
    Public WithEvents txtEnteredList As System.Windows.Forms.TextBox
    Public WithEvents cmdAdd As System.Windows.Forms.Button
    Public WithEvents Option2_2 As System.Windows.Forms.RadioButton
    Public WithEvents chkColoredTabs As System.Windows.Forms.CheckBox
    Public WithEvents Option2_1 As System.Windows.Forms.RadioButton
    Public WithEvents Option2_0 As System.Windows.Forms.RadioButton
    Public WithEvents List1 As System.Windows.Forms.CheckedListBox
    Public WithEvents Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents Option1_0 As System.Windows.Forms.RadioButton
    Public WithEvents Option1_1 As System.Windows.Forms.RadioButton
    Public WithEvents Label1_0 As System.Windows.Forms.Label
    Public WithEvents Label1_1 As System.Windows.Forms.Label
    Public WithEvents Label1_2 As System.Windows.Forms.Label
    Public WithEvents Label2_0 As System.Windows.Forms.Label
    Public WithEvents Label2_1 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdPrint As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileDividers))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtEnteredList = New System.Windows.Forms.TextBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.Option2_2 = New System.Windows.Forms.RadioButton()
        Me.chkColoredTabs = New System.Windows.Forms.CheckBox()
        Me.Option2_1 = New System.Windows.Forms.RadioButton()
        Me.Option2_0 = New System.Windows.Forms.RadioButton()
        Me.List1 = New System.Windows.Forms.CheckedListBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Text1_0 = New System.Windows.Forms.TextBox()
        Me.Text1_1 = New System.Windows.Forms.TextBox()
        Me.Option1_0 = New System.Windows.Forms.RadioButton()
        Me.Option1_1 = New System.Windows.Forms.RadioButton()
        Me.Label1_0 = New System.Windows.Forms.Label()
        Me.Label1_1 = New System.Windows.Forms.Label()
        Me.Label1_2 = New System.Windows.Forms.Label()
        Me.Label2_0 = New System.Windows.Forms.Label()
        Me.Label2_1 = New System.Windows.Forms.Label()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdPreview = New System.Windows.Forms.Button()
        Me.Frame1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEnteredList
        '
        Me.txtEnteredList.AcceptsReturn = True
        Me.txtEnteredList.BackColor = System.Drawing.SystemColors.Window
        Me.txtEnteredList.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEnteredList.Enabled = False
        Me.txtEnteredList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnteredList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEnteredList.Location = New System.Drawing.Point(288, 244)
        Me.txtEnteredList.MaxLength = 0
        Me.txtEnteredList.Name = "txtEnteredList"
        Me.txtEnteredList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEnteredList.Size = New System.Drawing.Size(217, 20)
        Me.txtEnteredList.TabIndex = 20
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.Enabled = False
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(515, 243)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(57, 21)
        Me.cmdAdd.TabIndex = 21
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'Option2_2
        '
        Me.Option2_2.BackColor = System.Drawing.SystemColors.Control
        Me.Option2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2_2.Location = New System.Drawing.Point(14, 214)
        Me.Option2_2.Name = "Option2_2"
        Me.Option2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2_2.Size = New System.Drawing.Size(245, 23)
        Me.Option2_2.TabIndex = 20
        Me.Option2_2.TabStop = True
        Me.Option2_2.Text = "Print a card for an entered &list of categories"
        Me.Option2_2.UseVisualStyleBackColor = False
        '
        'chkColoredTabs
        '
        Me.chkColoredTabs.BackColor = System.Drawing.SystemColors.Control
        Me.chkColoredTabs.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkColoredTabs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColoredTabs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkColoredTabs.Location = New System.Drawing.Point(14, 244)
        Me.chkColoredTabs.Name = "chkColoredTabs"
        Me.chkColoredTabs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkColoredTabs.Size = New System.Drawing.Size(245, 23)
        Me.chkColoredTabs.TabIndex = 13
        Me.chkColoredTabs.Text = "Colored &Tabs"
        Me.chkColoredTabs.UseVisualStyleBackColor = False
        '
        'Option2_1
        '
        Me.Option2_1.BackColor = System.Drawing.SystemColors.Control
        Me.Option2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2_1.Location = New System.Drawing.Point(14, 185)
        Me.Option2_1.Name = "Option2_1"
        Me.Option2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2_1.Size = New System.Drawing.Size(245, 23)
        Me.Option2_1.TabIndex = 12
        Me.Option2_1.TabStop = True
        Me.Option2_1.Text = "Print a card for &selected categories only"
        Me.Option2_1.UseVisualStyleBackColor = False
        '
        'Option2_0
        '
        Me.Option2_0.BackColor = System.Drawing.SystemColors.Control
        Me.Option2_0.Checked = True
        Me.Option2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2_0.Location = New System.Drawing.Point(14, 156)
        Me.Option2_0.Name = "Option2_0"
        Me.Option2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2_0.Size = New System.Drawing.Size(245, 23)
        Me.Option2_0.TabIndex = 11
        Me.Option2_0.TabStop = True
        Me.Option2_0.Text = "Print a card for &each category"
        Me.Option2_0.UseVisualStyleBackColor = False
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.CheckOnClick = True
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.Enabled = False
        Me.List1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.Location = New System.Drawing.Point(288, 46)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(217, 169)
        Me.List1.Sorted = True
        Me.List1.TabIndex = 16
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.NumericUpDown2)
        Me.Frame1.Controls.Add(Me.NumericUpDown1)
        Me.Frame1.Controls.Add(Me.Text1_0)
        Me.Frame1.Controls.Add(Me.Text1_1)
        Me.Frame1.Controls.Add(Me.Option1_0)
        Me.Frame1.Controls.Add(Me.Option1_1)
        Me.Frame1.Controls.Add(Me.Label1_0)
        Me.Frame1.Controls.Add(Me.Label1_1)
        Me.Frame1.Controls.Add(Me.Label1_2)
        Me.Frame1.Controls.Add(Me.Label2_0)
        Me.Frame1.Controls.Add(Me.Label2_1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(14, 42)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(245, 108)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Card Si&ze"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(134, 48)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(14, 20)
        Me.NumericUpDown2.TabIndex = 21
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(46, 48)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(14, 20)
        Me.NumericUpDown1.TabIndex = 20
        '
        'Text1_0
        '
        Me.Text1_0.AcceptsReturn = True
        Me.Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me.Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1_0.Location = New System.Drawing.Point(12, 48)
        Me.Text1_0.MaxLength = 0
        Me.Text1_0.Name = "Text1_0"
        Me.Text1_0.ReadOnly = True
        Me.Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1_0.Size = New System.Drawing.Size(33, 20)
        Me.Text1_0.TabIndex = 3
        Me.Text1_0.Text = "3"
        '
        'Text1_1
        '
        Me.Text1_1.AcceptsReturn = True
        Me.Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1_1.Location = New System.Drawing.Point(100, 48)
        Me.Text1_1.MaxLength = 0
        Me.Text1_1.Name = "Text1_1"
        Me.Text1_1.ReadOnly = True
        Me.Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1_1.Size = New System.Drawing.Size(33, 20)
        Me.Text1_1.TabIndex = 6
        Me.Text1_1.Text = "5"
        '
        'Option1_0
        '
        Me.Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me.Option1_0.Checked = True
        Me.Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1_0.Location = New System.Drawing.Point(180, 48)
        Me.Option1_0.Name = "Option1_0"
        Me.Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1_0.Size = New System.Drawing.Size(45, 20)
        Me.Option1_0.TabIndex = 9
        Me.Option1_0.TabStop = True
        Me.Option1_0.Text = "In."
        Me.Option1_0.UseVisualStyleBackColor = False
        '
        'Option1_1
        '
        Me.Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me.Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1_1.Location = New System.Drawing.Point(180, 74)
        Me.Option1_1.Name = "Option1_1"
        Me.Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1_1.Size = New System.Drawing.Size(45, 20)
        Me.Option1_1.TabIndex = 10
        Me.Option1_1.TabStop = True
        Me.Option1_1.Text = "mm."
        Me.Option1_1.UseVisualStyleBackColor = False
        '
        'Label1_0
        '
        Me.Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1_0.Location = New System.Drawing.Point(12, 24)
        Me.Label1_0.Name = "Label1_0"
        Me.Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1_0.Size = New System.Drawing.Size(48, 17)
        Me.Label1_0.TabIndex = 2
        Me.Label1_0.Text = "&Height"
        '
        'Label1_1
        '
        Me.Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1_1.Location = New System.Drawing.Point(100, 24)
        Me.Label1_1.Name = "Label1_1"
        Me.Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1_1.Size = New System.Drawing.Size(48, 17)
        Me.Label1_1.TabIndex = 5
        Me.Label1_1.Text = "&Width"
        '
        'Label1_2
        '
        Me.Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1_2.Location = New System.Drawing.Point(180, 24)
        Me.Label1_2.Name = "Label1_2"
        Me.Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1_2.Size = New System.Drawing.Size(37, 17)
        Me.Label1_2.TabIndex = 8
        Me.Label1_2.Text = "&Units"
        '
        'Label2_0
        '
        Me.Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me.Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2_0.Location = New System.Drawing.Point(60, 52)
        Me.Label2_0.Name = "Label2_0"
        Me.Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2_0.Size = New System.Drawing.Size(26, 21)
        Me.Label2_0.TabIndex = 19
        Me.Label2_0.Text = "In."
        '
        'Label2_1
        '
        Me.Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me.Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2_1.Location = New System.Drawing.Point(148, 52)
        Me.Label2_1.Name = "Label2_1"
        Me.Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2_1.Size = New System.Drawing.Size(26, 21)
        Me.Label2_1.TabIndex = 18
        Me.Label2_1.Text = "In."
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrint.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdPrint.Location = New System.Drawing.Point(516, 46)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrint.Size = New System.Drawing.Size(57, 53)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "&Print"
        Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCancel.Location = New System.Drawing.Point(515, 162)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 53)
        Me.cmdCancel.TabIndex = 19
        Me.cmdCancel.Text = "&Close"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(290, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(215, 31)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "&Food categories for which divider cards are to be printed."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(14, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(247, 31)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "This function will create file-divider cards labeled for each food category you h" & _
    "ave created."
        '
        'cmdPreview
        '
        Me.cmdPreview.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPreview.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPreview.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPreview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPreview.Image = CType(resources.GetObject("cmdPreview.Image"), System.Drawing.Image)
        Me.cmdPreview.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdPreview.Location = New System.Drawing.Point(515, 104)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPreview.Size = New System.Drawing.Size(57, 53)
        Me.cmdPreview.TabIndex = 18
        Me.cmdPreview.Text = "&Preview"
        Me.cmdPreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPreview.UseVisualStyleBackColor = False
        '
        'frmFileDividers
        '
        Me.AcceptButton = Me.cmdAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(584, 305)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdPreview)
        Me.Controls.Add(Me.txtEnteredList)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Option2_2)
        Me.Controls.Add(Me.chkColoredTabs)
        Me.Controls.Add(Me.Option2_1)
        Me.Controls.Add(Me.Option2_0)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(147, 153)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFileDividers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Divider Print Options"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Public WithEvents cmdPreview As System.Windows.Forms.Button
#End Region
End Class