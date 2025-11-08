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
    public partial class EnterNames : Form
    {
        public ChoseGame f1;
        private int nextLabelY;
        private int nexttxtY;
        public static List<string> allNames = new List<string>();
        private List<TextBox> textBoxes = new List<TextBox>();
        int t = 0;
        public EnterNames()
        {
            InitializeComponent();
            nextLabelY = lblName.Location.Y + lblName.Height +40;
            nexttxtY = txtGamerName.Location.Y + txtGamerName.Height + 20;
        }
        private void btnAddName_Click(object sender, EventArgs e)
        {
            //add label
            Label newlabel = new Label();
            newlabel.Text = lblName.Text;
            newlabel.AutoSize = true;
            newlabel.Location = new Point(lblName.Location.X, nextLabelY);
            this.Controls.Add(newlabel);
            nextLabelY += newlabel.Height + 40;
            //add textbox
            TextBox newtxt = new TextBox();
            newtxt.Location = new Point(txtGamerName.Location.X, nexttxtY);
            newtxt.Size = txtGamerName.Size;
            newtxt.Multiline = true;
            this.Controls.Add(newtxt);
            nexttxtY += newtxt.Height + 20;
            textBoxes.Add(newtxt);

            t++;
            if (t == 3)
                btnAddName.Enabled = false;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            //add names in varible
            allNames.Add(txtGamerName.Text);
            foreach (TextBox tb in textBoxes) 
            {
                if (string.IsNullOrWhiteSpace(tb.Text)) 
                {
                    MessageBox.Show("لطفاً همه تکست‌باکس‌ها را پر کنید!");
                    return;
                }
                allNames.Add(tb.Text);
            }

            game f3 = new game();
            f3.Show();
        }

        private void EnterNames_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
        }

    }
}
