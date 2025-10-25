Imports MySql.Data.MySqlClient

Public Class frmAddStudent
    ' Form controls
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private btnClose As Button
    Private pnlMain As Panel
    Private lblLastName As Label
    Private txtLastName As TextBox
    Private lblFirstName As Label
    Private txtFirstName As TextBox
    Private lblStudentNo As Label
    Private txtStudentNo As TextBox
    Private lblEmail As Label
    Private txtEmail As TextBox
    Private lblDepartment As Label
    Private cboDepartment As ComboBox
    Private lblCourse As Label
    Private cboCourse As ComboBox
    Private lblYearLevel As Label
    Private cboYearLevel As ComboBox
    Private pnlFooter As Panel
    Private btnSave As Button
    Private btnCancel As Button
    Private pnlShadow As Panel

    ' Dictionary to store courses by department
    Private courseDictionary As New Dictionary(Of String, List(Of String))

    Public Sub New()
        InitializeComponent()
        InitializeCourseDictionary()
        InitializeControls()
    End Sub

    Private Sub InitializeCourseDictionary()
        ' Initialize the dictionary with departments and their courses
        courseDictionary.Add("College of Arts and Sciences", New List(Of String) From {
            "Bachelor of Science in Psychology"
        })

        courseDictionary.Add("College of Business Management Education", New List(Of String) From {
            "Bachelor of Science in Accountancy",
            "Bachelor of Science in Customs Administration",
            "BS Business Administration - Marketing Management",
            "BS Business Administration - Financial Management",
            "BS Business Administration - Human Resource Development Management"
        })

        courseDictionary.Add("College of Criminal Justice", New List(Of String) From {
            "Bachelor of Science in Criminology"
        })

        courseDictionary.Add("College of Computer Studies", New List(Of String) From {
            "BS in Computer Science",
            "BS in Information Technology"
        })

        courseDictionary.Add("College of Education", New List(Of String) From {
            "Bachelor of Elementary Education",
            "Bachelor of Secondary Education - English",
            "Bachelor of Secondary Education - Filipino",
            "Bachelor of Secondary Education - Mathematics",
            "BS Technical Vocational Teacher Education - Automotive Technology",
            "BS Technical Vocational Teacher Education - Computer Programming",
            "BS Technical Vocational Teacher Education - Food Service Management",
            "BS Technical Vocational Teacher Education - Electronics Technology",
            "BS Technical Vocational Teacher Education - Welding and Fabrication"
        })

        courseDictionary.Add("College of Engineering", New List(Of String) From {
            "Bachelor of Science in Industrial Engineering",
            "Bachelor of Science in Computer Engineering"
        })

        courseDictionary.Add("College of Law", New List(Of String) From {
            "Juris Doctor Program"
        })

        courseDictionary.Add("College of Real Estate Management", New List(Of String) From {
            "Bachelor of Science in Real Estate Management"
        })

        courseDictionary.Add("College of Tourism and Hospitality Management", New List(Of String) From {
            "Bachelor of Science in Tourism Management",
            "Bachelor of Science in Hospitality Management"
        })
    End Sub

    Private Sub InitializeControls()
        Me.Text = "Add New Student"
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(550, 700)
        Me.BackColor = Color.FromArgb(45, 52, 54)
        Me.Padding = New Padding(3)

        ' Main container with shadow effect
        pnlShadow = New Panel()
        pnlShadow.BackColor = Color.White
        pnlShadow.Location = New Point(3, 3)
        pnlShadow.Size = New Size(544, 694)
        Me.Controls.Add(pnlShadow)

        ' Header Panel
        pnlHeader = New Panel()
        pnlHeader.BackColor = Color.FromArgb(0, 123, 255)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 70
        pnlShadow.Controls.Add(pnlHeader)

        ' Title Label
        lblTitle = New Label()
        lblTitle.Text = "Add New Student"
        lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(25, 22)
        lblTitle.AutoSize = True
        pnlHeader.Controls.Add(lblTitle)

        ' Close Button (X)
        btnClose = New Button()
        btnClose.Text = "✕"
        btnClose.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        btnClose.Size = New Size(40, 40)
        btnClose.Location = New Point(495, 15)
        btnClose.BackColor = Color.Transparent
        btnClose.ForeColor = Color.White
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.Cursor = Cursors.Hand
        AddHandler btnClose.Click, Sub() Me.Close()
        pnlHeader.Controls.Add(btnClose)

        ' Main Panel
        pnlMain = New Panel()
        pnlMain.BackColor = Color.FromArgb(248, 249, 250)
        pnlMain.Location = New Point(0, 70)
        pnlMain.Size = New Size(544, 555)
        pnlMain.AutoScroll = True
        pnlShadow.Controls.Add(pnlMain)

        Dim yPos As Integer = 30

        ' Last Name
        lblLastName = New Label()
        lblLastName.Text = "Last Name *"
        lblLastName.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblLastName.ForeColor = Color.FromArgb(52, 58, 64)
        lblLastName.Location = New Point(35, yPos)
        lblLastName.AutoSize = True
        pnlMain.Controls.Add(lblLastName)

        txtLastName = New TextBox()
        txtLastName.Location = New Point(35, yPos + 25)
        txtLastName.Size = New Size(474, 30)
        txtLastName.Font = New Font("Segoe UI", 10.0F)
        txtLastName.BorderStyle = BorderStyle.FixedSingle
        txtLastName.BackColor = Color.White
        pnlMain.Controls.Add(txtLastName)

        yPos += 70

        ' First Name
        lblFirstName = New Label()
        lblFirstName.Text = "First Name *"
        lblFirstName.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblFirstName.ForeColor = Color.FromArgb(52, 58, 64)
        lblFirstName.Location = New Point(35, yPos)
        lblFirstName.AutoSize = True
        pnlMain.Controls.Add(lblFirstName)

        txtFirstName = New TextBox()
        txtFirstName.Location = New Point(35, yPos + 25)
        txtFirstName.Size = New Size(474, 30)
        txtFirstName.Font = New Font("Segoe UI", 10.0F)
        txtFirstName.BorderStyle = BorderStyle.FixedSingle
        txtFirstName.BackColor = Color.White
        pnlMain.Controls.Add(txtFirstName)

        yPos += 70

        ' Student Number
        lblStudentNo = New Label()
        lblStudentNo.Text = "Student Number *"
        lblStudentNo.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblStudentNo.ForeColor = Color.FromArgb(52, 58, 64)
        lblStudentNo.Location = New Point(35, yPos)
        lblStudentNo.AutoSize = True
        pnlMain.Controls.Add(lblStudentNo)

        txtStudentNo = New TextBox()
        txtStudentNo.Location = New Point(35, yPos + 25)
        txtStudentNo.Size = New Size(474, 30)
        txtStudentNo.Font = New Font("Segoe UI", 10.0F)
        txtStudentNo.BorderStyle = BorderStyle.FixedSingle
        txtStudentNo.BackColor = Color.White
        pnlMain.Controls.Add(txtStudentNo)

        yPos += 70

        ' Email Address
        lblEmail = New Label()
        lblEmail.Text = "Email Address *"
        lblEmail.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblEmail.ForeColor = Color.FromArgb(52, 58, 64)
        lblEmail.Location = New Point(35, yPos)
        lblEmail.AutoSize = True
        pnlMain.Controls.Add(lblEmail)

        txtEmail = New TextBox()
        txtEmail.Location = New Point(35, yPos + 25)
        txtEmail.Size = New Size(474, 30)
        txtEmail.Font = New Font("Segoe UI", 10.0F)
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.BackColor = Color.White
        txtEmail.PlaceholderText = "example@email.com"
        pnlMain.Controls.Add(txtEmail)

        yPos += 70

        ' Department
        lblDepartment = New Label()
        lblDepartment.Text = "Department/College *"
        lblDepartment.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblDepartment.ForeColor = Color.FromArgb(52, 58, 64)
        lblDepartment.Location = New Point(35, yPos)
        lblDepartment.AutoSize = True
        pnlMain.Controls.Add(lblDepartment)

        cboDepartment = New ComboBox()
        cboDepartment.Location = New Point(35, yPos + 25)
        cboDepartment.Size = New Size(474, 30)
        cboDepartment.Font = New Font("Segoe UI", 9.0F)
        cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cboDepartment.FlatStyle = FlatStyle.Flat
        cboDepartment.BackColor = Color.White

        ' Add departments to the dropdown
        cboDepartment.Items.Add("-- Select Department --")
        For Each dept As String In courseDictionary.Keys
            cboDepartment.Items.Add(dept)
        Next
        cboDepartment.SelectedIndex = 0

        AddHandler cboDepartment.SelectedIndexChanged, AddressOf cboDepartment_SelectedIndexChanged
        pnlMain.Controls.Add(cboDepartment)

        yPos += 70

        ' Course
        lblCourse = New Label()
        lblCourse.Text = "Course *"
        lblCourse.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblCourse.ForeColor = Color.FromArgb(52, 58, 64)
        lblCourse.Location = New Point(35, yPos)
        lblCourse.AutoSize = True
        pnlMain.Controls.Add(lblCourse)

        cboCourse = New ComboBox()
        cboCourse.Location = New Point(35, yPos + 25)
        cboCourse.Size = New Size(474, 30)
        cboCourse.Font = New Font("Segoe UI", 9.0F)
        cboCourse.DropDownStyle = ComboBoxStyle.DropDownList
        cboCourse.FlatStyle = FlatStyle.Flat
        cboCourse.BackColor = Color.White
        cboCourse.Enabled = False
        cboCourse.Items.Add("-- Select Department First --")
        cboCourse.SelectedIndex = 0
        pnlMain.Controls.Add(cboCourse)

        yPos += 70

        ' Year Level
        lblYearLevel = New Label()
        lblYearLevel.Text = "Year Level *"
        lblYearLevel.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblYearLevel.ForeColor = Color.FromArgb(52, 58, 64)
        lblYearLevel.Location = New Point(35, yPos)
        lblYearLevel.AutoSize = True
        pnlMain.Controls.Add(lblYearLevel)

        cboYearLevel = New ComboBox()
        cboYearLevel.Location = New Point(35, yPos + 25)
        cboYearLevel.Size = New Size(474, 30)
        cboYearLevel.Font = New Font("Segoe UI", 10.0F)
        cboYearLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cboYearLevel.FlatStyle = FlatStyle.Flat
        cboYearLevel.BackColor = Color.White
        cboYearLevel.Items.AddRange(New String() {"1st Year", "2nd Year", "3rd Year", "4th Year", "Irregular"})
        pnlMain.Controls.Add(cboYearLevel)

        ' Footer Panel
        pnlFooter = New Panel()
        pnlFooter.BackColor = Color.White
        pnlFooter.Location = New Point(0, 625)
        pnlFooter.Size = New Size(544, 69)
        pnlShadow.Controls.Add(pnlFooter)

        ' Required fields note
        Dim lblRequired As New Label()
        lblRequired.Text = "* Required fields"
        lblRequired.Font = New Font("Segoe UI", 8.0F, FontStyle.Italic)
        lblRequired.ForeColor = Color.FromArgb(108, 117, 125)
        lblRequired.Location = New Point(35, 25)
        lblRequired.AutoSize = True
        pnlFooter.Controls.Add(lblRequired)

        ' Save Button
        btnSave = New Button()
        btnSave.Text = "Save Student"
        btnSave.Location = New Point(310, 15)
        btnSave.Size = New Size(120, 40)
        btnSave.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnSave.BackColor = Color.FromArgb(40, 167, 69)
        btnSave.ForeColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.Cursor = Cursors.Hand
        AddHandler btnSave.Click, AddressOf btnSave_Click
        pnlFooter.Controls.Add(btnSave)

        ' Cancel Button
        btnCancel = New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Location = New Point(440, 15)
        btnCancel.Size = New Size(90, 40)
        btnCancel.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        btnCancel.BackColor = Color.FromArgb(108, 117, 125)
        btnCancel.ForeColor = Color.White
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.Cursor = Cursors.Hand
        btnCancel.DialogResult = DialogResult.Cancel
        pnlFooter.Controls.Add(btnCancel)
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Clear and reset course dropdown
        cboCourse.Items.Clear()
        cboCourse.SelectedIndex = -1

        If cboDepartment.SelectedIndex > 0 Then
            Dim selectedDept As String = cboDepartment.SelectedItem.ToString()

            If courseDictionary.ContainsKey(selectedDept) Then
                ' Enable course dropdown and populate with courses
                cboCourse.Enabled = True
                cboCourse.Items.Add("-- Select Course --")

                For Each course As String In courseDictionary(selectedDept)
                    cboCourse.Items.Add(course)
                Next

                cboCourse.SelectedIndex = 0
            End If
        Else
            ' Disable course dropdown if no department selected
            cboCourse.Enabled = False
            cboCourse.Items.Add("-- Select Department First --")
            cboCourse.SelectedIndex = 0
        End If
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        ' Basic email validation
        If String.IsNullOrWhiteSpace(email) Then Return False

        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email.Trim()
        Catch
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        ' Validate input
        If String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtStudentNo.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           cboDepartment.SelectedIndex <= 0 OrElse
           cboCourse.SelectedIndex <= 0 OrElse
           cboYearLevel.SelectedItem Is Nothing Then
            MessageBox.Show("Please fill in all required fields:" & vbCrLf & vbCrLf &
                          "• Last Name" & vbCrLf &
                          "• First Name" & vbCrLf &
                          "• Student Number" & vbCrLf &
                          "• Email Address" & vbCrLf &
                          "• Department/College" & vbCrLf &
                          "• Course" & vbCrLf &
                          "• Year Level",
                          "Missing Information",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
            Return
        End If

        ' Validate email format
        If Not IsValidEmail(txtEmail.Text.Trim()) Then
            MessageBox.Show("Please enter a valid email address." & vbCrLf & vbCrLf &
                          "Example: student@example.com",
                          "Invalid Email",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        ' Call DatabaseHelper to add student
        Try
            Dim success As Boolean = DatabaseHelper.AddStudent(
                txtFirstName.Text.Trim(),
                txtLastName.Text.Trim(),
                txtStudentNo.Text.Trim(),
                cboCourse.SelectedItem.ToString(),
                cboYearLevel.SelectedItem.ToString(),
                txtEmail.Text.Trim()
            )

            If success Then
                MessageBox.Show("Student added successfully!" & vbCrLf & vbCrLf &
                              "Name: " & txtFirstName.Text.Trim() & " " & txtLastName.Text.Trim() & vbCrLf &
                              "Student No: " & txtStudentNo.Text.Trim() & vbCrLf &
                              "Email: " & txtEmail.Text.Trim() & vbCrLf &
                              "Department: " & cboDepartment.SelectedItem.ToString() & vbCrLf &
                              "Course: " & cboCourse.SelectedItem.ToString(),
                              "Success",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to add student. The student number or email might already exist.",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred while saving: {ex.Message}",
                          "Database Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub

    ' Drag functionality for borderless form
    Private isDragging As Boolean = False
    Private dragOffset As Point

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        AddHandler pnlHeader.MouseDown, AddressOf Header_MouseDown
        AddHandler pnlHeader.MouseMove, AddressOf Header_MouseMove
        AddHandler pnlHeader.MouseUp, AddressOf Header_MouseUp
        AddHandler lblTitle.MouseDown, AddressOf Header_MouseDown
        AddHandler lblTitle.MouseMove, AddressOf Header_MouseMove
        AddHandler lblTitle.MouseUp, AddressOf Header_MouseUp
    End Sub

    Private Sub Header_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            isDragging = True
            dragOffset = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Header_MouseMove(sender As Object, e As MouseEventArgs)
        If isDragging Then
            Dim currentScreenPos As Point = PointToScreen(e.Location)
            Me.Location = New Point(currentScreenPos.X - dragOffset.X, currentScreenPos.Y - dragOffset.Y)
        End If
    End Sub

    Private Sub Header_MouseUp(sender As Object, e As MouseEventArgs)
        isDragging = False
    End Sub
End Class