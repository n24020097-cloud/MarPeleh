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
        Random Rnd = new Random();
        List<PictureBox> Mohre = new List<PictureBox>();
        List<bool> IsOutSide = new List<bool>();
        List<int> GamerCells=new List<int>();
        List<bool> LtrList = new List<bool>(); 
        int TassNumber;
        int TurnGamer=0;
        int StepsLeft = 0;
        int NumberOfPlayer = EnterNames.AllNames.Count;
        Color[] c = { Color.Red, Color.Green, Color.Yellow,Color.Blue};
        public game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            if (NumberOfPlayer == 1)
            {
                NumberOfPlayer = 2;
                EnterNames.AllNames.Add("کامپیوتر");
            }
            //add mohre in list
            if (NumberOfPlayer >= 1) Mohre.Add(pcbGamer1);
            if (NumberOfPlayer >= 2) Mohre.Add(pcbGamer2);
            if (NumberOfPlayer >= 3) Mohre.Add(pcbGamer3);
            if (NumberOfPlayer >= 4) Mohre.Add(pcbGamer4);


            // set location and direction
            for (int i = 0; i < Mohre.Count; i++)
            {
                IsOutSide.Add(true);
                GamerCells.Add(1);
                LtrList.Add(true);
            }
            lblTurn.ForeColor = c[TurnGamer];
            lblTurn.Text = "نوبت: " + EnterNames.AllNames[TurnGamer] + " است"; 
        }

        public void PlaySound(string soundFile)
        {
            SoundPlayer player = new SoundPlayer(soundFile);
            player.Play();
        }

        private void PictureBoxTass_Click(object sender, EventArgs e)
        {
            CheckTass();
        }

        private void CheckTass()
        {
            PlaySound("sound/tassSound.wav");
            TassNumber = Rnd.Next(1, 7);
            pictureBoxTass.ImageLocation = "img/i" + TassNumber + ".PNG";
            StepsLeft = TassNumber;
            if (IsOutSide[TurnGamer])
            {
                if (TassNumber == 6)
                {
                    Mohre[TurnGamer].Parent = pictureBoxGame;
                    Mohre[TurnGamer].Location = new Point(
                    lblCell1.Location.X - pictureBoxGame.Location.X + (lblCell1.Width / 2) - (Mohre[TurnGamer].Width / 2),
                    lblCell1.Location.Y - pictureBoxGame.Location.Y + (lblCell1.Height / 2) - (Mohre[TurnGamer].Height / 2));
                    IsOutSide[TurnGamer] = false;
                    StepsLeft = 0;
                    if (EnterNames.AllNames[TurnGamer] == "کامپیوتر")
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            //move
            Move();
            //check snakes and ladders
            if (StepsLeft == 0)
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

        private void Move()
        {
            PlaySound("sound/mohreSound.wav");

            //going up
            if (GamerCells[TurnGamer] % 10 == 0)
            {
                Mohre[TurnGamer].Top -= 45;
                LtrList[TurnGamer] = !LtrList[TurnGamer];
            }
            //left and right
            else if (LtrList[TurnGamer])
                Mohre[TurnGamer].Left += 45;
            else
                Mohre[TurnGamer].Left -= 45;

            if (StepsLeft >= 0)
            {
                StepsLeft--;
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
                Mohre[TurnGamer].Location = lbl.Location;
                GamerCells[TurnGamer] = TargetCell;
                //check ltr
                int newRow = (GamerCells[TurnGamer] - 1) / 10;
                LtrList[TurnGamer] = (newRow % 2 == 0);
            }
        }

       
        private void CheckWin()
        {
            if (StepsLeft == 0 && GamerCells[TurnGamer] == 100)
            {
                timer1.Enabled = false;
                PlaySound("sound/winSound.wav");
                MessageBox.Show(EnterNames.AllNames[TurnGamer] + "  برنده شد", "برنده", MessageBoxButtons.OK);
                if (Mohre.Count == 2)
                {
                    MessageBox.Show("یازی تموم شد", "پایان بازی", MessageBoxButtons.OK);
                    pictureBoxTass.Enabled = false;
                }
                else
                {
                    //delete winning piece
                    Mohre[TurnGamer].Location = panelMohreh.Location;
                    Mohre[TurnGamer].Visible = false;
                    Mohre.RemoveAt(TurnGamer);
                    LtrList.RemoveAt(TurnGamer);
                    IsOutSide.RemoveAt(TurnGamer);
                    GamerCells.RemoveAt(TurnGamer);
                    EnterNames.AllNames.RemoveAt(TurnGamer);
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
            if (TurnGamer >= Mohre.Count)
                TurnGamer = 0;
            lblTurn.ForeColor = c[TurnGamer];
            lblTurn.Text = "نوبت: " + EnterNames.AllNames[TurnGamer] + " است";
            if (EnterNames.AllNames[TurnGamer] == "کامپیوتر" )
            {
                timerTass.Enabled = true;
            }
        }

        private void TimerTass_Tick(object sender, EventArgs e)
        {
            timerTass.Enabled = false;
            CheckTass();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            NumberOfPlayer = 0;
            Mohre.Clear();
            EnterNames.AllNames.Clear();
            LtrList.Clear();
            IsOutSide.Clear();
            GamerCells.Clear();
        }

        
    }
}
