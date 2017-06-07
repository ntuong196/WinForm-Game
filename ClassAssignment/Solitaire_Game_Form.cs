using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Low_Level_Objects_Library;
using Game_Class_Library;

namespace ClassAssignment
{
    /// <summary>
    /// GUI form control for the Solitaire Game
    /// Using the logical implement in the Solitaire Form
    /// </summary>
    public partial class SolitaireForm : Form
    {
        Card startCard;
        Card destinationCard;
        string startLocation;
        string destination;
        const string LOC_DISCARD = "discard";
        const string LOC_SUIT = "suit";
        const string LOC_TABLE = "table";

        //Table picturebox arrays
        PictureBox[] tableau1Img;
        PictureBox[] tableau2Img;
        PictureBox[] tableau3Img;
        PictureBox[] tableau4Img;
        PictureBox[] tableau5Img;
        PictureBox[] tableau6Img;
        PictureBox[] tableau7Img;
        
        // Additional Variable check a Clicked card to move it
        int cardsClicked = 0;

        /// <summary>
        /// Initialise Form
        /// </summary>
        public SolitaireForm()
        {
            InitializeComponent();
            Solitaire.SetUpGame();
            // Set up Image and set the Discard Pile wait for Click Event
            DrawPile.Image = Images.GetBackOfCardImage();
            DiscardPile.Click += new EventHandler(DiscardCard_Click);
            // Update Table
            UpdateDiscard();
            UpdateAllTables();
        }

        
        // Function need to update the table
        private void UpdateAllTables()
        {
            UpdateTableauOne();
            UpdateTableauTwo();
            UpdateTableauThree();
            UpdateTableauFour();
            UpdateTableauFive();
            UpdateTableauSix();
            UpdateTableauSeven();
        }

        private void UpdateAllSuits()
        {
            UpdateSuitOne();
            UpdateSuitTwo();
            UpdateSuitThree();
            UpdateSuitFour();
        }

        // Update the suit individually 
        private void UpdateSuitOne()
        {
            if (Solitaire.GetSuitOneCount() != 0)
            {
                PictureBox cardImg = UpdateSinglePictureBox(Solitaire.GetSuitPile(1));
                SuitPile1.Image = cardImg.Image;
                SuitPile1.Tag = cardImg.Tag;
            }
        }
        private void UpdateSuitTwo()
        {
            if (Solitaire.GetSuitTwoCount() != 0)
            {
                PictureBox cardImg = UpdateSinglePictureBox(Solitaire.GetSuitPile(2));
                SuitPile2.Image = cardImg.Image;
                SuitPile2.Tag = cardImg.Tag;
            }
        }
        private void UpdateSuitThree()
        {
            if (Solitaire.GetSuitThreeCount() != 0)
            {
                PictureBox cardImg = UpdateSinglePictureBox(Solitaire.GetSuitPile(3));
                SuitPile3.Image = cardImg.Image;
                SuitPile3.Tag = cardImg.Tag;

            }
        }
        private void UpdateSuitFour()
        {
            if (Solitaire.GetSuitFourCount() != 0)
            {
                PictureBox cardImg = UpdateSinglePictureBox(Solitaire.GetSuitPile(4));
                SuitPile4.Image = cardImg.Image;
                SuitPile4.Tag = cardImg.Tag;

            }
        }


        // Some useful function need to manipulate the card

        private void CardFlip_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = (PictureBox)sender;
            //Grabs the table number from the card to help determine which table the card is from
            int tableNum = (int)clickedCard.Tag;
            if (Solitaire.CheckTurnOver(tableNum) == true)
            {
                //resets all the table graphics
                UpdateAllTables();
            }
        }
        //Method used for empty tables to play a king
        private void BlankTable_Click(object sender, EventArgs e)
        {
            if ((cardsClicked == 1) && (startCard.GetFaceValue() == FaceValue.King))
            {
                PictureBox clickedTable = (PictureBox)sender;
                int tableNum = (int)clickedTable.Tag;
                Solitaire.PlayKing(startCard, startLocation, tableNum);
                //resets the click count to start a new play
                cardsClicked = 0;
                //Update all graphics
                UpdateAll();
            }
        }
        private void PBDraw_Click(object sender, EventArgs e)
        {
            //checks if the draw pile is empty, and resets it if need be. Otherwise deals a card. 
            if (Solitaire.GetDrawPileCount() != 0)
            {
                Solitaire.DrawCard();
                UpdateDiscard();
                if (Solitaire.GetDrawPileCount() == 0)
                {
                    DrawPile.Image = null;
                }
            }
            else {
                Solitaire.ResetDrawPile();
                UpdateDiscard();
                DrawPile.Image = Images.GetBackOfCardImage();
            }
            /*Drawing from a deck will cancel any plays currently in motion. I.e the player
             * clicks a card to play but doesn't click on where they want to play that card to. 
            */
            cardsClicked = 0;
        }
        

        // update all the Tableau after a move
        private void UpdateTableauOne()
        {
            //if table not empty
            if (Solitaire.GetTableCount(1) != 0)
            {
                tableau1Img = UpdateTableau(Solitaire.GetTable(1), Solitaire.GetTableCardsInPlay(1), 1);
                Tableau1.Controls.Clear();
                for (int i = 0; i < Solitaire.GetTableCount(1); i++)
                {
                    Tableau1.Controls.Add(tableau1Img[i]);
                }
                //else make blank table
            }
            else {
                tableau1Img = SetBlankTableau(1);
                Tableau1.Controls.Clear();
                Tableau1.Controls.Add(tableau1Img[0]);
            }

        }

        private void UpdateTableauTwo()
        {
            if (Solitaire.GetTableCount(2) != 0)
            {
                tableau2Img = UpdateTableau(Solitaire.GetTable(2), Solitaire.GetTableCardsInPlay(2), 2);
                Tableau2.Controls.Clear();
                for (int i = 0; i < Solitaire.GetTableCount(2); i++)
                {
                    Tableau2.Controls.Add(tableau2Img[i]);
                }
            }
            else {
                tableau2Img = SetBlankTableau(2);
                Tableau2.Controls.Clear();
                Tableau2.Controls.Add(tableau2Img[0]);
            }
        }
        private void UpdateTableauThree()
        {
            if (Solitaire.GetTableCount(3) != 0)
            {
                tableau3Img = UpdateTableau(Solitaire.GetTable(3), Solitaire.GetTableCardsInPlay(3), 3);
                Tableau3.Controls.Clear();
                for (int i = 0; i < Solitaire.GetTableCount(3); i++)
                {
                    Tableau3.Controls.Add(tableau3Img[i]);
                }
            }
            else {
                tableau3Img = SetBlankTableau(3);
                Tableau3.Controls.Clear();
                Tableau3.Controls.Add(tableau3Img[0]);
            }
        }
        private void UpdateTableauFour()
        {
            if (Solitaire.GetTableCount(4) != 0)
            {
                tableau4Img = UpdateTableau(Solitaire.GetTable(4), Solitaire.GetTableCardsInPlay(4), 4);
                Tableau4.Controls.Clear();
                for (int i = 0; i < Solitaire.GetTableCount(4); i++)
                {
                    Tableau4.Controls.Add(tableau4Img[i]);
                }
            }
            else {
                tableau4Img = SetBlankTableau(4);
                Tableau4.Controls.Clear();
                Tableau4.Controls.Add(tableau4Img[0]);
            }
        }
        private void UpdateTableauFive()
        {
            if (Solitaire.GetTableCount(5) != 0)
            {
                tableau5Img = UpdateTableau(Solitaire.GetTable(5), Solitaire.GetTableCardsInPlay(5), 5);
                Tableau5.Controls.Clear();
                for (int i = 0; i < Solitaire.GetTableCount(5); i++)
                {
                    Tableau5.Controls.Add(tableau5Img[i]);
                }
            }
            else {
                tableau5Img = SetBlankTableau(5);
                Tableau5.Controls.Clear();
                Tableau5.Controls.Add(tableau5Img[0]);
            }
        }
        private void UpdateTableauSix()
        {
            if (Solitaire.GetTableCount(6) != 0)
            {
                tableau6Img = UpdateTableau(Solitaire.GetTable(6), Solitaire.GetTableCardsInPlay(6), 6);
                Tableau6.Controls.Clear();
                for (int i = 0; i < Solitaire.GetTableCount(6); i++)
                {
                    Tableau6.Controls.Add(tableau6Img[i]);
                }
            }
            else {
                tableau6Img = SetBlankTableau(6);
                Tableau6.Controls.Clear();
                Tableau6.Controls.Add(tableau6Img[0]);
            }
        }
        private void UpdateTableauSeven()
        {
            if (Solitaire.GetTableCount(7) != 0)
            {
                tableau7Img = UpdateTableau(Solitaire.GetTable(7), Solitaire.GetTableCardsInPlay(7), 7);
                Tableau7.Controls.Clear();
                for (int i = 0; i < Solitaire.GetTableCount(7); i++)
                {
                    Tableau7.Controls.Add(tableau7Img[i]);
                }
            }
            else {
                tableau7Img = SetBlankTableau(7);
                Tableau7.Controls.Clear();
                Tableau7.Controls.Add(tableau7Img[0]);
            }
        }

        /// <summary>
        /// Method to move the card after check it is a valid move or not
        /// </summary>
        /// <param name="card"></param>
        /// <param name="location"></param>
        private void playCard(Card card, string location)
        {
            //If card is an ace, 
            if ((card.GetFaceValue() == FaceValue.Ace) && (location != LOC_SUIT))
            {
                Solitaire.PlayAce(card, location);
                //resets click count to start new move
                cardsClicked = 0;
                UpdateAll();
            }
            else {
                //if this is the start of a move
                if (cardsClicked == 0)
                {
                    startCard = card;
                    startLocation = location;
                    cardsClicked++;
                    //Else make move
                }
                else {
                    destinationCard = card;
                    destination = location;
                    //Check if move is valid, and if so make it
                    if (Solitaire.MoveCard(startCard, destinationCard, startLocation, destination) == false)
                    {
                        //trying to place on the discard pile
                        if (destination == LOC_DISCARD)
                        {
                            MessageBox.Show("Cannot place card onto Discard pile");
                            //other invaild move
                        }
                        else {
                            MessageBox.Show("ERROR - Move not allowed - Cannot place card onto this card");
                        }
                        //check if game over
                    }
                    else if ((destination == LOC_SUIT) && (Solitaire.HasWon() == true))
                    {
                        MessageBox.Show("Congratulations! You won the game!", "You Win!", MessageBoxButtons.OK);
                        this.Close();
                    }
                    //reset for next move and update graphics
                    cardsClicked = 0;
                    UpdateAll();
                }
            }
        }
        private void UpdateDiscard()
        {
            //grab the last card (if any) and display it
            if (Solitaire.GetDiscardCount() != 0)
            {
                PictureBox cardImg = UpdateSinglePictureBox(Solitaire.GetTopDiscard());
                DiscardPile.Image = cardImg.Image;
                DiscardPile.Tag = cardImg.Tag;
            }
            else {
                DiscardPile.Image = null;
            }
        }

        //Makes a single picture box for a card
        private PictureBox UpdateSinglePictureBox(Card card)
        {
            PictureBox cardImg = new PictureBox();
            cardImg.SizeMode = PictureBoxSizeMode.AutoSize;
            cardImg.Dock = DockStyle.Fill;
            cardImg.Image = Images.GetCardImage(card);
            cardImg.Tag = card;
            return cardImg;
        }

        private void DiscardCard_Click(object sender, EventArgs e)
        {
            //Grabs the top card and sets it to be played
            if (Solitaire.GetDiscardCount() != 0)
            {
                PictureBox clickedCard = (PictureBox)sender;
                Card card = (Card)clickedCard.Tag;
                playCard(card, LOC_DISCARD);
            }
        }
        
        //Plays a card from the table
        private void TableCard_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = (PictureBox)sender;
            Card card = (Card)clickedCard.Tag;

            playCard(card, LOC_TABLE);
        }
        //Generates an entire tables worth of card graphics
        private PictureBox[] UpdateTableau(CardPile table, int inPlay, int tableNum)
        {
            PictureBox cardImg;
            PictureBox[] tableauImg = new PictureBox[table.GetCount()];
            Card card;

            //loops through each card
            for (int i = 0; i < table.GetCount(); i++)
            {
                cardImg = new PictureBox();
                cardImg.SizeMode = PictureBoxSizeMode.AutoSize;
                cardImg.Dock = DockStyle.Fill;
                card = table.GetCard(i);
                //if Face up card
                if (i >= (table.GetCount() - inPlay))
                {
                    cardImg.Image = Images.GetCardImage(card);
                    tableauImg[i] = cardImg;
                    tableauImg[i].Click += new EventHandler(TableCard_Click);
                    tableauImg[i].Tag = card;
                    //else face down card
                }
                else {
                    tableauImg[i] = cardImg;
                    tableauImg[i].Click += new EventHandler(CardFlip_Click);
                    tableauImg[i].Tag = tableNum;
                    cardImg.Image = Images.GetBackOfCardImage();
                }
            }
            return tableauImg;
        }
        private void SuitCard_Click(object sender, EventArgs e)
        {
            //Try used incase the player clicks an empty suit pile
            try
            {
                PictureBox clickedCard = (PictureBox)sender;
                Card card = (Card)clickedCard.Tag;
                playCard(card, LOC_SUIT);
            }
            catch { }
        }
        private PictureBox[] SetBlankTableau(int tableNum)
        {
            PictureBox cardImg = new PictureBox();
            PictureBox[] tableauImg = new PictureBox[1];

            //black image to allow kings to be placed down
            cardImg.SizeMode = PictureBoxSizeMode.AutoSize;
            cardImg.Dock = DockStyle.Fill;
            cardImg.Image = null;
            cardImg.BackColor = System.Drawing.Color.White;
            cardImg.Size = new System.Drawing.Size(65, 95);
            tableauImg[0] = cardImg;
            tableauImg[0].Click += new EventHandler(BlankTable_Click);
            tableauImg[0].Tag = tableNum;
            return tableauImg;
        }
        
        
        
        private void UpdateAll()
        {
            UpdateDiscard();
            UpdateAllSuits();
            UpdateAllTables();
        }

    }
}
