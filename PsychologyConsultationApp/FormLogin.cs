using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PsychologyConsultationApp
{
    public partial class FormLogin : Form
    {
        private string connectionString;

        public FormLogin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager
                .ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("E-posta ve şifre boş bırakılamaz.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Id, FullName FROM dbo.Users
                                 WHERE Email=@email AND PasswordHash=@password AND Role='Hasta'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int userId = Convert.ToInt32(dr["Id"]);
                    string fullName = dr["FullName"].ToString();

                    using (PatientDashboard p = new PatientDashboard())
                    {
                        p.LoggedUserId = userId;
                        p.LoggedUserName = fullName;
                        p.StartPosition = FormStartPosition.CenterParent;
                        p.ShowDialog(this);
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("E-posta veya şifre hatalı!");
                }
            }
        }

        private void pnlLoginBox_Paint(object sender, PaintEventArgs e)
        {
            // Tasarımsal çizimler için boş bırakıldı
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            using (FormRegister register = new FormRegister())
            {
                register.StartPosition = FormStartPosition.CenterParent;
                register.ShowDialog(this);
            }
        }

        private void guna2HtmlLabel1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void guna2HtmlLabel1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Başlık etiketi için özel bir işlem gerekmiyor
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
