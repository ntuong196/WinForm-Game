using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    /// <summary>
    /// Contains all the logic necessary for implementation into the Pig with Two Dice Form class
    /// </summary>
    public static class Pig_Double_Dice_Game {
        // Initialise dice
        private static Die[] dice = new Die[2] { new Die(), new Die() };

        // Initialise class variables
        private static int[] faceValue;
        private static int[] pointsTotal;
        private static string[] playersName;

        // Additional variables
        private static string thisPlayer;
        private static int thisTurnPoints;

        private static int WIN_POINT = 100;

        /// <summary>
        /// Initialises the class variables at the start of a new game
        /// </summary>
        public static void SetUpGame() {
            // Set point values and player name array
            pointsTotal = new int[] { 0, 0 };
            thisTurnPoints = 0;
            playersName = new string[] { "Player 1", "Player 2" };
            faceValue = new int[] { 0, 0 };
            

            // Set the current player
            thisPlayer = GetFirstPlayersName();
        }// End SetUpGame

        /// <summary>
        /// Rolls the die once for the current player, updating the player’s score 
        /// appropriately according to the faceValue just rolled.
        /// </summary>
        /// <returns>bool: Returns true if the player has rolled a “1”, otherwise it returns false.</returns>
        public static bool PlayGame() {

            // Roll the dice and update the face values
            for (int i = 0; i < 2; i++) {
                dice[i].RollDie();
                faceValue[i] = GetFaceValue(i);

                if ((i == 0) && (faceValue[0] == 1)) { // Check if the first face value equals 1, but the second one does not. Then, the player have no point.
                    continue;
                } else if ((i == 1) && (faceValue[0] == 1) && (faceValue[1] != 1)) {
                    if (thisPlayer == playersName[0]) {
                        pointsTotal[0] -= thisTurnPoints;
                    } else {
                        pointsTotal[1] -= thisTurnPoints;
                    }
                    ResetThisTurnPoints();
                    thisPlayer = GetNextPlayersName();
                    return true;
                }
                if ((i == 1) && (faceValue[0] == 1) && (faceValue[1] == 1)) { // If both face value equals 1, the player have more 25 points.
                    if (thisPlayer == playersName[0]) {  // if player 1
                        pointsTotal[0] += 25;        // update player 1's score
                        thisTurnPoints += 25;     // update current turn points  
                    } else {
                        pointsTotal[1] += 25;        // if player 2
                        thisTurnPoints += 25;     // update current turn points 
                    }
                    break;
                }
                if ((i == 1) && (faceValue[0] == 2) && (faceValue[1] == 2)) { // If both face value equals 2, the player have more 8 points.
                    if (thisPlayer == playersName[0]) {  // if player 1

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
                    if (thisPlayer == playersName[0]) {  // if player 1

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
                    if (thisPlayer == playersName[0]) {  // if player 1

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
                    if (thisPlayer == playersName[0]) {  // if player 1

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
                    if (thisPlayer == playersName[0]) {  // if player 1

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
                    if (thisPlayer == playersName[0]) {
                        pointsTotal[0] -= thisTurnPoints;
                    } else {
                        pointsTotal[1] -= thisTurnPoints;
                    }
                    ResetThisTurnPoints();
                    thisPlayer = GetNextPlayersName();
                    return true;
                } else {
                    // update the current player's score
                    if (thisPlayer == playersName[0]) {  // if player 1
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
        /// Shows whether a player has won 
        /// </summary>
        /// <returns>bool: Returns true if a player has won (by reaching 100 points) and returns false if not</returns>
        public static bool HasWon() {
            return (pointsTotal[0] >= WIN_POINT || pointsTotal[1] >= WIN_POINT) ? true : false; // Only return true when points for either player has reached the winning amount
        }// End HasWon

        /// <summary>
        /// Gets the first player's name 
        /// </summary>
        /// <returns>string[]: Return the 0th position in the playersName array, Player 1</returns>
        public static string GetFirstPlayersName() {
            // Return player 1's name
            return playersName[0];
        }// End GetFirstPlayersName

        /// <summary>
        /// Gets the next player's name
        /// </summary>
        /// <returns>string[]: Returns the opposite player to the current player</returns>
        public static string GetNextPlayersName() {
            return (thisPlayer == playersName[0]) ? playersName[1] : playersName[0]; // Return the next player's name depending on the value of thisPlayer 
        }// End GetNextPlayersName

        /// <summary>
        /// Gets the total points of the desired player 
        /// </summary>
        /// <param name="nameOfPlayer">Name of the player whose points are being returned</param>
        /// <returns>Returns the total points respective to the name of the player inputted</returns>
        public static int GetPointsTotal(string nameOfPlayer) {
            return (nameOfPlayer == playersName[0]) ? pointsTotal[0] : pointsTotal[1];
        }// End GetPoiintsTotal

        /// <summary>
        /// Gets the face value
        /// </summary>
        /// <param name="die">int: Die which is being evaluated for it's face value</param>
        /// <returns>int: The face value</returns>
        public static int GetFaceValue(int die) {
            return (die == 0) ? dice[0].GetFaceValue() : dice[1].GetFaceValue();
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
            // Reset current turn points
            ResetThisTurnPoints();
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

