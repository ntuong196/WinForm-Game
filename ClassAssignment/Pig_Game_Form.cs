using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Games_Logic_Library;

namespace ClassAssignment {
    /// <summary>
    /// GUI form control for the single Pig Game
    /// Using the logical implement in the Pig Single Die Game class
    /// </summary>
    public partial class Pig_Game_Form : Form {

        public Pig_Game_Form() {
            InitializeComponent();
            Pig_Single_Die_Game.SetUpGame();
            FormUpdate();
        }

        /// <summary>
        /// "Help" function to update the form with the game value
        /// </summary>
        void FormUpdate() {
            diePictureBox.Image = Images.GetDieImage(Pig_Single_Die_Game.GetFaceValue());           // Set the image to the die value
            TotalPointsPlayer1.Text = Pig_Single_Die_Game.GetPointsTotal("Player 1").ToString();   // Set the Player 1 points label to player 1's points
            TotalPointsPlayer2.Text = Pig_Single_Die_Game.GetPointsTotal("Player 2").ToString();   // Set the Player 2 points label to player 2's points

            textLine1.Text = Pig_Single_Die_Game.GetThisPlayer();                                // Set the information text's first line to the player name
            textLine2.Text = (HoldBtn.Enabled) ? "Roll or Hold" : "Roll Die";                    // Set the information text's second line to the player's available action
        }
        private void HoldButton_Click(object sender, EventArgs e)
        {
            Pig_Single_Die_Game.SetThisPlayer(Pig_Single_Die_Game.GetNextPlayer());     // Move to next player
            HoldBtn.Enabled = false;
            FormUpdate();
        }


        private void RollButton_Click(object sender, EventArgs e) {
            HoldBtn.Enabled = true; // Enabled the hold button once a die has been thrown
            if (Pig_Single_Die_Game.PlayGame()) { // If a 1 has been thrown
                HoldBtn.Enabled = false;       // Disable the hold button
                FormUpdate();
                MessageBox.Show("Sorry you have thrown a 1.\nYour turn is over!\nYour score reverts to " + Pig_Single_Die_Game.GetPointsTotal(Pig_Single_Die_Game.GetNextPlayer()));
            } else {
                FormUpdate();
                if (Pig_Single_Die_Game.CheckWin()) { // If a player has won the game
                    MessageBox.Show(Pig_Single_Die_Game.GetThisPlayer() + " has won!\nWell done.");
                    // Disable gameplay buttons until the user makes a choice whether to play again
                    RollBtn.Enabled = false;     
                    HoldBtn.Enabled = false;
                    // Enable the user to make a choice whether to play again
                    GameTerminal.Enabled = true;
                }
            }
        }
        private void NoRadio_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                First_GUI_Form GameForm = new First_GUI_Form();
                GameForm.Closed += (s, args) => this.Close();
                GameForm.Show();
            }
        }

        private void YesRadio_CheckedChanged(object sender, EventArgs e) {
            Pig_Single_Die_Game.SetUpGame();        // Reset the game
            RollBtn.Enabled = true;              // Enable the roll button again
            GameTerminal.Enabled = false;       // Disable the play again choice
            FormUpdate();
            yesButton.Checked = false;
        }


        
        
    }
}
