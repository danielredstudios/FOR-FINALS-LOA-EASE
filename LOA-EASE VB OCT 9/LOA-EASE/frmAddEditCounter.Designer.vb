<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddEditCounter
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblCounterName = New Label()
        txtCounterName = New TextBox()
        lblCashier = New Label()
        cboCashier = New ComboBox()
        btnSave = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Poppins", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(23, 22)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(218, 37)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Add/Edit Counter"
        ' 
        ' lblCounterName
        ' 
        lblCounterName.AutoSize = True
        lblCounterName.Font = New Font("Poppins", 9.75F)
        lblCounterName.Location = New Point(29, 80)
        lblCounterName.Name = "lblCounterName"
        lblCounterName.Size = New Size(106, 23)
        lblCounterName.TabIndex = 1
        lblCounterName.Text = "Counter Name"
        ' 
        ' txtCounterName
        ' 
        txtCounterName.Font = New Font("Poppins", 9.75F)
        txtCounterName.Location = New Point(31, 106)
        txtCounterName.Name = "txtCounterName"
        txtCounterName.Size = New Size(354, 27)
        txtCounterName.TabIndex = 2
        ' 
        ' lblCashier
        ' 
        lblCashier.AutoSize = True
        lblCashier.Font = New Font("Poppins", 9.75F)
        lblCashier.Location = New Point(29, 153)
        lblCashier.Name = "lblCashier"
        lblCashier.Size = New Size(119, 23)
        lblCashier.TabIndex = 3
        lblCashier.Text = "Assign a Cashier"
        ' 
        ' cboCashier
        ' 
        cboCashier.DropDownStyle = ComboBoxStyle.DropDownList
        cboCashier.Font = New Font("Poppins", 9.75F)
        cboCashier.FormattingEnabled = True
        cboCashier.Location = New Point(31, 179)
        cboCashier.Name = "cboCashier"
        cboCashier.Size = New Size(354, 31)
        cboCashier.TabIndex = 4
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(265, 240)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(120, 36)
        btnSave.TabIndex = 5
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(139, 240)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(120, 36)
        btnCancel.TabIndex = 6
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' frmAddEditCounter
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(417, 301)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(cboCashier)
        Controls.Add(lblCashier)
        Controls.Add(txtCounterName)
        Controls.Add(lblCounterName)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAddEditCounter"
        StartPosition = FormStartPosition.CenterParent
        Text = "Add/Edit Counter"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblCounterName As Label
    Friend WithEvents txtCounterName As TextBox
    Friend WithEvents lblCashier As Label
    Friend WithEvents cboCashier As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class