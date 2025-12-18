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
    public partial class PatientDashboard : Form
    {
        public int LoggedUserId { get; set; }
        public string LoggedUserName { get; set; }

        public PatientDashboard()
        {
            InitializeComponent();
        }

        private void PatientDashboard_Load(object sender, EventArgs e)
        {
            // Giriş yapan kullanıcının adını başlığa ekle
            if (!string.IsNullOrWhiteSpace(LoggedUserName))
            {
                this.Text = $"Hasta Paneli - {LoggedUserName}";
            }
        }
    }
}
