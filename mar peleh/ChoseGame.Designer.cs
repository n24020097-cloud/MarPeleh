namespace mar_peleh
{
    partial class ChoseGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnComputerGame = new Glass.GlassButton();
            this.btnHumanGame = new Glass.GlassButton();
            this.btnExit = new Glass.GlassButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnComputerGame
            // 
            this.btnComputerGame.BackColor = System.Drawing.Color.CadetBlue;
            this.btnComputerGame.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnComputerGame.GlowColor = System.Drawing.Color.DarkCyan;
            this.btnComputerGame.InnerBorderColor = System.Drawing.Color.White;
            this.btnComputerGame.Location = new System.Drawing.Point(62, 85);
            this.btnComputerGame.Name = "btnComputerGame";
            this.btnComputerGame.Size = new System.Drawing.Size(98, 53);
            this.btnComputerGame.TabIndex = 1;
            this.btnComputerGame.Text = "بازی با کامپیوتر";
            this.btnComputerGame.Click += new System.EventHandler(this.btnComputerGame_Click);
            // 
            // btnHumanGame
            // 
            this.btnHumanGame.BackColor = System.Drawing.Color.CadetBlue;
            this.btnHumanGame.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnHumanGame.GlowColor = System.Drawing.Color.DarkCyan;
            this.btnHumanGame.InnerBorderColor = System.Drawing.Color.White;
            this.btnHumanGame.Location = new System.Drawing.Point(62, 154);
            this.btnHumanGame.Name = "btnHumanGame";
            this.btnHumanGame.Size = new System.Drawing.Size(98, 53);
            this.btnHumanGame.TabIndex = 1;
            this.btnHumanGame.Text = "بازی با انسان";
            this.btnHumanGame.Click += new System.EventHandler(this.btnHumanGame_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.CadetBlue;
            this.btnExit.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnExit.GlowColor = System.Drawing.Color.DarkCyan;
            this.btnExit.InnerBorderColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(62, 222);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 53);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "خروج";
            this.btnExit.Click += new System.EventHandler(this.glassButton3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "بازی مارپله";
            // 
            // ChoseGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 303);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHumanGame);
            this.Controls.Add(this.btnComputerGame);
            this.Name = "ChoseGame";
            this.Text = "Chose Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoseGame_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Glass.GlassButton btnComputerGame;
        private Glass.GlassButton btnHumanGame;
        private Glass.GlassButton btnExit;
        private System.Windows.Forms.Label label1;

    }
}

