<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdminDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        lblWelcome = New Label()
        lblTitle = New Label()
        btnLogout = New Button()
        pnlSidebar = New Panel()
        btnQueueLogs = New Button()
        btnReports = New Button()
        btnCounterManagement = New Button()
        btnUserManagement = New Button()
        btnDashboard = New Button()
        pnlMainContent = New Panel()
        pnlUserManagement = New Panel()
        tabUserManagement = New TabControl()
        tpWithAccount = New TabPage()
        dgvUsersWithAccount = New DataGridView()
        tpWithoutAccount = New TabPage()
        dgvUsersWithoutAccount = New DataGridView()
        pnlUserControls = New Panel()
        btnDeleteUser = New Button()
        btnEditUser = New Button()
        btnAddUser = New Button()
        txtSearchUsers = New TextBox()
        lblSearchUsers = New Label()
        pnlUserHeader = New Panel()
        lblUsersTotal = New Label()
        lblUserManagement = New Label()
        pnlQueueLogs = New Panel()
        dgvQueueLogs = New DataGridView()
        pnlQueueLogsControls = New Panel()
        btnChangeStatus = New Button()
        cboSortQueueLogs = New ComboBox()
        lblSortQueueLogs = New Label()
        txtSearchQueueLogs = New TextBox()
        lblSearchQueueLogs = New Label()
        pnlQueueLogsHeader = New Panel()
        lblQueueLogsTotal = New Label()
        lblQueueLogs = New Label()
        pnlReports = New Panel()
        tabReports = New TabControl()
        tpQueueLogsReport = New TabPage()
        pnlQueueLogsReport = New Panel()
        dgvReports = New DataGridView()
        pnlReportControls = New Panel()
        lblReportTotal = New Label()
        btnGenerateReport = New Button()
        dtpEndDate = New DateTimePicker()
        lblEndDate = New Label()
        dtpStartDate = New DateTimePicker()
        lblStartDate = New Label()
        cboReportType = New ComboBox()
        lblReportType = New Label()
        lblReports = New Label()
        pnlCounterManagement = New Panel()
        dgvCounters = New DataGridView()
        pnlCounterControls = New Panel()
        btnDeleteCounter = New Button()
        btnEditCounter = New Button()
        btnAddCounter = New Button()
        pnlCounterHeader = New Panel()
        lblCountersTotal = New Label()
        lblCounterManagement = New Label()
        pnlDashboard = New Panel()
        pnlQueues = New Panel()
        dgvAllQueues = New DataGridView()
        pnlQueuesControls = New Panel()
        txtSearchAllQueues = New TextBox()
        lblSearchAllQueues = New Label()
        pnlQueuesHeader = New Panel()
        lblQueueTotal = New Label()
        lblQueueTitle = New Label()
        pnlCashiers = New Panel()
        dgvCashierStatus = New DataGridView()
        pnlCashiersHeader = New Panel()
        lblActiveCashiers = New Label()
        lblCashierTitle = New Label()
        tmrRefresh = New Timer(components)
        pnlHeader.SuspendLayout()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlUserManagement.SuspendLayout()
        tabUserManagement.SuspendLayout()
        tpWithAccount.SuspendLayout()
        CType(dgvUsersWithAccount, ComponentModel.ISupportInitialize).BeginInit()
        tpWithoutAccount.SuspendLayout()
        CType(dgvUsersWithoutAccount, ComponentModel.ISupportInitialize).BeginInit()
        pnlUserControls.SuspendLayout()
        pnlUserHeader.SuspendLayout()
        pnlQueueLogs.SuspendLayout()
        CType(dgvQueueLogs, ComponentModel.ISupportInitialize).BeginInit()
        pnlQueueLogsControls.SuspendLayout()
        pnlQueueLogsHeader.SuspendLayout()
        pnlReports.SuspendLayout()
        tabReports.SuspendLayout()
        tpQueueLogsReport.SuspendLayout()
        pnlQueueLogsReport.SuspendLayout()
        CType(dgvReports, ComponentModel.ISupportInitialize).BeginInit()
        pnlReportControls.SuspendLayout()
        pnlCounterManagement.SuspendLayout()
        CType(dgvCounters, ComponentModel.ISupportInitialize).BeginInit()
        pnlCounterControls.SuspendLayout()
        pnlCounterHeader.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlQueues.SuspendLayout()
        CType(dgvAllQueues, ComponentModel.ISupportInitialize).BeginInit()
        pnlQueuesControls.SuspendLayout()
        pnlQueuesHeader.SuspendLayout()
        pnlCashiers.SuspendLayout()
        CType(dgvCashierStatus, ComponentModel.ISupportInitialize).BeginInit()
        pnlCashiersHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        pnlHeader.Controls.Add(lblWelcome)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(3, 4, 3, 4)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(29, 20, 29, 20)
        pnlHeader.Size = New Size(1463, 113)
        pnlHeader.TabIndex = 0
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Poppins", 9.75F)
        lblWelcome.ForeColor = Color.WhiteSmoke
        lblWelcome.Location = New Point(32, 64)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(98, 30)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome,"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Poppins SemiBold", 15.75F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(29, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(422, 48)
        lblTitle.TabIndex = 0
        lblTitle.Text = "LOA EASE - Admin Dashboard"
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnLogout.Cursor = Cursors.Hand
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(1297, 31)
        btnLogout.Margin = New Padding(3, 4, 3, 4)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(137, 53)
        btnLogout.TabIndex = 2
        btnLogout.Text = "🚪 Log Out"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(45), CByte(52), CByte(54))
        pnlSidebar.Controls.Add(btnQueueLogs)
        pnlSidebar.Controls.Add(btnReports)
        pnlSidebar.Controls.Add(btnCounterManagement)
        pnlSidebar.Controls.Add(btnUserManagement)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 113)
        pnlSidebar.Margin = New Padding(3, 4, 3, 4)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Padding = New Padding(0, 13, 0, 0)
        pnlSidebar.Size = New Size(251, 820)
        pnlSidebar.TabIndex = 1
        ' 
        ' btnQueueLogs
        ' 
        btnQueueLogs.Cursor = Cursors.Hand
        btnQueueLogs.Dock = DockStyle.Top
        btnQueueLogs.FlatAppearance.BorderSize = 0
        btnQueueLogs.FlatStyle = FlatStyle.Flat
        btnQueueLogs.Font = New Font("Poppins", 10.5F)
        btnQueueLogs.ForeColor = Color.White
        btnQueueLogs.Location = New Point(0, 297)
        btnQueueLogs.Margin = New Padding(0)
        btnQueueLogs.Name = "btnQueueLogs"
        btnQueueLogs.Padding = New Padding(29, 0, 0, 0)
        btnQueueLogs.Size = New Size(251, 71)
        btnQueueLogs.TabIndex = 4
        btnQueueLogs.Text = "📋 Queue Logs"
        btnQueueLogs.TextAlign = ContentAlignment.MiddleLeft
        btnQueueLogs.UseVisualStyleBackColor = True
        ' 
        ' btnReports
        ' 
        btnReports.Cursor = Cursors.Hand
        btnReports.Dock = DockStyle.Top
        btnReports.FlatAppearance.BorderSize = 0
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Poppins", 10.5F)
        btnReports.ForeColor = Color.White
        btnReports.Location = New Point(0, 226)
        btnReports.Margin = New Padding(0)
        btnReports.Name = "btnReports"
        btnReports.Padding = New Padding(29, 0, 0, 0)
        btnReports.Size = New Size(251, 71)
        btnReports.TabIndex = 3
        btnReports.Text = "📊 Reports"
        btnReports.TextAlign = ContentAlignment.MiddleLeft
        btnReports.UseVisualStyleBackColor = True
        ' 
        ' btnCounterManagement
        ' 
        btnCounterManagement.Cursor = Cursors.Hand
        btnCounterManagement.Dock = DockStyle.Top
        btnCounterManagement.FlatAppearance.BorderSize = 0
        btnCounterManagement.FlatStyle = FlatStyle.Flat
        btnCounterManagement.Font = New Font("Poppins", 10.5F)
        btnCounterManagement.ForeColor = Color.White
        btnCounterManagement.Location = New Point(0, 155)
        btnCounterManagement.Margin = New Padding(0)
        btnCounterManagement.Name = "btnCounterManagement"
        btnCounterManagement.Padding = New Padding(29, 0, 0, 0)
        btnCounterManagement.Size = New Size(251, 71)
        btnCounterManagement.TabIndex = 2
        btnCounterManagement.Text = ChrW(55358) & ChrW(56991) & " Counters"
        btnCounterManagement.TextAlign = ContentAlignment.MiddleLeft
        btnCounterManagement.UseVisualStyleBackColor = True
        ' 
        ' btnUserManagement
        ' 
        btnUserManagement.Cursor = Cursors.Hand
        btnUserManagement.Dock = DockStyle.Top
        btnUserManagement.FlatAppearance.BorderSize = 0
        btnUserManagement.FlatStyle = FlatStyle.Flat
        btnUserManagement.Font = New Font("Poppins", 10.5F)
        btnUserManagement.ForeColor = Color.White
        btnUserManagement.Location = New Point(0, 84)
        btnUserManagement.Margin = New Padding(0)
        btnUserManagement.Name = "btnUserManagement"
        btnUserManagement.Padding = New Padding(29, 0, 0, 0)
        btnUserManagement.Size = New Size(251, 71)
        btnUserManagement.TabIndex = 1
        btnUserManagement.Text = "👥 Users"
        btnUserManagement.TextAlign = ContentAlignment.MiddleLeft
        btnUserManagement.UseVisualStyleBackColor = True
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        btnDashboard.Cursor = Cursors.Hand
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Poppins", 10.5F, FontStyle.Bold)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(0, 13)
        btnDashboard.Margin = New Padding(0)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(29, 0, 0, 0)
        btnDashboard.Size = New Size(251, 71)
        btnDashboard.TabIndex = 0
        btnDashboard.Text = "🏠 Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.Controls.Add(pnlUserManagement)
        pnlMainContent.Controls.Add(pnlQueueLogs)
        pnlMainContent.Controls.Add(pnlReports)
        pnlMainContent.Controls.Add(pnlCounterManagement)
        pnlMainContent.Controls.Add(pnlDashboard)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(251, 113)
        pnlMainContent.Margin = New Padding(3, 4, 3, 4)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Padding = New Padding(29, 33, 29, 33)
        pnlMainContent.Size = New Size(1212, 820)
        pnlMainContent.TabIndex = 2
        ' 
        ' pnlUserManagement
        ' 
        pnlUserManagement.Controls.Add(tabUserManagement)
        pnlUserManagement.Controls.Add(pnlUserControls)
        pnlUserManagement.Controls.Add(pnlUserHeader)
        pnlUserManagement.Dock = DockStyle.Fill
        pnlUserManagement.Location = New Point(29, 33)
        pnlUserManagement.Margin = New Padding(3, 4, 3, 4)
        pnlUserManagement.Name = "pnlUserManagement"
        pnlUserManagement.Size = New Size(1154, 754)
        pnlUserManagement.TabIndex = 5
        ' 
        ' tabUserManagement
        ' 
        tabUserManagement.Controls.Add(tpWithAccount)
        tabUserManagement.Controls.Add(tpWithoutAccount)
        tabUserManagement.Dock = DockStyle.Fill
        tabUserManagement.Location = New Point(0, 160)
        tabUserManagement.Margin = New Padding(3, 4, 3, 4)
        tabUserManagement.Name = "tabUserManagement"
        tabUserManagement.SelectedIndex = 0
        tabUserManagement.Size = New Size(1154, 594)
        tabUserManagement.TabIndex = 9
        ' 
        ' tpWithAccount
        ' 
        tpWithAccount.Controls.Add(dgvUsersWithAccount)
        tpWithAccount.Location = New Point(4, 29)
        tpWithAccount.Margin = New Padding(3, 4, 3, 4)
        tpWithAccount.Name = "tpWithAccount"
        tpWithAccount.Padding = New Padding(3, 4, 3, 4)
        tpWithAccount.Size = New Size(1146, 561)
        tpWithAccount.TabIndex = 0
        tpWithAccount.Text = "With Account"
        tpWithAccount.UseVisualStyleBackColor = True
        ' 
        ' dgvUsersWithAccount
        ' 
        dgvUsersWithAccount.AllowUserToAddRows = False
        dgvUsersWithAccount.AllowUserToDeleteRows = False
        dgvUsersWithAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsersWithAccount.BackgroundColor = Color.White
        dgvUsersWithAccount.BorderStyle = BorderStyle.None
        dgvUsersWithAccount.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvUsersWithAccount.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.White
        DataGridViewCellStyle1.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvUsersWithAccount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvUsersWithAccount.ColumnHeadersHeight = 40
        dgvUsersWithAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvUsersWithAccount.DefaultCellStyle = DataGridViewCellStyle2
        dgvUsersWithAccount.Dock = DockStyle.Fill
        dgvUsersWithAccount.EnableHeadersVisualStyles = False
        dgvUsersWithAccount.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvUsersWithAccount.Location = New Point(3, 4)
        dgvUsersWithAccount.Margin = New Padding(3, 4, 3, 4)
        dgvUsersWithAccount.MultiSelect = False
        dgvUsersWithAccount.Name = "dgvUsersWithAccount"
        dgvUsersWithAccount.ReadOnly = True
        dgvUsersWithAccount.RowHeadersVisible = False
        dgvUsersWithAccount.RowHeadersWidth = 51
        DataGridViewCellStyle3.Padding = New Padding(10, 0, 0, 0)
        dgvUsersWithAccount.RowsDefaultCellStyle = DataGridViewCellStyle3
        dgvUsersWithAccount.RowTemplate.Height = 45
        dgvUsersWithAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsersWithAccount.Size = New Size(1140, 553)
        dgvUsersWithAccount.TabIndex = 1
        ' 
        ' tpWithoutAccount
        ' 
        tpWithoutAccount.Controls.Add(dgvUsersWithoutAccount)
        tpWithoutAccount.Location = New Point(4, 29)
        tpWithoutAccount.Margin = New Padding(3, 4, 3, 4)
        tpWithoutAccount.Name = "tpWithoutAccount"
        tpWithoutAccount.Padding = New Padding(3, 4, 3, 4)
        tpWithoutAccount.Size = New Size(1146, 561)
        tpWithoutAccount.TabIndex = 1
        tpWithoutAccount.Text = "Without Account"
        tpWithoutAccount.UseVisualStyleBackColor = True
        ' 
        ' dgvUsersWithoutAccount
        ' 
        dgvUsersWithoutAccount.AllowUserToAddRows = False
        dgvUsersWithoutAccount.AllowUserToDeleteRows = False
        dgvUsersWithoutAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsersWithoutAccount.BackgroundColor = Color.White
        dgvUsersWithoutAccount.BorderStyle = BorderStyle.None
        dgvUsersWithoutAccount.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvUsersWithoutAccount.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = Color.White
        DataGridViewCellStyle4.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle4.SelectionForeColor = Color.White
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dgvUsersWithoutAccount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgvUsersWithoutAccount.ColumnHeadersHeight = 40
        dgvUsersWithoutAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.White
        DataGridViewCellStyle5.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle5.SelectionForeColor = Color.White
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        dgvUsersWithoutAccount.DefaultCellStyle = DataGridViewCellStyle5
        dgvUsersWithoutAccount.Dock = DockStyle.Fill
        dgvUsersWithoutAccount.EnableHeadersVisualStyles = False
        dgvUsersWithoutAccount.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvUsersWithoutAccount.Location = New Point(3, 4)
        dgvUsersWithoutAccount.Margin = New Padding(3, 4, 3, 4)
        dgvUsersWithoutAccount.MultiSelect = False
        dgvUsersWithoutAccount.Name = "dgvUsersWithoutAccount"
        dgvUsersWithoutAccount.ReadOnly = True
        dgvUsersWithoutAccount.RowHeadersVisible = False
        dgvUsersWithoutAccount.RowHeadersWidth = 51
        DataGridViewCellStyle6.Padding = New Padding(10, 0, 0, 0)
        dgvUsersWithoutAccount.RowsDefaultCellStyle = DataGridViewCellStyle6
        dgvUsersWithoutAccount.RowTemplate.Height = 45
        dgvUsersWithoutAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsersWithoutAccount.Size = New Size(1140, 553)
        dgvUsersWithoutAccount.TabIndex = 2
        ' 
        ' pnlUserControls
        ' 
        pnlUserControls.Controls.Add(btnDeleteUser)
        pnlUserControls.Controls.Add(btnEditUser)
        pnlUserControls.Controls.Add(btnAddUser)
        pnlUserControls.Controls.Add(txtSearchUsers)
        pnlUserControls.Controls.Add(lblSearchUsers)
        pnlUserControls.Dock = DockStyle.Top
        pnlUserControls.Location = New Point(0, 80)
        pnlUserControls.Margin = New Padding(3, 4, 3, 4)
        pnlUserControls.Name = "pnlUserControls"
        pnlUserControls.Padding = New Padding(0, 13, 0, 13)
        pnlUserControls.Size = New Size(1154, 80)
        pnlUserControls.TabIndex = 8
        ' 
        ' btnDeleteUser
        ' 
        btnDeleteUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteUser.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDeleteUser.Cursor = Cursors.Hand
        btnDeleteUser.FlatAppearance.BorderSize = 0
        btnDeleteUser.FlatStyle = FlatStyle.Flat
        btnDeleteUser.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnDeleteUser.ForeColor = Color.White
        btnDeleteUser.Location = New Point(1006, 16)
        btnDeleteUser.Margin = New Padding(3, 4, 3, 4)
        btnDeleteUser.Name = "btnDeleteUser"
        btnDeleteUser.Size = New Size(149, 48)
        btnDeleteUser.TabIndex = 4
        btnDeleteUser.Text = "🗑️ Delete"
        btnDeleteUser.UseVisualStyleBackColor = False
        ' 
        ' btnEditUser
        ' 
        btnEditUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEditUser.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnEditUser.Cursor = Cursors.Hand
        btnEditUser.FlatAppearance.BorderSize = 0
        btnEditUser.FlatStyle = FlatStyle.Flat
        btnEditUser.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnEditUser.ForeColor = Color.White
        btnEditUser.Location = New Point(846, 16)
        btnEditUser.Margin = New Padding(3, 4, 3, 4)
        btnEditUser.Name = "btnEditUser"
        btnEditUser.Size = New Size(149, 48)
        btnEditUser.TabIndex = 3
        btnEditUser.Text = "✏️ Edit"
        btnEditUser.UseVisualStyleBackColor = False
        ' 
        ' btnAddUser
        ' 
        btnAddUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddUser.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAddUser.Cursor = Cursors.Hand
        btnAddUser.FlatAppearance.BorderSize = 0
        btnAddUser.FlatStyle = FlatStyle.Flat
        btnAddUser.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnAddUser.ForeColor = Color.White
        btnAddUser.Location = New Point(971, 16)
        btnAddUser.Margin = New Padding(3, 4, 3, 4)
        btnAddUser.Name = "btnAddUser"
        btnAddUser.Size = New Size(171, 48)
        btnAddUser.TabIndex = 2
        btnAddUser.Text = "➕ Create Account"
        btnAddUser.UseVisualStyleBackColor = False
        ' 
        ' txtSearchUsers
        ' 
        txtSearchUsers.Font = New Font("Poppins", 9.0F)
        txtSearchUsers.Location = New Point(91, 21)
        txtSearchUsers.Margin = New Padding(3, 4, 3, 4)
        txtSearchUsers.Name = "txtSearchUsers"
        txtSearchUsers.PlaceholderText = "Search users..."
        txtSearchUsers.Size = New Size(285, 30)
        txtSearchUsers.TabIndex = 6
        ' 
        ' lblSearchUsers
        ' 
        lblSearchUsers.AutoSize = True
        lblSearchUsers.Font = New Font("Poppins", 9.0F)
        lblSearchUsers.Location = New Point(11, 25)
        lblSearchUsers.Name = "lblSearchUsers"
        lblSearchUsers.Size = New Size(68, 26)
        lblSearchUsers.TabIndex = 7
        lblSearchUsers.Text = "Search:"
        ' 
        ' pnlUserHeader
        ' 
        pnlUserHeader.Controls.Add(lblUsersTotal)
        pnlUserHeader.Controls.Add(lblUserManagement)
        pnlUserHeader.Dock = DockStyle.Top
        pnlUserHeader.Location = New Point(0, 0)
        pnlUserHeader.Margin = New Padding(3, 4, 3, 4)
        pnlUserHeader.Name = "pnlUserHeader"
        pnlUserHeader.Padding = New Padding(0, 0, 0, 13)
        pnlUserHeader.Size = New Size(1154, 80)
        pnlUserHeader.TabIndex = 7
        ' 
        ' lblUsersTotal
        ' 
        lblUsersTotal.AutoSize = True
        lblUsersTotal.Font = New Font("Poppins", 11.0F)
        lblUsersTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblUsersTotal.Location = New Point(297, 20)
        lblUsersTotal.Name = "lblUsersTotal"
        lblUsersTotal.Size = New Size(101, 34)
        lblUsersTotal.TabIndex = 5
        lblUsersTotal.Text = "(Total: 0)"
        ' 
        ' lblUserManagement
        ' 
        lblUserManagement.AutoSize = True
        lblUserManagement.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblUserManagement.Location = New Point(6, 11)
        lblUserManagement.Name = "lblUserManagement"
        lblUserManagement.Size = New Size(306, 53)
        lblUserManagement.TabIndex = 0
        lblUserManagement.Text = "User Management"
        ' 
        ' pnlQueueLogs
        ' 
        pnlQueueLogs.Controls.Add(dgvQueueLogs)
        pnlQueueLogs.Controls.Add(pnlQueueLogsControls)
        pnlQueueLogs.Controls.Add(pnlQueueLogsHeader)
        pnlQueueLogs.Dock = DockStyle.Fill
        pnlQueueLogs.Location = New Point(29, 33)
        pnlQueueLogs.Margin = New Padding(3, 4, 3, 4)
        pnlQueueLogs.Name = "pnlQueueLogs"
        pnlQueueLogs.Size = New Size(1154, 754)
        pnlQueueLogs.TabIndex = 8
        ' 
        ' dgvQueueLogs
        ' 
        dgvQueueLogs.AllowUserToAddRows = False
        dgvQueueLogs.AllowUserToDeleteRows = False
        dgvQueueLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvQueueLogs.BackgroundColor = Color.White
        dgvQueueLogs.BorderStyle = BorderStyle.None
        dgvQueueLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvQueueLogs.Dock = DockStyle.Fill
        dgvQueueLogs.Location = New Point(0, 160)
        dgvQueueLogs.Margin = New Padding(3, 4, 3, 4)
        dgvQueueLogs.Name = "dgvQueueLogs"
        dgvQueueLogs.ReadOnly = True
        dgvQueueLogs.RowHeadersWidth = 51
        dgvQueueLogs.RowTemplate.Height = 35
        dgvQueueLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvQueueLogs.Size = New Size(1154, 594)
        dgvQueueLogs.TabIndex = 2
        ' 
        ' pnlQueueLogsControls
        ' 
        pnlQueueLogsControls.Controls.Add(btnChangeStatus)
        pnlQueueLogsControls.Controls.Add(cboSortQueueLogs)
        pnlQueueLogsControls.Controls.Add(lblSortQueueLogs)
        pnlQueueLogsControls.Controls.Add(txtSearchQueueLogs)
        pnlQueueLogsControls.Controls.Add(lblSearchQueueLogs)
        pnlQueueLogsControls.Dock = DockStyle.Top
        pnlQueueLogsControls.Location = New Point(0, 80)
        pnlQueueLogsControls.Margin = New Padding(3, 4, 3, 4)
        pnlQueueLogsControls.Name = "pnlQueueLogsControls"
        pnlQueueLogsControls.Padding = New Padding(0, 13, 0, 13)
        pnlQueueLogsControls.Size = New Size(1154, 80)
        pnlQueueLogsControls.TabIndex = 11
        ' 
        ' btnChangeStatus
        ' 
        btnChangeStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnChangeStatus.BackColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        btnChangeStatus.Cursor = Cursors.Hand
        btnChangeStatus.FlatAppearance.BorderSize = 0
        btnChangeStatus.FlatStyle = FlatStyle.Flat
        btnChangeStatus.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnChangeStatus.ForeColor = Color.White
        btnChangeStatus.Location = New Point(971, 16)
        btnChangeStatus.Margin = New Padding(3, 4, 3, 4)
        btnChangeStatus.Name = "btnChangeStatus"
        btnChangeStatus.Size = New Size(183, 48)
        btnChangeStatus.TabIndex = 5
        btnChangeStatus.Text = "✏️ Change Status"
        btnChangeStatus.UseVisualStyleBackColor = False
        ' 
        ' cboSortQueueLogs
        ' 
        cboSortQueueLogs.DropDownStyle = ComboBoxStyle.DropDownList
        cboSortQueueLogs.Font = New Font("Poppins", 9.0F)
        cboSortQueueLogs.FormattingEnabled = True
        cboSortQueueLogs.Location = New Point(91, 21)
        cboSortQueueLogs.Margin = New Padding(3, 4, 3, 4)
        cboSortQueueLogs.Name = "cboSortQueueLogs"
        cboSortQueueLogs.Size = New Size(228, 34)
        cboSortQueueLogs.TabIndex = 10
        ' 
        ' lblSortQueueLogs
        ' 
        lblSortQueueLogs.AutoSize = True
        lblSortQueueLogs.Font = New Font("Poppins", 9.0F)
        lblSortQueueLogs.Location = New Point(11, 25)
        lblSortQueueLogs.Name = "lblSortQueueLogs"
        lblSortQueueLogs.Size = New Size(67, 26)
        lblSortQueueLogs.TabIndex = 9
        lblSortQueueLogs.Text = "Sort by:"
        ' 
        ' txtSearchQueueLogs
        ' 
        txtSearchQueueLogs.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtSearchQueueLogs.Font = New Font("Poppins", 9.0F)
        txtSearchQueueLogs.Location = New Point(726, 21)
        txtSearchQueueLogs.Margin = New Padding(3, 4, 3, 4)
        txtSearchQueueLogs.Name = "txtSearchQueueLogs"
        txtSearchQueueLogs.PlaceholderText = "Search queues..."
        txtSearchQueueLogs.Size = New Size(228, 30)
        txtSearchQueueLogs.TabIndex = 7
        ' 
        ' lblSearchQueueLogs
        ' 
        lblSearchQueueLogs.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSearchQueueLogs.AutoSize = True
        lblSearchQueueLogs.Font = New Font("Poppins", 9.0F)
        lblSearchQueueLogs.Location = New Point(640, 25)
        lblSearchQueueLogs.Name = "lblSearchQueueLogs"
        lblSearchQueueLogs.Size = New Size(94, 26)
        lblSearchQueueLogs.TabIndex = 8
        lblSearchQueueLogs.Text = "🔍 Search:"
        ' 
        ' pnlQueueLogsHeader
        ' 
        pnlQueueLogsHeader.Controls.Add(lblQueueLogsTotal)
        pnlQueueLogsHeader.Controls.Add(lblQueueLogs)
        pnlQueueLogsHeader.Dock = DockStyle.Top
        pnlQueueLogsHeader.Location = New Point(0, 0)
        pnlQueueLogsHeader.Margin = New Padding(3, 4, 3, 4)
        pnlQueueLogsHeader.Name = "pnlQueueLogsHeader"
        pnlQueueLogsHeader.Padding = New Padding(0, 0, 0, 13)
        pnlQueueLogsHeader.Size = New Size(1154, 80)
        pnlQueueLogsHeader.TabIndex = 10
        ' 
        ' lblQueueLogsTotal
        ' 
        lblQueueLogsTotal.AutoSize = True
        lblQueueLogsTotal.Font = New Font("Poppins", 11.0F)
        lblQueueLogsTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblQueueLogsTotal.Location = New Point(211, 20)
        lblQueueLogsTotal.Name = "lblQueueLogsTotal"
        lblQueueLogsTotal.Size = New Size(101, 34)
        lblQueueLogsTotal.TabIndex = 6
        lblQueueLogsTotal.Text = "(Total: 0)"
        ' 
        ' lblQueueLogs
        ' 
        lblQueueLogs.AutoSize = True
        lblQueueLogs.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblQueueLogs.Location = New Point(6, 11)
        lblQueueLogs.Name = "lblQueueLogs"
        lblQueueLogs.Size = New Size(199, 53)
        lblQueueLogs.TabIndex = 1
        lblQueueLogs.Text = "Queue Logs"
        ' 
        ' pnlReports
        ' 
        pnlReports.Controls.Add(tabReports)
        pnlReports.Controls.Add(lblReports)
        pnlReports.Dock = DockStyle.Fill
        pnlReports.Location = New Point(29, 33)
        pnlReports.Margin = New Padding(3, 4, 3, 4)
        pnlReports.Name = "pnlReports"
        pnlReports.Size = New Size(1154, 754)
        pnlReports.TabIndex = 7
        ' 
        ' tabReports
        ' 
        tabReports.Controls.Add(tpQueueLogsReport)
        tabReports.Dock = DockStyle.Fill
        tabReports.Font = New Font("Poppins", 9.0F)
        tabReports.Location = New Point(0, 64)
        tabReports.Margin = New Padding(3, 4, 3, 4)
        tabReports.Name = "tabReports"
        tabReports.SelectedIndex = 0
        tabReports.Size = New Size(1154, 690)
        tabReports.TabIndex = 2
        ' 
        ' tpQueueLogsReport
        ' 
        tpQueueLogsReport.Controls.Add(pnlQueueLogsReport)
        tpQueueLogsReport.Location = New Point(4, 35)
        tpQueueLogsReport.Margin = New Padding(3, 4, 3, 4)
        tpQueueLogsReport.Name = "tpQueueLogsReport"
        tpQueueLogsReport.Padding = New Padding(3, 4, 3, 4)
        tpQueueLogsReport.Size = New Size(1146, 651)
        tpQueueLogsReport.TabIndex = 0
        tpQueueLogsReport.Text = "Queue Logs Report"
        tpQueueLogsReport.UseVisualStyleBackColor = True
        ' 
        ' pnlQueueLogsReport
        ' 
        pnlQueueLogsReport.Controls.Add(dgvReports)
        pnlQueueLogsReport.Controls.Add(pnlReportControls)
        pnlQueueLogsReport.Dock = DockStyle.Fill
        pnlQueueLogsReport.Location = New Point(3, 4)
        pnlQueueLogsReport.Margin = New Padding(3, 4, 3, 4)
        pnlQueueLogsReport.Name = "pnlQueueLogsReport"
        pnlQueueLogsReport.Size = New Size(1140, 643)
        pnlQueueLogsReport.TabIndex = 0
        ' 
        ' dgvReports
        ' 
        dgvReports.AllowUserToAddRows = False
        dgvReports.AllowUserToDeleteRows = False
        dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReports.BackgroundColor = Color.White
        dgvReports.BorderStyle = BorderStyle.None
        dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReports.Dock = DockStyle.Fill
        dgvReports.Location = New Point(0, 107)
        dgvReports.Margin = New Padding(3, 4, 3, 4)
        dgvReports.Name = "dgvReports"
        dgvReports.ReadOnly = True
        dgvReports.RowHeadersWidth = 51
        dgvReports.RowTemplate.Height = 35
        dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReports.Size = New Size(1140, 536)
        dgvReports.TabIndex = 7
        ' 
        ' pnlReportControls
        ' 
        pnlReportControls.Controls.Add(lblReportTotal)
        pnlReportControls.Controls.Add(btnGenerateReport)
        pnlReportControls.Controls.Add(dtpEndDate)
        pnlReportControls.Controls.Add(lblEndDate)
        pnlReportControls.Controls.Add(dtpStartDate)
        pnlReportControls.Controls.Add(lblStartDate)
        pnlReportControls.Controls.Add(cboReportType)
        pnlReportControls.Controls.Add(lblReportType)
        pnlReportControls.Dock = DockStyle.Top
        pnlReportControls.Location = New Point(0, 0)
        pnlReportControls.Margin = New Padding(3, 4, 3, 4)
        pnlReportControls.Name = "pnlReportControls"
        pnlReportControls.Padding = New Padding(11, 13, 11, 13)
        pnlReportControls.Size = New Size(1140, 107)
        pnlReportControls.TabIndex = 9
        ' 
        ' lblReportTotal
        ' 
        lblReportTotal.AutoSize = True
        lblReportTotal.Font = New Font("Poppins", 9.0F)
        lblReportTotal.Location = New Point(15, 64)
        lblReportTotal.Name = "lblReportTotal"
        lblReportTotal.Size = New Size(130, 26)
        lblReportTotal.TabIndex = 8
        lblReportTotal.Text = "Total Records: 0"
        ' 
        ' btnGenerateReport
        ' 
        btnGenerateReport.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnGenerateReport.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnGenerateReport.Cursor = Cursors.Hand
        btnGenerateReport.FlatAppearance.BorderSize = 0
        btnGenerateReport.FlatStyle = FlatStyle.Flat
        btnGenerateReport.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnGenerateReport.ForeColor = Color.White
        btnGenerateReport.Location = New Point(940, 20)
        btnGenerateReport.Margin = New Padding(3, 4, 3, 4)
        btnGenerateReport.Name = "btnGenerateReport"
        btnGenerateReport.Size = New Size(189, 48)
        btnGenerateReport.TabIndex = 6
        btnGenerateReport.Text = "📊 Generate Report"
        btnGenerateReport.UseVisualStyleBackColor = False
        ' 
        ' dtpEndDate
        ' 
        dtpEndDate.Font = New Font("Poppins", 9.0F)
        dtpEndDate.Location = New Point(693, 24)
        dtpEndDate.Margin = New Padding(3, 4, 3, 4)
        dtpEndDate.Name = "dtpEndDate"
        dtpEndDate.Size = New Size(228, 30)
        dtpEndDate.TabIndex = 5
        ' 
        ' lblEndDate
        ' 
        lblEndDate.AutoSize = True
        lblEndDate.Font = New Font("Poppins", 9.0F)
        lblEndDate.Location = New Point(595, 28)
        lblEndDate.Name = "lblEndDate"
        lblEndDate.Size = New Size(82, 26)
        lblEndDate.TabIndex = 4
        lblEndDate.Text = "End Date:"
        ' 
        ' dtpStartDate
        ' 
        dtpStartDate.Font = New Font("Poppins", 9.0F)
        dtpStartDate.Location = New Point(344, 24)
        dtpStartDate.Margin = New Padding(3, 4, 3, 4)
        dtpStartDate.Name = "dtpStartDate"
        dtpStartDate.Size = New Size(228, 30)
        dtpStartDate.TabIndex = 3
        ' 
        ' lblStartDate
        ' 
        lblStartDate.AutoSize = True
        lblStartDate.Font = New Font("Poppins", 9.0F)
        lblStartDate.Location = New Point(241, 28)
        lblStartDate.Name = "lblStartDate"
        lblStartDate.Size = New Size(89, 26)
        lblStartDate.TabIndex = 2
        lblStartDate.Text = "Start Date:"
        ' 
        ' cboReportType
        ' 
        cboReportType.DropDownStyle = ComboBoxStyle.DropDownList
        cboReportType.Font = New Font("Poppins", 9.0F)
        cboReportType.FormattingEnabled = True
        cboReportType.Items.AddRange(New Object() {"Daily", "Weekly", "Monthly", "Annual"})
        cboReportType.Location = New Point(118, 24)
        cboReportType.Margin = New Padding(3, 4, 3, 4)
        cboReportType.Name = "cboReportType"
        cboReportType.Size = New Size(114, 34)
        cboReportType.TabIndex = 1
        ' 
        ' lblReportType
        ' 
        lblReportType.AutoSize = True
        lblReportType.Font = New Font("Poppins", 9.0F)
        lblReportType.Location = New Point(15, 28)
        lblReportType.Name = "lblReportType"
        lblReportType.Size = New Size(103, 26)
        lblReportType.TabIndex = 0
        lblReportType.Text = "Report Type:"
        ' 
        ' lblReports
        ' 
        lblReports.AutoSize = True
        lblReports.Dock = DockStyle.Top
        lblReports.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblReports.Location = New Point(0, 0)
        lblReports.Name = "lblReports"
        lblReports.Padding = New Padding(6, 11, 0, 0)
        lblReports.Size = New Size(148, 64)
        lblReports.TabIndex = 1
        lblReports.Text = "Reports"
        ' 
        ' pnlCounterManagement
        ' 
        pnlCounterManagement.Controls.Add(dgvCounters)
        pnlCounterManagement.Controls.Add(pnlCounterControls)
        pnlCounterManagement.Controls.Add(pnlCounterHeader)
        pnlCounterManagement.Dock = DockStyle.Fill
        pnlCounterManagement.Location = New Point(29, 33)
        pnlCounterManagement.Margin = New Padding(3, 4, 3, 4)
        pnlCounterManagement.Name = "pnlCounterManagement"
        pnlCounterManagement.Size = New Size(1154, 754)
        pnlCounterManagement.TabIndex = 6
        ' 
        ' dgvCounters
        ' 
        dgvCounters.AllowUserToAddRows = False
        dgvCounters.AllowUserToDeleteRows = False
        dgvCounters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCounters.BackgroundColor = Color.White
        dgvCounters.BorderStyle = BorderStyle.None
        dgvCounters.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvCounters.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvCounters.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgvCounters.ColumnHeadersHeight = 40
        dgvCounters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvCounters.DefaultCellStyle = DataGridViewCellStyle5
        dgvCounters.Dock = DockStyle.Fill
        dgvCounters.EnableHeadersVisualStyles = False
        dgvCounters.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvCounters.Location = New Point(0, 160)
        dgvCounters.Margin = New Padding(3, 4, 3, 4)
        dgvCounters.MultiSelect = False
        dgvCounters.Name = "dgvCounters"
        dgvCounters.ReadOnly = True
        dgvCounters.RowHeadersVisible = False
        dgvCounters.RowHeadersWidth = 51
        dgvCounters.RowsDefaultCellStyle = DataGridViewCellStyle6
        dgvCounters.RowTemplate.Height = 45
        dgvCounters.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCounters.Size = New Size(1154, 594)
        dgvCounters.TabIndex = 1
        ' 
        ' pnlCounterControls
        ' 
        pnlCounterControls.Controls.Add(btnDeleteCounter)
        pnlCounterControls.Controls.Add(btnEditCounter)
        pnlCounterControls.Controls.Add(btnAddCounter)
        pnlCounterControls.Dock = DockStyle.Top
        pnlCounterControls.Location = New Point(0, 80)
        pnlCounterControls.Margin = New Padding(3, 4, 3, 4)
        pnlCounterControls.Name = "pnlCounterControls"
        pnlCounterControls.Padding = New Padding(0, 13, 0, 13)
        pnlCounterControls.Size = New Size(1154, 80)
        pnlCounterControls.TabIndex = 7
        ' 
        ' btnDeleteCounter
        ' 
        btnDeleteCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteCounter.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDeleteCounter.Cursor = Cursors.Hand
        btnDeleteCounter.FlatAppearance.BorderSize = 0
        btnDeleteCounter.FlatStyle = FlatStyle.Flat
        btnDeleteCounter.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnDeleteCounter.ForeColor = Color.White
        btnDeleteCounter.Location = New Point(1006, 16)
        btnDeleteCounter.Margin = New Padding(3, 4, 3, 4)
        btnDeleteCounter.Name = "btnDeleteCounter"
        btnDeleteCounter.Size = New Size(149, 48)
        btnDeleteCounter.TabIndex = 4
        btnDeleteCounter.Text = "🗑️ Delete"
        btnDeleteCounter.UseVisualStyleBackColor = False
        ' 
        ' btnEditCounter
        ' 
        btnEditCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEditCounter.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnEditCounter.Cursor = Cursors.Hand
        btnEditCounter.FlatAppearance.BorderSize = 0
        btnEditCounter.FlatStyle = FlatStyle.Flat
        btnEditCounter.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnEditCounter.ForeColor = Color.White
        btnEditCounter.Location = New Point(846, 16)
        btnEditCounter.Margin = New Padding(3, 4, 3, 4)
        btnEditCounter.Name = "btnEditCounter"
        btnEditCounter.Size = New Size(149, 48)
        btnEditCounter.TabIndex = 3
        btnEditCounter.Text = "✏️ Edit"
        btnEditCounter.UseVisualStyleBackColor = False
        ' 
        ' btnAddCounter
        ' 
        btnAddCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddCounter.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAddCounter.Cursor = Cursors.Hand
        btnAddCounter.FlatAppearance.BorderSize = 0
        btnAddCounter.FlatStyle = FlatStyle.Flat
        btnAddCounter.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnAddCounter.ForeColor = Color.White
        btnAddCounter.Location = New Point(663, 16)
        btnAddCounter.Margin = New Padding(3, 4, 3, 4)
        btnAddCounter.Name = "btnAddCounter"
        btnAddCounter.Size = New Size(171, 48)
        btnAddCounter.TabIndex = 2
        btnAddCounter.Text = "➕ Add Counter"
        btnAddCounter.UseVisualStyleBackColor = False
        ' 
        ' pnlCounterHeader
        ' 
        pnlCounterHeader.Controls.Add(lblCountersTotal)
        pnlCounterHeader.Controls.Add(lblCounterManagement)
        pnlCounterHeader.Dock = DockStyle.Top
        pnlCounterHeader.Location = New Point(0, 0)
        pnlCounterHeader.Margin = New Padding(3, 4, 3, 4)
        pnlCounterHeader.Name = "pnlCounterHeader"
        pnlCounterHeader.Padding = New Padding(0, 0, 0, 13)
        pnlCounterHeader.Size = New Size(1154, 80)
        pnlCounterHeader.TabIndex = 6
        ' 
        ' lblCountersTotal
        ' 
        lblCountersTotal.AutoSize = True
        lblCountersTotal.Font = New Font("Poppins", 11.0F)
        lblCountersTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblCountersTotal.Location = New Point(354, 20)
        lblCountersTotal.Name = "lblCountersTotal"
        lblCountersTotal.Size = New Size(132, 34)
        lblCountersTotal.TabIndex = 5
        lblCountersTotal.Text = "(Working: 0)"
        ' 
        ' lblCounterManagement
        ' 
        lblCounterManagement.AutoSize = True
        lblCounterManagement.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblCounterManagement.Location = New Point(6, 11)
        lblCounterManagement.Name = "lblCounterManagement"
        lblCounterManagement.Size = New Size(362, 53)
        lblCounterManagement.TabIndex = 1
        lblCounterManagement.Text = "Counter Management"
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.Controls.Add(pnlQueues)
        pnlDashboard.Controls.Add(pnlCashiers)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(29, 33)
        pnlDashboard.Margin = New Padding(3, 4, 3, 4)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(1154, 754)
        pnlDashboard.TabIndex = 4
        ' 
        ' pnlQueues
        ' 
        pnlQueues.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlQueues.BackColor = Color.White
        pnlQueues.Controls.Add(dgvAllQueues)
        pnlQueues.Controls.Add(pnlQueuesControls)
        pnlQueues.Controls.Add(pnlQueuesHeader)
        pnlQueues.Location = New Point(497, 0)
        pnlQueues.Margin = New Padding(3, 4, 3, 4)
        pnlQueues.Name = "pnlQueues"
        pnlQueues.Size = New Size(657, 754)
        pnlQueues.TabIndex = 3
        ' 
        ' dgvAllQueues
        ' 
        dgvAllQueues.AllowUserToAddRows = False
        dgvAllQueues.AllowUserToDeleteRows = False
        dgvAllQueues.AllowUserToResizeRows = False
        dgvAllQueues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAllQueues.BackgroundColor = Color.White
        dgvAllQueues.BorderStyle = BorderStyle.None
        dgvAllQueues.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvAllQueues.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = Color.White
        DataGridViewCellStyle7.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle7.SelectionForeColor = Color.White
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        dgvAllQueues.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        dgvAllQueues.ColumnHeadersHeight = 40
        dgvAllQueues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = Color.White
        DataGridViewCellStyle8.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle8.SelectionForeColor = Color.White
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
        dgvAllQueues.DefaultCellStyle = DataGridViewCellStyle8
        dgvAllQueues.Dock = DockStyle.Fill
        dgvAllQueues.EnableHeadersVisualStyles = False
        dgvAllQueues.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvAllQueues.Location = New Point(0, 167)
        dgvAllQueues.Margin = New Padding(3, 4, 3, 4)
        dgvAllQueues.MultiSelect = False
        dgvAllQueues.Name = "dgvAllQueues"
        dgvAllQueues.ReadOnly = True
        dgvAllQueues.RowHeadersVisible = False
        dgvAllQueues.RowHeadersWidth = 51
        DataGridViewCellStyle9.Padding = New Padding(10, 0, 0, 0)
        dgvAllQueues.RowsDefaultCellStyle = DataGridViewCellStyle9
        dgvAllQueues.RowTemplate.Height = 45
        dgvAllQueues.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAllQueues.Size = New Size(657, 587)
        dgvAllQueues.TabIndex = 1
        ' 
        ' pnlQueuesControls
        ' 
        pnlQueuesControls.Controls.Add(txtSearchAllQueues)
        pnlQueuesControls.Controls.Add(lblSearchAllQueues)
        pnlQueuesControls.Dock = DockStyle.Top
        pnlQueuesControls.Location = New Point(0, 87)
        pnlQueuesControls.Margin = New Padding(3, 4, 3, 4)
        pnlQueuesControls.Name = "pnlQueuesControls"
        pnlQueuesControls.Padding = New Padding(23, 13, 23, 13)
        pnlQueuesControls.Size = New Size(657, 80)
        pnlQueuesControls.TabIndex = 5
        ' 
        ' txtSearchAllQueues
        ' 
        txtSearchAllQueues.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtSearchAllQueues.Font = New Font("Poppins", 9.0F)
        txtSearchAllQueues.Location = New Point(394, 21)
        txtSearchAllQueues.Margin = New Padding(3, 4, 3, 4)
        txtSearchAllQueues.Name = "txtSearchAllQueues"
        txtSearchAllQueues.PlaceholderText = "Search queues..."
        txtSearchAllQueues.Size = New Size(239, 30)
        txtSearchAllQueues.TabIndex = 3
        ' 
        ' lblSearchAllQueues
        ' 
        lblSearchAllQueues.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSearchAllQueues.AutoSize = True
        lblSearchAllQueues.Font = New Font("Poppins", 9.0F)
        lblSearchAllQueues.Location = New Point(309, 25)
        lblSearchAllQueues.Name = "lblSearchAllQueues"
        lblSearchAllQueues.Size = New Size(94, 26)
        lblSearchAllQueues.TabIndex = 4
        lblSearchAllQueues.Text = "🔍 Search:"
        ' 
        ' pnlQueuesHeader
        ' 
        pnlQueuesHeader.Controls.Add(lblQueueTotal)
        pnlQueuesHeader.Controls.Add(lblQueueTitle)
        pnlQueuesHeader.Dock = DockStyle.Top
        pnlQueuesHeader.Location = New Point(0, 0)
        pnlQueuesHeader.Margin = New Padding(3, 4, 3, 4)
        pnlQueuesHeader.Name = "pnlQueuesHeader"
        pnlQueuesHeader.Padding = New Padding(23, 20, 23, 7)
        pnlQueuesHeader.Size = New Size(657, 87)
        pnlQueuesHeader.TabIndex = 0
        ' 
        ' lblQueueTotal
        ' 
        lblQueueTotal.AutoSize = True
        lblQueueTotal.Font = New Font("Poppins", 10.0F)
        lblQueueTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblQueueTotal.Location = New Point(263, 27)
        lblQueueTotal.Name = "lblQueueTotal"
        lblQueueTotal.Size = New Size(90, 30)
        lblQueueTotal.TabIndex = 2
        lblQueueTotal.Text = "(Total: 0)"
        ' 
        ' lblQueueTitle
        ' 
        lblQueueTitle.AutoSize = True
        lblQueueTitle.Font = New Font("Poppins", 14.25F, FontStyle.Bold)
        lblQueueTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblQueueTitle.Location = New Point(23, 20)
        lblQueueTitle.Name = "lblQueueTitle"
        lblQueueTitle.Size = New Size(254, 42)
        lblQueueTitle.TabIndex = 0
        lblQueueTitle.Text = "Live Queue Activity"
        ' 
        ' pnlCashiers
        ' 
        pnlCashiers.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        pnlCashiers.BackColor = Color.White
        pnlCashiers.Controls.Add(dgvCashierStatus)
        pnlCashiers.Controls.Add(pnlCashiersHeader)
        pnlCashiers.Location = New Point(0, 0)
        pnlCashiers.Margin = New Padding(3, 4, 3, 4)
        pnlCashiers.Name = "pnlCashiers"
        pnlCashiers.Size = New Size(480, 754)
        pnlCashiers.TabIndex = 2
        ' 
        ' dgvCashierStatus
        ' 
        dgvCashierStatus.AllowUserToAddRows = False
        dgvCashierStatus.AllowUserToDeleteRows = False
        dgvCashierStatus.AllowUserToResizeRows = False
        dgvCashierStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCashierStatus.BackgroundColor = Color.White
        dgvCashierStatus.BorderStyle = BorderStyle.None
        dgvCashierStatus.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvCashierStatus.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = Color.White
        DataGridViewCellStyle10.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle10.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle10.SelectionForeColor = Color.White
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.True
        dgvCashierStatus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        dgvCashierStatus.ColumnHeadersHeight = 40
        dgvCashierStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = Color.White
        DataGridViewCellStyle11.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle11.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle11.SelectionForeColor = Color.White
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.False
        dgvCashierStatus.DefaultCellStyle = DataGridViewCellStyle11
        dgvCashierStatus.Dock = DockStyle.Fill
        dgvCashierStatus.EnableHeadersVisualStyles = False
        dgvCashierStatus.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvCashierStatus.Location = New Point(0, 87)
        dgvCashierStatus.Margin = New Padding(3, 4, 3, 4)
        dgvCashierStatus.MultiSelect = False
        dgvCashierStatus.Name = "dgvCashierStatus"
        dgvCashierStatus.ReadOnly = True
        dgvCashierStatus.RowHeadersVisible = False
        dgvCashierStatus.RowHeadersWidth = 51
        DataGridViewCellStyle12.Padding = New Padding(10, 0, 0, 0)
        dgvCashierStatus.RowsDefaultCellStyle = DataGridViewCellStyle12
        dgvCashierStatus.RowTemplate.Height = 45
        dgvCashierStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCashierStatus.Size = New Size(480, 667)
        dgvCashierStatus.TabIndex = 1
        ' 
        ' pnlCashiersHeader
        ' 
        pnlCashiersHeader.Controls.Add(lblActiveCashiers)
        pnlCashiersHeader.Controls.Add(lblCashierTitle)
        pnlCashiersHeader.Dock = DockStyle.Top
        pnlCashiersHeader.Location = New Point(0, 0)
        pnlCashiersHeader.Margin = New Padding(3, 4, 3, 4)
        pnlCashiersHeader.Name = "pnlCashiersHeader"
        pnlCashiersHeader.Padding = New Padding(23, 20, 23, 7)
        pnlCashiersHeader.Size = New Size(480, 87)
        pnlCashiersHeader.TabIndex = 0
        ' 
        ' lblActiveCashiers
        ' 
        lblActiveCashiers.AutoSize = True
        lblActiveCashiers.Font = New Font("Poppins", 10.0F)
        lblActiveCashiers.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblActiveCashiers.Location = New Point(214, 27)
        lblActiveCashiers.Name = "lblActiveCashiers"
        lblActiveCashiers.Size = New Size(101, 30)
        lblActiveCashiers.TabIndex = 2
        lblActiveCashiers.Text = "(Active: 0)"
        ' 
        ' lblCashierTitle
        ' 
        lblCashierTitle.AutoSize = True
        lblCashierTitle.Font = New Font("Poppins", 14.25F, FontStyle.Bold)
        lblCashierTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblCashierTitle.Location = New Point(23, 20)
        lblCashierTitle.Name = "lblCashierTitle"
        lblCashierTitle.Size = New Size(198, 42)
        lblCashierTitle.TabIndex = 0
        lblCashierTitle.Text = "Cashier Status"
        ' 
        ' tmrRefresh
        ' 
        tmrRefresh.Enabled = True
        tmrRefresh.Interval = 5000
        ' 
        ' frmAdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(1463, 933)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Controls.Add(pnlHeader)
        Margin = New Padding(3, 4, 3, 4)
        MinimumSize = New Size(1168, 851)
        Name = "frmAdminDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LOA EASE - Admin Dashboard"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlUserManagement.ResumeLayout(False)
        tabUserManagement.ResumeLayout(False)
        tpWithAccount.ResumeLayout(False)
        CType(dgvUsersWithAccount, ComponentModel.ISupportInitialize).EndInit()
        tpWithoutAccount.ResumeLayout(False)
        CType(dgvUsersWithoutAccount, ComponentModel.ISupportInitialize).EndInit()
        pnlUserControls.ResumeLayout(False)
        pnlUserControls.PerformLayout()
        pnlUserHeader.ResumeLayout(False)
        pnlUserHeader.PerformLayout()
        pnlQueueLogs.ResumeLayout(False)
        CType(dgvQueueLogs, ComponentModel.ISupportInitialize).EndInit()
        pnlQueueLogsControls.ResumeLayout(False)
        pnlQueueLogsControls.PerformLayout()
        pnlQueueLogsHeader.ResumeLayout(False)
        pnlQueueLogsHeader.PerformLayout()
        pnlReports.ResumeLayout(False)
        pnlReports.PerformLayout()
        tabReports.ResumeLayout(False)
        tpQueueLogsReport.ResumeLayout(False)
        pnlQueueLogsReport.ResumeLayout(False)
        CType(dgvReports, ComponentModel.ISupportInitialize).EndInit()
        pnlReportControls.ResumeLayout(False)
        pnlReportControls.PerformLayout()
        pnlCounterManagement.ResumeLayout(False)
        CType(dgvCounters, ComponentModel.ISupportInitialize).EndInit()
        pnlCounterControls.ResumeLayout(False)
        pnlCounterHeader.ResumeLayout(False)
        pnlCounterHeader.PerformLayout()
        pnlDashboard.ResumeLayout(False)
        pnlQueues.ResumeLayout(False)
        CType(dgvAllQueues, ComponentModel.ISupportInitialize).EndInit()
        pnlQueuesControls.ResumeLayout(False)
        pnlQueuesControls.PerformLayout()
        pnlQueuesHeader.ResumeLayout(False)
        pnlQueuesHeader.PerformLayout()
        pnlCashiers.ResumeLayout(False)
        CType(dgvCashierStatus, ComponentModel.ISupportInitialize).EndInit()
        pnlCashiersHeader.ResumeLayout(False)
        pnlCashiersHeader.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnUserManagement As Button
    Friend WithEvents btnCounterManagement As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnQueueLogs As Button
    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents pnlQueues As Panel
    Friend WithEvents dgvAllQueues As DataGridView
    Friend WithEvents pnlQueuesHeader As Panel
    Friend WithEvents lblQueueTitle As Label
    Friend WithEvents lblQueueTotal As Label
    Friend WithEvents pnlCashiers As Panel
    Friend WithEvents dgvCashierStatus As DataGridView
    Friend WithEvents pnlCashiersHeader As Panel
    Friend WithEvents lblCashierTitle As Label
    Friend WithEvents lblActiveCashiers As Label
    Friend WithEvents pnlUserManagement As Panel
    Friend WithEvents lblUserManagement As Label
    Friend WithEvents btnAddUser As Button
    Friend WithEvents btnEditUser As Button
    Friend WithEvents btnDeleteUser As Button
    Friend WithEvents lblUsersTotal As Label
    Friend WithEvents pnlCounterManagement As Panel
    Friend WithEvents dgvCounters As DataGridView
    Friend WithEvents btnAddCounter As Button
    Friend WithEvents btnEditCounter As Button
    Friend WithEvents btnDeleteCounter As Button
    Friend WithEvents lblCounterManagement As Label
    Friend WithEvents lblCountersTotal As Label
    Friend WithEvents pnlReports As Panel
    Friend WithEvents lblReports As Label
    Friend WithEvents tabReports As TabControl
    Friend WithEvents tpQueueLogsReport As TabPage
    Friend WithEvents pnlQueueLogsReport As Panel
    Friend WithEvents dgvReports As DataGridView
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents lblEndDate As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblStartDate As Label
    Friend WithEvents cboReportType As ComboBox
    Friend WithEvents lblReportType As Label
    Friend WithEvents lblReportTotal As Label
    Friend WithEvents pnlQueueLogs As Panel
    Friend WithEvents dgvQueueLogs As DataGridView
    Friend WithEvents lblQueueLogs As Label
    Friend WithEvents btnChangeStatus As Button
    Friend WithEvents lblQueueLogsTotal As Label
    Friend WithEvents tmrRefresh As Timer
    Friend WithEvents txtSearchAllQueues As TextBox
    Friend WithEvents lblSearchAllQueues As Label
    Friend WithEvents txtSearchUsers As TextBox
    Friend WithEvents lblSearchUsers As Label
    Friend WithEvents txtSearchQueueLogs As TextBox
    Friend WithEvents lblSearchQueueLogs As Label
    Friend WithEvents cboSortQueueLogs As ComboBox
    Friend WithEvents lblSortQueueLogs As Label
    Friend WithEvents pnlQueueLogsHeader As Panel
    Friend WithEvents pnlQueueLogsControls As Panel
    Friend WithEvents pnlUserHeader As Panel
    Friend WithEvents pnlUserControls As Panel
    Friend WithEvents pnlCounterHeader As Panel
    Friend WithEvents pnlCounterControls As Panel
    Friend WithEvents pnlReportControls As Panel
    Friend WithEvents pnlQueuesControls As Panel
    Friend WithEvents tabUserManagement As TabControl
    Friend WithEvents tpWithAccount As TabPage
    Friend WithEvents dgvUsersWithAccount As DataGridView
    Friend WithEvents tpWithoutAccount As TabPage
    Friend WithEvents dgvUsersWithoutAccount As DataGridView
End Class