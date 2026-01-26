<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOpenBook
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New(mBookID As Integer)
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
		BookID = mBookID
		PerformStartup()
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
	Public WithEvents imgNext As System.Windows.Forms.PictureBox
	Public WithEvents imgPrev As System.Windows.Forms.PictureBox
	Public WithEvents imgNextCat As System.Windows.Forms.PictureBox
	Public WithEvents mnuNewRecipe As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEditRecipe As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSaveRecipe As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRemoveRecipe As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents RecipeMenuSep1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuPrintDividers As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents RecipeMenuSep2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuPrintRecipe As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEmailRecipe As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents RecipeMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCopyText As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCutText As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCopyRecipe As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents EditMenuSep1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuPasteText As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuPasteRecipe As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents EditMenu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenBook))
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.imgNext = New System.Windows.Forms.PictureBox()
		Me.imgPrev = New System.Windows.Forms.PictureBox()
		Me.imgNextCat = New System.Windows.Forms.PictureBox()
		Me.imgPrevCat = New System.Windows.Forms.PictureBox()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
		Me.RecipeMenu = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuNewRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuEditRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuSaveRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuMoveRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuRemoveRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuAddImage = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuPasteImage = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuDeleteImage = New System.Windows.Forms.ToolStripMenuItem()
		Me.RecipeMenuSep1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuPrintDividers = New System.Windows.Forms.ToolStripMenuItem()
		Me.RecipeMenuSep2 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuViewRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuPrintRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuEmailRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuExportHTML1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuExportHTML2 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuExportRTF1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuExportRTF2 = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuExchange = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuChangeServings = New System.Windows.Forms.ToolStripMenuItem()
		Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuCopyText = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuCutText = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuCopyRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuCopyExchange = New System.Windows.Forms.ToolStripMenuItem()
		Me.EditMenuSep1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuPasteText = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuPasteRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.LinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuLink = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuMaintainLinks = New System.Windows.Forms.ToolStripMenuItem()
		Me.pnlContents = New System.Windows.Forms.Panel()
		Me.imgLeftTabs = New System.Windows.Forms.PictureBox()
		Me.imgRightTabs = New System.Windows.Forms.PictureBox()
		Me.pnlEditRecipe = New System.Windows.Forms.Panel()
		Me.txtNotes = New PromptedTextBox.PromptedTextBox()
		Me.txtServings = New PromptedTextBox.PromptedTextBox()
		Me.txtTitle = New PromptedTextBox.PromptedTextBox()
		Me.txtCategory = New PromptedTextBox.PromptedTextBox()
		Me.txtAuthor = New PromptedTextBox.PromptedTextBox()
		Me.txtBlurb = New PromptedTextBox.PromptedTextBox()
		Me.txtIngredients = New PromptedTextBox.PromptedTextBox()
		Me.txtProcedure = New PromptedTextBox.PromptedTextBox()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.imgTOC = New System.Windows.Forms.PictureBox()
		Me.pnlDisplayRecipe = New System.Windows.Forms.Panel()
		Me.lblCategory = New System.Windows.Forms.Label()
		Me.lblServings = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblBlurb = New System.Windows.Forms.Label()
		Me.lblAuthor = New System.Windows.Forms.Label()
		Me.lblTitle = New System.Windows.Forms.Label()
		Me.pnlIngredients = New System.Windows.Forms.Panel()
		Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
		Me.VScrollBar2 = New System.Windows.Forms.VScrollBar()
		Me.pnlProcedure = New System.Windows.Forms.Panel()
		Me.lblBookTitle = New System.Windows.Forms.Label()
		Me.lblStatistics = New System.Windows.Forms.Label()
		Me.lblBookAuthor = New System.Windows.Forms.Label()
		Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.mnuPViewRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuPEmailRecipe = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuPPrintRecipe = New System.Windows.Forms.ToolStripMenuItem()
		CType(Me.imgNext, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgPrev, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgNextCat, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgPrevCat, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MainMenu1.SuspendLayout()
		Me.pnlContents.SuspendLayout()
		CType(Me.imgLeftTabs, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgRightTabs, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlEditRecipe.SuspendLayout()
		CType(Me.imgTOC, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlDisplayRecipe.SuspendLayout()
		Me.ContextMenuStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'imgNext
		'
		Me.imgNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgNext.Image = CType(resources.GetObject("imgNext.Image"), System.Drawing.Image)
		Me.imgNext.Location = New System.Drawing.Point(831, 601)
		Me.imgNext.Name = "imgNext"
		Me.imgNext.Size = New System.Drawing.Size(32, 32)
		Me.imgNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgNext.TabIndex = 11
		Me.imgNext.TabStop = False
		Me.ToolTip1.SetToolTip(Me.imgNext, "Next Page")
		'
		'imgPrev
		'
		Me.imgPrev.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgPrev.Image = CType(resources.GetObject("imgPrev.Image"), System.Drawing.Image)
		Me.imgPrev.Location = New System.Drawing.Point(39, 601)
		Me.imgPrev.Name = "imgPrev"
		Me.imgPrev.Size = New System.Drawing.Size(32, 32)
		Me.imgPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgPrev.TabIndex = 12
		Me.imgPrev.TabStop = False
		Me.ToolTip1.SetToolTip(Me.imgPrev, "Previous Page")
		'
		'imgNextCat
		'
		Me.imgNextCat.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgNextCat.Image = CType(resources.GetObject("imgNextCat.Image"), System.Drawing.Image)
		Me.imgNextCat.Location = New System.Drawing.Point(783, 601)
		Me.imgNextCat.Name = "imgNextCat"
		Me.imgNextCat.Size = New System.Drawing.Size(32, 32)
		Me.imgNextCat.TabIndex = 14
		Me.imgNextCat.TabStop = False
		Me.ToolTip1.SetToolTip(Me.imgNextCat, "Next Food Category")
		'
		'imgPrevCat
		'
		Me.imgPrevCat.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgPrevCat.Image = CType(resources.GetObject("imgPrevCat.Image"), System.Drawing.Image)
		Me.imgPrevCat.Location = New System.Drawing.Point(94, 601)
		Me.imgPrevCat.Name = "imgPrevCat"
		Me.imgPrevCat.Size = New System.Drawing.Size(32, 32)
		Me.imgPrevCat.TabIndex = 16
		Me.imgPrevCat.TabStop = False
		Me.ToolTip1.SetToolTip(Me.imgPrevCat, "Previous Food Category")
		'
		'PictureBox1
		'
		Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.PictureBox1.Location = New System.Drawing.Point(246, 97)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(74, 51)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox1.TabIndex = 70
		Me.PictureBox1.TabStop = False
		Me.ToolTip1.SetToolTip(Me.PictureBox1, "Click to view image")
		Me.PictureBox1.Visible = False
		'
		'MainMenu1
		'
		Me.MainMenu1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
		Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecipeMenu, Me.EditMenu, Me.LinkToolStripMenuItem})
		Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
		Me.MainMenu1.Name = "MainMenu1"
		Me.MainMenu1.Size = New System.Drawing.Size(1078, 24)
		Me.MainMenu1.TabIndex = 41
		'
		'RecipeMenu
		'
		Me.RecipeMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewRecipe, Me.mnuEditRecipe, Me.mnuSaveRecipe, Me.mnuMoveRecipe, Me.mnuRemoveRecipe, Me.mnuAddImage, Me.mnuPasteImage, Me.mnuDeleteImage, Me.RecipeMenuSep1, Me.mnuPrintDividers, Me.RecipeMenuSep2, Me.mnuViewRecipe, Me.mnuPrintRecipe, Me.mnuEmailRecipe, Me.mnuExport, Me.ToolStripMenuItem2, Me.mnuChangeServings})
		Me.RecipeMenu.Name = "RecipeMenu"
		Me.RecipeMenu.Size = New System.Drawing.Size(54, 20)
		Me.RecipeMenu.Text = "&Recipe"
		'
		'mnuNewRecipe
		'
		Me.mnuNewRecipe.Name = "mnuNewRecipe"
		Me.mnuNewRecipe.Size = New System.Drawing.Size(228, 22)
		Me.mnuNewRecipe.Text = "&New Recipe"
		'
		'mnuEditRecipe
		'
		Me.mnuEditRecipe.Enabled = False
		Me.mnuEditRecipe.Name = "mnuEditRecipe"
		Me.mnuEditRecipe.Size = New System.Drawing.Size(228, 22)
		Me.mnuEditRecipe.Text = "&Edit Recipe"
		'
		'mnuSaveRecipe
		'
		Me.mnuSaveRecipe.Enabled = False
		Me.mnuSaveRecipe.Name = "mnuSaveRecipe"
		Me.mnuSaveRecipe.Size = New System.Drawing.Size(228, 22)
		Me.mnuSaveRecipe.Text = "&Save Recipe"
		'
		'mnuMoveRecipe
		'
		Me.mnuMoveRecipe.Enabled = False
		Me.mnuMoveRecipe.Name = "mnuMoveRecipe"
		Me.mnuMoveRecipe.Size = New System.Drawing.Size(228, 22)
		Me.mnuMoveRecipe.Text = "Mo&ve Recipe..."
		'
		'mnuRemoveRecipe
		'
		Me.mnuRemoveRecipe.Enabled = False
		Me.mnuRemoveRecipe.Name = "mnuRemoveRecipe"
		Me.mnuRemoveRecipe.Size = New System.Drawing.Size(228, 22)
		Me.mnuRemoveRecipe.Text = "&Remove Recipe from Book"
		'
		'mnuAddImage
		'
		Me.mnuAddImage.Enabled = False
		Me.mnuAddImage.Name = "mnuAddImage"
		Me.mnuAddImage.Size = New System.Drawing.Size(228, 22)
		Me.mnuAddImage.Text = "Add &Image..."
		'
		'mnuPasteImage
		'
		Me.mnuPasteImage.Enabled = False
		Me.mnuPasteImage.Name = "mnuPasteImage"
		Me.mnuPasteImage.Size = New System.Drawing.Size(228, 22)
		Me.mnuPasteImage.Text = "Pas&te Image"
		'
		'mnuDeleteImage
		'
		Me.mnuDeleteImage.Enabled = False
		Me.mnuDeleteImage.Name = "mnuDeleteImage"
		Me.mnuDeleteImage.Size = New System.Drawing.Size(228, 22)
		Me.mnuDeleteImage.Text = "&Delete Image"
		'
		'RecipeMenuSep1
		'
		Me.RecipeMenuSep1.Name = "RecipeMenuSep1"
		Me.RecipeMenuSep1.Size = New System.Drawing.Size(225, 6)
		'
		'mnuPrintDividers
		'
		Me.mnuPrintDividers.Name = "mnuPrintDividers"
		Me.mnuPrintDividers.Size = New System.Drawing.Size(228, 22)
		Me.mnuPrintDividers.Text = "Print &Card File Dividers"
		'
		'RecipeMenuSep2
		'
		Me.RecipeMenuSep2.Name = "RecipeMenuSep2"
		Me.RecipeMenuSep2.Size = New System.Drawing.Size(225, 6)
		'
		'mnuViewRecipe
		'
		Me.mnuViewRecipe.Enabled = False
		Me.mnuViewRecipe.Name = "mnuViewRecipe"
		Me.mnuViewRecipe.Size = New System.Drawing.Size(228, 22)
		Me.mnuViewRecipe.Text = "&View"
		'
		'mnuPrintRecipe
		'
		Me.mnuPrintRecipe.Enabled = False
		Me.mnuPrintRecipe.Name = "mnuPrintRecipe"
		Me.mnuPrintRecipe.Size = New System.Drawing.Size(228, 22)
		Me.mnuPrintRecipe.Text = "&Print..."
		'
		'mnuEmailRecipe
		'
		Me.mnuEmailRecipe.Enabled = False
		Me.mnuEmailRecipe.Name = "mnuEmailRecipe"
		Me.mnuEmailRecipe.Size = New System.Drawing.Size(228, 22)
		Me.mnuEmailRecipe.Text = "E&mail..."
		'
		'mnuExport
		'
		Me.mnuExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportHTML1, Me.mnuExportHTML2, Me.mnuExportRTF1, Me.mnuExportRTF2, Me.mnuExchange})
		Me.mnuExport.Enabled = False
		Me.mnuExport.Name = "mnuExport"
		Me.mnuExport.Size = New System.Drawing.Size(228, 22)
		Me.mnuExport.Text = "E&xport"
		'
		'mnuExportHTML1
		'
		Me.mnuExportHTML1.Name = "mnuExportHTML1"
		Me.mnuExportHTML1.Size = New System.Drawing.Size(165, 22)
		Me.mnuExportHTML1.Text = "HTML (&Desktop)"
		'
		'mnuExportHTML2
		'
		Me.mnuExportHTML2.Name = "mnuExportHTML2"
		Me.mnuExportHTML2.Size = New System.Drawing.Size(165, 22)
		Me.mnuExportHTML2.Text = "HTML (&Mobile)"
		'
		'mnuExportRTF1
		'
		Me.mnuExportRTF1.Name = "mnuExportRTF1"
		Me.mnuExportRTF1.Size = New System.Drawing.Size(165, 22)
		Me.mnuExportRTF1.Text = "&RTF (Desktop)"
		'
		'mnuExportRTF2
		'
		Me.mnuExportRTF2.Name = "mnuExportRTF2"
		Me.mnuExportRTF2.Size = New System.Drawing.Size(165, 22)
		Me.mnuExportRTF2.Text = "R&TF (Mobile)"
		'
		'mnuExchange
		'
		Me.mnuExchange.Name = "mnuExchange"
		Me.mnuExchange.Size = New System.Drawing.Size(165, 22)
		Me.mnuExchange.Text = "&Exchange Format"
		'
		'ToolStripMenuItem2
		'
		Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
		Me.ToolStripMenuItem2.Size = New System.Drawing.Size(225, 6)
		'
		'mnuChangeServings
		'
		Me.mnuChangeServings.Name = "mnuChangeServings"
		Me.mnuChangeServings.Size = New System.Drawing.Size(228, 22)
		Me.mnuChangeServings.Text = "&Increase or Decrease Servings"
		'
		'EditMenu
		'
		Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopyText, Me.mnuCutText, Me.mnuCopyRecipe, Me.mnuCopyExchange, Me.EditMenuSep1, Me.mnuPasteText, Me.mnuPasteRecipe})
		Me.EditMenu.Name = "EditMenu"
		Me.EditMenu.Size = New System.Drawing.Size(39, 20)
		Me.EditMenu.Text = "&Edit"
		'
		'mnuCopyText
		'
		Me.mnuCopyText.Enabled = False
		Me.mnuCopyText.Name = "mnuCopyText"
		Me.mnuCopyText.Size = New System.Drawing.Size(207, 22)
		Me.mnuCopyText.Text = "Copy &Text"
		'
		'mnuCutText
		'
		Me.mnuCutText.Enabled = False
		Me.mnuCutText.Name = "mnuCutText"
		Me.mnuCutText.Size = New System.Drawing.Size(207, 22)
		Me.mnuCutText.Text = "C&ut Text"
		'
		'mnuCopyRecipe
		'
		Me.mnuCopyRecipe.Enabled = False
		Me.mnuCopyRecipe.Name = "mnuCopyRecipe"
		Me.mnuCopyRecipe.Size = New System.Drawing.Size(207, 22)
		Me.mnuCopyRecipe.Text = "Copy &Recipe as Text"
		'
		'mnuCopyExchange
		'
		Me.mnuCopyExchange.Enabled = False
		Me.mnuCopyExchange.Name = "mnuCopyExchange"
		Me.mnuCopyExchange.Size = New System.Drawing.Size(207, 22)
		Me.mnuCopyExchange.Text = "Copy Recipe as &Exchange"
		'
		'EditMenuSep1
		'
		Me.EditMenuSep1.Name = "EditMenuSep1"
		Me.EditMenuSep1.Size = New System.Drawing.Size(204, 6)
		'
		'mnuPasteText
		'
		Me.mnuPasteText.Enabled = False
		Me.mnuPasteText.Name = "mnuPasteText"
		Me.mnuPasteText.Size = New System.Drawing.Size(207, 22)
		Me.mnuPasteText.Text = "Paste Te&xt"
		'
		'mnuPasteRecipe
		'
		Me.mnuPasteRecipe.Enabled = False
		Me.mnuPasteRecipe.Name = "mnuPasteRecipe"
		Me.mnuPasteRecipe.Size = New System.Drawing.Size(207, 22)
		Me.mnuPasteRecipe.Text = "Paste Reci&pe"
		'
		'LinkToolStripMenuItem
		'
		Me.LinkToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLink, Me.mnuMaintainLinks})
		Me.LinkToolStripMenuItem.Name = "LinkToolStripMenuItem"
		Me.LinkToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
		Me.LinkToolStripMenuItem.Text = "&Link"
		Me.LinkToolStripMenuItem.Visible = False
		'
		'mnuLink
		'
		Me.mnuLink.Name = "mnuLink"
		Me.mnuLink.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
		Me.mnuLink.Size = New System.Drawing.Size(234, 22)
		Me.mnuLink.Text = "Link to Another &Recipe"
		'
		'mnuMaintainLinks
		'
		Me.mnuMaintainLinks.Name = "mnuMaintainLinks"
		Me.mnuMaintainLinks.Size = New System.Drawing.Size(234, 22)
		Me.mnuMaintainLinks.Text = "&Maintain Links"
		'
		'pnlContents
		'
		Me.pnlContents.BackgroundImage = Global.Sirius_Cook_SQL.My.Resources.Resources.OpenBinder
		Me.pnlContents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.pnlContents.Controls.Add(Me.imgLeftTabs)
		Me.pnlContents.Controls.Add(Me.imgRightTabs)
		Me.pnlContents.Controls.Add(Me.pnlEditRecipe)
		Me.pnlContents.Controls.Add(Me.imgTOC)
		Me.pnlContents.Controls.Add(Me.pnlDisplayRecipe)
		Me.pnlContents.Location = New System.Drawing.Point(3, 25)
		Me.pnlContents.Name = "pnlContents"
		Me.pnlContents.Size = New System.Drawing.Size(891, 570)
		Me.pnlContents.TabIndex = 20
		'
		'imgLeftTabs
		'
		Me.imgLeftTabs.BackColor = System.Drawing.Color.Transparent
		Me.imgLeftTabs.Location = New System.Drawing.Point(22, 42)
		Me.imgLeftTabs.Name = "imgLeftTabs"
		Me.imgLeftTabs.Size = New System.Drawing.Size(36, 376)
		Me.imgLeftTabs.TabIndex = 70
		Me.imgLeftTabs.TabStop = False
		'
		'imgRightTabs
		'
		Me.imgRightTabs.BackColor = System.Drawing.Color.Transparent
		Me.imgRightTabs.Location = New System.Drawing.Point(815, 42)
		Me.imgRightTabs.Name = "imgRightTabs"
		Me.imgRightTabs.Size = New System.Drawing.Size(36, 376)
		Me.imgRightTabs.TabIndex = 71
		Me.imgRightTabs.TabStop = False
		'
		'pnlEditRecipe
		'
		Me.pnlEditRecipe.BackColor = System.Drawing.Color.Transparent
		Me.pnlEditRecipe.BackgroundImage = Global.Sirius_Cook_SQL.My.Resources.Resources.OpenBindePager
		Me.pnlEditRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.pnlEditRecipe.Controls.Add(Me.txtNotes)
		Me.pnlEditRecipe.Controls.Add(Me.txtServings)
		Me.pnlEditRecipe.Controls.Add(Me.txtTitle)
		Me.pnlEditRecipe.Controls.Add(Me.txtCategory)
		Me.pnlEditRecipe.Controls.Add(Me.txtAuthor)
		Me.pnlEditRecipe.Controls.Add(Me.txtBlurb)
		Me.pnlEditRecipe.Controls.Add(Me.txtIngredients)
		Me.pnlEditRecipe.Controls.Add(Me.txtProcedure)
		Me.pnlEditRecipe.Controls.Add(Me.btnCancel)
		Me.pnlEditRecipe.Controls.Add(Me.btnSave)
		Me.pnlEditRecipe.Location = New System.Drawing.Point(51, 25)
		Me.pnlEditRecipe.Name = "pnlEditRecipe"
		Me.pnlEditRecipe.Size = New System.Drawing.Size(774, 492)
		Me.pnlEditRecipe.TabIndex = 68
		Me.pnlEditRecipe.Visible = False
		'
		'txtNotes
		'
		Me.txtNotes.ForeColor = System.Drawing.Color.DarkGray
		Me.txtNotes.Location = New System.Drawing.Point(447, 370)
		Me.txtNotes.Multiline = True
		Me.txtNotes.Name = "txtNotes"
		Me.txtNotes.Prompt = "Add additional notes"
		Me.txtNotes.Size = New System.Drawing.Size(314, 78)
		Me.txtNotes.TabIndex = 8
		Me.txtNotes.Text = "Add additional notes"
		'
		'txtServings
		'
		Me.txtServings.ForeColor = System.Drawing.Color.DarkGray
		Me.txtServings.Location = New System.Drawing.Point(23, 134)
		Me.txtServings.Name = "txtServings"
		Me.txtServings.Prompt = "No. Servings"
		Me.txtServings.Size = New System.Drawing.Size(72, 20)
		Me.txtServings.TabIndex = 5
		Me.txtServings.Text = "No. Servings"
		'
		'txtTitle
		'
		Me.txtTitle.ForeColor = System.Drawing.Color.DarkGray
		Me.txtTitle.Location = New System.Drawing.Point(23, 13)
		Me.txtTitle.Name = "txtTitle"
		Me.txtTitle.Prompt = "Recipe Title"
		Me.txtTitle.Size = New System.Drawing.Size(301, 20)
		Me.txtTitle.TabIndex = 1
		Me.txtTitle.Text = "Recipe Title"
		'
		'txtCategory
		'
		Me.txtCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.txtCategory.ForeColor = System.Drawing.Color.DarkGray
		Me.txtCategory.Location = New System.Drawing.Point(23, 35)
		Me.txtCategory.Name = "txtCategory"
		Me.txtCategory.Prompt = "Recipe Category"
		Me.txtCategory.Size = New System.Drawing.Size(173, 20)
		Me.txtCategory.TabIndex = 2
		Me.txtCategory.Text = "Recipe Category"
		'
		'txtAuthor
		'
		Me.txtAuthor.ForeColor = System.Drawing.Color.DarkGray
		Me.txtAuthor.Location = New System.Drawing.Point(23, 57)
		Me.txtAuthor.Name = "txtAuthor"
		Me.txtAuthor.Prompt = "Author's Name or Recipe Source"
		Me.txtAuthor.Size = New System.Drawing.Size(173, 20)
		Me.txtAuthor.TabIndex = 3
		Me.txtAuthor.Text = "Author's Name or Recipe Source"
		'
		'txtBlurb
		'
		Me.txtBlurb.ForeColor = System.Drawing.Color.DarkGray
		Me.txtBlurb.Location = New System.Drawing.Point(23, 79)
		Me.txtBlurb.Multiline = True
		Me.txtBlurb.Name = "txtBlurb"
		Me.txtBlurb.Prompt = "Say something about this recipe"
		Me.txtBlurb.Size = New System.Drawing.Size(301, 47)
		Me.txtBlurb.TabIndex = 4
		Me.txtBlurb.Text = "Say something about this recipe"
		'
		'txtIngredients
		'
		Me.txtIngredients.ForeColor = System.Drawing.Color.DarkGray
		Me.txtIngredients.Location = New System.Drawing.Point(23, 166)
		Me.txtIngredients.Multiline = True
		Me.txtIngredients.Name = "txtIngredients"
		Me.txtIngredients.Prompt = "List the ingredients for the recipe, pressing Enter between each ingredient"
		Me.txtIngredients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtIngredients.Size = New System.Drawing.Size(301, 295)
		Me.txtIngredients.TabIndex = 6
		Me.txtIngredients.Text = "List the ingredients for the recipe, pressing Enter between each ingredient"
		'
		'txtProcedure
		'
		Me.txtProcedure.ForeColor = System.Drawing.Color.DarkGray
		Me.txtProcedure.Location = New System.Drawing.Point(447, 59)
		Me.txtProcedure.Multiline = True
		Me.txtProcedure.Name = "txtProcedure"
		Me.txtProcedure.Prompt = "List the steps to making the recipe"
		Me.txtProcedure.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtProcedure.Size = New System.Drawing.Size(314, 304)
		Me.txtProcedure.TabIndex = 7
		Me.txtProcedure.Text = "List the steps to making the recipe"
		'
		'btnCancel
		'
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCancel.Location = New System.Drawing.Point(615, 456)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCancel.Size = New System.Drawing.Size(81, 25)
		Me.btnCancel.TabIndex = 10
		Me.btnCancel.Text = "&Cancel"
		Me.btnCancel.UseVisualStyleBackColor = False
		'
		'btnSave
		'
		Me.btnSave.BackColor = System.Drawing.SystemColors.Control
		Me.btnSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnSave.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnSave.Location = New System.Drawing.Point(459, 456)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnSave.Size = New System.Drawing.Size(81, 25)
		Me.btnSave.TabIndex = 9
		Me.btnSave.Text = "&Save Recipe"
		Me.btnSave.UseVisualStyleBackColor = False
		'
		'imgTOC
		'
		Me.imgTOC.BackColor = System.Drawing.Color.Transparent
		Me.imgTOC.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgTOC.Location = New System.Drawing.Point(9, 36)
		Me.imgTOC.Name = "imgTOC"
		Me.imgTOC.Size = New System.Drawing.Size(19, 110)
		Me.imgTOC.TabIndex = 67
		Me.imgTOC.TabStop = False
		'
		'pnlDisplayRecipe
		'
		Me.pnlDisplayRecipe.BackColor = System.Drawing.Color.Transparent
		Me.pnlDisplayRecipe.BackgroundImage = Global.Sirius_Cook_SQL.My.Resources.Resources.OpenBinderPages
		Me.pnlDisplayRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.pnlDisplayRecipe.Controls.Add(Me.PictureBox1)
		Me.pnlDisplayRecipe.Controls.Add(Me.lblCategory)
		Me.pnlDisplayRecipe.Controls.Add(Me.lblServings)
		Me.pnlDisplayRecipe.Controls.Add(Me.Label2)
		Me.pnlDisplayRecipe.Controls.Add(Me.lblBlurb)
		Me.pnlDisplayRecipe.Controls.Add(Me.lblAuthor)
		Me.pnlDisplayRecipe.Controls.Add(Me.lblTitle)
		Me.pnlDisplayRecipe.Controls.Add(Me.pnlIngredients)
		Me.pnlDisplayRecipe.Controls.Add(Me.VScrollBar1)
		Me.pnlDisplayRecipe.Controls.Add(Me.VScrollBar2)
		Me.pnlDisplayRecipe.Controls.Add(Me.pnlProcedure)
		Me.pnlDisplayRecipe.Location = New System.Drawing.Point(51, 28)
		Me.pnlDisplayRecipe.Name = "pnlDisplayRecipe"
		Me.pnlDisplayRecipe.Size = New System.Drawing.Size(774, 492)
		Me.pnlDisplayRecipe.TabIndex = 69
		Me.pnlDisplayRecipe.Visible = False
		'
		'lblCategory
		'
		Me.lblCategory.BackColor = System.Drawing.Color.Transparent
		Me.lblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblCategory.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCategory.Location = New System.Drawing.Point(13, 11)
		Me.lblCategory.Name = "lblCategory"
		Me.lblCategory.Size = New System.Drawing.Size(308, 19)
		Me.lblCategory.TabIndex = 54
		Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblServings
		'
		Me.lblServings.BackColor = System.Drawing.Color.Transparent
		Me.lblServings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblServings.Location = New System.Drawing.Point(81, 157)
		Me.lblServings.Name = "lblServings"
		Me.lblServings.Size = New System.Drawing.Size(31, 19)
		Me.lblServings.TabIndex = 53
		Me.lblServings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(10, 157)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(65, 19)
		Me.Label2.TabIndex = 52
		Me.Label2.Text = "Servings:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblBlurb
		'
		Me.lblBlurb.BackColor = System.Drawing.Color.Transparent
		Me.lblBlurb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblBlurb.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblBlurb.Location = New System.Drawing.Point(13, 97)
		Me.lblBlurb.Name = "lblBlurb"
		Me.lblBlurb.Size = New System.Drawing.Size(227, 51)
		Me.lblBlurb.TabIndex = 51
		'
		'lblAuthor
		'
		Me.lblAuthor.BackColor = System.Drawing.Color.Transparent
		Me.lblAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblAuthor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAuthor.Location = New System.Drawing.Point(13, 71)
		Me.lblAuthor.Name = "lblAuthor"
		Me.lblAuthor.Size = New System.Drawing.Size(308, 19)
		Me.lblAuthor.TabIndex = 50
		Me.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblTitle
		'
		Me.lblTitle.BackColor = System.Drawing.Color.Transparent
		Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitle.Location = New System.Drawing.Point(13, 40)
		Me.lblTitle.Name = "lblTitle"
		Me.lblTitle.Size = New System.Drawing.Size(308, 22)
		Me.lblTitle.TabIndex = 49
		Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'pnlIngredients
		'
		Me.pnlIngredients.Location = New System.Drawing.Point(13, 173)
		Me.pnlIngredients.Name = "pnlIngredients"
		Me.pnlIngredients.Size = New System.Drawing.Size(284, 269)
		Me.pnlIngredients.TabIndex = 47
		'
		'VScrollBar1
		'
		Me.VScrollBar1.Location = New System.Drawing.Point(299, 173)
		Me.VScrollBar1.Name = "VScrollBar1"
		Me.VScrollBar1.Size = New System.Drawing.Size(14, 269)
		Me.VScrollBar1.TabIndex = 48
		'
		'VScrollBar2
		'
		Me.VScrollBar2.Location = New System.Drawing.Point(733, 59)
		Me.VScrollBar2.Name = "VScrollBar2"
		Me.VScrollBar2.Size = New System.Drawing.Size(17, 400)
		Me.VScrollBar2.TabIndex = 45
		'
		'pnlProcedure
		'
		Me.pnlProcedure.AutoSize = True
		Me.pnlProcedure.BackColor = System.Drawing.Color.Transparent
		Me.pnlProcedure.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.pnlProcedure.Location = New System.Drawing.Point(441, 59)
		Me.pnlProcedure.Name = "pnlProcedure"
		Me.pnlProcedure.Size = New System.Drawing.Size(292, 391)
		Me.pnlProcedure.TabIndex = 46
		'
		'lblBookTitle
		'
		Me.lblBookTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
		Me.lblBookTitle.CausesValidation = False
		Me.lblBookTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblBookTitle.Location = New System.Drawing.Point(900, 32)
		Me.lblBookTitle.Name = "lblBookTitle"
		Me.lblBookTitle.Size = New System.Drawing.Size(156, 80)
		Me.lblBookTitle.TabIndex = 42
		Me.lblBookTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblStatistics
		'
		Me.lblStatistics.BackColor = System.Drawing.SystemColors.ButtonFace
		Me.lblStatistics.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblStatistics.Location = New System.Drawing.Point(901, 149)
		Me.lblStatistics.Name = "lblStatistics"
		Me.lblStatistics.Size = New System.Drawing.Size(156, 385)
		Me.lblStatistics.TabIndex = 43
		Me.lblStatistics.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblBookAuthor
		'
		Me.lblBookAuthor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
		Me.lblBookAuthor.Location = New System.Drawing.Point(900, 112)
		Me.lblBookAuthor.Name = "lblBookAuthor"
		Me.lblBookAuthor.Size = New System.Drawing.Size(156, 22)
		Me.lblBookAuthor.TabIndex = 44
		Me.lblBookAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'ContextMenuStrip1
		'
		Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPViewRecipe, Me.ToolStripSeparator1, Me.mnuPEmailRecipe, Me.ToolStripMenuItem1, Me.mnuPPrintRecipe})
		Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
		Me.ContextMenuStrip1.Size = New System.Drawing.Size(142, 82)
		'
		'mnuPViewRecipe
		'
		Me.mnuPViewRecipe.Name = "mnuPViewRecipe"
		Me.mnuPViewRecipe.Size = New System.Drawing.Size(141, 22)
		Me.mnuPViewRecipe.Text = "&View Recipe"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(138, 6)
		'
		'mnuPEmailRecipe
		'
		Me.mnuPEmailRecipe.Name = "mnuPEmailRecipe"
		Me.mnuPEmailRecipe.Size = New System.Drawing.Size(141, 22)
		Me.mnuPEmailRecipe.Text = "&Email Recipe"
		'
		'ToolStripMenuItem1
		'
		Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
		Me.ToolStripMenuItem1.Size = New System.Drawing.Size(138, 6)
		'
		'mnuPPrintRecipe
		'
		Me.mnuPPrintRecipe.Name = "mnuPPrintRecipe"
		Me.mnuPPrintRecipe.Size = New System.Drawing.Size(141, 22)
		Me.mnuPPrintRecipe.Text = "&Print Recipe"
		'
		'frmOpenBook
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.ClientSize = New System.Drawing.Size(1078, 679)
		Me.Controls.Add(Me.lblBookTitle)
		Me.Controls.Add(Me.lblBookAuthor)
		Me.Controls.Add(Me.lblStatistics)
		Me.Controls.Add(Me.imgNext)
		Me.Controls.Add(Me.imgNextCat)
		Me.Controls.Add(Me.imgPrev)
		Me.Controls.Add(Me.imgPrevCat)
		Me.Controls.Add(Me.MainMenu1)
		Me.Controls.Add(Me.pnlContents)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Location = New System.Drawing.Point(3, 64)
		Me.MainMenuStrip = Me.MainMenu1
		Me.Name = "frmOpenBook"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		CType(Me.imgNext, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgPrev, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgNextCat, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgPrevCat, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.MainMenu1.ResumeLayout(False)
		Me.MainMenu1.PerformLayout()
		Me.pnlContents.ResumeLayout(False)
		CType(Me.imgLeftTabs, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgRightTabs, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlEditRecipe.ResumeLayout(False)
		Me.pnlEditRecipe.PerformLayout()
		CType(Me.imgTOC, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlDisplayRecipe.ResumeLayout(False)
		Me.pnlDisplayRecipe.PerformLayout()
		Me.ContextMenuStrip1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlContents As System.Windows.Forms.Panel
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnSave As System.Windows.Forms.Button
	Public WithEvents imgTOC As System.Windows.Forms.PictureBox
	Public WithEvents imgPrevCat As System.Windows.Forms.PictureBox
	Friend WithEvents lblBookTitle As System.Windows.Forms.Label
	Friend WithEvents lblStatistics As System.Windows.Forms.Label
	Friend WithEvents lblBookAuthor As System.Windows.Forms.Label
	Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents mnuPEmailRecipe As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuPPrintRecipe As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuMoveRecipe As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuCopyExchange As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuChangeServings As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents LinkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuLink As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents pnlEditRecipe As Panel
	Friend WithEvents pnlDisplayRecipe As Panel
	Friend WithEvents lblServings As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents lblBlurb As Label
	Friend WithEvents lblAuthor As Label
	Friend WithEvents lblTitle As Label
	Friend WithEvents VScrollBar1 As VScrollBar
	Friend WithEvents pnlIngredients As Panel
	Friend WithEvents VScrollBar2 As VScrollBar
	Friend WithEvents pnlProcedure As Panel
	Friend WithEvents lblCategory As Label
	Friend WithEvents mnuAddImage As ToolStripMenuItem
	Friend WithEvents mnuDeleteImage As ToolStripMenuItem
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents imgRightTabs As PictureBox
	Friend WithEvents imgLeftTabs As PictureBox
	Friend WithEvents mnuPasteImage As ToolStripMenuItem
	Friend WithEvents mnuPViewRecipe As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents mnuViewRecipe As ToolStripMenuItem
	Friend WithEvents txtServings As PromptedTextBox.PromptedTextBox
	Friend WithEvents txtTitle As PromptedTextBox.PromptedTextBox
	Friend WithEvents txtCategory As PromptedTextBox.PromptedTextBox
	Friend WithEvents txtAuthor As PromptedTextBox.PromptedTextBox
	Friend WithEvents txtBlurb As PromptedTextBox.PromptedTextBox
	Friend WithEvents txtIngredients As PromptedTextBox.PromptedTextBox
	Friend WithEvents txtProcedure As PromptedTextBox.PromptedTextBox
	Friend WithEvents mnuMaintainLinks As ToolStripMenuItem
	Friend WithEvents mnuExport As ToolStripMenuItem
	Friend WithEvents mnuExportHTML1 As ToolStripMenuItem
	Friend WithEvents mnuExportHTML2 As ToolStripMenuItem
	Friend WithEvents mnuExportRTF1 As ToolStripMenuItem
	Friend WithEvents mnuExportRTF2 As ToolStripMenuItem
	Friend WithEvents mnuExchange As ToolStripMenuItem
	Friend WithEvents txtNotes As PromptedTextBox.PromptedTextBox
#End Region
End Class