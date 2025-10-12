using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgl
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void entrar_lp_Click(object sender, EventArgs e)
        {
            //abrir projeto sglform
            this.Hide();
            sglform sglform = new sglform();
            sglform.ShowDialog();
        }

        private void lbl_sair_lp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
