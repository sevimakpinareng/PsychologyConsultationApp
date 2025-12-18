namespace PsychologyConsultationApp
{
    partial class PatientDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblComplaint = new System.Windows.Forms.Label();
            this.txtComplaint = new System.Windows.Forms.TextBox();
            this.btnSuggest = new System.Windows.Forms.Button();
            this.lblSpecialist = new System.Windows.Forms.Label();
            this.cmbSpecialists = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.btnCreateAppointment = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecialist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComplaint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNewComplaint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(24, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(129, 28);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Hasta Paneli";
            // 
            // lblComplaint
            // 
            this.lblComplaint.AutoSize = true;
            this.lblComplaint.Location = new System.Drawing.Point(26, 64);
            this.lblComplaint.Name = "lblComplaint";
            this.lblComplaint.Size = new System.Drawing.Size(92, 17);
            this.lblComplaint.TabIndex = 1;
            this.lblComplaint.Text = "Şikayetiniz:";
            // 
            // txtComplaint
            // 
            this.txtComplaint.Location = new System.Drawing.Point(29, 84);
            this.txtComplaint.Multiline = true;
            this.txtComplaint.Name = "txtComplaint";
            this.txtComplaint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComplaint.Size = new System.Drawing.Size(350, 120);
            this.txtComplaint.TabIndex = 2;
            // 
            // btnSuggest
            // 
            this.btnSuggest.Location = new System.Drawing.Point(29, 210);
            this.btnSuggest.Name = "btnSuggest";
            this.btnSuggest.Size = new System.Drawing.Size(150, 30);
            this.btnSuggest.TabIndex = 3;
            this.btnSuggest.Text = "Uzman Öner";
            this.btnSuggest.UseVisualStyleBackColor = true;
            this.btnSuggest.Click += new System.EventHandler(this.btnSuggest_Click);
            // 
            // lblSpecialist
            // 
            this.lblSpecialist.AutoSize = true;
            this.lblSpecialist.Location = new System.Drawing.Point(26, 253);
            this.lblSpecialist.Name = "lblSpecialist";
            this.lblSpecialist.Size = new System.Drawing.Size(108, 17);
            this.lblSpecialist.TabIndex = 4;
            this.lblSpecialist.Text = "Uzman Seçimi:";
            // 
            // cmbSpecialists
            // 
            this.cmbSpecialists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialists.FormattingEnabled = true;
            this.cmbSpecialists.Location = new System.Drawing.Point(29, 273);
            this.cmbSpecialists.Name = "cmbSpecialists";
            this.cmbSpecialists.Size = new System.Drawing.Size(350, 24);
            this.cmbSpecialists.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(26, 312);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(88, 17);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Randevu tarihi";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(29, 332);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(247, 312);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(88, 17);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Randevu saati";
            // 
            // cmbTime
            // 
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(250, 332);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(129, 24);
            this.cmbTime.TabIndex = 9;
            // 
            // btnCreateAppointment
            // 
            this.btnCreateAppointment.Location = new System.Drawing.Point(29, 370);
            this.btnCreateAppointment.Name = "btnCreateAppointment";
            this.btnCreateAppointment.Size = new System.Drawing.Size(167, 32);
            this.btnCreateAppointment.TabIndex = 10;
            this.btnCreateAppointment.Text = "Randevu Oluştur";
            this.btnCreateAppointment.UseVisualStyleBackColor = true;
            this.btnCreateAppointment.Click += new System.EventHandler(this.btnCreateAppointment_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colSpecialist,
            this.colDate,
            this.colTime,
            this.colStatus,
            this.colComplaint,
            this.colNotes});
            this.dgvAppointments.Location = new System.Drawing.Point(400, 50);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(620, 352);
            this.dgvAppointments.TabIndex = 11;
            this.dgvAppointments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAppointments_CellFormatting);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 125;
            // 
            // colSpecialist
            // 
            this.colSpecialist.HeaderText = "Uzman";
            this.colSpecialist.MinimumWidth = 6;
            this.colSpecialist.Name = "colSpecialist";
            this.colSpecialist.ReadOnly = true;
            this.colSpecialist.Width = 150;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Tarih";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 90;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Saat";
            this.colTime.MinimumWidth = 6;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Durum";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 90;
            // 
            // colComplaint
            // 
            this.colComplaint.HeaderText = "Şikayet";
            this.colComplaint.MinimumWidth = 6;
            this.colComplaint.Name = "colComplaint";
            this.colComplaint.ReadOnly = true;
            this.colComplaint.Width = 160;
            // 
            // colNotes
            // 
            this.colNotes.HeaderText = "Seans Notu";
            this.colNotes.MinimumWidth = 6;
            this.colNotes.Name = "colNotes";
            this.colNotes.ReadOnly = true;
            this.colNotes.Width = 150;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(212, 370);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 32);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(400, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 26);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Randevuları Yenile";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(930, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 32);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Geri Dön";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNewComplaint
            // 
            this.btnNewComplaint.Location = new System.Drawing.Point(298, 370);
            this.btnNewComplaint.Name = "btnNewComplaint";
            this.btnNewComplaint.Size = new System.Drawing.Size(81, 32);
            this.btnNewComplaint.TabIndex = 15;
            this.btnNewComplaint.Text = "Yeni";
            this.btnNewComplaint.UseVisualStyleBackColor = true;
            this.btnNewComplaint.Click += new System.EventHandler(this.btnNewComplaint_Click);
            // 
            // PatientDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 430);
            this.Controls.Add(this.btnNewComplaint);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.btnCreateAppointment);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbSpecialists);
            this.Controls.Add(this.lblSpecialist);
            this.Controls.Add(this.btnSuggest);
            this.Controls.Add(this.txtComplaint);
            this.Controls.Add(this.lblComplaint);
            this.Controls.Add(this.lblWelcome);
            this.Name = "PatientDashboard";
            this.Text = "Hasta Paneli";
            this.Load += new System.EventHandler(this.PatientDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblComplaint;
        private System.Windows.Forms.TextBox txtComplaint;
        private System.Windows.Forms.Button btnSuggest;
        private System.Windows.Forms.Label lblSpecialist;
        private System.Windows.Forms.ComboBox cmbSpecialists;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.Button btnCreateAppointment;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNewComplaint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecialist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComplaint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
    }
}
