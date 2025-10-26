<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddEditUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 373) ' Adjusted default size
        Me.Text = "Add/Edit User"
        Me.Font = New Font("Poppins", 9.0F) ' Set default font
        Me.FormBorderStyle = FormBorderStyle.FixedDialog ' Prevent resizing by user
        Me.StartPosition = FormStartPosition.CenterParent
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        ' Header Panel
        pnlFormHeader = New Panel()
        pnlFormHeader.BackColor = Color.FromArgb(0, 51, 102) ' Match Admin Dashboard header
        pnlFormHeader.Dock = DockStyle.Top
        pnlFormHeader.Height = 60 ' Header height
        pnlFormHeader.Padding = New Padding(15, 0, 15, 0) ' Padding for title

        lblTitle = New Label()
        lblTitle.AutoSize = False ' Set to False to fill panel vertically
        lblTitle.Dock = DockStyle.Fill ' Fill the header panel
        lblTitle.Font = New Font("Poppins SemiBold", 14.0F, FontStyle.Bold) ' Larger, bold title font
        lblTitle.ForeColor = Color.White
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        lblTitle.Text = "Add/Edit User" ' Default text, will be updated in code-behind

        pnlFormHeader.Controls.Add(lblTitle)
        Me.Controls.Add(pnlFormHeader)

        ' Controls (Adjust Top based on header height)
        Dim contentTopMargin As Integer = pnlFormHeader.Height + 20 ' Space below header

        Label1 = New Label()
        Label1.AutoSize = True
        Label1.Location = New Point(30, contentTopMargin)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 26)
        Label1.Text = "Full Name:"
        Me.Controls.Add(Label1)

        txtFullName = New TextBox()
        txtFullName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right ' Anchor Left/Right
        txtFullName.Location = New Point(30, contentTopMargin + 30)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(402, 30) ' Adjusted width
        Me.Controls.Add(txtFullName)

        Label2 = New Label()
        Label2.AutoSize = True
        Label2.Location = New Point(30, contentTopMargin + 70)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 26)
        Label2.Text = "Username:"
        Me.Controls.Add(Label2)

        txtUsername = New TextBox()
        txtUsername.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtUsername.Location = New Point(30, contentTopMargin + 100)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(402, 30)
        Me.Controls.Add(txtUsername)

        Label3 = New Label()
        Label3.AutoSize = True
        Label3.Location = New Point(30, contentTopMargin + 140)
        Label3.Name = "Label3"
        Label3.Size = New Size(195, 26)
        Label3.Text = "Password (leave blank to keep current):"
        Me.Controls.Add(Label3)

        txtPassword = New TextBox()
        txtPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtPassword.Location = New Point(30, contentTopMargin + 170)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(402, 30)
        Me.Controls.Add(txtPassword)

        Label4 = New Label() ' Role Label
        Label4.AutoSize = True
        Label4.Location = New Point(30, contentTopMargin + 210)
        Label4.Name = "Label4"
        Label4.Size = New Size(46, 26)
        Label4.Text = "Role:"
        Me.Controls.Add(Label4)

        cboRole = New ComboBox() ' Role ComboBox
        cboRole.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.FormattingEnabled = True
        cboRole.Items.AddRange(New Object() {"Admin", "Cashier"})
        cboRole.Location = New Point(30, contentTopMargin + 240)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(402, 34) ' Height adjusted for ComboBox
        Me.Controls.Add(cboRole)

        ' Buttons (Position based on last visible control + margin)
        Dim buttonTop As Integer = If(cboRole.Visible, cboRole.Bottom + 20, txtPassword.Bottom + 20)

        btnSave = New Button()
        btnSave.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right ' Anchor bottom right
        btnSave.BackColor = Color.FromArgb(40, 167, 69) ' Green
        btnSave.Cursor = Cursors.Hand
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(222, buttonTop) ' Adjusted X position
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(100, 40) ' Consistent button size
        btnSave.Text = "💾 Save"
        btnSave.UseVisualStyleBackColor = False
        Me.Controls.Add(btnSave)

        btnCancel = New Button()
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCancel.BackColor = Color.FromArgb(108, 117, 125) ' Gray
        btnCancel.Cursor = Cursors.Hand
        btnCancel.DialogResult = DialogResult.Cancel ' Set DialogResult
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(332, buttonTop) ' Adjusted X position
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 40)
        btnCancel.Text = "❌ Cancel"
        btnCancel.UseVisualStyleBackColor = False
        Me.Controls.Add(btnCancel)

        ' Adjust Form Height based on button position
        Me.ClientSize = New Size(462, btnCancel.Bottom + 20) ' Set height dynamically
        Me.AcceptButton = btnSave ' Assign Enter key
        Me.CancelButton = btnCancel ' Assign Esc key

    End Sub

    Friend WithEvents pnlFormHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label4 As Label ' Role Label
    Friend WithEvents cboRole As ComboBox ' Role ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button

End Class
