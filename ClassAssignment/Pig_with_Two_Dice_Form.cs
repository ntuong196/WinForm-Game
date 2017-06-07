using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Games_Logic_Library;


namespace ClassAssignment
{
    /// <summary>
    /// GUI form control for the Pig with Two Die Game
    /// Using the logical implement in the Pig with Two Dice Form
    /// </summary>
    public partial class Pig_with_Two_Dice_Form : Form
    {
        // Timer tick
        int tick = 0;

        /// <summary>
        /// Initialise Form
        /// </summary>
        public Pig_with_Two_Dice_Form()
        {
            InitializeComponent();
            Pig_Double_Dice_Game.SetUpGame();
            UpdateForm();
        }

        /// <summary>
        /// "Help" function that is called at the end of the timer, updates buttons according the game rules and links the GUI with the game logic library
        /// </summary>
        private void Roll()
        {
            HoldBtn.Enabled = true; // Enabled the hold button once a die has been thrown
            if (Pig_Double_Dice_Game.PlayGame())
            { // If a 1 has been thrown
                HoldBtn.Enabled = false;       // Disable the hold button
                UpdateForm();
                MessageBox.Show("Sorry you have thrown a 1.\nYour turn is over!\nYour score reverts to " + Pig_Double_Dice_Game.GetPointsTotal(Pig_Double_Dice_Game.GetNextPlayersName()));
            }
            else {
                UpdateForm();
                if (Pig_Double_Dice_Game.HasWon())
                { // If a player has won the game
                    MessageBox.Show(Pig_Double_Dice_Game.GetThisPlayer() + " has won!\nWell done.");
                    // Disable gameplay buttons until the user makes a choice whether to play again
                    RollBtn.Enabled = false;
                    HoldBtn.Enabled = false;
                    // Enable the user to make a choice whether to play again
                    GameTerminal.Enabled = true;
                }
            }
        }

        /// <summary>
        /// "Help" function to update the form with the game value
        /// </summary>
        void UpdateForm()
        {
            diePictureBox1.Image = Images.GetDieImage(Pig_Double_Dice_Game.GetFaceValue(0));           // Set the image to the die value
            diePictureBox2.Image = Images.GetDieImage(Pig_Double_Dice_Game.GetFaceValue(1));           // Set the image to the die value
            TotalPointsPlayer1.Text = Pig_Double_Dice_Game.GetPointsTotal("Player 1").ToString();   // Set the Player 1 points label to player 1's points
            TotalPointPlayer2.Text = Pig_Double_Dice_Game.GetPointsTotal("Player 2").ToString();   // Set the Player 2 points label to player 2's points

            textLine1.Text = Pig_Double_Dice_Game.GetThisPlayer();                                // Set the information text's first line to the player name
            textLine2.Text = (HoldBtn.Enabled) ? "Roll or Hold" : "Roll Die";                    // Set the information text's second line to the player's available action
        }


        private void RollButton_Click(object sender, EventArgs e)
        {
            // Start roll timer
            rollTimer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;

            if (tick < 6)
            {
                RandomDiceImage();
            }
            else {
                rollTimer.Stop();
                tick = 0;
                Roll();
            }
        }




        private void HoldButton_Click(object sender, EventArgs e)
        {
            Pig_Double_Dice_Game.SetThisPlayer(Pig_Double_Dice_Game.GetNextPlayersName());     // Move to next player
            HoldBtn.Enabled = false;
            UpdateForm();
        }

        /// <summary>
        /// Helper function that randomly updates the dice image boxes to different face values
        /// </summary>
        private void RandomDiceImage()
        {
            Random rnd = new Random();
            int face = rnd.Next(1, 6);
            int face2 = rnd.Next(1, 6);
            diePictureBox1.Image = Images.GetDieImage(face);           // Set the image to the die value
            diePictureBox2.Image = Images.GetDieImage(face2);
        }





        private void YesRadio_CheckedChanged(object sender, EventArgs e)
        {
            Pig_Double_Dice_Game.SetUpGame();        // Reset the game
            RollBtn.Enabled = true;              // Enable the roll button again
            GameTerminal.Enabled = false;       // Disable the play again choice
            UpdateForm();
            YesButton.Checked = false;
        }


        private void NoRadio_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                First_GUI_Form GameForm = new First_GUI_Form();
                GameForm.Closed += (s, args) => this.Close();
                GameForm.Show();
            }
        }

    }
}
