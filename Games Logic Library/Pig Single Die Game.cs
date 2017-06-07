using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    /// <summary>
    /// Contains all the logic necessary for implementation into the Pig Game Form class
    /// </summary>
    public static class Pig_Single_Die_Game {
        // Initialise die
        private static Die die = new Die();

        // Initialise class variables
        private static int faceValue;         
        private static int[] pointsTotal;
        private static string[] playersName;

        // Additional variables
        private static string thisPlayer;
        private static int thisTurnPoints;
        private static int WIN_POINT = 30;

        /// <summary>
        /// Initialises the class variables at the start of a new game
        /// </summary>
        public static void SetUpGame() {
            // Set point values and player name array
            pointsTotal = new int[] { 0, 0 };
            thisTurnPoints = 0;
            playersName = new string[] { "Player 1", "Player 2" };

            // Set the current player
            thisPlayer = GetFirstPlayersName();
        }// End SetUpGame

        /// <summary>
        /// Rolls the die once for the current player, updating the player’s score 
        /// appropriately according to the faceValue just rolled.
        /// </summary>
        /// <returns>bool: Returns true if the player has rolled a “1”, otherwise it returns false.</returns>
        public static bool PlayGame() {
            // Roll the die and update the face value
            die.RollDie();
            faceValue = GetFaceValue();
            
            if (faceValue == 1) {   // If player rolls a 1
                if (thisPlayer == playersName[0]) {
                    pointsTotal[0] -= thisTurnPoints;
                } else {
                    pointsTotal[1] -= thisTurnPoints;
                }
                ResetThisTurnPoints();
                thisPlayer = GetNextPlayersName();
                return true; 
            } else {
                // Update the current player's score
                if (thisPlayer == playersName[0]) {  // If player 1
                    pointsTotal[0] += faceValue;        // Update player 1's score
                    thisTurnPoints += faceValue;     // Update current turn points  
                    return false;
                } else {
                    pointsTotal[1] += faceValue;        // If player 2
                    thisTurnPoints += faceValue;     // Update current turn points 
                    return false;                       // Update player 2's score
                }
            }
        }// End PlayGame

        /// <summary>
        /// Shows whether a player has won 
        /// </summary>
        /// <returns>bool: Returns true if a player has won (by reaching 30 points) and returns false if not</returns>
        public static bool HasWon() {
            return (pointsTotal[0] >= WIN_POINT || pointsTotal[1] >= WIN_POINT) ? true : false; // Only return true when points for either player has reached the winning amount
        }// End HasWon

        /// <summary>
        /// Gets the first player's name 
        /// </summary>
        /// <returns>string: Return the 0th position in the playersName array, Player 1</returns>
        public static string GetFirstPlayersName() {
            // Return player 1's name
            return playersName[0];
        }// End GetFirstPlayersName

        /// <summary>
        /// Gets the next player's name
        /// </summary>
        /// <returns>string: Returns the opposite player to the current player</returns>
        public static string GetNextPlayersName() {
            return (thisPlayer == playersName[0]) ? playersName[1] : playersName[0]; // Return the next player's name depending on the value of thisPlayer 
        }// End GetNextPlayersName

        /// <summary>
        /// Gets the total points of the desired player 
        /// </summary>
        /// <param name="nameOfPlayer">string: Name of the player whose points are being returned</param>
        /// <returns>int: Returns the total points respective to the name of the player inputted</returns>
        public static int GetPointsTotal(string nameOfPlayer) {
            return (nameOfPlayer == playersName[0]) ? pointsTotal[0] : pointsTotal[1]; 
        }// End GetPoiintsTotal

        /// <summary>
        /// Gets the face value 
        /// </summary>
        /// <returns>int: Returns the value derived from a method in the die object</returns>
        public static int GetFaceValue() {
            return die.GetFaceValue();  
        }// End GetFaceValue

        /// <summary>
        /// Gets the current player value
        /// </summary>
        /// <returns>string: returns the thisPlayer variable</returns>
        public static string GetThisPlayer() {
            return thisPlayer;
        }// End GetthisPlayer

        /// <summary>
        /// Sets the current player variable to a desired value
        /// </summary>
        /// <param name="playerName">string: Input string paramater to set the thisPlayer value to</param>
        public static void SetThisPlayer(string playerName) {
            // Reset the turn points
            ResetThisTurnPoints();
            // Update the current player
            thisPlayer = playerName;
        }// End SetthisPlayer

        /// <summary>
        /// Resets the current turn points
        /// </summary>
        private static void ResetThisTurnPoints() {
                thisTurnPoints = 0;
        }// End ResetthisTurnPoints
    }
}

