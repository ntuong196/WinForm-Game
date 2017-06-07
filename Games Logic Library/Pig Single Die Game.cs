using System;
using System.Collections.Generic;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    /// <summary>
    /// Logical implement for single Pig game
    /// </summary>
    public static class Pig_Single_Die_Game {
        // Initialise Die class
        private static Die die = new Die();

        // Class private variables
        private static int[] pointsTotal;
        private static string[] whichPlayer;
        private static int faceValue;
        private static string thisPlayer;
        private static int thisTurnPoints;
        private static int WIN_POINT = 30;

        /// <summary>
        /// Set up the new game and initialise some variable
        /// </summary>
        public static void SetUpGame() {
            // Player 1 have index "0", Player 2 have index "1"
            pointsTotal = new int[] { 0, 0 };
            thisTurnPoints = 0;
            whichPlayer = new string[] { "Player 1", "Player 2" };

            // Set the current player
            thisPlayer = GetFirstPlayer();
        }// End SetUpGame

        /// <summary>
        /// Pick the first player
        /// </summary>
        /// <returns>string: Return the index of the Player 1 in array</returns>
        public static string GetFirstPlayer()
        {
            return whichPlayer[0];
        }// End GetFirstPlayer

        /// <summary>
        /// The method manages to roll the die and to update 
        /// the score of current player every turn, until they roll a "1"
        /// </summary>
        /// <returns>bool: return true when the player rolled a “1”, otherwise returns false.</returns>
        public static bool PlayGame() {
            // Start to Roll and get the value of the face
            die.RollDie();
            faceValue = GetFaceValue();
            
            // Check if player roll a "1" or not
            if (faceValue == 1) {  
                if (thisPlayer == whichPlayer[0]) {
                    pointsTotal[0] -= thisTurnPoints;
                } else {
                    pointsTotal[1] -= thisTurnPoints;
                }
                ResetThisTurnPoints();
                thisPlayer = GetNextPlayer();
                return true; 
            } else { // if not, update that player'score
                if (thisPlayer == whichPlayer[0]) {     // player 1
                    pointsTotal[0] += faceValue;        // Record player 1's score
                    thisTurnPoints += faceValue;        // Record current turn points  
                    return false;
                } else
                {                                       // player 2
                    pointsTotal[1] += faceValue;        // Record current turn points 
                    thisTurnPoints += faceValue;        // Record player 2's score
                    return false;                       
                }
            }
        }// End PlayGame

        /// <summary>
        /// After a player roll a "1", Pick the next player to Roll
        /// </summary>
        /// <returns>string: Returns the other player to play the next turn</returns>
        public static string GetNextPlayer()
        {
            return (thisPlayer == whichPlayer[0]) ? whichPlayer[1] : whichPlayer[0];
        }// End GetNextPlayer

        /// <summary>
        /// Method validate the winner
        /// </summary>
        /// <returns>bool: Returns true if one player reachs to 30 points and Win, returns false if not</returns>
        public static bool CheckWin() {
            return (pointsTotal[0] >= WIN_POINT || pointsTotal[1] >= WIN_POINT) ? true : false;
        }// End CheckWin

        /// <summary>
        /// Calculate the points of a player after rolled turns
        /// </summary>
        /// <param name="player">string: Name of the player whose points are being returned</param>
        /// <returns>int: Returns the total points of current player </returns>
        public static int GetPointsTotal(string player) {
            return (player == whichPlayer[0]) ? pointsTotal[0] : pointsTotal[1]; 
        }// End GetPoiintsTotal

        /// <summary>
        /// Gets the face value of the dice 
        /// </summary>
        /// <returns>int: Returns the value by a method in the object "die"</returns>
        public static int GetFaceValue() {
            return die.GetFaceValue();  
        }// End GetFaceValue

        /// <summary>
        /// Determine the index of the current player
        /// </summary>
        /// <returns>string: returns the thisPlayer - index of the player</returns>
        public static string GetThisPlayer() {
            return thisPlayer;
        }// End GetThisPlayer

        /// <summary>
        /// Set a player to the next one to play
        /// </summary>
        /// <param name="player">string: Input string paramater represent for a player</param>
        public static void SetThisPlayer(string player) {
            // Reset the turn points
            ResetThisTurnPoints();
            // Update the current player
            thisPlayer = player;
        }// End SetThisPlayer

        /// <summary>
        /// Resets the points of a turn when a player rolled "1"
        /// </summary>
        private static void ResetThisTurnPoints() {
                thisTurnPoints = 0;
        }// End ResetThisTurnPoints
    }
}