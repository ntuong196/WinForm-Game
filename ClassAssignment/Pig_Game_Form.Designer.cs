namespace ClassAssignment {
    partial class Pig_Game_Form {
        /// <summary>
        /// Designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// A check point to clean any resources if its being used.
        /// </summary>
        /// <param name="disposing">true if the resources are disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Initialize all GUI component
        /// </summary>
        private void InitializeComponent() {
            this.diePictureBox = new System.Windows.Forms.PictureBox();
            this.RollBtn = new System.Windows.Forms.Button();
            this.HoldBtn = new System.Windows.Forms.Button();
            this.TotalPointsPlayer1 = new System.Windows.Forms.TextBox();
            this.TotalPointsPlayer2 = new System.Windows.Forms.TextBox();
            this.GameTerminal = new System.Windows.Forms.GroupBox();
            this.noButton = new System.Windows.Forms.RadioButton();
            this.yesButton = new System.Windows.Forms.RadioButton();
            this.textLine1 = new System.Windows.Forms.Label();
            this.player1TotalLabel = new System.Windows.Forms.Label();
            this.player2TotalLabel = new System.Windows.Forms.Label();
            this.textLine2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.diePictureBox)).BeginInit();
            this.GameTerminal.SuspendLayout();
            this.SuspendLayout();
            // 
            // diePictureBox
            // 
            this.diePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diePictureBox.Location = new System.Drawing.Point(114, 60);
            this.diePictureBox.Name = "diePictureBox";
            this.diePictureBox.Size = new System.Drawing.Size(55, 55);
            this.diePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.diePictureBox.TabIndex = 0;
            this.diePictureBox.TabStop = false;
            // 
            // RollBtn
            // 
            this.RollBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RollBtn.Location = new System.Drawing.Point(34, 165);
            this.RollBtn.Name = "RollBtn";
            this.RollBtn.Size = new System.Drawing.Size(87, 23);
            this.RollBtn.TabIndex = 1;
            this.RollBtn.TabStop = false;
            this.RollBtn.Text = "Roll";
            this.RollBtn.UseVisualStyleBackColor = false;
            this.RollBtn.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // HoldBtn
            // 
            this.HoldBtn.BackColor = System.Drawing.Color.Red;
            this.HoldBtn.Enabled = false;
            this.HoldBtn.Location = new System.Drawing.Point(143, 165);
            this.HoldBtn.Name = "HoldBtn";
            this.HoldBtn.Size = new System.Drawing.Size(87, 23);
            this.HoldBtn.TabIndex = 2;
            this.HoldBtn.TabStop = false;
            this.HoldBtn.Text = "Hold";
            this.HoldBtn.UseVisualStyleBackColor = false;
            this.HoldBtn.Click += new System.EventHandler(this.HoldButton_Click);
            // 
            // TotalPointsPlayer1
            // 
            this.TotalPointsPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsPlayer1.Location = new System.Drawing.Point(341, 57);
            this.TotalPointsPlayer1.Name = "TotalPointsPlayer1";
            this.TotalPointsPlayer1.ReadOnly = true;
            this.TotalPointsPlayer1.Size = new System.Drawing.Size(68, 20);
            this.TotalPointsPlayer1.TabIndex = 3;
            this.TotalPointsPlayer1.TabStop = false;
            this.TotalPointsPlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TotalPointsPlayer2
            // 
            this.TotalPointsPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsPlayer2.Location = new System.Drawing.Point(341, 95);
            this.TotalPointsPlayer2.Name = "TotalPointsPlayer2";
            this.TotalPointsPlayer2.ReadOnly = true;
            this.TotalPointsPlayer2.Size = new System.Drawing.Size(68, 20);
            this.TotalPointsPlayer2.TabIndex = 4;
            this.TotalPointsPlayer2.TabStop = false;
            this.TotalPointsPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GameTerminal
            // 
            this.GameTerminal.Controls.Add(this.noButton);
            this.GameTerminal.Controls.Add(this.yesButton);
            this.GameTerminal.Enabled = false;
            this.GameTerminal.Location = new System.Drawing.Point(267, 152);
            this.GameTerminal.Name = "GameTerminal";
            this.GameTerminal.Size = new System.Drawing.Size(142, 70);
            this.GameTerminal.TabIndex = 5;
            this.GameTerminal.TabStop = false;
            this.GameTerminal.Text = "Another Game?";
            // 
            // noButton
            // 
            this.noButton.AutoSize = true;
            this.noButton.Location = new System.Drawing.Point(8, 42);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(41, 17);
            this.noButton.TabIndex = 1;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.CheckedChanged += new System.EventHandler(this.NoRadio_CheckedChanged);
            // 
            // yesButton
            // 
            this.yesButton.AutoSize = true;
            this.yesButton.Location = new System.Drawing.Point(8, 19);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(46, 17);
            this.yesButton.TabIndex = 0;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.CheckedChanged += new System.EventHandler(this.YesRadio_CheckedChanged);
            // 
            // textLine1
            // 
            this.textLine1.AutoSize = true;
            this.textLine1.Location = new System.Drawing.Point(12, 73);
            this.textLine1.Name = "textLine1";
            this.textLine1.Size = new System.Drawing.Size(87, 13);
            this.textLine1.TabIndex = 6;
            this.textLine1.Text = "Whose turn to";
            // 
            // player1TotalLabel
            // 
            this.player1TotalLabel.AutoSize = true;
            this.player1TotalLabel.Location = new System.Drawing.Point(249, 60);
            this.player1TotalLabel.Name = "player1TotalLabel";
            this.player1TotalLabel.Size = new System.Drawing.Size(86, 13);
            this.player1TotalLabel.TabIndex = 7;
            this.player1TotalLabel.Text = "Player 1 Total";
            // 
            // player2TotalLabel
            // 
            this.player2TotalLabel.AutoSize = true;
            this.player2TotalLabel.Location = new System.Drawing.Point(249, 98);
            this.player2TotalLabel.Name = "player2TotalLabel";
            this.player2TotalLabel.Size = new System.Drawing.Size(86, 13);
            this.player2TotalLabel.TabIndex = 8;
            this.player2TotalLabel.Text = "Player 2 Total";
            // 
            // textLine2
            // 
            this.textLine2.AutoSize = true;
            this.textLine2.Location = new System.Drawing.Point(14, 93);
            this.textLine2.Name = "textLine2";
            this.textLine2.Size = new System.Drawing.Size(67, 13);
            this.textLine2.TabIndex = 9;
            this.textLine2.Text = "roll or hold";
            // 
            // Pig_Game_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 244);
            this.Controls.Add(this.textLine2);
            this.Controls.Add(this.player2TotalLabel);
            this.Controls.Add(this.player1TotalLabel);
            this.Controls.Add(this.textLine1);
            this.Controls.Add(this.GameTerminal);
            this.Controls.Add(this.TotalPointsPlayer2);
            this.Controls.Add(this.TotalPointsPlayer1);
            this.Controls.Add(this.HoldBtn);
            this.Controls.Add(this.RollBtn);
            this.Controls.Add(this.diePictureBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Pig_Game_Form";
            this.Text = "Pig Game";
            ((System.ComponentModel.ISupportInitialize)(this.diePictureBox)).EndInit();
            this.GameTerminal.ResumeLayout(false);
            this.GameTerminal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox diePictureBox;
        private System.Windows.Forms.Button RollBtn;
        private System.Windows.Forms.Button HoldBtn;
        private System.Windows.Forms.TextBox TotalPointsPlayer1;
        private System.Windows.Forms.TextBox TotalPointsPlayer2;
        private System.Windows.Forms.GroupBox GameTerminal;
        private System.Windows.Forms.RadioButton noButton;
        private System.Windows.Forms.RadioButton yesButton;
        private System.Windows.Forms.Label textLine1;
        private System.Windows.Forms.Label player1TotalLabel;
        private System.Windows.Forms.Label player2TotalLabel;
        private System.Windows.Forms.Label textLine2;
    }
}