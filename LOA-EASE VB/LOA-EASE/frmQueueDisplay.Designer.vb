<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQueueDisplay
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
        Me.components = New System.ComponentModel.Container()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlWaiting = New System.Windows.Forms.Panel()
        Me.flpWaiting = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblWaitingHeader = New System.Windows.Forms.Label()
        Me.pnlNowServing = New System.Windows.Forms.Panel()
        Me.flpNowServing = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblNowServingHeader = New System.Windows.Forms.Label()
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMain.SuspendLayout()
        Me.pnlWaiting.SuspendLayout()
        Me.pnlNowServing.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlWaiting)
        Me.pnlMain.Controls.Add(Me.pnlNowServing)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1280, 720)
        Me.pnlMain.TabIndex = 0
        '
        'pnlWaiting
        '
        Me.pnlWaiting.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlWaiting.Controls.Add(Me.flpWaiting)
        Me.pnlWaiting.Controls.Add(Me.lblWaitingHeader)
        Me.pnlWaiting.Location = New System.Drawing.Point(820, 20)
        Me.pnlWaiting.Name = "pnlWaiting"
        Me.pnlWaiting.Size = New System.Drawing.Size(440, 680)
        Me.pnlWaiting.TabIndex = 1
        '
        'flpWaiting
        '
        Me.flpWaiting.AutoScroll = True
        Me.flpWaiting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpWaiting.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpWaiting.Location = New System.Drawing.Point(0, 60)
        Me.flpWaiting.Name = "flpWaiting"
        Me.flpWaiting.Padding = New System.Windows.Forms.Padding(10)
        Me.flpWaiting.Size = New System.Drawing.Size(440, 620)
        Me.flpWaiting.TabIndex = 1
        Me.flpWaiting.WrapContents = False
        '
        'lblWaitingHeader
        '
        Me.lblWaitingHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblWaitingHeader.Font = New System.Drawing.Font("Segoe UI", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblWaitingHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblWaitingHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblWaitingHeader.Name = "lblWaitingHeader"
        Me.lblWaitingHeader.Size = New System.Drawing.Size(440, 60)
        Me.lblWaitingHeader.TabIndex = 0
        Me.lblWaitingHeader.Text = "Waiting"
        Me.lblWaitingHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlNowServing
        '
        Me.pnlNowServing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlNowServing.Controls.Add(Me.flpNowServing)
        Me.pnlNowServing.Controls.Add(Me.lblNowServingHeader)
        Me.pnlNowServing.Location = New System.Drawing.Point(20, 20)
        Me.pnlNowServing.Name = "pnlNowServing"
        Me.pnlNowServing.Size = New System.Drawing.Size(780, 680)
        Me.pnlNowServing.TabIndex = 0
        '
        'flpNowServing
        '
        Me.flpNowServing.AutoScroll = True
        Me.flpNowServing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpNowServing.Location = New System.Drawing.Point(0, 60)
        Me.flpNowServing.Name = "flpNowServing"
        Me.flpNowServing.Padding = New System.Windows.Forms.Padding(10)
        Me.flpNowServing.Size = New System.Drawing.Size(780, 620)
        Me.flpNowServing.TabIndex = 1
        '
        'lblNowServingHeader
        '
        Me.lblNowServingHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNowServingHeader.Font = New System.Drawing.Font("Segoe UI", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblNowServingHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblNowServingHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblNowServingHeader.Name = "lblNowServingHeader"
        Me.lblNowServingHeader.Size = New System.Drawing.Size(780, 60)
        Me.lblNowServingHeader.TabIndex = 0
        Me.lblNowServingHeader.Text = "Now Serving"
        Me.lblNowServingHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Interval = 5000
        '
        'frmQueueDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "frmQueueDisplay"
        Me.Text = "Queue Display"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlWaiting.ResumeLayout(False)
        Me.pnlNowServing.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlNowServing As Panel
    Friend WithEvents lblNowServingHeader As Label
    Friend WithEvents flpNowServing As FlowLayoutPanel
    Friend WithEvents pnlWaiting As Panel
    Friend WithEvents flpWaiting As FlowLayoutPanel
    Friend WithEvents lblWaitingHeader As Label
    Friend WithEvents RefreshTimer As Timer
End Class