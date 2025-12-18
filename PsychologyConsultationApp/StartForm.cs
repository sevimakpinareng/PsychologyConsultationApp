using System;
using System.Windows.Forms;

namespace PsychologyConsultationApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnPatientLogin_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Owner = this;
            login.FormClosed += (_, __) => this.Show();
            login.Show();
            this.Hide();
        }

        private void btnSpecialistLogin_Click(object sender, EventArgs e)
        {
            SpecialistLogin specialistLogin = new SpecialistLogin();
            specialistLogin.Owner = this;
            specialistLogin.FormClosed += (_, __) => this.Show();
            specialistLogin.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
