namespace mar_peleh
{
    partial class EnterNames
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
            this.btnAddName = new Glass.GlassButton();
            this.btnStartGame = new Glass.GlassButton();
            this.txtGamerName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddName
            // 
            this.btnAddName.BackColor = System.Drawing.Color.CadetBlue;
            this.btnAddName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddName.GlowColor = System.Drawing.Color.DarkCyan;
            this.btnAddName.InnerBorderColor = System.Drawing.Color.White;
            this.btnAddName.Location = new System.Drawing.Point(24, 77);
            this.btnAddName.Name = "btnAddName";
            this.btnAddName.Size = new System.Drawing.Size(98, 53);
            this.btnAddName.TabIndex = 2;
            this.btnAddName.Text = "اضافه کردن نام";
            this.btnAddName.Click += new System.EventHandler(this.btnAddName_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.CadetBlue;
            this.btnStartGame.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnStartGame.GlowColor = System.Drawing.Color.DarkCyan;
            this.btnStartGame.InnerBorderColor = System.Drawing.Color.White;
            this.btnStartGame.Location = new System.Drawing.Point(24, 136);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(98, 53);
            this.btnStartGame.TabIndex = 2;
            this.btnStartGame.Text = "شروع بازی";
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // txtGamerName
            // 
            this.txtGamerName.BackColor = System.Drawing.Color.Azure;
            this.txtGamerName.ForeColor = System.Drawing.Color.Black;
            this.txtGamerName.Location = new System.Drawing.Point(151, 35);
            this.txtGamerName.Multiline = true;
            this.txtGamerName.Name = "txtGamerName";
            this.txtGamerName.Size = new System.Drawing.Size(100, 33);
            this.txtGamerName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(259, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(19, 17);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "نام";
            // 
            // EnterNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 307);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtGamerName);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.btnAddName);
            this.Name = "EnterNames";
            this.Text = "EnterNames";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnterNames_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Glass.GlassButton btnStartGame;
        private System.Windows.Forms.TextBox txtGamerName;
        public System.Windows.Forms.Label lblName;
        public Glass.GlassButton btnAddName;

    }
}