﻿Imports MySql.Data.MySqlClient
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

    Public Shared Function AuthenticateWithStoredProcedure(username As String, password As String) As DataRow
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand("sp_get_user_by_username", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@p_username", username)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        If dt.Rows.Count > 0 Then
                            Dim row As DataRow = dt.Rows(0)

                            If Convert.ToBoolean(row("is_locked")) Then
                                MessageBox.Show("Your account is locked. Please contact the administrator.",
                                              "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return Nothing
                            End If

                            If Not Convert.ToBoolean(row("is_active")) Then
                                MessageBox.Show("Your account is inactive. Please contact the administrator.",
                                              "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return Nothing
                            End If

                            Dim storedHash As String = row("password_hash").ToString()
                            If BCrypt.Net.BCrypt.Verify(password, storedHash) Then
                                Return row
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error during authentication: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing
    End Function

    Public Shared Sub UpdateLastLogin(username As String, userType As String, ipAddress As String)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand("sp_update_last_login", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@p_username", username)
                    cmd.Parameters.AddWithValue("@p_user_type", userType)
                    cmd.Parameters.AddWithValue("@p_ip_address", ipAddress)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error updating last login: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub RecordLoginAttempt(username As String, userType As String, userId As Object, success As Boolean, ipAddress As String, userAgent As String, notes As String)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand("sp_record_login_attempt", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@p_username", username)
                    cmd.Parameters.AddWithValue("@p_user_type", userType)
                    cmd.Parameters.AddWithValue("@p_user_id", If(userId, DBNull.Value))
                    cmd.Parameters.AddWithValue("@p_success", success)
                    cmd.Parameters.AddWithValue("@p_ip_address", ipAddress)
                    cmd.Parameters.AddWithValue("@p_user_agent", userAgent)
                    cmd.Parameters.AddWithValue("@p_notes", notes)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Failed to record login attempt: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub UpdateFailedAttempts(username As String, userType As String, attempts As Integer)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand("sp_update_failed_attempts", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@p_username", username)
                    cmd.Parameters.AddWithValue("@p_user_type", userType)
                    cmd.Parameters.AddWithValue("@p_attempts", attempts)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Failed to update failed attempts: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub CreateLockout(username As String, userType As String, userId As Object, failedAttempts As Integer, lockoutMinutes As Integer, ipAddress As String)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand("sp_create_lockout", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@p_username", username)
                    cmd.Parameters.AddWithValue("@p_user_type", userType)
                    cmd.Parameters.AddWithValue("@p_user_id", If(userId, DBNull.Value))
                    cmd.Parameters.AddWithValue("@p_failed_attempts", failedAttempts)
                    cmd.Parameters.AddWithValue("@p_lockout_minutes", lockoutMinutes)
                    cmd.Parameters.AddWithValue("@p_ip_address", ipAddress)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Failed to create lockout: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub ClearLockout(username As String)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand("sp_clear_lockout", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@p_username", username)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Failed to clear lockout: " & ex.Message)
        End Try
    End Sub

    Public Shared Function CheckActiveLockout(username As String) As DataRow
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand("sp_check_active_lockout", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@p_username", username)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        If dt.Rows.Count > 0 Then
                            Return dt.Rows(0)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error checking active lockout: " & ex.Message)
        End Try

        Return Nothing
    End Function

    Public Shared Function GetProgressiveLockoutDuration(username As String) As Integer
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand("sp_get_lockout_duration", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@p_username", username)

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error getting progressive lockout duration: " & ex.Message)
        End Try

        Return 5
    End Function

    Public Shared Function GetUserType(username As String) As String
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim query As String = "SELECT 'admin' AS type FROM admins WHERE username = @username " &
                                    "UNION SELECT 'cashier' AS type FROM cashiers WHERE username = @username LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error getting user type: " & ex.Message)
        End Try

        Return "unknown"
    End Function

    Public Shared Function GetUserId(username As String, userType As String) As Integer?
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim query As String = ""
                If userType = "admin" Then
                    query = "SELECT admin_id FROM admins WHERE username = @username"
                ElseIf userType = "cashier" Then
                    query = "SELECT cashier_id FROM cashiers WHERE username = @username"
                End If

                If Not String.IsNullOrEmpty(query) Then
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@username", username)
                        Dim result = cmd.ExecuteScalar()
                        If result IsNot Nothing Then
                            Return Convert.ToInt32(result)
                        End If
                    End Using
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine("Error getting user ID: " & ex.Message)
        End Try

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

    Public Shared Function AddStudent(firstName As String, lastName As String, studentNo As String, course As String, yearLevel As String, Optional email As String = "") As Boolean
        Using conn As MySqlConnection = GetConnection()
            Try
                conn.Open()
                Dim number_with_c As String = studentNo.Trim()
                Dim number_without_c As String = studentNo.Trim()

                If Not studentNo.Trim().StartsWith("C", StringComparison.OrdinalIgnoreCase) Then
                    number_with_c = "C" & studentNo.Trim()
                Else
                    number_without_c = studentNo.Trim().Substring(1)
                End If

                Dim checkQuery As String = "SELECT COUNT(*) FROM students WHERE student_number = @num1 OR student_number = @num2"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@num1", number_with_c)
                    checkCmd.Parameters.AddWithValue("@num2", number_without_c)
                    Dim count As Long = Convert.ToInt64(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        Return False
                    End If
                End Using

                Dim insertQuery As String = "INSERT INTO students (first_name, last_name, student_number, course, year_level, email, created_at) VALUES (@firstName, @lastName, @studentNo, @course, @yearLevel, @email, NOW())"
                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@firstName", firstName)
                    cmd.Parameters.AddWithValue("@lastName", lastName)
                    cmd.Parameters.AddWithValue("@studentNo", studentNo.Trim())
                    cmd.Parameters.AddWithValue("@course", course)
                    cmd.Parameters.AddWithValue("@yearLevel", yearLevel)
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(email), DBNull.Value, email.Trim()))

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return (rowsAffected > 0)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error adding student: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Shared Function DeleteStudent(studentNumber As String) As Boolean
        Using conn As MySqlConnection = GetConnection()
            Try
                Dim number_with_c As String = studentNumber.Trim()
                Dim number_without_c As String = studentNumber.Trim()

                If Not studentNumber.Trim().StartsWith("C", StringComparison.OrdinalIgnoreCase) Then
                    number_with_c = "C" & studentNumber.Trim()
                Else
                    number_without_c = studentNumber.Trim().Substring(1)
                End If

                conn.Open()
                Dim query As String = "DELETE FROM students WHERE student_number = @num1 OR student_number = @num2"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@num1", number_with_c)
                    cmd.Parameters.AddWithValue("@num2", number_without_c)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return (rowsAffected > 0)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting student: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

End Class