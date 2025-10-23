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
        Using conn As MySqlConnection = GetConnection()
            Try
                conn.Open()

                ' --- MODIFIED QUERY ---
                ' Added 'BINARY' before username and c.username to enforce
                ' case-sensitivity in the WHERE clauses.
                Dim query As String = "
                    (SELECT admin_id, username, password_hash, full_name, 'admin' AS role, 
                            NULL AS counter_id, NULL AS cashier_id, NULL as counter_name 
                     FROM admins 
                     WHERE BINARY username = @username)
                    
                    UNION
                    
                    (SELECT c.cashier_id, c.username, c.password_hash, c.full_name, c.role, 
                            c.counter_id, c.cashier_id, co.counter_name 
                     FROM cashiers c
                     JOIN counters co ON c.counter_id = co.counter_id
                     WHERE BINARY c.username = @username AND c.role = 'cashier')
                "
                ' --- END OF MODIFICATION ---

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Dim dt As New DataTable()
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using

                    If dt.Rows.Count > 0 Then
                        Dim userRow As DataRow = dt.Rows(0)
                        Dim storedHash As String = userRow("password_hash").ToString()

                        If BCrypt.Net.BCrypt.Verify(password, storedHash) Then
                            Return userRow
                        End If
                    End If

                End Using
            Catch ex As Exception
                MessageBox.Show("Error during authentication: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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