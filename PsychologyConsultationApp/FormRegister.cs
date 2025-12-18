using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PsychologyConsultationApp
{
    public partial class FormRegister: Form
    {
        private readonly string connectionString;

        public FormRegister()
        {
            InitializeComponent();
            connectionString = ConfigurationManager
                .ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void guna2HtmlLabel2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;

        }

        private void guna2HtmlLabel2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            using (FormLogin login = new FormLogin())
            {
                login.StartPosition = FormStartPosition.CenterParent;
                login.ShowDialog(this);
            }

            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string fullName = guna2TextBox1.Text.Trim();
            string email = guna2TextBox2.Text.Trim();
            string password = guna2TextBox3.Text;
            string passwordConfirm = guna2TextBox4.Text;

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(passwordConfirm))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (password != passwordConfirm)
            {
                MessageBox.Show("Şifreler uyuşmuyor.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string insertQuery = @"INSERT INTO dbo.Users (FullName, Email, PasswordHash, Role)
                                      VALUES (@fullName, @email, @password, 'Hasta')";

                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Kayıt başarılı! Giriş ekranına yönlendiriliyorsunuz.");
                    using (FormLogin login = new FormLogin())
                    {
                        login.StartPosition = FormStartPosition.CenterParent;
                        login.ShowDialog(this);
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu.");
                }
            }
        }
    }
}
