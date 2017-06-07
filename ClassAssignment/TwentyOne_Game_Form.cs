using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Low_Level_Objects_Library;
using Games_Logic_Library;

namespace ClassAssignment {
    /// <summary>
    /// Displays the form and makes use of the logic implemented from the TwentyOne Game class
    /// </summary>
    public partial class TwentyOne_Game_Form : Form {
        public TwentyOne_Game_Form() {
            InitializeComponent();
            TwentyOne_Game.SetUpGame();
        }
        

        /// <summary>
        /// Docks the table layouts with images of the cards respective to each hand
        /// </summary>
        /// <param name="hand">Hand: the hand for the table</param>
        /// <param name="tableLayoutPanel">TalbeLayoutPanel: the table to dock the images on</param>
        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel) {
            tableLayoutPanel.Controls.Clear(); // Remove any cards already being shown.
            foreach (Card card in hand) {
                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Set the PictureBox to use all of its space
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);
                pictureBox.Image = Images.GetCardImage(card);
                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// End DisplayGuiHand


        /// <summary>
        /// Updates the GUI labels and displays the hands onto the tables
        /// </summary>
        private void UpdateGUI() {
            // Update games won count labels
            WonGamePlayer.Text = TwentyOne_Game.GetNumOfGamesWon(0).ToString();
            WonGamesDealer.Text = TwentyOne_Game.GetNumOfGamesWon(1).ToString();

            // Display hands onto GUI
            DisplayGuiHand(TwentyOne_Game.GetHand(0), playerTable);
            DisplayGuiHand(TwentyOne_Game.GetHand(1), dealerTable);

            // Update dealer and player points label
            PointsPlayer.Text = TwentyOne_Game.GetTotalPoints(0).ToString();
            PointsDealer.Text = TwentyOne_Game.GetTotalPoints(1).ToString();

            // Update ace count label
            AceCountOne.Text = TwentyOne_Game.GetNumOfUserAcesWithValueOne().ToString();
        }// End UpdateGUI


        private void DealButton_Click(object sender, EventArgs e) {
            // Set up a new game
            TwentyOne_Game.SetUpGame();
            
            // Deal cards and then display them
            for (int i = 0; i < 2; i++) {
                TwentyOne_Game.DealOneCardTo(0);    // Deal two cards to player
                TwentyOne_Game.DealOneCardTo(1);    // Deal two cards to dealer
            }
            DisplayGuiHand(TwentyOne_Game.GetHand(0), playerTable);
            DisplayGuiHand(TwentyOne_Game.GetHand(1), dealerTable);

            // Update labels
            AceCountOne.Text = TwentyOne_Game.GetNumOfUserAcesWithValueOne().ToString();
            BustedDealer.Visible = false;
            BustedPlayer.Visible = false;
            PointsPlayer.Text = TwentyOne_Game.CalculateHandTotal(0).ToString();
            PointsPlayer.Visible = true;
            PointsDealer.Text = TwentyOne_Game.CalculateHandTotal(1).ToString();
            PointsDealer.Visible = true;

            // Enable and disable buttons
            StandBtn.Enabled = true;
            HitBtn.Enabled = true; 
            DealBtn.Enabled = false;
        }


        private void HitButton_Click(object sender, EventArgs e) {
            // Deal card 
            Card c = TwentyOne_Game.DealOneCardTo(0);

            // If ace is dealt
            if (c.GetFaceValue() == FaceValue.Ace) {
                DialogResult result = MessageBox.Show("Count Ace as one?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    TwentyOne_Game.IncrementNumOfUserAcesWithValueOne();
                }
            }

            // If player has busted
            if (TwentyOne_Game.CalculateHandTotal(0) > 21) {
                // Update button enabled values
                DealBtn.Enabled = true;
                HitBtn.Enabled = false;
                StandBtn.Enabled = false;

                // Show busted label
                BustedPlayer.Visible = true;
            }

            // Update the GUI
            UpdateGUI();
        }


        private void StandButton_Click(object sender, EventArgs e) {
            // Play a round for the dealer
            TwentyOne_Game.PlayForDealer();

            // Update button enabled values
            StandBtn.Enabled = false;
            HitBtn.Enabled = false;

            // If the dealer has busted
            if (TwentyOne_Game.GetTotalPoints(1) > 21) {
                BustedDealer.Visible = true;
            }

            // Enable the player to deal again
            DealBtn.Enabled = true;

            // Update the GUI
            UpdateGUI();
        }

        private void CancelGameButton_Click(object sender, EventArgs e) {
            if (TwentyOne_Game.GetNumOfGamesWon(0) > TwentyOne_Game.GetNumOfGamesWon(1)) {              // If player wins
                MessageBox.Show("You won! Well done.");                                             // Show message
                TwentyOne_Game.ResetTotals();                                                       // Reset points and games
                this.Hide();                                                                        // Close window
                First_GUI_Form GameForm = new First_GUI_Form();                                         // Open initial window
                GameForm.Closed += (s, args) => this.Close();                                       // Dispose this form together when the other is closed
                GameForm.Show();                                                                    // Show the initial menu
            } else if (TwentyOne_Game.GetNumOfGamesWon(0) < TwentyOne_Game.GetNumOfGamesWon(1)) {       // If dealer wins
                MessageBox.Show("House won! Better luck next time.");                               // " "
                TwentyOne_Game.ResetTotals();
                this.Hide();
                First_GUI_Form GameForm = new First_GUI_Form();
                GameForm.Closed += (s, args) => this.Close();
                GameForm.Show();
            } else {                                                                                // If it was a draw
                MessageBox.Show("It was a draw!");
                TwentyOne_Game.ResetTotals();
                this.Hide();
                First_GUI_Form GameForm = new First_GUI_Form();
                GameForm.Closed += (s, args) => this.Close();
                GameForm.Show();
            }
        }
    }
}
