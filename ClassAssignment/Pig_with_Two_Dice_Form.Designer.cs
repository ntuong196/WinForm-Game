namespace ClassAssignment {
    partial class Pig_with_Two_Dice_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.textLine2 = new System.Windows.Forms.Label();
            this.player2TotalLabel = new System.Windows.Forms.Label();
            this.player1TotalLabel = new System.Windows.Forms.Label();
            this.textLine1 = new System.Windows.Forms.Label();
            this.GameTerminal = new System.Windows.Forms.GroupBox();
            this.NoButton = new System.Windows.Forms.RadioButton();
            this.YesButton = new System.Windows.Forms.RadioButton();
            this.TotalPointPlayer2 = new System.Windows.Forms.TextBox();
            this.TotalPointsPlayer1 = new System.Windows.Forms.TextBox();
            this.HoldBtn = new System.Windows.Forms.Button();
            this.RollBtn = new System.Windows.Forms.Button();
            this.diePictureBox1 = new System.Windows.Forms.PictureBox();
            this.diePictureBox2 = new System.Windows.Forms.PictureBox();
            this.rollTimer = new System.Windows.Forms.Timer(this.components);
            this.GameTerminal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diePictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textLine2
            // 
            this.textLine2.AutoSize = true;
            this.textLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLine2.Location = new System.Drawing.Point(6, 77);
            this.textLine2.Name = "textLine2";
            this.textLine2.Size = new System.Drawing.Size(67, 13);
            this.textLine2.TabIndex = 19;
            this.textLine2.Text = "roll or hold";
            // 
            // player2TotalLabel
            // 
            this.player2TotalLabel.AutoSize = true;
            this.player2TotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2TotalLabel.Location = new System.Drawing.Point(255, 80);
            this.player2TotalLabel.Name = "player2TotalLabel";
            this.player2TotalLabel.Size = new System.Drawing.Size(86, 13);
            this.player2TotalLabel.TabIndex = 18;
            this.player2TotalLabel.Text = "Player 2 Total";
            // 
            // player1TotalLabel
            // 
            this.player1TotalLabel.AutoSize = true;
            this.player1TotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1TotalLabel.Location = new System.Drawing.Point(255, 42);
            this.player1TotalLabel.Name = "player1TotalLabel";
            this.player1TotalLabel.Size = new System.Drawing.Size(86, 13);
            this.player1TotalLabel.TabIndex = 17;
            this.player1TotalLabel.Text = "Player 1 Total";
            // 
            // textLine1
            // 
            this.textLine1.AutoSize = true;
            this.textLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLine1.Location = new System.Drawing.Point(5, 55);
            this.textLine1.Name = "textLine1";
            this.textLine1.Size = new System.Drawing.Size(87, 13);
            this.textLine1.TabIndex = 16;
            this.textLine1.Text = "Whose turn to";
            // 
            // GameTerminal
            // 
            this.GameTerminal.Controls.Add(this.NoButton);
            this.GameTerminal.Controls.Add(this.YesButton);
            this.GameTerminal.Enabled = false;
            this.GameTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTerminal.Location = new System.Drawing.Point(273, 134);
            this.GameTerminal.Name = "GameTerminal";
            this.GameTerminal.Size = new System.Drawing.Size(142, 70);
            this.GameTerminal.TabIndex = 15;
            this.GameTerminal.TabStop = false;
            this.GameTerminal.Text = "Another Game?";
            // 
            // NoButton
            // 
            this.NoButton.AutoSize = true;
            this.NoButton.Location = new System.Drawing.Point(8, 42);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(41, 17);
            this.NoButton.TabIndex = 1;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.CheckedChanged += new System.EventHandler(this.NoRadio_CheckedChanged);
            // 
            // YesButton
            // 
            this.YesButton.AutoSize = true;
            this.YesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesButton.Location = new System.Drawing.Point(8, 19);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(46, 17);
            this.YesButton.TabIndex = 0;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.CheckedChanged += new System.EventHandler(this.YesRadio_CheckedChanged);
            // 
            // TotalPointPlayer2
            // 
            this.TotalPointPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointPlayer2.Location = new System.Drawing.Point(347, 77);
            this.TotalPointPlayer2.Name = "TotalPointPlayer2";
            this.TotalPointPlayer2.ReadOnly = true;
            this.TotalPointPlayer2.Size = new System.Drawing.Size(68, 20);
            this.TotalPointPlayer2.TabIndex = 14;
            this.TotalPointPlayer2.TabStop = false;
            this.TotalPointPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TotalPointsPlayer1
            // 
            this.TotalPointsPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsPlayer1.Location = new System.Drawing.Point(347, 39);
            this.TotalPointsPlayer1.Name = "TotalPointsPlayer1";
            this.TotalPointsPlayer1.ReadOnly = true;
            this.TotalPointsPlayer1.Size = new System.Drawing.Size(68, 20);
            this.TotalPointsPlayer1.TabIndex = 13;
            this.TotalPointsPlayer1.TabStop = false;
            this.TotalPointsPlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // HoldBtn
            // 
            this.HoldBtn.BackColor = System.Drawing.Color.Red;
            this.HoldBtn.Enabled = false;
            this.HoldBtn.Location = new System.Drawing.Point(149, 147);
            this.HoldBtn.Name = "HoldBtn";
            this.HoldBtn.Size = new System.Drawing.Size(87, 23);
            this.HoldBtn.TabIndex = 12;
            this.HoldBtn.TabStop = false;
            this.HoldBtn.Text = "Hold";
            this.HoldBtn.UseVisualStyleBackColor = false;
            this.HoldBtn.Click += new System.EventHandler(this.HoldButton_Click);
            // 
            // RollBtn
            // 
            this.RollBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RollBtn.Location = new System.Drawing.Point(40, 147);
            this.RollBtn.Name = "RollBtn";
            this.RollBtn.Size = new System.Drawing.Size(87, 23);
            this.RollBtn.TabIndex = 11;
            this.RollBtn.TabStop = false;
            this.RollBtn.Text = "Roll";
            this.RollBtn.UseVisualStyleBackColor = false;
            this.RollBtn.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // diePictureBox1
            // 
            this.diePictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diePictureBox1.Location = new System.Drawing.Point(98, 42);
            this.diePictureBox1.Name = "diePictureBox1";
            this.diePictureBox1.Size = new System.Drawing.Size(55, 55);
            this.diePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.diePictureBox1.TabIndex = 10;
            this.diePictureBox1.TabStop = false;
            // 
            // diePictureBox2
            // 
            this.diePictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diePictureBox2.Location = new System.Drawing.Point(170, 42);
            this.diePictureBox2.Name = "diePictureBox2";
            this.diePictureBox2.Size = new System.Drawing.Size(55, 55);
            this.diePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.diePictureBox2.TabIndex = 20;
            this.diePictureBox2.TabStop = false;
            // 
            // rollTimer
            // 
            this.rollTimer.Interval = 75;
            this.rollTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Pig_with_Two_Dice_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 243);
            this.Controls.Add(this.diePictureBox2);
            this.Controls.Add(this.textLine2);
            this.Controls.Add(this.player2TotalLabel);
            this.Controls.Add(this.player1TotalLabel);
            this.Controls.Add(this.textLine1);
            this.Controls.Add(this.GameTerminal);
            this.Controls.Add(this.TotalPointPlayer2);
            this.Controls.Add(this.TotalPointsPlayer1);
            this.Controls.Add(this.HoldBtn);
            this.Controls.Add(this.RollBtn);
            this.Controls.Add(this.diePictureBox1);
            this.Name = "Pig_with_Two_Dice_Form";
            this.Text = "Two Dice Pig Game";
            this.GameTerminal.ResumeLayout(false);
            this.GameTerminal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diePictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textLine2;
        private System.Windows.Forms.Label player2TotalLabel;
        private System.Windows.Forms.Label player1TotalLabel;
        private System.Windows.Forms.Label textLine1;
        private System.Windows.Forms.GroupBox GameTerminal;
        private System.Windows.Forms.RadioButton NoButton;
        private System.Windows.Forms.RadioButton YesButton;
        private System.Windows.Forms.TextBox TotalPointPlayer2;
        private System.Windows.Forms.TextBox TotalPointsPlayer1;
        private System.Windows.Forms.Button HoldBtn;
        private System.Windows.Forms.Button RollBtn;
        private System.Windows.Forms.PictureBox diePictureBox1;
        private System.Windows.Forms.PictureBox diePictureBox2;
        private System.Windows.Forms.Timer rollTimer;
    }
}