<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmProperties
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
    Public WithEvents cmdApply As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOkay As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProperties))
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.cmdApply = New System.Windows.Forms.Button()
		Me.cmdCancel = New System.Windows.Forms.Button()
		Me.cmdOkay = New System.Windows.Forms.Button()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.Text1 = New System.Windows.Forms.TextBox()
		Me.Text2 = New System.Windows.Forms.TextBox()
		Me.Text3 = New System.Windows.Forms.TextBox()
		Me.Text4 = New System.Windows.Forms.TextBox()
		Me.Label1_1 = New System.Windows.Forms.Label()
		Me.Label1_2 = New System.Windows.Forms.Label()
		Me.Label1_3 = New System.Windows.Forms.Label()
		Me.Label1_4 = New System.Windows.Forms.Label()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.chkQuietBackup = New System.Windows.Forms.CheckBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Frame1 = New System.Windows.Forms.GroupBox()
		Me.txtPort = New System.Windows.Forms.TextBox()
		Me.lblPort = New System.Windows.Forms.Label()
		Me.txtPassword = New System.Windows.Forms.TextBox()
		Me.lblPassword = New System.Windows.Forms.Label()
		Me.txtLogin = New System.Windows.Forms.TextBox()
		Me.lblLogin = New System.Windows.Forms.Label()
		Me.txtEmail = New System.Windows.Forms.TextBox()
		Me.optTransport_1 = New System.Windows.Forms.RadioButton()
		Me.optTransport_0 = New System.Windows.Forms.RadioButton()
		Me.lblEmail = New System.Windows.Forms.Label()
		Me.Check1_1 = New System.Windows.Forms.CheckBox()
		Me.cmdBrowseDir = New System.Windows.Forms.Button()
		Me.Text6 = New System.Windows.Forms.TextBox()
		Me.Text5 = New System.Windows.Forms.TextBox()
		Me.cmdBrowseDB = New System.Windows.Forms.Button()
		Me.Label2_3 = New System.Windows.Forms.Label()
		Me.Label2_0 = New System.Windows.Forms.Label()
		Me.Label2_1 = New System.Windows.Forms.Label()
		Me.Label2_2 = New System.Windows.Forms.Label()
		Me.lblUseSSL = New System.Windows.Forms.Label()
		Me.chkUseSSL = New System.Windows.Forms.CheckBox()
		Me.TabPage1.SuspendLayout()
		Me.TabControl1.SuspendLayout()
		Me.TabPage2.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		'
		'cmdApply
		'
		Me.cmdApply.BackColor = System.Drawing.SystemColors.Control
		Me.cmdApply.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdApply.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdApply.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdApply.Location = New System.Drawing.Point(408, 369)
		Me.cmdApply.Name = "cmdApply"
		Me.cmdApply.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdApply.Size = New System.Drawing.Size(73, 25)
		Me.cmdApply.TabIndex = 13
		Me.cmdApply.Text = "&Apply"
		Me.cmdApply.UseVisualStyleBackColor = False
		'
		'cmdCancel
		'
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Location = New System.Drawing.Point(325, 369)
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
		Me.cmdCancel.TabIndex = 11
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.UseVisualStyleBackColor = False
		'
		'cmdOkay
		'
		Me.cmdOkay.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOkay.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOkay.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOkay.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOkay.Location = New System.Drawing.Point(242, 369)
		Me.cmdOkay.Name = "cmdOkay"
		Me.cmdOkay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOkay.Size = New System.Drawing.Size(73, 25)
		Me.cmdOkay.TabIndex = 10
		Me.cmdOkay.Text = "&Okay"
		Me.cmdOkay.UseVisualStyleBackColor = False
		'
		'TabPage1
		'
		Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
		Me.TabPage1.Controls.Add(Me.Text1)
		Me.TabPage1.Controls.Add(Me.Text2)
		Me.TabPage1.Controls.Add(Me.Text3)
		Me.TabPage1.Controls.Add(Me.Text4)
		Me.TabPage1.Controls.Add(Me.Label1_1)
		Me.TabPage1.Controls.Add(Me.Label1_2)
		Me.TabPage1.Controls.Add(Me.Label1_3)
		Me.TabPage1.Controls.Add(Me.Label1_4)
		Me.TabPage1.Location = New System.Drawing.Point(4, 23)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Size = New System.Drawing.Size(453, 285)
		Me.TabPage1.TabIndex = 2
		Me.TabPage1.Text = "Personalization"
		'
		'Text1
		'
		Me.Text1.AcceptsReturn = True
		Me.Text1.BackColor = System.Drawing.SystemColors.Window
		Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text1.ForeColor = System.Drawing.Color.Black
		Me.Text1.Location = New System.Drawing.Point(158, 13)
		Me.Text1.MaxLength = 0
		Me.Text1.Name = "Text1"
		Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text1.Size = New System.Drawing.Size(281, 20)
		Me.Text1.TabIndex = 9
		'
		'Text2
		'
		Me.Text2.AcceptsReturn = True
		Me.Text2.BackColor = System.Drawing.SystemColors.Window
		Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text2.ForeColor = System.Drawing.Color.Black
		Me.Text2.Location = New System.Drawing.Point(158, 41)
		Me.Text2.MaxLength = 0
		Me.Text2.Name = "Text2"
		Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text2.Size = New System.Drawing.Size(281, 20)
		Me.Text2.TabIndex = 11
		'
		'Text3
		'
		Me.Text3.AcceptsReturn = True
		Me.Text3.BackColor = System.Drawing.SystemColors.Window
		Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text3.ForeColor = System.Drawing.Color.Black
		Me.Text3.Location = New System.Drawing.Point(158, 69)
		Me.Text3.MaxLength = 0
		Me.Text3.Name = "Text3"
		Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text3.Size = New System.Drawing.Size(281, 20)
		Me.Text3.TabIndex = 13
		'
		'Text4
		'
		Me.Text4.AcceptsReturn = True
		Me.Text4.BackColor = System.Drawing.Color.White
		Me.Text4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text4.ForeColor = System.Drawing.Color.Black
		Me.Text4.Location = New System.Drawing.Point(158, 97)
		Me.Text4.MaxLength = 0
		Me.Text4.Name = "Text4"
		Me.Text4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text4.Size = New System.Drawing.Size(281, 20)
		Me.Text4.TabIndex = 15
		'
		'Label1_1
		'
		Me.Label1_1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_1.ForeColor = System.Drawing.Color.Black
		Me.Label1_1.Location = New System.Drawing.Point(14, 13)
		Me.Label1_1.Name = "Label1_1"
		Me.Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_1.Size = New System.Drawing.Size(137, 17)
		Me.Label1_1.TabIndex = 8
		Me.Label1_1.Text = "&Cook's Name:"
		'
		'Label1_2
		'
		Me.Label1_2.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_2.ForeColor = System.Drawing.Color.Black
		Me.Label1_2.Location = New System.Drawing.Point(14, 41)
		Me.Label1_2.Name = "Label1_2"
		Me.Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_2.Size = New System.Drawing.Size(137, 17)
		Me.Label1_2.TabIndex = 10
		Me.Label1_2.Text = "&Street Address:"
		'
		'Label1_3
		'
		Me.Label1_3.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_3.ForeColor = System.Drawing.Color.Black
		Me.Label1_3.Location = New System.Drawing.Point(14, 69)
		Me.Label1_3.Name = "Label1_3"
		Me.Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_3.Size = New System.Drawing.Size(137, 17)
		Me.Label1_3.TabIndex = 12
		Me.Label1_3.Text = "&Mailing Address:"
		'
		'Label1_4
		'
		Me.Label1_4.BackColor = System.Drawing.SystemColors.Control
		Me.Label1_4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1_4.ForeColor = System.Drawing.Color.Black
		Me.Label1_4.Location = New System.Drawing.Point(14, 97)
		Me.Label1_4.Name = "Label1_4"
		Me.Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1_4.Size = New System.Drawing.Size(137, 17)
		Me.Label1_4.TabIndex = 14
		Me.Label1_4.Text = "City, State, &Zip Code:"
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Location = New System.Drawing.Point(20, 22)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(461, 341)
		Me.TabControl1.TabIndex = 16
		'
		'TabPage2
		'
		Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
		Me.TabPage2.Controls.Add(Me.chkQuietBackup)
		Me.TabPage2.Controls.Add(Me.Label1)
		Me.TabPage2.Controls.Add(Me.Frame1)
		Me.TabPage2.Controls.Add(Me.Check1_1)
		Me.TabPage2.Controls.Add(Me.cmdBrowseDir)
		Me.TabPage2.Controls.Add(Me.Text6)
		Me.TabPage2.Controls.Add(Me.Text5)
		Me.TabPage2.Controls.Add(Me.cmdBrowseDB)
		Me.TabPage2.Controls.Add(Me.Label2_3)
		Me.TabPage2.Controls.Add(Me.Label2_0)
		Me.TabPage2.Controls.Add(Me.Label2_1)
		Me.TabPage2.Controls.Add(Me.Label2_2)
		Me.TabPage2.Location = New System.Drawing.Point(4, 23)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(453, 314)
		Me.TabPage2.TabIndex = 0
		Me.TabPage2.Text = "Global"
		'
		'chkQuietBackup
		'
		Me.chkQuietBackup.BackColor = System.Drawing.SystemColors.Control
		Me.chkQuietBackup.Location = New System.Drawing.Point(155, 88)
		Me.chkQuietBackup.Name = "chkQuietBackup"
		Me.chkQuietBackup.Size = New System.Drawing.Size(19, 24)
		Me.chkQuietBackup.TabIndex = 0
		Me.chkQuietBackup.UseVisualStyleBackColor = False
		'
		'Label1
		'
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Location = New System.Drawing.Point(13, 80)
		Me.Label1.Name = "Label1"
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.Size = New System.Drawing.Size(138, 36)
		Me.Label1.TabIndex = 8
		Me.Label1.Text = "&Quiet  Backup (No Overwrite Prompts)"
		'
		'Frame1
		'
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Controls.Add(Me.chkUseSSL)
		Me.Frame1.Controls.Add(Me.lblUseSSL)
		Me.Frame1.Controls.Add(Me.txtPort)
		Me.Frame1.Controls.Add(Me.lblPort)
		Me.Frame1.Controls.Add(Me.txtPassword)
		Me.Frame1.Controls.Add(Me.lblPassword)
		Me.Frame1.Controls.Add(Me.txtLogin)
		Me.Frame1.Controls.Add(Me.lblLogin)
		Me.Frame1.Controls.Add(Me.txtEmail)
		Me.Frame1.Controls.Add(Me.optTransport_1)
		Me.Frame1.Controls.Add(Me.optTransport_0)
		Me.Frame1.Controls.Add(Me.lblEmail)
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.Location = New System.Drawing.Point(155, 127)
		Me.Frame1.Name = "Frame1"
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Size = New System.Drawing.Size(289, 181)
		Me.Frame1.TabIndex = 9
		Me.Frame1.TabStop = False
		'
		'txtPort
		'
		Me.txtPort.AcceptsReturn = True
		Me.txtPort.BackColor = System.Drawing.SystemColors.Window
		Me.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPort.Enabled = False
		Me.txtPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPort.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPort.Location = New System.Drawing.Point(112, 122)
		Me.txtPort.MaxLength = 0
		Me.txtPort.Name = "txtPort"
		Me.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPort.Size = New System.Drawing.Size(54, 20)
		Me.txtPort.TabIndex = 20
		'
		'lblPort
		'
		Me.lblPort.BackColor = System.Drawing.SystemColors.Control
		Me.lblPort.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPort.Enabled = False
		Me.lblPort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPort.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPort.Location = New System.Drawing.Point(6, 122)
		Me.lblPort.Name = "lblPort"
		Me.lblPort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPort.Size = New System.Drawing.Size(103, 21)
		Me.lblPort.TabIndex = 19
		Me.lblPort.Text = "P&ort:"
		'
		'txtPassword
		'
		Me.txtPassword.AcceptsReturn = True
		Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
		Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPassword.Enabled = False
		Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPassword.Location = New System.Drawing.Point(112, 96)
		Me.txtPassword.MaxLength = 0
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPassword.Size = New System.Drawing.Size(171, 20)
		Me.txtPassword.TabIndex = 18
		'
		'lblPassword
		'
		Me.lblPassword.BackColor = System.Drawing.SystemColors.Control
		Me.lblPassword.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPassword.Enabled = False
		Me.lblPassword.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPassword.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPassword.Location = New System.Drawing.Point(6, 96)
		Me.lblPassword.Name = "lblPassword"
		Me.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPassword.Size = New System.Drawing.Size(103, 21)
		Me.lblPassword.TabIndex = 17
		Me.lblPassword.Text = "&Password:"
		'
		'txtLogin
		'
		Me.txtLogin.AcceptsReturn = True
		Me.txtLogin.BackColor = System.Drawing.SystemColors.Window
		Me.txtLogin.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLogin.Enabled = False
		Me.txtLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtLogin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLogin.Location = New System.Drawing.Point(112, 70)
		Me.txtLogin.MaxLength = 0
		Me.txtLogin.Name = "txtLogin"
		Me.txtLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLogin.Size = New System.Drawing.Size(171, 20)
		Me.txtLogin.TabIndex = 16
		'
		'lblLogin
		'
		Me.lblLogin.BackColor = System.Drawing.SystemColors.Control
		Me.lblLogin.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLogin.Enabled = False
		Me.lblLogin.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLogin.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLogin.Location = New System.Drawing.Point(6, 70)
		Me.lblLogin.Name = "lblLogin"
		Me.lblLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLogin.Size = New System.Drawing.Size(103, 21)
		Me.lblLogin.TabIndex = 15
		Me.lblLogin.Text = "Login Name:"
		'
		'txtEmail
		'
		Me.txtEmail.AcceptsReturn = True
		Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
		Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEmail.Enabled = False
		Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEmail.Location = New System.Drawing.Point(112, 46)
		Me.txtEmail.MaxLength = 0
		Me.txtEmail.Name = "txtEmail"
		Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEmail.Size = New System.Drawing.Size(171, 20)
		Me.txtEmail.TabIndex = 14
		'
		'optTransport_1
		'
		Me.optTransport_1.BackColor = System.Drawing.SystemColors.Control
		Me.optTransport_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.optTransport_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optTransport_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optTransport_1.Location = New System.Drawing.Point(112, 10)
		Me.optTransport_1.Name = "optTransport_1"
		Me.optTransport_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optTransport_1.Size = New System.Drawing.Size(101, 19)
		Me.optTransport_1.TabIndex = 12
		Me.optTransport_1.TabStop = True
		Me.optTransport_1.Text = "&Local"
		Me.optTransport_1.UseVisualStyleBackColor = False
		'
		'optTransport_0
		'
		Me.optTransport_0.BackColor = System.Drawing.SystemColors.Control
		Me.optTransport_0.Checked = True
		Me.optTransport_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.optTransport_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optTransport_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optTransport_0.Location = New System.Drawing.Point(8, 10)
		Me.optTransport_0.Name = "optTransport_0"
		Me.optTransport_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optTransport_0.Size = New System.Drawing.Size(101, 19)
		Me.optTransport_0.TabIndex = 11
		Me.optTransport_0.TabStop = True
		Me.optTransport_0.Text = "&Sirius Email"
		Me.optTransport_0.UseVisualStyleBackColor = False
		'
		'lblEmail
		'
		Me.lblEmail.BackColor = System.Drawing.SystemColors.Control
		Me.lblEmail.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEmail.Enabled = False
		Me.lblEmail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEmail.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEmail.Location = New System.Drawing.Point(6, 46)
		Me.lblEmail.Name = "lblEmail"
		Me.lblEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEmail.Size = New System.Drawing.Size(103, 21)
		Me.lblEmail.TabIndex = 13
		Me.lblEmail.Text = "Mail Server Name:"
		'
		'Check1_1
		'
		Me.Check1_1.BackColor = System.Drawing.SystemColors.Control
		Me.Check1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Check1_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Check1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Check1_1.Location = New System.Drawing.Point(155, 63)
		Me.Check1_1.Name = "Check1_1"
		Me.Check1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Check1_1.Size = New System.Drawing.Size(17, 21)
		Me.Check1_1.TabIndex = 7
		Me.Check1_1.UseVisualStyleBackColor = False
		'
		'cmdBrowseDir
		'
		Me.cmdBrowseDir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBrowseDir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBrowseDir.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdBrowseDir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBrowseDir.Location = New System.Drawing.Point(377, 36)
		Me.cmdBrowseDir.Name = "cmdBrowseDir"
		Me.cmdBrowseDir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBrowseDir.Size = New System.Drawing.Size(69, 20)
		Me.cmdBrowseDir.TabIndex = 5
		Me.cmdBrowseDir.Text = "&Browse..."
		Me.cmdBrowseDir.UseVisualStyleBackColor = False
		'
		'Text6
		'
		Me.Text6.AcceptsReturn = True
		Me.Text6.BackColor = System.Drawing.SystemColors.Window
		Me.Text6.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text6.ForeColor = System.Drawing.Color.Black
		Me.Text6.Location = New System.Drawing.Point(155, 36)
		Me.Text6.MaxLength = 0
		Me.Text6.Name = "Text6"
		Me.Text6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text6.Size = New System.Drawing.Size(213, 20)
		Me.Text6.TabIndex = 4
		'
		'Text5
		'
		Me.Text5.AcceptsReturn = True
		Me.Text5.BackColor = System.Drawing.SystemColors.Window
		Me.Text5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text5.ForeColor = System.Drawing.Color.Black
		Me.Text5.Location = New System.Drawing.Point(155, 14)
		Me.Text5.MaxLength = 0
		Me.Text5.Name = "Text5"
		Me.Text5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text5.Size = New System.Drawing.Size(213, 20)
		Me.Text5.TabIndex = 1
		'
		'cmdBrowseDB
		'
		Me.cmdBrowseDB.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBrowseDB.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBrowseDB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdBrowseDB.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBrowseDB.Location = New System.Drawing.Point(376, 12)
		Me.cmdBrowseDB.Name = "cmdBrowseDB"
		Me.cmdBrowseDB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBrowseDB.Size = New System.Drawing.Size(69, 20)
		Me.cmdBrowseDB.TabIndex = 2
		Me.cmdBrowseDB.Text = "&Browse..."
		Me.cmdBrowseDB.UseVisualStyleBackColor = False
		'
		'Label2_3
		'
		Me.Label2_3.BackColor = System.Drawing.SystemColors.Control
		Me.Label2_3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2_3.ForeColor = System.Drawing.Color.Black
		Me.Label2_3.Location = New System.Drawing.Point(13, 127)
		Me.Label2_3.Name = "Label2_3"
		Me.Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2_3.Size = New System.Drawing.Size(138, 17)
		Me.Label2_3.TabIndex = 10
		Me.Label2_3.Text = "&Email Transport"
		'
		'Label2_0
		'
		Me.Label2_0.BackColor = System.Drawing.SystemColors.Control
		Me.Label2_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2_0.ForeColor = System.Drawing.Color.Black
		Me.Label2_0.Location = New System.Drawing.Point(13, 15)
		Me.Label2_0.Name = "Label2_0"
		Me.Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2_0.Size = New System.Drawing.Size(138, 17)
		Me.Label2_0.TabIndex = 0
		Me.Label2_0.Text = "&Auto-Open Database:"
		'
		'Label2_1
		'
		Me.Label2_1.BackColor = System.Drawing.SystemColors.Control
		Me.Label2_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2_1.ForeColor = System.Drawing.Color.Black
		Me.Label2_1.Location = New System.Drawing.Point(13, 39)
		Me.Label2_1.Name = "Label2_1"
		Me.Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2_1.Size = New System.Drawing.Size(138, 17)
		Me.Label2_1.TabIndex = 3
		Me.Label2_1.Text = "&Backup Path:"
		'
		'Label2_2
		'
		Me.Label2_2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2_2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2_2.ForeColor = System.Drawing.Color.Black
		Me.Label2_2.Location = New System.Drawing.Point(13, 63)
		Me.Label2_2.Name = "Label2_2"
		Me.Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2_2.Size = New System.Drawing.Size(138, 17)
		Me.Label2_2.TabIndex = 6
		Me.Label2_2.Text = "&Auto-Open &Last Database Used:"
		'
		'lblUseSSL
		'
		Me.lblUseSSL.BackColor = System.Drawing.SystemColors.Control
		Me.lblUseSSL.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblUseSSL.Enabled = False
		Me.lblUseSSL.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblUseSSL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblUseSSL.Location = New System.Drawing.Point(6, 148)
		Me.lblUseSSL.Name = "lblUseSSL"
		Me.lblUseSSL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblUseSSL.Size = New System.Drawing.Size(103, 21)
		Me.lblUseSSL.TabIndex = 21
		Me.lblUseSSL.Text = "&Use SSL:"
		'
		'chkUseSSL
		'
		Me.chkUseSSL.AutoSize = True
		Me.chkUseSSL.Location = New System.Drawing.Point(112, 148)
		Me.chkUseSSL.Name = "chkUseSSL"
		Me.chkUseSSL.Size = New System.Drawing.Size(15, 14)
		Me.chkUseSSL.TabIndex = 22
		Me.chkUseSSL.UseVisualStyleBackColor = True
		'
		'frmProperties
		'
		Me.AcceptButton = Me.cmdOkay
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton = Me.cmdCancel
		Me.ClientSize = New System.Drawing.Size(494, 406)
		Me.Controls.Add(Me.TabControl1)
		Me.Controls.Add(Me.cmdApply)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOkay)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ForeColor = System.Drawing.SystemColors.WindowText
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Location = New System.Drawing.Point(150, 167)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmProperties"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Properties"
		Me.TabPage1.ResumeLayout(False)
		Me.TabPage1.PerformLayout()
		Me.TabControl1.ResumeLayout(False)
		Me.TabPage2.ResumeLayout(False)
		Me.TabPage2.PerformLayout()
		Me.Frame1.ResumeLayout(False)
		Me.Frame1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Text2 As System.Windows.Forms.TextBox
    Public WithEvents Text3 As System.Windows.Forms.TextBox
    Public WithEvents Text4 As System.Windows.Forms.TextBox
    Public WithEvents Label1_1 As System.Windows.Forms.Label
    Public WithEvents Label1_2 As System.Windows.Forms.Label
    Public WithEvents Label1_3 As System.Windows.Forms.Label
    Public WithEvents Label1_4 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents chkQuietBackup As System.Windows.Forms.CheckBox
    Public WithEvents txtPort As System.Windows.Forms.TextBox
    Public WithEvents lblPort As System.Windows.Forms.Label
    Public WithEvents txtPassword As System.Windows.Forms.TextBox
    Public WithEvents lblPassword As System.Windows.Forms.Label
    Public WithEvents txtLogin As System.Windows.Forms.TextBox
    Public WithEvents lblLogin As System.Windows.Forms.Label
    Public WithEvents txtEmail As System.Windows.Forms.TextBox
    Public WithEvents optTransport_1 As System.Windows.Forms.RadioButton
    Public WithEvents optTransport_0 As System.Windows.Forms.RadioButton
    Public WithEvents lblEmail As System.Windows.Forms.Label
    Public WithEvents Check1_1 As System.Windows.Forms.CheckBox
    Public WithEvents cmdBrowseDir As System.Windows.Forms.Button
    Public WithEvents Text6 As System.Windows.Forms.TextBox
    Public WithEvents Text5 As System.Windows.Forms.TextBox
    Public WithEvents cmdBrowseDB As System.Windows.Forms.Button
    Public WithEvents Label2_3 As System.Windows.Forms.Label
    Public WithEvents Label2_0 As System.Windows.Forms.Label
    Public WithEvents Label2_1 As System.Windows.Forms.Label
    Public WithEvents Label2_2 As System.Windows.Forms.Label
    Public WithEvents CheckBox1 As System.Windows.Forms.CheckBox
	Friend WithEvents chkUseSSL As CheckBox
	Public WithEvents lblUseSSL As Label
#End Region
End Class