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
        lblBrandSubtitle = New Label()
        lblBrandTitle = New Label()
        pnlLogin = New Panel()
        lblLogin = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        btnLogin = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        chkShowPassword = New CheckBox()
        pnlBranding.SuspendLayout()
        pnlLogin.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlBranding
        ' 
        pnlBranding.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        pnlBranding.Controls.Add(lblBrandSubtitle)
        pnlBranding.Controls.Add(lblBrandTitle)
        pnlBranding.Dock = DockStyle.Left
        pnlBranding.Location = New Point(0, 0)
        pnlBranding.Name = "pnlBranding"
        pnlBranding.Size = New Size(380, 541)
        pnlBranding.TabIndex = 3
        ' 
        ' lblBrandSubtitle
        ' 
        lblBrandSubtitle.AutoSize = True
        lblBrandSubtitle.Font = New Font("Poppins", 9.75F)
        lblBrandSubtitle.ForeColor = Color.WhiteSmoke
        lblBrandSubtitle.Location = New Point(40, 270)
        lblBrandSubtitle.Name = "lblBrandSubtitle"
        lblBrandSubtitle.Size = New Size(244, 23)
        lblBrandSubtitle.TabIndex = 1
        lblBrandSubtitle.Text = "Streamlining Services, One Click at a Time"
        ' 
        ' lblBrandTitle
        ' 
        lblBrandTitle.AutoSize = True
        lblBrandTitle.Font = New Font("Poppins SemiBold", 24.0F, FontStyle.Bold)
        lblBrandTitle.ForeColor = Color.White
        lblBrandTitle.Location = New Point(35, 210)
        lblBrandTitle.Name = "lblBrandTitle"
        lblBrandTitle.Size = New Size(183, 56)
        lblBrandTitle.TabIndex = 0
        lblBrandTitle.Text = "LOA EASE"
        ' 
        ' pnlLogin
        ' 
        pnlLogin.BackColor = Color.White
        pnlLogin.Controls.Add(lblLogin)
        pnlLogin.Controls.Add(txtUsername)
        pnlLogin.Controls.Add(txtPassword)
        pnlLogin.Controls.Add(btnLogin)
        pnlLogin.Controls.Add(PictureBox1)
        pnlLogin.Controls.Add(PictureBox2)
        pnlLogin.Controls.Add(chkShowPassword)
        pnlLogin.Dock = DockStyle.Fill
        pnlLogin.Location = New Point(380, 0)
        pnlLogin.Name = "pnlLogin"
        pnlLogin.Size = New Size(404, 541)
        pnlLogin.TabIndex = 4
        ' 
        ' lblLogin
        ' 
        lblLogin.AutoSize = True
        lblLogin.Font = New Font("Poppins", 15.75F, FontStyle.Bold)
        lblLogin.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblLogin.Location = New Point(50, 140)
        lblLogin.Name = "lblLogin"
        lblLogin.Size = New Size(189, 37)
        lblLogin.TabIndex = 0
        lblLogin.Text = "Welcome Back!"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Poppins", 11.25F)
        txtUsername.Location = New Point(90, 210)
        txtUsername.Name = "txtUsername"
        txtUsername.PlaceholderText = "Username"
        txtUsername.Size = New Size(250, 30)
        txtUsername.TabIndex = 1
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Poppins", 11.25F)
        txtPassword.Location = New Point(90, 260)
        txtPassword.Name = "txtPassword"
        txtPassword.PlaceholderText = "Password"
        txtPassword.Size = New Size(250, 30)
        txtPassword.TabIndex = 3
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Poppins", 11.25F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(90, 330)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(250, 48)
        btnLogin.TabIndex = 5
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(55, 213)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 24)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(55, 263)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(24, 24)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 4
        PictureBox2.TabStop = False
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Poppins", 9.0F)
        chkShowPassword.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        chkShowPassword.Location = New Point(90, 295)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(118, 23)
        chkShowPassword.TabIndex = 6
        chkShowPassword.Text = "Show Password"
        chkShowPassword.UseVisualStyleBackColor = True
        '
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(784, 541)
        Controls.Add(pnlLogin)
        Controls.Add(pnlBranding)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LOA EASE - Login"
        pnlBranding.ResumeLayout(False)
        pnlBranding.PerformLayout()
        pnlLogin.ResumeLayout(False)
        pnlLogin.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBranding As Panel
    Friend WithEvents lblBrandTitle As Label
    Friend WithEvents lblBrandSubtitle As Label
    Friend WithEvents pnlLogin As Panel
    Friend WithEvents lblLogin As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents chkShowPassword As CheckBox

End Class