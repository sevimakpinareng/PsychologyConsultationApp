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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Id, FullName, Role FROM dbo.Users 
                                 WHERE Email=@email AND PasswordHash=@password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int userId = Convert.ToInt32(dr["Id"]);
                    string fullName = dr["FullName"].ToString();
                    string role = dr["Role"].ToString();

                    MessageBox.Show("Giriş başarılı: " + role);

                    if (role == "Hasta")
                    {
                        PatientDashboard p = new PatientDashboard();
                        p.LoggedUserId = userId;
                        p.LoggedUserName = fullName;
                        p.Show();
                    }
                    else if (role == "Uzman")
                    {
                        SpecialistDashboard s = new SpecialistDashboard();
                        s.LoggedUserId = userId;
                        s.LoggedUserName = fullName;
                        s.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bu role özel panel yok: " + role);
                        return;
                    }

                    this.Hide();
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
            FormRegister register = new FormRegister();
            register.Show();
            this.Hide();
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
