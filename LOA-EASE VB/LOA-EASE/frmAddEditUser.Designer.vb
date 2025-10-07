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
        lblTitle = New Label()
        Label1 = New Label()
        txtFullName = New TextBox()
        txtUsername = New TextBox()
        Label2 = New Label()
        txtPassword = New TextBox()
        Label3 = New Label()
        Label4 = New Label()
        cboRole = New ComboBox()
        btnSave = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(94, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Add User"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 53)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 15)
        Label1.TabIndex = 1
        Label1.Text = "Full Name:"
        ' 
        ' txtFullName
        ' 
        txtFullName.Location = New Point(12, 71)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(260, 23)
        txtFullName.TabIndex = 2
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(12, 115)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(260, 23)
        txtUsername.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 15)
        Label2.TabIndex = 3
        Label2.Text = "Username:"
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(12, 159)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(260, 23)
        txtPassword.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 141)
        Label3.Name = "Label3"
        Label3.Size = New Size(60, 15)
        Label3.TabIndex = 5
        Label3.Text = "Password:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 185)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 7
        Label4.Text = "Role:"
        ' 
        ' cboRole
        ' 
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.FormattingEnabled = True
        cboRole.Items.AddRange(New Object() {"Admin", "Cashier"})
        cboRole.Location = New Point(12, 203)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(260, 23)
        cboRole.TabIndex = 8
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(116, 241)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 9
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(197, 241)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 10
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' frmAddEditUser
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 276)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(cboRole)
        Controls.Add(Label4)
        Controls.Add(txtPassword)
        Controls.Add(Label3)
        Controls.Add(txtUsername)
        Controls.Add(Label2)
        Controls.Add(txtFullName)
        Controls.Add(Label1)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAddEditUser"
        StartPosition = FormStartPosition.CenterParent
        Text = "Add/Edit User"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class