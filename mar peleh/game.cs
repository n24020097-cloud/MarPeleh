using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace mar_peleh
{
    public partial class game : Form
    {
        Random rnd = new Random();
        List<PictureBox> mohre = new List<PictureBox>();
        List<bool> isOutside = new List<bool>();
        List<int> GamerCells=new List<int>();
        List<bool> ltrList = new List<bool>(); 
        int TassNumber;
        int TurnGamer=0;
        int stepsLeft = 0;
        int NumberOfPlayer = EnterNames.allNames.Count;
        Color[] c = { Color.Red, Color.Green, Color.Yellow,Color.Blue};
        public game()
        {
            InitializeComponent();
        }

        private void game_Load(object sender, EventArgs e)
        {
            if (NumberOfPlayer == 1)
            {
                NumberOfPlayer = 2;
                EnterNames.allNames.Add("کامپیوتر");
            }
            //add mohre in list
            if (NumberOfPlayer >= 1) mohre.Add(pcbGamer1);
            if (NumberOfPlayer >= 2) mohre.Add(pcbGamer2);
            if (NumberOfPlayer >= 3) mohre.Add(pcbGamer3);
            if (NumberOfPlayer >= 4) mohre.Add(pcbGamer4);


            // set location and direction
            for (int i = 0; i < mohre.Count; i++)
            {
                isOutside.Add(true);
                GamerCells.Add(1);
                ltrList.Add(true);
            }
            lblTurn.ForeColor = c[TurnGamer];
            lblTurn.Text = "نوبت: " + EnterNames.allNames[TurnGamer] + " است"; 
        }

        public void PlaySound(string soundFile)
        {
            SoundPlayer player = new SoundPlayer(soundFile);
            player.Play();
        }

        private void pictureBoxTass_Click(object sender, EventArgs e)
        {
            CheckTass();
        }

        private void CheckTass()
        {
            PlaySound("sound/tassSound.wav");
            TassNumber = rnd.Next(1, 7);
            pictureBoxTass.ImageLocation = "img/i" + TassNumber + ".PNG";
            stepsLeft = TassNumber;
            if (isOutside[TurnGamer])
            {
                if (TassNumber == 6)
                {
                    mohre[TurnGamer].Parent = pictureBoxGame;
                    mohre[TurnGamer].Location = new Point(
                    lblCell1.Location.X - pictureBoxGame.Location.X + (lblCell1.Width / 2) - (mohre[TurnGamer].Width / 2),
                    lblCell1.Location.Y - pictureBoxGame.Location.Y + (lblCell1.Height / 2) - (mohre[TurnGamer].Height / 2));
                    isOutside[TurnGamer] = false;
                    stepsLeft = 0;
                    if (EnterNames.allNames[TurnGamer] == "کامپیوتر")
                        EndPlayerTurn();
                    return;
                }
                else
                {
                    EndPlayerTurn();
                    return;
                }
            }
            else
            {
                pictureBoxTass.Enabled = false;
                if (TassNumber + GamerCells[TurnGamer] <= 100)
                    timer1.Enabled = true;
                else
                    EndPlayerTurn();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //move
            move();
            //check snakes and ladders
            if (stepsLeft == 0)
            {
                int cell = GamerCells[TurnGamer];
                switch (cell)
                {
                    //ladder
                    case 4: MoveToCell(14); break;
                    case 9: MoveToCell(31); break;
                    case 20: MoveToCell(38); break;
                    case 28: MoveToCell(84); break;
                    case 40: MoveToCell(59); break;
                    case 51: MoveToCell(67); break;
                    case 63: MoveToCell(81); break;
                    case 71: MoveToCell(91); break;
                    //snake
                    case 17: MoveToCell(7); break;
                    case 54: MoveToCell(34); break;
                    case 62: MoveToCell(19); break;
                    case 64: MoveToCell(60); break;
                    case 87: MoveToCell(24); break;
                    case 93: MoveToCell(73); break;
                    case 95: MoveToCell(75); break;
                    case 99: MoveToCell(78); break;
                }
                CheckWin();
                EndPlayerTurn();
            }
        }

        private void move()
        {
            PlaySound("sound/mohreSound.wav");

            //going up
            if (GamerCells[TurnGamer] % 10 == 0)
            {
                mohre[TurnGamer].Top -= 45;
                ltrList[TurnGamer] = !ltrList[TurnGamer];
            }
            //left and right
            else if (ltrList[TurnGamer])
                mohre[TurnGamer].Left += 45;
            else
                mohre[TurnGamer].Left -= 45;

            if (stepsLeft >= 0)
            {
                stepsLeft--;
                GamerCells[TurnGamer]++;
            }
            else
                return;
        }

        private void MoveToCell(int TargetCell)
        {
            Label lbl = this.Controls.Find("label" + TargetCell, true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                mohre[TurnGamer].Location = lbl.Location;
                GamerCells[TurnGamer] = TargetCell;
                //check ltr
                int newRow = (GamerCells[TurnGamer] - 1) / 10;
                ltrList[TurnGamer] = (newRow % 2 == 0);
            }
        }

       
        private void CheckWin()
        {
            if (stepsLeft == 0 && GamerCells[TurnGamer] == 100)
            {
                timer1.Enabled = false;
                PlaySound("sound/winSound.wav");
                MessageBox.Show(EnterNames.allNames[TurnGamer] + "  برنده شد", "برنده", MessageBoxButtons.OK);
                if (mohre.Count == 2)
                {
                    MessageBox.Show("یازی تموم شد", "پایان بازی", MessageBoxButtons.OK);
                    pictureBoxTass.Enabled = false;
                }
                else
                {
                    //delete winning piece
                    mohre[TurnGamer].Location = panelMohreh.Location;
                    mohre[TurnGamer].Visible = false;
                    mohre.RemoveAt(TurnGamer);
                    ltrList.RemoveAt(TurnGamer);
                    isOutside.RemoveAt(TurnGamer);
                    GamerCells.RemoveAt(TurnGamer);
                    EnterNames.allNames.RemoveAt(TurnGamer);
                    return;
                }
            }
            else return;
        }

        private void EndPlayerTurn()
        {
            timer1.Enabled = false;
            pictureBoxTass.Enabled = true;
            if (TassNumber != 6)
                TurnGamer++;
            if (TurnGamer >= mohre.Count)
                TurnGamer = 0;
            lblTurn.ForeColor = c[TurnGamer];
            lblTurn.Text = "نوبت: " + EnterNames.allNames[TurnGamer] + " است";
            if (EnterNames.allNames[TurnGamer] == "کامپیوتر" )
            {
                timerTass.Enabled = true;
            }
        }

        private void timerTass_Tick(object sender, EventArgs e)
        {
            timerTass.Enabled = false;
            CheckTass();
        }

        private void game_FormClosing(object sender, FormClosingEventArgs e)
        {
            NumberOfPlayer = 0;
            mohre.Clear();
            EnterNames.allNames.Clear();
            ltrList.Clear();
            isOutside.Clear();
            GamerCells.Clear();
        }

        
    }
}
