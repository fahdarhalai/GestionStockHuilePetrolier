using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuileWinForm
{
    public partial class Acceuil : Form
    {
        public Acceuil()
        {
            InitializeComponent();
        }

        private void buttonEntrer_Click(object sender, EventArgs e)
        {
            Gestionnaire gestionnaire = new Gestionnaire();
            gestionnaire.Location = this.Location;
            gestionnaire.StartPosition = FormStartPosition.Manual;
            gestionnaire.FormClosing += delegate { this.Show(); };
            gestionnaire.Show();
            this.Hide();
            gestionnaire.Closed += (s, args) => this.Close();
        }

        private void buttonApropos_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.panel1.Visible = true;
        }

        private void buttonRetourner_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.panel1.Visible = false;
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonQuitter2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
    }
}
