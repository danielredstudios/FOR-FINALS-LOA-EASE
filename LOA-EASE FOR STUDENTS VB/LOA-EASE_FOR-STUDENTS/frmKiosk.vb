Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Media

Public Class frmKiosk

    Private selectedCounterId As Integer = -1
    Private selectedTimeSlot As String = ""
    Private selectedCounterName As String = ""
    Private selectedCashierName As String = ""
    Private selectedDateTime As DateTime
    Private studentId As Integer = -1
    Private isVisitorMode As Boolean = False
    Private WithEvents tmrResetView As New Timer()
    Private resetStep As Integer = 0
    Private soundPlayer As New SoundPlayer()

    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(hwnd As IntPtr, attr As Integer, ByRef attrValue As Integer, attrSize As Integer) As Integer
    End Function

    Private Const DWMWA_USE_IMMERSIVE_DARK_MODE As Integer = 20

    Private Sub frmKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGetTicket.Enabled = False
        gbDocumentRequest.Visible = False
        tcKiosk.Appearance = TabAppearance.FlatButtons
        tcKiosk.ItemSize = New Size(0, 1)
        tcKiosk.SizeMode = TabSizeMode.Fixed
        Me.ResizeRedraw = True
        ApplyRoundedCorners()
        LoadSoundFile()
        CenterPanel()
    End Sub

    Private Sub frmKiosk_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If soundPlayer IsNot Nothing Then
            soundPlayer.Dispose()
        End If
    End Sub

    Private Sub LoadSoundFile()
        Try
            Dim soundPath As String = System.IO.Path.Combine(Application.StartupPath, "Notification-Kiosk.wav")
            If System.IO.File.Exists(soundPath) Then
                soundPlayer.SoundLocation = soundPath
                soundPlayer.Load()
            Else
                MessageBox.Show($"Sound file not found at: {soundPath}", "Sound File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading sound file: " & ex.Message, "Sound Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub PlayNotificationSound()
        Try
            If Not String.IsNullOrEmpty(soundPlayer.SoundLocation) Then
                soundPlayer.Play()
            End If
        Catch ex As Exception
            Debug.WriteLine("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Private Sub ApplyRoundedCorners()
        SetRoundedCorners(pnlMainInput, 15)
        SetRoundedCorners(pnlTicketCard, 15)
        SetRoundedCorners(btnGetTicket, 10)
        SetRoundedCorners(btnNewVisitor, 10)

        SetRoundedCorners(gbStudentInfo, 10)
        SetRoundedCorners(gbPurpose, 10)
        SetRoundedCorners(gbDocumentRequest, 10)
    End Sub

    Private Sub btnNewVisitor_Click(sender As Object, e As EventArgs) Handles btnNewVisitor.Click
        If isVisitorMode Then
            ResetForm()
        Else
            isVisitorMode = True
            ResetForm()
            isVisitorMode = True

            gbStudentInfo.Text = "Visitor Information"
            btnNewVisitor.Text = "I am a Student"
            btnNewVisitor.BackColor = Color.FromArgb(220, 53, 69)

            txtStudentID.Visible = False
            Label1.Visible = False
            txtCourse.Visible = False
            Label4.Visible = False
            txtYearLevel.Visible = False
            Label5.Visible = False

            chkPromissory.Visible = False

            txtLastName.ReadOnly = False
            txtFirstName.ReadOnly = False

            txtLastName.Location = New Point(155, 42)
            Label2.Location = New Point(20, 44)
            txtFirstName.Location = New Point(155, 79)
            Label3.Location = New Point(20, 81)
        End If
    End Sub

    Private Sub SetRoundedCorners(ctrl As Control, radius As Integer)
        Dim path As New GraphicsPath()
        Dim rect As New Rectangle(0, 0, ctrl.Width, ctrl.Height)

        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        ctrl.Region = New Region(path)
    End Sub

    Private Sub frmKiosk_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterPanel()
    End Sub

    Private Sub CenterPanel()
        pnlMainInput.Left = (tpMain.ClientSize.Width - pnlMainInput.Width) / 2
        pnlMainInput.Top = (tpMain.ClientSize.Height - pnlMainInput.Height) / 2
        pnlTicketResult.Left = (tpTicket.ClientSize.Width - pnlTicketResult.Width) / 2
        pnlTicketResult.Top = (tpTicket.ClientSize.Height - pnlTicketResult.Height) / 2
    End Sub

    Private Sub btnGetTicket_MouseEnter(sender As Object, e As EventArgs) Handles btnGetTicket.MouseEnter
        btnGetTicket.BackColor = Color.FromArgb(230, 179, 24)
        btnGetTicket.Font = New Font("Poppins", 18.5F, FontStyle.Bold)
    End Sub

    Private Sub btnGetTicket_MouseLeave(sender As Object, e As EventArgs) Handles btnGetTicket.MouseLeave
        btnGetTicket.BackColor = Color.FromArgb(255, 199, 44)
        btnGetTicket.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
    End Sub



    Private Sub AdjustLabelFont(lbl As Label)
        If String.IsNullOrEmpty(lbl.Text) Then Return
        Dim maxSize As Size = New Size(lbl.Width - 60, Integer.MaxValue)
        Dim initialFontSize As Single = 56.0F
        Dim currentFontSize As Single = initialFontSize
        Dim measuredSize As SizeF
        Do
            Dim currentFont As New Font(lbl.Font.FontFamily, currentFontSize, lbl.Font.Style)
            measuredSize = TextRenderer.MeasureText(lbl.Text, currentFont, maxSize)
            If measuredSize.Width > lbl.Width - 60 Then
                currentFontSize -= 1.0F
            Else
                lbl.Font = currentFont
                Exit Do
            End If
            currentFont.Dispose()
        Loop While currentFontSize > 20
        If lbl.Font.Size < 20 Then
            lbl.Font = New Font(lbl.Font.FontFamily, 20.0F, lbl.Font.Style)
        End If
    End Sub

    Private Sub ResetForm()
        txtStudentID.Clear()
        txtLastName.Clear()
        txtFirstName.Clear()
        txtCourse.Clear()
        txtYearLevel.Clear()
        chkIsPriority.Checked = False
        chkTuition.Checked = False
        chkEnrollment.Checked = False
        chkPromissory.Checked = False
        chkDocRequest.Checked = False
        chkClearance.Checked = False
        chkDiploma.Checked = False
        chkTOR.Checked = False
        chkGMC.Checked = False
        studentId = -1
        selectedCounterId = -1
        selectedTimeSlot = ""
        selectedCounterName = ""
        selectedCashierName = ""
        btnGetTicket.Enabled = False
        tcKiosk.SelectedTab = tpMain

        isVisitorMode = False
        gbStudentInfo.Text = "Student Information"
        If btnNewVisitor IsNot Nothing Then
            btnNewVisitor.Text = "New Visitor"
            btnNewVisitor.BackColor = Color.FromArgb(0, 123, 255)
        End If

        txtStudentID.Visible = True
        Label1.Visible = True
        txtCourse.Visible = True
        Label4.Visible = True
        txtYearLevel.Visible = True
        Label5.Visible = True

        chkTuition.Visible = True
        chkEnrollment.Visible = True
        chkPromissory.Visible = True
        chkDocRequest.Visible = True
        chkClearance.Visible = True

        txtLastName.ReadOnly = True
        txtFirstName.ReadOnly = True

        txtStudentID.Location = New Point(155, 42)
        Label1.Location = New Point(20, 44)
        txtLastName.Location = New Point(155, 79)
        Label2.Location = New Point(20, 81)
        txtFirstName.Location = New Point(155, 116)
        Label3.Location = New Point(20, 118)
        txtCourse.Location = New Point(155, 153)
        Label4.Location = New Point(20, 155)
        txtYearLevel.Location = New Point(155, 190)
        Label5.Location = New Point(20, 192)
    End Sub

    Private Sub FindBestCounterAndTimeSlot()
        Dim purpose As String = GetPurposeString()
        Dim isPriority As Boolean = chkIsPriority.Checked
        selectedCounterId = FindAvailableCounter(purpose, isPriority)
        If selectedCounterId <> -1 Then
            FetchCounterDetails(selectedCounterId)
            Dim selectedDate As DateTime = DateTime.Today
            Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
                Try
                    conn.Open()
                    FindEarliestAvailableTimeSlot(conn, selectedDate, selectedCounterId)
                Catch ex As Exception
                    MessageBox.Show("Failed to find an available time slot: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Else
            selectedTimeSlot = "No available slots"
        End If
        UpdateUIWithSelection()
    End Sub

    Private Function FindAvailableCounter(purpose As String, isPriority As Boolean) As Integer
        Dim counterStatuses As New Dictionary(Of Integer, Tuple(Of Boolean, String))
        Dim query As String = "SELECT counter_id, is_open, status FROM counter_schedules WHERE counter_id IN (1, 2, 3, 4)"
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            counterStatuses(reader.GetInt32("counter_id")) = New Tuple(Of Boolean, String)(reader.GetBoolean("is_open"), reader.GetString("status"))
                        End While
                    End Using
                End Using
                If purpose.Contains("Document Request") Or purpose.Contains("Clearance Signing") Then
                    If counterStatuses.ContainsKey(4) AndAlso counterStatuses(4).Item1 AndAlso counterStatuses(4).Item2 = "open" Then
                        Return 4
                    Else
                        Return FindAvailableLeastBusyCounter(conn, counterStatuses, New List(Of Integer) From {1, 2, 3})
                    End If
                End If
                If isPriority Then
                    If counterStatuses.ContainsKey(3) AndAlso counterStatuses(3).Item1 AndAlso counterStatuses(3).Item2 = "open" Then
                        Return 3
                    Else
                        Return FindAvailableLeastBusyCounter(conn, counterStatuses, New List(Of Integer) From {1, 2})
                    End If
                End If
                Return FindAvailableLeastBusyCounter(conn, counterStatuses, New List(Of Integer) From {1, 2})
            Catch ex As Exception
                MessageBox.Show("Error finding an available counter: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return -1
            End Try
        End Using
    End Function

    Private Function FindAvailableLeastBusyCounter(conn As MySqlConnection, statuses As Dictionary(Of Integer, Tuple(Of Boolean, String)), countersToCheck As List(Of Integer)) As Integer
        Dim availableCounters As New List(Of Integer)
        For Each counterId In countersToCheck
            If statuses.ContainsKey(counterId) AndAlso statuses(counterId).Item1 AndAlso statuses(counterId).Item2 = "open" Then
                availableCounters.Add(counterId)
            End If
        Next
        If availableCounters.Count = 0 Then
            Return -1
        ElseIf availableCounters.Count = 1 Then
            Return availableCounters(0)
        Else
            Dim counterAppointments As New Dictionary(Of Integer, Integer)
            Dim query As String = $"SELECT counter_id, COUNT(*) as appointment_count FROM queues WHERE DATE(schedule_datetime) = CURDATE() AND counter_id IN ({String.Join(",", availableCounters)}) GROUP BY counter_id"
            For Each counterId In availableCounters
                counterAppointments.Add(counterId, 0)
            Next
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        counterAppointments(reader.GetInt32("counter_id")) = reader.GetInt32("appointment_count")
                    End While
                End Using
            End Using
            Dim leastBusyCounter As Integer = -1
            Dim minAppointments As Integer = Integer.MaxValue
            For Each counterId In availableCounters
                If counterAppointments(counterId) < minAppointments Then
                    minAppointments = counterAppointments(counterId)
                    leastBusyCounter = counterId
                End If
            Next
            Return leastBusyCounter
        End If
    End Function

    Private Sub FetchCounterDetails(counterId As Integer)
        Dim counterQuery As String = "SELECT counter_name FROM counters WHERE counter_id = @counter_id"
        Dim cashierQuery As String = "SELECT full_name FROM cashiers WHERE counter_id = @counter_id"
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(counterQuery, conn)
                    cmd.Parameters.AddWithValue("@counter_id", counterId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        selectedCounterName = result.ToString()
                    Else
                        selectedCounterName = "N/A"
                    End If
                End Using
                Using cmd As New MySqlCommand(cashierQuery, conn)
                    cmd.Parameters.AddWithValue("@counter_id", counterId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        selectedCashierName = result.ToString()
                    Else
                        selectedCashierName = "Not Assigned"
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error fetching counter details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                selectedCounterName = "Error"
                selectedCashierName = "Error"
            End Try
        End Using
    End Sub

    Private Sub FindEarliestAvailableTimeSlot(conn As MySqlConnection, selectedDate As DateTime, counterId As Integer)
        Dim bookedSlots As New List(Of TimeSpan)
        Dim query As String = "SELECT TIME(schedule_datetime) FROM queues WHERE counter_id = @counter_id AND DATE(schedule_datetime) = @schedule_date"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@counter_id", counterId)
            cmd.Parameters.AddWithValue("@schedule_date", selectedDate.ToString("yyyy-MM-dd"))
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    bookedSlots.Add(reader.GetTimeSpan(0))
                End While
            End Using
        End Using
        Dim startTime As DateTime = DateTime.Today.AddHours(8)
        Dim endTime As DateTime = DateTime.Today.AddHours(17)
        Dim interval As TimeSpan = TimeSpan.FromMinutes(30)
        Dim currentTime As DateTime = startTime
        While currentTime < endTime
            If Not bookedSlots.Contains(currentTime.TimeOfDay) Then
                selectedTimeSlot = currentTime.ToString("hh:mm tt")
                selectedDateTime = currentTime
                Exit Sub
            End If
            currentTime = currentTime.Add(interval)
        End While
        selectedTimeSlot = "No available slots"
    End Sub

    Private Sub UpdateUIWithSelection()
        Dim purposeSelected As Boolean = chkTuition.Checked Or chkEnrollment.Checked Or chkPromissory.Checked Or chkDocRequest.Checked Or chkClearance.Checked
        Dim hasSlot As Boolean = (selectedCounterId <> -1 AndAlso Not String.IsNullOrEmpty(selectedTimeSlot) AndAlso selectedTimeSlot <> "No available slots")
        Dim validVisitor As Boolean = False

        If isVisitorMode Then
            validVisitor = (Not String.IsNullOrWhiteSpace(txtLastName.Text) AndAlso Not String.IsNullOrWhiteSpace(txtFirstName.Text))
        End If

        Dim validStudent As Boolean = (Not isVisitorMode AndAlso studentId <> -1)

        btnGetTicket.Enabled = (validStudent Or validVisitor) AndAlso purposeSelected AndAlso hasSlot

        If Not hasSlot AndAlso (validStudent Or validVisitor) AndAlso purposeSelected Then
            MessageBox.Show("All counters for your purpose are currently unavailable or fully booked. Please try again later.", "No Slots Available", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function GetCoursePrefix(studentId As Integer, conn As MySqlConnection, transaction As MySqlTransaction) As String
        Dim course As String = ""
        Dim query As String = "SELECT course FROM students WHERE student_id = @student_id"
        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@student_id", studentId)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                course = result.ToString()
            Else
                course = "GEN"
            End If
        End Using

        Select Case course
            Case "Visitor"
                Return "VIS"
            Case "Bachelor of Science in Psychology"
                Return "CAS"
            Case "Bachelor of Science in Accountancy", "Bachelor of Science in Customs Administration", "Bachelor of Science in Business Administration", "Major in Marketing Management", "Major in Financial Management", "Major in Human Resource Development Management"
                Return "CBME"
            Case "Bachelor of Science in Criminology"
                Return "CCJ"
            Case "Bachelor of Science in Computer Science"
                Return "CCS"
            Case "Bachelor of Science in Information Technology"
                Return "BSIT"
            Case "Bachelor of Elementary Education", "Bachelor of Secondary Education", "Major in English", "Major in Filipino", "Major in Mathematics", "Bachelor of Technical Vocational for Teacher Education", "Major in Automotive Technology", "Major in Computer Programming", "Major in Food Service Management", "Major in Electronics Technology", "Major in Welding and Fabrication"
                Return "COE"
            Case "Bachelor of Science in Industrial Engineering", "Bachelor of Science in Computer Engineering"
                Return "CEN"
            Case "Juris Doctor Program"
                Return "COL"
            Case "Bachelor of Science in Real Estate Management"
                Return "CREM"
            Case "Bachelor of Science in Tourism Management", "Bachelor of Science in Hospitality Management"
                Return "CTHM"
            Case Else
                Return "GEN"
        End Select
    End Function

    Private Function HasActiveTicket(currentStudentId As Integer) As Boolean
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM queues WHERE student_id = @student_id AND status IN ('waiting', 'serving') AND DATE(schedule_datetime) = CURDATE()"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@student_id", currentStudentId)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            Catch ex As Exception
                MessageBox.Show("Error checking for active tickets: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True
            End Try
        End Using
    End Function

    Private Sub btnGetTicket_Click(sender As Object, e As EventArgs) Handles btnGetTicket.Click
        Dim purpose As String = GetPurposeString()
        If String.IsNullOrWhiteSpace(purpose) Then
            MessageBox.Show("Please select a purpose for your visit.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If chkDocRequest.Checked AndAlso Not (chkDiploma.Checked Or chkTOR.Checked Or chkGMC.Checked) Then
            MessageBox.Show("Please select at least one type of document to request.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If isVisitorMode Then
            If String.IsNullOrWhiteSpace(txtLastName.Text) Or String.IsNullOrWhiteSpace(txtFirstName.Text) Then
                MessageBox.Show("Please enter your First and Last Name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Try
                Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
                    conn.Open()
                    Dim visitorStudentNumber = "VIS-" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
                    Dim insertStudentQuery = "INSERT INTO students (student_number, last_name, first_name, course, year_level) VALUES (@student_number, @last_name, @first_name, 'Visitor', 'N/A')"
                    Using cmd As New MySqlCommand(insertStudentQuery, conn)
                        cmd.Parameters.AddWithValue("@student_number", visitorStudentNumber)
                        cmd.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim())
                        cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim())
                        cmd.ExecuteNonQuery()
                        studentId = CInt(cmd.LastInsertedId)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Failed to register visitor. " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        Else
            If studentId = -1 Then
                MessageBox.Show("Please enter a valid Student ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If HasActiveTicket(studentId) Then
                MessageBox.Show("You already have an active transaction." & vbCrLf & "Please complete your current transaction before getting a new ticket.", "Active Transaction Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        FindBestCounterAndTimeSlot()
        If selectedCounterId = -1 OrElse selectedTimeSlot = "No available slots" Then
            MessageBox.Show("No available slots. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim queueNumber As String = ""
        Dim isPriority As Integer = If(chkIsPriority.Checked, 1, 0)
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                Dim prefix As String = GetCoursePrefix(studentId, conn, transaction)
                If isPriority = 1 Then
                    prefix = "P-" & prefix
                End If
                Dim datePart As String = DateTime.Now.ToString("MMdd")
                Dim countQuery As String = "SELECT COUNT(*) FROM queues WHERE DATE(created_at) = CURDATE()"
                Dim countCmd As New MySqlCommand(countQuery, conn, transaction)
                Dim nextNum As Integer = Convert.ToInt32(countCmd.ExecuteScalar()) + 1
                queueNumber = $"{prefix}-{datePart}-{nextNum:D3}"
                Dim status As String = "waiting"
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn
                cmd.Transaction = transaction
                cmd.CommandText = "INSERT INTO queues (student_id, counter_id, queue_number, purpose, is_priority, status, schedule_datetime, created_at) " &
                                      "VALUES (@student_id, @counter_id, @queue_number, @purpose, @is_priority, @status, @schedule_datetime, NOW())"
                cmd.Parameters.AddWithValue("@student_id", studentId)
                cmd.Parameters.AddWithValue("@counter_id", selectedCounterId)
                cmd.Parameters.AddWithValue("@queue_number", queueNumber)
                cmd.Parameters.AddWithValue("@purpose", purpose)
                cmd.Parameters.AddWithValue("@is_priority", isPriority)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@schedule_datetime", selectedDateTime)
                cmd.ExecuteNonQuery()
                transaction.Commit()
                ShowTicket(queueNumber)
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Failed to create ticket. The database reported the following error:" & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Function GetPurposeString() As String
        Dim purposes As New List(Of String)
        If chkTuition.Checked Then purposes.Add("Tuition Payment")
        If chkEnrollment.Checked Then purposes.Add("Enrollment Concern")
        If chkPromissory.Checked Then purposes.Add("Promissory Note")
        If chkClearance.Checked Then purposes.Add("Clearance Signing")
        Dim docRequests As New List(Of String)
        If chkDocRequest.Checked Then
            purposes.Add("Document Request")
            If chkDiploma.Checked Then docRequests.Add("Diploma")
            If chkTOR.Checked Then docRequests.Add("Transcript of Records (TOR)")
            If chkGMC.Checked Then docRequests.Add("Good Moral Certificate")
            If docRequests.Count > 0 Then
                purposes.Add("doc_req:" & String.Join(", ", docRequests))
            End If
        End If
        Return String.Join(", ", purposes)
    End Function

    Private Sub btnNewTransaction_Click(sender As Object, e As EventArgs)
        ResetForm()
    End Sub

    Private Sub txtStudentID_TextChanged(sender As Object, e As EventArgs) Handles txtStudentID.TextChanged
        If isVisitorMode Then Return

        txtLastName.Clear()
        txtFirstName.Clear()
        txtCourse.Clear()
        txtYearLevel.Clear()

        chkIsPriority.Checked = False
        chkTuition.Checked = False
        chkEnrollment.Checked = False
        chkPromissory.Checked = False
        chkDocRequest.Checked = False
        chkClearance.Checked = False
        studentId = -1
        selectedCounterId = -1
        selectedTimeSlot = ""
        btnGetTicket.Enabled = False

        txtLastName.ReadOnly = True
        txtFirstName.ReadOnly = True

        If txtStudentID.Text.Length > 4 Then
            FetchStudentDetails(txtStudentID.Text.Trim())
        Else
            UpdateUIWithSelection()
        End If
    End Sub

    Private Sub FetchStudentDetails(studentNumber As String)
        Dim queryNumber As String = studentNumber
        If Not studentNumber.StartsWith("C", StringComparison.OrdinalIgnoreCase) Then
            queryNumber = "C" & studentNumber
        End If
        Dim query As String = "SELECT student_id, last_name, first_name, course, year_level FROM students WHERE student_number = @student_number"
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@student_number", queryNumber)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            studentId = reader.GetInt32("student_id")
                            txtLastName.Text = reader.GetString("last_name")
                            txtFirstName.Text = reader.GetString("first_name")
                            txtCourse.Text = reader.GetString("course")
                            If Not reader.IsDBNull(reader.GetOrdinal("year_level")) Then
                                txtYearLevel.Text = reader.GetString("year_level")
                            Else
                                txtYearLevel.Text = "N/A"
                            End If

                            FindBestCounterAndTimeSlot()
                        Else
                            studentId = -1
                            txtLastName.ReadOnly = True
                            txtFirstName.ReadOnly = True
                            UpdateUIWithSelection()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error fetching student details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub chkDocRequest_CheckedChanged(sender As Object, e As EventArgs) Handles chkDocRequest.CheckedChanged
        gbDocumentRequest.Visible = chkDocRequest.Checked
        FindBestCounterAndTimeSlot()
    End Sub

    Private Sub Purpose_CheckedChanged(sender As Object, e As EventArgs) Handles chkTuition.CheckedChanged, chkEnrollment.CheckedChanged, chkPromissory.CheckedChanged, chkIsPriority.CheckedChanged, txtLastName.TextChanged, txtFirstName.TextChanged, chkDiploma.CheckedChanged, chkTOR.CheckedChanged, chkGMC.CheckedChanged, chkClearance.CheckedChanged
        If TypeOf sender Is CheckBox AndAlso DirectCast(sender, CheckBox).Name = "chkIsPriority" AndAlso chkIsPriority.Checked Then
            MessageBox.Show("Priority lane is intended for pregnant, PWD, and senior citizens.", "Priority Lane", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        FindBestCounterAndTimeSlot()
    End Sub

    Private Sub ShowTicket(queueNumber As String)
        lblQueueNumber.Text = queueNumber
        lblAssignedCounter.Text = $"Counter: {selectedCounterName}"
        lblAssignedCashier.Text = $"Cashier: {selectedCashierName}"
        tcKiosk.SelectedTab = tpTicket

        PlayNotificationSound()

        resetStep = 1
        tmrResetView.Interval = 5000
        tmrResetView.Start()
    End Sub

    Private Sub tmrResetView_Tick(sender As Object, e As EventArgs) Handles tmrResetView.Tick
        tmrResetView.Stop()
        If resetStep = 1 Then
            lblQueueNumber.Text = "Thank You!"
            lblAssignedCounter.Text = ""
            lblAssignedCashier.Text = ""

            PlayNotificationSound()

            resetStep = 2
            tmrResetView.Interval = 2000
            tmrResetView.Start()
        ElseIf resetStep = 2 Then
            resetStep = 0
            ResetForm()
        End If
    End Sub

End Class

