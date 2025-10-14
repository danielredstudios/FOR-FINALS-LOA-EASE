<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucCounter
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblQueueNumber = New System.Windows.Forms.Label()
        Me.lblCounterName = New System.Windows.Forms.Label()
        Me.pnlLeftBorder = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'lblQueueNumber
        '
        Me.lblQueueNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQueueNumber.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblQueueNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQueueNumber.Location = New System.Drawing.Point(20, 10)
        Me.lblQueueNumber.Name = "lblQueueNumber"
        Me.lblQueueNumber.Size = New System.Drawing.Size(260, 54)
        Me.lblQueueNumber.TabIndex = 0
        Me.lblQueueNumber.Text = "P-CCS-0925-004"
        Me.lblQueueNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounterName
        '
        Me.lblCounterName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCounterName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblCounterName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblCounterName.Location = New System.Drawing.Point(20, 70)
        Me.lblCounterName.Name = "lblCounterName"
        Me.lblCounterName.Size = New System.Drawing.Size(260, 28)
        Me.lblCounterName.TabIndex = 1
        Me.lblCounterName.Text = "Cashier 1"
        Me.lblCounterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLeftBorder
        '
        Me.pnlLeftBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.pnlLeftBorder.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftBorder.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftBorder.Name = "pnlLeftBorder"
        Me.pnlLeftBorder.Size = New System.Drawing.Size(10, 110)
        Me.pnlLeftBorder.TabIndex = 2
        '
        'ucCounter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlLeftBorder)
        Me.Controls.Add(Me.lblCounterName)
        Me.Controls.Add(Me.lblQueueNumber)
        Me.Margin = New System.Windows.Forms.Padding(10)
        Me.Name = "ucCounter"
        Me.Size = New System.Drawing.Size(300, 110)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblQueueNumber As Label
    Friend WithEvents lblCounterName As Label
    Friend WithEvents pnlLeftBorder As Panel
End Class