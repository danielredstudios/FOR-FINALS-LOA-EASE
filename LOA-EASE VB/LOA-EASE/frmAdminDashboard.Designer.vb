<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdminDashboard
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

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
        pnlQueueLogs = New Panel()
        lblQueueLogsTotal = New Label()
        btnChangeStatus = New Button()
        dgvQueueLogs = New DataGridView()
        lblQueueLogs = New Label()
        pnlReports = New Panel()
        lblReports = New Label()
        pnlCounterManagement = New Panel()
        lblCountersTotal = New Label()
        btnDeleteCounter = New Button()
        btnEditCounter = New Button()
        btnAddCounter = New Button()
        dgvCounters = New DataGridView()
        lblCounterManagement = New Label()
        pnlUserManagement = New Panel()
        lblUsersTotal = New Label()
        btnDeleteUser = New Button()
        btnEditUser = New Button()
        btnAddUser = New Button()
        dgvUsers = New DataGridView()
        lblUserManagement = New Label()
        pnlDashboard = New Panel()
        pnlQueues = New Panel()
        lblQueueTotal = New Label()
        dgvAllQueues = New DataGridView()
        pnlQueuesHeader = New Panel()
        lblQueueTitle = New Label()
        pnlCashiers = New Panel()
        lblActiveCashiers = New Label()
        dgvCashierStatus = New DataGridView()
        pnlCashiersHeader = New Panel()
        lblCashierTitle = New Label()
        tmrRefresh = New Timer(components)
        tabReports = New TabControl()
        tpQueueLogsReport = New TabPage()
        pnlQueueLogsReport = New Panel()
        lblReportType = New Label()
        cboReportType = New ComboBox()
        lblStartDate = New Label()
        dtpStartDate = New DateTimePicker()
        lblEndDate = New Label()
        dtpEndDate = New DateTimePicker()
        btnGenerateReport = New Button()
        dgvReports = New DataGridView()
        lblReportTotal = New Label()
        pnlHeader.SuspendLayout()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlQueueLogs.SuspendLayout()
        CType(dgvQueueLogs, ComponentModel.ISupportInitialize).BeginInit()
        pnlReports.SuspendLayout()
        pnlCounterManagement.SuspendLayout()
        CType(dgvCounters, ComponentModel.ISupportInitialize).BeginInit()
        pnlUserManagement.SuspendLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        pnlDashboard.SuspendLayout()
        pnlQueues.SuspendLayout()
        CType(dgvAllQueues, ComponentModel.ISupportInitialize).BeginInit()
        pnlQueuesHeader.SuspendLayout()
        pnlCashiers.SuspendLayout()
        CType(dgvCashierStatus, ComponentModel.ISupportInitialize).BeginInit()
        pnlCashiersHeader.SuspendLayout()
        tpQueueLogsReport.SuspendLayout()
        pnlQueueLogsReport.SuspendLayout()
        CType(dgvReports, ComponentModel.ISupportInitialize).BeginInit()
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
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1264, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Poppins", 9.75F)
        lblWelcome.ForeColor = Color.WhiteSmoke
        lblWelcome.Location = New Point(27, 43)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(74, 23)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome,"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Poppins SemiBold", 14.25F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(24, 12)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(304, 34)
        lblTitle.TabIndex = 0
        lblTitle.Text = "LOA EASE - Admin Dashboard"
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(1122, 22)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(120, 36)
        btnLogout.TabIndex = 2
        btnLogout.Text = "Log Out"
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
        pnlSidebar.Location = New Point(0, 80)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(200, 601)
        pnlSidebar.TabIndex = 1
        ' 
        ' btnQueueLogs
        ' 
        btnQueueLogs.Dock = DockStyle.Top
        btnQueueLogs.FlatAppearance.BorderSize = 0
        btnQueueLogs.FlatStyle = FlatStyle.Flat
        btnQueueLogs.Font = New Font("Poppins", 11.25F, FontStyle.Bold)
        btnQueueLogs.ForeColor = Color.White
        btnQueueLogs.Location = New Point(0, 200)
        btnQueueLogs.Name = "btnQueueLogs"
        btnQueueLogs.Padding = New Padding(20, 0, 0, 0)
        btnQueueLogs.Size = New Size(200, 50)
        btnQueueLogs.TabIndex = 4
        btnQueueLogs.Text = "Queue Logs"
        btnQueueLogs.TextAlign = ContentAlignment.MiddleLeft
        btnQueueLogs.UseVisualStyleBackColor = True
        ' 
        ' btnReports
        ' 
        btnReports.Dock = DockStyle.Top
        btnReports.FlatAppearance.BorderSize = 0
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Poppins", 11.25F, FontStyle.Bold)
        btnReports.ForeColor = Color.White
        btnReports.Location = New Point(0, 150)
        btnReports.Name = "btnReports"
        btnReports.Padding = New Padding(20, 0, 0, 0)
        btnReports.Size = New Size(200, 50)
        btnReports.TabIndex = 3
        btnReports.Text = "Reports"
        btnReports.TextAlign = ContentAlignment.MiddleLeft
        btnReports.UseVisualStyleBackColor = True
        ' 
        ' btnCounterManagement
        ' 
        btnCounterManagement.Dock = DockStyle.Top
        btnCounterManagement.FlatAppearance.BorderSize = 0
        btnCounterManagement.FlatStyle = FlatStyle.Flat
        btnCounterManagement.Font = New Font("Poppins", 11.25F, FontStyle.Bold)
        btnCounterManagement.ForeColor = Color.White
        btnCounterManagement.Location = New Point(0, 100)
        btnCounterManagement.Name = "btnCounterManagement"
        btnCounterManagement.Padding = New Padding(20, 0, 0, 0)
        btnCounterManagement.Size = New Size(200, 50)
        btnCounterManagement.TabIndex = 2
        btnCounterManagement.Text = "Counter Management"
        btnCounterManagement.TextAlign = ContentAlignment.MiddleLeft
        btnCounterManagement.UseVisualStyleBackColor = True
        ' 
        ' btnUserManagement
        ' 
        btnUserManagement.Dock = DockStyle.Top
        btnUserManagement.FlatAppearance.BorderSize = 0
        btnUserManagement.FlatStyle = FlatStyle.Flat
        btnUserManagement.Font = New Font("Poppins", 11.25F, FontStyle.Bold)
        btnUserManagement.ForeColor = Color.White
        btnUserManagement.Location = New Point(0, 50)
        btnUserManagement.Name = "btnUserManagement"
        btnUserManagement.Padding = New Padding(20, 0, 0, 0)
        btnUserManagement.Size = New Size(200, 50)
        btnUserManagement.TabIndex = 1
        btnUserManagement.Text = "User Management"
        btnUserManagement.TextAlign = ContentAlignment.MiddleLeft
        btnUserManagement.UseVisualStyleBackColor = True
        ' 
        ' btnDashboard
        ' 
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Poppins", 11.25F, FontStyle.Bold)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(0, 0)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(20, 0, 0, 0)
        btnDashboard.Size = New Size(200, 50)
        btnDashboard.TabIndex = 0
        btnDashboard.Text = "Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = True
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.Controls.Add(pnlQueueLogs)
        pnlMainContent.Controls.Add(pnlReports)
        pnlMainContent.Controls.Add(pnlCounterManagement)
        pnlMainContent.Controls.Add(pnlUserManagement)
        pnlMainContent.Controls.Add(pnlDashboard)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(200, 80)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Padding = New Padding(20)
        pnlMainContent.Size = New Size(1064, 601)
        pnlMainContent.TabIndex = 2
        ' 
        ' pnlQueueLogs
        ' 
        pnlQueueLogs.Controls.Add(lblQueueLogsTotal)
        pnlQueueLogs.Controls.Add(btnChangeStatus)
        pnlQueueLogs.Controls.Add(dgvQueueLogs)
        pnlQueueLogs.Controls.Add(lblQueueLogs)
        pnlQueueLogs.Dock = DockStyle.Fill
        pnlQueueLogs.Location = New Point(20, 20)
        pnlQueueLogs.Name = "pnlQueueLogs"
        pnlQueueLogs.Size = New Size(1024, 561)
        pnlQueueLogs.TabIndex = 8
        ' 
        ' lblQueueLogsTotal
        ' 
        lblQueueLogsTotal.AutoSize = True
        lblQueueLogsTotal.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblQueueLogsTotal.Location = New Point(180, 28)
        lblQueueLogsTotal.Name = "lblQueueLogsTotal"
        lblQueueLogsTotal.Size = New Size(77, 28)
        lblQueueLogsTotal.TabIndex = 6
        lblQueueLogsTotal.Text = "(Total: 0)"
        ' 
        ' btnChangeStatus
        ' 
        btnChangeStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnChangeStatus.BackColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        btnChangeStatus.FlatAppearance.BorderSize = 0
        btnChangeStatus.FlatStyle = FlatStyle.Flat
        btnChangeStatus.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnChangeStatus.ForeColor = Color.White
        btnChangeStatus.Location = New Point(874, 20)
        btnChangeStatus.Name = "btnChangeStatus"
        btnChangeStatus.Size = New Size(150, 36)
        btnChangeStatus.TabIndex = 5
        btnChangeStatus.Text = "Change Status"
        btnChangeStatus.UseVisualStyleBackColor = False
        ' 
        ' dgvQueueLogs
        ' 
        dgvQueueLogs.AllowUserToAddRows = False
        dgvQueueLogs.AllowUserToDeleteRows = False
        dgvQueueLogs.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvQueueLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvQueueLogs.BackgroundColor = Color.White
        dgvQueueLogs.BorderStyle = BorderStyle.None
        dgvQueueLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvQueueLogs.Location = New Point(0, 70)
        dgvQueueLogs.Name = "dgvQueueLogs"
        dgvQueueLogs.ReadOnly = True
        dgvQueueLogs.RowTemplate.Height = 25
        dgvQueueLogs.Size = New Size(1024, 491)
        dgvQueueLogs.TabIndex = 2
        ' 
        ' lblQueueLogs
        ' 
        lblQueueLogs.AutoSize = True
        lblQueueLogs.Font = New Font("Poppins", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQueueLogs.Location = New Point(20, 20)
        lblQueueLogs.Name = "lblQueueLogs"
        lblQueueLogs.Size = New Size(165, 42)
        lblQueueLogs.TabIndex = 1
        lblQueueLogs.Text = "Queue Logs"
        ' 
        ' pnlReports
        ' 
        pnlReports.Controls.Add(tabReports)
        pnlReports.Controls.Add(lblReports)
        pnlReports.Dock = DockStyle.Fill
        pnlReports.Location = New Point(20, 20)
        pnlReports.Name = "pnlReports"
        pnlReports.Size = New Size(1024, 561)
        pnlReports.TabIndex = 7
        ' 
        ' lblReports
        ' 
        lblReports.AutoSize = True
        lblReports.Font = New Font("Poppins", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblReports.Location = New Point(20, 20)
        lblReports.Name = "lblReports"
        lblReports.Size = New Size(113, 42)
        lblReports.TabIndex = 1
        lblReports.Text = "Reports"
        ' 
        ' pnlCounterManagement
        ' 
        pnlCounterManagement.Controls.Add(lblCountersTotal)
        pnlCounterManagement.Controls.Add(btnDeleteCounter)
        pnlCounterManagement.Controls.Add(btnEditCounter)
        pnlCounterManagement.Controls.Add(btnAddCounter)
        pnlCounterManagement.Controls.Add(dgvCounters)
        pnlCounterManagement.Controls.Add(lblCounterManagement)
        pnlCounterManagement.Dock = DockStyle.Fill
        pnlCounterManagement.Location = New Point(20, 20)
        pnlCounterManagement.Name = "pnlCounterManagement"
        pnlCounterManagement.Size = New Size(1024, 561)
        pnlCounterManagement.TabIndex = 6
        ' 
        ' lblCountersTotal
        ' 
        lblCountersTotal.AutoSize = True
        lblCountersTotal.Font = New Font("Poppins", 12.0F)
        lblCountersTotal.Location = New Point(305, 28)
        lblCountersTotal.Name = "lblCountersTotal"
        lblCountersTotal.Size = New Size(77, 28)
        lblCountersTotal.TabIndex = 5
        lblCountersTotal.Text = "(Total: 0)"
        ' 
        ' btnDeleteCounter
        ' 
        btnDeleteCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteCounter.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDeleteCounter.FlatAppearance.BorderSize = 0
        btnDeleteCounter.FlatStyle = FlatStyle.Flat
        btnDeleteCounter.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnDeleteCounter.ForeColor = Color.White
        btnDeleteCounter.Location = New Point(904, 20)
        btnDeleteCounter.Name = "btnDeleteCounter"
        btnDeleteCounter.Size = New Size(120, 36)
        btnDeleteCounter.TabIndex = 4
        btnDeleteCounter.Text = "Delete"
        btnDeleteCounter.UseVisualStyleBackColor = False
        ' 
        ' btnEditCounter
        ' 
        btnEditCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEditCounter.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnEditCounter.FlatAppearance.BorderSize = 0
        btnEditCounter.FlatStyle = FlatStyle.Flat
        btnEditCounter.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnEditCounter.ForeColor = Color.White
        btnEditCounter.Location = New Point(778, 20)
        btnEditCounter.Name = "btnEditCounter"
        btnEditCounter.Size = New Size(120, 36)
        btnEditCounter.TabIndex = 3
        btnEditCounter.Text = "Edit"
        btnEditCounter.UseVisualStyleBackColor = False
        ' 
        ' btnAddCounter
        ' 
        btnAddCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddCounter.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAddCounter.FlatAppearance.BorderSize = 0
        btnAddCounter.FlatStyle = FlatStyle.Flat
        btnAddCounter.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnAddCounter.ForeColor = Color.White
        btnAddCounter.Location = New Point(652, 20)
        btnAddCounter.Name = "btnAddCounter"
        btnAddCounter.Size = New Size(120, 36)
        btnAddCounter.TabIndex = 2
        btnAddCounter.Text = "Add Counter"
        btnAddCounter.UseVisualStyleBackColor = False
        ' 
        ' dgvCounters
        ' 
        dgvCounters.AllowUserToAddRows = False
        dgvCounters.AllowUserToDeleteRows = False
        dgvCounters.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvCounters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCounters.BackgroundColor = Color.White
        dgvCounters.BorderStyle = BorderStyle.None
        dgvCounters.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvCounters.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = Color.White
        DataGridViewCellStyle10.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle10.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle10.SelectionForeColor = Color.White
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.True
        dgvCounters.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        dgvCounters.ColumnHeadersHeight = 35
        dgvCounters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = Color.White
        DataGridViewCellStyle11.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle11.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle11.SelectionForeColor = Color.White
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.False
        dgvCounters.DefaultCellStyle = DataGridViewCellStyle11
        dgvCounters.EnableHeadersVisualStyles = False
        dgvCounters.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvCounters.Location = New Point(0, 70)
        dgvCounters.MultiSelect = False
        dgvCounters.Name = "dgvCounters"
        dgvCounters.ReadOnly = True
        dgvCounters.RowHeadersVisible = False
        DataGridViewCellStyle12.Padding = New Padding(10, 0, 0, 0)
        dgvCounters.RowsDefaultCellStyle = DataGridViewCellStyle12
        dgvCounters.RowTemplate.Height = 40
        dgvCounters.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCounters.Size = New Size(1024, 491)
        dgvCounters.TabIndex = 1
        ' 
        ' lblCounterManagement
        ' 
        lblCounterManagement.AutoSize = True
        lblCounterManagement.Font = New Font("Poppins", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCounterManagement.Location = New Point(20, 20)
        lblCounterManagement.Name = "lblCounterManagement"
        lblCounterManagement.Size = New Size(290, 42)
        lblCounterManagement.TabIndex = 1
        lblCounterManagement.Text = "Counter Management"
        ' 
        ' pnlUserManagement
        ' 
        pnlUserManagement.Controls.Add(lblUsersTotal)
        pnlUserManagement.Controls.Add(btnDeleteUser)
        pnlUserManagement.Controls.Add(btnEditUser)
        pnlUserManagement.Controls.Add(btnAddUser)
        pnlUserManagement.Controls.Add(dgvUsers)
        pnlUserManagement.Controls.Add(lblUserManagement)
        pnlUserManagement.Dock = DockStyle.Fill
        pnlUserManagement.Location = New Point(20, 20)
        pnlUserManagement.Name = "pnlUserManagement"
        pnlUserManagement.Size = New Size(1024, 561)
        pnlUserManagement.TabIndex = 5
        ' 
        ' lblUsersTotal
        ' 
        lblUsersTotal.AutoSize = True
        lblUsersTotal.Font = New Font("Poppins", 12.0F)
        lblUsersTotal.Location = New Point(245, 28)
        lblUsersTotal.Name = "lblUsersTotal"
        lblUsersTotal.Size = New Size(77, 28)
        lblUsersTotal.TabIndex = 5
        lblUsersTotal.Text = "(Total: 0)"
        ' 
        ' btnDeleteUser
        ' 
        btnDeleteUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteUser.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDeleteUser.FlatAppearance.BorderSize = 0
        btnDeleteUser.FlatStyle = FlatStyle.Flat
        btnDeleteUser.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnDeleteUser.ForeColor = Color.White
        btnDeleteUser.Location = New Point(904, 20)
        btnDeleteUser.Name = "btnDeleteUser"
        btnDeleteUser.Size = New Size(120, 36)
        btnDeleteUser.TabIndex = 4
        btnDeleteUser.Text = "Delete"
        btnDeleteUser.UseVisualStyleBackColor = False
        ' 
        ' btnEditUser
        ' 
        btnEditUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEditUser.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnEditUser.FlatAppearance.BorderSize = 0
        btnEditUser.FlatStyle = FlatStyle.Flat
        btnEditUser.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnEditUser.ForeColor = Color.White
        btnEditUser.Location = New Point(778, 20)
        btnEditUser.Name = "btnEditUser"
        btnEditUser.Size = New Size(120, 36)
        btnEditUser.TabIndex = 3
        btnEditUser.Text = "Edit"
        btnEditUser.UseVisualStyleBackColor = False
        ' 
        ' btnAddUser
        ' 
        btnAddUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddUser.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAddUser.FlatAppearance.BorderSize = 0
        btnAddUser.FlatStyle = FlatStyle.Flat
        btnAddUser.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnAddUser.ForeColor = Color.White
        btnAddUser.Location = New Point(652, 20)
        btnAddUser.Name = "btnAddUser"
        btnAddUser.Size = New Size(120, 36)
        btnAddUser.TabIndex = 2
        btnAddUser.Text = "Add User"
        btnAddUser.UseVisualStyleBackColor = False
        ' 
        ' dgvUsers
        ' 
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AllowUserToDeleteRows = False
        dgvUsers.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.BorderStyle = BorderStyle.None
        dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.White
        DataGridViewCellStyle1.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvUsers.ColumnHeadersHeight = 35
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvUsers.DefaultCellStyle = DataGridViewCellStyle2
        dgvUsers.EnableHeadersVisualStyles = False
        dgvUsers.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvUsers.Location = New Point(0, 70)
        dgvUsers.MultiSelect = False
        dgvUsers.Name = "dgvUsers"
        dgvUsers.ReadOnly = True
        dgvUsers.RowHeadersVisible = False
        DataGridViewCellStyle3.Padding = New Padding(10, 0, 0, 0)
        dgvUsers.RowsDefaultCellStyle = DataGridViewCellStyle3
        dgvUsers.RowTemplate.Height = 40
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.Size = New Size(1024, 491)
        dgvUsers.TabIndex = 1
        ' 
        ' lblUserManagement
        ' 
        lblUserManagement.AutoSize = True
        lblUserManagement.Font = New Font("Poppins", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUserManagement.Location = New Point(0, 16)
        lblUserManagement.Name = "lblUserManagement"
        lblUserManagement.Size = New Size(245, 42)
        lblUserManagement.TabIndex = 0
        lblUserManagement.Text = "User Management"
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.Controls.Add(pnlQueues)
        pnlDashboard.Controls.Add(pnlCashiers)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(20, 20)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(1024, 561)
        pnlDashboard.TabIndex = 4
        ' 
        ' pnlQueues
        ' 
        pnlQueues.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlQueues.BackColor = Color.White
        pnlQueues.Controls.Add(lblQueueTotal)
        pnlQueues.Controls.Add(dgvAllQueues)
        pnlQueues.Controls.Add(pnlQueuesHeader)
        pnlQueues.Location = New Point(420, 0)
        pnlQueues.Name = "pnlQueues"
        pnlQueues.Size = New Size(604, 561)
        pnlQueues.TabIndex = 3
        ' 
        ' lblQueueTotal
        ' 
        lblQueueTotal.AutoSize = True
        lblQueueTotal.Font = New Font("Poppins", 11.25F)
        lblQueueTotal.Location = New Point(215, 17)
        lblQueueTotal.Name = "lblQueueTotal"
        lblQueueTotal.Size = New Size(71, 26)
        lblQueueTotal.TabIndex = 2
        lblQueueTotal.Text = "(Total: 0)"
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
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = Color.White
        DataGridViewCellStyle4.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle4.SelectionForeColor = Color.White
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dgvAllQueues.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgvAllQueues.ColumnHeadersHeight = 35
        dgvAllQueues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.White
        DataGridViewCellStyle5.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle5.SelectionForeColor = Color.White
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        dgvAllQueues.DefaultCellStyle = DataGridViewCellStyle5
        dgvAllQueues.Dock = DockStyle.Fill
        dgvAllQueues.EnableHeadersVisualStyles = False
        dgvAllQueues.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvAllQueues.Location = New Point(0, 60)
        dgvAllQueues.MultiSelect = False
        dgvAllQueues.Name = "dgvAllQueues"
        dgvAllQueues.ReadOnly = True
        dgvAllQueues.RowHeadersVisible = False
        DataGridViewCellStyle6.Padding = New Padding(10, 0, 0, 0)
        dgvAllQueues.RowsDefaultCellStyle = DataGridViewCellStyle6
        dgvAllQueues.RowTemplate.Height = 40
        dgvAllQueues.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAllQueues.Size = New Size(604, 501)
        dgvAllQueues.TabIndex = 1
        ' 
        ' pnlQueuesHeader
        ' 
        pnlQueuesHeader.Controls.Add(lblQueueTitle)
        pnlQueuesHeader.Dock = DockStyle.Top
        pnlQueuesHeader.Location = New Point(0, 0)
        pnlQueuesHeader.Name = "pnlQueuesHeader"
        pnlQueuesHeader.Size = New Size(604, 60)
        pnlQueuesHeader.TabIndex = 0
        ' 
        ' lblQueueTitle
        ' 
        lblQueueTitle.AutoSize = True
        lblQueueTitle.Font = New Font("Poppins", 14.25F, FontStyle.Bold)
        lblQueueTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblQueueTitle.Location = New Point(15, 13)
        lblQueueTitle.Name = "lblQueueTitle"
        lblQueueTitle.Size = New Size(204, 34)
        lblQueueTitle.TabIndex = 0
        lblQueueTitle.Text = "Live Queue Activity"
        ' 
        ' pnlCashiers
        ' 
        pnlCashiers.BackColor = Color.White
        pnlCashiers.Controls.Add(lblActiveCashiers)
        pnlCashiers.Controls.Add(dgvCashierStatus)
        pnlCashiers.Controls.Add(pnlCashiersHeader)
        pnlCashiers.Location = New Point(0, 0)
        pnlCashiers.Name = "pnlCashiers"
        pnlCashiers.Size = New Size(400, 561)
        pnlCashiers.TabIndex = 2
        ' 
        ' lblActiveCashiers
        ' 
        lblActiveCashiers.AutoSize = True
        lblActiveCashiers.Font = New Font("Poppins", 11.25F)
        lblActiveCashiers.Location = New Point(172, 17)
        lblActiveCashiers.Name = "lblActiveCashiers"
        lblActiveCashiers.Size = New Size(71, 26)
        lblActiveCashiers.TabIndex = 2
        lblActiveCashiers.Text = "(Active: 0)"
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
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = Color.White
        DataGridViewCellStyle7.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle7.SelectionForeColor = Color.White
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        dgvCashierStatus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        dgvCashierStatus.ColumnHeadersHeight = 35
        dgvCashierStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = Color.White
        DataGridViewCellStyle8.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle8.SelectionForeColor = Color.White
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
        dgvCashierStatus.DefaultCellStyle = DataGridViewCellStyle8
        dgvCashierStatus.Dock = DockStyle.Fill
        dgvCashierStatus.EnableHeadersVisualStyles = False
        dgvCashierStatus.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvCashierStatus.Location = New Point(0, 60)
        dgvCashierStatus.MultiSelect = False
        dgvCashierStatus.Name = "dgvCashierStatus"
        dgvCashierStatus.ReadOnly = True
        dgvCashierStatus.RowHeadersVisible = False
        DataGridViewCellStyle9.Padding = New Padding(10, 0, 0, 0)
        dgvCashierStatus.RowsDefaultCellStyle = DataGridViewCellStyle9
        dgvCashierStatus.RowTemplate.Height = 40
        dgvCashierStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCashierStatus.Size = New Size(400, 501)
        dgvCashierStatus.TabIndex = 1
        ' 
        ' pnlCashiersHeader
        ' 
        pnlCashiersHeader.Controls.Add(lblCashierTitle)
        pnlCashiersHeader.Dock = DockStyle.Top
        pnlCashiersHeader.Location = New Point(0, 0)
        pnlCashiersHeader.Name = "pnlCashiersHeader"
        pnlCashiersHeader.Size = New Size(400, 60)
        pnlCashiersHeader.TabIndex = 0
        ' 
        ' lblCashierTitle
        ' 
        lblCashierTitle.AutoSize = True
        lblCashierTitle.Font = New Font("Poppins", 14.25F, FontStyle.Bold)
        lblCashierTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblCashierTitle.Location = New Point(15, 13)
        lblCashierTitle.Name = "lblCashierTitle"
        lblCashierTitle.Size = New Size(161, 34)
        lblCashierTitle.TabIndex = 0
        lblCashierTitle.Text = "Cashier Status"
        ' 
        ' tmrRefresh
        ' 
        tmrRefresh.Enabled = True
        tmrRefresh.Interval = 5000
        ' 
        ' tabReports
        ' 
        tabReports.Controls.Add(tpQueueLogsReport)
        tabReports.Dock = DockStyle.Fill
        tabReports.Location = New Point(0, 0)
        tabReports.Name = "tabReports"
        tabReports.SelectedIndex = 0
        tabReports.Size = New Size(1024, 561)
        tabReports.TabIndex = 2
        ' 
        ' tpQueueLogsReport
        ' 
        tpQueueLogsReport.Controls.Add(pnlQueueLogsReport)
        tpQueueLogsReport.Location = New Point(4, 24)
        tpQueueLogsReport.Name = "tpQueueLogsReport"
        tpQueueLogsReport.Padding = New Padding(3)
        tpQueueLogsReport.Size = New Size(1016, 533)
        tpQueueLogsReport.TabIndex = 0
        tpQueueLogsReport.Text = "Queue Logs Report"
        tpQueueLogsReport.UseVisualStyleBackColor = True
        ' 
        ' pnlQueueLogsReport
        ' 
        pnlQueueLogsReport.Controls.Add(lblReportTotal)
        pnlQueueLogsReport.Controls.Add(dgvReports)
        pnlQueueLogsReport.Controls.Add(btnGenerateReport)
        pnlQueueLogsReport.Controls.Add(dtpEndDate)
        pnlQueueLogsReport.Controls.Add(lblEndDate)
        pnlQueueLogsReport.Controls.Add(dtpStartDate)
        pnlQueueLogsReport.Controls.Add(lblStartDate)
        pnlQueueLogsReport.Controls.Add(cboReportType)
        pnlQueueLogsReport.Controls.Add(lblReportType)
        pnlQueueLogsReport.Dock = DockStyle.Fill
        pnlQueueLogsReport.Location = New Point(3, 3)
        pnlQueueLogsReport.Name = "pnlQueueLogsReport"
        pnlQueueLogsReport.Size = New Size(1010, 527)
        pnlQueueLogsReport.TabIndex = 0
        ' 
        ' lblReportType
        ' 
        lblReportType.AutoSize = True
        lblReportType.Location = New Point(20, 25)
        lblReportType.Name = "lblReportType"
        lblReportType.Size = New Size(70, 15)
        lblReportType.TabIndex = 0
        lblReportType.Text = "Report Type:"
        ' 
        ' cboReportType
        ' 
        cboReportType.DropDownStyle = ComboBoxStyle.DropDownList
        cboReportType.FormattingEnabled = True
        cboReportType.Items.AddRange(New Object() {"Daily", "Weekly", "Monthly", "Annual"})
        cboReportType.Location = New Point(120, 20)
        cboReportType.Name = "cboReportType"
        cboReportType.Size = New Size(121, 23)
        cboReportType.TabIndex = 1
        ' 
        ' lblStartDate
        ' 
        lblStartDate.AutoSize = True
        lblStartDate.Location = New Point(300, 25)
        lblStartDate.Name = "lblStartDate"
        lblStartDate.Size = New Size(61, 15)
        lblStartDate.TabIndex = 2
        lblStartDate.Text = "Start Date:"
        ' 
        ' dtpStartDate
        ' 
        dtpStartDate.Location = New Point(380, 20)
        dtpStartDate.Name = "dtpStartDate"
        dtpStartDate.Size = New Size(200, 23)
        dtpStartDate.TabIndex = 3
        ' 
        ' lblEndDate
        ' 
        lblEndDate.AutoSize = True
        lblEndDate.Location = New Point(580, 25)
        lblEndDate.Name = "lblEndDate"
        lblEndDate.Size = New Size(57, 15)
        lblEndDate.TabIndex = 4
        lblEndDate.Text = "End Date:"
        ' 
        ' dtpEndDate
        ' 
        dtpEndDate.Location = New Point(660, 20)
        dtpEndDate.Name = "dtpEndDate"
        dtpEndDate.Size = New Size(200, 23)
        dtpEndDate.TabIndex = 5
        ' 
        ' btnGenerateReport
        ' 
        btnGenerateReport.Location = New Point(850, 20)
        btnGenerateReport.Name = "btnGenerateReport"
        btnGenerateReport.Size = New Size(150, 25)
        btnGenerateReport.TabIndex = 6
        btnGenerateReport.Text = "Generate Report"
        btnGenerateReport.UseVisualStyleBackColor = True
        ' 
        ' dgvReports
        ' 
        dgvReports.AllowUserToAddRows = False
        dgvReports.AllowUserToDeleteRows = False
        dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReports.Dock = DockStyle.Bottom
        dgvReports.Location = New Point(0, 76)
        dgvReports.Name = "dgvReports"
        dgvReports.ReadOnly = True
        dgvReports.RowTemplate.Height = 25
        dgvReports.Size = New Size(1010, 451)
        dgvReports.TabIndex = 7
        ' 
        ' lblReportTotal
        ' 
        lblReportTotal.AutoSize = True
        lblReportTotal.Location = New Point(20, 50)
        lblReportTotal.Name = "lblReportTotal"
        lblReportTotal.Size = New Size(88, 15)
        lblReportTotal.TabIndex = 8
        lblReportTotal.Text = "Total Records: 0"
        ' 
        ' frmAdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(1264, 681)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Controls.Add(pnlHeader)
        MinimumSize = New Size(960, 600)
        Name = "frmAdminDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LOA EASE - Admin Dashboard"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlQueueLogs.ResumeLayout(False)
        pnlQueueLogs.PerformLayout()
        CType(dgvQueueLogs, ComponentModel.ISupportInitialize).EndInit()
        pnlReports.ResumeLayout(False)
        pnlReports.PerformLayout()
        pnlCounterManagement.ResumeLayout(False)
        pnlCounterManagement.PerformLayout()
        CType(dgvCounters, ComponentModel.ISupportInitialize).EndInit()
        pnlUserManagement.ResumeLayout(False)
        pnlUserManagement.PerformLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        pnlDashboard.ResumeLayout(False)
        pnlQueues.ResumeLayout(False)
        pnlQueues.PerformLayout()
        CType(dgvAllQueues, ComponentModel.ISupportInitialize).EndInit()
        pnlQueuesHeader.ResumeLayout(False)
        pnlQueuesHeader.PerformLayout()
        pnlCashiers.ResumeLayout(False)
        pnlCashiers.PerformLayout()
        CType(dgvCashierStatus, ComponentModel.ISupportInitialize).EndInit()
        pnlCashiersHeader.ResumeLayout(False)
        pnlCashiersHeader.PerformLayout()
        tpQueueLogsReport.ResumeLayout(False)
        pnlQueueLogsReport.ResumeLayout(False)
        pnlQueueLogsReport.PerformLayout()
        CType(dgvReports, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnDashboard As Button
    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents pnlQueues As Panel
    Friend WithEvents dgvAllQueues As DataGridView
    Friend WithEvents pnlQueuesHeader As Panel
    Friend WithEvents lblQueueTitle As Label
    Friend WithEvents pnlCashiers As Panel
    Friend WithEvents dgvCashierStatus As DataGridView
    Friend WithEvents pnlCashiersHeader As Panel
    Friend WithEvents lblCashierTitle As Label
    Friend WithEvents tmrRefresh As Timer
    Friend WithEvents btnUserManagement As Button
    Friend WithEvents btnCounterManagement As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents pnlUserManagement As Panel
    Friend WithEvents pnlCounterManagement As Panel
    Friend WithEvents pnlReports As Panel
    Friend WithEvents lblUserManagement As Label
    Friend WithEvents lblCounterManagement As Label
    Friend WithEvents lblReports As Label
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents btnAddUser As Button
    Friend WithEvents btnDeleteUser As Button
    Friend WithEvents btnEditUser As Button
    Friend WithEvents dgvCounters As DataGridView
    Friend WithEvents btnAddCounter As Button
    Friend WithEvents btnEditCounter As Button
    Friend WithEvents btnDeleteCounter As Button
    Friend WithEvents btnQueueLogs As Button
    Friend WithEvents pnlQueueLogs As Panel
    Friend WithEvents btnChangeStatus As Button
    Friend WithEvents dgvQueueLogs As DataGridView
    Friend WithEvents lblQueueLogs As Label
    Friend WithEvents lblUsersTotal As Label
    Friend WithEvents lblCountersTotal As Label
    Friend WithEvents lblQueueLogsTotal As Label
    Friend WithEvents lblActiveCashiers As Label
    Friend WithEvents lblQueueTotal As Label
    Friend WithEvents tabReports As TabControl
    Friend WithEvents tpQueueLogsReport As TabPage
    Friend WithEvents pnlQueueLogsReport As Panel
    Friend WithEvents lblReportType As Label
    Friend WithEvents cboReportType As ComboBox
    Friend WithEvents lblStartDate As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblEndDate As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents dgvReports As DataGridView
    Friend WithEvents lblReportTotal As Label
End Class