<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKiosk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKiosk))
        tcKiosk = New TabControl()
        tpMain = New TabPage()
        pnlMainInput = New Panel()
        tlpPurpose = New TableLayoutPanel()
        gbDocumentRequest = New GroupBox()
        chkGMC = New CheckBox()
        chkTOR = New CheckBox()
        chkDiploma = New CheckBox()
        gbPurpose = New GroupBox()
        chkIsPriority = New CheckBox()
        chkDocRequest = New CheckBox()
        chkPromissory = New CheckBox()
        chkEnrollment = New CheckBox()
        chkTuition = New CheckBox()
        btnGetTicket = New Button()
        gbStudentInfo = New GroupBox()
        txtCourse = New TextBox()
        Label4 = New Label()
        txtFirstName = New TextBox()
        Label3 = New Label()
        txtLastName = New TextBox()
        Label2 = New Label()
        txtStudentID = New TextBox()
        Label1 = New Label()
        tpTicket = New TabPage()
        pnlTicketResult = New Panel()
        lblMessage = New Label()
        lblAssignedCashier = New Label()
        lblAssignedCounter = New Label()
        btnNewTransaction = New Button()
        lblQueueNumber = New Label()
        pnlHeader = New Panel()
        lblAppName = New Label()
        lblSystemName = New Label()
        pbLogo = New PictureBox()
        tcKiosk.SuspendLayout()
        tpMain.SuspendLayout()
        pnlMainInput.SuspendLayout()
        tlpPurpose.SuspendLayout()
        gbDocumentRequest.SuspendLayout()
        gbPurpose.SuspendLayout()
        gbStudentInfo.SuspendLayout()
        tpTicket.SuspendLayout()
        pnlTicketResult.SuspendLayout()
        pnlHeader.SuspendLayout()
        CType(pbLogo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tcKiosk
        ' 
        tcKiosk.Controls.Add(tpMain)
        tcKiosk.Controls.Add(tpTicket)
        tcKiosk.Dock = DockStyle.Fill
        tcKiosk.Location = New Point(0, 100)
        tcKiosk.Name = "tcKiosk"
        tcKiosk.SelectedIndex = 0
        tcKiosk.Size = New Size(1264, 761)
        tcKiosk.TabIndex = 0
        ' 
        ' tpMain
        ' 
        tpMain.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        tpMain.Controls.Add(pnlMainInput)
        tpMain.Location = New Point(4, 46)
        tpMain.Name = "tpMain"
        tpMain.Padding = New Padding(10)
        tpMain.Size = New Size(1256, 711)
        tpMain.TabIndex = 0
        tpMain.Text = "Main"
        ' 
        ' pnlMainInput
        ' 
        pnlMainInput.Anchor = AnchorStyles.None
        pnlMainInput.BackColor = Color.White
        pnlMainInput.Controls.Add(tlpPurpose)
        pnlMainInput.Controls.Add(btnGetTicket)
        pnlMainInput.Controls.Add(gbStudentInfo)
        pnlMainInput.Location = New Point(242, 82)
        pnlMainInput.Name = "pnlMainInput"
        pnlMainInput.Size = New Size(772, 552)
        pnlMainInput.TabIndex = 0
        ' 
        ' tlpPurpose
        ' 
        tlpPurpose.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tlpPurpose.ColumnCount = 2
        tlpPurpose.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpPurpose.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpPurpose.Controls.Add(gbDocumentRequest, 1, 0)
        tlpPurpose.Controls.Add(gbPurpose, 0, 0)
        tlpPurpose.Location = New Point(15, 203)
        tlpPurpose.Name = "tlpPurpose"
        tlpPurpose.RowCount = 1
        tlpPurpose.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpPurpose.Size = New Size(742, 260)
        tlpPurpose.TabIndex = 4
        ' 
        ' gbDocumentRequest
        ' 
        gbDocumentRequest.Controls.Add(chkGMC)
        gbDocumentRequest.Controls.Add(chkTOR)
        gbDocumentRequest.Controls.Add(chkDiploma)
        gbDocumentRequest.Dock = DockStyle.Fill
        gbDocumentRequest.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        gbDocumentRequest.Location = New Point(374, 3)
        gbDocumentRequest.Name = "gbDocumentRequest"
        gbDocumentRequest.Size = New Size(365, 254)
        gbDocumentRequest.TabIndex = 3
        gbDocumentRequest.TabStop = False
        gbDocumentRequest.Text = "Document Details"
        ' 
        ' chkGMC
        ' 
        chkGMC.AutoSize = True
        chkGMC.Location = New Point(15, 105)
        chkGMC.Name = "chkGMC"
        chkGMC.Size = New Size(211, 32)
        chkGMC.TabIndex = 2
        chkGMC.Text = "Good Moral Certificate"
        chkGMC.UseVisualStyleBackColor = True
        ' 
        ' chkTOR
        ' 
        chkTOR.AutoSize = True
        chkTOR.Location = New Point(15, 70)
        chkTOR.Name = "chkTOR"
        chkTOR.Size = New Size(250, 32)
        chkTOR.TabIndex = 1
        chkTOR.Text = "Transcript of Records (TOR)"
        chkTOR.UseVisualStyleBackColor = True
        ' 
        ' chkDiploma
        ' 
        chkDiploma.AutoSize = True
        chkDiploma.Location = New Point(15, 35)
        chkDiploma.Name = "chkDiploma"
        chkDiploma.Size = New Size(98, 32)
        chkDiploma.TabIndex = 0
        chkDiploma.Text = "Diploma"
        chkDiploma.UseVisualStyleBackColor = True
        ' 
        ' gbPurpose
        ' 
        gbPurpose.Controls.Add(chkIsPriority)
        gbPurpose.Controls.Add(chkDocRequest)
        gbPurpose.Controls.Add(chkPromissory)
        gbPurpose.Controls.Add(chkEnrollment)
        gbPurpose.Controls.Add(chkTuition)
        gbPurpose.Dock = DockStyle.Fill
        gbPurpose.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        gbPurpose.Location = New Point(3, 3)
        gbPurpose.Name = "gbPurpose"
        gbPurpose.Size = New Size(365, 254)
        gbPurpose.TabIndex = 1
        gbPurpose.TabStop = False
        gbPurpose.Text = "Purpose of Visit"
        ' 
        ' chkIsPriority
        ' 
        chkIsPriority.AutoSize = True
        chkIsPriority.Font = New Font("Poppins", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        chkIsPriority.Location = New Point(16, 210)
        chkIsPriority.Name = "chkIsPriority"
        chkIsPriority.Size = New Size(134, 32)
        chkIsPriority.TabIndex = 4
        chkIsPriority.Text = "Priority Lane"
        chkIsPriority.UseVisualStyleBackColor = True
        ' 
        ' chkDocRequest
        ' 
        chkDocRequest.AutoSize = True
        chkDocRequest.Location = New Point(16, 175)
        chkDocRequest.Name = "chkDocRequest"
        chkDocRequest.Size = New Size(183, 32)
        chkDocRequest.TabIndex = 3
        chkDocRequest.Text = "Document Request"
        chkDocRequest.UseVisualStyleBackColor = True
        ' 
        ' chkPromissory
        ' 
        chkPromissory.AutoSize = True
        chkPromissory.Location = New Point(16, 140)
        chkPromissory.Name = "chkPromissory"
        chkPromissory.Size = New Size(158, 32)
        chkPromissory.TabIndex = 2
        chkPromissory.Text = "Promissory Note"
        chkPromissory.UseVisualStyleBackColor = True
        ' 
        ' chkEnrollment
        ' 
        chkEnrollment.AutoSize = True
        chkEnrollment.Location = New Point(16, 105)
        chkEnrollment.Name = "chkEnrollment"
        chkEnrollment.Size = New Size(187, 32)
        chkEnrollment.TabIndex = 1
        chkEnrollment.Text = "Enrollment Concern"
        chkEnrollment.UseVisualStyleBackColor = True
        ' 
        ' chkTuition
        ' 
        chkTuition.AutoSize = True
        chkTuition.Location = New Point(16, 70)
        chkTuition.Name = "chkTuition"
        chkTuition.Size = New Size(159, 32)
        chkTuition.TabIndex = 0
        chkTuition.Text = "Tuition Payment"
        chkTuition.UseVisualStyleBackColor = True
        ' 
        ' btnGetTicket
        ' 
        btnGetTicket.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnGetTicket.BackColor = Color.FromArgb(CByte(255), CByte(199), CByte(44))
        btnGetTicket.Cursor = Cursors.Hand
        btnGetTicket.FlatAppearance.BorderSize = 0
        btnGetTicket.FlatStyle = FlatStyle.Flat
        btnGetTicket.Font = New Font("Poppins", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGetTicket.ForeColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        btnGetTicket.Location = New Point(15, 480)
        btnGetTicket.Name = "btnGetTicket"
        btnGetTicket.Size = New Size(742, 60)
        btnGetTicket.TabIndex = 2
        btnGetTicket.Text = "Get Ticket"
        btnGetTicket.UseVisualStyleBackColor = False
        ' 
        ' gbStudentInfo
        ' 
        gbStudentInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        gbStudentInfo.Controls.Add(txtCourse)
        gbStudentInfo.Controls.Add(Label4)
        gbStudentInfo.Controls.Add(txtFirstName)
        gbStudentInfo.Controls.Add(Label3)
        gbStudentInfo.Controls.Add(txtLastName)
        gbStudentInfo.Controls.Add(Label2)
        gbStudentInfo.Controls.Add(txtStudentID)
        gbStudentInfo.Controls.Add(Label1)
        gbStudentInfo.Font = New Font("Poppins", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        gbStudentInfo.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        gbStudentInfo.Location = New Point(15, 15)
        gbStudentInfo.Name = "gbStudentInfo"
        gbStudentInfo.Size = New Size(742, 182)
        gbStudentInfo.TabIndex = 0
        gbStudentInfo.TabStop = False
        gbStudentInfo.Text = "Student Information"
        ' 
        ' txtCourse
        ' 
        txtCourse.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtCourse.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtCourse.BorderStyle = BorderStyle.FixedSingle
        txtCourse.Location = New Point(140, 137)
        txtCourse.Name = "txtCourse"
        txtCourse.ReadOnly = True
        txtCourse.Size = New Size(585, 31)
        txtCourse.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(16, 140)
        Label4.Name = "Label4"
        Label4.Size = New Size(71, 28)
        Label4.TabIndex = 6
        Label4.Text = "Course:"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtFirstName.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtFirstName.BorderStyle = BorderStyle.FixedSingle
        txtFirstName.Location = New Point(140, 104)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.ReadOnly = True
        txtFirstName.Size = New Size(585, 31)
        txtFirstName.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 107)
        Label3.Name = "Label3"
        Label3.Size = New Size(99, 28)
        Label3.TabIndex = 4
        Label3.Text = "First Name:"
        ' 
        ' txtLastName
        ' 
        txtLastName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLastName.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtLastName.BorderStyle = BorderStyle.FixedSingle
        txtLastName.Location = New Point(140, 71)
        txtLastName.Name = "txtLastName"
        txtLastName.ReadOnly = True
        txtLastName.Size = New Size(585, 31)
        txtLastName.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 74)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 28)
        Label2.TabIndex = 2
        Label2.Text = "Last Name:"
        ' 
        ' txtStudentID
        ' 
        txtStudentID.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtStudentID.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtStudentID.BorderStyle = BorderStyle.FixedSingle
        txtStudentID.Location = New Point(140, 38)
        txtStudentID.Name = "txtStudentID"
        txtStudentID.Size = New Size(585, 31)
        txtStudentID.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 41)
        Label1.Name = "Label1"
        Label1.Size = New Size(96, 28)
        Label1.TabIndex = 0
        Label1.Text = "Student ID:"
        ' 
        ' tpTicket
        ' 
        tpTicket.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        tpTicket.Controls.Add(pnlTicketResult)
        tpTicket.Location = New Point(4, 24)
        tpTicket.Name = "tpTicket"
        tpTicket.Padding = New Padding(10)
        tpTicket.Size = New Size(1256, 733)
        tpTicket.TabIndex = 1
        tpTicket.Text = "Ticket"
        ' 
        ' pnlTicketResult
        ' 
        pnlTicketResult.Anchor = AnchorStyles.None
        pnlTicketResult.BackColor = Color.White
        pnlTicketResult.Controls.Add(lblMessage)
        pnlTicketResult.Controls.Add(lblAssignedCashier)
        pnlTicketResult.Controls.Add(lblAssignedCounter)
        pnlTicketResult.Controls.Add(btnNewTransaction)
        pnlTicketResult.Controls.Add(lblQueueNumber)
        pnlTicketResult.Location = New Point(242, 82)
        pnlTicketResult.Name = "pnlTicketResult"
        pnlTicketResult.Size = New Size(772, 552)
        pnlTicketResult.TabIndex = 0
        ' 
        ' lblMessage
        ' 
        lblMessage.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblMessage.Font = New Font("Poppins", 14.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblMessage.ForeColor = Color.DimGray
        lblMessage.Location = New Point(20, 320)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(732, 60)
        lblMessage.TabIndex = 4
        lblMessage.Text = "Please proceed to your assigned counter. Your number will be called shortly."
        lblMessage.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblAssignedCashier
        ' 
        lblAssignedCashier.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblAssignedCashier.Font = New Font("Poppins", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAssignedCashier.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        lblAssignedCashier.Location = New Point(20, 260)
        lblAssignedCashier.Name = "lblAssignedCashier"
        lblAssignedCashier.Size = New Size(732, 50)
        lblAssignedCashier.TabIndex = 3
        lblAssignedCashier.Text = "Cashier: John Doe"
        lblAssignedCashier.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblAssignedCounter
        ' 
        lblAssignedCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblAssignedCounter.Font = New Font("Poppins", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAssignedCounter.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        lblAssignedCounter.Location = New Point(20, 210)
        lblAssignedCounter.Name = "lblAssignedCounter"
        lblAssignedCounter.Size = New Size(732, 50)
        lblAssignedCounter.TabIndex = 2
        lblAssignedCounter.Text = "Counter: Cashier 1"
        lblAssignedCounter.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnNewTransaction
        ' 
        btnNewTransaction.Anchor = AnchorStyles.Bottom
        btnNewTransaction.BackColor = Color.FromArgb(CByte(222), CByte(226), CByte(230))
        btnNewTransaction.Cursor = Cursors.Hand
        btnNewTransaction.FlatAppearance.BorderSize = 0
        btnNewTransaction.FlatStyle = FlatStyle.Flat
        btnNewTransaction.Font = New Font("Poppins", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNewTransaction.ForeColor = Color.Black
        btnNewTransaction.Location = New Point(286, 480)
        btnNewTransaction.Name = "btnNewTransaction"
        btnNewTransaction.Size = New Size(200, 50)
        btnNewTransaction.TabIndex = 1
        btnNewTransaction.Text = "New Transaction"
        btnNewTransaction.UseVisualStyleBackColor = False
        ' 
        ' lblQueueNumber
        ' 
        lblQueueNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblQueueNumber.Font = New Font("Poppins", 60.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQueueNumber.ForeColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        lblQueueNumber.Location = New Point(20, 40)
        lblQueueNumber.Name = "lblQueueNumber"
        lblQueueNumber.Size = New Size(732, 170)
        lblQueueNumber.TabIndex = 0
        lblQueueNumber.Text = "CCS-0926-001"
        lblQueueNumber.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(0), CByte(41), CByte(82))
        pnlHeader.Controls.Add(lblAppName)
        pnlHeader.Controls.Add(lblSystemName)
        pnlHeader.Controls.Add(pbLogo)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1264, 100)
        pnlHeader.TabIndex = 2
        ' 
        ' lblAppName
        ' 
        lblAppName.AutoSize = True
        lblAppName.Font = New Font("Poppins", 24.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAppName.ForeColor = Color.FromArgb(CByte(255), CByte(199), CByte(44))
        lblAppName.Location = New Point(106, 45)
        lblAppName.Name = "lblAppName"
        lblAppName.Size = New Size(185, 56)
        lblAppName.TabIndex = 2
        lblAppName.Text = "LOA-EASE"
        ' 
        ' lblSystemName
        ' 
        lblSystemName.AutoSize = True
        lblSystemName.Font = New Font("Poppins", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSystemName.ForeColor = Color.White
        lblSystemName.Location = New Point(110, 15)
        lblSystemName.Name = "lblSystemName"
        lblSystemName.Size = New Size(397, 37)
        lblSystemName.TabIndex = 1
        lblSystemName.Text = "Lyceum of Alabang Queuing System"
        ' 
        ' pbLogo
        ' 
        pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Image)
        pbLogo.Location = New Point(20, 10)
        pbLogo.Name = "pbLogo"
        pbLogo.Size = New Size(80, 80)
        pbLogo.SizeMode = PictureBoxSizeMode.Zoom
        pbLogo.TabIndex = 0
        pbLogo.TabStop = False
        ' 
        ' frmKiosk
        ' 
        AutoScaleDimensions = New SizeF(13.0F, 37.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        ClientSize = New Size(1264, 861)
        Controls.Add(tcKiosk)
        Controls.Add(pnlHeader)
        Font = New Font("Poppins", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "frmKiosk"
        Text = "LOA-EASE Kiosk"
        WindowState = FormWindowState.Maximized
        tcKiosk.ResumeLayout(False)
        tpMain.ResumeLayout(False)
        pnlMainInput.ResumeLayout(False)
        tlpPurpose.ResumeLayout(False)
        gbDocumentRequest.ResumeLayout(False)
        gbDocumentRequest.PerformLayout()
        gbPurpose.ResumeLayout(False)
        gbPurpose.PerformLayout()
        gbStudentInfo.ResumeLayout(False)
        gbStudentInfo.PerformLayout()
        tpTicket.ResumeLayout(False)
        pnlTicketResult.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(pbLogo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tcKiosk As TabControl
    Friend WithEvents tpMain As TabPage
    Friend WithEvents pnlMainInput As Panel
    Friend WithEvents gbStudentInfo As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCourse As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents gbPurpose As GroupBox
    Friend WithEvents chkTuition As CheckBox
    Friend WithEvents chkDocRequest As CheckBox
    Friend WithEvents chkPromissory As CheckBox
    Friend WithEvents chkEnrollment As CheckBox
    Friend WithEvents chkIsPriority As CheckBox
    Friend WithEvents btnGetTicket As Button
    Friend WithEvents gbDocumentRequest As GroupBox
    Friend WithEvents chkGMC As CheckBox
    Friend WithEvents chkTOR As CheckBox
    Friend WithEvents chkDiploma As CheckBox
    Friend WithEvents tpTicket As TabPage
    Friend WithEvents pnlTicketResult As Panel
    Friend WithEvents lblQueueNumber As Label
    Friend WithEvents btnNewTransaction As Button
    Friend WithEvents lblAssignedCounter As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents lblAssignedCashier As Label
    Friend WithEvents tlpPurpose As TableLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblAppName As Label
    Friend WithEvents lblSystemName As Label
    Friend WithEvents pbLogo As PictureBox
End Class