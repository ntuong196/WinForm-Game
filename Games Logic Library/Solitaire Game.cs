using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Game_Class_Library {
    public static class Solitaire {
       

        private static CardPile drawPile;
        private static CardPile discardPile;

        //Piles for the individual suits
        private static CardPile suitPileOne;
        private static CardPile suitPileTwo;
        private static CardPile suitPileThree;
        private static CardPile suitPileFour;

        //Piles for all the tables
        private static CardPile tableau1;
        private static CardPile tableau2;
        private static CardPile tableau3;
        private static CardPile tableau4;
        private static CardPile tableau5;
        private static CardPile tableau6;
        private static CardPile tableau7;

        private const int CARDS_IN_SUIT = 13; //Amount of cards per suit
        private const int AMOUNT_OF_TABLES = 7; //Amout of tables

        private static int[] tableCardsInPlay = new int[8]; //the amount if playable cards per table. index at 1 to allow index to match table number

        //Game Setup
        public static void StartGame() {
            drawPile = new CardPile(true);
            discardPile = new CardPile();
            suitPileOne = new CardPile();
            suitPileTwo = new CardPile();
            suitPileThree = new CardPile();
            suitPileFour = new CardPile();

            drawPile.Shuffle();
            discardPile.Add(drawPile.DealOneCard());
            tableau1 = SetupTableau(1);
            tableau2 = SetupTableau(2);
            tableau3 = SetupTableau(3);
            tableau4 = SetupTableau(4);
            tableau5 = SetupTableau(5);
            tableau6 = SetupTableau(6);
            tableau7 = SetupTableau(7);

            //sets up the cards in play array, with the index at 1
            tableCardsInPlay[0] = 0;
            for (int i = 1; i < tableCardsInPlay.Length; i++) {
                tableCardsInPlay[i] = 1;
            }

        }
        public static void DrawCard() {
            discardPile.Add(drawPile.DealOneCard());
        }
        public static void ResetDrawPile() {
            drawPile = discardPile;
            discardPile = new CardPile();
            discardPile.Add(drawPile.DealOneCard());
        }
        //Checks if the user has won the game
        public static bool CheckGameWon() {
            if ((suitPileOne.GetCount() == CARDS_IN_SUIT) && (suitPileTwo.GetCount() == CARDS_IN_SUIT) && (suitPileThree.GetCount() == CARDS_IN_SUIT) && (suitPileFour.GetCount() == CARDS_IN_SUIT)) {
                return true;
            } else {
                return false;
            }
        }

        //Checks if the requested move is a vaild and if so, make the move
        public static bool MakeMove(Card startCard, Card endCard, string startLocation, string endLocation) {
            if ((startLocation == "table") && (endLocation == "table")) {
                if (CheckValidMove(startCard, endCard) == true) {
                    //Grabs the card(s) to be played and removes them
                    Card[] stack = GrabStack(startCard);
                    int tableNum = GetTableNumber(startCard);
                    //removes card(s) in the stack from the table
                    RemoveStackFromTable(stack, tableNum);
                    MoveToTable(stack, endCard);
                    return true;
                } else {
                    return false;
                }
            } else if ((startLocation == "table") && (endLocation == "suit")) {
                if (CheckValidMoveSuit(startCard, endCard) == true) {
                    //Grabs the card(s) to be played and removes them
                    Card[] stack = GrabStack(startCard);
                    //Checks if the stack has only one card in it
                    if (stack.Length == 1) {
                        int tableNum = GetTableNumber(startCard);
                        RemoveStackFromTable(stack, tableNum);
                        MoveToSuit(startCard, endCard);
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } else if ((startLocation == "discard") && (endLocation == "table")) {
                if (CheckValidMove(startCard, endCard) == true) {
                    RemoveFromDiscard(startCard);
                    //Card put into an array to work seemlessly with existing code 
                    Card[] stack = { startCard };
                    MoveToTable(stack, endCard);
                    return true;
                } else {
                    return false;
                }
            } else if ((startLocation == "discard") && (endLocation == "suit")) {
                if (CheckValidMoveSuit(startCard, endCard) == true) {
                    RemoveFromDiscard(startCard);
                    MoveToSuit(startCard, endCard);
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
        public static bool CheckValidMove(Card played, Card destination) {

            if ((destination.GetFaceValue() == FaceValue.Two) && (played.GetFaceValue() == FaceValue.Ace) && (destination.GetColour() != played.GetColour())) {
                return true;
                //Special check for Tens and Jacks due to comparative errors 
            } else if ((destination.GetFaceValue() == FaceValue.Jack) && (played.GetFaceValue() == FaceValue.Ten) && (destination.GetColour() != played.GetColour())) {
                return true;
            } else if ((destination.GetFaceValue() == played.GetFaceValue() + 1) && (destination.GetColour() != played.GetColour())) {
                return true;
            } else {
                return false;
            }
        }
        //Similar to CheckValidMove but for the suit piles, as suits need to match up
        public static bool CheckValidMoveSuit(Card played, Card destination) {
            if ((destination.GetFaceValue() == FaceValue.Ace) && (played.GetFaceValue() == FaceValue.Two) && (played.GetSuit() == destination.GetSuit())) {
                return true;
            } else if ((destination.GetFaceValue() == FaceValue.Ten) && (played.GetFaceValue() == FaceValue.Jack) && (played.GetSuit() == destination.GetSuit())) {
                return true;
            } else if ((destination.GetFaceValue() + 1 == played.GetFaceValue()) && (played.GetSuit() == destination.GetSuit())) {
                return true;
            } else {
                return false;
            }
        }
        public static bool IfAce(Card played) {
            if (played.GetFaceValue() == FaceValue.Ace) {
                return true;
            } else {
                return false;
            }
        }
        //Check if the clicked card can be turned over 
        public static bool CheckCardFlip(int tableNum) {
            if (GetTableCount(tableNum) != 0) {
                //Checks if there is any face up cards already in the table
                if (tableCardsInPlay[tableNum] == 0) {
                    tableCardsInPlay[tableNum]++;
                }
                return true;
            } else {
                return false;
            }
        }

        //Grabs a group if cards from a pile to play
        private static Card[] GrabStack(Card played) {
            Card[] stack = new Card[1]; //Stack of cards to be moved
            CardPile tempTable = new CardPile(); //temporary cardpile to hold the table cardpile
            //find the table the played card comes from
            int tableNum = GetTableNumber(played);
            tempTable = GetTable(tableNum);
            //Grab the played cards from the table
            stack = GetCards(played, tempTable, tableNum);
            return stack;
        }
        private static Card[] GetCards(Card played, CardPile table, int tableNum) {
            //initialize stack to hold the grabed cards and counter varible max
            Card[] stack = new Card[1];
            int max = 0;
            for (int i = 0; i < GetTableCount(tableNum); i++) {
                if (table.GetCard((GetTableCount(tableNum) - 1) - i) == played) {
                    max = i;
                    stack = new Card[max + 1];
                    break;
                }
            }
            //Grab them from the last card up to the clicked card for redisplaying purposes
            for (int j = max; j > -1; j--) {
                stack[max - j] = table.GetCard((table.GetCount() - 1) - j);
            }
            return stack;
        }
        private static void RemoveStackFromTable(Card[] stack, int table) {
            //tempoary table variable, inplay variable and while loop control initiziation
            CardPile tempTable = GetTable(table);
            int tempInPlay = GetTableCardsInPlay(table);
            bool allRemoved = false;
            while (!allRemoved) {
                //loop each card in the stack and remove it from the table
                for (int i = 0; i < stack.Length; i++) {
                    for (int j = 0; j < GetTableCount(table); j++) {
                        if (tempTable.GetCard(j) == stack[i]) {
                            tempTable.RemoveCard(j);
                            tempInPlay--;
                            break;
                        }
                    }

                }
                //check if all the cards have been removed from the table
                int count = 0;
                for (int i = 0; i < tempTable.GetCount(); i++) {
                    for (int j = 0; j < stack.Length; j++) {
                        if (tempTable.GetCard(i) == stack[j]) {
                            count++;
                        }
                    }
                }
                if (count > 0) {
                    //reset the temporary table and repeat process
                    tempTable = GetTable(table);
                    tempInPlay = GetTableCardsInPlay(table);
                } else {
                    //else kill loop
                    allRemoved = true;
                }
            }
            AssignUpdatedTable(tempTable, table, tempInPlay);

        }
        //Reassign the updated table to the actual table variable 
        private static void AssignUpdatedTable(CardPile tempTable, int tableNum, int inPlay) {
            tableCardsInPlay[tableNum] = inPlay;
            switch (tableNum) {
                case 1:
                    tableau1 = tempTable;
                    break;
                case 2:
                    tableau2 = tempTable;
                    break;
                case 3:
                    tableau3 = tempTable;
                    break;
                case 4:
                    tableau4 = tempTable;
                    break;
                case 5:
                    tableau5 = tempTable;
                    break;
                case 6:
                    tableau6 = tempTable;
                    break;
                case 7:
                    tableau7 = tempTable;
                    break;
            }
        }
        private static void RemoveFromDiscard(Card played) {
            CardPile saved = discardPile;
            bool removed = false;
            while (!removed) {
                discardPile.RemoveLastCard();
                if (discardPile.ContainsCard(played)) {
                    discardPile = saved;
                } else {
                    removed = true;
                }
            }
        }
        //Determine which table the played card came from
        private static int GetTableNumber(Card played) {
            for (int table = 1; table <= AMOUNT_OF_TABLES; table++) {
                if ((GetTableCount(table) != 0) && (GetTable(table).ContainsCard(played) == true)) {
                    return table;
                }
            }
            return 0;
        }
        private static void MoveToTable(Card[] played, Card destination) {
            //Finds correct table and adds all the cards in the stack to the table
            if ((tableau1.GetCount() != 0) && (tableau1.GetLastCardInPile() == destination)) {
                for (int i = 0; i < played.Length; i++) {
                    tableau1.Add(played[i]);
                    tableCardsInPlay[1]++;
                }
            } else if ((tableau2.GetCount() != 0) && (tableau2.GetLastCardInPile() == destination)) {
                for (int i = 0; i < played.Length; i++) {
                    tableau2.Add(played[i]);
                    tableCardsInPlay[2]++;
                }
            } else if ((tableau3.GetCount() != 0) && (tableau3.GetLastCardInPile() == destination)) {
                for (int i = 0; i < played.Length; i++) {
                    tableau3.Add(played[i]);
                    tableCardsInPlay[3]++;
                }
            } else if ((tableau4.GetCount() != 0) && (tableau4.GetLastCardInPile() == destination)) {
                for (int i = 0; i < played.Length; i++) {
                    tableau4.Add(played[i]);
                    tableCardsInPlay[4]++;
                }
            } else if ((tableau5.GetCount() != 0) && (tableau5.GetLastCardInPile() == destination)) {
                for (int i = 0; i < played.Length; i++) {
                    tableau5.Add(played[i]);
                    tableCardsInPlay[5]++;
                }
            } else if ((tableau6.GetCount() != 0) && (tableau6.GetLastCardInPile() == destination)) {
                for (int i = 0; i < played.Length; i++) {
                    tableau6.Add(played[i]);
                    tableCardsInPlay[6]++;
                }
            } else if ((tableau7.GetCount() != 0) && (tableau7.GetLastCardInPile() == destination)) {
                for (int i = 0; i < played.Length; i++) {
                    tableau7.Add(played[i]);
                    tableCardsInPlay[7]++;
                }
            }

        }
        private static void MoveToSuit(Card played, Card destination) {
            if ((suitPileOne.GetCount() != 0) && (suitPileOne.GetLastCardInPile().GetSuit() == destination.GetSuit())) {
                suitPileOne.Add(played);
            } else if ((suitPileTwo.GetCount() != 0) && (suitPileTwo.GetLastCardInPile().GetSuit() == destination.GetSuit())) {
                suitPileTwo.Add(played);
            } else if ((suitPileThree.GetCount() != 0) && (suitPileThree.GetLastCardInPile().GetSuit() == destination.GetSuit())) {
                suitPileThree.Add(played);
            } else if ((suitPileFour.GetCount() != 0) && (suitPileFour.GetLastCardInPile().GetSuit() == destination.GetSuit())) {
                suitPileFour.Add(played);
            }

        }
        //Sets a single table at the start of the game
        private static CardPile SetupTableau(int amountOfCards) {
            CardPile tableau = new CardPile();
            for (int i = 0; i < amountOfCards; i++) {
                tableau.Add(drawPile.DealOneCard());
            }
            return tableau;
        }
        public static void PlayAce(Card ace, string startLocation) {
            //Determines whether the card is in the discard pile or a table
            if (startLocation == "discard") {
                RemoveFromDiscard(ace);
            } else {
                if ((tableau1.GetCount() != 0) && (tableau1.GetLastCardInPile() == ace)) {
                    tableau1.RemoveLastCard();
                    tableCardsInPlay[1]--;
                } else if ((tableau2.GetCount() != 0) && (tableau2.GetLastCardInPile() == ace)) {
                    tableau2.RemoveLastCard();
                    tableCardsInPlay[2]--;
                } else if ((tableau3.GetCount() != 0) && (tableau3.GetLastCardInPile() == ace)) {
                    tableau3.RemoveLastCard();
                    tableCardsInPlay[3]--;
                } else if ((tableau4.GetCount() != 0) && (tableau4.GetLastCardInPile() == ace)) {
                    tableau4.RemoveLastCard();
                    tableCardsInPlay[4]--;
                } else if ((tableau5.GetCount() != 0) && (tableau5.GetLastCardInPile() == ace)) {
                    tableau5.RemoveLastCard();
                    tableCardsInPlay[5]--;
                } else if ((tableau6.GetCount() != 0) && (tableau6.GetLastCardInPile() == ace)) {
                    tableau6.RemoveLastCard();
                    tableCardsInPlay[6]--;
                } else if ((tableau7.GetCount() != 0) && (tableau7.GetLastCardInPile() == ace)) {
                    tableau7.RemoveLastCard();
                    tableCardsInPlay[7]--;
                }
            }

            if (suitPileOne.GetCount() == 0) {
                suitPileOne.Add(ace);
            } else if (suitPileTwo.GetCount() == 0) {
                suitPileTwo.Add(ace);
            } else if (suitPileThree.GetCount() == 0) {
                suitPileThree.Add(ace);
            } else {
                suitPileFour.Add(ace);
            }
        }
        public static void PlayKing(Card king, string startLocation, int tableNum) {
            Card[] stack = new Card[1];
            //determines where the king starts and move it accordingly
            if (startLocation == "discard") {
                RemoveFromDiscard(king);
                stack[0] = king;
            } else {
                stack = GrabStack(king);
                int startTable = GetTableNumber(king);
                RemoveStackFromTable(stack, startTable);
            }
            switch (tableNum) {
                case 1:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau1.Add(stack[i]);
                        tableCardsInPlay[1]++;
                    }
                    break;
                case 2:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau2.Add(stack[i]);
                        tableCardsInPlay[2]++;
                    }
                    break;
                case 3:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau3.Add(stack[i]);
                        tableCardsInPlay[3]++;
                    }
                    break;
                case 4:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau4.Add(stack[i]);
                        tableCardsInPlay[4]++;
                    }
                    break;
                case 5:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau5.Add(stack[i]);
                        tableCardsInPlay[5]++;
                    }
                    break;
                case 6:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau6.Add(stack[i]);
                        tableCardsInPlay[6]++;
                    }
                    break;
                case 7:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau7.Add(stack[i]);
                        tableCardsInPlay[7]++;
                    }
                    break;
            }
        }

        public static Card GetTopDiscard() {
            return discardPile.GetLastCardInPile();
        }
        public static int GetDiscardCount() {
            return discardPile.GetCount();
        }
        public static int GetDrawPileCount() {
            return drawPile.GetCount();
        }

        public static int GetSuitOneCount() {
            return suitPileOne.GetCount();
        }
        public static int GetSuitTwoCount() {
            return suitPileTwo.GetCount();
        }
        public static int GetSuitThreeCount() {
            return suitPileThree.GetCount();
        }
        public static int GetSuitFourCount() {
            return suitPileFour.GetCount();
        }

        public static Card GetSuitPile(int suitNum) {
            switch (suitNum) {
                case 1:
                    return suitPileOne.GetLastCardInPile();
                case 2:
                    return suitPileTwo.GetLastCardInPile();
                case 3:
                    return suitPileThree.GetLastCardInPile();
                case 4:
                    return suitPileFour.GetLastCardInPile();
                default:
                    return new Card();
            }
        }

        public static int GetTableCount(int tableNum) {
            switch (tableNum) {
                case 1:
                    return tableau1.GetCount();
                case 2:
                    return tableau2.GetCount();
                case 3:
                    return tableau3.GetCount();
                case 4:
                    return tableau4.GetCount();
                case 5:
                    return tableau5.GetCount();
                case 6:
                    return tableau6.GetCount();
                case 7:
                    return tableau7.GetCount();
                default:
                    return 0;
            }
        }
        public static int GetTableCardsInPlay(int tableNum) {
            return tableCardsInPlay[tableNum];
        }
        public static CardPile GetTable(int tableNum) {
            switch (tableNum) {
                case 1:
                    return tableau1;
                case 2:
                    return tableau2;
                case 3:
                    return tableau3;
                case 4:
                    return tableau4;
                case 5:
                    return tableau5;
                case 6:
                    return tableau6;
                case 7:
                    return tableau7;
                default:
                    return new CardPile();
            }
        }
    }
}
