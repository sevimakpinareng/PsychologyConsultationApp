using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PsychologyConsultationApp
{
    public partial class SpecialistLogin : Form
    {
        private readonly string connectionString;

        public SpecialistLogin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager
                .ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSpecialistId.Text, out int specialistId))
            {
                MessageBox.Show("Uzman ID sadece rakamlardan oluşmalıdır.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Id, FullName FROM dbo.Users
                                 WHERE Id=@id AND PasswordHash=@password AND Role='Uzman'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", specialistId);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int userId = Convert.ToInt32(dr["Id"]);
                    string fullName = dr["FullName"].ToString();

                    SpecialistDashboard s = new SpecialistDashboard();
                    s.LoggedUserId = userId;
                    s.LoggedUserName = fullName;
                    s.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ID veya şifre hatalı!");
                }
            }
        }

        private void pnlLoginBox_Paint(object sender, PaintEventArgs e)
        {
            // Tasarım alanı
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            if (this.Owner is StartForm startForm)
            {
                startForm.Show();
            }

            this.Close();
        }

        private void lblBack_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblBack_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
