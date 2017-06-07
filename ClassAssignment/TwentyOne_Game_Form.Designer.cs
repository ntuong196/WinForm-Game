namespace ClassAssignment {
    partial class TwentyOne_Game_Form {
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
            this.dealerTable = new System.Windows.Forms.TableLayoutPanel();
            this.playerTable = new System.Windows.Forms.TableLayoutPanel();
            this.DealBtn = new System.Windows.Forms.Button();
            this.HitBtn = new System.Windows.Forms.Button();
            this.StandBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.BustedDealer = new System.Windows.Forms.Label();
            this.Dealer = new System.Windows.Forms.Label();
            this.PointsDealer = new System.Windows.Forms.Label();
            this.dealerGamesWonLabel = new System.Windows.Forms.Label();
            this.WonGamesDealer = new System.Windows.Forms.Label();
            this.BustedPlayer = new System.Windows.Forms.Label();
            this.Player = new System.Windows.Forms.Label();
            this.PointsPlayer = new System.Windows.Forms.Label();
            this.playerGamesWonLabel = new System.Windows.Forms.Label();
            this.WonGamePlayer = new System.Windows.Forms.Label();
            this.acesTextLabel = new System.Windows.Forms.Label();
            this.AceCountOne = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dealerTable
            // 
            this.dealerTable.ColumnCount = 8;
            this.dealerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTable.Location = new System.Drawing.Point(12, 89);
            this.dealerTable.Name = "dealerTable";
            this.dealerTable.RowCount = 1;
            this.dealerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dealerTable.Size = new System.Drawing.Size(580, 98);
            this.dealerTable.TabIndex = 0;
            // 
            // playerTable
            // 
            this.playerTable.ColumnCount = 8;
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTable.Location = new System.Drawing.Point(12, 218);
            this.playerTable.Name = "playerTable";
            this.playerTable.RowCount = 1;
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerTable.Size = new System.Drawing.Size(580, 103);
            this.playerTable.TabIndex = 1;
            // 
            // DealBtn
            // 
            this.DealBtn.Location = new System.Drawing.Point(37, 373);
            this.DealBtn.Name = "DealBtn";
            this.DealBtn.Size = new System.Drawing.Size(75, 23);
            this.DealBtn.TabIndex = 2;
            this.DealBtn.Text = "Deal";
            this.DealBtn.UseVisualStyleBackColor = true;
            this.DealBtn.Click += new System.EventHandler(this.DealButton_Click);
            // 
            // HitBtn
            // 
            this.HitBtn.Enabled = false;
            this.HitBtn.Location = new System.Drawing.Point(134, 373);
            this.HitBtn.Name = "HitBtn";
            this.HitBtn.Size = new System.Drawing.Size(75, 23);
            this.HitBtn.TabIndex = 3;
            this.HitBtn.Text = "Hit";
            this.HitBtn.UseVisualStyleBackColor = true;
            this.HitBtn.Click += new System.EventHandler(this.HitButton_Click);
            // 
            // StandBtn
            // 
            this.StandBtn.Enabled = false;
            this.StandBtn.Location = new System.Drawing.Point(230, 373);
            this.StandBtn.Name = "StandBtn";
            this.StandBtn.Size = new System.Drawing.Size(75, 23);
            this.StandBtn.TabIndex = 4;
            this.StandBtn.Text = "Stand";
            this.StandBtn.UseVisualStyleBackColor = true;
            this.StandBtn.Click += new System.EventHandler(this.StandButton_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(345, 373);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelGameButton_Click);
            // 
            // BustedDealer
            // 
            this.BustedDealer.AutoSize = true;
            this.BustedDealer.BackColor = System.Drawing.Color.Transparent;
            this.BustedDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BustedDealer.ForeColor = System.Drawing.Color.Red;
            this.BustedDealer.Location = new System.Drawing.Point(85, 30);
            this.BustedDealer.Name = "BustedDealer";
            this.BustedDealer.Size = new System.Drawing.Size(97, 25);
            this.BustedDealer.TabIndex = 7;
            this.BustedDealer.Text = "BUSTED";
            this.BustedDealer.Visible = false;
            // 
            // Dealer
            // 
            this.Dealer.AutoSize = true;
            this.Dealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dealer.Location = new System.Drawing.Point(188, 31);
            this.Dealer.Name = "Dealer";
            this.Dealer.Size = new System.Drawing.Size(71, 24);
            this.Dealer.TabIndex = 8;
            this.Dealer.Text = "Dealer";
            // 
            // PointsDealer
            // 
            this.PointsDealer.AutoSize = true;
            this.PointsDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsDealer.Location = new System.Drawing.Point(265, 31);
            this.PointsDealer.Name = "PointsDealer";
            this.PointsDealer.Size = new System.Drawing.Size(79, 24);
            this.PointsDealer.TabIndex = 9;
            this.PointsDealer.Text = "POINTS";
            this.PointsDealer.Visible = false;
            // 
            // dealerGamesWonLabel
            // 
            this.dealerGamesWonLabel.AutoSize = true;
            this.dealerGamesWonLabel.Location = new System.Drawing.Point(399, 39);
            this.dealerGamesWonLabel.Name = "dealerGamesWonLabel";
            this.dealerGamesWonLabel.Size = new System.Drawing.Size(63, 13);
            this.dealerGamesWonLabel.TabIndex = 10;
            this.dealerGamesWonLabel.Text = "Games won";
            // 
            // WonGamesDealer
            // 
            this.WonGamesDealer.AutoSize = true;
            this.WonGamesDealer.BackColor = System.Drawing.Color.White;
            this.WonGamesDealer.Location = new System.Drawing.Point(468, 39);
            this.WonGamesDealer.Name = "WonGamesDealer";
            this.WonGamesDealer.Size = new System.Drawing.Size(13, 13);
            this.WonGamesDealer.TabIndex = 11;
            this.WonGamesDealer.Text = "0";
            // 
            // BustedPlayer
            // 
            this.BustedPlayer.AutoSize = true;
            this.BustedPlayer.BackColor = System.Drawing.Color.Transparent;
            this.BustedPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BustedPlayer.ForeColor = System.Drawing.Color.Red;
            this.BustedPlayer.Location = new System.Drawing.Point(85, 324);
            this.BustedPlayer.Name = "BustedPlayer";
            this.BustedPlayer.Size = new System.Drawing.Size(97, 25);
            this.BustedPlayer.TabIndex = 12;
            this.BustedPlayer.Text = "BUSTED";
            this.BustedPlayer.Visible = false;
            // 
            // Player
            // 
            this.Player.AutoSize = true;
            this.Player.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player.Location = new System.Drawing.Point(191, 325);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(68, 24);
            this.Player.TabIndex = 13;
            this.Player.Text = "Player";
            // 
            // PointsPlayer
            // 
            this.PointsPlayer.AutoSize = true;
            this.PointsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsPlayer.Location = new System.Drawing.Point(265, 325);
            this.PointsPlayer.Name = "PointsPlayer";
            this.PointsPlayer.Size = new System.Drawing.Size(79, 24);
            this.PointsPlayer.TabIndex = 14;
            this.PointsPlayer.Text = "POINTS";
            this.PointsPlayer.Visible = false;
            // 
            // playerGamesWonLabel
            // 
            this.playerGamesWonLabel.AutoSize = true;
            this.playerGamesWonLabel.Location = new System.Drawing.Point(399, 333);
            this.playerGamesWonLabel.Name = "playerGamesWonLabel";
            this.playerGamesWonLabel.Size = new System.Drawing.Size(63, 13);
            this.playerGamesWonLabel.TabIndex = 15;
            this.playerGamesWonLabel.Text = "Games won";
            // 
            // WonGamePlayer
            // 
            this.WonGamePlayer.AutoSize = true;
            this.WonGamePlayer.BackColor = System.Drawing.Color.White;
            this.WonGamePlayer.Location = new System.Drawing.Point(468, 333);
            this.WonGamePlayer.Name = "WonGamePlayer";
            this.WonGamePlayer.Size = new System.Drawing.Size(13, 13);
            this.WonGamePlayer.TabIndex = 16;
            this.WonGamePlayer.Text = "0";
            // 
            // acesTextLabel
            // 
            this.acesTextLabel.AutoSize = true;
            this.acesTextLabel.Location = new System.Drawing.Point(214, 353);
            this.acesTextLabel.Name = "acesTextLabel";
            this.acesTextLabel.Size = new System.Drawing.Size(91, 13);
            this.acesTextLabel.TabIndex = 17;
            this.acesTextLabel.Text = "Aces with value 1";
            // 
            // AceCountOne
            // 
            this.AceCountOne.AutoSize = true;
            this.AceCountOne.BackColor = System.Drawing.Color.White;
            this.AceCountOne.Location = new System.Drawing.Point(196, 353);
            this.AceCountOne.Name = "AceCountOne";
            this.AceCountOne.Size = new System.Drawing.Size(13, 13);
            this.AceCountOne.TabIndex = 18;
            this.AceCountOne.Text = "0";
            // 
            // TwentyOne_Game_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 421);
            this.Controls.Add(this.AceCountOne);
            this.Controls.Add(this.acesTextLabel);
            this.Controls.Add(this.WonGamePlayer);
            this.Controls.Add(this.playerGamesWonLabel);
            this.Controls.Add(this.PointsPlayer);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.BustedPlayer);
            this.Controls.Add(this.WonGamesDealer);
            this.Controls.Add(this.dealerGamesWonLabel);
            this.Controls.Add(this.PointsDealer);
            this.Controls.Add(this.Dealer);
            this.Controls.Add(this.BustedDealer);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.StandBtn);
            this.Controls.Add(this.HitBtn);
            this.Controls.Add(this.DealBtn);
            this.Controls.Add(this.playerTable);
            this.Controls.Add(this.dealerTable);
            this.Name = "TwentyOne_Game_Form";
            this.Text = "Twenty One Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dealerTable;
        private System.Windows.Forms.TableLayoutPanel playerTable;
        private System.Windows.Forms.Button DealBtn;
        private System.Windows.Forms.Button HitBtn;
        private System.Windows.Forms.Button StandBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label BustedDealer;
        private System.Windows.Forms.Label Dealer;
        private System.Windows.Forms.Label PointsDealer;
        private System.Windows.Forms.Label dealerGamesWonLabel;
        private System.Windows.Forms.Label WonGamesDealer;
        private System.Windows.Forms.Label BustedPlayer;
        private System.Windows.Forms.Label Player;
        private System.Windows.Forms.Label PointsPlayer;
        private System.Windows.Forms.Label playerGamesWonLabel;
        private System.Windows.Forms.Label WonGamePlayer;
        private System.Windows.Forms.Label acesTextLabel;
        private System.Windows.Forms.Label AceCountOne;
    }
}