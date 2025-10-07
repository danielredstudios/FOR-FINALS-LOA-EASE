Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim userRow As DataRow = DatabaseHelper.Authenticate(username, password)

        If userRow IsNot Nothing Then
            Dim role As String = userRow("role").ToString()
            Dim fullName As String = userRow("full_name").ToString()

            If role = "admin" Then
                Dim adminDashboard As New frmAdminDashboard(fullName)
                adminDashboard.Show()
                Me.Hide()
            ElseIf role = "cashier" Then
                Dim counterId As Integer
                If userRow("counter_id") IsNot DBNull.Value AndAlso Integer.TryParse(userRow("counter_id").ToString(), counterId) Then
                    ' We need the cashier_id which should be in the userRow
                    Dim cashierId As Integer
                    If userRow("cashier_id") IsNot DBNull.Value AndAlso Integer.TryParse(userRow("cashier_id").ToString(), cashierId) Then

                        ' Set the cashier's status to online and ready to accept queue
                        Try
                            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                                conn.Open()
                                Dim query As String = "UPDATE counter_schedules SET is_open = 1, status = 'open' WHERE counter_id = @counterId"
                                Using cmd As New MySqlCommand(query, conn)
                                    cmd.Parameters.AddWithValue("@counterId", counterId)
                                    cmd.ExecuteNonQuery()
                                End Using
                            End Using
                        Catch ex As Exception
                            MessageBox.Show("Could not update cashier status on login: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End Try

                        ' Use the fullName as cashierFullName
                        Dim cashierDashboard As New frmCashierDashboard(cashierId, counterId, fullName)
                        cashierDashboard.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Could not log in as cashier due to an invalid Cashier ID from the database.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Could not log in as cashier due to an invalid Counter ID from the database.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
End Class