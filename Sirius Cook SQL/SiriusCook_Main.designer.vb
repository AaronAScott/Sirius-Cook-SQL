<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        IsInitializing = True
        InitializeComponent()
        IsInitializing = False
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
    Public WithEvents HScroll1 As System.Windows.Forms.HScrollBar
    Public WithEvents picBookshelf_1 As System.Windows.Forms.Panel
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents picBookshelf_0 As System.Windows.Forms.Panel
    Public SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Public CommonDialog1Color As System.Windows.Forms.ColorDialog
    Public WithEvents mnuNewFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOpenFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuCloseFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents FileMenuSep1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuProperties As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MRUSeparator As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MRU1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MRU2 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MRU3 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MRU4 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents FileMenuSep3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuNewBook As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOpenBook As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMoveRecipes As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuDeleteBook As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents CookbookMenuSep1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuCatalog As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSearchLibrary As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents CookbookMenuSep2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuCookbookProperties As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents CookbookMenu As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuBackupDatabase As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents UtilMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.HScroll1 = New System.Windows.Forms.HScrollBar()
		Me.picBookshelf_1 = New System.Windows.Forms.Panel()
		Me.picBookshelf_0 = New System.Windows.Forms.Panel()
		Me.Image1 = New System.Windows.Forms.PictureBox()
		Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.CommonDialog1Color = New System.Windows.Forms.ColorDialog()
		Me.MRU1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.MRU2 = New System.Windows.Forms.ToolStripMenuItem()
		Me.MRU3 = New System.Windows.Forms.ToolStripMenuItem()
		Me.MRU4 = New System.Windows.Forms.ToolStripMenuItem()
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
		Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuNewFile = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuOpenFile = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuCloseFile = New System.Windows.Forms.ToolStripMenuItem()
		Me.FileMenuSep1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuProperties = New System.Windows.Forms.ToolStripMenuItem()
		Me.MRUSeparator = New System.Windows.Forms.ToolStripSeparator()
		Me.FileMenuSep3 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
		Me.CookbookMenu = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuNewBook = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuOpenBook = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuMoveRecipes = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuDeleteBook = New System.Windows.Forms.ToolStripMenuItem()
		Me.CookbookMenuSep1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuCatalog = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuSearchLibrary = New System.Windows.Forms.ToolStripMenuItem()
		Me.CookbookMenuSep2 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuCookbookProperties = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuRecent = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuFavorites = New System.Windows.Forms.ToolStripMenuItem()
		Me.UtilMenu = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuBackupDatabase = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuRestoreDatabase = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuCompactDatabase = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuSetWSID = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuOrganizeDB = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuControlTableEditor = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuRegistry = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuTheme = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuMaintainLinks = New System.Windows.Forms.ToolStripMenuItem()
		Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuViewReadMe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuViewLicense = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.StatusLabel = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.UserLabel = New System.Windows.Forms.ToolStripLabel()
		Me.BackupRestoreStatus = New System.Windows.Forms.ToolStripLabel()
		Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
		Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.mnuContextMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.mnuPOPOpenBook = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuPOPRemove = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuPOPProperties = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuRestoreDefaults = New System.Windows.Forms.ToolStripMenuItem()
		Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
		Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
		Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
		Me.timBackupStatus = New System.Windows.Forms.Timer(Me.components)
		Me.picBookshelf_0.SuspendLayout()
		CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MainMenu1.SuspendLayout()
		Me.ToolStrip1.SuspendLayout()
		Me.mnuContextMenu1.SuspendLayout()
		Me.SuspendLayout()
		'
		'HScroll1
		'
		Me.HScroll1.Cursor = System.Windows.Forms.Cursors.Default
		Me.HScroll1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.HScroll1.LargeChange = 100
		Me.HScroll1.Location = New System.Drawing.Point(0, 665)
		Me.HScroll1.Maximum = 2000
		Me.HScroll1.Minimum = -2000
		Me.HScroll1.Name = "HScroll1"
		Me.HScroll1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HScroll1.Size = New System.Drawing.Size(1026, 23)
		Me.HScroll1.SmallChange = 10
		Me.HScroll1.TabIndex = 2
		Me.HScroll1.TabStop = True
		'
		'picBookshelf_1
		'
		Me.picBookshelf_1.AutoSize = True
		Me.picBookshelf_1.BackColor = System.Drawing.Color.White
		Me.picBookshelf_1.BackgroundImage = Global.Sirius_Cook_SQL.My.Resources.Resources.BookEnd
		Me.picBookshelf_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.picBookshelf_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.picBookshelf_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.picBookshelf_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picBookshelf_1.Location = New System.Drawing.Point(268, 160)
		Me.picBookshelf_1.Name = "picBookshelf_1"
		Me.picBookshelf_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picBookshelf_1.Size = New System.Drawing.Size(223, 460)
		Me.picBookshelf_1.TabIndex = 1
		Me.picBookshelf_1.TabStop = True
		'
		'picBookshelf_0
		'
		Me.picBookshelf_0.AutoSize = True
		Me.picBookshelf_0.BackColor = System.Drawing.Color.White
		Me.picBookshelf_0.BackgroundImage = Global.Sirius_Cook_SQL.My.Resources.Resources.BookEnd
		Me.picBookshelf_0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.picBookshelf_0.Controls.Add(Me.Image1)
		Me.picBookshelf_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.picBookshelf_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.picBookshelf_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picBookshelf_0.Location = New System.Drawing.Point(37, 160)
		Me.picBookshelf_0.Name = "picBookshelf_0"
		Me.picBookshelf_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picBookshelf_0.Size = New System.Drawing.Size(223, 460)
		Me.picBookshelf_0.TabIndex = 0
		Me.picBookshelf_0.TabStop = True
		'
		'Image1
		'
		Me.Image1.BackColor = System.Drawing.Color.Transparent
		Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
		Me.Image1.Location = New System.Drawing.Point(140, 0)
		Me.Image1.Name = "Image1"
		Me.Image1.Size = New System.Drawing.Size(32, 32)
		Me.Image1.TabIndex = 0
		Me.Image1.TabStop = False
		'
		'MRU1
		'
		Me.MRU1.Name = "MRU1"
		Me.MRU1.Size = New System.Drawing.Size(163, 22)
		Me.MRU1.Text = "&1"
		Me.MRU1.Visible = False
		'
		'MRU2
		'
		Me.MRU2.Name = "MRU2"
		Me.MRU2.Size = New System.Drawing.Size(163, 22)
		Me.MRU2.Text = "&2"
		Me.MRU2.Visible = False
		'
		'MRU3
		'
		Me.MRU3.Name = "MRU3"
		Me.MRU3.Size = New System.Drawing.Size(163, 22)
		Me.MRU3.Text = "&3"
		Me.MRU3.Visible = False
		'
		'MRU4
		'
		Me.MRU4.Name = "MRU4"
		Me.MRU4.Size = New System.Drawing.Size(163, 22)
		Me.MRU4.Text = "&4"
		Me.MRU4.Visible = False
		'
		'MainMenu1
		'
		Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.CookbookMenu, Me.mnuRecent, Me.mnuFavorites, Me.UtilMenu, Me.HelpMenu})
		Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
		Me.MainMenu1.Name = "MainMenu1"
		Me.MainMenu1.Size = New System.Drawing.Size(1026, 24)
		Me.MainMenu1.TabIndex = 6
		'
		'FileMenu
		'
		Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewFile, Me.mnuOpenFile, Me.mnuCloseFile, Me.FileMenuSep1, Me.mnuProperties, Me.MRUSeparator, Me.MRU1, Me.MRU2, Me.MRU3, Me.MRU4, Me.FileMenuSep3, Me.mnuExit})
		Me.FileMenu.Name = "FileMenu"
		Me.FileMenu.Size = New System.Drawing.Size(37, 20)
		Me.FileMenu.Text = "&File"
		'
		'mnuNewFile
		'
		Me.mnuNewFile.Name = "mnuNewFile"
		Me.mnuNewFile.Size = New System.Drawing.Size(163, 22)
		Me.mnuNewFile.Text = "&New Database..."
		'
		'mnuOpenFile
		'
		Me.mnuOpenFile.Name = "mnuOpenFile"
		Me.mnuOpenFile.Size = New System.Drawing.Size(163, 22)
		Me.mnuOpenFile.Text = "&Open Database..."
		'
		'mnuCloseFile
		'
		Me.mnuCloseFile.Enabled = False
		Me.mnuCloseFile.Name = "mnuCloseFile"
		Me.mnuCloseFile.Size = New System.Drawing.Size(163, 22)
		Me.mnuCloseFile.Text = "&Close Database"
		'
		'FileMenuSep1
		'
		Me.FileMenuSep1.Name = "FileMenuSep1"
		Me.FileMenuSep1.Size = New System.Drawing.Size(160, 6)
		'
		'mnuProperties
		'
		Me.mnuProperties.Name = "mnuProperties"
		Me.mnuProperties.Size = New System.Drawing.Size(163, 22)
		Me.mnuProperties.Text = "&Properties"
		'
		'MRUSeparator
		'
		Me.MRUSeparator.Name = "MRUSeparator"
		Me.MRUSeparator.Size = New System.Drawing.Size(160, 6)
		Me.MRUSeparator.Visible = False
		'
		'FileMenuSep3
		'
		Me.FileMenuSep3.Name = "FileMenuSep3"
		Me.FileMenuSep3.Size = New System.Drawing.Size(160, 6)
		'
		'mnuExit
		'
		Me.mnuExit.Name = "mnuExit"
		Me.mnuExit.Size = New System.Drawing.Size(163, 22)
		Me.mnuExit.Text = "E&xit"
		'
		'CookbookMenu
		'
		Me.CookbookMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewBook, Me.mnuOpenBook, Me.mnuMoveRecipes, Me.mnuDeleteBook, Me.CookbookMenuSep1, Me.mnuCatalog, Me.mnuSearchLibrary, Me.CookbookMenuSep2, Me.mnuCookbookProperties})
		Me.CookbookMenu.Enabled = False
		Me.CookbookMenu.Name = "CookbookMenu"
		Me.CookbookMenu.Size = New System.Drawing.Size(79, 20)
		Me.CookbookMenu.Text = "&Cookbooks"
		'
		'mnuNewBook
		'
		Me.mnuNewBook.Name = "mnuNewBook"
		Me.mnuNewBook.Size = New System.Drawing.Size(185, 22)
		Me.mnuNewBook.Text = "&New Cookbook"
		'
		'mnuOpenBook
		'
		Me.mnuOpenBook.Enabled = False
		Me.mnuOpenBook.Name = "mnuOpenBook"
		Me.mnuOpenBook.Size = New System.Drawing.Size(185, 22)
		Me.mnuOpenBook.Text = "&Open Cookbook"
		'
		'mnuMoveRecipes
		'
		Me.mnuMoveRecipes.Enabled = False
		Me.mnuMoveRecipes.Name = "mnuMoveRecipes"
		Me.mnuMoveRecipes.Size = New System.Drawing.Size(185, 22)
		Me.mnuMoveRecipes.Text = "&Move Recipes..."
		'
		'mnuDeleteBook
		'
		Me.mnuDeleteBook.Enabled = False
		Me.mnuDeleteBook.Name = "mnuDeleteBook"
		Me.mnuDeleteBook.Size = New System.Drawing.Size(185, 22)
		Me.mnuDeleteBook.Text = "&Remove from Library"
		'
		'CookbookMenuSep1
		'
		Me.CookbookMenuSep1.Name = "CookbookMenuSep1"
		Me.CookbookMenuSep1.Size = New System.Drawing.Size(182, 6)
		'
		'mnuCatalog
		'
		Me.mnuCatalog.Enabled = False
		Me.mnuCatalog.Name = "mnuCatalog"
		Me.mnuCatalog.Size = New System.Drawing.Size(185, 22)
		Me.mnuCatalog.Text = "Catalog"
		'
		'mnuSearchLibrary
		'
		Me.mnuSearchLibrary.Enabled = False
		Me.mnuSearchLibrary.Name = "mnuSearchLibrary"
		Me.mnuSearchLibrary.Size = New System.Drawing.Size(185, 22)
		Me.mnuSearchLibrary.Text = "Search Library"
		'
		'CookbookMenuSep2
		'
		Me.CookbookMenuSep2.Name = "CookbookMenuSep2"
		Me.CookbookMenuSep2.Size = New System.Drawing.Size(182, 6)
		'
		'mnuCookbookProperties
		'
		Me.mnuCookbookProperties.Enabled = False
		Me.mnuCookbookProperties.Name = "mnuCookbookProperties"
		Me.mnuCookbookProperties.Size = New System.Drawing.Size(185, 22)
		Me.mnuCookbookProperties.Text = "Cookbook Properties"
		'
		'mnuRecent
		'
		Me.mnuRecent.Enabled = False
		Me.mnuRecent.Name = "mnuRecent"
		Me.mnuRecent.Size = New System.Drawing.Size(55, 20)
		Me.mnuRecent.Text = "&Recent"
		'
		'mnuFavorites
		'
		Me.mnuFavorites.Enabled = False
		Me.mnuFavorites.Name = "mnuFavorites"
		Me.mnuFavorites.Size = New System.Drawing.Size(66, 20)
		Me.mnuFavorites.Text = "&Favorites"
		'
		'UtilMenu
		'
		Me.UtilMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBackupDatabase, Me.mnuRestoreDatabase, Me.mnuCompactDatabase, Me.ToolStripMenuItem2, Me.mnuSetWSID, Me.mnuOrganizeDB, Me.mnuControlTableEditor, Me.mnuRegistry, Me.mnuTheme, Me.mnuMaintainLinks})
		Me.UtilMenu.Name = "UtilMenu"
		Me.UtilMenu.Size = New System.Drawing.Size(58, 20)
		Me.UtilMenu.Text = "&Utilities"
		'
		'mnuBackupDatabase
		'
		Me.mnuBackupDatabase.Enabled = False
		Me.mnuBackupDatabase.Name = "mnuBackupDatabase"
		Me.mnuBackupDatabase.Size = New System.Drawing.Size(213, 22)
		Me.mnuBackupDatabase.Text = "&Backup Database"
		'
		'mnuRestoreDatabase
		'
		Me.mnuRestoreDatabase.Name = "mnuRestoreDatabase"
		Me.mnuRestoreDatabase.Size = New System.Drawing.Size(213, 22)
		Me.mnuRestoreDatabase.Text = "&Restore Database..."
		'
		'mnuCompactDatabase
		'
		Me.mnuCompactDatabase.Enabled = False
		Me.mnuCompactDatabase.Name = "mnuCompactDatabase"
		Me.mnuCompactDatabase.Size = New System.Drawing.Size(213, 22)
		Me.mnuCompactDatabase.Text = "&Compact Database"
		'
		'ToolStripMenuItem2
		'
		Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
		Me.ToolStripMenuItem2.Size = New System.Drawing.Size(210, 6)
		'
		'mnuSetWSID
		'
		Me.mnuSetWSID.Name = "mnuSetWSID"
		Me.mnuSetWSID.Size = New System.Drawing.Size(213, 22)
		Me.mnuSetWSID.Text = "Set &WSID..."
		'
		'mnuOrganizeDB
		'
		Me.mnuOrganizeDB.Name = "mnuOrganizeDB"
		Me.mnuOrganizeDB.Size = New System.Drawing.Size(213, 22)
		Me.mnuOrganizeDB.Text = "&Organize Database History"
		'
		'mnuControlTableEditor
		'
		Me.mnuControlTableEditor.Enabled = False
		Me.mnuControlTableEditor.Name = "mnuControlTableEditor"
		Me.mnuControlTableEditor.Size = New System.Drawing.Size(213, 22)
		Me.mnuControlTableEditor.Text = "Control &Table Editor"
		'
		'mnuRegistry
		'
		Me.mnuRegistry.Name = "mnuRegistry"
		Me.mnuRegistry.Size = New System.Drawing.Size(213, 22)
		Me.mnuRegistry.Text = "Registry &Settings"
		'
		'mnuTheme
		'
		Me.mnuTheme.Name = "mnuTheme"
		Me.mnuTheme.Size = New System.Drawing.Size(213, 22)
		Me.mnuTheme.Text = "Choose Color &Theme"
		'
		'mnuMaintainLinks
		'
		Me.mnuMaintainLinks.Enabled = False
		Me.mnuMaintainLinks.Name = "mnuMaintainLinks"
		Me.mnuMaintainLinks.Size = New System.Drawing.Size(213, 22)
		Me.mnuMaintainLinks.Text = "Maintain Recipe &Links"
		'
		'HelpMenu
		'
		Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbout, Me.mnuViewReadMe, Me.mnuViewLicense})
		Me.HelpMenu.Name = "HelpMenu"
		Me.HelpMenu.Size = New System.Drawing.Size(44, 20)
		Me.HelpMenu.Text = "&Help"
		'
		'mnuAbout
		'
		Me.mnuAbout.Name = "mnuAbout"
		Me.mnuAbout.Size = New System.Drawing.Size(180, 22)
		Me.mnuAbout.Text = "About SiriusCook"
		'
		'mnuViewReadMe
		'
		Me.mnuViewReadMe.Name = "mnuViewReadMe"
		Me.mnuViewReadMe.Size = New System.Drawing.Size(180, 22)
		Me.mnuViewReadMe.Text = "View &ReadMe"
		'
		'mnuViewLicense
		'
		Me.mnuViewLicense.Name = "mnuViewLicense"
		Me.mnuViewLicense.Size = New System.Drawing.Size(180, 22)
		Me.mnuViewLicense.Text = "View &License"
		'
		'ToolStrip1
		'
		Me.ToolStrip1.AutoSize = False
		Me.ToolStrip1.CanOverflow = False
		Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(64, 32)
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.ToolStripLabel1, Me.UserLabel, Me.BackupRestoreStatus})
		Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(1026, 35)
		Me.ToolStrip1.TabIndex = 7
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'StatusLabel
		'
		Me.StatusLabel.AutoSize = False
		Me.StatusLabel.BackColor = System.Drawing.SystemColors.Menu
		Me.StatusLabel.Name = "StatusLabel"
		Me.StatusLabel.Size = New System.Drawing.Size(300, 32)
		Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ToolStripLabel1
		'
		Me.ToolStripLabel1.Name = "ToolStripLabel1"
		Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 0)
		'
		'UserLabel
		'
		Me.UserLabel.AutoSize = False
		Me.UserLabel.Name = "UserLabel"
		Me.UserLabel.Size = New System.Drawing.Size(250, 32)
		Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'BackupRestoreStatus
		'
		Me.BackupRestoreStatus.AutoSize = False
		Me.BackupRestoreStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.BackupRestoreStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.BackupRestoreStatus.Name = "BackupRestoreStatus"
		Me.BackupRestoreStatus.Size = New System.Drawing.Size(300, 32)
		Me.BackupRestoreStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'ImageList2
		'
		Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
		Me.ImageList2.Images.SetKeyName(0, "Tab1.ico")
		Me.ImageList2.Images.SetKeyName(1, "Tab2.ico")
		Me.ImageList2.Images.SetKeyName(2, "Tab3.ico")
		Me.ImageList2.Images.SetKeyName(3, "Tab4.ico")
		Me.ImageList2.Images.SetKeyName(4, "Tab5.ico")
		Me.ImageList2.Images.SetKeyName(5, "Tab6.ico")
		Me.ImageList2.Images.SetKeyName(6, "Tab7.ico")
		Me.ImageList2.Images.SetKeyName(7, "Tab8.ico")
		Me.ImageList2.Images.SetKeyName(8, "Tab9.ico")
		Me.ImageList2.Images.SetKeyName(9, "Tab10.ico")
		Me.ImageList2.Images.SetKeyName(10, "Tab11.ico")
		Me.ImageList2.Images.SetKeyName(11, "Tab12.ico")
		Me.ImageList2.Images.SetKeyName(12, "Tab13.ico")
		Me.ImageList2.Images.SetKeyName(13, "Tab14.ico")
		Me.ImageList2.Images.SetKeyName(14, "Tab15.ico")
		Me.ImageList2.Images.SetKeyName(15, "Tab16.ico")
		Me.ImageList2.Images.SetKeyName(16, "Tab17.ico")
		Me.ImageList2.Images.SetKeyName(17, "Tab18.ico")
		Me.ImageList2.Images.SetKeyName(18, "Tab19.ico")
		Me.ImageList2.Images.SetKeyName(19, "Tab20.ico")
		Me.ImageList2.Images.SetKeyName(20, "Tab21.ico")
		Me.ImageList2.Images.SetKeyName(21, "Tab22.ico")
		Me.ImageList2.Images.SetKeyName(22, "tab23.ico")
		Me.ImageList2.Images.SetKeyName(23, "tab24.ico")
		Me.ImageList2.Images.SetKeyName(24, "tab25.ico")
		Me.ImageList2.Images.SetKeyName(25, "tab26.ico")
		Me.ImageList2.Images.SetKeyName(26, "tab27.ico")
		Me.ImageList2.Images.SetKeyName(27, "tab28.ico")
		Me.ImageList2.Images.SetKeyName(28, "tab29.ico")
		Me.ImageList2.Images.SetKeyName(29, "tab30.ico")
		Me.ImageList2.Images.SetKeyName(30, "tab31.ico")
		Me.ImageList2.Images.SetKeyName(31, "tab32.ico")
		Me.ImageList2.Images.SetKeyName(32, "tab33.ico")
		Me.ImageList2.Images.SetKeyName(33, "tab34.ico")
		Me.ImageList2.Images.SetKeyName(34, "tab35.ico")
		Me.ImageList2.Images.SetKeyName(35, "tab36.ico")
		Me.ImageList2.Images.SetKeyName(36, "tab37.ico")
		Me.ImageList2.Images.SetKeyName(37, "tab38.ico")
		Me.ImageList2.Images.SetKeyName(38, "tab39.ico")
		Me.ImageList2.Images.SetKeyName(39, "tab40.ico")
		Me.ImageList2.Images.SetKeyName(40, "tab41.ico")
		Me.ImageList2.Images.SetKeyName(41, "tab42.ico")
		Me.ImageList2.Images.SetKeyName(42, "tab43.ico")
		Me.ImageList2.Images.SetKeyName(43, "tab44.ico")
		'
		'ImageList3
		'
		Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
		Me.ImageList3.Images.SetKeyName(0, "CategoryLeft.ico")
		Me.ImageList3.Images.SetKeyName(1, "CategoryLeftClick.ico")
		Me.ImageList3.Images.SetKeyName(2, "CategoryRight.ico")
		Me.ImageList3.Images.SetKeyName(3, "CategoryRightClick.ico")
		Me.ImageList3.Images.SetKeyName(4, "RecipeLeft.ico")
		Me.ImageList3.Images.SetKeyName(5, "RecipeLeftClick.ico")
		Me.ImageList3.Images.SetKeyName(6, "RecipeRight.ico")
		Me.ImageList3.Images.SetKeyName(7, "RecipeRightClick.ico")
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'mnuContextMenu1
		'
		Me.mnuContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPOPOpenBook, Me.ToolStripSeparator1, Me.mnuPOPRemove, Me.ToolStripSeparator2, Me.mnuPOPProperties, Me.mnuRestoreDefaults})
		Me.mnuContextMenu1.Name = "ContextMenuStrip1"
		Me.mnuContextMenu1.Size = New System.Drawing.Size(186, 104)
		'
		'mnuPOPOpenBook
		'
		Me.mnuPOPOpenBook.Name = "mnuPOPOpenBook"
		Me.mnuPOPOpenBook.Size = New System.Drawing.Size(185, 22)
		Me.mnuPOPOpenBook.Text = "&Open Book"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(182, 6)
		'
		'mnuPOPRemove
		'
		Me.mnuPOPRemove.Name = "mnuPOPRemove"
		Me.mnuPOPRemove.Size = New System.Drawing.Size(185, 22)
		Me.mnuPOPRemove.Text = "&Remove from Library"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(182, 6)
		'
		'mnuPOPProperties
		'
		Me.mnuPOPProperties.Name = "mnuPOPProperties"
		Me.mnuPOPProperties.Size = New System.Drawing.Size(185, 22)
		Me.mnuPOPProperties.Text = "&Properties"
		'
		'mnuRestoreDefaults
		'
		Me.mnuRestoreDefaults.Name = "mnuRestoreDefaults"
		Me.mnuRestoreDefaults.Size = New System.Drawing.Size(185, 22)
		Me.mnuRestoreDefaults.Text = "Restore &Defaults"
		Me.mnuRestoreDefaults.Visible = False
		'
		'PrintDialog1
		'
		Me.PrintDialog1.UseEXDialog = True
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
		'timBackupStatus
		'
		Me.timBackupStatus.Interval = 30000
		'
		'frmMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.ClientSize = New System.Drawing.Size(1026, 688)
		Me.Controls.Add(Me.picBookshelf_1)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Controls.Add(Me.HScroll1)
		Me.Controls.Add(Me.picBookshelf_0)
		Me.Controls.Add(Me.MainMenu1)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Location = New System.Drawing.Point(124, 117)
		Me.Name = "frmMain"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "SiriusCook"
		Me.picBookshelf_0.ResumeLayout(False)
		CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.MainMenu1.ResumeLayout(False)
		Me.MainMenu1.PerformLayout()
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.mnuContextMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
	Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripLabel
	Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
	Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
	Friend WithEvents UserLabel As System.Windows.Forms.ToolStripLabel
	Friend WithEvents mnuControlTableEditor As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSetWSID As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuRestoreDatabase As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuContextMenu1 As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents mnuPOPOpenBook As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuPOPRemove As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuPOPProperties As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
	Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
	Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
	Friend WithEvents mnuRestoreDefaults As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents BackupRestoreStatus As System.Windows.Forms.ToolStripLabel
	Friend WithEvents mnuOrganizeDB As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuTheme As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents timBackupStatus As System.Windows.Forms.Timer
	Friend WithEvents mnuRegistry As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuMaintainLinks As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuRecent As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFavorites As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuCompactDatabase As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
	Friend WithEvents mnuViewReadMe As ToolStripMenuItem
	Friend WithEvents mnuViewLicense As ToolStripMenuItem
#End Region
End Class