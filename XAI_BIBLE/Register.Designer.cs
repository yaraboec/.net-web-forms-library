namespace XAI_BIBLE
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.background = new System.Windows.Forms.PictureBox();
            this.bttn_RegisterLinkLabel = new System.Windows.Forms.LinkLabel();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.txtBox_RegisterLogin = new System.Windows.Forms.TextBox();
            this.registerlabel = new System.Windows.Forms.Label();
            this.bttn_RegisterButton = new System.Windows.Forms.Button();
            this.txtBox_RegisterPassword = new System.Windows.Forms.TextBox();
            this.txtBox_RegisterConfirmPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.chkBox_Remember = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.background.Location = new System.Drawing.Point(65, 46);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(396, 492);
            this.background.TabIndex = 45;
            this.background.TabStop = false;
            // 
            // bttn_RegisterLinkLabel
            // 
            this.bttn_RegisterLinkLabel.AutoSize = true;
            this.bttn_RegisterLinkLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bttn_RegisterLinkLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttn_RegisterLinkLabel.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.bttn_RegisterLinkLabel.Location = new System.Drawing.Point(237, 482);
            this.bttn_RegisterLinkLabel.Name = "bttn_RegisterLinkLabel";
            this.bttn_RegisterLinkLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bttn_RegisterLinkLabel.Size = new System.Drawing.Size(54, 21);
            this.bttn_RegisterLinkLabel.TabIndex = 53;
            this.bttn_RegisterLinkLabel.TabStop = true;
            this.bttn_RegisterLinkLabel.Text = "Назад";
            this.bttn_RegisterLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtBox_RegisterLinkLabel_LinkClicked);
            // 
            // Avatar
            // 
            this.Avatar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Avatar.Image = global::XAI_BIBLE.Properties.Resources.avatar_circle_blue_512dp;
            this.Avatar.Location = new System.Drawing.Point(197, 87);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(132, 96);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Avatar.TabIndex = 52;
            this.Avatar.TabStop = false;
            // 
            // txtBox_RegisterLogin
            // 
            this.txtBox_RegisterLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_RegisterLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBox_RegisterLogin.Location = new System.Drawing.Point(137, 238);
            this.txtBox_RegisterLogin.Name = "txtBox_RegisterLogin";
            this.txtBox_RegisterLogin.Size = new System.Drawing.Size(256, 29);
            this.txtBox_RegisterLogin.TabIndex = 49;
            this.txtBox_RegisterLogin.Enter += new System.EventHandler(this.txtBox_RegisterLogin_Enter);
            this.txtBox_RegisterLogin.Leave += new System.EventHandler(this.txtBox_RegisterLogin_Leave);
            this.txtBox_RegisterLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBox_RegisterLogin_MouseDown);
            // 
            // registerlabel
            // 
            this.registerlabel.AutoSize = true;
            this.registerlabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.registerlabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registerlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.registerlabel.Location = new System.Drawing.Point(120, 198);
            this.registerlabel.Name = "registerlabel";
            this.registerlabel.Size = new System.Drawing.Size(291, 25);
            this.registerlabel.TabIndex = 48;
            this.registerlabel.Text = "Реєстрація нового користувача";
            // 
            // bttn_RegisterButton
            // 
            this.bttn_RegisterButton.BackColor = System.Drawing.Color.DarkGray;
            this.bttn_RegisterButton.Enabled = false;
            this.bttn_RegisterButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttn_RegisterButton.ForeColor = System.Drawing.Color.White;
            this.bttn_RegisterButton.Location = new System.Drawing.Point(137, 424);
            this.bttn_RegisterButton.Name = "bttn_RegisterButton";
            this.bttn_RegisterButton.Size = new System.Drawing.Size(256, 45);
            this.bttn_RegisterButton.TabIndex = 47;
            this.bttn_RegisterButton.Text = "Зареєструватися";
            this.bttn_RegisterButton.UseVisualStyleBackColor = false;
            this.bttn_RegisterButton.Click += new System.EventHandler(this.bttn_RegisterButton_Click);
            this.bttn_RegisterButton.MouseEnter += new System.EventHandler(this.bttn_RegisterButton_MouseEnter);
            this.bttn_RegisterButton.MouseLeave += new System.EventHandler(this.bttn_RegisterButton_MouseLeave);
            // 
            // txtBox_RegisterPassword
            // 
            this.txtBox_RegisterPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_RegisterPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBox_RegisterPassword.Location = new System.Drawing.Point(137, 288);
            this.txtBox_RegisterPassword.Name = "txtBox_RegisterPassword";
            this.txtBox_RegisterPassword.Size = new System.Drawing.Size(256, 29);
            this.txtBox_RegisterPassword.TabIndex = 46;
            this.txtBox_RegisterPassword.Enter += new System.EventHandler(this.txtBox_RegisterPassword_Enter);
            this.txtBox_RegisterPassword.Leave += new System.EventHandler(this.txtBox_RegisterPassword_Leave);
            this.txtBox_RegisterPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBox_RegisterPassword_MouseDown);
            // 
            // txtBox_RegisterConfirmPassword
            // 
            this.txtBox_RegisterConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_RegisterConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBox_RegisterConfirmPassword.Location = new System.Drawing.Point(137, 336);
            this.txtBox_RegisterConfirmPassword.Name = "txtBox_RegisterConfirmPassword";
            this.txtBox_RegisterConfirmPassword.Size = new System.Drawing.Size(256, 29);
            this.txtBox_RegisterConfirmPassword.TabIndex = 54;
            this.txtBox_RegisterConfirmPassword.Enter += new System.EventHandler(this.txtBox_RegisterConfirmPassword_Enter);
            this.txtBox_RegisterConfirmPassword.Leave += new System.EventHandler(this.txtBox_RegisterConfirmPassword_Leave);
            this.txtBox_RegisterConfirmPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBox_RegisterConfirmPassword_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(572, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 30);
            this.button1.TabIndex = 56;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(528, 25);
            this.toolStrip1.TabIndex = 57;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton3.Text = "Вийти";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // chkBox_Remember
            // 
            this.chkBox_Remember.AutoSize = true;
            this.chkBox_Remember.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chkBox_Remember.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkBox_Remember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBox_Remember.Location = new System.Drawing.Point(137, 371);
            this.chkBox_Remember.Name = "chkBox_Remember";
            this.chkBox_Remember.Size = new System.Drawing.Size(211, 46);
            this.chkBox_Remember.TabIndex = 58;
            this.chkBox_Remember.Text = "Я даю згоду на обробку \r\nособистих даних";
            this.chkBox_Remember.UseVisualStyleBackColor = false;
            this.chkBox_Remember.CheckedChanged += new System.EventHandler(this.chkBox_Remember_CheckedChanged);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::XAI_BIBLE.Properties.Resources.Screenshot_12;
            this.ClientSize = new System.Drawing.Size(528, 586);
            this.Controls.Add(this.chkBox_Remember);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBox_RegisterConfirmPassword);
            this.Controls.Add(this.bttn_RegisterLinkLabel);
            this.Controls.Add(this.Avatar);
            this.Controls.Add(this.txtBox_RegisterLogin);
            this.Controls.Add(this.registerlabel);
            this.Controls.Add(this.bttn_RegisterButton);
            this.Controls.Add(this.txtBox_RegisterPassword);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.Shown += new System.EventHandler(this.Register_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Register_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Register_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.LinkLabel bttn_RegisterLinkLabel;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.TextBox txtBox_RegisterLogin;
        private System.Windows.Forms.Label registerlabel;
        private System.Windows.Forms.Button bttn_RegisterButton;
        private System.Windows.Forms.TextBox txtBox_RegisterPassword;
        private System.Windows.Forms.TextBox txtBox_RegisterConfirmPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.CheckBox chkBox_Remember;
    }
}