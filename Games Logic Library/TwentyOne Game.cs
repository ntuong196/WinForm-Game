using System;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    /// <summary>
    /// Logical implement for the TwentyOne Game
    /// </summary>
    public static class TwentyOne_Game {
        // Constant
        public const int NUM_OF_PLAYERS = 2;

        // Initialise cardPile 
        private static CardPile cardPile = new CardPile(true);

        // Initialise class variables
        // Player's index is 0, Dealer's index is 1
        private static Hand[] hands;
        private static int[] totalPoints = new int[] { 0, 0 };
        private static int[] numOfGamesWon = new int[] { 0, 0 };
        private static int numOfUserAcesWithValueOne;

        /// <summary>
        /// Initializes the class variables and shuffles the card pile at the start of the game
        /// </summary>
        public static void SetUpGame() {
            // Initialise dealer and player hands
            Hand pHand = new Hand();
            Hand dHand = new Hand();
            hands = new Hand[2] { pHand, dHand };

            // Shuffle a random amount of times for extra randomness
            Random rnd = new Random();
            int randAmount = rnd.Next(1, 10);
            for (int i = 0; i < randAmount; i++) {
                cardPile.Shuffle();
            }

            // Reset ace counter
            numOfUserAcesWithValueOne = 0;
        }// End SetUpGame

        /// <summary>
        /// Plays a turn for the dealer
        /// </summary>
        public static void PlayForDealer()
        {
            // Set total points for the dealer to current hand
            CalculateHandTotal(1);

            // Before the dealer can stand after reaching 17, keep dealing cards and recalculating
            while (totalPoints[1] < 17)
            {
                DealOneCardTo(1);
                CalculateHandTotal(1);
            }

            // If anyone has won, increment the number of games won
            if (totalPoints[0] < totalPoints[1] && totalPoints[0] < 22 && totalPoints[1] < 22)
            {
                numOfGamesWon[1]++;
            }
            else if (totalPoints[1] < totalPoints[0] && totalPoints[0] < 22 && totalPoints[1] < 22)
            {
                numOfGamesWon[0]++;
            }
        }// End PlayForDealer

        /// <summary>
        /// Deals one card from the deck to the hand of "who" and returns that card
        /// </summary>
        /// <param name="who">int: index of dealer or player</param>
        /// <returns>Card: c - the dealt card</returns>
        public static Card DealOneCardTo(int who) {
            // Create a new deck and shuffle if it is empty
            if (cardPile.GetCount() == 0) {
                cardPile = new CardPile(true);
                cardPile.Shuffle();
            }

            // Deal one card and add it to the player's hand
            Card c = cardPile.DealOneCard();
            hands[who].Add(c);
            return c;
        }// End DealOneCardTo

        /// <summary>
        /// Adds the face values of all cards in the hand of "who" and returns that total which is adjusted if the "who" is the player and has one or more aces values as one
        /// </summary>
        /// <param name="who">int: index number of the player</param>
        /// <returns>int: total number of points in the hand</returns>
        public static int CalculateHandTotal(int who) {
            int total = 0;

            foreach (Card c in hands[who]) {
                if (c.GetFaceValue() == FaceValue.Ace) {
                    foreach (Card d in hands[who]) // Check if some one recieve 2 ACE card in the begining
                    {
                        if ((d.GetFaceValue() == FaceValue.Ace) && ( d != c) && (c.GetFaceValue() == FaceValue.Ace))
                        {
                            total += 2;
                            break;
                        }
                    }
                    // Increment total by 11 if the card is an ace
                    total += 11;
                } else if (c.GetFaceValue() == FaceValue.Jack || c.GetFaceValue() == FaceValue.Queen || c.GetFaceValue() == FaceValue.King) {
                    // Increment total by 10 if the face is a 10 point card
                    total += 10;
                } else {
                    // Increment total by the index position of the enumerator + 2, which comes out as the card value
                    total += ((int)c.GetFaceValue() + 2);
                }
            } 

            // If player or dealer has busted
            if (total > 21 && who == 1) {
                numOfGamesWon[0]++;                
            } else if (total > 21 && who == 0) {
                numOfGamesWon[1]++;                
            }

            // For ever ace selected to value at one, remove 10 points from the total
            for (int i = 0; i < numOfUserAcesWithValueOne; i++) {
                total -= 10;
            }

            // Add points to the total
            totalPoints[who] = total;
            
            // Return value for evaluation
            return total;
        }// End CalculateHandTotal

        /// <summary>
        /// Returns the number of aces with value as one
        /// </summary>
        /// <returns>int: number of aces valued at one</returns>
        public static int GetNumOfUserAcesWithValueOne()
        {
            return numOfUserAcesWithValueOne;
        }// End GetNumOfAcesWithValueOne


        /// <summary>
        /// Increments the number of aces valued at one
        /// </summary>
        public static void IncrementNumOfUserAcesWithValueOne()
        {
            numOfUserAcesWithValueOne++;
        }// End IncrementNumOfUserAcesWithValueOne



        /// <summary>
        /// List all the card in who's hand
        /// </summary>
        /// <param name="who">int: index of dealer or player</param>
        /// <returns>Hand[]: the hand of the player or dealer</returns>
        public static Hand GetHand(int who) {
            return hands[who];
        }// End GetHand


        /// <summary>
        /// Calculate the total points of who
        /// </summary>
        /// <param name="who">int: index of dealer or player</param>
        /// <returns>int[]: total points of the dealer or player</returns>
        public static int GetTotalPoints(int who) {
            return totalPoints[who];
        }// End GetTotalPoints


        /// <summary>
        /// Calculate the won game of who
        /// </summary>
        /// <param name="who">int: index of dealer or player</param>
        /// <returns>int[]: won games of the dealer or player</returns>
        public static int GetNumOfGamesWon(int who) {
            return numOfGamesWon[who];
        }// End GetNumOfGamesWon


       

        /// <summary>
        /// Resets the points and games won
        /// </summary>
        public static void ResetTotals() {
            totalPoints[0] = 0;
            totalPoints[1] = 0;
            numOfGamesWon[0] = 0;
            numOfGamesWon[1] = 0;
        }// End ResetTotals
    }
}
