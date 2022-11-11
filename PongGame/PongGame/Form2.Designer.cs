namespace PongGame
{
    partial class CharacterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.chillFaceCharacter = new System.Windows.Forms.PictureBox();
            this.happyFaceCharacter = new System.Windows.Forms.PictureBox();
            this.sadFaceCharacter = new System.Windows.Forms.PictureBox();
            this.programmingCharacter = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chillFaceCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.happyFaceCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadFaceCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programmingCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Cascadia Mono", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.Location = new System.Drawing.Point(157, 28);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(903, 92);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Choose a Character";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chillFaceCharacter
            // 
            this.chillFaceCharacter.Image = ((System.Drawing.Image)(resources.GetObject("chillFaceCharacter.Image")));
            this.chillFaceCharacter.Location = new System.Drawing.Point(157, 204);
            this.chillFaceCharacter.Name = "chillFaceCharacter";
            this.chillFaceCharacter.Size = new System.Drawing.Size(160, 160);
            this.chillFaceCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chillFaceCharacter.TabIndex = 1;
            this.chillFaceCharacter.TabStop = false;
            this.chillFaceCharacter.Click += new System.EventHandler(this.chillFaceCharacter_Click);
            // 
            // happyFaceCharacter
            // 
            this.happyFaceCharacter.Image = ((System.Drawing.Image)(resources.GetObject("happyFaceCharacter.Image")));
            this.happyFaceCharacter.Location = new System.Drawing.Point(407, 204);
            this.happyFaceCharacter.Name = "happyFaceCharacter";
            this.happyFaceCharacter.Size = new System.Drawing.Size(160, 160);
            this.happyFaceCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.happyFaceCharacter.TabIndex = 2;
            this.happyFaceCharacter.TabStop = false;
            this.happyFaceCharacter.Click += new System.EventHandler(this.happyFaceCharacter_Click);
            // 
            // sadFaceCharacter
            // 
            this.sadFaceCharacter.Image = ((System.Drawing.Image)(resources.GetObject("sadFaceCharacter.Image")));
            this.sadFaceCharacter.Location = new System.Drawing.Point(662, 204);
            this.sadFaceCharacter.Name = "sadFaceCharacter";
            this.sadFaceCharacter.Size = new System.Drawing.Size(160, 160);
            this.sadFaceCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sadFaceCharacter.TabIndex = 3;
            this.sadFaceCharacter.TabStop = false;
            this.sadFaceCharacter.Click += new System.EventHandler(this.sadFaceCharacter_Click);
            // 
            // programmingCharacter
            // 
            this.programmingCharacter.Image = ((System.Drawing.Image)(resources.GetObject("programmingCharacter.Image")));
            this.programmingCharacter.Location = new System.Drawing.Point(900, 204);
            this.programmingCharacter.Name = "programmingCharacter";
            this.programmingCharacter.Size = new System.Drawing.Size(160, 160);
            this.programmingCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.programmingCharacter.TabIndex = 4;
            this.programmingCharacter.TabStop = false;
            this.programmingCharacter.Click += new System.EventHandler(this.programmingCharacter_Click);
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1264, 844);
            this.Controls.Add(this.programmingCharacter);
            this.Controls.Add(this.sadFaceCharacter);
            this.Controls.Add(this.happyFaceCharacter);
            this.Controls.Add(this.chillFaceCharacter);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CharacterForm";
            this.Text = "Choose Character";
            ((System.ComponentModel.ISupportInitialize)(this.chillFaceCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.happyFaceCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadFaceCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programmingCharacter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label TitleLabel;
        private PictureBox chillFaceCharacter;
        private PictureBox happyFaceCharacter;
        private PictureBox sadFaceCharacter;
        private PictureBox programmingCharacter;
    }
}