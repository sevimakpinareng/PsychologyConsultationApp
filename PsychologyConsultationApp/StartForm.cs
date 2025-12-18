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
            using (FormLogin login = new FormLogin())
            {
                login.StartPosition = FormStartPosition.CenterParent;
                login.ShowDialog(this);
            }
        }

        private void btnSpecialistLogin_Click(object sender, EventArgs e)
        {
            using (SpecialistLogin specialistLogin = new SpecialistLogin())
            {
                specialistLogin.StartPosition = FormStartPosition.CenterParent;
                specialistLogin.ShowDialog(this);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
