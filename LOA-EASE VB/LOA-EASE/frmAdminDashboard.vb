Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Data

Public Class frmAdminDashboard
    Private ReadOnly _adminFullName As String
    Private _activeButton As Button
    Private queueLogsTable As DataTable
    Private _lastQueueLogTimestamp As DateTime
    Private lblNoResultsFound As Label
    Private WithEvents tmrUserManagementRefresh As New Timer()
    Private btnAddNewStudent As Button
    Private btnDeleteStudent As Button

    Public Sub New(adminFullName As String)
        InitializeComponent()
        _adminFullName = adminFullName
        Me.WindowState = FormWindowState.Maximized

    End Sub


    Private Sub frmAdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        lblWelcome.Text = $"Welcome, {_adminFullName}"
        lblNoResultsFound = New Label()
        lblNoResultsFound.AutoSize = True
        lblNoResultsFound.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        lblNoResultsFound.ForeColor = Color.Red
        lblNoResultsFound.Location = New Point(630, 19)
        lblNoResultsFound.Name = "lblNoResultsFound"
        lblNoResultsFound.Size = New Size(150, 22)
        lblNoResultsFound.Text = "No results found"
        lblNoResultsFound.Visible = False
        pnlUserControls.Controls.Add(lblNoResultsFound)
        SetupDataGridViews()
        RefreshAllData()

        tmrRefresh.Interval = 15000
        AddHandler tmrRefresh.Tick, AddressOf tmrRefresh_Tick
        tmrRefresh.Start()
        cboSortQueueLogs.Items.Add("Default")
        cboSortQueueLogs.Items.Add("Queue Number")
        cboSortQueueLogs.Items.Add("Full Name")
        cboSortQueueLogs.Items.Add("Status")
        cboSortQueueLogs.SelectedIndex = 0

        Dim cboSortUsers As New ComboBox()
        cboSortUsers.DropDownStyle = ComboBoxStyle.DropDownList
        cboSortUsers.Name = "cboSortUsers"
        cboSortUsers.Location = New Point(440, 16)
        cboSortUsers.Size = New Size(180, 30)
        cboSortUsers.Font = New Font("Poppins", 9.0F)
        cboSortUsers.Items.Add("Default")
        cboSortUsers.Items.Add("Name (A-Z)")
        cboSortUsers.Items.Add("Name (Z-A)")
        cboSortUsers.Items.Add("Student No.")
        cboSortUsers.Items.Add("Course")
        cboSortUsers.Items.Add("Year Level")
        cboSortUsers.Items.Add("Last Activity")
        cboSortUsers.SelectedIndex = 0
        AddHandler cboSortUsers.SelectedIndexChanged, AddressOf cboSortUsers_SelectedIndexChanged
        pnlUserControls.Controls.Add(cboSortUsers)
        Dim lblSortUsers As New Label()
        lblSortUsers.Text = "Sort by:"
        lblSortUsers.AutoSize = True
        lblSortUsers.Font = New Font("Poppins", 9.0F)
        lblSortUsers.Location = New Point(380, 19)
        lblSortUsers.Name = "lblSortUsers"
        pnlUserControls.Controls.Add(lblSortUsers)
        btnAddNewStudent = New Button()
        btnAddNewStudent.Name = "btnAddNewStudent"
        btnAddNewStudent.Text = "Add New Student"
        btnAddNewStudent.Location = New Point(630, 16)  ' Positioned after the sort dropdown
        btnAddNewStudent.Size = New Size(150, 30)
        btnAddNewStudent.Font = New Font("Poppins", 9.0F)
        btnAddNewStudent.BackColor = Color.FromArgb(0, 123, 255)  ' Blue color like other action buttons
        btnAddNewStudent.ForeColor = Color.White
        btnAddNewStudent.FlatStyle = FlatStyle.Flat
        btnAddNewStudent.FlatAppearance.BorderSize = 0
        btnAddNewStudent.Cursor = Cursors.Hand
        btnAddNewStudent.Visible = False
        AddHandler btnAddNewStudent.Click, AddressOf btnAddNewStudent_Click
        pnlUserControls.Controls.Add(btnAddNewStudent)
        btnDeleteStudent = New Button()
        btnDeleteStudent.Name = "btnDeleteStudent"
        btnDeleteStudent.Text = "Delete Student"
        btnDeleteStudent.Location = New Point(790, 16)  ' Positioned after Add New Student button
        btnDeleteStudent.Size = New Size(150, 30)
        btnDeleteStudent.Font = New Font("Poppins", 9.0F)
        btnDeleteStudent.BackColor = Color.FromArgb(220, 53, 69)  ' Red color for delete action
        btnDeleteStudent.ForeColor = Color.White
        btnDeleteStudent.FlatStyle = FlatStyle.Flat
        btnDeleteStudent.FlatAppearance.BorderSize = 0
        btnDeleteStudent.Cursor = Cursors.Hand
        btnDeleteStudent.Visible = False
        AddHandler btnDeleteStudent.Click, AddressOf btnDeleteStudent_Click
        pnlUserControls.Controls.Add(btnDeleteStudent)

        ShowPanel(pnlDashboard, btnDashboard)
        AddHandler tabUserManagement.SelectedIndexChanged, AddressOf tabUserManagement_SelectedIndexChanged
    End Sub



    Private Sub cboSortUsers_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim comboBox As ComboBox = DirectCast(sender, ComboBox)
        ApplySorting(comboBox.SelectedItem.ToString())
    End Sub

    Private Sub ApplySorting(sortBy As String)
        If Not pnlUserManagement.Visible Then Return
        If tabUserManagement Is Nothing OrElse tabUserManagement.SelectedTab Is Nothing Then Return
        Dim activeGridView As DataGridView = If(tabUserManagement.SelectedTab Is tpWithAccount, dgvUsersWithAccount, dgvUsersWithoutAccount)
        If activeGridView Is Nothing Then Return
        Dim source As BindingList(Of User) = TryCast(activeGridView.DataSource, BindingList(Of User))
        If source Is Nothing OrElse source.Count = 0 Then Return
        Dim userList As New List(Of User)(source)
        Select Case sortBy
            Case "Name (A-Z)"
                userList.Sort(Function(x, y) String.Compare(x.FullName, y.FullName))
            Case "Name (Z-A)"
                userList.Sort(Function(x, y) String.Compare(y.FullName, x.FullName))
            Case "Student No."
                userList.Sort(Function(x, y) String.Compare(x.StudentNo, y.StudentNo))
            Case "Course"
                userList.Sort(Function(x, y) String.Compare(x.Course, y.Course))
            Case "Year Level"
                userList.Sort(Function(x, y) String.Compare(x.YearLevel, y.YearLevel))
            Case "Last Activity"
                userList.Sort(Function(x, y)
                                  ' Compare last queue time (more recent first)
                                  If x.LastQueueDateTime = "N/A" AndAlso y.LastQueueDateTime = "N/A" Then
                                      Return 0
                                  ElseIf x.LastQueueDateTime = "N/A" Then
                                      Return 1
                                  ElseIf y.LastQueueDateTime = "N/A" Then
                                      Return -1
                                  Else
                                      Return DateTime.Compare(DateTime.Parse(y.LastQueueDateTime), DateTime.Parse(x.LastQueueDateTime))
                                  End If
                              End Function)
            Case "Default"
                ' Do nothing, just reload the data
            Case Else
                Return
        End Select

        ' Update the DataGridView with sorted list
        activeGridView.DataSource = New BindingList(Of User)(userList)
    End Sub

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs)
        If pnlDashboard.Visible Then
            RefreshAllData()
        ElseIf pnlCounterManagement.Visible Then
            FetchCounters()
        ElseIf pnlQueueLogs.Visible Then
            CheckForQueueLogUpdates()
        End If
    End Sub

    Private Sub CheckForQueueLogUpdates()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "SELECT MAX(created_at) FROM queues"
                Using cmd As New MySqlCommand(query, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        Dim latest As DateTime = Convert.ToDateTime(result)
                        If latest > _lastQueueLogTimestamp Then
                            _lastQueueLogTimestamp = latest
                            FetchAllQueueLogs()
                        End If
                    End If
                End Using
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Private Sub SetupDataGridViews()
        ' Cashier Status DataGridView
        dgvCashierStatus.AutoGenerateColumns = False
        dgvCashierStatus.Columns.Clear()
        dgvCashierStatus.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "CashierName",
        .HeaderText = "Cashier Name",
        .DataPropertyName = "CashierName"
    })
        dgvCashierStatus.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Status",
        .HeaderText = "Status",
        .DataPropertyName = "Status"
    })
        dgvCashierStatus.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Counter",
        .HeaderText = "Counter",
        .DataPropertyName = "Counter"
    })
        dgvCashierStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCashierStatus.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvCashierStatus.DefaultCellStyle.SelectionForeColor = Color.White

        ' All Queues DataGridView
        dgvAllQueues.AutoGenerateColumns = False
        dgvAllQueues.Columns.Clear()
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "QueueNumber",
        .HeaderText = "Queue No.",
        .DataPropertyName = "QueueNumber"
    })
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "FullName",
        .HeaderText = "Full Name",
        .DataPropertyName = "FullName"
    })
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "StudentNo",
        .HeaderText = "Student No.",
        .DataPropertyName = "StudentNo"
    })
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Counter",
        .HeaderText = "Counter",
        .DataPropertyName = "Counter"
    })
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Status",
        .HeaderText = "Status",
        .DataPropertyName = "Status"
    })
        dgvAllQueues.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAllQueues.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvAllQueues.DefaultCellStyle.SelectionForeColor = Color.White

        ' Queue Logs DataGridView
        dgvQueueLogs.AutoGenerateColumns = False
        dgvQueueLogs.Columns.Clear()
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "QueueNumber",
        .HeaderText = "Queue No.",
        .DataPropertyName = "Queue Number"
    })
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "FullName",
        .HeaderText = "Full Name",
        .DataPropertyName = "Full Name"
    })
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Status",
        .HeaderText = "Status",
        .DataPropertyName = "Status"
    })
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "CreatedAt",
        .HeaderText = "Date Created",
        .DataPropertyName = "Date Created"
    })
        dgvQueueLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvQueueLogs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvQueueLogs.DefaultCellStyle.SelectionForeColor = Color.White

        ' Users With Account DataGridView
        dgvUsersWithAccount.AutoGenerateColumns = False
        dgvUsersWithAccount.Columns.Clear()
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "FullName",
        .HeaderText = "Full Name",
        .DataPropertyName = "FullName"
    })
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Username",
        .HeaderText = "Username",
        .DataPropertyName = "Username"
    })
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "StudentNo",
        .HeaderText = "Student No.",
        .DataPropertyName = "StudentNo"
    })
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Role",
        .HeaderText = "Role",
        .DataPropertyName = "Role"
    })
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "LastLogin",
        .HeaderText = "Last Login",
        .DataPropertyName = "LastLogin"
    })
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "LastSession",
        .HeaderText = "Last Session",
        .DataPropertyName = "LastSession"
    })
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "LastQueueDateTime",
        .HeaderText = "Last Queue",
        .DataPropertyName = "LastQueueDateTime"
    })
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Course",
        .HeaderText = "Course",
        .DataPropertyName = "Course"
    })
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "YearLevel",
        .HeaderText = "Year Level",
        .DataPropertyName = "YearLevel"
    })
        dgvUsersWithAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsersWithAccount.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvUsersWithAccount.DefaultCellStyle.SelectionForeColor = Color.White

        ' Users Without Account DataGridView
        dgvUsersWithoutAccount.AutoGenerateColumns = False
        dgvUsersWithoutAccount.Columns.Clear()
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "FullName",
        .HeaderText = "Full Name",
        .DataPropertyName = "FullName"
    })
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "StudentNo",
        .HeaderText = "Student No.",
        .DataPropertyName = "StudentNo"
    })
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Course",
        .HeaderText = "Course",
        .DataPropertyName = "Course"
    })
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "YearLevel",
        .HeaderText = "Year Level",
        .DataPropertyName = "YearLevel"
    })
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "LastQueueDateTime",
        .HeaderText = "Last Queue",
        .DataPropertyName = "LastQueueDateTime"
    })
        dgvUsersWithoutAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsersWithoutAccount.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvUsersWithoutAccount.DefaultCellStyle.SelectionForeColor = Color.White

        ' Counters DataGridView
        dgvCounters.AutoGenerateColumns = False
        dgvCounters.Columns.Clear()
        dgvCounters.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "CounterName",
        .HeaderText = "Counter Name",
        .DataPropertyName = "CounterName"
    })
        dgvCounters.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Cashier",
        .HeaderText = "Cashier",
        .DataPropertyName = "Cashier"
    })
        dgvCounters.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCounters.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvCounters.DefaultCellStyle.SelectionForeColor = Color.White

        dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReports.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvReports.DefaultCellStyle.SelectionForeColor = Color.White
    End Sub

    Private Sub RefreshAllData()
        FetchCashierStatus()
        FetchAllQueues()
    End Sub

    Private Sub FetchCashierStatus()
        Dim cashierStatusList As New BindingList(Of CashierStatusItem)()
        Dim activeCashiers As Integer = 0
        Try
            Dim dt As DataTable = DatabaseHelper.GetCashierStatus()
            For Each row As DataRow In dt.Rows
                Dim statusText As String = "Offline"
                If Not row.IsNull("is_open") AndAlso CBool(row("is_open")) Then
                    statusText = If(row.IsNull("status"), "Open", row("status").ToString())
                    activeCashiers += 1
                End If

                cashierStatusList.Add(New CashierStatusItem With {
                    .CashierName = row("full_name").ToString(),
                    .Status = statusText,
                    .Counter = row("counter_name").ToString()
                })
            Next
            dgvCashierStatus.DataSource = cashierStatusList
            lblActiveCashiers.Text = $"(Active: {activeCashiers})"
            dgvCashierStatus.ClearSelection()
        Catch ex As Exception
            HandleDbError("fetching cashier status", ex)
        End Try
    End Sub

    Private Sub FetchAllQueues()
        Dim queueList As New BindingList(Of QueueLogItem)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                        SELECT
                            q.queue_number,
                        COALESCE(CONCAT(s.first_name, ' ', s.last_name), v.full_name) AS FullName,
                        s.student_number AS StudentNo,
                        c.counter_name,
                            q.status
                    FROM queues q
                    LEFT JOIN students s ON q.student_id = s.student_id
                    LEFT JOIN visitors v ON q.visitor_id = v.visitor_id
                    JOIN counters c ON q.counter_id = c.counter_id
                    WHERE DATE(q.created_at) = CURDATE()
                    ORDER BY q.created_at DESC"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            queueList.Add(New QueueLogItem With {
                                .QueueNumber = reader("queue_number").ToString(),
                                .FullName = reader("FullName").ToString(),
                                .StudentNo = If(reader("StudentNo") IsNot DBNull.Value, reader("StudentNo").ToString(), "N/A"),
                                .Counter = reader("counter_name").ToString(),
                                .Status = reader("status").ToString()
                            })
                        End While
                    End Using
                End Using
                dgvAllQueues.DataSource = queueList
                lblQueueTotal.Text = $"(Total: {queueList.Count})"
                dgvAllQueues.ClearSelection()
            Catch ex As Exception
                HandleDbError("fetching all queues", ex)
            End Try
        End Using
    End Sub

    Private Sub FetchAllQueueLogs()
        queueLogsTable = New DataTable()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                SELECT
                    q.queue_id,
                    q.queue_number AS 'Queue Number',
                    COALESCE(CONCAT(s.first_name, ' ', s.last_name), v.full_name) AS 'Full Name',
                    q.status AS 'Status',
                    q.created_at AS 'Date Created'
                FROM queues q
                LEFT JOIN students s ON q.student_id = s.student_id
                LEFT JOIN visitors v ON q.visitor_id = v.visitor_id
                ORDER BY
                    CASE
                        WHEN q.status = 'serving' THEN 1
                        WHEN q.status = 'waiting' THEN 2
                        ELSE 3
                    END,
                    q.created_at DESC"
                Using adapter As New MySqlDataAdapter(query, conn)
                    adapter.Fill(queueLogsTable)
                End Using

                dgvQueueLogs.DataSource = queueLogsTable
                dgvQueueLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvQueueLogs.AllowUserToOrderColumns = True
                dgvQueueLogs.ReadOnly = True
                dgvQueueLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect

                lblQueueLogsTotal.Text = $"(Total: {queueLogsTable.Rows.Count})"

                If queueLogsTable.Rows.Count > 0 Then
                    _lastQueueLogTimestamp = Convert.ToDateTime(queueLogsTable.Rows(0)("Date Created"))
                End If

            Catch ex As Exception
                HandleDbError("fetching queue logs", ex)
            End Try
        End Using
    End Sub

    Private Sub txtSearchQueueLogs_TextChanged(sender As Object, e As EventArgs) Handles txtSearchQueueLogs.TextChanged
        If queueLogsTable Is Nothing Then Return
        Dim filterText As String = txtSearchQueueLogs.Text.Replace("'", "''")
        Dim view As DataView = queueLogsTable.DefaultView
        view.RowFilter = $"[Queue Number] LIKE '%{filterText}%' OR [Full Name] LIKE '%{filterText}%' OR [Status] LIKE '%{filterText}%'"
    End Sub

    Private Sub txtSearchUsers_TextChanged(sender As Object, e As EventArgs) Handles txtSearchUsers.TextChanged
        Dim searchText As String = txtSearchUsers.Text.Trim().ToLower()

        lblNoResultsFound.Visible = False
        If String.IsNullOrEmpty(searchText) Then
            If tabUserManagement.SelectedTab Is tpWithAccount AndAlso dgvUsersWithAccount.Tag IsNot Nothing Then
                dgvUsersWithAccount.DataSource = dgvUsersWithAccount.Tag
                dgvUsersWithAccount.Tag = Nothing
            ElseIf tabUserManagement.SelectedTab Is tpWithoutAccount AndAlso dgvUsersWithoutAccount.Tag IsNot Nothing Then
                dgvUsersWithoutAccount.DataSource = dgvUsersWithoutAccount.Tag
                dgvUsersWithoutAccount.Tag = Nothing
            End If
            Return
        End If

        If tabUserManagement.SelectedTab Is tpWithAccount Then
            Dim source As BindingList(Of User) = TryCast(dgvUsersWithAccount.DataSource, BindingList(Of User))
            If source IsNot Nothing Then
                Dim filteredList As New BindingList(Of User)

                For Each user As User In source
                    If user.FullName.ToLower().Contains(searchText) OrElse
                   user.Username.ToLower().Contains(searchText) OrElse
                   user.StudentNo.ToLower().Contains(searchText) OrElse
                   (user.Course IsNot Nothing AndAlso user.Course.ToLower().Contains(searchText)) OrElse
                   (user.YearLevel IsNot Nothing AndAlso user.YearLevel.ToLower().Contains(searchText)) OrElse
                   user.Role.ToLower().Contains(searchText) Then
                        filteredList.Add(user)
                    End If
                Next

                If dgvUsersWithAccount.Tag Is Nothing Then
                    dgvUsersWithAccount.Tag = source
                End If
                dgvUsersWithAccount.DataSource = filteredList
                lblNoResultsFound.Visible = (filteredList.Count = 0)
            End If
        ElseIf tabUserManagement.SelectedTab Is tpWithoutAccount Then
            Dim source As BindingList(Of User) = TryCast(dgvUsersWithoutAccount.DataSource, BindingList(Of User))
            If source IsNot Nothing Then
                Dim filteredList As New BindingList(Of User)
                For Each user As User In source
                    If user.FullName.ToLower().Contains(searchText) OrElse
                   user.StudentNo.ToLower().Contains(searchText) OrElse
                   (user.Course IsNot Nothing AndAlso user.Course.ToLower().Contains(searchText)) OrElse
                   user.LastQueueDateTime.ToLower().Contains(searchText) Then
                        filteredList.Add(user)
                    End If
                Next


                If dgvUsersWithoutAccount.Tag Is Nothing Then
                    dgvUsersWithoutAccount.Tag = source
                End If


                dgvUsersWithoutAccount.DataSource = filteredList


                lblNoResultsFound.Visible = (filteredList.Count = 0)
            End If
        End If
    End Sub

    Private Sub cboSortQueueLogs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSortQueueLogs.SelectedIndexChanged
        If queueLogsTable Is Nothing Then Return

        Dim sortColumn As String = ""
        Select Case cboSortQueueLogs.SelectedItem.ToString()
            Case "Queue Number"
                sortColumn = "[Queue Number]"
            Case "Full Name"
                sortColumn = "[Full Name]"
            Case "Status"
                sortColumn = "[Status]"
            Case Else
                queueLogsTable.DefaultView.Sort = ""
                Return
        End Select
        queueLogsTable.DefaultView.Sort = $"{sortColumn} ASC"
    End Sub


    Private Sub FetchUsers()
        Dim usersWithAccount As New BindingList(Of User)()
        Dim usersWithoutAccount As New BindingList(Of User)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
            SELECT
                s.student_id,
                s.student_number,
                CONCAT(s.first_name, ' ', s.last_name) AS full_name,
                s.course,
                s.year_level,
                u.user_id,
                u.username,
                u.last_login,
                u.created_at AS user_created_at,
                q.last_queue_time
            FROM
                students s
            LEFT JOIN
                users u ON s.student_id = u.student_id
            LEFT JOIN
                (SELECT student_id, MAX(created_at) AS last_queue_time FROM queues GROUP BY student_id) q ON s.student_id = q.student_id"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim user As New User With {
                            .StudentID = Convert.ToInt32(reader("student_id")),
                            .UserID = If(reader.IsDBNull(reader.GetOrdinal("user_id")), 0, Convert.ToInt32(reader("user_id"))),
                            .FullName = reader("full_name").ToString(),
                            .Username = If(reader.IsDBNull(reader.GetOrdinal("username")), "N/A", reader("username").ToString()),
                            .StudentNo = reader("student_number").ToString(),
                            .Course = If(reader.IsDBNull(reader.GetOrdinal("course")), "N/A", reader("course").ToString()),
                            .YearLevel = If(reader.IsDBNull(reader.GetOrdinal("year_level")), "N/A", reader("year_level").ToString()),
                            .Role = If(reader.IsDBNull(reader.GetOrdinal("user_id")), "No Account", "Student"),
                            .LastLogin = If(reader.IsDBNull(reader.GetOrdinal("last_login")), "N/A", Convert.ToDateTime(reader("last_login")).ToString("g")),
                            .LastSession = If(reader.IsDBNull(reader.GetOrdinal("user_created_at")), "N/A", Convert.ToDateTime(reader("user_created_at")).ToString("g")),
                            .LastQueueDateTime = If(reader.IsDBNull(reader.GetOrdinal("last_queue_time")), "N/A", Convert.ToDateTime(reader("last_queue_time")).ToString("g"))
                        }
                            If user.Role = "No Account" Then
                                usersWithoutAccount.Add(user)
                            Else
                                usersWithAccount.Add(user)
                            End If
                        End While
                    End Using
                End Using
                dgvUsersWithAccount.DataSource = usersWithAccount
                dgvUsersWithoutAccount.DataSource = usersWithoutAccount
                lblUsersTotal.Text = $"(With Account: {usersWithAccount.Count}, Without Account: {usersWithoutAccount.Count})"
                dgvUsersWithAccount.ClearSelection()
                dgvUsersWithoutAccount.ClearSelection()
            Catch ex As Exception
                HandleDbError("fetching users", ex)
            End Try
        End Using
    End Sub

    Private Sub FetchCounters()
        Dim counterList As New BindingList(Of Counter)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                SELECT
                    c.counter_id,
                    c.counter_name,
                    COALESCE(ch.full_name, 'N/A') AS cashier
                FROM counters c
                LEFT JOIN cashiers ch ON c.counter_id = ch.counter_id
                ORDER BY c.counter_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            counterList.Add(New Counter With {
                                .CounterID = Convert.ToInt32(reader("counter_id")),
                                .CounterName = reader("counter_name").ToString(),
                                .Cashier = reader("cashier").ToString()
                            })
                        End While
                    End Using
                End Using
                dgvCounters.DataSource = counterList
            Catch ex As Exception
                HandleDbError("fetching counters", ex)
            End Try
        End Using
    End Sub

    Private Sub HandleDbError(action As String, ex As Exception)
        tmrRefresh.Stop()
        MessageBox.Show($"Error {action}: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ShowPanel(panelToShow As Panel, clickedButton As Button)
        pnlDashboard.Visible = False
        pnlUserManagement.Visible = False
        pnlCounterManagement.Visible = False
        pnlReports.Visible = False
        pnlQueueLogs.Visible = False

        panelToShow.Visible = True
        panelToShow.BringToFront()


        If _activeButton IsNot Nothing Then
            _activeButton.BackColor = Color.FromArgb(45, 52, 54)
        End If
        clickedButton.BackColor = Color.FromArgb(0, 85, 164)
        _activeButton = clickedButton
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowPanel(pnlDashboard, btnDashboard)
    End Sub

    Private Sub btnUserManagement_Click(sender As Object, e As EventArgs) Handles btnUserManagement.Click
        ShowPanel(pnlUserManagement, btnUserManagement)
        FetchUsers()
        tabUserManagement_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub btnCounterManagement_Click(sender As Object, e As EventArgs) Handles btnCounterManagement.Click
        ShowPanel(pnlCounterManagement, btnCounterManagement)
        FetchCounters()
    End Sub

    Private Sub btnQueueLogs_Click(sender As Object, e As EventArgs) Handles btnQueueLogs.Click
        ShowPanel(pnlQueueLogs, btnQueueLogs)
        FetchAllQueueLogs()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        ShowPanel(pnlReports, btnReports)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        tmrRefresh.Stop()
        If tmrUserManagementRefresh IsNot Nothing Then
            tmrUserManagementRefresh.Stop()
        End If

        Me.Close()
        Dim frmLogin As New frmLogin()
        frmLogin.Show()
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        If dgvUsersWithoutAccount.SelectedRows.Count > 0 Then
            Dim selectedUser As User = CType(dgvUsersWithoutAccount.SelectedRows(0).DataBoundItem, User)
            If selectedUser.Role = "No Account" Then
                Using frm As New frmAddEditUser(selectedUser.StudentID, selectedUser.FullName)
                    If frm.ShowDialog() = DialogResult.OK Then
                        FetchUsers()
                    End If
                End Using
            Else
                MessageBox.Show("This student already has an account.", "Account Exists", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Please select a student from the 'Without Account' tab to create an account for.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        If dgvUsersWithAccount.SelectedRows.Count > 0 Then
            Dim selectedUser As User = CType(dgvUsersWithAccount.SelectedRows(0).DataBoundItem, User)
            If selectedUser.Role <> "No Account" Then
                Using frm As New frmAddEditUser(selectedUser.UserID, selectedUser.FullName, selectedUser.Username, selectedUser.Role)
                    If frm.ShowDialog() = DialogResult.OK Then
                        FetchUsers()
                    End If
                End Using
            Else
                MessageBox.Show("This student does not have an account to edit.", "No Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Please select a user from the 'With Account' tab to edit.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If dgvUsersWithAccount.SelectedRows.Count > 0 Then
            Dim selectedUser As User = CType(dgvUsersWithAccount.SelectedRows(0).DataBoundItem, User)

            If selectedUser.Role = "No Account" Then
                MessageBox.Show("This student does not have an account to delete.", "No Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If MessageBox.Show($"Are you sure you want to delete the user account for '{selectedUser.FullName}'?{vbCrLf}This will not delete the student record.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                    Try
                        conn.Open()
                        Dim query As String = "DELETE FROM users WHERE user_id = @userId"

                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@userId", selectedUser.UserID)
                            Dim result = cmd.ExecuteNonQuery()

                            If result > 0 Then
                                MessageBox.Show("User account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                FetchUsers()
                            Else
                                MessageBox.Show("Could not find the user account to delete. The list will be refreshed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                FetchUsers()
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show($"Error deleting user account: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Please select a user from the 'With Account' tab to delete.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAddCounter_Click(sender As Object, e As EventArgs) Handles btnAddCounter.Click
        Using frm As New frmAddEditCounter()
            If frm.ShowDialog() = DialogResult.OK Then
                FetchCounters()
            End If
        End Using
    End Sub

    Private Sub btnEditCounter_Click(sender As Object, e As EventArgs) Handles btnEditCounter.Click
        If dgvCounters.SelectedRows.Count > 0 Then
            Dim selectedCounter As Counter = CType(dgvCounters.SelectedRows(0).DataBoundItem, Counter)
            Using frm As New frmAddEditCounter(selectedCounter.CounterID)
                If frm.ShowDialog() = DialogResult.OK Then
                    FetchCounters()
                End If
            End Using
        Else
            MessageBox.Show("Please select a counter to edit.", "No Counter Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnChangeStatus_Click(sender As Object, e As EventArgs) Handles btnChangeStatus.Click
        If dgvQueueLogs.SelectedRows.Count > 0 Then
            ' The DataBoundItem is a DataRowView when the DataSource is a DataTable.
            Dim selectedRow As DataRowView = TryCast(dgvQueueLogs.SelectedRows(0).DataBoundItem, DataRowView)

            If selectedRow IsNot Nothing Then
                Dim queueId As Integer = Convert.ToInt32(selectedRow("queue_id"))
                Dim queueNumber As String = selectedRow("Queue Number").ToString()
                Dim currentStatus As String = selectedRow("Status").ToString()


                Using statusForm As New Form()
                    statusForm.Text = "Change Queue Status"
                    statusForm.StartPosition = FormStartPosition.CenterParent
                    statusForm.FormBorderStyle = FormBorderStyle.FixedDialog
                    statusForm.ClientSize = New Size(250, 150)

                    Dim lbl As New Label()
                    lbl.Text = $"Change status for {queueNumber}:"
                    lbl.Location = New Point(10, 10)
                    lbl.AutoSize = True
                    statusForm.Controls.Add(lbl)

                    Dim cboStatus As New ComboBox()
                    cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
                    cboStatus.Items.AddRange(New String() {"waiting", "serving", "completed", "cancelled", "no-show", "scheduled", "expired"})
                    cboStatus.SelectedItem = currentStatus
                    cboStatus.Location = New Point(10, 40)
                    cboStatus.Width = 230
                    statusForm.Controls.Add(cboStatus)

                    Dim btnOk As New Button()
                    btnOk.Text = "OK"
                    btnOk.DialogResult = DialogResult.OK
                    btnOk.Location = New Point(80, 80)
                    statusForm.Controls.Add(btnOk)

                    Dim btnCancel As New Button()
                    btnCancel.Text = "Cancel"
                    btnCancel.DialogResult = DialogResult.Cancel
                    btnCancel.Location = New Point(160, 80)
                    statusForm.Controls.Add(btnCancel)

                    If statusForm.ShowDialog() = DialogResult.OK Then
                        Dim newStatus As String = cboStatus.SelectedItem.ToString()
                        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                            Try
                                conn.Open()
                                Dim query As String = "UPDATE queues SET status = @status WHERE queue_id = @queueId"
                                Using cmd As New MySqlCommand(query, conn)
                                    cmd.Parameters.AddWithValue("@status", newStatus)
                                    cmd.Parameters.AddWithValue("@queueId", queueId)
                                    cmd.ExecuteNonQuery()
                                End Using
                                FetchAllQueueLogs()
                            Catch ex As Exception
                                MessageBox.Show($"Error updating status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        End Using
                    End If
                End Using
            End If
        Else
            MessageBox.Show("Please select a queue entry to change its status.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDeleteCounter_Click(sender As Object, e As EventArgs) Handles btnDeleteCounter.Click
        If dgvCounters.SelectedRows.Count > 0 Then
            Dim selectedCounter As Counter = CType(dgvCounters.SelectedRows(0).DataBoundItem, Counter)
            If MessageBox.Show($"Are you sure you want to delete '{selectedCounter.CounterName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                    conn.Open()
                    Dim transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' First, delete the cashier associated with the counter
                        Dim deleteCashierQuery As String = "DELETE FROM cashiers WHERE counter_id = @counterId"
                        Using cmd As New MySqlCommand(deleteCashierQuery, conn, transaction)
                            cmd.Parameters.AddWithValue("@counterId", selectedCounter.CounterID)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Then, delete the counter itself
                        Dim deleteCounterQuery As String = "DELETE FROM counters WHERE counter_id = @counterId"
                        Using cmd As New MySqlCommand(deleteCounterQuery, conn, transaction)
                            cmd.Parameters.AddWithValue("@counterId", selectedCounter.CounterID)
                            cmd.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                        FetchCounters()
                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show($"Error deleting counter: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Please select a counter to delete.", "No Counter Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        FetchReportData()
    End Sub

    Private Sub FetchReportData()
        If cboReportType.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a report type.", "No Report Type Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim reportType As String = cboReportType.SelectedItem.ToString()
        Dim startDate As Date = dtpStartDate.Value
        Dim endDate As Date = dtpEndDate.Value
        Dim reportData As New BindingList(Of QueueLogAdminItem)()

        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                SELECT
                    q.queue_id,
                    q.queue_number,
                    COALESCE(CONCAT(s.first_name, ' ', s.last_name), v.full_name) AS FullName,
                    q.status,
                    q.created_at
                FROM queues q
                LEFT JOIN students s ON q.student_id = s.student_id
                LEFT JOIN visitors v ON q.visitor_id = v.visitor_id
                WHERE "

                Select Case reportType
                    Case "Daily"
                        query &= "DATE(q.created_at) = @startDate"
                    Case "Weekly"
                        query &= "YEARWEEK(q.created_at, 1) = YEARWEEK(@startDate, 1)"
                    Case "Monthly"
                        query &= "YEAR(q.created_at) = YEAR(@startDate) AND MONTH(q.created_at) = MONTH(@startDate)"
                    Case "Annual"
                        query &= "YEAR(q.created_at) = YEAR(@startDate)"
                End Select

                query &= " ORDER BY q.created_at DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            reportData.Add(New QueueLogAdminItem With {
                                .QueueID = Convert.ToInt32(reader("queue_id")),
                                .QueueNumber = reader("queue_number").ToString(),
                                .FullName = reader("FullName").ToString(),
                                .Status = reader("status").ToString(),
                                .CreatedAt = Convert.ToDateTime(reader("created_at")).ToString("g")
                            })
                        End While
                    End Using
                End Using

                dgvReports.DataSource = reportData
                lblReportTotal.Text = $"Total Records: {reportData.Count}"
            Catch ex As Exception
                HandleDbError("fetching report data", ex)
            End Try
        End Using
    End Sub

    Private Sub dgvQueueLogs_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvQueueLogs.CellFormatting
        If e.ColumnIndex = dgvQueueLogs.Columns("Status").Index AndAlso e.Value IsNot Nothing Then
            Dim status As String = e.Value.ToString()

            ' Check if the row is selected
            Dim isSelected As Boolean = False
            If e.RowIndex >= 0 AndAlso e.RowIndex < dgvQueueLogs.Rows.Count Then
                isSelected = dgvQueueLogs.Rows(e.RowIndex).Selected
            End If

            Select Case status
                Case "completed"
                    e.CellStyle.BackColor = Color.LimeGreen
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "serving"
                    e.CellStyle.BackColor = Color.Blue
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "waiting"
                    e.CellStyle.BackColor = Color.Orange
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "cancelled"
                    e.CellStyle.BackColor = Color.Red
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "no-show"
                    e.CellStyle.BackColor = Color.Gray
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "scheduled"
                    e.CellStyle.BackColor = Color.Purple
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "expired"
                    e.CellStyle.BackColor = Color.DarkGray
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
            End Select
        End If
    End Sub

    Private Sub dgvAllQueues_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvAllQueues.CellFormatting
        If e.ColumnIndex = dgvAllQueues.Columns("Status").Index AndAlso e.Value IsNot Nothing Then
            Dim status As String = e.Value.ToString()

            ' Check if the row is selected
            Dim isSelected As Boolean = False
            If e.RowIndex >= 0 AndAlso e.RowIndex < dgvAllQueues.Rows.Count Then
                isSelected = dgvAllQueues.Rows(e.RowIndex).Selected
            End If

            Select Case status
                Case "completed"
                    e.CellStyle.BackColor = Color.Green
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "serving"
                    e.CellStyle.BackColor = Color.Blue
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "waiting"
                    e.CellStyle.BackColor = Color.Orange
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "cancelled"
                    e.CellStyle.BackColor = Color.Red
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "no-show"
                    e.CellStyle.BackColor = Color.Gray
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "scheduled"
                    e.CellStyle.BackColor = Color.Purple
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "expired"
                    e.CellStyle.BackColor = Color.DarkGray
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
            End Select
        End If
    End Sub

    Private Sub dgvCashierStatus_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCashierStatus.CellFormatting
        If e.ColumnIndex = dgvCashierStatus.Columns("Status").Index AndAlso e.Value IsNot Nothing Then
            Dim status As String = e.Value.ToString()

            ' Check if the row is selected
            Dim isSelected As Boolean = False
            If e.RowIndex >= 0 AndAlso e.RowIndex < dgvCashierStatus.Rows.Count Then
                isSelected = dgvCashierStatus.Rows(e.RowIndex).Selected
            End If

            Select Case status.ToLower()
                Case "open"
                    e.CellStyle.BackColor = Color.Green
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "offline"
                    e.CellStyle.BackColor = Color.Gray
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case "break"
                    e.CellStyle.BackColor = Color.Orange
                    e.CellStyle.ForeColor = Color.White
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
                Case Else
                    e.CellStyle.BackColor = Color.LightBlue
                    e.CellStyle.ForeColor = Color.Black
                    If isSelected Then
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                        e.CellStyle.SelectionForeColor = Color.White
                    End If
            End Select
        End If
    End Sub

    Private Sub tabUserManagement_SelectedIndexChanged(sender As Object, e As EventArgs)
        lblNoResultsFound.Visible = False
        btnAddNewStudent.Visible = True

        If tabUserManagement.SelectedTab Is tpWithAccount Then
            btnAddUser.Visible = False
            btnEditUser.Visible = True
            btnDeleteUser.Visible = True
            btnDeleteStudent.Visible = False
        ElseIf tabUserManagement.SelectedTab Is tpWithoutAccount Then
            btnAddUser.Visible = True
            btnEditUser.Visible = False
            btnDeleteUser.Visible = False
            btnDeleteStudent.Visible = True
        End If
        If Not String.IsNullOrEmpty(txtSearchUsers.Text) Then
            txtSearchUsers_TextChanged(txtSearchUsers, EventArgs.Empty)
        End If
    End Sub


    Private Sub btnAddNewStudent_Click(sender As Object, e As EventArgs)

        Using frm As New frmAddStudent()
            If frm.ShowDialog() = DialogResult.OK Then
                FetchUsers()
            End If
        End Using
    End Sub

    Private Sub btnDeleteStudent_Click(sender As Object, e As EventArgs)
        If dgvUsersWithoutAccount.SelectedRows.Count > 0 Then
            Dim selectedUser As User = CType(dgvUsersWithoutAccount.SelectedRows(0).DataBoundItem, User)

            ' Confirm deletion
            Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete the student record for '{selectedUser.FullName}'?{vbCrLf}{vbCrLf}" &
            $"Student Number: {selectedUser.StudentNo}{vbCrLf}{vbCrLf}" &
            "⚠️ WARNING: This will permanently delete the student record and all associated data!",
            "Confirm Student Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2)

            If result = DialogResult.Yes Then
                ' Call the DeleteStudent function from DatabaseHelper
                Dim success As Boolean = DatabaseHelper.DeleteStudent(selectedUser.StudentNo)

                If success Then
                    MessageBox.Show(
                    $"Student '{selectedUser.FullName}' has been successfully deleted.",
                    "Student Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
                    FetchUsers()
                Else
                    MessageBox.Show(
                    "Failed to delete the student record. The student may not exist or there was a database error.",
                    "Deletion Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show(
            "Please select a student from the 'Without Account' tab to delete.",
            "No Student Selected",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
        End If
    End Sub


End Class




Public Class CashierStatusItem
    Public Property CashierName As String
    Public Property Status As String
    Public Property Counter As String
End Class

Public Class QueueLogItem
    Public Property QueueNumber As String
    Public Property FullName As String
    Public Property StudentNo As String
    Public Property Counter As String
    Public Property Status As String
End Class

Public Class QueueLogAdminItem
    Public Property QueueID As Integer
    Public Property QueueNumber As String
    Public Property FullName As String
    Public Property Status As String
    Public Property CreatedAt As String
End Class

Public Class User
    Public Property UserID As Integer
    Public Property StudentID As Integer
    Public Property FullName As String
    Public Property Username As String
    Public Property StudentNo As String
    Public Property Role As String
    Public Property LastLogin As String
    Public Property LastSession As String
    Public Property LastQueueDateTime As String
    Public Property Course As String
    Public Property YearLevel As String
End Class

Public Class Counter
    Public Property CounterID As Integer
    Public Property CounterName As String
    Public Property Cashier As String
End Class