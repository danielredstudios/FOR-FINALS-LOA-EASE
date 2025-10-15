<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        pnlBranding = New Panel()
        pnlGradientOverlay = New Panel()
        lblBrandSubtitle = New Label()
        lblBrandTitle = New Label()
        pnlLogin = New Panel()
        pnlLoginContainer = New Panel()
        lblForgotPassword = New Label()
        chkShowPassword = New CheckBox()
        btnLogin = New Button()
        pnlPasswordContainer = New Panel()
        txtPassword = New TextBox()
        PictureBox2 = New PictureBox()
        pnlUsernameContainer = New Panel()
        txtUsername = New TextBox()
        PictureBox1 = New PictureBox()
        lblSubtitle = New Label()
        lblLogin = New Label()
        pnlBranding.SuspendLayout()
        pnlGradientOverlay.SuspendLayout()
        pnlLogin.SuspendLayout()
        pnlLoginContainer.SuspendLayout()
        pnlPasswordContainer.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        pnlUsernameContainer.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlBranding
        ' 
        pnlBranding.BackColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        pnlBranding.Controls.Add(pnlGradientOverlay)
        pnlBranding.Dock = DockStyle.Left
        pnlBranding.Location = New Point(0, 0)
        pnlBranding.Name = "pnlBranding"
        pnlBranding.Size = New Size(420, 600)
        pnlBranding.TabIndex = 0
        ' 
        ' pnlGradientOverlay
        ' 
        pnlGradientOverlay.BackColor = Color.Transparent
        pnlGradientOverlay.Controls.Add(lblBrandSubtitle)
        pnlGradientOverlay.Controls.Add(lblBrandTitle)
        pnlGradientOverlay.Dock = DockStyle.Fill
        pnlGradientOverlay.Location = New Point(0, 0)
        pnlGradientOverlay.Name = "pnlGradientOverlay"
        pnlGradientOverlay.Size = New Size(420, 600)
        pnlGradientOverlay.TabIndex = 0
        ' 
        ' lblBrandSubtitle
        ' 
        lblBrandSubtitle.Anchor = AnchorStyles.None
        lblBrandSubtitle.Font = New Font("Poppins", 11.25F, FontStyle.Regular)
        lblBrandSubtitle.ForeColor = Color.FromArgb(CByte(200), CByte(220), CByte(240))
        lblBrandSubtitle.Location = New Point(50, 320)
        lblBrandSubtitle.Name = "lblBrandSubtitle"
        lblBrandSubtitle.Size = New Size(320, 60)
        lblBrandSubtitle.TabIndex = 1
        lblBrandSubtitle.Text = "Streamlining Services," & vbCrLf & "One Click at a Time"
        lblBrandSubtitle.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblBrandTitle
        ' 
        lblBrandTitle.Anchor = AnchorStyles.None
        lblBrandTitle.AutoSize = True
        lblBrandTitle.Font = New Font("Poppins", 42.0F, FontStyle.Bold)
        lblBrandTitle.ForeColor = Color.White
        lblBrandTitle.Location = New Point(75, 240)
        lblBrandTitle.Name = "lblBrandTitle"
        lblBrandTitle.Size = New Size(270, 99)
        lblBrandTitle.TabIndex = 0
        lblBrandTitle.Text = "LOA EASE"
        lblBrandTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlLogin
        ' 
        pnlLogin.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        pnlLogin.Controls.Add(pnlLoginContainer)
        pnlLogin.Dock = DockStyle.Fill
        pnlLogin.Location = New Point(420, 0)
        pnlLogin.Name = "pnlLogin"
        pnlLogin.Size = New Size(480, 600)
        pnlLogin.TabIndex = 1
        ' 
        ' pnlLoginContainer
        ' 
        pnlLoginContainer.Anchor = AnchorStyles.None
        pnlLoginContainer.BackColor = Color.White
        pnlLoginContainer.Controls.Add(lblForgotPassword)
        pnlLoginContainer.Controls.Add(chkShowPassword)
        pnlLoginContainer.Controls.Add(btnLogin)
        pnlLoginContainer.Controls.Add(pnlPasswordContainer)
        pnlLoginContainer.Controls.Add(pnlUsernameContainer)
        pnlLoginContainer.Controls.Add(lblSubtitle)
        pnlLoginContainer.Controls.Add(lblLogin)
        pnlLoginContainer.Location = New Point(60, 120)
        pnlLoginContainer.Name = "pnlLoginContainer"
        pnlLoginContainer.Size = New Size(360, 450)
        pnlLoginContainer.TabIndex = 0
        ' 
        ' lblForgotPassword
        ' 
        lblForgotPassword.AutoSize = True
        lblForgotPassword.Cursor = Cursors.Hand
        lblForgotPassword.Font = New Font("Poppins", 8.25F)
        lblForgotPassword.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblForgotPassword.Location = New Point(40, 315)
        lblForgotPassword.Name = "lblForgotPassword"
        lblForgotPassword.Size = New Size(102, 19)
        lblForgotPassword.TabIndex = 6
        lblForgotPassword.Text = "Forgot Password?"
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Poppins", 8.25F)
        chkShowPassword.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        chkShowPassword.Location = New Point(40, 280)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(110, 23)
        chkShowPassword.TabIndex = 5
        chkShowPassword.Text = "Show Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Poppins", 12.0F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(40, 355)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(280, 55)
        btnLogin.TabIndex = 4
        btnLogin.Text = "Sign In"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' pnlPasswordContainer
        ' 
        pnlPasswordContainer.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        pnlPasswordContainer.Controls.Add(txtPassword)
        pnlPasswordContainer.Controls.Add(PictureBox2)
        pnlPasswordContainer.Location = New Point(40, 215)
        pnlPasswordContainer.Name = "pnlPasswordContainer"
        pnlPasswordContainer.Size = New Size(280, 50)
        pnlPasswordContainer.TabIndex = 3
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Poppins", 11.25F)
        txtPassword.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        txtPassword.Location = New Point(50, 12)
        txtPassword.Name = "txtPassword"
        txtPassword.PlaceholderText = "Password"
        txtPassword.Size = New Size(215, 23)
        txtPassword.TabIndex = 1
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(15, 13)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(24, 24)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 0
        PictureBox2.TabStop = False
        ' 
        ' pnlUsernameContainer
        ' 
        pnlUsernameContainer.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        pnlUsernameContainer.Controls.Add(txtUsername)
        pnlUsernameContainer.Controls.Add(PictureBox1)
        pnlUsernameContainer.Location = New Point(40, 150)
        pnlUsernameContainer.Name = "pnlUsernameContainer"
        pnlUsernameContainer.Size = New Size(280, 50)
        pnlUsernameContainer.TabIndex = 2
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Poppins", 11.25F)
        txtUsername.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        txtUsername.Location = New Point(50, 12)
        txtUsername.Name = "txtUsername"
        txtUsername.PlaceholderText = "Username"
        txtUsername.Size = New Size(215, 23)
        txtUsername.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(15, 13)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 24)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Poppins", 9.0F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblSubtitle.Location = New Point(40, 95)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(191, 22)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Please sign in to your account"
        ' 
        ' lblLogin
        ' 
        lblLogin.AutoSize = True
        lblLogin.Font = New Font("Poppins", 24.0F, FontStyle.Bold)
        lblLogin.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblLogin.Location = New Point(35, 40)
        lblLogin.Name = "lblLogin"
        lblLogin.Size = New Size(239, 56)
        lblLogin.TabIndex = 0
        lblLogin.Text = "Welcome Back"
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(900, 600)
        Controls.Add(pnlLogin)
        Controls.Add(pnlBranding)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LOA EASE - Login"
        pnlBranding.ResumeLayout(False)
        pnlGradientOverlay.ResumeLayout(False)
        pnlGradientOverlay.PerformLayout()
        pnlLogin.ResumeLayout(False)
        pnlLoginContainer.ResumeLayout(False)
        pnlLoginContainer.PerformLayout()
        pnlPasswordContainer.ResumeLayout(False)
        pnlPasswordContainer.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        pnlUsernameContainer.ResumeLayout(False)
        pnlUsernameContainer.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBranding As Panel
    Friend WithEvents pnlGradientOverlay As Panel
    Friend WithEvents lblBrandTitle As Label
    Friend WithEvents lblBrandSubtitle As Label
    Friend WithEvents pnlLogin As Panel
    Friend WithEvents pnlLoginContainer As Panel
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlUsernameContainer As Panel
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlPasswordContainer As Panel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents lblForgotPassword As Label

End Class