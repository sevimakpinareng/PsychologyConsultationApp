using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PsychologyConsultationApp
{
    public partial class PatientDashboard : Form
    {
        public int LoggedUserId { get; set; }
        public string LoggedUserName { get; set; }

        private readonly string connectionString;

        public PatientDashboard()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            dtpDate.MinDate = DateTime.Today;
        }

        private void PatientDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = string.IsNullOrWhiteSpace(LoggedUserName)
                ? "Hasta Paneli"
                : $"Hasta Paneli - {LoggedUserName}";

            FillTimeSlots();
            LoadSpecialists();
            LoadAppointments();
        }

        private void FillTimeSlots()
        {
            cmbTime.Items.Clear();
            string[] slots = { "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "16:00" };
            cmbTime.Items.AddRange(slots);
            if (cmbTime.Items.Count > 0)
            {
                cmbTime.SelectedIndex = 0;
            }
        }

        private void LoadSpecialists(string keyword = null)
        {
            cmbSpecialists.Items.Clear();

            string query = "SELECT Id, FullName, Specialty FROM dbo.Users WHERE Role='Uzman'";
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query += " AND (Specialty LIKE @kw OR FullName LIKE @kw)";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                }

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    string display = $"{dr["FullName"]} - {dr["Specialty"]} (#{id})";
                    cmbSpecialists.Items.Add(new ComboBoxItem(display, id));
                }
            }

            if (cmbSpecialists.Items.Count > 0)
            {
                cmbSpecialists.SelectedIndex = 0;
            }
        }

        private void LoadAppointments()
        {
            dgvAppointments.Rows.Clear();

            string query = @"
SELECT A.Id, U.FullName AS SpecialistName, A.AppointmentDate, A.AppointmentTime, A.Status, A.ComplaintText, A.SessionNotes
FROM dbo.Appointments A
INNER JOIN dbo.Users U ON U.Id = A.SpecialistId
WHERE A.PatientId=@pid
ORDER BY A.AppointmentDate, A.AppointmentTime";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@pid", LoggedUserId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgvAppointments.Rows.Add(
                        dr["Id"],
                        dr["SpecialistName"],
                        Convert.ToDateTime(dr["AppointmentDate"]).ToString("dd.MM.yyyy"),
                        TimeSpan.Parse(dr["AppointmentTime"].ToString()).ToString("hh\\:mm"),
                        dr["Status"],
                        dr["ComplaintText"],
                        dr["SessionNotes"]
                    );
                }
            }
        }

        private string DetectKeyword()
        {
            string text = txtComplaint.Text.ToLower();
            if (text.Contains("anksiyete")) return "Anksiyete";
            if (text.Contains("depres")) return "Depresyon";
            if (text.Contains("uyku")) return "Uyku";
            if (text.Contains("sınav") || text.Contains("stres")) return "Sınav";
            if (text.Contains("çocuk") || text.Contains("ergen")) return "Çocuk";
            return null;
        }

        private void btnSuggest_Click(object sender, EventArgs e)
        {
            string keyword = DetectKeyword();
            if (keyword == null)
            {
                LoadSpecialists();
                MessageBox.Show("Şikayet metninde eşleşme bulunamadı. Tüm uzmanlar listelendi.");
            }
            else
            {
                LoadSpecialists(keyword);
                MessageBox.Show($"Şikayet anahtar kelimesi: {keyword}. Uygun uzmanlar listelendi.");
            }
        }

        private void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            if (LoggedUserId == 0)
            {
                MessageBox.Show("Geçerli kullanıcı bilgisi bulunamadı.");
                return;
            }

            if (cmbSpecialists.SelectedItem is not ComboBoxItem specialistItem)
            {
                MessageBox.Show("Lütfen bir uzman seçiniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComplaint.Text))
            {
                MessageBox.Show("Şikayet alanı boş bırakılamaz.");
                return;
            }

            if (cmbTime.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir saat seçiniz.");
                return;
            }

            DateTime date = dtpDate.Value.Date;
            TimeSpan time = TimeSpan.Parse(cmbTime.SelectedItem.ToString());

            if (!IsSlotAvailable(specialistItem.Value, date, time))
            {
                MessageBox.Show("Seçilen uzman için bu saat dolu. Lütfen başka bir saat seçin.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.Appointments
                (PatientId, SpecialistId, AppointmentDate, AppointmentTime, Status, ComplaintText)
                VALUES (@pid, @sid, @date, @time, 'Bekliyor', @complaint)", conn))
            {
                cmd.Parameters.AddWithValue("@pid", LoggedUserId);
                cmd.Parameters.AddWithValue("@sid", specialistItem.Value);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@complaint", txtComplaint.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Randevu oluşturuldu.");
            LoadAppointments();
        }

        private bool IsSlotAvailable(int specialistId, DateTime date, TimeSpan time)
        {
            string query = @"
SELECT COUNT(1) FROM dbo.Appointments
WHERE SpecialistId=@sid AND AppointmentDate=@date AND AppointmentTime=@time AND Status<>'İptal'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@sid", specialistId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@time", time);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtComplaint.Clear();
            cmbSpecialists.SelectedIndex = cmbSpecialists.Items.Count > 0 ? 0 : -1;
            cmbTime.SelectedIndex = cmbTime.Items.Count > 0 ? 0 : -1;
            dtpDate.Value = DateTime.Today;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewComplaint_Click(object sender, EventArgs e)
        {
            txtComplaint.Focus();
            txtComplaint.SelectAll();
        }

        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        }

        private class ComboBoxItem
        {
            public string Text { get; }
            public int Value { get; }
            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString() => Text;
        }
    }
}
