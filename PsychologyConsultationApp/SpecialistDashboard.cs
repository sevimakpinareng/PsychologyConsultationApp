using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PsychologyConsultationApp
{
    public partial class SpecialistDashboard : Form
        
    {
      
        
        // 🔹 Son giriş yapan kullanıcının bilgileri
        public int LoggedUserId { get; set; }
        public string LoggedUserName { get; set; }

        // SQL bağlantısı
        string connectionString =
            @"Server=.;Database=PsychologyDB;Trusted_Connection=True;";

        int hoveredRowIndex = -1;

        public SpecialistDashboard()
        {
            InitializeComponent();

            dgAppointments.AutoGenerateColumns = false;
            dgAppointments.CellFormatting += dgAppointments_CellFormatting;
        }

        // FORM LOAD
        private void SpecialistDashboard_Load(object sender, EventArgs e)
        {
            // Kullanıcı adını göster (istersen label ekleriz)
            Console.WriteLine($"Uzman giriş yaptı: {LoggedUserName} (ID: {LoggedUserId})");

            LoadAppointments();
        }

        // SQL'DEN VERİ ÇEK
        private void LoadAppointments()
        {
            dgAppointments.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        PatientName,
                        AppointmentDate,
                        AppointmentTime,
                        Status
                    FROM Appointments
                    ORDER BY AppointmentDate, AppointmentTime";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgAppointments.Rows.Add(
                        dr["PatientName"].ToString(),
                        dr["AppointmentDate"],
                        dr["AppointmentTime"],
                        dr["Status"].ToString()
                    );
                }
            }
        }

        // TABLO RENDER
        private void dgAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = dgAppointments.Columns[e.ColumnIndex].Name;

            // DURUM RENKLERİ
            if (columnName == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "Onaylandı")
                {
                    e.CellStyle.BackColor = Color.FromArgb(46, 204, 113);
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (status == "Bekliyor")
                {
                    e.CellStyle.BackColor = Color.FromArgb(241, 196, 15);
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (status == "İptal")
                {
                    e.CellStyle.BackColor = Color.FromArgb(231, 76, 60);
                    e.CellStyle.ForeColor = Color.White;
                }

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            // TARİH
            if (columnName == "AppointmentDate" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd.MM.yyyy");
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            // SAAT
            if (columnName == "AppointmentTime" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime time))
                {
                    e.Value = time.ToString("HH:mm");
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            // HOVER
            if (e.RowIndex == hoveredRowIndex && e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(220, 230, 245);
            }
        }

        // HOVER MOVE
        private void dgAppointments_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dgAppointments.HitTest(e.X, e.Y);

            if (hit.RowIndex != hoveredRowIndex)
            {
                hoveredRowIndex = hit.RowIndex;
                dgAppointments.Invalidate();
            }
        }

        // HOVER OUT
        private void dgAppointments_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            dgAppointments.Invalidate();
        }

        // ÇIKIŞ
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        // ZORUNLU
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        // ZORUNLU
        private void dgAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
