namespace PongGame
{
    partial class Pong
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pong));
            this.cpuPlayer = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.PictureBox();
            this.pongBall = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cpuScore = new System.Windows.Forms.Label();
            this.PlayerScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cpuPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pongBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cpuPlayer
            // 
            this.cpuPlayer.Location = new System.Drawing.Point(48, 239);
            this.cpuPlayer.Name = "cpuPlayer";
            this.cpuPlayer.Size = new System.Drawing.Size(22, 201);
            this.cpuPlayer.TabIndex = 2;
            this.cpuPlayer.TabStop = false;
            // 
            // Player
            // 
            this.Player.Location = new System.Drawing.Point(1190, 239);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(22, 201);
            this.Player.TabIndex = 3;
            this.Player.TabStop = false;
            // 
            // pongBall
            // 
            this.pongBall.Image = ((System.Drawing.Image)(resources.GetObject("pongBall.Image")));
            this.pongBall.Location = new System.Drawing.Point(615, 328);
            this.pongBall.Name = "pongBall";
            this.pongBall.Size = new System.Drawing.Size(28, 28);
            this.pongBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pongBall.TabIndex = 4;
            this.pongBall.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(468, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // cpuScore
            // 
            this.cpuScore.BackColor = System.Drawing.Color.Transparent;
            this.cpuScore.Font = new System.Drawing.Font("Cascadia Mono", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cpuScore.ForeColor = System.Drawing.SystemColors.Control;
            this.cpuScore.Location = new System.Drawing.Point(407, 41);
            this.cpuScore.Name = "cpuScore";
            this.cpuScore.Size = new System.Drawing.Size(55, 55);
            this.cpuScore.TabIndex = 6;
            this.cpuScore.Text = "0";
            this.cpuScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerScore
            // 
            this.PlayerScore.BackColor = System.Drawing.Color.Transparent;
            this.PlayerScore.Font = new System.Drawing.Font("Cascadia Mono", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerScore.ForeColor = System.Drawing.SystemColors.Control;
            this.PlayerScore.Location = new System.Drawing.Point(792, 41);
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.Size = new System.Drawing.Size(55, 55);
            this.PlayerScore.TabIndex = 7;
            this.PlayerScore.Text = "0";
            this.PlayerScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 844);
            this.Controls.Add(this.PlayerScore);
            this.Controls.Add(this.cpuScore);
            this.Controls.Add(this.pongBall);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.cpuPlayer);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pong";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.Pong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cpuPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pongBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox cpuPlayer;
        private PictureBox Player;
        private PictureBox pongBall;
        private PictureBox pictureBox1;
        private Label cpuScore;
        private Label PlayerScore;
    }
}