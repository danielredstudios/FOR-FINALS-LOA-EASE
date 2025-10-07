Imports MySql.Data.MySqlClient
Imports System.Data

Public Class DatabaseHelper
    Private Shared ReadOnly ConnectionString As String = "Server=localhost;Database=loa_ease_queuing_experiemental;User ID=root;Password=;"

    Public Shared Function GetConnectionString() As String
        Return ConnectionString
    End Function

    Public Shared Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnectionString)
    End Function

    Public Shared Function Authenticate(username As String, password As String) As DataRow
        Using conn As New MySqlConnection(ConnectionString)
            Try
                conn.Open()
                Dim adminQuery As String = "SELECT 'admin' as role, admin_id, password_hash, full_name, NULL as counter_id, NULL as counter_name FROM admins WHERE username = @username"
                Dim adminCmd As New MySqlCommand(adminQuery, conn)
                adminCmd.Parameters.AddWithValue("@username", username)
                Dim adminAdapter As New MySqlDataAdapter(adminCmd)
                Dim adminDt As New DataTable()
                adminAdapter.Fill(adminDt)

                If adminDt.Rows.Count > 0 Then
                    Dim adminRow As DataRow = adminDt.Rows(0)
                    Dim adminPasswordHash As String = adminRow("password_hash").ToString()
                    If BCrypt.Net.BCrypt.Verify(password, adminPasswordHash) Then
                        Return adminRow
                    End If
                End If

                Dim cashierQuery As String = "SELECT c.role, c.cashier_id, c.password_hash, c.full_name, co.counter_id, co.counter_name FROM cashiers c JOIN counters co ON c.counter_id = co.counter_id WHERE c.username = @username"
                Dim cashierCmd As New MySqlCommand(cashierQuery, conn)
                cashierCmd.Parameters.AddWithValue("@username", username)
                Dim cashierAdapter As New MySqlDataAdapter(cashierCmd)
                Dim cashierDt As New DataTable()
                cashierAdapter.Fill(cashierDt)

                If cashierDt.Rows.Count > 0 Then
                    Dim cashierRow As DataRow = cashierDt.Rows(0)
                    Dim cashierPasswordHash As String = cashierRow("password_hash").ToString()
                    If BCrypt.Net.BCrypt.Verify(password, cashierPasswordHash) Then
                        Return cashierRow
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred during authentication: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return Nothing
    End Function

    Public Shared Function GetCashierStatus() As DataTable
        Using conn As New MySqlConnection(ConnectionString)
            Dim dt As New DataTable()
            Try
                conn.Open()
                Dim query As String = "SELECT c.full_name, co.counter_name, cs.is_open, cs.status FROM cashiers c JOIN counters co ON c.counter_id = co.counter_id LEFT JOIN counter_schedules cs ON c.counter_id = cs.counter_id WHERE c.role = 'cashier' ORDER BY co.counter_name"
                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            Catch ex As Exception
                MessageBox.Show("An error occurred while fetching cashier status: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return dt
        End Using
    End Function

    Public Shared Function GetAllQueues() As DataTable
        Using conn As New MySqlConnection(ConnectionString)
            Dim dt As New DataTable()
            Try
                conn.Open()
                Dim query As String = "SELECT q.queue_number AS `Queue #`, COALESCE(CONCAT(s.first_name, ' ', s.last_name), v.full_name) AS Name, q.purpose AS Purpose, q.status AS Status, co.counter_name AS Counter FROM queues q LEFT JOIN students s ON q.student_id = s.student_id LEFT JOIN visitors v ON q.visitor_id = v.visitor_id JOIN counters co ON q.counter_id = co.counter_id WHERE DATE(q.created_at) = CURDATE() ORDER BY q.created_at DESC"
                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            Catch ex As Exception
                MessageBox.Show("An error occurred while fetching all queues: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return dt
        End Using
    End Function

    Public Shared Function GetStudentInfo(studentNumber As String) As DataRow
        Using conn As New MySqlConnection(ConnectionString)
            Try
                Dim number_with_c As String = studentNumber
                Dim number_without_c As String = studentNumber

                If Not studentNumber.StartsWith("C", StringComparison.OrdinalIgnoreCase) Then
                    number_with_c = "C" & studentNumber
                Else
                    number_without_c = studentNumber.Substring(1)
                End If

                conn.Open()
                Dim query As String = "SELECT last_name, first_name, course FROM students WHERE student_number = @num1 OR student_number = @num2"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@num1", number_with_c)
                cmd.Parameters.AddWithValue("@num2", number_without_c)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return Nothing
    End Function
End Class