using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PsychologyConsultationApp
{
    public partial class SpecialistDashboard : Form
    {
        public int LoggedUserId { get; set; }
        public string LoggedUserName { get; set; }

        private readonly string connectionString;
        private int hoveredRowIndex = -1;

        public SpecialistDashboard()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            cmbFilter.Items.AddRange(new object[] { "Tümü", "Bugün", "Bu Hafta", "Bu Ay", "Bekleyenler", "İptaller" });
            if (cmbFilter.Items.Count > 0) cmbFilter.SelectedIndex = 0;
        }

        private void SpecialistDashboard_Load(object sender, EventArgs e)
        {
            lblHeader.Text = string.IsNullOrWhiteSpace(LoggedUserName)
                ? "Uzman Paneli"
                : $"Uzman Paneli - {LoggedUserName}";

            LoadAppointments();
        }

        private void LoadAppointments()
        {
            dgvAppointments.Rows.Clear();

            string query = @"
SELECT A.Id, P.FullName AS PatientName, A.AppointmentDate, A.AppointmentTime, A.Status, A.ComplaintText, A.SessionNotes
FROM dbo.Appointments A
INNER JOIN dbo.Users P ON P.Id = A.PatientId
WHERE A.SpecialistId=@sid
";

            string filter = cmbFilter.SelectedItem?.ToString();
            if (filter == "Bekleyenler") query += " AND A.Status='Bekliyor'";
            else if (filter == "İptaller") query += " AND A.Status='İptal'";
            else if (filter == "Bugün") query += " AND A.AppointmentDate = CAST(GETDATE() AS DATE)";
            else if (filter == "Bu Hafta") query += " AND A.AppointmentDate BETWEEN CAST(DATEADD(DAY,-DATEPART(WEEKDAY, GETDATE())+1, GETDATE()) AS DATE) AND CAST(DATEADD(DAY,7-DATEPART(WEEKDAY, GETDATE()), GETDATE()) AS DATE)";
            else if (filter == "Bu Ay") query += " AND MONTH(A.AppointmentDate)=MONTH(GETDATE()) AND YEAR(A.AppointmentDate)=YEAR(GETDATE())";

            query += " ORDER BY A.AppointmentDate, A.AppointmentTime";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@sid", LoggedUserId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgvAppointments.Rows.Add(
                        dr["Id"],
                        dr["PatientName"],
                        Convert.ToDateTime(dr["AppointmentDate"]).ToString("dd.MM.yyyy"),
                        TimeSpan.Parse(dr["AppointmentTime"].ToString()).ToString("hh\\:mm"),
                        dr["Status"],
                        dr["ComplaintText"],
                        dr["SessionNotes"],
                        "Onayla",
                        "İptal",
                        "Not Gir"
                    );
                }
            }
        }

        private void UpdateStatus(int appointmentId, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("UPDATE dbo.Appointments SET Status=@status WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", appointmentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void SaveSessionNote(int appointmentId, string note)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("UPDATE dbo.Appointments SET SessionNotes=@note WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@id", appointmentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int appointmentId = Convert.ToInt32(dgvAppointments.Rows[e.RowIndex].Cells["colId"].Value);
            string columnName = dgvAppointments.Columns[e.ColumnIndex].Name;

            if (columnName == "colApprove")
            {
                UpdateStatus(appointmentId, "Onaylandı");
                LoadAppointments();
            }
            else if (columnName == "colCancel")
            {
                UpdateStatus(appointmentId, "İptal");
                LoadAppointments();
            }
            else if (columnName == "colNote")
            {
                string existingNote = dgvAppointments.Rows[e.RowIndex].Cells["colNotes"].Value?.ToString();
                string note = PromptNote(existingNote);
                if (note != null)
                {
                    SaveSessionNote(appointmentId, note);
                    LoadAppointments();
                }
            }
        }

        private string PromptNote(string existing)
        {
            using (Form dialog = new Form())
            {
                dialog.Width = 400;
                dialog.Height = 220;
                dialog.Text = "Seans Notu";
                TextBox txt = new TextBox { Left = 15, Top = 15, Width = 350, Height = 100, Multiline = true, Text = existing };
                Button ok = new Button { Text = "Kaydet", Left = 210, Width = 75, Top = 130, DialogResult = DialogResult.OK };
                Button cancel = new Button { Text = "Vazgeç", Left = 290, Width = 75, Top = 130, DialogResult = DialogResult.Cancel };
                dialog.Controls.Add(txt);
                dialog.Controls.Add(ok);
                dialog.Controls.Add(cancel);
                dialog.AcceptButton = ok;
                dialog.CancelButton = cancel;

                return dialog.ShowDialog(this) == DialogResult.OK ? txt.Text : null;
            }
        }

        private void dgAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAppointments.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Onaylandı")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else if (status == "İptal")
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Khaki;
                }
            }

            if (e.RowIndex == hoveredRowIndex && e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.LightSteelBlue;
            }
        }

        private void dgAppointments_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dgvAppointments.HitTest(e.X, e.Y);
            if (hit.RowIndex != hoveredRowIndex)
            {
                hoveredRowIndex = hit.RowIndex;
                dgvAppointments.Invalidate();
            }
        }

        private void dgAppointments_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            dgvAppointments.Invalidate();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
