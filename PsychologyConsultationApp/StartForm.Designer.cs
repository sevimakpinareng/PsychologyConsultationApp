namespace PsychologyConsultationApp
{
    partial class StartForm
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnSpecialistLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnPatientLogin = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.BorderRadius = 8;
            this.pnlContainer.Controls.Add(this.btnExit);
            this.pnlContainer.Controls.Add(this.btnSpecialistLogin);
            this.pnlContainer.Controls.Add(this.btnPatientLogin);
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.FillColor = System.Drawing.Color.White;
            this.pnlContainer.Location = new System.Drawing.Point(40, 30);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.ShadowDecoration.Depth = 10;
            this.pnlContainer.ShadowDecoration.Enabled = true;
            this.pnlContainer.Size = new System.Drawing.Size(400, 320);
            this.pnlContainer.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 4;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.LightGray;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(140, 240);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 35);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Çıkış";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSpecialistLogin
            // 
            this.btnSpecialistLogin.BorderRadius = 5;
            this.btnSpecialistLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSpecialistLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSpecialistLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSpecialistLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSpecialistLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(108)))), ((int)(((byte)(247)))));
            this.btnSpecialistLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSpecialistLogin.ForeColor = System.Drawing.Color.White;
            this.btnSpecialistLogin.Location = new System.Drawing.Point(80, 170);
            this.btnSpecialistLogin.Name = "btnSpecialistLogin";
            this.btnSpecialistLogin.Size = new System.Drawing.Size(240, 40);
            this.btnSpecialistLogin.TabIndex = 2;
            this.btnSpecialistLogin.Text = "Uzman Girişi";
            this.btnSpecialistLogin.Click += new System.EventHandler(this.btnSpecialistLogin_Click);
            // 
            // btnPatientLogin
            // 
            this.btnPatientLogin.BorderRadius = 5;
            this.btnPatientLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPatientLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPatientLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPatientLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPatientLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnPatientLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPatientLogin.ForeColor = System.Drawing.Color.White;
            this.btnPatientLogin.Location = new System.Drawing.Point(80, 110);
            this.btnPatientLogin.Name = "btnPatientLogin";
            this.btnPatientLogin.Size = new System.Drawing.Size(240, 40);
            this.btnPatientLogin.TabIndex = 1;
            this.btnPatientLogin.Text = "Hasta Girişi";
            this.btnPatientLogin.Click += new System.EventHandler(this.btnPatientLogin_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitle.Location = new System.Drawing.Point(136, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PsikoPanel";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(480, 380);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PsikoPanel";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnPatientLogin;
        private Guna.UI2.WinForms.Guna2Button btnSpecialistLogin;
        private Guna.UI2.WinForms.Guna2Button btnExit;
    }
}
