Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Data

Public Class frmAdminDashboard
    Private ReadOnly _adminFullName As String
    Private _activeButton As Button

    Public Sub New(adminFullName As String)
        InitializeComponent()
        _adminFullName = adminFullName
    End Sub

    Private Sub frmAdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = $"Welcome, {_adminFullName}"
        SetupDataGridViews()
        RefreshAllData()

        tmrRefresh.Interval = 5000
        AddHandler tmrRefresh.Tick, AddressOf tmrRefresh_Tick
        tmrRefresh.Start()

        ShowPanel(pnlDashboard, btnDashboard)
    End Sub

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs)
        If pnlDashboard.Visible Then
            RefreshAllData()
        ElseIf pnlUserManagement.Visible Then
            FetchUsers()
        ElseIf pnlCounterManagement.Visible Then
            FetchCounters()
        ElseIf pnlQueueLogs.Visible Then
            FetchAllQueueLogs()
        End If
    End Sub

    Private Sub SetupDataGridViews()
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

        dgvQueueLogs.AutoGenerateColumns = False
        dgvQueueLogs.Columns.Clear()
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "QueueNumber",
        .HeaderText = "Queue No.",
        .DataPropertyName = "QueueNumber"
    })
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "FullName",
        .HeaderText = "Full Name",
        .DataPropertyName = "FullName"
     })
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Status",
        .HeaderText = "Status",
        .DataPropertyName = "Status"
    })
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "CreatedAt",
        .HeaderText = "Date Created",
        .DataPropertyName = "CreatedAt"
    })

        dgvUsers.AutoGenerateColumns = False
        dgvUsers.Columns.Clear()
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "FullName",
         .HeaderText = "Full Name",
        .DataPropertyName = "FullName"
    })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Username",
         .HeaderText = "Username",
        .DataPropertyName = "Username"
    })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "StudentNo",
        .HeaderText = "Student No.",
        .DataPropertyName = "StudentNo"
    })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "Role",
        .HeaderText = "Role",
        .DataPropertyName = "Role"
    })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "LastLogin",
        .HeaderText = "Last Login",
        .DataPropertyName = "LastLogin"
    })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "LastSession",
        .HeaderText = "Last Session",
        .DataPropertyName = "LastSession"
    })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "LastQueueDateTime",
        .HeaderText = "Last Queue",
        .DataPropertyName = "LastQueueDateTime"
    })

        dgvCounters.AutoGenerateColumns = False
        dgvCounters.Columns.Clear()
        dgvCounters.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "CounterName",
        .HeaderText = "Counter Name",
        .DataPropertyName = "CounterName"
    })
        dgvCounters.Columns.Add(New DataGridViewTextBoxColumn With {
        .Name = "AssignedCashier",
        .HeaderText = "Assigned Cashier",
        .DataPropertyName = "AssignedCashier"
    })
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
            Catch ex As Exception
                HandleDbError("fetching all queues", ex)
            End Try
        End Using
    End Sub

    Private Sub FetchAllQueueLogs()
        Dim queueLogList As New BindingList(Of QueueLogAdminItem)()
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
                ORDER BY q.created_at DESC"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            queueLogList.Add(New QueueLogAdminItem With {
                                .QueueID = Convert.ToInt32(reader("queue_id")),
                                .QueueNumber = reader("queue_number").ToString(),
                                .FullName = reader("FullName").ToString(),
                                .Status = reader("status").ToString(),
                                .CreatedAt = Convert.ToDateTime(reader("created_at")).ToString("g")
                            })
                        End While
                    End Using
                End Using
                dgvQueueLogs.DataSource = queueLogList
                lblQueueLogsTotal.Text = $"(Total: {queueLogList.Count})"
            Catch ex As Exception
                HandleDbError("fetching queue logs", ex)
            End Try
        End Using
    End Sub

    Private Sub FetchUsers()
        Dim userList As New BindingList(Of User)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                SELECT
                    u.user_id,
                    u.username,
                    u.last_login,
                    u.created_at,
                    s.student_number,
                    CASE
                        WHEN u.student_id IS NOT NULL THEN 'Student'
                        WHEN u.guardian_id IS NOT NULL THEN 'Guardian'
                        ELSE 'Other'
                    END AS role,
                    COALESCE(CONCAT(s.first_name, ' ', s.last_name), g.full_name, 'N/A') AS full_name,
                    q.last_queue_time
                FROM
                    users u
                LEFT JOIN
                    students s ON u.student_id = s.student_id
                LEFT JOIN
                    guardians g ON u.guardian_id = g.guardian_id
                LEFT JOIN
                    (SELECT student_id, MAX(created_at) AS last_queue_time FROM queues GROUP BY student_id) q ON u.student_id = q.student_id"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            userList.Add(New User With {
                                .UserID = Convert.ToInt32(reader("user_id")),
                                .FullName = reader("full_name").ToString(),
                                .Username = reader("username").ToString(),
                                .StudentNo = If(reader.IsDBNull(reader.GetOrdinal("student_number")), "N/A", reader("student_number").ToString()),
                                .Role = reader("role").ToString(),
                                .LastLogin = If(reader("last_login") IsNot DBNull.Value, Convert.ToDateTime(reader("last_login")).ToString("g"), "N/A"),
                                .LastSession = If(reader("created_at") IsNot DBNull.Value, Convert.ToDateTime(reader("created_at")).ToString("g"), "N/A"),
                                .LastQueueDateTime = If(reader("last_queue_time") IsNot DBNull.Value, Convert.ToDateTime(reader("last_queue_time")).ToString("g"), "N/A")
                            })
                        End While
                    End Using
                End Using
                dgvUsers.DataSource = userList
                lblUsersTotal.Text = $"(Total: {userList.Count})"
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
                    COALESCE(ch.full_name, 'N/A') AS assigned_cashier
                FROM counters c
                LEFT JOIN cashiers ch ON c.counter_id = ch.counter_id
                ORDER BY c.counter_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            counterList.Add(New Counter With {
                                .CounterID = Convert.ToInt32(reader("counter_id")),
                                .CounterName = reader("counter_name").ToString(),
                                .AssignedCashier = reader("assigned_cashier").ToString()
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
        Me.Close()
        Dim frmLogin As New frmLogin()
        frmLogin.Show()
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Using frm As New frmAddEditUser()
            If frm.ShowDialog() = DialogResult.OK Then
                FetchUsers()
            End If
        End Using
    End Sub

    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedUser As User = CType(dgvUsers.SelectedRows(0).DataBoundItem, User)
            Using frm As New frmAddEditUser(selectedUser.UserID, selectedUser.FullName, selectedUser.Username, selectedUser.Role)
                If frm.ShowDialog() = DialogResult.OK Then
                    FetchUsers()
                End If
            End Using
        Else
            MessageBox.Show("Please select a user to edit.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedUser As User = CType(dgvUsers.SelectedRows(0).DataBoundItem, User)
            If MessageBox.Show($"Are you sure you want to delete the user '{selectedUser.FullName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                    Try
                        conn.Open()
                        Dim query As String = "DELETE FROM users WHERE user_id = @userId"

                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@userId", selectedUser.UserID)
                            Dim result = cmd.ExecuteNonQuery()

                            If result > 0 Then
                                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                FetchUsers()
                            Else
                                MessageBox.Show("Could not find the user to delete. The list will be refreshed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                FetchUsers()
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show($"Error deleting user: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Please select a user to delete.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Using frm As New frmAddEditCounter(selectedCounter.CounterID, selectedCounter.CounterName, selectedCounter.AssignedCashier)
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
            Dim selectedQueue As QueueLogAdminItem = CType(dgvQueueLogs.SelectedRows(0).DataBoundItem, QueueLogAdminItem)

            Using statusForm As New Form()
                statusForm.Text = "Change Queue Status"
                statusForm.StartPosition = FormStartPosition.CenterParent
                statusForm.FormBorderStyle = FormBorderStyle.FixedDialog
                statusForm.ClientSize = New Size(250, 150)

                Dim lbl As New Label()
                lbl.Text = $"Change status for {selectedQueue.QueueNumber}:"
                lbl.Location = New Point(10, 10)
                lbl.AutoSize = True
                statusForm.Controls.Add(lbl)

                Dim cboStatus As New ComboBox()
                cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
                cboStatus.Items.AddRange(New String() {"waiting", "serving", "completed", "cancelled", "no-show", "scheduled", "expired"})
                cboStatus.SelectedItem = selectedQueue.Status
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
                                cmd.Parameters.AddWithValue("@queueId", selectedQueue.QueueID)
                                cmd.ExecuteNonQuery()
                            End Using
                            FetchAllQueueLogs()
                        Catch ex As Exception
                            MessageBox.Show($"Error updating status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Using
                End If
            End Using
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
                        Dim updateQuery As String = "UPDATE cashiers SET counter_id = NULL WHERE counter_id = @counterId"
                        Using cmd As New MySqlCommand(updateQuery, conn, transaction)
                            cmd.Parameters.AddWithValue("@counterId", selectedCounter.CounterID)
                            cmd.ExecuteNonQuery()
                        End Using

                        Dim deleteQuery As String = "DELETE FROM counters WHERE counter_id = @counterId"
                        Using cmd As New MySqlCommand(deleteQuery, conn, transaction)
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
    Public Property FullName As String
    Public Property Username As String
    Public Property StudentNo As String
    Public Property Role As String
    Public Property LastLogin As String
    Public Property LastSession As String
    Public Property LastQueueDateTime As String
End Class

Public Class Counter
    Public Property CounterID As Integer
    Public Property CounterName As String
    Public Property AssignedCashier As String
End Class