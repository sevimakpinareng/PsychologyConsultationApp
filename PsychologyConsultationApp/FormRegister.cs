using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologyConsultationApp
{
    public partial class FormRegister: Form
    {
        public FormRegister()
        {
            InitializeComponent();
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
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }
    }
}
