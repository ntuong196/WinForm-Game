using System;
using System.Collections.Generic;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    /// <summary>
    /// Logical implement for the Pig with Two Dice Form class
    /// </summary>
    public static class Pig_Double_Dice_Game {
        // Initialise 2 new dice
        private static Die[] dice = new Die[2] { new Die(), new Die() };

        // Private variables
        private static string thisPlayer;
        private static int thisTurnPoints;
        private static int[] faceValue;
        private static int[] pointsTotal;
        private static string[] whichPlayer;
        private static int WIN_POINT = 100;

        /// <summary>
        /// Set up the new game and initialise some variable
        /// </summary>
        public static void SetUpGame() {
            // Player 1 have index "0", Player 2 have index "1"
            // Dice 1 have index "0", Dice 2 have index "1"
            pointsTotal = new int[] { 0, 0 };
            thisTurnPoints = 0;
            whichPlayer = new string[] { "Player 1", "Player 2" };
            faceValue = new int[] { 0, 0 };
            // Set the current player
            thisPlayer = GetFirstPlayer();
        }// End SetUpGame

        /// <summary>
        /// The method manages to roll the die and to update the score of current player every turn
        /// Due to wheather they roll a "1" or roll the same face value
        /// </summary>
        /// <returns>bool: return true when the player rolled a “1”, otherwise returns false</returns>
        public static bool PlayGame() {

            // Roll the dice and update the face values
            for (int i = 0; i < 2; i++) {
                dice[i].RollDie();
                faceValue[i] = GetFaceValue(i);

                if ((i == 0) && (faceValue[0] == 1)) { // Check if the first face value equals 1, but the second one does not. Then, the player have no point.
                    continue;
                } else if ((i == 1) && (faceValue[0] == 1) && (faceValue[1] != 1)) {
                    if (thisPlayer == whichPlayer[0]) {
                        pointsTotal[0] -= thisTurnPoints;
                    } else {
                        pointsTotal[1] -= thisTurnPoints;
                    }
                    ResetThisTurnPoints();
                    thisPlayer = GetNextPlayer();
                    return true;
                }
                if ((i == 1) && (faceValue[0] == 1) && (faceValue[1] == 1)) { // If both face value equals 1, the player have more 25 points.
                    if (thisPlayer == whichPlayer[0]) {  // if player 1
                        pointsTotal[0] += 25;        // update player 1's score
                        thisTurnPoints += 25;     // update current turn points  
                    } else {
                        pointsTotal[1] += 25;        // if player 2
                        thisTurnPoints += 25;     // update current turn points 
                    }
                    break;
                }
                if ((i == 1) && (faceValue[0] == 2) && (faceValue[1] == 2)) { // If both face value equals 2, the player have more 8 points.
                    if (thisPlayer == whichPlayer[0]) {  // if player 1

                        pointsTotal[0] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[0] += 8;        // update player 1's score
                        thisTurnPoints += 8;     // update current turn points  
                    } else {
                        pointsTotal[1] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[1] += 8;        // if player 2
                        thisTurnPoints += 8;     // update current turn points 
                    }
                    break;
                }
                if ((i == 1) && (faceValue[0] == 3) && (faceValue[1] == 3)) {// If both face value equals 3, the player have more 12 points.
                    if (thisPlayer == whichPlayer[0]) {  // if player 1

                        pointsTotal[0] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[0] += 12;        // update player 1's score
                        thisTurnPoints += 12;     // update current turn points  
                    } else {

                        pointsTotal[1] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[1] += 12;        // if player 2
                        thisTurnPoints += 12;     // update current turn points 
                    }
                    break;
                }
                if ((i == 1) && (faceValue[0] == 4) && (faceValue[1] == 4)) {// If both face value equals 4, the player have more 16 points.
                    if (thisPlayer == whichPlayer[0]) {  // if player 1

                        pointsTotal[0] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[0] += 16;        // update player 1's score
                        thisTurnPoints += 16;     // update current turn points  
                    } else {

                        pointsTotal[1] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[1] += 16;        // if player 2
                        thisTurnPoints += 16;     // update current turn points 
                    }
                    break;
                }
                if ((i == 1) && (faceValue[0] == 5) && (faceValue[1] == 5)) {// If both face value equals 5, the player have more 20 points.
                    if (thisPlayer == whichPlayer[0]) {  // if player 1

                        pointsTotal[0] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[0] += 20;        // update player 1's score
                        thisTurnPoints += 20;     // update current turn points  
                    } else {

                        pointsTotal[1] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[1] += 20;        // if player 2
                        thisTurnPoints += 20;     // update current turn points 
                    }
                    break;
                }
                if ((i == 1) && (faceValue[0] == 6) && (faceValue[1] == 6)) {// If both face value equals 6, the player have more 24 points.
                    if (thisPlayer == whichPlayer[0]) {  // if player 1

                        pointsTotal[0] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[0] += 24;        // update player 1's score
                        thisTurnPoints += 24;     // update current turn points  
                    } else {

                        pointsTotal[1] -= faceValue[0];
                        thisTurnPoints -= faceValue[0];
                        pointsTotal[1] += 24;        // if player 2
                        thisTurnPoints += 24;     // update current turn points 
                    }
                    break;
                }

                if (faceValue[i] == 1) {   // if player rolls a 1
                    if (thisPlayer == whichPlayer[0]) {
                        pointsTotal[0] -= thisTurnPoints;
                    } else {
                        pointsTotal[1] -= thisTurnPoints;
                    }
                    ResetThisTurnPoints();
                    thisPlayer = GetNextPlayer();
                    return true;
                } else {
                    // update the current player's score
                    if (thisPlayer == whichPlayer[0]) {  // if player 1
                        pointsTotal[0] += faceValue[i];        // update player 1's score
                        thisTurnPoints += faceValue[i];     // update current turn points  
                    } else {
                        pointsTotal[1] += faceValue[i];        // if player 2
                        thisTurnPoints += faceValue[i];     // update current turn points 
                    }
                }
            }

            // Return if loop completes
            return false;
        }// End PlayGame

        /// <summary>
        /// Gets the face value
        /// </summary>
        /// <param name="die">int: Die which is being evaluated for it's face value</param>
        /// <returns>int: The face value</returns>
        public static int GetFaceValue(int die)
        {
            return (die == 0) ? dice[0].GetFaceValue() : dice[1].GetFaceValue();
        }// End GetFaceValue

        /// <summary>
        /// Method validate the winner
        /// </summary>
        /// <returns>bool: Returns true if one player reachs to 100 points and Win, returns false if not</returns>
        public static bool CheckWin() {
            return (pointsTotal[0] >= WIN_POINT || pointsTotal[1] >= WIN_POINT) ? true : false; // Only return true when points for either player has reached the winning amount
        }// End CheckWin

        /// <summary>
        /// Gets the first player's name 
        /// </summary>
        /// <returns>string[]: Return the 0th position in the whichPlayer array, Player 1</returns>
        public static string GetFirstPlayer() {
            // Return player 1's name
            return whichPlayer[0];
        }// End GetFirstwhichPlayer

        /// <summary>
        /// Gets the next player's name
        /// </summary>
        /// <returns>string[]: Returns the opposite player to the current player</returns>
        public static string GetNextPlayer() {
            return (thisPlayer == whichPlayer[0]) ? whichPlayer[1] : whichPlayer[0]; // Return the next player's name depending on the value of thisPlayer 
        }// End GetNextwhichPlayer

        /// <summary>
        /// Gets the total points of the desired player 
        /// </summary>
        /// <param name="nameOfPlayer">Name of the player whose points are being returned</param>
        /// <returns>Returns the total points respective to the name of the player inputted</returns>
        public static int GetPointsTotal(string nameOfPlayer) {
            return (nameOfPlayer == whichPlayer[0]) ? pointsTotal[0] : pointsTotal[1];
        }// End GetPoiintsTotal


        /// <summary>
        /// Determine the index of the current player
        /// </summary>
        /// <returns>string: returns the thisPlayer - index of the player</returns>
        public static string GetThisPlayer() {
            return thisPlayer;
        }// End GetthisPlayer

        /// <summary>
        /// Sets the current player variable to a desired value
        /// </summary>
        /// <param name="playerName">string: Input string paramater to set the thisPlayer value to</param>
        public static void SetThisPlayer(string playerName) {
            // Reset current turn points
            ResetThisTurnPoints();
            thisPlayer = playerName;
        }// End SetthisPlayer

        /// <summary>
        /// Resets the points of a turn when a player rolled "1"
        /// </summary>
        private static void ResetThisTurnPoints() {
            thisTurnPoints = 0;
        }// End ResetthisTurnPoints
    }
}

