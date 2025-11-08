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
        private int NextLabelY;
        private int NextTxtY;
        public static List<string> AllNames = new List<string>();
        private List<TextBox> TextBoxes = new List<TextBox>();
        int t = 0;
        public EnterNames()
        {
            InitializeComponent();
            NextLabelY = lblName.Location.Y + lblName.Height +40;
            NextTxtY = txtGamerName.Location.Y + txtGamerName.Height + 20;
        }
        private void btnAddName_Click(object sender, EventArgs e)
        {
            //add label
            Label newlabel = new Label();
            newlabel.Text = lblName.Text;
            newlabel.AutoSize = true;
            newlabel.Location = new Point(lblName.Location.X, NextLabelY);
            this.Controls.Add(newlabel);
            NextLabelY += newlabel.Height + 40;
            //add textbox
            TextBox newtxt = new TextBox();
            newtxt.Location = new Point(txtGamerName.Location.X, NextTxtY);
            newtxt.Size = txtGamerName.Size;
            newtxt.Multiline = true;
            this.Controls.Add(newtxt);
            NextTxtY += newtxt.Height + 20;
            TextBoxes.Add(newtxt);

            t++;
            if (t == 3)
                btnAddName.Enabled = false;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            //add names in varible
            AllNames.Add(txtGamerName.Text);
            foreach (TextBox tb in TextBoxes) 
            {
                if (string.IsNullOrWhiteSpace(tb.Text)) 
                {
                    MessageBox.Show("لطفاً همه تکست‌باکس‌ها را پر کنید!");
                    return;
                }
                AllNames.Add(tb.Text);
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
