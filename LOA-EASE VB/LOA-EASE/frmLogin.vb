Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmLogin
    ' Login attempt tracking
    Private Const MAX_ATTEMPTS As Integer = 3
    Private loginAttempts As Integer = 0
    Private isAccountLocked As Boolean = False
    Private lockoutEndTime As DateTime = DateTime.MinValue

    ' Animation variables
    Private cardOpacity As Integer = 200
    Private fadeDirection As Integer = -5

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize UI
        pnlAttempts.Visible = False

        ' Add rounded corners effect to panels
        AddRoundedCorners(pnlLoginContainer, 15)
        AddRoundedCorners(pnlUsernameContainer, 8)
        AddRoundedCorners(pnlPasswordContainer, 8)
        AddRoundedCorners(btnLogin, 8)
        AddRoundedCorners(pnlFloatingCard, 12)
        AddRoundedCorners(pnlAttempts, 8)
        FadeTimer.Start()
        CheckAccountLockout()
    End Sub

    Private Sub AddRoundedCorners(ctrl As Control, radius As Integer)
        ctrl.Region = New Region(GetRoundedRectangle(ctrl.ClientRectangle, radius))
    End Sub

    Private Function GetRoundedRectangle(bounds As Rectangle, radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90)
        path.AddArc(bounds.Right - radius, bounds.Top, radius, radius, 270, 90)
        path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(bounds.Left, bounds.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function



    Private Sub CheckAccountLockout()
        ' Check if account is currently locked
        If isAccountLocked AndAlso DateTime.Now < lockoutEndTime Then
            Dim remainingTime As TimeSpan = lockoutEndTime - DateTime.Now
            DisableLogin(CInt(Math.Ceiling(remainingTime.TotalSeconds)))
        ElseIf isAccountLocked AndAlso DateTime.Now >= lockoutEndTime Then
            ' Lockout expired
            ResetAttempts()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Check if account is locked
        If isAccountLocked Then
            CheckAccountLockout()
            If isAccountLocked Then
                MessageBox.Show("Account is temporarily locked. Please try again later.",
                              "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.",
                          "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Show loading state
        btnLogin.Enabled = False
        btnLogin.Text = "Signing In..."
        Application.DoEvents()

        Try
            Dim userRow As DataRow = DatabaseHelper.Authenticate(username, password)

            If userRow IsNot Nothing Then
                ' Successful login
                ResetAttempts()

                Dim role As String = userRow("role").ToString()
                Dim fullName As String = userRow("full_name").ToString()

                If role = "admin" Then
                    Dim adminDashboard As New frmAdminDashboard(fullName)
                    adminDashboard.Show()
                    Me.Hide()
                ElseIf role = "cashier" Then
                    HandleCashierLogin(userRow, fullName)
                End If
            Else
                ' Failed login attempt
                HandleFailedLogin(username)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred during login: " & ex.Message,
                          "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnLogin.Enabled = True
            btnLogin.Text = "Sign In"
        End Try
    End Sub

    Private Sub HandleCashierLogin(userRow As DataRow, fullName As String)
        Dim counterId As Integer
        If userRow("counter_id") IsNot DBNull.Value AndAlso
           Integer.TryParse(userRow("counter_id").ToString(), counterId) Then

            Dim cashierId As Integer
            If userRow("cashier_id") IsNot DBNull.Value AndAlso
               Integer.TryParse(userRow("cashier_id").ToString(), cashierId) Then

                ' Update cashier status
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
                    MessageBox.Show("Could not update cashier status: " & ex.Message,
                                  "Status Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try

                Dim cashierDashboard As New frmCashierDashboard(cashierId, counterId, fullName)
                cashierDashboard.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid Cashier ID from database.",
                              "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid Counter ID from database.",
                          "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub HandleFailedLogin(username As String)
        loginAttempts += 1
        Dim remainingAttempts As Integer = MAX_ATTEMPTS - loginAttempts

        If loginAttempts >= MAX_ATTEMPTS Then
            ' Lock the account
            LockAccount(username)
        Else
            ' Show warning with remaining attempts
            ShowAttemptsWarning(remainingAttempts)

            MessageBox.Show($"Invalid username or password.{vbCrLf}You have {remainingAttempts} attempt(s) remaining.",
                          "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LockAccount(username As String)
        isAccountLocked = True
        lockoutEndTime = DateTime.Now.AddMinutes(5) ' 5-minute lockout

        ' Log lockout event
        LogLoginAttempt(username, False, "Account locked due to multiple failed attempts")

        ' Disable login controls
        DisableLogin(300) ' 300 seconds = 5 minutes

        MessageBox.Show("Too many failed login attempts. Your account has been temporarily locked for 5 minutes.",
                      "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub DisableLogin(seconds As Integer)
        txtUsername.Enabled = False
        txtPassword.Enabled = False
        btnLogin.Enabled = False
        chkShowPassword.Enabled = False

        pnlAttempts.BackColor = Color.FromArgb(CByte(248), CByte(215), CByte(218))
        lblAttemptsInfo.ForeColor = Color.FromArgb(CByte(114), CByte(28), CByte(36))
        lblAttemptsInfo.Text = $"🔒 Account locked. Try again in {TimeSpan.FromSeconds(seconds).TotalMinutes:F0} minutes"
        pnlAttempts.Visible = True

        ' Start countdown timer
        Dim countdownTimer As New Timer()
        countdownTimer.Interval = 1000
        countdownTimer.Tag = seconds

        AddHandler countdownTimer.Tick, Sub(s, e)
                                            Dim remaining As Integer = CInt(countdownTimer.Tag) - 1
                                            countdownTimer.Tag = remaining

                                            If remaining > 0 Then
                                                Dim minutes As Integer = remaining \ 60
                                                Dim secs As Integer = remaining Mod 60
                                                lblAttemptsInfo.Text = $"🔒 Account locked. Try again in {minutes}:{secs:D2}"
                                            Else
                                                countdownTimer.Stop()
                                                ResetAttempts()
                                            End If
                                        End Sub

        countdownTimer.Start()
    End Sub

    Private Sub ShowAttemptsWarning(remainingAttempts As Integer)
        pnlAttempts.BackColor = Color.FromArgb(CByte(255), CByte(243), CByte(205))
        lblAttemptsInfo.ForeColor = Color.FromArgb(CByte(133), CByte(100), CByte(4))

        If remainingAttempts = 1 Then
            lblAttemptsInfo.Text = "⚠ Warning: 1 attempt remaining before lockout!"
        Else
            lblAttemptsInfo.Text = $"⚠ {remainingAttempts} attempts remaining"
        End If

        pnlAttempts.Visible = True
    End Sub

    Private Sub ResetAttempts()
        loginAttempts = 0
        isAccountLocked = False
        lockoutEndTime = DateTime.MinValue
        pnlAttempts.Visible = False

        txtUsername.Enabled = True
        txtPassword.Enabled = True
        btnLogin.Enabled = True
        chkShowPassword.Enabled = True
    End Sub

    Private Sub LogLoginAttempt(username As String, success As Boolean, Optional notes As String = "")
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                conn.Open()

                Dim query As String = "INSERT INTO login_attempts (username, success, attempt_time, ip_address, notes) " &
                                    "VALUES (@username, @success, @attemptTime, @ipAddress, @notes)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@success", success)
                    cmd.Parameters.AddWithValue("@attemptTime", DateTime.Now)
                    cmd.Parameters.AddWithValue("@ipAddress", GetLocalIPAddress())
                    cmd.Parameters.AddWithValue("@notes", notes)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Silently fail - don't interrupt login process
            Console.WriteLine("Failed to log login attempt: " & ex.Message)
        End Try
    End Sub

    Private Function GetLocalIPAddress() As String
        Try
            Dim host As Net.IPHostEntry = Net.Dns.GetHostEntry(Net.Dns.GetHostName())
            For Each ip As Net.IPAddress In host.AddressList
                If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
        Catch ex As Exception
            Return "Unknown"
        End Try
        Return "Unknown"
    End Function

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    Private Sub lblForgotPassword_Click(sender As Object, e As EventArgs) Handles lblForgotPassword.Click
        MessageBox.Show("Please contact your system administrator to reset your password.",
                      "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnLogin.PerformClick()
        End If
    End Sub

    ' Hover effects for button
    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        If btnLogin.Enabled Then
            btnLogin.BackColor = Color.FromArgb(CByte(10), CByte(60), CByte(140))
        End If
    End Sub

    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
    End Sub

    Private Sub lblForgotPassword_MouseEnter(sender As Object, e As EventArgs) Handles lblForgotPassword.MouseEnter
        lblForgotPassword.Font = New Font(lblForgotPassword.Font, FontStyle.Underline)
    End Sub

    Private Sub lblForgotPassword_MouseLeave(sender As Object, e As EventArgs) Handles lblForgotPassword.MouseLeave
        lblForgotPassword.Font = New Font(lblForgotPassword.Font, FontStyle.Regular)
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        FadeTimer.Stop()
    End Sub
End Class