using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mar_peleh
{
    public partial class ChoseGame : Form
    {
        public ChoseGame()
        {
            InitializeComponent();
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            DialogResult a=MessageBox.Show("آیا مطمئنی که میخوای از برنامه خارج بشی؟", "خروج",MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
                this.Close();
        }

        private void btnComputerGame_Click(object sender, EventArgs e)
        {
            EnterNames f2 = new EnterNames();
            f2.btnAddName.Enabled = false;
            f2.f1 = this;
            f2.Show();
            this.Hide();
        }

        private void btnHumanGame_Click(object sender, EventArgs e)
        {
            EnterNames f2 = new EnterNames();
            f2.f1 = this;
            f2.Show();
            this.Hide();
        }


        private void ChoseGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

    }
}
